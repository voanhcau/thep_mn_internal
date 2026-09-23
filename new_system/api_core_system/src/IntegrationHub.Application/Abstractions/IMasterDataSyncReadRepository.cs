using IntegrationHub.Application.Modules.MasterData.Sync;
using IntegrationHub.Domain.MasterData;

namespace IntegrationHub.Application.Abstractions;

public interface IMasterDataSyncReadRepository
{
    Task<MasterDataSyncPage> GetPageAsync(
        GetMasterDataSyncPageQuery query,
        CancellationToken cancellationToken);
}
