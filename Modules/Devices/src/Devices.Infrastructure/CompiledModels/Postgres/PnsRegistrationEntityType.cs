﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications;
using Backbone.Modules.Devices.Domain.Aggregates.PushNotifications.Handles;
using Backbone.Modules.Devices.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore.Metadata;
using Environment = Backbone.Modules.Devices.Domain.Aggregates.PushNotifications.Environment;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.Postgres
{
    internal partial class PnsRegistrationEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Devices.Domain.Aggregates.PushNotifications.PnsRegistration",
                typeof(PnsRegistration),
                baseEntityType);

            var deviceId = runtimeEntityType.AddProperty(
                "DeviceId",
                typeof(DeviceId),
                propertyInfo: typeof(PnsRegistration).GetProperty("DeviceId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PnsRegistration).GetField("<DeviceId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            deviceId.AddAnnotation("Relational:IsFixedLength", true);

            var appId = runtimeEntityType.AddProperty(
                "AppId",
                typeof(string),
                propertyInfo: typeof(PnsRegistration).GetProperty("AppId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PnsRegistration).GetField("<AppId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var environment = runtimeEntityType.AddProperty(
                "Environment",
                typeof(Environment),
                propertyInfo: typeof(PnsRegistration).GetProperty("Environment", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PnsRegistration).GetField("<Environment>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd);
            environment.AddAnnotation("Relational:DefaultValue", Environment.Production);

            var handle = runtimeEntityType.AddProperty(
                "Handle",
                typeof(PnsHandle),
                propertyInfo: typeof(PnsRegistration).GetProperty("Handle", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PnsRegistration).GetField("<Handle>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 200,
                unicode: true,
                valueConverter: new PnsHandleEntityFrameworkValueConverter());
            handle.AddAnnotation("Relational:IsFixedLength", false);

            var identityAddress = runtimeEntityType.AddProperty(
                "IdentityAddress",
                typeof(IdentityAddress),
                propertyInfo: typeof(PnsRegistration).GetProperty("IdentityAddress", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PnsRegistration).GetField("<IdentityAddress>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            identityAddress.AddAnnotation("Relational:IsFixedLength", true);

            var updatedAt = runtimeEntityType.AddProperty(
                "UpdatedAt",
                typeof(DateTime),
                propertyInfo: typeof(PnsRegistration).GetProperty("UpdatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PnsRegistration).GetField("<UpdatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());

            var key = runtimeEntityType.AddKey(
                new[] { deviceId });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "PnsRegistrations");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
