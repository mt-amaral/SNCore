using Admin.Shared.Response;

namespace Admin.Application.Interfaces;

public interface IExpressionService
{
    Task<IEnumerable<ExpressionResponse>> GetExpression();
}
