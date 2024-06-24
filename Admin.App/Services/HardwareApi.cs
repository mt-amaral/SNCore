using Admin.App.Model;
using System.Net.Http.Json;

namespace Admin.App.Services;
public class HardwareApi
{
    private readonly HttpClient _httpClient;

    public HardwareApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<HardwareModel>?> GetHardwaresAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<HardwareModel>>("Hardware/ExibirTodos");
        }
    public async Task EditHardwareAsync(HardwareModel hardware)
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
