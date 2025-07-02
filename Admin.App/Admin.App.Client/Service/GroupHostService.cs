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
        var response = await _httpClient.PostAsJsonAsync("HostGroup", request);
        return await response.Content.ReadFromJsonAsync<Response<GroupHostResponse?>>()
               ?? new(null, 400, "Não foi possivel criar o grupo");
    }

    public async Task<Response<GroupHostResponse?>> UpdateHostGroup(CreateGroupHostRequest request, int id)
    {
        var response = await _httpClient.PutAsJsonAsync($"HostGroup/{id}", request);
        return await response.Content.ReadFromJsonAsync<Response<GroupHostResponse?>>()
               ?? new(null, 400, "Não foi possivel atualizar o grupo");
    }

    public async Task<Response<Dictionary<int, string>?>> GroupAddHostList(int idGroup, List<int> hostIds)
    {
        return await Task.FromResult(new Response<Dictionary<int, string>?>());
    }

    public async Task<Response<GroupHostResponse?>> DeleteHostGroup(List<int> ids)
    {
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, "HostGroup")
        {
            Content = JsonContent.Create(ids)
        });
        return await response.Content.ReadFromJsonAsync<Response<GroupHostResponse?>>()
            ?? new Response<GroupHostResponse?>(null, 400, "Não foi possivel deletar os grupos");
    }

    public async Task<Response<List<GroupHostResponse?>>> GetHostGroupList(GroupHostFilter filter)
    {
        var query = new Dictionary<string, string?>
        {
            { "name", filter.Name }
        };
        var queryString = string.Join("&", query
            .Where(kv => !string.IsNullOrEmpty(kv.Value))
            .Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value!)}"));

        return await _httpClient.GetFromJsonAsync<Response<List<GroupHostResponse?>>>($"HostGroup/list?{queryString}")
               ?? new Response<List<GroupHostResponse?>>(null, 400, "Não foi possível obter os grupos");
    }
}
