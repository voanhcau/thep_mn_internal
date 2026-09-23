using IntegrationHub.Application.Modules.Finance.CreditLimitDetails;
using IntegrationHub.Domain.Finance;

namespace IntegrationHub.Application.Abstractions;

public interface ICreditLimitDetailReadRepository
{
    Task<CreditLimitDetailResult> GetAsync(
        GetCreditLimitDetailsQuery query,
        CancellationToken cancellationToken);
}
