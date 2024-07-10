using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;

namespace Admin.Persistence.Repositories
{
    public class TelnetRepository : BaseRepository<Telnet>, ITelnetRepository
    {
        public TelnetRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
