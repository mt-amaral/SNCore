using Admin.Application.Interfaces;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Admin.Api.Controllers.v1;

public class ModelController : BaseController
{
    private readonly IHostModelService _hostModelService;

    public ModelController(IHostModelService hostModelService)
    {
        _hostModelService = hostModelService;
    }
    /// <summary>
    /// Modelos criados até o momento.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ModelResponse>), StatusCodes.Status200OK)]
    [Route("GetAll")]
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

    /// <summary>
    /// Modelos Para Inputs.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ModelInputResponse>), StatusCodes.Status200OK)]
    [Route("GetInputList")]
    public async Task<ActionResult> GetModelInputAsync()
    {
        try
        {
            var result = await _hostModelService.GetModelInput();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Consulta itens por modelId
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ItemModelResponse>), StatusCodes.Status200OK)]
    [Route("GetItensByModelId")]
    public async Task<ActionResult> GetModelAllAsync(
        [FromQuery]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "modelId deve ser maior que 0")]
        int modelId)
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

