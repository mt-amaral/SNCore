using Admin.Application.Interfaces;
using Admin.Application.Services;
using Admin.Shared.Payload;
using Admin.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

public class HostModelController : BaseController
{
    private readonly IHostModelService _hostModelService;

    public HostModelController(IHostModelService hostModelService)
    {
        _hostModelService = hostModelService;
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HostModelPayload>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ExibirTodos")]
    public async Task<ActionResult<ICollection<HostModelPayload>>> GetGroupHost()
    {
        try
        {
            var hostList = await _hostModelService.SelectAll();
            return Ok(hostList);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ItemByModelResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("ExibirItemModel")]
    public async Task<ActionResult<ICollection<ItemByModelResponse>>> GetItemByModel(int modelId)
    {
        try
        {
            var hostList = await _hostModelService.GetItemByModel(modelId);
            return Ok(hostList);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
