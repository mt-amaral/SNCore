
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class ItemRepository: BaseRepository<Item>, IItemRepository
{
    public ItemRepository(ApplicationDbContext context) : base(context)
    {
        
    }
    
    public async Task<IEnumerable<Item>> GetItemByModel(int modelId)
    {
        return await _dbSet
            .Where(x => x.ModelId == modelId)
            .Include(o => o.OidList)
            .ToListAsync();
    }
}
