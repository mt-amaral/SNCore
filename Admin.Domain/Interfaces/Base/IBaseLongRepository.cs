namespace Admin.Domain.Interfaces.Base;

public interface IBaseLongRepository<T> where T : class
{
    Task<bool> SaveAllAsync();
    Task<T> SelectByPk(int id);
    Task<IEnumerable<T>> SelectAll();
    Task Create(T entity);
    Task Edit(T entity);
    Task Delete(T entity);
}
