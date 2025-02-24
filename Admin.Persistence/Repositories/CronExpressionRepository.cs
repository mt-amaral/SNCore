
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class CronExpressionRepository(ApplicationDbContext context) : ICronExpressionRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<CronExpression> _dbSet = context.Set<CronExpression>();


    public async Task<IEnumerable<CronExpression>> SelectAll()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task Create(CronExpression entity)
    {
        try
        {   
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
