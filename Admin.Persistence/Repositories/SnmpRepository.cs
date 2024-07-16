using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories
{
    public class SnmpRepository : BaseRepository<Snmp>, ISnmpRepository
    {
        private readonly ApplicationDbContext _context;
        public SnmpRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Snmp> SelectByHardwareId(int? id)
        {
            var snmp = await _dbSet.Where(x => x.HardwareId == id).FirstOrDefaultAsync();
            return snmp == null ? throw new InvalidOperationException() : snmp;
                
        }
    }
}
