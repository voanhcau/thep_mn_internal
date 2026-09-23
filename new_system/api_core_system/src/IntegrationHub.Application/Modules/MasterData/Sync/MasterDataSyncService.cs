using IntegrationHub.Application.Abstractions;
using IntegrationHub.Domain.MasterData;

namespace IntegrationHub.Application.Modules.MasterData.Sync;

public sealed class MasterDataSyncService(IMasterDataSyncReadRepository repository)
{
    public IReadOnlyList<string> GetCatalog() => MasterDataEntityCatalog.All;

    public Task<MasterDataSyncPage> GetPageAsync(
        GetMasterDataSyncPageQuery query,
        CancellationToken cancellationToken)
    {
        var entity = query.Entity?.Trim().ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(entity) || !MasterDataEntityCatalog.Contains(entity))
        {
            throw new MasterDataSyncQueryValidationException(
                "The requested master-data entity is not supported.");
        }

        if (query.Page < 1)
        {
            throw new MasterDataSyncQueryValidationException("page must be greater than or equal to 1.");
        }

        if (query.PageSize is < 1 or > 1000)
        {
            throw new MasterDataSyncQueryValidationException(
                "page_size must be between 1 and 1000.");
        }

        return repository.GetPageAsync(query with { Entity = entity }, cancellationToken);
    }
}
