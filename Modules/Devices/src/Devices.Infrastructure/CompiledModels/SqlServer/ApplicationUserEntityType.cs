﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Devices.Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Backbone.Modules.Devices.Infrastructure.CompiledModels.SqlServer
{
    internal partial class ApplicationUserEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Devices.Domain.Entities.Identities.ApplicationUser",
                typeof(ApplicationUser),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
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

            var accessFailedCount = runtimeEntityType.AddProperty(
                "AccessFailedCount",
                typeof(int),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("AccessFailedCount", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<AccessFailedCount>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            accessFailedCount.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v));
            accessFailedCount.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var concurrencyStamp = runtimeEntityType.AddProperty(
                "ConcurrencyStamp",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("ConcurrencyStamp", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<ConcurrencyStamp>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                concurrencyToken: true);
            concurrencyStamp.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            concurrencyStamp.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(ApplicationUser).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ApplicationUser).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());
            createdAt.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                keyComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                providerValueComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                converter: new ValueConverter<DateTime, DateTime>(
                    (DateTime v) => v.ToUniversalTime(),
                    (DateTime v) => DateTime.SpecifyKind(v, DateTimeKind.Utc)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<DateTime, DateTime>(
                    JsonDateTimeReaderWriter.Instance,
                    new ValueConverter<DateTime, DateTime>(
                        (DateTime v) => v.ToUniversalTime(),
                        (DateTime v) => DateTime.SpecifyKind(v, DateTimeKind.Utc))));
            createdAt.SetSentinelFromProviderValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            createdAt.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var deviceId = runtimeEntityType.AddProperty(
                "DeviceId",
                typeof(DeviceId),
                propertyInfo: typeof(ApplicationUser).GetProperty("DeviceId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ApplicationUser).GetField("<DeviceId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            deviceId.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<DeviceId>(
                    (DeviceId v1, DeviceId v2) => object.Equals(v1, v2),
                    (DeviceId v) => v.GetHashCode(),
                    (DeviceId v) => v),
                keyComparer: new ValueComparer<DeviceId>(
                    (DeviceId v1, DeviceId v2) => object.Equals(v1, v2),
                    (DeviceId v) => v.GetHashCode(),
                    (DeviceId v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "char(20)",
                    size: 20,
                    dbType: System.Data.DbType.AnsiStringFixedLength),
                converter: new ValueConverter<DeviceId, string>(
                    (DeviceId id) => id.StringValue,
                    (string value) => DeviceId.Parse(value)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<DeviceId, string>(
                    JsonStringReaderWriter.Instance,
                    new ValueConverter<DeviceId, string>(
                        (DeviceId id) => id.StringValue,
                        (string value) => DeviceId.Parse(value))));
            deviceId.AddAnnotation("Relational:IsFixedLength", true);
            deviceId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var lastLoginAt = runtimeEntityType.AddProperty(
                "LastLoginAt",
                typeof(DateTime?),
                propertyInfo: typeof(ApplicationUser).GetProperty("LastLoginAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ApplicationUser).GetField("<LastLoginAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());
            lastLoginAt.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
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
            lastLoginAt.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var lockoutEnabled = runtimeEntityType.AddProperty(
                "LockoutEnabled",
                typeof(bool),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("LockoutEnabled", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<LockoutEnabled>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: false);
            lockoutEnabled.TypeMapping = SqlServerBoolTypeMapping.Default.Clone(
                comparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v),
                keyComparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v),
                providerValueComparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v));
            lockoutEnabled.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var lockoutEnd = runtimeEntityType.AddProperty(
                "LockoutEnd",
                typeof(DateTimeOffset?),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("LockoutEnd", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<LockoutEnd>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            lockoutEnd.TypeMapping = SqlServerDateTimeOffsetTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTimeOffset?>(
                    (Nullable<DateTimeOffset> v1, Nullable<DateTimeOffset> v2) => v1.HasValue && v2.HasValue && ((DateTimeOffset)v1).EqualsExact((DateTimeOffset)v2) || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTimeOffset> v) => v.HasValue ? ((DateTimeOffset)v).GetHashCode() : 0,
                    (Nullable<DateTimeOffset> v) => v.HasValue ? (Nullable<DateTimeOffset>)(DateTimeOffset)v : default(Nullable<DateTimeOffset>)),
                keyComparer: new ValueComparer<DateTimeOffset?>(
                    (Nullable<DateTimeOffset> v1, Nullable<DateTimeOffset> v2) => v1.HasValue && v2.HasValue && ((DateTimeOffset)v1).EqualsExact((DateTimeOffset)v2) || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTimeOffset> v) => v.HasValue ? ((DateTimeOffset)v).GetHashCode() : 0,
                    (Nullable<DateTimeOffset> v) => v.HasValue ? (Nullable<DateTimeOffset>)(DateTimeOffset)v : default(Nullable<DateTimeOffset>)),
                providerValueComparer: new ValueComparer<DateTimeOffset?>(
                    (Nullable<DateTimeOffset> v1, Nullable<DateTimeOffset> v2) => v1.HasValue && v2.HasValue && ((DateTimeOffset)v1).EqualsExact((DateTimeOffset)v2) || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTimeOffset> v) => v.HasValue ? ((DateTimeOffset)v).GetHashCode() : 0,
                    (Nullable<DateTimeOffset> v) => v.HasValue ? (Nullable<DateTimeOffset>)(DateTimeOffset)v : default(Nullable<DateTimeOffset>)));
            lockoutEnd.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var normalizedUserName = runtimeEntityType.AddProperty(
                "NormalizedUserName",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("NormalizedUserName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<NormalizedUserName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 256);
            normalizedUserName.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
                    storeTypeName: "nvarchar(256)",
                    size: 256,
                    dbType: System.Data.DbType.String));
            normalizedUserName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var passwordHash = runtimeEntityType.AddProperty(
                "PasswordHash",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("PasswordHash", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<PasswordHash>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            passwordHash.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            passwordHash.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var securityStamp = runtimeEntityType.AddProperty(
                "SecurityStamp",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("SecurityStamp", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<SecurityStamp>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            securityStamp.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            securityStamp.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var userName = runtimeEntityType.AddProperty(
                "UserName",
                typeof(string),
                propertyInfo: typeof(IdentityUser<string>).GetProperty("UserName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(IdentityUser<string>).GetField("<UserName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20,
                unicode: false);
            userName.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
                    storeTypeName: "char(20)",
                    size: 20,
                    dbType: System.Data.DbType.AnsiStringFixedLength));
            userName.AddAnnotation("Relational:IsFixedLength", true);
            userName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { deviceId },
                unique: true);

            var index0 = runtimeEntityType.AddIndex(
                new[] { normalizedUserName },
                unique: true);
            index0.AddAnnotation("Relational:Name", "UserNameIndex");

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("DeviceId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                unique: true,
                required: true,
                requiredDependent: true);

            var device = declaringEntityType.AddNavigation("Device",
                runtimeForeignKey,
                onDependent: true,
                typeof(Device),
                propertyInfo: typeof(ApplicationUser).GetProperty("Device", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ApplicationUser).GetField("_device", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var user = principalEntityType.AddNavigation("User",
                runtimeForeignKey,
                onDependent: false,
                typeof(ApplicationUser),
                propertyInfo: typeof(Device).GetProperty("User", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Device).GetField("<User>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "AspNetUsers");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
