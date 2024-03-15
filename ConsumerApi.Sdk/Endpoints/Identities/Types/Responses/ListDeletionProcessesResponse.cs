﻿using Backbone.BuildingBlocks.SDK.Endpoints.Common.Types;

namespace Backbone.ConsumerApi.Sdk.Endpoints.Identities.Types.Responses;

public class ListDeletionProcessesResponse(IEnumerable<IdentityDeletionProcess> items) : EnumerableResponseBase<IdentityDeletionProcess>(items);
