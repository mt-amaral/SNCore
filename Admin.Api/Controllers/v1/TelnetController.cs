using Admin.Application.Interfaces;
using Admin.Application.Services;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class TelnetController : BaseController
{
    private readonly ITelnetService _telnetService;
    private readonly IValidator<TelnetPayload> _validatorPayload;
    private readonly IValidator<TelnetRequest> _validatorRequest;
    public TelnetController(ITelnetService telnetService,
                            IValidator<TelnetPayload> telnetPayloadValidator,
                            IValidator<TelnetRequest> TelnetResponseValidator)
    {
        _telnetService = telnetService;
        _validatorPayload = telnetPayloadValidator;
        _validatorRequest = TelnetResponseValidator;
    }
    [HttpGet]
    [ProducesResponseType(typeof(TelnetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ExibirTelnetPorId")]
    public async Task<ActionResult> SelectSnmp([FromQuery] int id)
    {
        try
        {
            ValidateInt(id);
            var snmp = await _telnetService.SelectByPk(id);
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
    [Route("CriarTelnet")]
    public async Task<ActionResult> CreateSnmp([FromQuery] int hardwareId, [FromBody] TelnetPayload TelnetNew)
    {
        try
        {
            ValidateInt(hardwareId);
            ValidateEntity(TelnetNew, _validatorPayload);
            await _telnetService.Create(hardwareId, TelnetNew);
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
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("EditarTelnet")]
    public async Task<ActionResult> EditSnmp([FromQuery] int id, [FromBody] TelnetPayload telnetEdit)
    {
        try
        {
            ValidateInt(id);
            ValidateEntity(telnetEdit, _validatorPayload);
            await _telnetService.Edit(id, telnetEdit);
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
    [Route("DeleteTelnet")]
    public async Task<ActionResult> DeleteHardware([FromQuery] int id)
    {
        try
        {
            ValidateInt(id);
            await _telnetService.Delete(id);
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
            var telnet = await _telnetService.SelectByHardwareId(id);
            return Ok(telnet);
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
