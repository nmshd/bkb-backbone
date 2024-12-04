﻿using System.Diagnostics;
using Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Create.SubHandler;

public class DeviceFactory(ILogger<DeviceFactory> logger, IConsumerApiClient consumerApiClient) : IDeviceFactory
{
    private int _numberOfCreatedDevices;
    public int TotalNumberOfDevices { get; set; }
    private readonly Lock _lockObj = new();
    private readonly SemaphoreSlim _semaphoreSlim = new(Environment.ProcessorCount);

    public async Task Create(CreateDevices.Command request, DomainIdentity identity)
    {
        await _semaphoreSlim.WaitAsync();

        try
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();
            var deviceIds = await CreateDevices(request, identity);
            stopwatch.Stop();

            using (_lockObj.EnterScope())
            {
                _numberOfCreatedDevices += deviceIds.Count;
            }

            logger.LogDebug(
                "Created {CreatedDevices}/{TotalNumberOfDevices} devices.  Semaphore.Count: {SemaphoreCount} - Devices {DeviceIds} of Identity {Address}/{ConfigurationAddress}/{Pool} created in {ElapsedMilliseconds} ms",
                _numberOfCreatedDevices,
                TotalNumberOfDevices,
                _semaphoreSlim.CurrentCount,
                string.Join(',', deviceIds),
                identity.IdentityAddress,
                identity.ConfigurationIdentityAddress,
                identity.PoolAlias,
                stopwatch.ElapsedMilliseconds);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    internal async Task<List<string>> CreateDevices(CreateDevices.Command request, DomainIdentity identity)
    {
        List<string> deviceIds = [];

        var sdkClient = consumerApiClient.CreateForExistingIdentity(request, identity);

        if (identity.DeviceIds.Count == 1)
        {
            // Note: One Device gets already added in the Identity creation handler
            deviceIds.Add(identity.DeviceIds[0]);
        }

        for (var i = 1; i < identity.NumberOfDevices; i++)
        {
            var newDeviceId = await consumerApiClient.OnBoardNewDevice(identity, sdkClient);

            deviceIds.Add(newDeviceId);
        }

        identity.AddDevices(deviceIds);
        return deviceIds;
    }
}
