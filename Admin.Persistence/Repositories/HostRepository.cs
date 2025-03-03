using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Admin.Persistence.Repositories;

public class HostRepository : BaseRepository<Host>, IHostRepository
{

    public HostRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<Host> SelectByHost(int id)
    {
        return  await _dbSet
              .Include(e => e.Snmp)
              .Include(e => e.Telnet)
              .FirstOrDefaultAsync(e => e.Id == id) ??
            throw new InvalidOperationException($"Não encontrado {nameof(Host)} id:{id}");

    }
    public async Task<List<Host>> SelectByGroup()
    {
        return await _dbSet
            .Include(e => e.HostGroup)
            .ToListAsync();
    }

    public async Task<List<Host>> SelectAll()
    {
        return await _dbSet
            .Include(e => e.HostGroup).AsNoTracking()
            .ToListAsync();
    }
    public async Task CreateNewHost(Host newEntity)
    {
        await Create(newEntity);
    }

    public async Task UpdateHost(Host entity)
    {
        await Edit(entity);
    }

    public async Task DeleteHost(Host entity)
    {
        await Delete(entity);
    }
}
