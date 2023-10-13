﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.Modules.Synchronization.Domain.Entities;
using Backbone.Modules.Synchronization.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Synchronization.Infrastructure.CompiledModels.SqlServer
{
    internal partial class DatawalletEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Synchronization.Domain.Entities.Datawallet",
                typeof(Datawallet),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(DatawalletId),
                propertyInfo: typeof(Datawallet).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Datawallet).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new DatawalletIdEntityFrameworkValueConverter());
            id.AddAnnotation("Relational:IsFixedLength", true);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var owner = runtimeEntityType.AddProperty(
                "Owner",
                typeof(IdentityAddress),
                propertyInfo: typeof(Datawallet).GetProperty("Owner", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Datawallet).GetField("<Owner>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            owner.AddAnnotation("Relational:IsFixedLength", true);
            owner.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var version = runtimeEntityType.AddProperty(
                "Version",
                typeof(Datawallet.DatawalletVersion),
                propertyInfo: typeof(Datawallet).GetProperty("Version", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Datawallet).GetField("<Version>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                unicode: false,
                valueConverter: new DatawalletVersionEntityFrameworkValueConverter());
            version.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { owner },
                unique: true);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Datawallets");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
