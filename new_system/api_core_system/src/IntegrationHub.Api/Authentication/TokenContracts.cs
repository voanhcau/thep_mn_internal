using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationHub.Api.Authentication;

public sealed class ClientCredentialsTokenRequest
{
    [FromForm(Name = "grant_type")]
    public string? GrantType { get; init; }

    [FromForm(Name = "client_id")]
    public string? ClientId { get; init; }

    [FromForm(Name = "client_secret")]
    public string? ClientSecret { get; init; }

    [FromForm(Name = "scope")]
    public string? Scope { get; init; }
}

public sealed record AccessTokenResponse(
    [property: JsonPropertyName("access_token")] string AccessToken,
    [property: JsonPropertyName("token_type")] string TokenType,
    [property: JsonPropertyName("expires_in")] int ExpiresIn,
    [property: JsonPropertyName("scope")] string Scope);

public sealed record OAuthErrorResponse(
    [property: JsonPropertyName("error")] string Error,
    [property: JsonPropertyName("error_description")] string ErrorDescription);
