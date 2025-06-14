using System.Net.Http.Json;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Response;
using Admin.Shared.Response.Host;

namespace Admin.App.Client.Service;

public class HostService : IHostService
{

    private readonly HttpClient _httpClient;
    public HostService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<Response<HostResponse?>> CreateHost(CreateHostRequest request)
    {
        return await Task.FromResult(new Response<HostResponse?>());
    }

    public async Task<Response<HostResponse?>> UpdateHost(CreateHostRequest request, int id)
    {
        return await Task.FromResult(new Response<HostResponse?>());
    }

    public async Task<Response<HostResponse?>> DeleteHost(int id)
    {
        return await Task.FromResult(new Response<HostResponse?>());
    }

    public async Task<Response<HostResponse?>> GetHost(int id)
    {
        return await Task.FromResult(new Response<HostResponse?>());
    }

    public Task<Response<List<HostResponse?>>> GetHostList(int pageNumber = 1, int pageSize = 20)
    {
            return  _httpClient.GetFromJsonAsync<Response<List<HostResponse?>>>($"Host/list?pageNumber={pageNumber}&pageSize={pageSize}")!;
    }
}
