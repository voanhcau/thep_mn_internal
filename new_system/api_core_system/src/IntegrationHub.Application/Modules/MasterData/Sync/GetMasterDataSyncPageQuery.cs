namespace IntegrationHub.Application.Modules.MasterData.Sync;

public sealed record GetMasterDataSyncPageQuery(string? Entity, int Page, int PageSize);
