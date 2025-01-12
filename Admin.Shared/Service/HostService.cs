using Admin.Shared.Response;
using System.Net.Http.Json;

namespace Admin.Shared.Service;

public class HostService(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("Api");

    public async Task<List<HostResponse>?> GetHostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<HostResponse>>("api/host/exibirtodos");
    }
}