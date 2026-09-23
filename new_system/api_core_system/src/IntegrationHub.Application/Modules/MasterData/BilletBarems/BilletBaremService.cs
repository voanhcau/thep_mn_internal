using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Common;
using IntegrationHub.Domain.MasterData;

namespace IntegrationHub.Application.Modules.MasterData.BilletBarems;

public sealed class BilletBaremService(IBilletBaremReadRepository repository)
{
    public Task<PagedResult<BilletBarem>> SearchAsync(
        SearchBilletBaremsQuery query,
        CancellationToken cancellationToken)
    {
        var normalized = query.Normalize();

        if (normalized.EffectiveFrom > normalized.EffectiveTo)
        {
            throw new ArgumentException("effectiveFrom must be less than or equal to effectiveTo.");
        }

        return repository.SearchAsync(normalized, cancellationToken);
    }

    public Task<BilletBarem?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "id must be greater than zero.");
        }

        return repository.GetByIdAsync(id, cancellationToken);
    }
}
