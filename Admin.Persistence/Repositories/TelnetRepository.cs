using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class TelnetRepository : BaseRepository<Telnet>, ITelnetRepository
{
    private readonly ApplicationDbContext _context;
    public TelnetRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Telnet> SelectByHostId(int id)
    {
        return await _dbSet.Where(x => x.HostId == id).FirstOrDefaultAsync() ?? throw new InvalidOperationException($"Não encontrado HostId:{id}");
    }
}
