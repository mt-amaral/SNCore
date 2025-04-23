using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
using Admin.Shared.Response.Expression;

namespace Admin.Application.Interfaces;

public interface IExpressionService
{
    Task<string> TranslationExpression(ExpressionRequest expression);
    Task<Response<IEnumerable<GetExpressionResponse?>>> GetExpressions();
    Task<Response<ExpressionResponse>> GetExpression(short id);
    Task<Response<ExpressionResponse?>> CreateExpression(ExpressionRequest expression);
    Task<Response<string?>> UpdateExpression(ExpressionRequest expression, short id);
    Task<Response<string?>> DeleteExpression(short id);
}
