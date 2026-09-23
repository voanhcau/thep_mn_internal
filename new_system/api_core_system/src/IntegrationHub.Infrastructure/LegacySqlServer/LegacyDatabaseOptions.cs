namespace IntegrationHub.Infrastructure.LegacySqlServer;

public sealed class LegacyDatabaseOptions
{
    public const string SectionName = "LegacyDatabase";

    public string ConnectionString { get; init; } = string.Empty;
    public int CommandTimeoutSeconds { get; init; } = 30;
}
