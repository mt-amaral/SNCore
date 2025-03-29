
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class CronExpressionRepository: ICronExpressionRepository
{
    
    
    private readonly ApplicationDbContext _context;
    private readonly DbSet<CronExpression> _dbSet;

    public CronExpressionRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<CronExpression>();
    }
    
    private async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<IEnumerable<CronExpression>> GetAll()
    {
        return await _dbSet
            .AsNoTracking().ToListAsync();
    }
    public async Task<CronExpression?> GetById(short id)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Create(CronExpression entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAllAsync();
    }

    public async Task Update(CronExpression entity)
    {
        _dbSet.Update(entity);
        await SaveAllAsync();
    }

    public async Task Delete (CronExpression entity)
    {
        _dbSet.Remove(entity);
        await SaveAllAsync();
    }
    
}
