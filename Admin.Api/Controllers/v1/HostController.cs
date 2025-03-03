using Admin.Application.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Response.Host;
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

    /// <summary>
    /// Criar um novo Grupo de host
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("CreateGroup")]
    public async Task<ActionResult> CreateGroup(CreateGroupHostRequest newGroup)
    {
        try
        {
            await _hostservice.CreateGroupHost(newGroup);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza um novo Grupo de host
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("UpdateGroup")]
    public async Task<ActionResult> UpdateGroup(CreateGroupHostRequest group,
    [FromQuery]
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "groupId deve ser maior que 0")]
    int groupId)
    {
        try
        {
            await _hostservice.UpdateGroupHost(group, groupId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    /// <summary>
    /// Listar todos Grupos de Hosts em inputs - (Temporário)
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<GroupHostInputResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ListGroup")]
    public async Task<ActionResult> ListGroup()
    {
        try
        {
            var response = await _hostservice.GetInputGroupHost();
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Seleciona Grupos de Hosts específico - (Temporário)
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(GroupHostResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("GetGroupById")]
    public async Task<ActionResult> GetGroupById(
    [FromQuery]
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "groupId deve ser maior que 0")]
    int groupId)
    {
        try
        {
            var response = await _hostservice.GetGroupById(groupId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delear Grupo host por id
    /// </summary>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Route("DeleteGroupById")]
    public async Task<ActionResult> DeleteGroupById(
    [FromQuery]
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "groupId deve ser maior que 0")]
    int groupId)
    {
        try
        {
            await _hostservice.DeleteGroupById(groupId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
