﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Backbone.Modules.Messages.Domain.Entities;
using Backbone.Modules.Messages.Domain.Ids;
using Backbone.Modules.Messages.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.BuildingBlocks.Infrastructure.Persistence.Database.ValueConverters;
using Enmeshed.DevelopmentKit.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Backbone.Modules.Messages.Infrastructure.CompiledModels.Postgres
{
    internal partial class RecipientInformationEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Backbone.Modules.Messages.Domain.Entities.RecipientInformation",
                typeof(RecipientInformation),
                baseEntityType);

            var address = runtimeEntityType.AddProperty(
                "Address",
                typeof(IdentityAddress),
                propertyInfo: typeof(RecipientInformation).GetProperty("Address", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RecipientInformation).GetField("<Address>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 36,
                unicode: false,
                valueConverter: new IdentityAddressValueConverter());
            address.AddAnnotation("Relational:IsFixedLength", true);

            var messageId = runtimeEntityType.AddProperty(
                "MessageId",
                typeof(MessageId),
                propertyInfo: typeof(RecipientInformation).GetProperty("MessageId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RecipientInformation).GetField("<MessageId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                maxLength: 20,
                unicode: false,
                valueConverter: new MessageIdEntityFrameworkValueConverter());
            messageId.AddAnnotation("Relational:IsFixedLength", true);

            var encryptedKey = runtimeEntityType.AddProperty(
                "EncryptedKey",
                typeof(byte[]),
                propertyInfo: typeof(RecipientInformation).GetProperty("EncryptedKey", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RecipientInformation).GetField("<EncryptedKey>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var receivedAt = runtimeEntityType.AddProperty(
                "ReceivedAt",
                typeof(DateTime?),
                propertyInfo: typeof(RecipientInformation).GetProperty("ReceivedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RecipientInformation).GetField("<ReceivedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueConverter: new NullableDateTimeValueConverter());

            var receivedByDevice = runtimeEntityType.AddProperty(
                "ReceivedByDevice",
                typeof(DeviceId),
                propertyInfo: typeof(RecipientInformation).GetProperty("ReceivedByDevice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RecipientInformation).GetField("<ReceivedByDevice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20,
                unicode: false,
                valueConverter: new DeviceIdValueConverter());
            receivedByDevice.AddAnnotation("Relational:IsFixedLength", true);

            var relationshipId = runtimeEntityType.AddProperty(
                "RelationshipId",
                typeof(RelationshipId),
                propertyInfo: typeof(RecipientInformation).GetProperty("RelationshipId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(RecipientInformation).GetField("<RelationshipId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20,
                unicode: false,
                valueConverter: new RelationshipIdEntityFrameworkValueConverter());
            relationshipId.AddAnnotation("Relational:IsFixedLength", true);

            var key = runtimeEntityType.AddKey(
                new[] { address, messageId });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { messageId });

            var index0 = runtimeEntityType.AddIndex(
                new[] { receivedAt });

            var index1 = runtimeEntityType.AddIndex(
                new[] { relationshipId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("MessageId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var recipients = principalEntityType.AddNavigation("Recipients",
                runtimeForeignKey,
                onDependent: false,
                typeof(IReadOnlyCollection<RecipientInformation>),
                propertyInfo: typeof(Message).GetProperty("Recipients", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Message).GetField("<Recipients>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("RelationshipId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "RecipientInformation");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
