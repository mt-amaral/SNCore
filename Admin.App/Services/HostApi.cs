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
        return await _httpClient.GetFromJsonAsync<IEnumerable<HostResponse>>("Host/ExibirTodos");
    }
    public async Task CreateHostAsync(HostRequest host)
    {
        var response = await _httpClient.PostAsJsonAsync("Host/CriarHost", host);
        response.EnsureSuccessStatusCode();
    }
    public async Task<HostResponse> GetHostId(int hostId)
    {
        return await _httpClient.GetFromJsonAsync<HostResponse>($"Host/ExibirHostPorId?id={hostId}");
    }
    public async Task EditHostAsync(int id, HostRequest host)
    {
        var response = await _httpClient.PutAsJsonAsync($"Host/EditarHost?id={id}", host);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteHostAsync(int hostId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"Host/DeleteHost/?hostId={hostId}");
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {
            throw new Exception("Erro request");
        }
    }
}
