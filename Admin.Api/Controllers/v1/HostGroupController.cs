using Admin.Application.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

public class HostGroupController : BaseController
{
    private readonly IHostGroupService _hostGroupService;

    public HostGroupController(IHostGroupService hostGroupService)
    {
        _hostGroupService = hostGroupService;
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HostGroupPayload>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ExibirTodos")]
    public async Task<ActionResult<ICollection<HostGroupResponse>>> GetGroupHost()
    {
        try
        {
            var hostList = await _hostGroupService.SelectAll();
            return Ok(hostList);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
