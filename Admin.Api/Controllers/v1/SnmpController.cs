using Admin.Application.Interfaces;
using Admin.Shared.Payload;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

[ApiController]
[Route("[controller]")]
public class SnmpController : BaseController
{
    private readonly ISnmpService _snmpService;
    private readonly IValidator<SnmpPayload> _validatorPayload;
    public SnmpController(ISnmpService snmpService,
                            IValidator<SnmpPayload> snmpPayloadValidator)
    {
        _snmpService = snmpService;
        _validatorPayload = snmpPayloadValidator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SnmpPayload), StatusCodes.Status200OK)]
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
}
