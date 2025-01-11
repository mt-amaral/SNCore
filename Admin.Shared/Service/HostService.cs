using Admin.Shared.Response;
using System.Net.Http.Json;

namespace Admin.Shared.Service;

public class HostService
{
    private readonly HttpClient _httpClient;

    public HostService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<IEnumerable<HostResponse>?> GetHostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<HostResponse>>("api/host/exibirtodos");
    }
}