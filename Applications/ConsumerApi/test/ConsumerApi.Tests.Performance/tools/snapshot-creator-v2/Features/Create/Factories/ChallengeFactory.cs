﻿using System.Diagnostics;
using Backbone.ConsumerApi.Sdk.Endpoints.Challenges.Types;
using Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Create.Helper;
using Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Create.SubHandler;
using Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Backbone.ConsumerApi.Tests.Performance.SnapshotCreator.V2.Features.Create.Factories;

public class ChallengeFactory(ILogger<ChallengeFactory> logger, IConsumerApiHelper consumerApiHelper) : IChallengeFactory
{
    public int TotalCreatedChallenges { get; private set; }
    public int TotalConfiguredChallenges { get; set; }

    private readonly Lock _lockObj = new();
    private readonly SemaphoreSlim _semaphore = new(Environment.ProcessorCount);

    internal int GetSemaphoreCurrentCount() => _semaphore.CurrentCount;

    public async Task Create(CreateChallenges.Command request, DomainIdentity identityWithChallenge)
    {
        await _semaphore.WaitAsync();

        try
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();
            var challenges = await CreateChallenges(request, identityWithChallenge);
            stopwatch.Stop();

            using (_lockObj.EnterScope())
            {
                TotalCreatedChallenges += challenges.Count;
            }

            logger.LogDebug(
                "Created {CreatedChallenges}/{TotalChallenges} challenges.  Semaphore.Count: {SemaphoreCount} - Challenges of Identity {Address}/{ConfigurationAddress}/{Pool} created in {ElapsedMilliseconds} ms",
                TotalCreatedChallenges,
                TotalConfiguredChallenges,
                _semaphore.CurrentCount,
                identityWithChallenge.IdentityAddress,
                identityWithChallenge.ConfigurationIdentityAddress,
                identityWithChallenge.PoolAlias,
                stopwatch.ElapsedMilliseconds);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    internal async Task<List<Challenge>> CreateChallenges(CreateChallenges.Command request, DomainIdentity identityWithChallenge)
    {
        List<Challenge> challenges = [];
        var sdkClient = consumerApiHelper.CreateForExistingIdentity(request.BaseUrlAddress, request.ClientCredentials, identityWithChallenge.UserCredentials);

        for (var i = 0; i < identityWithChallenge.NumberOfChallenges; i++)
        {
            if (sdkClient.DeviceData?.DeviceId is null || identityWithChallenge.DeviceIds.Count == 0)
            {
                var identityDeviceId = identityWithChallenge.DeviceIds.Count > 0 ? string.Join(',', identityWithChallenge.DeviceIds) : "null";

                logger.LogWarning("SDK Client DeviceId is {SdkClientDeviceId}! " +
                                  "Configuration {Address}/{ConfigurationAddress}/{Pool} \r\n" +
                                  "Identity DeviceIds: {IdentityDeviceIds}",
                    sdkClient.DeviceData?.DeviceId is null,
                    identityWithChallenge.IdentityAddress,
                    identityWithChallenge.ConfigurationIdentityAddress,
                    identityWithChallenge.PoolAlias,
                    identityDeviceId);
            }

            var apiResponse = await consumerApiHelper.CreateChallenge(sdkClient);

            if (apiResponse.IsError)
            {
                throw new InvalidOperationException(BuildErrorDetails("Failed to create challenge.",
                    identityWithChallenge,
                    apiResponse));
            }

            var challenge = apiResponse.Result;

            if (challenge is null) continue;

            challenges.Add(challenge);
        }

        identityWithChallenge.Challenges.AddRange(challenges);

        return challenges;
    }
}