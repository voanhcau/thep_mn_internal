using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Modules.Odoo.MethodCalls;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.Odoo;

public sealed class OdooGatewayClient(
    HttpClient httpClient,
    IOptions<OdooOptions> options,
    ILogger<OdooGatewayClient> logger) : IOdooGatewayClient
{
    private const string GatewayPath = "json/2/iwmn.api.gateway/call_as_user";
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly OdooOptions _options = options.Value;

    public async Task<JsonElement> CallAsync(
        OdooMethodCall command,
        CancellationToken cancellationToken)
    {
        if (!_options.Enabled)
        {
            throw new OdooGatewayException("The Odoo connection is disabled.");
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, GatewayPath);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);
        request.Headers.UserAgent.ParseAdd("IntegrationHub/1.0");
        if (!string.IsNullOrWhiteSpace(_options.Database))
        {
            request.Headers.Add("X-Odoo-Database", _options.Database);
        }

        request.Content = JsonContent.Create(new Dictionary<string, object?>
        {
            ["model"] = command.Model,
            ["method"] = command.Method,
            ["user_id"] = command.UserId,
            ["record_ids"] = command.RecordIds,
            ["vals"] = command.Vals,
            ["args"] = command.Args,
            ["kwargs"] = command.Kwargs,
            ["context"] = command.Context
        }, options: SerializerOptions);

        HttpResponseMessage response;
        try
        {
            response = await httpClient.SendAsync(request, cancellationToken);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            throw new OdooGatewayException("The Odoo request timed out.");
        }
        catch (HttpRequestException exception)
        {
            throw new OdooGatewayException("Could not connect to Odoo.", innerException: exception);
        }

        using (response)
        {
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var error = ParseError(responseBody);
                logger.LogWarning(
                    "Odoo rejected {Model}.{Method} for user {UserId} with HTTP {StatusCode}: {ErrorType}",
                    command.Model,
                    command.Method,
                    command.UserId,
                    (int)response.StatusCode,
                    error.Type ?? "unknown");
                throw new OdooGatewayException(
                    error.Message ?? "Odoo rejected the method call.",
                    (int)response.StatusCode,
                    error.Type);
            }

            try
            {
                using var document = JsonDocument.Parse(responseBody);
                return document.RootElement.Clone();
            }
            catch (JsonException exception)
            {
                throw new OdooGatewayException(
                    "Odoo returned an invalid JSON response.",
                    (int)response.StatusCode,
                    innerException: exception);
            }
        }
    }

    private static (string? Message, string? Type) ParseError(string responseBody)
    {
        try
        {
            using var document = JsonDocument.Parse(responseBody);
            var root = document.RootElement;
            var message = TryGetString(root, "message") ??
                          TryGetNestedString(root, "error", "message");
            var type = TryGetString(root, "name") ??
                       TryGetString(root, "type") ??
                       TryGetNestedString(root, "error", "name") ??
                       TryGetNestedString(root, "error", "type");
            return (message, type);
        }
        catch (JsonException)
        {
            return (null, null);
        }
    }

    private static string? TryGetString(JsonElement element, string propertyName) =>
        element.ValueKind == JsonValueKind.Object &&
        element.TryGetProperty(propertyName, out var property) &&
        property.ValueKind == JsonValueKind.String
            ? property.GetString()
            : null;

    private static string? TryGetNestedString(
        JsonElement element,
        string parentProperty,
        string propertyName) =>
        element.ValueKind == JsonValueKind.Object &&
        element.TryGetProperty(parentProperty, out var parent)
            ? TryGetString(parent, propertyName)
            : null;
}
