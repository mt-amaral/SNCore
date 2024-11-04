using Admin.Domain.Entities;
using Admin.Domain.Interfaces.Base;

namespace Admin.Domain.Interfaces;

public interface IItemRepository: IBaseRepository<Item>
{
    Task<IEnumerable<Item>> GetItemByModel(int modelId);
}
