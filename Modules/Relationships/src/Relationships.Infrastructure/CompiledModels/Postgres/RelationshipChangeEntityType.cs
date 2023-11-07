﻿// <auto-generated />
using System;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.Modules.Relationships.Domain.Entities;
using Backbone.Modules.Relationships.Domain.Ids;
using Backbone.Modules.Relationships.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Relationships.Infrastructure.CompiledModels.Postgres
{
    internal partial class RelationshipChangeEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Relationships.Domain.Entities.RelationshipChange",
                typeof(RelationshipChange),
                baseEntityType,
                discriminatorProperty: "Discriminator",
                discriminatorValue: "RelationshipChange");

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(RelationshipChangeId),
                propertyInfo: typeof(RelationshipChange).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChange).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                valueConverter: new RelationshipChangeIdEntityFrameworkValueConverter());

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(RelationshipChange).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChange).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());

            var discriminator = runtimeEntityType.AddProperty(
                "Discriminator",
                typeof(string),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                valueGeneratorFactory: new DiscriminatorValueGeneratorFactory().Create);

            var relationshipId = runtimeEntityType.AddProperty(
                "RelationshipId",
                typeof(RelationshipId),
                propertyInfo: typeof(RelationshipChange).GetProperty("RelationshipId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChange).GetField("<RelationshipId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new RelationshipIdEntityFrameworkValueConverter());
            relationshipId.AddAnnotation("Relational:IsFixedLength", true);

            var status = runtimeEntityType.AddProperty(
                "Status",
                typeof(RelationshipChangeStatus),
                propertyInfo: typeof(RelationshipChange).GetProperty("Status", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChange).GetField("<Status>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(RelationshipChangeType),
                propertyInfo: typeof(RelationshipChange).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChange).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { createdAt });

            var index0 = runtimeEntityType.AddIndex(
                new[] { relationshipId });

            var index1 = runtimeEntityType.AddIndex(
                new[] { status });

            var index2 = runtimeEntityType.AddIndex(
                new[] { type });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("RelationshipId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var relationship = declaringEntityType.AddNavigation("Relationship",
                runtimeForeignKey,
                onDependent: true,
                typeof(Relationship),
                propertyInfo: typeof(RelationshipChange).GetProperty("Relationship", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipChange).GetField("<Relationship>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var changes = principalEntityType.AddNavigation("Changes",
                runtimeForeignKey,
                onDependent: false,
                typeof(IRelationshipChangeLog),
                propertyInfo: typeof(Relationship).GetProperty("Changes", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Relationship).GetField("_changes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                propertyAccessMode: PropertyAccessMode.Field);

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:MappingStrategy", "TPH");
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
