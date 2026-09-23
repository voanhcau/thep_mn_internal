using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IntegrationHub.Api.Authentication;

public sealed class AccessTokenService(
    IOptions<TokenIssuerOptions> options,
    RsaKeyStore keyStore,
    TimeProvider timeProvider)
{
    private readonly TokenIssuerOptions _options = options.Value;

    public TokenIssueResult Issue(
        string? clientId,
        string? clientSecret,
        string? requestedScope)
    {
        var client = _options.Clients.SingleOrDefault(candidate =>
            string.Equals(candidate.ClientId, clientId, StringComparison.Ordinal));

        if (client is null ||
            string.IsNullOrEmpty(clientSecret) ||
            !SecretsMatch(client.ClientSecret, clientSecret))
        {
            return TokenIssueResult.InvalidClient();
        }

        var requestedScopes = (requestedScope ?? string.Empty)
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Distinct(StringComparer.Ordinal)
            .ToArray();

        if (requestedScopes.Length == 0 ||
            requestedScopes.Any(scope =>
                !client.AllowedScopes.Contains(scope, StringComparer.Ordinal)))
        {
            return TokenIssueResult.InvalidScope();
        }

        var now = timeProvider.GetUtcNow();
        var expires = now.AddMinutes(TokenIssuerOptions.RequiredAccessTokenLifetimeMinutes);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, client.ClientId),
            new("client_id", client.ClientId),
            new("scope", string.Join(' ', requestedScopes)),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new(
                JwtRegisteredClaimNames.Iat,
                now.ToUnixTimeSeconds().ToString(System.Globalization.CultureInfo.InvariantCulture),
                ClaimValueTypes.Integer64)
        };

        var token = new JwtSecurityToken(
            issuer: _options.Issuer.TrimEnd('/'),
            audience: _options.Audience,
            claims: claims,
            notBefore: now.UtcDateTime,
            expires: expires.UtcDateTime,
            signingCredentials: new SigningCredentials(
                keyStore.SigningKey,
                SecurityAlgorithms.RsaSha256));

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        return TokenIssueResult.Success(
            accessToken,
            checked((int)(expires - now).TotalSeconds),
            string.Join(' ', requestedScopes));
    }

    private static bool SecretsMatch(string configuredSecret, string providedSecret)
    {
        var configuredHash = SHA256.HashData(Encoding.UTF8.GetBytes(configuredSecret));
        var providedHash = SHA256.HashData(Encoding.UTF8.GetBytes(providedSecret));
        return CryptographicOperations.FixedTimeEquals(configuredHash, providedHash);
    }
}

public sealed record TokenIssueResult(
    bool IsSuccess,
    string? AccessToken,
    int ExpiresIn,
    string? Scope,
    TokenIssueError Error)
{
    public static TokenIssueResult Success(string accessToken, int expiresIn, string scope) =>
        new(true, accessToken, expiresIn, scope, TokenIssueError.None);

    public static TokenIssueResult InvalidClient() =>
        new(false, null, 0, null, TokenIssueError.InvalidClient);

    public static TokenIssueResult InvalidScope() =>
        new(false, null, 0, null, TokenIssueError.InvalidScope);
}

public enum TokenIssueError
{
    None,
    InvalidClient,
    InvalidScope
}
