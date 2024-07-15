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
            var de = _context.Snmp.Where(x => x.HardwareId == id);
            if (de.Any())
            {
                return de.FirstOrDefault();
            }
            return null;
        }
    }
}
