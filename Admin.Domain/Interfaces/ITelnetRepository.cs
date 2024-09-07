using Admin.Domain.Entities;
using Admin.Domain.Interfaces.Base;


namespace Admin.Domain.Interfaces
{
    public interface ITelnetRepository : IBaseRepository<Telnet>
    {
        Task<Telnet> SelectByHardwareId(int id);
    }
}
