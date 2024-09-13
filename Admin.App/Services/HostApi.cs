using Admin.Shared.Request;
using Admin.Shared.Response;
using System.Net.Http.Json;

namespace Admin.App.Services;
public class HostApi
{
    private readonly HttpClient _httpClient;

    public HostApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<IEnumerable<HostResponse>?> GetHostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<HostResponse>>("api/host/exibirtodos");
    }
    public async Task CreateHostAsync(HostRequest host)
    {
        var response = await _httpClient.PostAsJsonAsync("api/host/criarHost", host);
        response.EnsureSuccessStatusCode();
    }
    public async Task<HostResponse> GetHostId(int hostId)
    {
        return await _httpClient.GetFromJsonAsync<HostResponse>($"Api/host/exibirhostporid?id={hostId}");
    }
    public async Task EditHostAsync(int id, HostRequest host)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/host/editarhost?id={id}", host);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteHostAsync(int hostId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"host/deleteHost/?hostId={hostId}");
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {
            throw new Exception("Erro request");
        }
    }
}
