using Admin.Domain.Entities.Base;

namespace Admin.Domain.Interfaces.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<bool> SaveAllAsync();
    Task<T> SelectById(int id);
    Task<IEnumerable<T>> SelectAll();
    Task<IEnumerable<T>> SelectAllNoTrack();
    Task Create(T entity);
    Task Edit(T entity);
    Task Delete(T entity);

}
