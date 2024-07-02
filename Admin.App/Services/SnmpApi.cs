using System.Net.Http.Json;
using Admin.Share.Request;
using Admin.Share.Response;

namespace Admin.App.Services;
public class SnmpApi
{
    private readonly HttpClient _httpClient;

    public SnmpApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }
    public async Task CreateHardwareAsync(SnmpRequest snmp)
    {
        var response = await _httpClient.PostAsJsonAsync("Snmp/CriarSnmp", snmp);
        response.EnsureSuccessStatusCode();
    }
    public async Task EditHardwareAsync(SnmpRequest snmp)
    {
        var response = await _httpClient.PutAsJsonAsync("Snmp/EditarSnmp", snmp);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteHardwareAsync(int snmpId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"Snmp/DeleteSnmp/?snmpId={snmpId}");
            response.EnsureSuccessStatusCode();
        }catch(Exception)
        {
            throw new Exception("Erro request");
        }
    }
}
