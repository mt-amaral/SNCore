using Admin.Domain.Entities;
using Admin.Domain.Interfaces.Base;


namespace Admin.Domain.Interfaces
{
    public interface IHardwareRepository : IBaseRepository<Hardware>
    {
        Task<Hardware> SelectByHardware(int id);
    }
}
