
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface ICronExpressionRepository
{
    Task<IEnumerable<CronExpression>> SelectAll();
    Task<CronExpression> SelectById(long id);
    Task Create(CronExpression entity);
    Task Update(CronExpression entity);
    Task Delete(CronExpression entity);
}
