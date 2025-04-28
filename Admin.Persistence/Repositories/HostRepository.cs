using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Admin.Persistence.Repositories;

public class HostRepository : IHostRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Host> _dbSet;
    
    public HostRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Host>();

    }
    private async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Host?> SelectByHost(int id)
    {
        return await _dbSet
            .Include(e => e.Snmp)
            .Include(e => e.Telnet)
            .FirstOrDefaultAsync(e => e.Id == id);

    }

    public async Task<List<Host>> SelectAll()
    {
        return await _dbSet
            .Include(e => e.HostGroup).AsNoTracking()
            .ToListAsync();
    }
    public async Task CreateHost(Host entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAllAsync();
    }

    public async Task UpdateHost(Host entity)
    {
        _dbSet.Update(entity);
        await SaveAllAsync();
    }

    public async Task DeleteHost(Host entity)
    {
        _dbSet.Remove(entity);
        await SaveAllAsync();
    }

}
