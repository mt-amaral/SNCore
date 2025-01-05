using Admin.Application.Interfaces;
using Admin.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

public class HostController : BaseController
{
    private readonly IHostService _hostservice;

    public HostController(IHostService hostservice)
    {
        _hostservice = hostservice;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<HostResponse>), StatusCodes.Status200OK)]
    [Route("ExibirTodos")]
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
}
