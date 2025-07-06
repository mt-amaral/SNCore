
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class RunTimeRepository : IRunTimeRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<RunTime> _dbSet;

    public RunTimeRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<RunTime>();
    }

    private async Task<bool> SaveAllAsync()
    {    
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<RunTime?>> GetActiveAsync(CancellationToken ct = default)
    {
        return await _dbSet.Where(c => c.Active == true)
            .Include(e => e.CronExpression)
            .Include(e => e.Host)
            .Include(e => e.Item)
            .AsNoTracking().ToListAsync(ct).ContinueWith(t => (IEnumerable<RunTime>)t.Result, ct);
    }
    
    public async Task<RunTime?> GetById(Guid id)
    {
        return await _dbSet
            .Include(e => e.CronExpression)
            .Include(e => e.Host)
            .Include(e => e.Item)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<List<RunTime>?> GetByHostId(long id)
    {
        return await _dbSet.Where(c => c.HostId == id)
            .ToListAsync();
    }

    public async Task Create(RunTime entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAllAsync();
    }
    public async Task Update(RunTime entity)
    {
        _dbSet.Update(entity);
        await SaveAllAsync();

    }

}
