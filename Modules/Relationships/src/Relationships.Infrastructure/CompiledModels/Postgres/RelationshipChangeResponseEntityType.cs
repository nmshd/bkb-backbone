﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.Modules.Relationships.Domain.Entities;
using Backbone.Modules.Relationships.Domain.Ids;
using Backbone.Modules.Relationships.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Relationships.Infrastructure.CompiledModels.Postgres
{
    internal partial class RelationshipChangeResponseEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Relationships.Domain.Entities.RelationshipChangeResponse",
                typeof(RelationshipChangeResponse),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(RelationshipChangeId),
                propertyInfo: typeof(RelationshipChangeResponse).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChangeResponse).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                valueConverter: new RelationshipChangeIdEntityFrameworkValueConverter());

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(RelationshipChangeResponse).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChangeResponse).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());
            createdAt.AddAnnotation("Relational:ColumnName", "Res_CreatedAt");

            var createdBy = runtimeEntityType.AddProperty(
                "CreatedBy",
                typeof(IdentityAddress),
                propertyInfo: typeof(RelationshipChangeResponse).GetProperty("CreatedBy", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChangeResponse).GetField("<CreatedBy>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            createdBy.AddAnnotation("Relational:ColumnName", "Res_CreatedBy");
            createdBy.AddAnnotation("Relational:IsFixedLength", true);

            var createdByDevice = runtimeEntityType.AddProperty(
                "CreatedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(RelationshipChangeResponse).GetProperty("CreatedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChangeResponse).GetField("<CreatedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            createdByDevice.AddAnnotation("Relational:ColumnName", "Res_CreatedByDevice");
            createdByDevice.AddAnnotation("Relational:IsFixedLength", true);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { createdAt });

            var index0 = runtimeEntityType.AddIndex(
                new[] { createdBy });

            var index1 = runtimeEntityType.AddIndex(
                new[] { createdByDevice });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("Id")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                unique: true,
                required: true);

            var response = principalEntityType.AddNavigation("Response",
                runtimeForeignKey,
                onDependent: false,
                typeof(RelationshipChangeResponse),
                propertyInfo: typeof(RelationshipChange).GetProperty("Response", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChange).GetField("<Response>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "RelationshipChanges");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
