
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface ICronExpressionRepository
{
    Task<IEnumerable<CronExpression>> GetAll();
    Task<CronExpression?> GetById(short id);
    Task CreateCronExpression(CronExpression entity);
    Task Update(CronExpression entity);
    Task Delete(CronExpression entity);
}
