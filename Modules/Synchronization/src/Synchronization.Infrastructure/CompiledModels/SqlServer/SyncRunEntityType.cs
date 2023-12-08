﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Synchronization.Domain.Entities.Sync;
using Backbone.Modules.Synchronization.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Backbone.Modules.Synchronization.Infrastructure.CompiledModels.SqlServer
{
    internal partial class SyncRunEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncRun",
                typeof(SyncRun),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(SyncRunId),
                propertyInfo: typeof(SyncRun).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new SyncRunIdEntityFrameworkValueConverter());
            id.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<SyncRunId>(
                    (SyncRunId v1, SyncRunId v2) => object.Equals(v1, v2),
                    (SyncRunId v) => v.GetHashCode(),
                    (SyncRunId v) => v),
                keyComparer: new ValueComparer<SyncRunId>(
                    (SyncRunId v1, SyncRunId v2) => object.Equals(v1, v2),
                    (SyncRunId v) => v.GetHashCode(),
                    (SyncRunId v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "char(20)",
                    size: 20,
                    dbType: System.Data.DbType.AnsiStringFixedLength),
                converter: new ValueConverter<SyncRunId, string>(
                    (SyncRunId id) => id == null ? null : id.StringValue,
                    (string value) => SyncRunId.Parse(value)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<SyncRunId, string>(
                    JsonStringReaderWriter.Instance,
                    new ValueConverter<SyncRunId, string>(
                        (SyncRunId id) => id == null ? null : id.StringValue,
                        (string value) => SyncRunId.Parse(value))));
            id.AddAnnotation("Relational:IsFixedLength", true);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(SyncRun).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
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

            var createdBy = runtimeEntityType.AddProperty(
                "CreatedBy",
                typeof(IdentityAddress),
                propertyInfo: typeof(SyncRun).GetProperty("CreatedBy", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<CreatedBy>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            createdBy.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<IdentityAddress>(
                    (IdentityAddress v1, IdentityAddress v2) => v1 == null && v2 == null || v1 != null && v2 != null && v1.Equals(v2),
                    (IdentityAddress v) => v.GetHashCode(),
                    (IdentityAddress v) => v),
                keyComparer: new ValueComparer<IdentityAddress>(
                    (IdentityAddress v1, IdentityAddress v2) => v1 == null && v2 == null || v1 != null && v2 != null && v1.Equals(v2),
                    (IdentityAddress v) => v.GetHashCode(),
                    (IdentityAddress v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "char(36)",
                    size: 36,
                    dbType: System.Data.DbType.AnsiStringFixedLength),
                converter: new ValueConverter<IdentityAddress, string>(
                    (IdentityAddress id) => id.StringValue,
                    (string value) => IdentityAddress.ParseUnsafe(value.Trim())),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<IdentityAddress, string>(
                    JsonStringReaderWriter.Instance,
                    new ValueConverter<IdentityAddress, string>(
                        (IdentityAddress id) => id.StringValue,
                        (string value) => IdentityAddress.ParseUnsafe(value.Trim()))));
            createdBy.AddAnnotation("Relational:IsFixedLength", true);
            createdBy.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdByDevice = runtimeEntityType.AddProperty(
                "CreatedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(SyncRun).GetProperty("CreatedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<CreatedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            createdByDevice.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            createdByDevice.AddAnnotation("Relational:IsFixedLength", true);
            createdByDevice.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var eventCount = runtimeEntityType.AddProperty(
                "EventCount",
                typeof(int),
                propertyInfo: typeof(SyncRun).GetProperty("EventCount", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<EventCount>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            eventCount.TypeMapping = IntTypeMapping.Default.Clone(
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
            eventCount.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var expiresAt = runtimeEntityType.AddProperty(
                "ExpiresAt",
                typeof(DateTime),
                propertyInfo: typeof(SyncRun).GetProperty("ExpiresAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<ExpiresAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());
            expiresAt.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
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
            expiresAt.SetSentinelFromProviderValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            expiresAt.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var finalizedAt = runtimeEntityType.AddProperty(
                "FinalizedAt",
                typeof(DateTime?),
                propertyInfo: typeof(SyncRun).GetProperty("FinalizedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<FinalizedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());
            finalizedAt.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
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
            finalizedAt.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var index = runtimeEntityType.AddProperty(
                "Index",
                typeof(long),
                propertyInfo: typeof(SyncRun).GetProperty("Index", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<Index>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0L);
            index.TypeMapping = SqlServerLongTypeMapping.Default.Clone(
                comparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                keyComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v),
                providerValueComparer: new ValueComparer<long>(
                    (long v1, long v2) => v1 == v2,
                    (long v) => v.GetHashCode(),
                    (long v) => v));
            index.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(SyncRun.SyncRunType),
                propertyInfo: typeof(SyncRun).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            type.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<SyncRun.SyncRunType>(
                    (SyncRun.SyncRunType v1, SyncRun.SyncRunType v2) => object.Equals((object)v1, (object)v2),
                    (SyncRun.SyncRunType v) => v.GetHashCode(),
                    (SyncRun.SyncRunType v) => v),
                keyComparer: new ValueComparer<SyncRun.SyncRunType>(
                    (SyncRun.SyncRunType v1, SyncRun.SyncRunType v2) => object.Equals((object)v1, (object)v2),
                    (SyncRun.SyncRunType v) => v.GetHashCode(),
                    (SyncRun.SyncRunType v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                converter: new ValueConverter<SyncRun.SyncRunType, int>(
                    (SyncRun.SyncRunType value) => (int)value,
                    (int value) => (SyncRun.SyncRunType)value),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<SyncRun.SyncRunType, int>(
                    JsonInt32ReaderWriter.Instance,
                    new ValueConverter<SyncRun.SyncRunType, int>(
                        (SyncRun.SyncRunType value) => (int)value,
                        (int value) => (SyncRun.SyncRunType)value)));
            type.SetSentinelFromProviderValue(0);
            type.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index0 = runtimeEntityType.AddIndex(
                new[] { createdBy });

            var index1 = runtimeEntityType.AddIndex(
                new[] { createdBy, finalizedAt });

            var index2 = runtimeEntityType.AddIndex(
                new[] { createdBy, index },
                unique: true);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "SyncRuns");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
