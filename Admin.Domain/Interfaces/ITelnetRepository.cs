using Admin.Domain.Entities;


namespace Admin.Domain.Interfaces
{
    public interface ITelnetRepository : IBaseRepository<Telnet>
    {
        Task<Telnet> SelectByHardwareId(int id);
    }
}
