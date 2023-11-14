﻿using Backbone.BuildingBlocks.Domain.Errors;
using Backbone.Modules.Quotas.Domain.Aggregates.Metrics;

namespace Backbone.Modules.Quotas.Domain;

public static class DomainErrors
{
    public static DomainError UnsupportedMetricKey()
    {
        return new DomainError("error.platform.quotas.unsupportedMetricKey", $"The given metric key is not supported. The supported metric keys are: [{string.Join(", ", MetricKey.GetSupportedMetricKeyValues())}].");
    }

    public static DomainError MaxValueCannotBeLowerThanZero()
    {
        return new DomainError("error.platform.quotas.invalidValueForMaxLimitInQuota", "A quota max value cannot be lower than zero.");
    }

    public static DomainError DuplicateQuota()
    {
        return new DomainError("error.platform.quotas.duplicateQuota", "A quota targeting the same metric and period already exists.");
    }

    public static DomainError CannotCreateOrDeleteQuotaForUpForDeletionTier()
    {
        return new DomainError("error.platform.quotas.cannotCreateOrDeleteQuotaOnUpForDeletionTier", "Quotas cannot be manually managed for the Up for Deletion tier.");
    }
}
