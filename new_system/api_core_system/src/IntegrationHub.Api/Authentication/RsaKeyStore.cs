using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Api.Authentication;

public sealed class RsaKeyStore : IDisposable
{
    private readonly Lazy<KeyMaterial> _keyMaterial;

    public RsaKeyStore(
        IOptions<TokenIssuerOptions> options,
        IHostEnvironment environment)
    {
        _keyMaterial = new Lazy<KeyMaterial>(
            () => Load(options.Value, environment.ContentRootPath),
            LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public RsaSecurityKey SigningKey => _keyMaterial.Value.SigningKey;
    public RsaSecurityKey ValidationKey => _keyMaterial.Value.ValidationKey;

    public void EnsureLoaded() => _ = _keyMaterial.Value;

    public void Dispose()
    {
        if (_keyMaterial.IsValueCreated)
        {
            _keyMaterial.Value.Dispose();
        }
    }

    private static KeyMaterial Load(TokenIssuerOptions options, string contentRootPath)
    {
        if (!options.Enabled)
        {
            throw new InvalidOperationException("The local token issuer is disabled.");
        }

        var privateKeyPath = ResolvePath(options.PrivateKeyPath, contentRootPath);
        var publicKeyPath = ResolvePath(options.PublicKeyPath, contentRootPath);

        var privateRsa = RSA.Create();
        var publicRsa = RSA.Create();

        try
        {
            privateRsa.ImportFromPem(File.ReadAllText(privateKeyPath));
            publicRsa.ImportFromPem(File.ReadAllText(publicKeyPath));

            VerifyKeyPair(privateRsa, publicRsa);

            return new KeyMaterial(
                privateRsa,
                publicRsa,
                new RsaSecurityKey(privateRsa) { KeyId = options.KeyId },
                new RsaSecurityKey(publicRsa) { KeyId = options.KeyId });
        }
        catch
        {
            privateRsa.Dispose();
            publicRsa.Dispose();
            throw;
        }
    }

    private static string ResolvePath(string configuredPath, string contentRootPath)
    {
        var path = Path.IsPathRooted(configuredPath)
            ? configuredPath
            : Path.Combine(contentRootPath, configuredPath);
        var fullPath = Path.GetFullPath(path);

        if (!File.Exists(fullPath))
        {
            throw new InvalidOperationException($"Token signing key file was not found: {fullPath}");
        }

        return fullPath;
    }

    private static void VerifyKeyPair(RSA privateRsa, RSA publicRsa)
    {
        var privatePublicParameters = privateRsa.ExportParameters(false);
        var publicParameters = publicRsa.ExportParameters(false);

        if (privatePublicParameters.Modulus is null ||
            privatePublicParameters.Exponent is null ||
            publicParameters.Modulus is null ||
            publicParameters.Exponent is null ||
            !CryptographicOperations.FixedTimeEquals(
                privatePublicParameters.Modulus,
                publicParameters.Modulus) ||
            !CryptographicOperations.FixedTimeEquals(
                privatePublicParameters.Exponent,
                publicParameters.Exponent))
        {
            throw new InvalidOperationException(
                "TokenIssuer private key and public key do not belong to the same RSA key pair.");
        }
    }

    private sealed record KeyMaterial(
        RSA PrivateRsa,
        RSA PublicRsa,
        RsaSecurityKey SigningKey,
        RsaSecurityKey ValidationKey) : IDisposable
    {
        public void Dispose()
        {
            PrivateRsa.Dispose();
            PublicRsa.Dispose();
        }
    }
}
