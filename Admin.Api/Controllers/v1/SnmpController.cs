using Admin.Application.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class SnmpController : BaseController
{
    private readonly ISnmpService _snmpService;
    private readonly IValidator<SnmpPayload> _validatorPayload;
    private readonly IValidator<SnmpRequest> _validatorRequest;
    public SnmpController(ISnmpService snmpService,
                            IValidator<SnmpPayload> snmpPayloadValidator,
                            IValidator<SnmpRequest> snmpRequestValidator)
    {
        _snmpService = snmpService;
        _validatorPayload = snmpPayloadValidator;
        _validatorRequest = snmpRequestValidator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SnmpResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ExibirSnmpPorId")]
    public async Task<ActionResult> SelectByPk([FromQuery] int id)
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
            return NotFound(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(SnmpResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ExibirPorHardwareId")]
    public async Task<ActionResult> SelectByHardwareId([FromQuery] int id)
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
    public async Task<ActionResult> CreateSnmp([FromQuery] int hardwareId, [FromBody] SnmpPayload snmpNew)
    {
        try
        {
            ValidateInt(hardwareId);
            ValidateEntity(snmpNew, _validatorPayload);
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("EditarSnmp")]
    public async Task<ActionResult> EditSnmp([FromQuery] int id, [FromBody] SnmpPayload snmpEdit)
    {
        try
        {
            ValidateInt(id);
            ValidateEntity(snmpEdit, _validatorPayload);
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
            return NotFound(ex.Message);
        }
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("DeleteSnmp")]
    public async Task<ActionResult> DeleteHardware([FromQuery] int id)
    {
        try
        {
            ValidateInt(id);
            await _snmpService.Delete(id);
            return Ok();
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
}
