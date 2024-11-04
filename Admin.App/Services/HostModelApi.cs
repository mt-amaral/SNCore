using Admin.Shared.Response;
using System.Net.Http.Json;

namespace Admin.App.Services;

public class HostModelApi
{
    private readonly HttpClient _httpClient;

    public HostModelApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<IEnumerable<ItemByModelResponse>?> GetModelGroupAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ItemByModelResponse>>("api/HostModel/ExibirTodos");
    }  
}