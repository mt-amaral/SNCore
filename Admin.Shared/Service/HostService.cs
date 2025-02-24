using Admin.Shared.Response;
using System.Net.Http.Json;
using Admin.Shared.Response.Input;

namespace Admin.Shared.Service;

public class HostService(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("Api");

    public async Task<List<HostResponse>?> GetHostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<HostResponse>>("api/host/exibirtodos");
    }
    
    public async Task<List<HostInputResponse>?> GetHostsListAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<HostInputResponse>>("api/host/listarHost");
        
    }
}