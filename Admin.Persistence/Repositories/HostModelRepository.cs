using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Admin.Persistence.Repositories;

public class HostModelRepository : BaseRepository<HostModel>, IHostModelRepository
{
    private readonly ApplicationDbContext _context;
    public HostModelRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
