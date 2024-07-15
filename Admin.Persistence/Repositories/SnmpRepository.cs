using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;

namespace Admin.Persistence.Repositories
{
    public class SnmpRepository : BaseRepository<Snmp>, ISnmpRepository
    {
        private readonly ApplicationDbContext _context;
        public SnmpRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public  Snmp? SelectByHardware(int id)
        {
            var snmp = _context.Snmp.Where(x => x.HardwareId == id);
            return snmp.Any() ? snmp.FirstOrDefault(): null;
        }
    }
}
