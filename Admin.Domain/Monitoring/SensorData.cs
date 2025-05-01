using System.Text.Json;
using System.Text.Json.Serialization;

namespace Admin.Domain.Monitoring;

public class SensorData
{
    public DateTimeOffset Time { get; set; }
    [JsonIgnore]
    public Guid TrackingKey { get; set; }
    public JsonDocument Value { get; set; }

}