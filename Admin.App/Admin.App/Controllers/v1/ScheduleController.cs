using Admin.App.Filter;
using Admin.Application.Interfaces;
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
    /// Cria uma nova rotina
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Response<string?>), StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateExpressions(CreateScheduleRequest schedule)
    {

        var result = await _service.Create(schedule);
        return StatusCode(result.IsSuccess ? 201 : 400, result);

    }
    
}
