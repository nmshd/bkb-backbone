﻿using AdminApi.Tests.Integration.API;
using AdminApi.Tests.Integration.Extensions;
using AdminApi.Tests.Integration.Models;
using Newtonsoft.Json;

namespace AdminApi.Tests.Integration.StepDefinitions;

[Scope(Feature = "POST TierQuota")]
public class TierQuotaStepDefinitions : BaseStepDefinitions
{
    private readonly TiersApi _tiersApi;
    private string _tierId;
    private HttpResponse<TierQuotaDefinitionDTO>? _response;

    public TierQuotaStepDefinitions(TiersApi tiersApi) : base()
    {
        _tiersApi = tiersApi;
        _tierId = string.Empty;
    }

    [Given(@"a valid Tier")]
    public void GivenAValidTier()
    {
        _tierId = "TIR9xK9NLCTvGDx6zlfR";
    }

    [Given(@"an invalid Tier")]
    public void GivenAnInvalidTier()
    {
        _tierId = "some-inexistent-tier-id";
    }

    [When(@"a POST request is sent to the Create Tier Quota endpoint")]
    public async Task WhenAPOSTRequestIsSentToTheCreateTiersQuotaEndpoint()
    {
        var createTierQuotaRequest = new CreateTierQuotaRequest
        {
            MetricKey = "NumberOfSentMessages",
            Max = 2,
            Period = "Week"
        };

        var requestConfiguration = new RequestConfiguration();
        requestConfiguration.SupplementWith(_requestConfiguration);
        requestConfiguration.ContentType = "application/json";
        requestConfiguration.Content = JsonConvert.SerializeObject(createTierQuotaRequest);

        _response = await _tiersApi.CreateTierQuota(requestConfiguration, _tierId);
    }

    [Then(@"the response status code is (\d+) \(.+\)")]
    public void ThenTheResponseStatusCodeIs(int expectedStatusCode)
    {
        var actualStatusCode = (int)_response!.StatusCode;
        actualStatusCode.Should().Be(expectedStatusCode);
    }

    [Then(@"the response contains a TierQuotaDefinition")]
    public void ThenTheResponseContainsATierQuotaDefinition()
    {
        _response!.AssertHasValue();
        _response!.AssertStatusCodeIsSuccess();
        _response!.AssertContentTypeIs("application/json");
        _response!.AssertContentCompliesWithSchema();
    }

    [Then(@"the response content includes an error with the error code ""([^""]+)""")]
    public void ThenTheResponseContentIncludesAnErrorWithTheErrorCode(string errorCode)
    {
        _response!.Content.Error.Should().NotBeNull();
        _response.Content.Error!.Code.Should().Be(errorCode);
    }
}