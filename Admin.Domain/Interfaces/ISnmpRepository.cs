using Admin.Domain.Entities;
using Admin.Domain.Interfaces.Base;


namespace Admin.Domain.Interfaces
{
    public interface ISnmpRepository : IBaseRepository<Snmp>
    {
        Task<Snmp?> SelectByHardwareId(int id);
    }
}
