using Admin.Shared.Request.Expression;
using Admin.Shared.Response.Expression;
using System.Net.Http.Json;

namespace Admin.Shared.Service;

public class ExpressionService(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("Api");

    public async Task<List<ExpressionResponse>?> GetExpressionAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ExpressionResponse>>("api/expression/getAllExpressions");
    }

    public async Task<string?> GetTranslationAsync(string expression)
    {
        return await _httpClient.GetFromJsonAsync<string>($"api/expression/TranslationExpressions?expression={expression}");
    }
    public async Task CreateExpressionAsync(ExpressionRequest expressionRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("api/expression/CreatExpressions", expressionRequest);
        response.EnsureSuccessStatusCode();
    }
}