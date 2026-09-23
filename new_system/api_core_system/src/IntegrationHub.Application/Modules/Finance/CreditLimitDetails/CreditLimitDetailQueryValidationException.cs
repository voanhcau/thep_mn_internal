namespace IntegrationHub.Application.Modules.Finance.CreditLimitDetails;

public sealed class CreditLimitDetailQueryValidationException(string message)
    : Exception(message);
