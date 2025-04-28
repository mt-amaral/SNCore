
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;

using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Item> _dbSet;
    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<Item>();

    }

    public async Task<IEnumerable<Item>> GetItemByModel(int modelId)
    {
        return await _dbSet
            .Where(x => x.ModelId == modelId)
            .Include(o => o.OidList)
            .ToListAsync();
    }
}
