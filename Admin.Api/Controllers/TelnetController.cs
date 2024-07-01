using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Share.Request;
using Admin.Share.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TelnetController : Controller
{
    private readonly ITelnetService _telnetService;

    public TelnetController(ITelnetService telnetService)
    {
        _telnetService = telnetService;
    }
    [HttpGet]
    [Route("ExibirTelnetPorId")]
    public async Task<ActionResult> SelectSnmp(int id)
    {
        try
        {
            var snmp = await _telnetService.SelectByPk(id);
            return Ok(snmp);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("CriarTelnet")]
    public async Task<ActionResult> CreateSnmp(TelnetRequest TelnetNew)
    {
        try
        {
            await _telnetService.Create(TelnetNew);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    [Route("EditarTelnet")]
    public async Task<ActionResult> EditSnmp(TelnetRequest telnetRequest)
    {
        try
        {
            await _telnetService.Edit(telnetRequest);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("DeleteTelnet")]
    public async Task<ActionResult> DeleteHardware(int telnetId)
    {
        try
        {
            await _telnetService.Delete(telnetId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
