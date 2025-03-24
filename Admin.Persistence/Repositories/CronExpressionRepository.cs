
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class CronExpressionRepository: BaseRepository<CronExpression>, ICronExpressionRepository
{
    public CronExpressionRepository(ApplicationDbContext context) : base(context)
    {
        
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

    public async Task CreateCronExpression(CronExpression entity)
    {
        await Create(entity);
    }

    public async Task UpdateCronExpression(CronExpression entity)
    {
        await Update(entity);
    }

    public async Task DeleteCronExpression (CronExpression entity)
    {
        await Delete(entity);
    }
}
