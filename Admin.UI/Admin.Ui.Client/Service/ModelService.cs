using System.Net.Http.Json;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using Admin.Shared.Response.Model;

namespace Admin.Ui.Client.Service;

public class ModelService(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("Api");

    public async Task<List<ModelResponse>?> GetModelsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ModelResponse>>("api/model/exibirtodos");
    }

    public async Task<List<ModelInputResponse>?> GetModelsInputAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ModelInputResponse>>("api/model/ExibirTodosInput");
    }

    public async Task<List<ItemModelResponse>?> GetItemsAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<List<ItemModelResponse>>($"api/model/exibiritems?modelId={id}");
    }
}