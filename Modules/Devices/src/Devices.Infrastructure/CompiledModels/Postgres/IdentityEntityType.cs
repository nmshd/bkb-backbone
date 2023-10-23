﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Devices.Domain.Aggregates.Tier;
using Backbone.Devices.Domain.Entities;
using Backbone.Devices.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.Postgres
{
    internal partial class IdentityEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Devices.Domain.Entities.Identity",
                typeof(Identity),
                baseEntityType);

            var address = runtimeEntityType.AddProperty(
                "Address",
                typeof(IdentityAddress),
                propertyInfo: typeof(Identity).GetProperty("Address", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("<Address>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            address.AddAnnotation("Relational:IsFixedLength", true);

            var clientId = runtimeEntityType.AddProperty(
                "ClientId",
                typeof(string),
                propertyInfo: typeof(Identity).GetProperty("ClientId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("<ClientId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 200);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(Identity).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());

            var identityVersion = runtimeEntityType.AddProperty(
                "IdentityVersion",
                typeof(byte),
                propertyInfo: typeof(Identity).GetProperty("IdentityVersion", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("<IdentityVersion>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var publicKey = runtimeEntityType.AddProperty(
                "PublicKey",
                typeof(byte[]),
                propertyInfo: typeof(Identity).GetProperty("PublicKey", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("<PublicKey>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var tierId = runtimeEntityType.AddProperty(
                "TierId",
                typeof(TierId),
                propertyInfo: typeof(Identity).GetProperty("TierId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("<TierId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20,
                unicode: false,
                valueConverter: new TierIdEntityFrameworkValueConverter());
            tierId.AddAnnotation("Relational:IsFixedLength", true);

            var key = runtimeEntityType.AddKey(
                new[] { address });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Identities");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
