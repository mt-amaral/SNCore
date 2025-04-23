using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;


namespace Admin.Persistence.Repositories;

public class HostModelRepository : BaseRepository<HostModel>, IHostModelRepository
{
    public HostModelRepository(ApplicationDbContext context) : base(context)
    {

    }
    public async Task<List<HostModel>> SelectAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<HostModel>> GetInput()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }
}
