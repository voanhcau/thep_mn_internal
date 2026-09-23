namespace IntegrationHub.Infrastructure.Odoo;

public sealed class OdooOptions
{
    public const string SectionName = "Odoo";

    public bool Enabled { get; init; }
    public string BaseUrl { get; init; } = string.Empty;
    public string Database { get; init; } = string.Empty;
    public string ApiKey { get; init; } = string.Empty;
    public int TimeoutSeconds { get; init; } = 30;
}
