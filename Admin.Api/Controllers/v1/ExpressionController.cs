using Admin.Application.Interfaces;
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
}
