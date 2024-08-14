using Admin.Application.Interfaces;
using Admin.Shared.Request;
using Admin.Shared.Response;
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
    [ProducesResponseType(typeof(TelnetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
            return NotFound(ex.Message);
        }
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("EditarTelnet")]
    public async Task<ActionResult> EditSnmp(TelnetRequest telnetRequest, [FromQuery] int Id)
    {
        try
        {
            await _telnetService.Edit(Id, telnetRequest);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
