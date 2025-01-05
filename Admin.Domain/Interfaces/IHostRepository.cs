using Admin.Domain.Entities;


namespace Admin.Domain.Interfaces;

public interface IHostRepository
{
    Task<Host> SelectByHost(int id);
    Task<List<Host>> SelectByGroup();
}
