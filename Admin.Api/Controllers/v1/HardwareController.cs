using Admin.Application.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class HardwareController : BaseController
{
    private readonly IHardwareService _hardwareService;
    private readonly IValidator<HardwarePayload> _validatorPayload;
    private readonly IValidator<HardwareRequest> _validatorRequest;
    public HardwareController(IHardwareService hardwareService,
                              IValidator<HardwareRequest> hardwareRequestValidator,
                              IValidator<HardwarePayload> HardwarePayloadValidator)
    {
        _hardwareService = hardwareService;
        _validatorRequest = hardwareRequestValidator;
        _validatorPayload = HardwarePayloadValidator;
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
    public async Task<ActionResult> CreateHardware([FromBody] HardwarePayload hardwareNew)
    {
        try
        {
            ValidateEntity(hardwareNew, _validatorPayload);
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
    public async Task<ActionResult> EditHardware([FromQuery] int id, [FromBody] HardwarePayload hardwareEdit)
    {
        try
        {
            ValidateInt(id);
            ValidateEntity(hardwareEdit, _validatorPayload);
            await _hardwareService.Edit(id, hardwareEdit);
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
    public async Task<ActionResult> EditPartialHardware([FromQuery] int id, [FromBody] JsonPatchDocument<HardwarePayload> hardwareEdit)
    {
        try
        {
            // Validation admin.Application
            ValidateInt(id);
            await _hardwareService.EditPartial(id, hardwareEdit);
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
