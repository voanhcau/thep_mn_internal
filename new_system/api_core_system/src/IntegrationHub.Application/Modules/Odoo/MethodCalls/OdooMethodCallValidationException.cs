namespace IntegrationHub.Application.Modules.Odoo.MethodCalls;

public sealed class OdooMethodCallValidationException(string message)
    : Exception(message);
