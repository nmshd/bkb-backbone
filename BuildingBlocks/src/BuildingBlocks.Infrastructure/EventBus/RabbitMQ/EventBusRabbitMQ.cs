﻿using System.Net.Sockets;
using System.Text;
using Autofac;
using Azure.Messaging.ServiceBus;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Enmeshed.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus.Events;
using Enmeshed.BuildingBlocks.Infrastructure.EventBus.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Enmeshed.BuildingBlocks.Infrastructure.EventBus.RabbitMQ;

public class EventBusRabbitMq : IEventBus, IDisposable
{
    private const string BROKER_NAME = "event_bus";
    private const string AUTOFAC_SCOPE_NAME = "event_bus";

    private readonly ILifetimeScope _autofac;
    private readonly ILogger<EventBusRabbitMq> _logger;

    private readonly IRabbitMqPersistentConnection _persistentConnection;
    private readonly int _connectionRetryCount;
    private readonly HandlerRetryBehavior _handlerRetryBehavior;
    private readonly IEventBusSubscriptionsManager _subsManager;

    private IModel _consumerChannel;
    private readonly string? _queueName;
    private EventingBasicConsumer? _consumer;

    public EventBusRabbitMq(IRabbitMqPersistentConnection persistentConnection, ILogger<EventBusRabbitMq> logger,
        ILifetimeScope autofac, IEventBusSubscriptionsManager? subsManager, HandlerRetryBehavior handlerRetryBehavior, string? queueName = null,
        int connectionRetryCount = 5)
    {
        _persistentConnection =
            persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _subsManager = subsManager ?? new InMemoryEventBusSubscriptionsManager();
        _queueName = queueName;
        _consumerChannel = CreateConsumerChannel();
        _autofac = autofac;
        _connectionRetryCount = connectionRetryCount;
        _handlerRetryBehavior = handlerRetryBehavior;
    }

    public void Dispose()
    {
        _consumerChannel.Dispose();
        _subsManager.Clear();
    }

    public void StartConsuming()
    {
        if (_consumer is null)
        {
            throw new Exception("Cannnot start consuming without a consumer set.");
        }

        _consumerChannel.BasicConsume(_queueName, false, _consumer);
    }

    public void Publish(IntegrationEvent @event)
    {
        if (!_persistentConnection.IsConnected) _persistentConnection.TryConnect();

        var policy = Policy.Handle<BrokerUnreachableException>()
            .Or<SocketException>()
            .WaitAndRetry(_connectionRetryCount,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (ex, _) => _logger.SocketException(ex.ToString()));

        var eventName = @event.GetType().Name;

        _logger.LogInformation("Creating RabbitMQ channel to publish event: '{EventId}' ({EventName})", @event.IntegrationEventId, eventName);

        _persistentConnection.CreateModel().ExchangeDeclare(BROKER_NAME, "direct");

        _logger.LogInformation("Declaring RabbitMQ exchange to publish event: '{EventId}'", @event.IntegrationEventId);

        var message = JsonConvert.SerializeObject(@event, new JsonSerializerSettings
        {
            ContractResolver = new ContractResolverWithPrivates()
        });

        var body = Encoding.UTF8.GetBytes(message);

        policy.Execute(() =>
        {
            _logger.LogDebug("Publishing event to RabbitMQ: '{EventId}'", @event.IntegrationEventId);

            using var channel = _persistentConnection.CreateModel();
            var properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2; // persistent
            properties.MessageId = @event.IntegrationEventId;

            channel.BasicPublish(BROKER_NAME,
                eventName,
                true,
                properties,
                body);

            _logger.PublishedIntegrationEvent(@event.IntegrationEventId);
        });
    }

    public void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        var eventName = _subsManager.GetEventKey<T>();
        DoInternalSubscription(eventName);

        _logger.LogInformation("Subscribing to event '{EventName}' with {EventHandler}", eventName, typeof(TH).GetType().Name);

