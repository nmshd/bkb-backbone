﻿using Backbone.BuildingBlocks.SDK.Endpoints.Common.Types;
using Backbone.ConsumerApi.Tests.Integration.Assertions;

namespace Backbone.ConsumerApi.Tests.Integration.Extensions;

public static class ApiResponseExtensions
{
    public static ApiResponseAssertions<T> Should<T>(this ApiResponse<T> instance)
    {
        return new ApiResponseAssertions<T>(instance);
    }
}
