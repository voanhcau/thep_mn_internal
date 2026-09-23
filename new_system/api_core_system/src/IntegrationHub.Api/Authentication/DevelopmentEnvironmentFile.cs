namespace IntegrationHub.Api.Authentication;

/// <summary>
/// Loads a local .env file before ASP.NET Core builds its configuration.
/// This loader is deliberately disabled outside the Development environment.
/// Existing process environment variables always take precedence over the file.
/// </summary>
public static class DevelopmentEnvironmentFile
{
    private const string FileVariable = "INTEGRATIONHUB_ENV_FILE";

    public static void Load()
    {
        var environmentName =
            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
            Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

        if (!string.Equals(environmentName, "Development", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        var configuredPath = Environment.GetEnvironmentVariable(FileVariable);
        var path = string.IsNullOrWhiteSpace(configuredPath) ? ".env" : configuredPath;
        var fullPath = Path.GetFullPath(path, Environment.CurrentDirectory);

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException(
                $"Development environment file was not found: {fullPath}",
                fullPath);
        }

        foreach (var rawLine in File.ReadLines(fullPath))
        {
            var line = rawLine.Trim();
            if (line.Length == 0 || line.StartsWith('#'))
            {
                continue;
            }

            var separatorIndex = line.IndexOf('=');
            if (separatorIndex <= 0)
            {
                throw new FormatException($"Invalid .env entry: {rawLine}");
            }

            var key = line[..separatorIndex].Trim();
            var value = RemoveMatchingQuotes(line[(separatorIndex + 1)..].Trim());

            if (Environment.GetEnvironmentVariable(key) is null)
            {
                Environment.SetEnvironmentVariable(key, value);
            }
        }
    }

    private static string RemoveMatchingQuotes(string value)
    {
        if (value.Length >= 2 &&
            ((value[0] == '"' && value[^1] == '"') ||
             (value[0] == '\'' && value[^1] == '\'')))
        {
            return value[1..^1];
        }

        return value;
    }
}
