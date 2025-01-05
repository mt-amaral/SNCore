using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;

namespace Admin.Persistence.Repositories;

public class TelnetRepository : BaseRepository<Telnet>, ITelnetRepository
{
    public TelnetRepository(ApplicationDbContext context) : base(context)
    {

    }
}