        _subsManager.AddSubscription<T, TH>();
    }

    private void DoInternalSubscription(string eventName)
    {
        var containsKey = _subsManager.HasSubscriptionsForEvent(eventName);
        if (containsKey)
        {
            _logger.LogInformation("The messaging entity '{eventName}' already exists.", eventName);
            return;
        }

        if (!_persistentConnection.IsConnected) _persistentConnection.TryConnect();

        _logger.LogTrace("Trying to bind queue '{QueueName}' on RabbitMQ ...", _queueName);

        using var channel = _persistentConnection.CreateModel();
        channel.QueueBind(_queueName,
            BROKER_NAME,
            eventName);

        _logger.LogTrace("Successfully bound queue '{QueueName}' on RabbitMQ.", _queueName);
    }

    private IModel CreateConsumerChannel()
    {
        if (!_persistentConnection.IsConnected) _persistentConnection.TryConnect();

        _logger.LogInformation("Creating RabbitMQ consumer channel");

        var channel = _persistentConnection.CreateModel();

        channel.ExchangeDeclare(BROKER_NAME,
            "direct");

        channel.QueueDeclare(_queueName,
            true,
            false,
            false,
            null);

        _consumer = new EventingBasicConsumer(channel);
        _consumer.Received += async (_, eventArgs) =>
        {
            var eventName = eventArgs.RoutingKey;
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            try
            {
                await ProcessEvent(eventName, message);

                channel.BasicAck(eventArgs.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                channel.BasicReject(eventArgs.DeliveryTag, true);

                _logger.ErrorWhileProcessingIntegrationEvent(eventName);
            }
        };

        channel.CallbackException += (_, ea) =>
        {
            _logger.LogWarning(ea.Exception, "Recreating RabbitMQ consumer channel");

            _consumerChannel.Dispose();
            _consumerChannel = CreateConsumerChannel();
        };

        return channel;
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        _logger.LogDebug("Processing RabbitMQ event: '{EventName}'", eventName);

        if (_subsManager.HasSubscriptionsForEvent(eventName))
        {
            await using var scope = _autofac.BeginLifetimeScope(AUTOFAC_SCOPE_NAME);
            var subscriptions = _subsManager.GetHandlersForEvent(eventName);
            foreach (var subscription in subscriptions)
            {
                var eventType = subscription.EventType;

                if (eventType == null) throw new Exception($"Unsupported event type '${eventType}' received.");

                var integrationEvent = JsonConvert.DeserializeObject(message, eventType,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new ContractResolverWithPrivates()
                    });
                var handler = scope.ResolveOptional(subscription.HandlerType) ?? throw new Exception(
                        $"The handler type {subscription.HandlerType.FullName} is not registered in the dependency container.");
                var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);

                var policy = EventBusRetryPolicyFactory.Create(
                    _handlerRetryBehavior, (ex, _) => _logger.ErrorWhileExecutingEventHandlerType(eventName, ex.Message, ex.StackTrace!));

                await policy.ExecuteAsync(() => (Task)concreteType.GetMethod("Handle")!.Invoke(handler, new[] { integrationEvent })!);
            }
        }
        else
        {
            _logger.NoSubscriptionForEvent(eventName);
        }
    }
}

internal static partial class EventBusRabbitMQLogs
{
    [LoggerMessage(
        EventId = 411326,
        EventName = "EventBusRabbitMQ.SocketException",
        Level = LogLevel.Warning,
        Message = "{exceptionString}")]
    public static partial void SocketException(this ILogger logger, string exceptionString);

    [LoggerMessage(
        EventId = 585231,
        EventName = "EventBusRabbitMQ.PublishedIntegrationEvent",
        Level = LogLevel.Debug,
        Message = "Successfully published event with id '{integrationEventId}'.")]
    public static partial void PublishedIntegrationEvent(this ILogger logger, string integrationEventId);

    [LoggerMessage(
        EventId = 702822,
        EventName = "EventBusRabbitMQ.ErrorWhileProcessingIntegrationEvent",
        Level = LogLevel.Error,
        Message = "An error occurred while processing the integration event of type '{eventName}'.")]
    public static partial void ErrorWhileProcessingIntegrationEvent(this ILogger logger, string eventName);

    [LoggerMessage(
        EventId = 980768,
        EventName = "EventBusRabbitMQ.NoSubscriptionForEvent",
        Level = LogLevel.Warning,
        Message = "No subscription for event: '{eventName}'.")]
    public static partial void NoSubscriptionForEvent(this ILogger logger, string eventName);

    [LoggerMessage(
        EventId = 288394,
        EventName = "EventBusRabbitMQ.ErrorWhileExecutingEventHandlerType",
        Level = LogLevel.Warning,
        Message = "The following error was thrown while executing '{eventHandlerType}':\n'{errorMessage}'\n{stackTrace}.\nAttempting to retry...")]
    public static partial void ErrorWhileExecutingEventHandlerType(this ILogger logger, string eventHandlerType, string errorMessage, string stackTrace);
}
