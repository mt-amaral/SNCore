using Admin.Shared.Response;
using System.Net.Http.Json;

namespace Admin.Shared.Service;

public class ExpressionService(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("Api");

    public async Task<List<ExpressionResponse>?> GetExpressionAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ExpressionResponse>>("api/expression/getAllExpressions");
    }
}