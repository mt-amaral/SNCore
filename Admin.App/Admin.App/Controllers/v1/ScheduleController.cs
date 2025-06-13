using Admin.App.Filter;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Request.Host;
using Admin.Shared.Request.Schedule;
using Admin.Shared.Response;
using Admin.Shared.Response.Expression;
using Admin.Shared.Response.Host;
using Microsoft.AspNetCore.Mvc;


namespace Admin.App.Controllers.v1;

public class ScheduleController : BaseController
{
    private readonly IRunTimeService _service;

    public ScheduleController(IRunTimeService service)
    {
        _service = service;
    }
    
    /// <summary>
    /// Criar nova rotina
    /// </summary>
    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(typeof(Response<string?>), StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateExpressions(CreateScheduleRequest schedule)
    {
        var result = await _service.Create(schedule);
        return StatusCode(result.IsSuccess ? 201 : 400, result);
    }
    
    /// <summary>
    /// Define status da rotina
    /// </summary>
    [HttpPatch]
    [Route("ScheduleStatus")]
    [ProducesResponseType(typeof(Response<string?>), StatusCodes.Status200OK)]
    public async Task<ActionResult> ScheduleStatus(Guid id,bool status = false)
    {
        var result = await _service.ScheduleStatus(id, status);
        return StatusCode(result.IsSuccess ? 201 : 404, result);
    }
    
}
