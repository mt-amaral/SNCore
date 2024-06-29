
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IHardwareRepositories
{

    Task<bool> SaveAllAsync();
    Task<Hardware> SelectByPk(int ?id);
    Task<IEnumerable<Hardware>> SelectAll();
    Task Create(Hardware hardware);
    Task Edit(Hardware hardware);
    Task Delete(Hardware hardware);
}
