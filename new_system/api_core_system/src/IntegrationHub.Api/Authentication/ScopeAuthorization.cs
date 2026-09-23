using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace IntegrationHub.Api.Authentication;

public static class ScopeAuthorization
{
    public static IServiceCollection AddApiAuthentication(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        var authority = configuration["Authentication:Authority"];
        var audience = configuration["Authentication:Audience"];
        var tokenIssuer = configuration
            .GetSection(TokenIssuerOptions.SectionName)
            .Get<TokenIssuerOptions>() ?? new TokenIssuerOptions();

        services.AddOptions<TokenIssuerOptions>()
            .Bind(configuration.GetSection(TokenIssuerOptions.SectionName))
            .Validate(options => !options.Enabled || IsValidIssuer(options.Issuer, environment),
                "TokenIssuer:Issuer must use HTTPS. HTTP is allowed only for a loopback URL in Development.")
            .Validate(options => !options.Enabled || !string.IsNullOrWhiteSpace(options.Audience),
                "TokenIssuer:Audience is required when the token issuer is enabled.")
            .Validate(options => !options.Enabled || !string.IsNullOrWhiteSpace(options.KeyId),
                "TokenIssuer:KeyId is required when the token issuer is enabled.")
            .Validate(options => !options.Enabled ||
                (!string.IsNullOrWhiteSpace(options.PrivateKeyPath) &&
                 !string.IsNullOrWhiteSpace(options.PublicKeyPath)),
                "TokenIssuer private/public key paths are required when the token issuer is enabled.")
            .Validate(options => !options.Enabled ||
                options.AccessTokenLifetimeMinutes == TokenIssuerOptions.RequiredAccessTokenLifetimeMinutes,
                "Access tokens must have a lifetime of exactly 30 minutes.")
            .Validate(options => !options.Enabled ||
                (options.Clients.Count > 0 &&
                 options.Clients.All(client =>
                     !string.IsNullOrWhiteSpace(client.ClientId) &&
                     !string.IsNullOrWhiteSpace(client.ClientSecret) &&
                     client.AllowedScopes.Count > 0)),
                "At least one complete TokenIssuer client is required when enabled.")
            .Validate(options => !options.Enabled ||
                options.Clients.Select(client => client.ClientId).Distinct(StringComparer.Ordinal).Count() ==
                options.Clients.Count,
                "TokenIssuer client IDs must be unique.")
            .ValidateOnStart();

        services.AddSingleton<RsaKeyStore>();
        services.AddSingleton<AccessTokenService>();
        services.AddSingleton(TimeProvider.System);

        if (!tokenIssuer.Enabled &&
            (string.IsNullOrWhiteSpace(authority) || string.IsNullOrWhiteSpace(audience)))
        {
            throw new InvalidOperationException(
                "Authentication:Authority and Authentication:Audience are required.");
        }

        var authentication = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

        if (tokenIssuer.Enabled)
        {
            authentication.AddJwtBearer();
            services.AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
                .Configure<RsaKeyStore, IOptions<TokenIssuerOptions>>((options, keyStore, issuerOptions) =>
                {
                    options.MapInboundClaims = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = keyStore.ValidationKey,
                        ValidateIssuer = true,
                        ValidIssuer = issuerOptions.Value.Issuer.TrimEnd('/'),
                        ValidateAudience = true,
                        ValidAudience = issuerOptions.Value.Audience,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        RequireSignedTokens = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidAlgorithms = [SecurityAlgorithms.RsaSha256]
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            if (!HasAcceptableThirtyMinuteLifetime(context.SecurityToken))
                            {
                                context.Fail("The access token lifetime exceeds 30 minutes.");
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
        }
        else
        {
            authentication.AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.Audience = audience;
                options.RequireHttpsMetadata = true;
                options.MapInboundClaims = false;
                options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });
        }

        services.AddAuthorization(options =>
        {
            foreach (var scope in ApiScopes.All)
            {
                options.AddPolicy(scope, policy => policy
                    .RequireAuthenticatedUser()
                    .RequireAssertion(context => HasScope(context.User, scope)));
            }
        });

        return services;
    }

    private static bool IsValidIssuer(string issuer, IHostEnvironment environment)
    {
        if (string.IsNullOrWhiteSpace(issuer) ||
            !Uri.TryCreate(issuer, UriKind.Absolute, out var issuerUri))
        {
            return false;
        }

        return issuerUri.Scheme == Uri.UriSchemeHttps ||
               (environment.IsDevelopment() &&
                issuerUri.Scheme == Uri.UriSchemeHttp &&
                issuerUri.IsLoopback);
    }

    private static bool HasScope(ClaimsPrincipal user, string requiredScope) =>
        user.FindAll("scope")
            .SelectMany(claim => claim.Value.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Contains(requiredScope, StringComparer.Ordinal);

    private static bool HasAcceptableThirtyMinuteLifetime(SecurityToken securityToken)
    {
        IEnumerable<Claim> claims = securityToken switch
        {
            JwtSecurityToken jwt => jwt.Claims,
            JsonWebToken jsonWebToken => jsonWebToken.Claims,
            _ => []
        };

        var issuedAtClaim = claims
            .SingleOrDefault(claim => claim.Type == "iat")?.Value;
        var expiresClaim = claims
            .SingleOrDefault(claim => claim.Type == "exp")?.Value;

        if (!long.TryParse(
                issuedAtClaim,
                System.Globalization.NumberStyles.None,
                System.Globalization.CultureInfo.InvariantCulture,
                out var issuedAtUnixSeconds) ||
            !long.TryParse(
                expiresClaim,
                System.Globalization.NumberStyles.None,
                System.Globalization.CultureInfo.InvariantCulture,
                out var expiresUnixSeconds))
        {
            return false;
        }

        var lifetimeSeconds = expiresUnixSeconds - issuedAtUnixSeconds;
        return lifetimeSeconds is > 0 and <=
            TokenIssuerOptions.RequiredAccessTokenLifetimeMinutes * 60;
    }
}
