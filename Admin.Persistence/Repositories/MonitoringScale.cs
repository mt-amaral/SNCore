using System.Text.Json;
using Admin.Domain.Interfaces;
using Admin.Domain.Monitoring;
using Dapper;
using Npgsql;


namespace Admin.Persistence.Repositories;

public class MonitoringScale: IMonitoringScale
{
    private readonly string _connectionString;

    public MonitoringScale(string connectionString)
    {

        _connectionString = connectionString;
    }

    public async Task<IEnumerable<SensorData?>> GetByTrackingKeyAsync(Guid trackingKey)
    {
        const string sql = @"SELECT ""Time"", ""TrackingKey"", ""Value""
                             FROM ""SensorData""";
        
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        
        var result = await connection.QueryAsync<SensorData>(@"
            SELECT ""Time"", ""TrackingKey"", ""Value""::text AS ValueJson
            FROM ""SensorData""
            WHERE ""TrackingKey"" = @trackingKey", new { trackingKey });
        
        return result;
        
    }
    
    public async Task InsertAsync(SensorData data)
    {
        const string sql = @"INSERT INTO ""SensorData"" (""Time"", ""TrackingKey"", ""Value"")
                     VALUES (@Time, @TrackingKey, @Value::jsonb)";

        await using var conn = new NpgsqlConnection(_connectionString);
        await conn.ExecuteAsync(sql, new
        {
            Time = data.Time,
            TrackingKey = data.TrackingKey,
            Value = data.Value.RootElement.GetRawText()
        });
    }

}
