﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.Modules.Devices.Infrastructure.OpenIddict;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenIddict.EntityFrameworkCore.Models;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.SqlServer
{
    internal partial class CustomOpenIddictEntityFrameworkCoreAuthorizationEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
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
            id.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(450)",
                    size: 450,
                    dbType: System.Data.DbType.String));
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var applicationId = runtimeEntityType.AddProperty(
                "ApplicationId",
                typeof(string),
                nullable: true);
            applicationId.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(450)",
                    size: 450,
                    dbType: System.Data.DbType.String));
            applicationId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var concurrencyToken = runtimeEntityType.AddProperty(
                "ConcurrencyToken",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("ConcurrencyToken", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<ConcurrencyToken>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                concurrencyToken: true,
                maxLength: 50);
            concurrencyToken.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(50)",
                    size: 50,
                    dbType: System.Data.DbType.String));
            concurrencyToken.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var creationDate = runtimeEntityType.AddProperty(
                "CreationDate",
                typeof(DateTime?),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("CreationDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<CreationDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());
            creationDate.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => object.Equals((object)v1, (object)v2),
                    (Nullable<DateTime> v) => v.GetHashCode(),
                    (Nullable<DateTime> v) => v),
                keyComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => object.Equals((object)v1, (object)v2),
                    (Nullable<DateTime> v) => v.GetHashCode(),
                    (Nullable<DateTime> v) => v),
                providerValueComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => object.Equals((object)v1, (object)v2),
                    (Nullable<DateTime> v) => v.GetHashCode(),
                    (Nullable<DateTime> v) => v),
                converter: new ValueConverter<DateTime?, DateTime?>(
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)v.Value.ToUniversalTime() : v,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<DateTime?, DateTime>(
                    JsonDateTimeReaderWriter.Instance,
                    new ValueConverter<DateTime?, DateTime?>(
                        (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)v.Value.ToUniversalTime() : v,
                        (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v)));
            creationDate.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var properties = runtimeEntityType.AddProperty(
                "Properties",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Properties", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Properties>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            properties.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(max)",
                    dbType: System.Data.DbType.String),
                storeTypePostfix: StoreTypePostfix.None);
            properties.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var scopes = runtimeEntityType.AddProperty(
                "Scopes",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Scopes", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Scopes>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            scopes.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(max)",
                    dbType: System.Data.DbType.String),
                storeTypePostfix: StoreTypePostfix.None);
            scopes.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var status = runtimeEntityType.AddProperty(
                "Status",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Status", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Status>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);
            status.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(50)",
                    size: 50,
                    dbType: System.Data.DbType.String));
            status.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var subject = runtimeEntityType.AddProperty(
                "Subject",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Subject", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Subject>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 400);
            subject.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(400)",
                    size: 400,
                    dbType: System.Data.DbType.String));
            subject.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(string),
                propertyInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(OpenIddictEntityFrameworkCoreAuthorization<string, CustomOpenIddictEntityFrameworkCoreApplication, CustomOpenIddictEntityFrameworkCoreToken>).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 50);
            type.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string l, string r) => string.Equals(l, r, StringComparison.OrdinalIgnoreCase),
                    (string v) => v == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(v),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(50)",
                    size: 50,
                    dbType: System.Data.DbType.String));
            type.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { applicationId, status, subject, type });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ApplicationId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
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
