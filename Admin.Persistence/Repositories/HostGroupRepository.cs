using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class HostGroupRepository : IHostGroupRepository
{
    
    private readonly ApplicationDbContext _context;
    private readonly DbSet<HostGroup> _dbSet;
    public HostGroupRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<HostGroup>();

    }
    private async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    
    public async Task CreateGroup(HostGroup entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAllAsync();
    }

    public async Task UpdateGroup(HostGroup entity)
    {
        _dbSet.Update(entity);
        await SaveAllAsync();
        
    }
    public async Task DeleteGroup(HostGroup entity)
    {
         _dbSet.Remove(entity);
        await SaveAllAsync();
    }
    
    public async Task<HostGroup?> SelectByGrup(int id)
    {
        return await _dbSet
            .Include(e => e.Hosts)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<HostGroup?>> FilteredGroup(
        int pageNumber = 1,
        int pageSize = 20)
    {
        return await _dbSet
            .Include(e => e.Hosts)
            .AsNoTracking()
            .OrderByDescending(x => x.Id) 
            .Skip((pageNumber - 1) * pageSize) 
            .Take(pageSize) 
            .ToListAsync();  
    }
    
}
