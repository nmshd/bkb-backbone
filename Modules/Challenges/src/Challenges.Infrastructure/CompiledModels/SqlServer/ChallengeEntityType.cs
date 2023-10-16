﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.Modules.Challenges.Domain.Entities;
using Backbone.Modules.Challenges.Domain.Ids;
using Backbone.Modules.Challenges.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Challenges.Infrastructure.CompiledModels.SqlServer
{
    internal partial class ChallengeEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Challenges.Domain.Entities.Challenge",
                typeof(Challenge),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(ChallengeId),
                propertyInfo: typeof(Challenge).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Challenge).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new ChallengeIdEntityFrameworkValueConverter());
            id.AddAnnotation("Relational:IsFixedLength", true);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdBy = runtimeEntityType.AddProperty(
                "CreatedBy",
                typeof(IdentityAddress),
                propertyInfo: typeof(Challenge).GetProperty("CreatedBy", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Challenge).GetField("<CreatedBy>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            createdBy.AddAnnotation("Relational:IsFixedLength", true);
            createdBy.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdByDevice = runtimeEntityType.AddProperty(
                "CreatedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(Challenge).GetProperty("CreatedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Challenge).GetField("<CreatedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            createdByDevice.AddAnnotation("Relational:IsFixedLength", true);
            createdByDevice.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var expiresAt = runtimeEntityType.AddProperty(
                "ExpiresAt",
                typeof(DateTime),
                propertyInfo: typeof(Challenge).GetProperty("ExpiresAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Challenge).GetField("<ExpiresAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());
            expiresAt.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Challenges");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
