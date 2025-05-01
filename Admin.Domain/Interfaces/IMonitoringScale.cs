using System.Text.Json;
using Admin.Domain.Monitoring;

namespace Admin.Domain.Interfaces;

public interface IMonitoringScale
{
    Task<IEnumerable<SensorData?>> GetByTrackingKeyAsync(Guid trackingKey);
    Task InsertAsync(SensorData data);
}
