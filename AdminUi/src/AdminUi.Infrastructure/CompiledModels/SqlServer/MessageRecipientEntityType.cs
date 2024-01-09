﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.AdminUi.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;

#pragma warning disable 219, 612, 618
#nullable disable

namespace AdminUi.Infrastructure.CompiledModels.SqlServer
{
    internal partial class MessageRecipientEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.AdminUi.Infrastructure.DTOs.MessageRecipient",
                typeof(MessageRecipient),
                baseEntityType);

            var address = runtimeEntityType.AddProperty(
                "Address",
                typeof(string),
                propertyInfo: typeof(MessageRecipient).GetProperty("Address", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageRecipient).GetField("<Address>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw);
            address.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
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
            address.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var messageId = runtimeEntityType.AddProperty(
                "MessageId",
                typeof(string),
                propertyInfo: typeof(MessageRecipient).GetProperty("MessageId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageRecipient).GetField("<MessageId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
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

            var key = runtimeEntityType.AddKey(
                new[] { address });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { messageId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("MessageId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("MessageId") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var recipients = principalEntityType.AddNavigation("Recipients",
                runtimeForeignKey,
                onDependent: false,
                typeof(List<MessageRecipient>),
                propertyInfo: typeof(MessageOverview).GetProperty("Recipients", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(MessageOverview).GetField("<Recipients>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewDefinitionSql", null);
            runtimeEntityType.AddAnnotation("Relational:ViewName", "MessageRecipients");
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
