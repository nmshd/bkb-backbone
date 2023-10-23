﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.Synchronization.Domain.Entities.Sync;
using Backbone.Synchronization.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Synchronization.Infrastructure.CompiledModels.SqlServer
{
    internal partial class SyncErrorEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Synchronization.Domain.Entities.Sync.SyncError",
                typeof(SyncError),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(SyncErrorId),
                propertyInfo: typeof(SyncError).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncError).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new SyncErrorIdEntityFrameworkValueConverter());
            id.AddAnnotation("Relational:IsFixedLength", true);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var errorCode = runtimeEntityType.AddProperty(
                "ErrorCode",
                typeof(string),
                propertyInfo: typeof(SyncError).GetProperty("ErrorCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncError).GetField("<ErrorCode>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 50);
            errorCode.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var externalEventId = runtimeEntityType.AddProperty(
                "ExternalEventId",
                typeof(ExternalEventId),
                propertyInfo: typeof(SyncError).GetProperty("ExternalEventId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncError).GetField("<ExternalEventId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new ExternalEventIdEntityFrameworkValueConverter());
            externalEventId.AddAnnotation("Relational:IsFixedLength", true);
            externalEventId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var syncRunId = runtimeEntityType.AddProperty(
                "SyncRunId",
                typeof(SyncRunId),
                propertyInfo: typeof(SyncError).GetProperty("SyncRunId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncError).GetField("<SyncRunId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new SyncRunIdEntityFrameworkValueConverter());
            syncRunId.AddAnnotation("Relational:IsFixedLength", true);
            syncRunId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { externalEventId });

            var index0 = runtimeEntityType.AddIndex(
                new[] { syncRunId, externalEventId },
                unique: true);

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ExternalEventId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var errors = principalEntityType.AddNavigation("Errors",
                runtimeForeignKey,
                onDependent: false,
                typeof(IReadOnlyCollection<SyncError>),
                propertyInfo: typeof(ExternalEvent).GetProperty("Errors", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ExternalEvent).GetField("_errors", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("SyncRunId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var errors = principalEntityType.AddNavigation("Errors",
                runtimeForeignKey,
                onDependent: false,
                typeof(IReadOnlyList<SyncError>),
                propertyInfo: typeof(SyncRun).GetProperty("Errors", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SyncRun).GetField("_errors", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "SyncErrors");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
