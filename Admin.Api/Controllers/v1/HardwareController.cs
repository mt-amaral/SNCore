using Admin.Application.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class HardwareController : BaseController
{
    private readonly IHardwareService _hardwareService;
    private readonly IValidator<HardwarePayload> _validatorPayload;
    private readonly IValidator<HardwareRequest> _validatorRequest;
    private readonly IValidator<SnmpPayload> _validatorSnmp;
    private readonly IValidator<TelnetPayload> _validatorTelnet;
    public HardwareController(IHardwareService hardwareService,
                              IValidator<HardwareRequest> hardwareRequestValidator,
                              IValidator<HardwarePayload> HardwarePayloadValidator,
                              IValidator<SnmpPayload> validatorSnmp,
                              IValidator<TelnetPayload> validatorTelnet)
    {
        _hardwareService = hardwareService;
        _validatorRequest = hardwareRequestValidator;
        _validatorPayload = HardwarePayloadValidator;
        _validatorSnmp = validatorSnmp;
        _validatorTelnet = validatorTelnet;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HardwareResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ExibirTodos")]
    public async Task<ActionResult<IEnumerable<HardwareResponse>>> GetHardware()
    {
        try
        {
            var hardwareList = await _hardwareService.SelectAll();
            return Ok(hardwareList);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(HardwareResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ExibirHardwarePorId")]
    public async Task<ActionResult> SelectHardware([FromQuery] int id)
    {
        try
        {
            ValidateInt(id);
            var hardware = await _hardwareService.SelectByPk(id);
            return Ok(hardware);
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [Route("CriarHardware")]
    public async Task<ActionResult> CreateHardware([FromBody] HardwareRequest hardwareNew)
    {
        try
        {
            ValidateEntity(hardwareNew, _validatorPayload);
            if (hardwareNew.Snmp != null)
                ValidateEntity(hardwareNew.Snmp, _validatorSnmp);
            if (hardwareNew.Telnet != null)
                ValidateEntity(hardwareNew.Telnet, _validatorTelnet);

            await _hardwareService.Create(hardwareNew);
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [Route("EditarHardware")]
    public async Task<ActionResult> EditHardware([FromQuery] int id, [FromBody] HardwareRequest hardwareNew)
    {
        try
        {
            ValidateInt(id);
            ValidateEntity(hardwareNew, _validatorPayload);
            if (hardwareNew.Snmp != null)
                ValidateEntity(hardwareNew.Snmp, _validatorSnmp);
            if (hardwareNew.Telnet != null)
                ValidateEntity(hardwareNew.Telnet, _validatorTelnet);

            await _hardwareService.Edit(id, hardwareNew);
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
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("DeleteHardware")]
    public async Task<ActionResult> DeleteHardware([FromQuery] int hardwareId)
    {
        try
        {
            ValidateInt(hardwareId);
            await _hardwareService.Delete(hardwareId);
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
}
