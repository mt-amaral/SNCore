
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
    public async Task<TelnetPayload?> SelectByHardware(int hardwareId)
    {
        var snmp = await _httpClient.GetAsync($"/Telnet/ExibirPorHardwareId?id={hardwareId}");
        return snmp.IsSuccessStatusCode
            ? await snmp.Content.ReadFromJsonAsync<TelnetPayload>() : null;
    }
}
