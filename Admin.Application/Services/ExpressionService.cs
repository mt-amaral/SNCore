using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;
using CronExpressionDescriptor;

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



    public async Task CreatExpressions(DataExpressionRequest expression)
    {
        var entity = _mapper.Map<CronExpression>(expression);
        entity.UpdateDescription(await CronExpressionTranslator(null, expression)) ;
        await _repository.Create(entity);
    }
    
    
    public async Task<string> CronExpressionTranslator(string? expression = null, DataExpressionRequest? expressionObj = null)
    {
        if (expressionObj != null)
        {
            expression = $"{expressionObj.Second} {expressionObj.Minute}  {expressionObj.Hour}  {expressionObj.Day} {expressionObj.Month} {expressionObj.Weesday}";
        }
        var translation = ExpressionDescriptor.GetDescription(expression, new Options { Locale = "pt-BR" }) 
                          ?? "Expressão inválida";
        return await Task.FromResult(translation);
    }
}
