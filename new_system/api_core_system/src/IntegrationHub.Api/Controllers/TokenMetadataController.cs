using System.Security.Cryptography;
using IntegrationHub.Api.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[AllowAnonymous]
public sealed class TokenMetadataController(
    IOptions<TokenIssuerOptions> options,
    RsaKeyStore keyStore) : ControllerBase
{
    [HttpGet("/.well-known/openid-configuration")]
    [HttpGet("/.well-known/oauth-authorization-server")]
    public IActionResult GetOpenIdConfiguration()
    {
        if (!options.Value.Enabled)
        {
            return NotFound();
        }

        var issuer = options.Value.Issuer.TrimEnd('/');
        var scopes = options.Value.Clients
            .SelectMany(client => client.AllowedScopes)
            .Distinct(StringComparer.Ordinal)
            .Order(StringComparer.Ordinal)
            .ToArray();

        return Ok(new
        {
            issuer,
            token_endpoint = $"{issuer}/connect/token",
            jwks_uri = $"{issuer}/.well-known/jwks.json",
            grant_types_supported = new[] { "client_credentials" },
            token_endpoint_auth_methods_supported = new[] { "client_secret_post" },
            scopes_supported = scopes
        });
    }

    [HttpGet("/.well-known/jwks.json")]
    public IActionResult GetJsonWebKeySet()
    {
        if (!options.Value.Enabled)
        {
            return NotFound();
        }

        RSAParameters parameters = keyStore.ValidationKey.Rsa.ExportParameters(false);
        return Ok(new
        {
            keys = new[]
            {
                new
                {
                    kty = "RSA",
                    use = "sig",
                    kid = options.Value.KeyId,
                    alg = SecurityAlgorithms.RsaSha256,
                    n = Base64UrlEncoder.Encode(parameters.Modulus),
                    e = Base64UrlEncoder.Encode(parameters.Exponent)
                }
            }
        });
    }
}
