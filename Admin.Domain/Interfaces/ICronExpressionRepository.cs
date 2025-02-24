
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface ICronExpressionRepository
{
    Task<IEnumerable<CronExpression>> SelectAll();
    Task Create(CronExpression entity);
}
