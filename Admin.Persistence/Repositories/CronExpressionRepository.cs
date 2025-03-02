
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
        return await _dbSet
            .Include(e => e.Host)
            .Include(e => e.Item)
            .AsNoTracking().ToListAsync();
    }
    public async Task<CronExpression> SelectById(long id)
    {
        return await _dbSet
        .Include(e => e.Host)
        .Include(e => e.Item)
        .FirstOrDefaultAsync(c => c.Id == id) ?? 
        throw new Exception("Não encontrado");
    }

    public async Task Create(CronExpression entity)
    {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
    }

    public async Task Update(CronExpression entity)
    {
         _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(CronExpression entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

    }
}
