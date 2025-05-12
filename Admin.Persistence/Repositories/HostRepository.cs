using System.Linq.Expressions;
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
    
    public  async Task<List<Host>> Query(  
        Expression<Func<Host, bool>> filter)  
    {  
        return await _dbSet  
            .Where(filter)
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
    public async Task UpdateRange(List<Host> entitys)
    {
        _dbSet.UpdateRange(entitys);
        await SaveAllAsync();
    }

    public async Task DeleteHost(Host entity)
    {
        _dbSet.Remove(entity);
        await SaveAllAsync();
    }

    public async Task<IEnumerable<Host?>> FilteredHost(
        int pageNumber = 1,
        int pageSize = 20)
    {
        return await _dbSet
            .Include(e => e.Snmp)
            .Include(e => e.Telnet)
            .Include(e => e.HostGroup)
            .Include(e => e.HostModel)
            .AsNoTracking()
            .OrderByDescending(x => x.Id) 
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize) 
            .ToListAsync();  
    }

}
