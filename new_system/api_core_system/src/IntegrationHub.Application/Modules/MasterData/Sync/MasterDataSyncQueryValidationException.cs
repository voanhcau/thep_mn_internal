namespace IntegrationHub.Application.Modules.MasterData.Sync;

public sealed class MasterDataSyncQueryValidationException(string message)
    : Exception(message);
