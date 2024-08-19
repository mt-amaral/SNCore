using ConnectionControl.Application.Dtos.Request;
using ConnectionControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConnectionSNMPController : Controller
{
    private readonly IConnectionSNMPService _hardwareService;

    public ConnectionSNMPController(IConnectionSNMPService hardwareService)
    {
        _hardwareService = hardwareService;
    }
    [HttpPost]
    [Route("SimplesSNMP")]
    public async Task<ActionResult> simpleSNMP(ConnectionSNMPDto ConnectionSNMP)
    {
        try
        {
            await _hardwareService.SimpleSNPM(ConnectionSNMP);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
