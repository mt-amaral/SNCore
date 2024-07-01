using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;

namespace Admin.Persistence.Repositories
{
    public class SnmpRepository : RepositoryBase<Snmp>, ISnmpRepository
    {
        public SnmpRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
