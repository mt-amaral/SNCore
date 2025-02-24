using Admin.Shared.Response;
using System.Net.Http.Json;
using Admin.Shared.Request;

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
    public async Task CreateExpressionAsync(DataExpressionRequest expressionRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("api/expression/CreatExpressions", expressionRequest);
        response.EnsureSuccessStatusCode();
    }
}