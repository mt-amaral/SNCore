using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
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

    public async Task<Response<IEnumerable<GetExpressionResponse?>>> GetExpressions()
    {
        var entity = await _repository.GetAll();

        var list = _mapper.Map<List<GetExpressionResponse>>(entity);
        return new Response<IEnumerable<GetExpressionResponse?>>(list, 200, null);
    }

    public async Task<Response<ExpressionResponse>> GetExpression(short id)
    {
        var entity = await _repository.GetById(id);

        if (entity is null)
            return new Response<ExpressionResponse>(null, 404, $"Expressão com ID {id} não encontrada.");

        return new Response<ExpressionResponse>(_mapper.Map<ExpressionResponse>(entity), 200);
    }



    public async Task<Response<ExpressionResponse?>> CreateExpression(ExpressionRequest expression)
    {
        try
        {
            var entity = _mapper.Map<CronExpression>(expression);
            entity.UpdateDescription(await TranslationExpression(expression));
            await _repository.Create(entity);
            return new Response<ExpressionResponse?>(_mapper.Map<ExpressionResponse>(entity), 201, "Criado com sucesso");
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possivel criar a expressão ");
        }
    }


    public async Task<Response<string?>> UpdateExpression(ExpressionRequest expression, short id)
    {
        try
        {
            var entity = await _repository.GetById(id);

            if (entity is null)
                return new Response<string?>(null, 404, $"Expressão com ID {id} não encontrada.");

            _mapper.Map(expression, entity);
            entity.UpdateDescription(await TranslationExpression(expression));
            await _repository.Update(entity);
            return new Response<string?>(null, 200, "Atualizado com sucesso");

        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possivel atualizar a expressão ID {id}");
        }
    }

    public async Task<string> TranslationExpression(ExpressionRequest expression)
    {
        try
        {
            var expressionStr = $"{expression.Second} {expression.Minute}  {expression.Hour}  {expression.Day} {expression.Month} {expression.Weesday}";
            var translation = ExpressionDescriptor.GetDescription(expressionStr, new Options { Locale = "pt-BR" });
            return await Task.FromResult(translation);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao traduzir expressão");
        }
    }

    public async Task<Response<string?>> DeleteExpression(short id)
    {
        try
        {
            var entity = await _repository.GetById(id);
            if (entity is null)
                return new Response<string?>(null, 404, $"Expressão com ID {id} não encontrada.");

            await _repository.Delete(entity);
            return new Response<string?>(null, 200, "Deletado com sucesso");
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possivel excluir Expressão ID {id}");
        }
    }
}
