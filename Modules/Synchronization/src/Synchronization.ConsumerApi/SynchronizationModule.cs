﻿using Backbone.BuildingBlocks.API;
using Backbone.BuildingBlocks.API.Extensions;
using Backbone.BuildingBlocks.Application.Abstractions.Infrastructure.EventBus;
using Backbone.Synchronization.Application;
using Backbone.Synchronization.Application.Extensions;
using Backbone.Synchronization.Infrastructure.Persistence;
using Backbone.Tooling.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Backbone.Synchronization.ConsumerApi;

public class SynchronizationModule : AbstractModule
{
    public override string Name => "Synchronization";

    public override void ConfigureServices(IServiceCollection services, IConfigurationSection configuration)
    {
        services.ConfigureAndValidate<ApplicationOptions>(options => configuration.GetSection("Application").Bind(options));
        services.ConfigureAndValidate<Configuration>(configuration.Bind);

        var parsedConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<Configuration>>().Value;

        services.AddPersistence(options =>
        {
            options.DbOptions.Provider = parsedConfiguration.Infrastructure.SqlDatabase.Provider;
            options.DbOptions.DbConnectionString = parsedConfiguration.Infrastructure.SqlDatabase.ConnectionString;

            options.BlobStorageOptions.CloudProvider = parsedConfiguration.Infrastructure.BlobStorage.CloudProvider;
            options.BlobStorageOptions.ConnectionInfo = parsedConfiguration.Infrastructure.BlobStorage.ConnectionInfo;
            options.BlobStorageOptions.Container =
                parsedConfiguration.Infrastructure.BlobStorage.ContainerName.IsNullOrEmpty()
                    ? "synchronization"
                    : parsedConfiguration.Infrastructure.BlobStorage.ContainerName;
        });

        services.AddApplication();

        services.AddSqlDatabaseHealthCheck(Name, parsedConfiguration.Infrastructure.SqlDatabase.Provider, parsedConfiguration.Infrastructure.SqlDatabase.ConnectionString);
    }

    public override void ConfigureEventBus(IEventBus eventBus)
    {
        eventBus.AddSynchronizationIntegrationEventSubscriptions();
    }
}
