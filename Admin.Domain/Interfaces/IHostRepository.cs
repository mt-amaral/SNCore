using System.Linq.Expressions;
using Admin.Domain.Entities;


namespace Admin.Domain.Interfaces;

public interface IHostRepository
{
    Task<Host?> SelectByHost(int id);
    Task<List<Host>> Query(
        Expression<Func<Host, bool>> filter);
    Task CreateHost(Host entity);
    Task UpdateHost(Host entity);
    Task DeleteHost(Host entity);
    Task UpdateRange(List<Host> entitys);
    Task<IEnumerable<Host?>> FilteredHost(
        int pageNumber = 1,
        int pageSize = 20);
}
