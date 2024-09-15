using Admin.Shared.Request;
using Admin.Shared.Response;
using System.Net.Http.Json;

namespace Admin.App.Services;
public class HostGroupApi
{
    private readonly HttpClient _httpClient;

    public HostGroupApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<IEnumerable<HostGroupResponse>?> GetHostsGroupAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<HostGroupResponse>>("api/hostGroup/exibirtodos");
    }
}
