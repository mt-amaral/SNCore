using System.Net.Http.Json;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
using Admin.Shared.Response.Expression;


namespace Admin.App.Client.Service;

public class ExpressionService : IExpressionService
{
    private readonly HttpClient _httpClient;
    public ExpressionService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<string> TranslationExpression(ExpressionRequest expression)
    {
        var response = await _httpClient.PutAsJsonAsync("Expression/Translation", expression);
        return await Task.FromResult("");
    }

    public async Task<Response<IEnumerable<GetExpressionResponse?>>> GetExpressions()
    { 
        return await _httpClient.GetFromJsonAsync<Response<IEnumerable<GetExpressionResponse?>>>("Expression/GetAll");
            
    }

    public async Task<Response<ExpressionResponse>> GetExpression(short id)
    {
        return await Task.FromResult(new Response<ExpressionResponse>());
    }

    public async  Task<Response<ExpressionResponse?>> CreateExpression(ExpressionRequest expression)
    {
        return await Task.FromResult(new Response<ExpressionResponse?>());
    }

    public async  Task<Response<string?>> UpdateExpression(ExpressionRequest expression, short id)
    {
        return await Task.FromResult(new Response<string?>());
    }

    public async  Task<Response<string?>> DeleteExpression(short id)
    {
        return await Task.FromResult(new Response<string?>());
    }

}