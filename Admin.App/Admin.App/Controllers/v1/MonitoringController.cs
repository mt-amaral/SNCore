using System.Text.Json;
using Admin.Domain.Interfaces;
using Admin.Domain.Monitoring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.App.Controllers.v1;

public class MonitoringController: BaseController
{
    private readonly IMonitoringScale  _scale;
    public MonitoringController(IMonitoringScale scale)
    {
        _scale = scale;
    }

    [HttpPut]
    public async Task<IActionResult> WriteSensorDataAsync(Guid trackingKey)
    {
        var result = await _scale.GetByTrackingKeyAsync(trackingKey);
        return Ok(result);

    }
    
    [HttpPost]
    public async Task<IActionResult> InsertAsync(JsonDocument json)
    {
        var sensorData = new SensorData
        {
            Time = DateTimeOffset.UtcNow,
            TrackingKey = Guid.NewGuid(),
            Value = json,
        };
        
        await _scale.InsertAsync(sensorData);
        return Ok();

    }
    

    
}