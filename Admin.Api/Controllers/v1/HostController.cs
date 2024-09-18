using Admin.Application.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

public class HostController : BaseController
{
    private readonly IHostService _hostService;
    private readonly IValidator<HostPayload> _validatorPayload;
    private readonly IValidator<HostRequest> _validatorRequest;
    private readonly IValidator<SnmpPayload> _validatorSnmp;
    private readonly IValidator<TelnetPayload> _validatorTelnet;
    public HostController(IHostService hostService,
                              IValidator<HostRequest> hostRequestValidator,
                              IValidator<HostPayload> HostPayloadValidator,
                              IValidator<SnmpPayload> validatorSnmp,
                              IValidator<TelnetPayload> validatorTelnet)
    {
        _hostService = hostService;
        _validatorRequest = hostRequestValidator;
        _validatorPayload = HostPayloadValidator;
        _validatorSnmp = validatorSnmp;
        _validatorTelnet = validatorTelnet;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HostResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ExibirTodos")]
    public async Task<ActionResult<IEnumerable<HostResponse>>> GetHost()
    {
        try
        {
            var hostList = await _hostService.SelectAll();
            return Ok(hostList);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(HostResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("ExibirHostPorId")]
    public async Task<ActionResult> SelectHost([FromQuery] int id)
    {
        try
        {
            ValidateInt(id);
            var host = await _hostService.SelectByPk(id);
            return Ok(host);
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
    [Route("CriarHost")]
    public async Task<ActionResult> CreateHost([FromBody] HostRequest hostNew)
    {
        try
        {
            ValidateEntity(hostNew, _validatorPayload);
            if (hostNew.Snmp != null)
                ValidateEntity(hostNew.Snmp, _validatorSnmp);
            if (hostNew.Telnet != null)
                ValidateEntity(hostNew.Telnet, _validatorTelnet);

            await _hostService.Create(hostNew);
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
    [Route("EditarHost")]
    public async Task<ActionResult> EditHost([FromQuery] int id, [FromBody] HostRequest hostNew)
    {
        try
        {
            ValidateInt(id);
            ValidateEntity(hostNew, _validatorPayload);
            if (hostNew.Snmp != null)
                ValidateEntity(hostNew.Snmp, _validatorSnmp);
            if (hostNew.Telnet != null)
                ValidateEntity(hostNew.Telnet, _validatorTelnet);

            await _hostService.Edit(id, hostNew);
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
    [Route("DeleteHost")]
    public async Task<ActionResult> DeleteHost([FromQuery] int hostId)
    {
        try
        {
            ValidateInt(hostId);
            await _hostService.Delete(hostId);
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
