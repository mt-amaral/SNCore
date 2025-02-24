using Admin.Application.Interfaces;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
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
    [HttpGet]
    [ProducesResponseType(typeof(List<HostInputResponse>), StatusCodes.Status200OK)]
    [Route("ListarHost")]
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
}
