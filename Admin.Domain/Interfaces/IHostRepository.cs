using Admin.Domain.Entities;


namespace Admin.Domain.Interfaces;

public interface IHostRepository
{
    Task<Host> SelectByHost(int id);
    Task<List<Host>> SelectByGroup();
    Task<List<Host>> SelectAll();
    Task CreateNewHost(Host newEntity);
    Task UpdateHost(Host entity);
    Task DeleteHost(Host entity);

}
