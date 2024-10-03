
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;

namespace Admin.Persistence.Repositories;

public class OidListRepository : BaseLongRepository<OidList>, IOidListRepository
{
    private readonly ApplicationDbContext _context;
    public OidListRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
