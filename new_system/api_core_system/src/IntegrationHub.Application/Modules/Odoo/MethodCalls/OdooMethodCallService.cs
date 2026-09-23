using System.Text.Json;
using System.Text.RegularExpressions;
using IntegrationHub.Application.Abstractions;

namespace IntegrationHub.Application.Modules.Odoo.MethodCalls;

public sealed partial class OdooMethodCallService(IOdooGatewayClient gatewayClient)
{
    private const int MaximumRecordIds = 1000;

    public async Task<OdooMethodCallResult> CallAsync(
        OdooMethodCall command,
        CancellationToken cancellationToken)
    {
        var normalized = ValidateAndNormalize(command);
        var result = await gatewayClient.CallAsync(normalized, cancellationToken);

        return new OdooMethodCallResult(
            true,
            normalized.Model,
            normalized.Method,
            normalized.UserId,
            result);
    }

    private static OdooMethodCall ValidateAndNormalize(OdooMethodCall command)
    {
        var model = NormalizeModelName(command.Model);
        var method = command.Method?.Trim() ?? string.Empty;

        if (!ModelNamePattern().IsMatch(model))
        {
            throw new OdooMethodCallValidationException(
                "model must be a valid Odoo technical model name, for example iwmn.r81dmbl.");
        }

        if (!MethodNamePattern().IsMatch(method) || method.StartsWith('_'))
        {
            throw new OdooMethodCallValidationException(
                "method must be a public Odoo method name.");
        }

        if (command.UserId <= 0)
        {
            throw new OdooMethodCallValidationException("userId must be greater than zero.");
        }

        if (command.RecordIds is { Count: > MaximumRecordIds } ||
            command.RecordIds?.Any(id => id <= 0) == true)
        {
            throw new OdooMethodCallValidationException(
                $"recordIds must contain at most {MaximumRecordIds} positive IDs.");
        }

        ValidateJsonKind(command.Vals, "vals", JsonValueKind.Object, JsonValueKind.Array);
        ValidateJsonKind(command.Args, "args", JsonValueKind.Array);
        ValidateJsonKind(command.Kwargs, "kwargs", JsonValueKind.Object);
        ValidateJsonKind(command.Context, "context", JsonValueKind.Object);

        if (command.Vals.HasValue && command.Args.HasValue)
        {
            throw new OdooMethodCallValidationException(
                "vals and args cannot be supplied together; put positional values in args for a custom method.");
        }

        return command with { Model = model, Method = method };
    }

    private static string NormalizeModelName(string? value)
    {
        var model = value?.Trim() ?? string.Empty;
        if (!model.Contains('.') && model.StartsWith("iwmn_", StringComparison.OrdinalIgnoreCase))
        {
            model = $"iwmn.{model[5..]}";
        }

        return model.ToLowerInvariant();
    }

    private static void ValidateJsonKind(
        JsonElement? value,
        string propertyName,
        params JsonValueKind[] allowedKinds)
    {
        if (!value.HasValue || value.Value.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
        {
            return;
        }

        if (!allowedKinds.Contains(value.Value.ValueKind))
        {
            throw new OdooMethodCallValidationException(
                $"{propertyName} has an invalid JSON type.");
        }
    }

    [GeneratedRegex("^[a-z][a-z0-9_.]*[a-z0-9]$", RegexOptions.CultureInvariant)]
    private static partial Regex ModelNamePattern();

    [GeneratedRegex("^[A-Za-z][A-Za-z0-9_]*$", RegexOptions.CultureInvariant)]
    private static partial Regex MethodNamePattern();
}
