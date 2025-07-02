using Admin.App.Filter;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Response;
using Admin.Shared.Response.Host;
using Microsoft.AspNetCore.Mvc;


namespace Admin.App.Controllers.v1;

public class HostGroupController : BaseController
{
    private readonly IGroupHostService _service;

    public HostGroupController(IGroupHostService service)
    {
        _service = service;
    }
    
    
    /// <summary>
    /// Cria um novo Grupo
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> CreateGroup(CreateGroupHostRequest request)
    {
        var result = await _service.CreateHostGroup(request);
        return StatusCode(201, result);
    }
    /// <summary>
    /// Editar Host Existente
    /// </summary>
    [HttpPut]
    [Route("{id}")]
    [ValidateIdFilter]
    public async Task<ActionResult> EditGroup(CreateGroupHostRequest request, int id)
    {
        var result = await _service.UpdateHostGroup(request, id);
        return StatusCode(result.IsSuccess ? 201 : 404, result);
    }
    
    /// <summary>
    /// Adiciona lista de host host ao grupo
    /// </summary>
    [HttpPatch]
    [Route("GroupAddHost")]
    public async Task<ActionResult> GroupAddHostList(int idGroup, List<int> hostIds)
    {
        var result = await _service.GroupAddHostList(idGroup, hostIds);
        return StatusCode(result.IsSuccess ? 201 : 404, result);
    }
    
    /// <summary>
    /// Deletar por Lista de Ids
    /// </summary>
    [HttpDelete]
    public async Task<ActionResult> DeleteGroup([FromBody] List<int> idList)
    {
        var result = await _service.DeleteHostGroup(idList);
        return StatusCode(result.IsSuccess ? 201 : 404, result);
    }
    
    /// <summary>
    /// Consultar grupos de host com filtros
    /// </summary>
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult> GetListGroup([FromQuery] GroupHostFilter filter)
    {
        var result = await _service.GetHostGroupList(filter);
        return Ok(result);
    }
    
}
