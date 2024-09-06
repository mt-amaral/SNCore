
using Admin.Shared.Response;
using System.Net.Http.Json;

namespace Admin.App.Services;
public class TelnetApi
{
    private readonly HttpClient _httpClient;

    public TelnetApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task EditHardwareAsync(TelnetResponse snmp)
    {
        var response = await _httpClient.PutAsJsonAsync("Snmp/EditarSnmp", snmp);
        response.EnsureSuccessStatusCode();
    }
    public async Task<TelnetResponse?> SelectByHardware(int hardwareId)
    {
        var snmp = await _httpClient.GetAsync($"/Telnet/ExibirPorHardwareId?id={hardwareId}");
        return snmp.IsSuccessStatusCode
            ? await snmp.Content.ReadFromJsonAsync<TelnetResponse>() : null;
    }
}
