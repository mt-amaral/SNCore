using Admin.Shared.Payload;
using System.Net.Http.Json;

namespace Admin.App.Services;
public class SnmpApi
{
    private readonly HttpClient _httpClient;

    public SnmpApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }
    public async Task<SnmpPayload?> SelectByHost(int hostId)
    {
        var snmp = await _httpClient.GetAsync($"/Snmp/ExibirPorHostId?id={hostId}");
        return snmp.IsSuccessStatusCode
            ? await snmp.Content.ReadFromJsonAsync<SnmpPayload>() : null;
    }
}
