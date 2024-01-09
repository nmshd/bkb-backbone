﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.AdminUi.Infrastructure.DTOs;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#pragma warning disable 219, 612, 618
#nullable disable

namespace AdminUi.Infrastructure.CompiledModels.SqlServer
{
    internal partial class MessageOverviewEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.AdminUi.Infrastructure.DTOs.MessageOverview",
                typeof(MessageOverview),
                baseEntityType);

            var messageId = runtimeEntityType.AddProperty(
                "MessageId",
                typeof(string),
                propertyInfo: typeof(MessageOverview).GetProperty("MessageId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageOverview).GetField("<MessageId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw);
            messageId.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            messageId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var numberOfAttachments = runtimeEntityType.AddProperty(
                "NumberOfAttachments",
                typeof(int),
                propertyInfo: typeof(MessageOverview).GetProperty("NumberOfAttachments", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageOverview).GetField("<NumberOfAttachments>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            numberOfAttachments.TypeMapping = IntTypeMapping.Default.Clone(
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
            numberOfAttachments.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var sendDate = runtimeEntityType.AddProperty(
                "SendDate",
                typeof(DateTime),
                propertyInfo: typeof(MessageOverview).GetProperty("SendDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageOverview).GetField("<SendDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());
            sendDate.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
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
            sendDate.SetSentinelFromProviderValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            sendDate.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var senderAddress = runtimeEntityType.AddProperty(
                "SenderAddress",
                typeof(string),
                propertyInfo: typeof(MessageOverview).GetProperty("SenderAddress", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageOverview).GetField("<SenderAddress>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            senderAddress.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            senderAddress.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var senderDevice = runtimeEntityType.AddProperty(
                "SenderDevice",
                typeof(string),
                propertyInfo: typeof(MessageOverview).GetProperty("SenderDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageOverview).GetField("<SenderDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            senderDevice.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            senderDevice.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { messageId });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewDefinitionSql", null);
            runtimeEntityType.AddAnnotation("Relational:ViewName", "MessageOverviews");
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
