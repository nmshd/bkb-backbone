﻿using Backbone.BuildingBlocks.SDK.Endpoints.Common.Types;
using Backbone.ConsumerApi.Sdk;
using Backbone.ConsumerApi.Sdk.Authentication;
using Backbone.ConsumerApi.Sdk.Endpoints.Challenges.Types;
using Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Create.SubHandler;
using Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Shared.Models;

namespace Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Create.Helper;

public interface IConsumerApiHelper
{
    Task<string> OnBoardNewDevice(DomainIdentity identity, Client sdkClient);

    Task<Client> CreateForNewIdentity(CreateIdentities.Command request);
    Client CreateForExistingIdentity(string baseUrl, ClientCredentials clientCredentials, UserCredentials userCredentials, IdentityData? identityData = null);

    Task<ApiResponse<Challenge>> CreateChallenge(Client sdkClient);
}