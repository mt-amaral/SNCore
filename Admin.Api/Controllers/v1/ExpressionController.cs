using Admin.Application.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Admin.Api.Controllers.v1;

public class ExpressionController : BaseController
{
    private readonly IExpressionService _expressionService;

    public ExpressionController(IExpressionService expressionService)
    {
        _expressionService = expressionService;
    }
    /// <summary>
    /// Expressões cron criadas até o momento.
    /// </summary>
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
    /// <summary>
    /// Traduz as expressões cron.( pt -br )
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("TranslationExpressions")]
    public async Task<ActionResult> TranslationExpressions(CronExpressionRequest expression)
    {
        try
        {
            var result = await _expressionService.TranslationExpressions(expression);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Cria uma nova expressão cron com base nos dados fornecidos.
    /// </summary>
    /// <param name="expression">Objeto contendo as configurações da expressão cron.</param>
    /// <returns>Status 201 se criado com sucesso, ou 400 em caso de erro.</returns>
    /// <response code="201">Expressão criada com sucesso.</response>
    /// <response code="400">Erro na requisição ou dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("CreateExpressions")]
    public async Task<ActionResult> CreateExpressions(CreateExpressionRequest expression)
    {
        try
        {
            
            await _expressionService.CreateExpressions(expression);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza expressão cron com base nos dados fornecidos.
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("UpdateExpressions")]
    public async Task<ActionResult> UpdateExpressions( [FromBody] CreateExpressionRequest expression, [FromQuery] long expressionId)
    {
        try
        {
            await _expressionService.UpdateExpressions(expression, expressionId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Deleta expressão cron.
    /// </summary>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("UpdateExpressions")]
    public async Task<ActionResult> UpdateExpressions(
        [FromQuery]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "expressionId deve ser maior que 0")] 
        long expressionId){
        try
        {
            await _expressionService.DeleteExpressions(expressionId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
