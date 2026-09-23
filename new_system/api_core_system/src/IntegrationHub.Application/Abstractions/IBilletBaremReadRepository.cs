using IntegrationHub.Application.Common;
using IntegrationHub.Application.Modules.MasterData.BilletBarems;
using IntegrationHub.Domain.MasterData;

namespace IntegrationHub.Application.Abstractions;

public interface IBilletBaremReadRepository
{
    Task<PagedResult<BilletBarem>> SearchAsync(
        SearchBilletBaremsQuery query,
        CancellationToken cancellationToken);

    Task<BilletBarem?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
