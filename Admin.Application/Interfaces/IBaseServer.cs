using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.Application.Interfaces;
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> SelectAll();
    Task<TEntity> SelectByPk(int id);
    Task Create(TEntity entity);
    Task Edit(TEntity entity);
    Task Delete(TEntity entity);
    Task<bool> SaveAllAsync();
}