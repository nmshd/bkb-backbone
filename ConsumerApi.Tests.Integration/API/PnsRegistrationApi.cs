﻿using Backbone.ConsumerApi.Tests.Integration.Models;
using Backbone.Modules.Devices.Application.PushNotifications.Commands.UpdateDeviceRegistration;

namespace Backbone.ConsumerApi.Tests.Integration.API;
internal class PnsRegistrationApi : BaseApi
{
    public PnsRegistrationApi(HttpClientFactory factory) : base(factory) { }

    internal async Task<HttpResponse<UpdateDeviceRegistrationResponse>> TestRegisterForPushNotification(RequestConfiguration requestConfiguration)
    {
        return await Put<UpdateDeviceRegistrationResponse>("/Devices/Self/PushNotifications", requestConfiguration);
    }
}
