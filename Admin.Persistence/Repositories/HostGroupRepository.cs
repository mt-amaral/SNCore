using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class HostGroupRepository : BaseRepository<HostGroup>, IHostGroupRepository
{
    private readonly ApplicationDbContext _context;
    public HostGroupRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
