using Admin.Application.Interfaces;
using Admin.Share.Request;
using Admin.Share.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SnmpController : Controller
{
    private readonly ISnmpService _snmpService;

    public SnmpController(ISnmpService snmpService)
    {
        _snmpService = snmpService;
    }
    [HttpGet]
    [ProducesResponseType(typeof(SnmpResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ExibirSnmpPorId")]
    public async Task<ActionResult> SelectByPk(int id)
    {
        try
        {
            var snmp = await _snmpService.SelectByPk(id);
            return Ok(snmp);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(SnmpResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ExibirPorHardwareId")]
    public async Task<ActionResult> SelectByHardwareId(int id)
    {
        try
        {
            var snmp = await _snmpService.SelectByHardwareId(id);
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
    [Route("CriarSnmp")]
    public async Task<ActionResult> CreateSnmp(SnmpRequest SnmpNew)
    {
        try
        {
            await _snmpService.Create(SnmpNew);
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
    [Route("EditarSnmp")]
    public async Task<ActionResult> EditSnmp(SnmpRequest snmpRequest)
    {
        try
        {
            await _snmpService.Edit(snmpRequest);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("DeleteSnmp")]
    public async Task<ActionResult> DeleteHardware(int snmpId)
    {
        try
        {
            await _snmpService.Delete(snmpId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
