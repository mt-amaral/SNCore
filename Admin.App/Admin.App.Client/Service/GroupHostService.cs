using System.Net.Http.Json;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Response;
using Admin.Shared.Response.Host;

namespace Admin.App.Client.Service;

public class GroupHostService : IGroupHostService
{

    private readonly HttpClient _httpClient;
    public GroupHostService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<Response<GroupHostResponse?>> CreateHostGroup(CreateGroupHostRequest request)
    {
        return await Task.FromResult(new Response<GroupHostResponse?>());
    }

    public async Task<Response<GroupHostResponse?>> UpdateHostGroup(CreateGroupHostRequest request, int id)
    {
        return await Task.FromResult(new Response<GroupHostResponse?>());
    }

    public async Task<Response<Dictionary<int, string>?>> GroupAddHostList(int idGroup, List<int> hostIds)
    {
        return await Task.FromResult(new Response<Dictionary<int, string>?>());
    }

    public async Task<Response<GroupHostResponse?>> DeleteHostGroup(int id)
    {
        return await Task.FromResult(new Response<GroupHostResponse?>());
    }

    public Task<Response<List<GroupHostResponse?>>> GetHostGroupList(int pageNumber = 1, int pageSize = 20)
    {
        return  _httpClient.GetFromJsonAsync<Response<List<GroupHostResponse?>>>($"HostGroup/list?pageNumber={pageNumber}&pageSize={pageSize}")!;
    }
}
