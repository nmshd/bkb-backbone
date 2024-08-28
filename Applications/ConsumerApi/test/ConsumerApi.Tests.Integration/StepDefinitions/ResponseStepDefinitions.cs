﻿using Backbone.BuildingBlocks.SDK.Endpoints.Common.Types;
using Backbone.ConsumerApi.Tests.Integration.Contexts;
using Backbone.ConsumerApi.Tests.Integration.Extensions;
using Backbone.ConsumerApi.Tests.Integration.Helpers;
using static Backbone.ConsumerApi.Tests.Integration.Helpers.ThrowHelpers;

namespace Backbone.ConsumerApi.Tests.Integration.StepDefinitions;

[Binding]
internal class ResponseStepDefinitions
{
    #region Constructor, Fields, Properties

    private readonly MessagesContext _messagesContext;
    private readonly ResponseContext _responseContext;
    private readonly ClientPool _clientPool;

    public ResponseStepDefinitions(MessagesContext messagesContext, ResponseContext responseContext, ClientPool clientPool)
    {
        _messagesContext = messagesContext;
        _responseContext = responseContext;
        _clientPool = clientPool;
    }

    private IResponse? WhenResponse => _responseContext.WhenResponse;

    #endregion

    [Then(@"the response status code is (\d\d\d) \(.+\)")]
    public void ThenTheResponseStatusCodeIs(int expectedStatusCode)
    {
        ThrowIfNull(WhenResponse);
        ((int)WhenResponse!.Status).Should().Be(expectedStatusCode);
    }

    [Then(@"the response content contains an error with the error code ""([^""]*)""")]
    public void ThenTheResponseContentContainsAnErrorWithTheErrorCode(string errorCode)
    {
        WhenResponse!.Error.Should().NotBeNull();
        WhenResponse.Error!.Code.Should().Be(errorCode);
    }

    [Then(@"the response contains a ([a-zA-Z]+)")]
    public async Task ThenTheResponseContains(string responseType)
    {
        WhenResponse!.Should().NotBeNull();
        WhenResponse!.Should().BeASuccess();
        await WhenResponse!.Should().ComplyWithSchema();
    }

    #region Challenges

    [Then(@"the Challenge has an expiration date in the future")]
    public void ThenTheChallengeHasAnExpirationDateInTheFuture()
    {
        _responseContext.ChallengeResponse!.Result!.ExpiresAt.Should().BeAfter(DateTime.UtcNow);
    }

    #endregion

    #region Identities

    [Then(@"the response status is '([^']*)'")]
    public void ThenTheResponseStatusIs(string deletionProcessStatus)
    {
        _responseContext.CancelDeletionProcessResponse!.Result.Should().NotBeNull();
        _responseContext.CancelDeletionProcessResponse.Should().BeASuccess();
        _responseContext.CancelDeletionProcessResponse.Result!.Status.Should().Be(deletionProcessStatus);
    }

    #endregion

    #region Messages

    [Then(@"the error contains a list of Identities to be deleted that includes ([a-zA-Z0-9]+)")]
    public void ThenTheErrorContainsAListOfIdentitiesToBeDeletedThatIncludesIdentity(string identityName)
    {
        var errorData = _responseContext.SendMessageResponse!.Error!.Data?.As<PeersToBeDeletedErrorData>();
        errorData.Should().NotBeNull();
        errorData!.PeersToBeDeleted.Contains(_clientPool.FirstForIdentityName(identityName).IdentityData!.Address).Should().BeTrue();
    }

    [Then(@"the response contains the Messages ([a-zA-Z0-9]+) and ([a-zA-Z0-9]+)")]
    public void ThenTheResponseContainsTheMessages(string message1Name, string message2Name)
    {
        var message1 = _messagesContext.Messages[message1Name];
        var message2 = _messagesContext.Messages[message2Name];

        ThrowIfNull(_responseContext.GetMessagesResponse);

        _responseContext.GetMessagesResponse.Result.Should().Contain(m => m.Id == message1.Id);
        _responseContext.GetMessagesResponse.Result.Should().Contain(m => m.Id == message2.Id);
    }

    [Then(@"the response contains the Message ([a-zA-Z0-9]+)")]
    public void ThenTheResponseContainsTheMessage(string messageName)
    {
        var message = _messagesContext.Messages[messageName];

        ThrowIfNull(_responseContext.GetMessagesResponse);

        _responseContext.GetMessagesResponse.Result.Should().Contain(m => m.Id == message.Id);
    }

    [Then(@"the response does not contain the Message ([a-zA-Z0-9]+)")]
    public void ThenTheResponseDoesNotContainTheMessage(string messageName)
    {
        var message = _messagesContext.Messages[messageName];

        ThrowIfNull(_responseContext.GetMessagesResponse);

        _responseContext.GetMessagesResponse.Result.Should().NotContain(m => m.Id == message.Id);
    }

    #endregion

    #region PnsRegistrations

    [Then("the response contains the push identifier for the device")]
    public void ThenTheResponseContainsThePushIdentifierForTheDevice()
    {
        _responseContext.UpdateDeviceRegistrationResponse!.Result!.DevicePushIdentifier.Should().NotBeNullOrEmpty();
    }

    #endregion

    #region Relationships

    [Then("a relationship can be established")]
    public void ThenARelationshipCanBeEstablished()
    {
        if (_responseContext.CanEstablishRelationshipResponse != null)
            _responseContext.CanEstablishRelationshipResponse.Result!.CanCreate.Should().BeTrue();
    }

    [Then("a relationship can not be established")]
    public void ThenARelationshipCanNotBeEstablished()
    {
        if (_responseContext.CanEstablishRelationshipResponse != null)
            _responseContext.CanEstablishRelationshipResponse.Result!.CanCreate.Should().BeFalse();
    }

    #endregion
}
