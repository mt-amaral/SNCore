using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories
{
    public class HardwareRepository : BaseRepository<Hardware>, IHardwareRepository
    {
        private readonly ApplicationDbContext _context;
        public HardwareRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public  async Task<Hardware> SelectByHardware(int id)
        {
            return await _dbSet
                .Include(e => e.Snmp)
                .Include(e => e.Telnet)
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new InvalidOperationException($"Não encontrado {typeof(Hardware).Name} id:{id}");
        }
    }
}
