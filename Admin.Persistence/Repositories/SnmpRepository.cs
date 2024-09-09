using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class SnmpRepository : BaseRepository<Snmp>, ISnmpRepository
{
    private readonly ApplicationDbContext _context;
    public SnmpRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Snmp> SelectByHostId(int id)
    {
        return await _dbSet.Where(x => x.HostId == id).FirstOrDefaultAsync() ?? throw new InvalidOperationException($"Não encontrado HostId:{id}");
    }
}
