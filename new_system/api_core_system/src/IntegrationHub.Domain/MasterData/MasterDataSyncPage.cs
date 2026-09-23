namespace IntegrationHub.Domain.MasterData;

public sealed record MasterDataSyncPage(
    string Entity,
    IReadOnlyList<string> KeyFields,
    int Page,
    int PageSize,
    bool HasMore,
    IReadOnlyList<IReadOnlyDictionary<string, object?>> Data);
