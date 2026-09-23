using System.Data;
using Dapper;
using IntegrationHub.Application.Abstractions;
using IntegrationHub.Application.Modules.MasterData.Sync;
using IntegrationHub.Domain.MasterData;
using Microsoft.Extensions.Options;

namespace IntegrationHub.Infrastructure.LegacySqlServer.MasterData;

internal sealed class MasterDataSyncReadRepository(
    ILegacyDbConnectionFactory connectionFactory,
    IOptions<LegacyDatabaseOptions> options) : IMasterDataSyncReadRepository
{
    private const string SchemaName = "dbo";
    private readonly int _commandTimeout = options.Value.CommandTimeoutSeconds;

    public async Task<MasterDataSyncPage> GetPageAsync(
        GetMasterDataSyncPageQuery query,
        CancellationToken cancellationToken)
    {
        // The entity was checked against MasterDataEntityCatalog before reaching this layer.
        // It is therefore safe to derive the legacy table name and quote it as an identifier.
        var entity = query.Entity!;
        var tableName = entity.ToUpperInvariant();

        await using var connection = await connectionFactory.OpenConnectionAsync(cancellationToken);
        var keyColumns = (await connection.QueryAsync<string>(new CommandDefinition(
            """
            SELECT column_info.name
            FROM sys.tables AS table_info
            INNER JOIN sys.schemas AS schema_info
                ON schema_info.schema_id = table_info.schema_id
            INNER JOIN sys.indexes AS index_info
                ON index_info.object_id = table_info.object_id
               AND index_info.is_primary_key = 1
            INNER JOIN sys.index_columns AS index_column
                ON index_column.object_id = index_info.object_id
               AND index_column.index_id = index_info.index_id
            INNER JOIN sys.columns AS column_info
                ON column_info.object_id = index_column.object_id
               AND column_info.column_id = index_column.column_id
            WHERE schema_info.name = @SchemaName
              AND table_info.name = @TableName
            ORDER BY index_column.key_ordinal;
            """,
            new { SchemaName, TableName = tableName },
            commandTimeout: _commandTimeout,
            cancellationToken: cancellationToken))).AsList();

        if (keyColumns.Count == 0)
        {
            throw new InvalidOperationException(
                $"Master-data table {SchemaName}.{tableName} does not exist or has no primary key.");
        }

        var orderBy = string.Join(", ", keyColumns.Select(QuoteIdentifier));
        var sql = $"""
            SELECT *
            FROM {QuoteIdentifier(SchemaName)}.{QuoteIdentifier(tableName)}
            ORDER BY {orderBy}
            OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY;
            """;

        var offset = checked((query.Page - 1) * query.PageSize);
        var rows = (await connection.QueryAsync(new CommandDefinition(
            sql,
            new { Offset = offset, Fetch = query.PageSize + 1 },
            commandTimeout: _commandTimeout,
            cancellationToken: cancellationToken))).AsList();

        var hasMore = rows.Count > query.PageSize;
        var data = rows
            .Take(query.PageSize)
            .Select(ToDictionary)
            .ToArray();

        return new MasterDataSyncPage(
            entity,
            keyColumns.Select(column => column.ToLowerInvariant()).ToArray(),
            query.Page,
            query.PageSize,
            hasMore,
            data);
    }

    private static IReadOnlyDictionary<string, object?> ToDictionary(dynamic row)
    {
        var source = (IDictionary<string, object>)row;
        return source.ToDictionary(
            pair => pair.Key.ToLowerInvariant(),
            pair => pair.Value is DBNull ? null : pair.Value,
            StringComparer.Ordinal);
    }

    private static string QuoteIdentifier(string identifier) =>
        $"[{identifier.Replace("]", "]]", StringComparison.Ordinal)}]";
}
