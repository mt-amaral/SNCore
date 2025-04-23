
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories.Base;

public class BaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAllAsync();
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await SaveAllAsync();
    }
    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        await SaveAllAsync();
    }
}