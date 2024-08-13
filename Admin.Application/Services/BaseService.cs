using AutoMapper;
using Admin.Domain.Interfaces;

public abstract class BaseService<TEntity, TRequest, TResponse, TRepository>
    where TEntity : class
    where TRequest : class
    where TResponse : class
    where TRepository : IBaseRepository<TEntity>
{
    protected readonly TRepository _repository;
    protected readonly IMapper _mapper;

    protected BaseService(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TResponse>> SelectAll()
    {
        var entityList = await _repository.SelectAll();
        return _mapper.Map<IEnumerable<TResponse>>(entityList);
    }

    public virtual async Task<TResponse> SelectByPk(int id)
    {
        var entity = await _repository.SelectByPk(id);
        return _mapper.Map<TResponse>(entity);
    }

    public virtual async Task Create(TRequest request)
    {
        var entity = _mapper.Map<TEntity>(request);
        await _repository.Create(entity);
    }

    public virtual async Task Edit(TRequest request)
    {
        var entity = _mapper.Map<TEntity>(request);
        await _repository.Edit(entity);
    }

    public virtual async Task Delete(int id)
    {
        var entity = await _repository.SelectByPk(id);
        if (entity != null)
            await _repository.Delete(entity);

    }
}
