using Admin.App.Filter;
using Admin.Application.Interfaces;
using Admin.Shared.Request.Host;
using Microsoft.AspNetCore.Mvc;


namespace Admin.App.Controllers.v1;

public class HostController : BaseController
{
    private readonly IHostService _hostService;

    public HostController(IHostService service)
    {
        _hostService = service;
    }
    
    /// <summary>
    /// Cria um novo Host
    /// </summary>
    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateExpressions(CreateHostRequest request)
    {
        var result = await _hostService.CreateHost(request);
        return StatusCode(result.IsSuccess ? 201 : 500, result);
    }
    
    
    /// <summary>
    /// Editar Host Existente
    /// </summary>
    [HttpPut]
    [Route("Edit/{id}")]
    [ValidateIdFilter]
    public async Task<ActionResult> EditExpressions(CreateHostRequest request, int id)
    {
        var result = await _hostService.UpdateHost(request, id);
        return StatusCode(result.IsSuccess ? 201 : 500, result);
    }
}
