using Admin.Shared.Request.Expression;
using Admin.Shared.Response.Expression;

namespace Admin.Application.Interfaces;

public interface IExpressionService
{
    Task<IEnumerable<ExpressionResponse>> GetExpression();
    Task<string> TranslationExpressions(CronExpressionRequest expressionObj);
    Task CreateExpressions(CreateExpressionRequest expression);
    Task UpdateExpressions(CreateExpressionRequest expression, long expressionId);
    Task DeleteExpressions(long expressionId);
}
