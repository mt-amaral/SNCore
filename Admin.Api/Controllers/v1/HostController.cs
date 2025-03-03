using Admin.Application.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Admin.Api.Controllers.v1;

public class HostController : BaseController
{
    private readonly IHostService _hostservice;

    public HostController(IHostService hostservice)
    {
        _hostservice = hostservice;
    }

    /// <summary>
    /// Listar todos Hosts - (tela inicial host)
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<HostResponse>), StatusCodes.Status200OK)]
    [Route("GetAll")]
    public async Task<ActionResult> GetHostAllAsync()
    {
        try
        {
            var result = await _hostservice.GetHosts();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Listar todos Hosts em inputs - (Temporário)
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<HostInputResponse>), StatusCodes.Status200OK)]
    [Route("GetInputList")]
    public async Task<ActionResult> GetHostListInput()
    {
        try
        {
            var result = await _hostservice.GetInput();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Selecionar Hosts por id
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(HostResponse), StatusCodes.Status200OK)]
    [Route("GetById")]
    public async Task<ActionResult> GetById([FromQuery] int hostId)
    {
        try
        {
            var response = await _hostservice.GetById(hostId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Criar um novo host
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("Create")]
    public async Task<ActionResult> Create(CreateHostRequest newHost)
    {
        try
        {
             await _hostservice.CreateHost(newHost);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Atualizar host
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("Update")]
    public async Task<ActionResult> Update(CreateHostRequest host, 
        [FromQuery]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "hostId deve ser maior que 0")]
        int hostId)
    {
        try
        {
            await _hostservice.UpdateHost(host, hostId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Delear host por id
    /// </summary>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Route("DeleteById")]
    public async Task<ActionResult> DeleteById(
    [FromQuery]
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "hostId deve ser maior que 0")]
    int hostId)
    {
        try
        {
             await _hostservice.DeletetById(hostId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
