using IntegrationHub.Api.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("connect/token")]
public sealed class TokenController(
    AccessTokenService tokenService,
    IOptions<TokenIssuerOptions> options) : ControllerBase
{
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    [ProducesResponseType<AccessTokenResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<OAuthErrorResponse>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<OAuthErrorResponse>(StatusCodes.Status401Unauthorized)]
    public ActionResult<AccessTokenResponse> Create(
        [FromForm] ClientCredentialsTokenRequest request)
    {
        if (!options.Value.Enabled)
        {
            return NotFound();
        }

        Response.Headers.CacheControl = "no-store";
        Response.Headers.Pragma = "no-cache";

        if (!string.Equals(request.GrantType, "client_credentials", StringComparison.Ordinal))
        {
            return BadRequest(new OAuthErrorResponse(
                "unsupported_grant_type",
                "Only grant_type=client_credentials is supported."));
        }

        var result = tokenService.Issue(
            request.ClientId,
            request.ClientSecret,
            request.Scope);

        if (result.Error == TokenIssueError.InvalidClient)
        {
            Response.Headers.WWWAuthenticate = "Basic realm=\"token\"";
            return Unauthorized(new OAuthErrorResponse(
                "invalid_client",
                "Client authentication failed."));
        }

        if (result.Error == TokenIssueError.InvalidScope)
        {
            return BadRequest(new OAuthErrorResponse(
                "invalid_scope",
                "The requested scope is empty or is not allowed for this client."));
        }

        return Ok(new AccessTokenResponse(
            result.AccessToken!,
            "Bearer",
            result.ExpiresIn,
            result.Scope!));
    }
}
