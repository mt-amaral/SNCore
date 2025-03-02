using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response.Expression;
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

        return _mapper.Map<List<ExpressionResponse>>(entity);
    }



    public async Task<ExpressionResponse> CreateExpressions(CreateExpressionRequest expression)
    {
        try
        {
            var entity = _mapper.Map<CronExpression>(expression);
            entity.UpdateDescription(await TranslationExpressions(expression.Expression));
            await _repository.Create(entity);
            return _mapper.Map<ExpressionResponse>(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex}");
        }
    }

    public async Task UpdateExpressions(CreateExpressionRequest expression, long expressionId)
    {
        try
        {
            var entity = await _repository.SelectById(expressionId);
            _mapper.Map(expression, entity);
            entity.UpdateDescription(await TranslationExpressions(expression.Expression));
            await _repository.Update(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex}");
        }
    }

    public async Task<string> TranslationExpressions(CronExpressionRequest expressionObj)
    {
        var expression = $"{expressionObj.Second} {expressionObj.Minute}  {expressionObj.Hour}  {expressionObj.Day} {expressionObj.Month} {expressionObj.Weesday}";
        var translation = ExpressionDescriptor.GetDescription(expression, new Options { Locale = "pt-BR" })
                          ?? "Expressão inválida";
        return await Task.FromResult(translation);
    }

    public async Task DeleteExpressions(long expressionId)
    {
        try
        {
            var entity = await _repository.SelectById(expressionId);
            if (entity == null)
                throw new Exception("Não encontrado");
            await _repository.Delete(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex}");
        }
    }
}
