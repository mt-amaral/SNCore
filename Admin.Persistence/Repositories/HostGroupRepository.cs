using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class HostGroupRepository: BaseRepository<HostGroup>,  IHostGroupRepository
{
    public HostGroupRepository(ApplicationDbContext context) : base(context)
    {
            
    }

    public async Task<HostGroup> GetGroupById(int groupId)
    {
       return await _dbSet.Include(h => h.Hosts).FirstOrDefaultAsync(g => g.Id == groupId)
            ?? throw new InvalidOperationException($"Não encontrado {typeof(HostGroup).Name} id:{groupId}");
    }

    public async Task<List<HostGroup>> GetInput()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }
   
    public async Task CreateGroupHost(HostGroup hostGroup)
    {
        await Create(hostGroup);
    }

    public async Task UpdateGroupHost(HostGroup hostGroup)
    {
        await Update(hostGroup);
    }
    public async Task DeleteGroupHost(HostGroup hostGroup)
    {
        await Delete(hostGroup);
    }
    

}
