using System.Net.Http.Json;
using Admin.Share.Request;
using Admin.Share.Response;

namespace Admin.App.Services;
public class HardwareApi
{
    private readonly HttpClient _httpClient;

    public HardwareApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<HardwareResponse>?> GetHardwaresAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<HardwareResponse>>("Hardware/ExibirTodos");
        }
    public async Task EditHardwareAsync(HardwareRequest hardware)
    {
        var response = await _httpClient.PutAsJsonAsync("Hardware/EditarHardware", hardware);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteHardwareAsync(int hardwareId)
    {
        var response = await _httpClient.DeleteAsync($"api/hardware/DeleteHardware/{hardwareId}");
        response.EnsureSuccessStatusCode();
    }
}
