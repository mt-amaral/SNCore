using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Services;

public class ExpressionService : IExpressionService
{
    private readonly ICronExpressionRepository _repository;

    private readonly IMapper _mapper;
    public ExpressionService(ICronExpressionRepository repository,
        IMapper mapper)
    {

        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExpressionResponse>> GetExpression()
    {
        var entity = await _repository.SelectAll();

          return  _mapper.Map<List<ExpressionResponse>>(entity);
    }
}
