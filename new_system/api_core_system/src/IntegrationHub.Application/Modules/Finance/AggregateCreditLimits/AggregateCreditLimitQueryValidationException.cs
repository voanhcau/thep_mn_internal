namespace IntegrationHub.Application.Modules.Finance.AggregateCreditLimits;

public sealed class AggregateCreditLimitQueryValidationException(string message)
    : Exception(message);
