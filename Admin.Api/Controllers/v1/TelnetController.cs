using Admin.Application.Interfaces;
using Admin.Shared.Payload;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class TelnetController : BaseController
{
    private readonly ITelnetService _telnetService;
    private readonly IValidator<TelnetPayload> _validatorPayload;
    public TelnetController(ITelnetService telnetService,
                            IValidator<TelnetPayload> telnetPayloadValidator)
    {
        _telnetService = telnetService;
        _validatorPayload = telnetPayloadValidator;
    }
    [HttpGet]
    [ProducesResponseType(typeof(TelnetPayload), StatusCodes.Status200OK)]
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
