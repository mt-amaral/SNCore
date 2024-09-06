using Admin.Domain.Entities;


namespace Admin.Domain.Interfaces
{
    public interface ISnmpRepository : IBaseRepository<Snmp>
    {
        Task<Snmp?> SelectByHardwareId(int id);
    }
}
