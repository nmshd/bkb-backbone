﻿using Backbone.BuildingBlocks.Domain;
using Backbone.DevelopmentKit.Identity.ValueObjects;

namespace Backbone.Synchronization.Domain.Entities;

public class Datawallet
{
#pragma warning disable CS8618
    private Datawallet() { }
#pragma warning restore CS8618

    public Datawallet(DatawalletVersion version, IdentityAddress owner) : this()
    {
        Id = DatawalletId.New();
        Version = version;
        Owner = owner;
        Modifications = new List<DatawalletModification>();
    }

    public DatawalletId Id { get; }
    public IdentityAddress Owner { get; }
    public DatawalletVersion Version { get; private set; }
    public List<DatawalletModification> Modifications { get; }
    public DatawalletModification? LatestModification => Modifications.MaxBy(m => m.Index);

    public void Upgrade(DatawalletVersion targetVersion)
    {
        if (targetVersion < Version)
            throw new DomainException(DomainErrors.Datawallet.CannotDowngrade(Version.Value, targetVersion.Value));

        Version = targetVersion;
    }

    public DatawalletModification AddModification(DatawalletModificationType type, DatawalletVersion datawalletVersionOfModification, string collection, string objectIdentifier, string payloadCategory, byte[] encryptedPayload, DeviceId createdByDevice, string blobReference)
    {
        if (datawalletVersionOfModification > Version)
            throw new DomainException(DomainErrors.Datawallet.DatawalletVersionOfModificationTooHigh(Version, datawalletVersionOfModification));

        var indexOfNewModification = Modifications.Count > 0 ? Modifications.Max(m => m.Index) + 1 : 0;

        var newModification = new DatawalletModification(this, datawalletVersionOfModification, indexOfNewModification, type, collection, objectIdentifier, payloadCategory, encryptedPayload, createdByDevice, blobReference);
        Modifications.Add(newModification);
        return newModification;
    }

    public class DatawalletVersion : SimpleValueObject<ushort>
    {
        public DatawalletVersion(ushort value) : base(value) { }

        public static bool operator <(DatawalletVersion versionA, DatawalletVersion versionB)
        {
            return versionA.Value < versionB.Value;
        }

        public static bool operator >(DatawalletVersion versionA, DatawalletVersion versionB)
        {
            return versionA.Value > versionB.Value;
        }
    }
}
