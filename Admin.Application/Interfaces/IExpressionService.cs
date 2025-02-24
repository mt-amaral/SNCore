using Admin.Shared.Request;
using Admin.Shared.Response;

namespace Admin.Application.Interfaces;

public interface IExpressionService
{
    Task<IEnumerable<ExpressionResponse>> GetExpression();
    Task<string> CronExpressionTranslator(string? expression = null, DataExpressionRequest? expressionObj = null);
     Task CreatExpressions(DataExpressionRequest expression);
}
