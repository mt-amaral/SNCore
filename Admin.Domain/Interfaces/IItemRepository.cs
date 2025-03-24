using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItemByModel(int modelId);
}
