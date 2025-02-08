using Admin.Application.Interfaces;
using Admin.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

public class ModelController : BaseController
{
    private readonly  IHostModelService _hostModelService;

    public ModelController(IHostModelService hostModelService)
    {
        _hostModelService = hostModelService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ModelResponse>), StatusCodes.Status200OK)]
    [Route("ExibirTodos")]
    public async Task<ActionResult> GetModelAllAsync()
    {
        try
        {
            var result = await _hostModelService.GetModel();


            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ItemModelResponse>), StatusCodes.Status200OK)]
    [Route("ExibirItems")]
    public async Task<ActionResult> GetModelAllAsync(int modelId)
    {
        try
        {
            var result = await _hostModelService.GetItem(modelId);


            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}

