using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Admin.Persistence.Repositories;

public class HostModelRepository : IHostModelRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<HostModel> _dbSet;
    
    public HostModelRepository(ApplicationDbContext context) 
    {
        _context = context;
        _dbSet = _context.Set<HostModel>();
    }
    public async Task<List<HostModel>> SelectAll()
    {
        return await _dbSet.ToListAsync();
    }
    
}
