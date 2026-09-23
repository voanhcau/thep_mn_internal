namespace IntegrationHub.Api.Authentication;

public sealed class TokenIssuerOptions
{
    public const string SectionName = "TokenIssuer";
    public const int RequiredAccessTokenLifetimeMinutes = 30;

    public bool Enabled { get; init; }
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string KeyId { get; init; } = string.Empty;
    public string PrivateKeyPath { get; init; } = string.Empty;
    public string PublicKeyPath { get; init; } = string.Empty;
    public int AccessTokenLifetimeMinutes { get; init; } = RequiredAccessTokenLifetimeMinutes;
    public List<TokenClientOptions> Clients { get; init; } = [];
}

public sealed class TokenClientOptions
{
    public string ClientId { get; init; } = string.Empty;
    public string ClientSecret { get; init; } = string.Empty;
    public List<string> AllowedScopes { get; init; } = [];
}
