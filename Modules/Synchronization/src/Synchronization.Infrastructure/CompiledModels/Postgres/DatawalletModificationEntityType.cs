﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Synchronization.Domain.Entities;
using Backbone.Synchronization.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Synchronization.Infrastructure.CompiledModels.Postgres
{
    internal partial class DatawalletModificationEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Synchronization.Domain.Entities.DatawalletModification",
                typeof(DatawalletModification),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(DatawalletModificationId),
                propertyInfo: typeof(DatawalletModification).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new DatawalletModificationIdEntityFrameworkValueConverter());
            id.AddAnnotation("Relational:IsFixedLength", true);

            var blobReference = runtimeEntityType.AddProperty(
                "BlobReference",
                typeof(string),
                propertyInfo: typeof(DatawalletModification).GetProperty("BlobReference", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<BlobReference>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 32,
                unicode: false);
            blobReference.AddAnnotation("Relational:IsFixedLength", true);

            var collection = runtimeEntityType.AddProperty(
                "Collection",
                typeof(string),
                propertyInfo: typeof(DatawalletModification).GetProperty("Collection", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<Collection>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 50);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(DatawalletModification).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());

            var createdBy = runtimeEntityType.AddProperty(
                "CreatedBy",
                typeof(IdentityAddress),
                propertyInfo: typeof(DatawalletModification).GetProperty("CreatedBy", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<CreatedBy>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            createdBy.AddAnnotation("Relational:IsFixedLength", true);

            var createdByDevice = runtimeEntityType.AddProperty(
                "CreatedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(DatawalletModification).GetProperty("CreatedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<CreatedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            createdByDevice.AddAnnotation("Relational:IsFixedLength", true);

            var datawalletId = runtimeEntityType.AddProperty(
                "DatawalletId",
                typeof(DatawalletId),
                nullable: true,
                maxLength: 20,
                unicode: false,
                valueConverter: new DatawalletIdEntityFrameworkValueConverter());
            datawalletId.AddAnnotation("Relational:IsFixedLength", true);

            var datawalletVersion = runtimeEntityType.AddProperty(
                "DatawalletVersion",
                typeof(Datawallet.DatawalletVersion),
                propertyInfo: typeof(DatawalletModification).GetProperty("DatawalletVersion", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<DatawalletVersion>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                unicode: false,
                valueConverter: new DatawalletVersionEntityFrameworkValueConverter());

            var index = runtimeEntityType.AddProperty(
                "Index",
                typeof(long),
                propertyInfo: typeof(DatawalletModification).GetProperty("Index", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<Index>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var objectIdentifier = runtimeEntityType.AddProperty(
                "ObjectIdentifier",
                typeof(string),
                propertyInfo: typeof(DatawalletModification).GetProperty("ObjectIdentifier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<ObjectIdentifier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 100);

            var payloadCategory = runtimeEntityType.AddProperty(
                "PayloadCategory",
                typeof(string),
                propertyInfo: typeof(DatawalletModification).GetProperty("PayloadCategory", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<PayloadCategory>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(DatawalletModificationType),
                propertyInfo: typeof(DatawalletModification).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index0 = runtimeEntityType.AddIndex(
                new[] { createdBy });

            var index1 = runtimeEntityType.AddIndex(
                new[] { datawalletId });

            var index2 = runtimeEntityType.AddIndex(
                new[] { createdBy, index },
                unique: true);

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("DatawalletId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType);

            var datawallet = declaringEntityType.AddNavigation("Datawallet",
                runtimeForeignKey,
                onDependent: true,
                typeof(Datawallet),
                propertyInfo: typeof(DatawalletModification).GetProperty("Datawallet", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(DatawalletModification).GetField("<Datawallet>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var modifications = principalEntityType.AddNavigation("Modifications",
                runtimeForeignKey,
                onDependent: false,
                typeof(List<DatawalletModification>),
                propertyInfo: typeof(Datawallet).GetProperty("Modifications", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Datawallet).GetField("<Modifications>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "DatawalletModifications");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
