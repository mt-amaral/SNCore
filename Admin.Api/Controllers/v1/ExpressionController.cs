using Admin.Application.Interfaces;
using Admin.Shared.Request;
using Admin.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers.v1;

public class ExpressionController : BaseController
{
    private readonly IExpressionService _expressionService;

    public ExpressionController(IExpressionService expressionService)
    {
        _expressionService = expressionService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ExpressionResponse>), StatusCodes.Status200OK)]
    [Route("GetAllExpressions")]
    public async Task<ActionResult> GetHostAllAsync()
    {
        try
        {
            var result = await _expressionService.GetExpression();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [Route("TranslationExpressions")]
    public async Task<ActionResult> TranslationExpressionsAsync(string expression)
    {
        try
        {
            var result = await _expressionService.CronExpressionTranslator(expression);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route("CreatExpressions")]
    public async Task<ActionResult> CreatExpressions(DataExpressionRequest expression)
    {
        try
        {
            
            await _expressionService.CreatExpressions(expression);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
