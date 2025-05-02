using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IRunTimeRepository
{
    Task<RunTime?> GetById(Guid id);
    Task Create(RunTime entity);
    Task<List<RunTime>?> GetByHostId(long id);
    Task Update(RunTime entity);
    Task<IEnumerable<RunTime?>> GetActiveAsync(CancellationToken ct = default);
    
}