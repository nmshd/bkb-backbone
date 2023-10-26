﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.Modules.Devices.Infrastructure.OpenIddict;
using Microsoft.EntityFrameworkCore.Metadata;
using OpenIddict.EntityFrameworkCore.Models;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.Postgres
{
    internal partial class CustomOpenIddictEntityFrameworkCoreAuthorizationEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Devices.Infrastructure.OpenIddict.CustomOpenIddictEntityFrameworkCoreAuthorization",
                typeof(CustomOpenIddictEntityFrameworkCoreAuthorization),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);

            var applicationId = runtimeEntityType.AddProperty(
                "ApplicationId",
                typeof(string),
                nullable: true);

            var concurrencyToken = runtimeEntityType.AddProperty(
                "ConcurrencyToken",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("ConcurrencyToken", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<ConcurrencyToken>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                concurrencyToken: true,
                maxLength: 50);

            var creationDate = runtimeEntityType.AddProperty(
                "CreationDate",
                typeof(DateTime?),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("CreationDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<CreationDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());

            var properties = runtimeEntityType.AddProperty(
                "Properties",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Properties", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Properties>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);

            var scopes = runtimeEntityType.AddProperty(
                "Scopes",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Scopes", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Scopes>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);

            var status = runtimeEntityType.AddProperty(
                "Status",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Status", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Status>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);

            var subject = runtimeEntityType.AddProperty(
                "Subject",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Subject", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Subject>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 400);

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { applicationId, status, subject, type });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ApplicationId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType);

            var application = declaringEntityType.AddNavigation("Application",
                runtimeForeignKey,
                onDependent: true,
                typeof(CustomOpenIddictEntityFrameworkCoreApplication),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Application", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Application>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var authorizations = principalEntityType.AddNavigation("Authorizations",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<CustomOpenIddictEntityFrameworkCoreAuthorization>),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, CustomOpenIddictEntityFrameworkCoreAuthorization, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Authorizations", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreApplication<string, CustomOpenIddictEntityFrameworkCoreAuthorization, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Authorizations>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "OpenIddictAuthorizations");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
