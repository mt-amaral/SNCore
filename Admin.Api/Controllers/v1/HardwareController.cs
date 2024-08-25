using Admin.Application.Interfaces;
using Admin.Shared.Base;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc; 

namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class HardwareController : BaseController<HardwareBase, HardwareRequest>
{
    private readonly IHardwareService _hardwareService;
    private readonly IValidator<SnmpBase> _snmpValidator;

    public HardwareController(IHardwareService hardwareService,
                              IValidator<HardwareRequest> hardwareRequestValidator,
                              IValidator<HardwareBase> hardwareBaseValidator,
                              IValidator<SnmpBase> snmpValidator)
        : base(hardwareRequestValidator, hardwareBaseValidator)
    {
        _hardwareService = hardwareService;
        _snmpValidator = snmpValidator;
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ExibirHardwarePorId")]
    public async Task<ActionResult> SelectHardware(int id)
    {
        try
        {
            var hardware = await _hardwareService.SelectByPk(id);
            return Ok(hardware);

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
    public async Task<ActionResult> CreateHardware(HardwareBase hardwareNew)
    {
        try
        {
            ValidationBase(hardwareNew);
            if(hardwareNew.Snmp != null)
            {
                var validationResult = _snmpValidator.Validate(hardwareNew.Snmp);
                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
            }
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("EditarHardware")]
    public async Task<ActionResult> EditHardware([FromQuery] int Id, [FromBody] HardwareBase hardwareEdit)
    {
        try
        {
            ValidationBase(hardwareEdit);
            await _hardwareService.Edit(Id, hardwareEdit);
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
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("EditPartialHardware")]
    public async Task<ActionResult> EditPartialHardware([FromQuery] int Id, [FromBody] JsonPatchDocument<HardwareBase> hardwareEdit)
    {
        try
        {
            // Validation admin.Application
            await _hardwareService.EditPartial(Id, hardwareEdit);
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("DeleteHardware")]
    public async Task<ActionResult> DeleteHardware(int hardwareId)
    {
        try
        {
            await _hardwareService.Delete(hardwareId);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
