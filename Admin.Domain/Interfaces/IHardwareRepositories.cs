
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IHardwareRepositories
{

    Task<bool> SaveAllAsync();
    Task<Hardware> SelectByPk(int ?id);
    Task<IEnumerable<Hardware>> SelectAll();
    Task Edit(Hardware hardware);
}
