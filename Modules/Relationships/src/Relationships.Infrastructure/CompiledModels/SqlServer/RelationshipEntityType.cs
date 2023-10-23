﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Relationships.Domain.Entities;
using Backbone.Relationships.Domain.Ids;
using Backbone.Relationships.Infrastructure.Persistence.Database.ValueConverters;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Relationships.Infrastructure.CompiledModels.SqlServer
{
    internal partial class RelationshipEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Relationships.Domain.Entities.Relationship",
                typeof(Relationship),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(RelationshipId),
                propertyInfo: typeof(Relationship).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Relationship).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new RelationshipIdEntityFrameworkValueConverter());
            id.AddAnnotation("Relational:IsFixedLength", true);
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(Relationship).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Relationship).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new DateTimeValueConverter());
            createdAt.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var from = runtimeEntityType.AddProperty(
                "From",
                typeof(IdentityAddress),
                propertyInfo: typeof(Relationship).GetProperty("From", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Relationship).GetField("<From>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            from.AddAnnotation("Relational:IsFixedLength", true);
            from.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var relationshipTemplateId = runtimeEntityType.AddProperty(
                "RelationshipTemplateId",
                typeof(RelationshipTemplateId),
                propertyInfo: typeof(Relationship).GetProperty("RelationshipTemplateId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Relationship).GetField("<RelationshipTemplateId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20,
                unicode: false,
                valueConverter: new RelationshipTemplateIdEntityFrameworkValueConverter());
            relationshipTemplateId.AddAnnotation("Relational:IsFixedLength", true);
            relationshipTemplateId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var status = runtimeEntityType.AddProperty(
                "Status",
                typeof(RelationshipStatus),
                propertyInfo: typeof(Relationship).GetProperty("Status", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Relationship).GetField("<Status>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            status.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var to = runtimeEntityType.AddProperty(
                "To",
                typeof(IdentityAddress),
                propertyInfo: typeof(Relationship).GetProperty("To", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Relationship).GetField("<To>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            to.AddAnnotation("Relational:IsFixedLength", true);
            to.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { createdAt });

            var index0 = runtimeEntityType.AddIndex(
                new[] { from });

            var index1 = runtimeEntityType.AddIndex(
                new[] { relationshipTemplateId });

            var index2 = runtimeEntityType.AddIndex(
                new[] { status });

            var index3 = runtimeEntityType.AddIndex(
                new[] { to });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("RelationshipTemplateId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType);

            var relationships = principalEntityType.AddNavigation("Relationships",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Relationship>),
                propertyInfo: typeof(RelationshipTemplate).GetProperty("Relationships", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RelationshipTemplate).GetField("<Relationships>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Relationships");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
