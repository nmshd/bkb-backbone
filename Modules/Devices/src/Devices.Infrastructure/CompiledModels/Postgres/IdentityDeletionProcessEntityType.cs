﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using Backbone.Modules.Devices.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.Postgres
{
    internal partial class IdentityDeletionProcessEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Devices.Domain.Entities.Identities.IdentityDeletionProcess",
                typeof(IdentityDeletionProcess),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(IdentityDeletionProcessId),
                propertyInfo: typeof(IdentityDeletionProcess).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityDeletionProcess).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new IdentityDeletionProcessIdEntityFrameworkValueConverter());
            id.AddAnnotation("Relational:IsFixedLength", true);

            var approvedAt = runtimeEntityType.AddProperty(
                "ApprovedAt",
                typeof(DateTime?),
                propertyInfo: typeof(IdentityDeletionProcess).GetProperty("ApprovedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityDeletionProcess).GetField("<ApprovedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());

            var approvedByDevice = runtimeEntityType.AddProperty(
                "ApprovedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(IdentityDeletionProcess).GetProperty("ApprovedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityDeletionProcess).GetField("<ApprovedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            approvedByDevice.AddAnnotation("Relational:IsFixedLength", true);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(IdentityDeletionProcess).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityDeletionProcess).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());

            var deletionStartedAt = runtimeEntityType.AddProperty(
                "DeletionStartedAt",
                typeof(DateTime),
                propertyInfo: typeof(IdentityDeletionProcess).GetProperty("DeletionStartedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityDeletionProcess).GetField("<DeletionStartedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());

            var gracePeriodEndsAt = runtimeEntityType.AddProperty(
                "GracePeriodEndsAt",
                typeof(DateTime?),
                propertyInfo: typeof(IdentityDeletionProcess).GetProperty("GracePeriodEndsAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityDeletionProcess).GetField("<GracePeriodEndsAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());

            var identityAddress = runtimeEntityType.AddProperty(
                "IdentityAddress",
                typeof(IdentityAddress),
                nullable: true,
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            identityAddress.AddAnnotation("Relational:IsFixedLength", true);

            var status = runtimeEntityType.AddProperty(
                "Status",
                typeof(DeletionProcessStatus),
                propertyInfo: typeof(IdentityDeletionProcess).GetProperty("Status", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityDeletionProcess).GetField("<Status>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

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
                deleteBehavior: DeleteBehavior.Cascade);

            var deletionProcesses = principalEntityType.AddNavigation("DeletionProcesses",
                runtimeForeignKey,
                onDependent: false,
                typeof(IReadOnlyList<IdentityDeletionProcess>),
                propertyInfo: typeof(Identity).GetProperty("DeletionProcesses", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Identity).GetField("_deletionProcesses", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "IdentityDeletionProcesses");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
