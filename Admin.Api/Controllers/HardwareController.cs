
using Admin.Application.Interfaces;
using Admin.Shared.Base;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HardwareController : Controller
{
    private readonly IValidator<HardwareRequest> _validator;
    private readonly IValidator<HardwareBase> _validatorBase;
    private readonly IHardwareService _hardwareService;

    public HardwareController(IHardwareService hardwareService,
        IValidator<HardwareRequest> validator,
        IValidator<HardwareBase> validatorBase)
    {
        _hardwareService = hardwareService;
        _validator = validator;
        _validatorBase = validatorBase;
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
        var validationResult = await _validatorBase.ValidateAsync(hardwareNew);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            return BadRequest(new { Errors = errors });
        }

        try
        {
            await _hardwareService.Create(hardwareNew);
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("EditarHardware")]
    public async Task<ActionResult> EditHardware(HardwareBase hardwareEdit, [FromQuery] int Id)
    {
        var validationResult = await _validatorBase.ValidateAsync(hardwareEdit);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        try
        {
            await _hardwareService.Edit(Id, hardwareEdit);
            return NoContent();
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
