﻿using Backbone.ConsumerApi.Tests.Integration.Extensions;

namespace Backbone.ConsumerApi.Tests.Integration.StepDefinitions;

[Binding]
internal class IdentityDeletionProcessesStepDefinitions
{
    #region Constructor, Fields, Properties
    private readonly IdentitiesContext _identitiesContext;
    private readonly ResponseContext _responseContext;

    public IdentityDeletionProcessesStepDefinitions(IdentitiesContext identitiesContext, ResponseContext responseContext)
    {
        _identitiesContext = identitiesContext;
        _responseContext = responseContext;
    }

    private ClientPool ClientPool => _identitiesContext.ClientPool;
    #endregion

    #region Given
    [Given("no active deletion process for i exists")]
    public void GivenNoActiveDeletionProcessForIExists() { }

    [Given("an active deletion process for ([a-zA-Z0-9]+) exists")]
    public async Task GivenAnActiveDeletionProcessForTheIdentityExists(string identityName)
    {
        var deletionProcess = await _identitiesContext.ClientPool.FirstForIdentity(identityName)!.Identities.StartDeletionProcess();
        _identitiesContext.ActiveDeletionProcesses.Add(identityName, deletionProcess.Result!.Id);
    }

    [Given("([a-zA-Z0-9]+) is in status \"ToBeDeleted\"")]
    public async Task GivenIdentityIsToBeDeleted(string identityName)
    {
        _responseContext.StartDeletionProcessResponse = await ClientPool.FirstForIdentity(identityName)!.Identities.StartDeletionProcess();
        _responseContext.StartDeletionProcessResponse.Should().BeASuccess();
    }
    #endregion

    #region When
    [When(@"([a-zA-Z0-9]+) sends a POST request to the /Identities/Self/DeletionProcesses endpoint")]
    public async Task WhenISendsAPostRequestToTheIdentitiesSelfDeletionProcessesEndpoint(string identityName)
    {
        _responseContext.WhenResponse = _responseContext.StartDeletionProcessResponse = await ClientPool.FirstForIdentity(identityName)!.Identities.StartDeletionProcess();
    }

    [When(@"([a-zA-Z0-9]+) sends a PUT request to the /Identities/Self/DeletionProcesses/\{id} endpoint")]
    public async Task WhenISendsAPutRequestToTheIdentitiesSelfDeletionProcessesIdEndpoint(string identityName)
    {
        _responseContext.WhenResponse = _responseContext.CancelDeletionProcessResponse = await ClientPool.FirstForIdentity(identityName)!.Identities.CancelDeletionProcess(_identitiesContext.ActiveDeletionProcesses[identityName]);
    }
    #endregion
}
