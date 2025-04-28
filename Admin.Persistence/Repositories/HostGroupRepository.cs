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
    
    
    public async Task CreateGroupHost(HostGroup entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAllAsync();
    }

    public async Task UpdateGroupHost(HostGroup entity)
    {
        _dbSet.Update(entity);
        await SaveAllAsync();
        
    }
    public async Task DeleteGroupHost(HostGroup entity)
    {
         _dbSet.Remove(entity);
        await SaveAllAsync();
    }
}
