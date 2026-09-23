using IntegrationHub.Application.Abstractions;
using IntegrationHub.Infrastructure.LegacySqlServer;
using IntegrationHub.Infrastructure.LegacySqlServer.Finance;
using IntegrationHub.Infrastructure.LegacySqlServer.MasterData;
using IntegrationHub.Infrastructure.LegacySqlServer.Orders;
using IntegrationHub.Infrastructure.Odoo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<LegacyDatabaseOptions>()
            .Bind(configuration.GetSection(LegacyDatabaseOptions.SectionName))
            .Validate(options => !string.IsNullOrWhiteSpace(options.ConnectionString),
                "LegacyDatabase:ConnectionString is required.")
            .Validate(options => options.CommandTimeoutSeconds is >= 1 and <= 300,
                "CommandTimeoutSeconds must be between 1 and 300.")
            .ValidateOnStart();

        services.AddSingleton<ILegacyDbConnectionFactory, SqlServerConnectionFactory>();
        services.AddScoped<IBilletBaremReadRepository, BilletBaremReadRepository>();
        services.AddScoped<ICreditLimitReadRepository, CreditLimitReadRepository>();
        services.AddScoped<IAggregateCreditLimitReadRepository, AggregateCreditLimitReadRepository>();
        services.AddScoped<ICreditLimitDetailReadRepository, CreditLimitDetailReadRepository>();
        services.AddScoped<IMasterDataSyncReadRepository, MasterDataSyncReadRepository>();
        services.AddScoped<IBarWeightReadRepository, BarWeightReadRepository>();
        services.AddScoped<ICustomerOrderWriteRepository, CustomerOrderWriteRepository>();
        services.AddScoped<IDriverVehicleLookupRepository, DriverVehicleLookupRepository>();
        services.AddOptions<OdooOptions>()
            .Bind(configuration.GetSection(OdooOptions.SectionName))
            .Validate(options => !options.Enabled ||
                (Uri.TryCreate(options.BaseUrl, UriKind.Absolute, out var uri) &&
                 (uri.Scheme == Uri.UriSchemeHttps ||
                  (uri.Scheme == Uri.UriSchemeHttp && uri.IsLoopback))),
                "Odoo:BaseUrl must be an absolute HTTPS URL (HTTP is allowed only for loopback).")
            .Validate(options => !options.Enabled || !string.IsNullOrWhiteSpace(options.ApiKey),
                "Odoo:ApiKey is required when the Odoo connection is enabled.")
            .Validate(options => options.TimeoutSeconds is >= 1 and <= 300,
                "Odoo:TimeoutSeconds must be between 1 and 300.")
            .ValidateOnStart();
        services.AddHttpClient<IOdooGatewayClient, OdooGatewayClient>((serviceProvider, client) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<OdooOptions>>().Value;
            if (Uri.TryCreate(options.BaseUrl.TrimEnd('/') + "/", UriKind.Absolute, out var baseAddress))
            {
                client.BaseAddress = baseAddress;
            }

            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        });
        services.AddHealthChecks()
            .AddCheck<LegacySqlServerHealthCheck>("legacy-sql-server", tags: ["ready"]);

        return services;
    }
}
