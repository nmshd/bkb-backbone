﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Devices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.Postgres
{
    internal partial class DeviceEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Devices.Domain.Entities.Device",
                typeof(Device),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(DeviceId),
                propertyInfo: typeof(Device).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            id.AddAnnotation("Relational:IsFixedLength", true);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(Device).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());

            var createdByDevice = runtimeEntityType.AddProperty(
                "CreatedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(Device).GetProperty("CreatedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<CreatedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            createdByDevice.AddAnnotation("Relational:IsFixedLength", true);

            var deletedAt = runtimeEntityType.AddProperty(
                "DeletedAt",
                typeof(DateTime?),
                propertyInfo: typeof(Device).GetProperty("DeletedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<DeletedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());

            var deletedByDevice = runtimeEntityType.AddProperty(
                "DeletedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(Device).GetProperty("DeletedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<DeletedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            deletedByDevice.AddAnnotation("Relational:IsFixedLength", true);

            var identityAddress = runtimeEntityType.AddProperty(
                "IdentityAddress",
                typeof(IdentityAddress),
                propertyInfo: typeof(Device).GetProperty("IdentityAddress", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<IdentityAddress>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            identityAddress.AddAnnotation("Relational:IsFixedLength", true);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { identityAddress });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("IdentityAddress")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Address")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var identity = declaringEntityType.AddNavigation("Identity",
                runtimeForeignKey,
                onDependent: true,
                typeof(Identity),
                propertyInfo: typeof(Device).GetProperty("Identity", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<Identity>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var devices = principalEntityType.AddNavigation("Devices",
                runtimeForeignKey,
                onDependent: false,
                typeof(List<Device>),
                propertyInfo: typeof(Identity).GetProperty("Devices", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("<Devices>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Devices");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
