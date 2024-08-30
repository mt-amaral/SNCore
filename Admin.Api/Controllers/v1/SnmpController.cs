using Admin.Application.Interfaces;
using Admin.Shared.Base;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class SnmpController : BaseController<SnmpBase, SnmpRequest>
{
    private readonly ISnmpService _snmpService;

    public SnmpController(ISnmpService snmpService,
                            IValidator<SnmpBase> snmpBaseValidator,
                            IValidator<SnmpRequest> snmpRequestValidator)
        : base(snmpRequestValidator, snmpBaseValidator)
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
            ValidateInt(id);
            var snmp = await _snmpService.SelectByPk(id);
            return Ok(snmp);

        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            return BadRequest(new { Errors = errors });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(SnmpResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ExibirPorHardwareId")]
    public async Task<ActionResult> SelectByHardwareId(int id)
    {
        try
        {
            ValidateInt(id);
            var snmp = await _snmpService.SelectByHardwareId(id);
            return Ok(snmp);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            return BadRequest(new { Errors = errors });
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("CriarSnmp")]
    public async Task<ActionResult> CreateSnmp([FromQuery] int hardwareId, [FromBody] SnmpBase snmpNew)
    {
        try
        {
            ValidateInt(hardwareId);
            ValidationBase(snmpNew);
            await _snmpService.Create(hardwareId, snmpNew);
            return Created();
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            return BadRequest(new { Errors = errors });
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("EditarSnmp")]
    public async Task<ActionResult> EditSnmp([FromQuery] int id, [FromBody] SnmpBase snmpEdit)
    {
        try
        {
            ValidateInt(id);
            ValidationBase(snmpEdit);
            await _snmpService.Edit(id, snmpEdit);
            return NoContent();
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            return BadRequest(new { Errors = errors });
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
    public async Task<ActionResult> DeleteHardware(int id)
    {
        try
        {
            ValidateInt(id);
            await _snmpService.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
