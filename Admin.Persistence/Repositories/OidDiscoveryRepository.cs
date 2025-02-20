using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class OidDiscoveryRepository(ApplicationDbContext context) : IOidDiscoveryRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<OidDiscovery> _dbSet = context.Set<OidDiscovery>();



}