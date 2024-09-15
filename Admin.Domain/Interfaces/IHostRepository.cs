using Admin.Domain.Entities;
using Admin.Domain.Interfaces.Base;


namespace Admin.Domain.Interfaces;

public interface IHostRepository : IBaseRepository<Host>
{
    Task<Host> SelectByHost(int id);
    Task<IEnumerable<Host>> SelectByGroup();
}
