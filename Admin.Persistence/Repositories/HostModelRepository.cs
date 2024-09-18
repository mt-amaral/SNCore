using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;

namespace Admin.Persistence.Repositories;

public class HostModelRepository : BaseRepository<HostModel>, IHostModelRepository
{
    private readonly ApplicationDbContext _context;
    public HostModelRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
