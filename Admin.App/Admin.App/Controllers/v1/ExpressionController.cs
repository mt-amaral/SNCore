using Admin.Api.Controllers;
using Admin.App.Filter;
using Admin.Application.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
using Admin.Shared.Response.Expression;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.App.Controllers.v1;

public class ExpressionController : BaseController
{
    private readonly IExpressionService _expressionService;

    public ExpressionController(IExpressionService expressionService)
    {
        _expressionService = expressionService;
    }
    
    /// <summary>
    /// Expressões cron  criadas até o momento.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Response<List<GetExpressionResponse>>), StatusCodes.Status200OK)]
    [Route("GetAll")]
    [AllowAnonymous]
    public async Task<ActionResult> GetAll()
    {
        
            var result = await _expressionService.GetExpressions();

            return Ok(result);

    }
    /// <summary>
    /// seleciona expression pelo Id até o.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Response<ExpressionResponse>), StatusCodes.Status200OK)]
    [Route("GetById/{id}")]
    [ValidateIdFilter]
    public async Task<ActionResult> GetById(short id)
    {
        var result = await _expressionService.GetExpression(id);
        return StatusCode(result.IsSuccess ? 200 : 404, result);
    }
    /// <summary>
    /// Traduz as expressões cron.( pt -br )
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(Response<string?>), StatusCodes.Status200OK)]
    [Route("Translation")]
    public async Task<ActionResult> Translation(ExpressionRequest expression)
    {
        string? expressionStr = await _expressionService.TranslationExpression(expression);
        var result = new Response<string?>(
            expressionStr,
            200,
            null
        );
        return Ok(result);
    }

    /// <summary>
    /// Cria uma nova expressão cron com base nos dados forneci dos.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Response<ExpressionResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateExpressions(ExpressionRequest expression)
    {

        var result = await _expressionService.CreateExpression(expression);
        return StatusCode(result.IsSuccess ? 201 : 500, result);

    }

    /// <summary>
    /// Atualiza expressão cron com base nos dados fornecidos.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Response<string?>),StatusCodes.Status200OK)]
    [ValidateIdFilter]
    public async Task<ActionResult> Update([FromBody] ExpressionRequest expression,  short id)
    {

        var result = await _expressionService.UpdateExpression(expression, id);
        return StatusCode(result.IsSuccess ? 200 : 404, result);
        
    }
    /// <summary>
    /// Deleta expressão cron.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Response<string?>), StatusCodes.Status200OK)]
    [ValidateIdFilter]
    public async Task<ActionResult> Delete(short id)
    {
           var result =  await _expressionService.DeleteExpression(id);
           return StatusCode(result.IsSuccess ? 200 : 404, result);
    }
}
