
using Admin.Shared.Payload;
using System.Net.Http.Json;

namespace Admin.App.Services;
public class TelnetApi
{
    private readonly HttpClient _httpClient;

    public TelnetApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }
    public async Task<TelnetPayload?> SelectByHost(int hostId)
    {
        var snmp = await _httpClient.GetAsync($"api/telnet/exibirporhostId?id={hostId}");
        return snmp.IsSuccessStatusCode
            ? await snmp.Content.ReadFromJsonAsync<TelnetPayload>() : null;
    }
}
