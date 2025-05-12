using Admin.App.Filter;
using Admin.Application.Interfaces;
using Admin.Shared.Request.Host;
using Microsoft.AspNetCore.Mvc;


namespace Admin.App.Controllers.v1;

public class HostController : BaseController
{
    private readonly IHostService _service;

    public HostController(IHostService service)
    {
        _service = service;
    }
    
    /// <summary>
    /// Pegar por Id
    /// </summary>
    [HttpGet]
    [Route("{id}")]
    [ValidateIdFilter]
    public async Task<ActionResult> GetHost(int id)
    {
        var result = await _service.GetHost(id);
        return StatusCode(result.IsSuccess ? 200 : 404, result);
    }
    
    /// <summary>
    /// Cria um novo Host
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> CreateHost(CreateHostRequest request)
    {
        var result = await _service.CreateHost(request);
        return StatusCode(result.IsSuccess ? 204 : 500, result);
    }
    
    /// <summary>
    /// Editar Host Existente
    /// </summary>
    [HttpPut]
    [Route("{id}")]
    [ValidateIdFilter]
    public async Task<ActionResult> EditHost(CreateHostRequest request, int id)
    {
        var result = await _service.UpdateHost(request, id);
        return StatusCode(result.IsSuccess ? 201 : 404, result);
    }
    
    /// <summary>
    /// Deletar por Id
    /// </summary>
    [HttpDelete]
    [Route("{id}")]
    [ValidateIdFilter]
    public async Task<ActionResult> DeleteHost(int id)
    {
        var result = await _service.DeleteHost(id);
        return StatusCode(result.IsSuccess ? 201 : 404, result);
    }
    
    /// <summary>
    /// Consultar por pagina
    /// </summary>
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult> GetListHost([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        var result = await _service.GetHostList(pageNumber,pageSize);
        return Ok(result);
    }
}
