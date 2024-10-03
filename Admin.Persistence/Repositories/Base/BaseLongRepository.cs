using Admin.Domain.Entities.Base;
using Admin.Domain.Interfaces.Base;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories.Base;

public class BaseLongRepository<T> : IBaseLongRepository<T> where T : BaseLongEntity
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseLongRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<T> SelectByPk(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new InvalidOperationException($"Não encontrado {typeof(T).Name} id:{id}");
    }

    public async Task<IEnumerable<T>> SelectAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Edit(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
