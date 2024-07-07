using System.Net.Http.Json;
using Admin.Share.Request;
using Admin.Share.Response;

namespace Admin.App.Services;
public class HardwareApi
{
    private readonly HttpClient _httpClient;

    public HardwareApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<IEnumerable<HardwareResponse>?> GetHardwaresAsync()
    {  
            return await _httpClient.GetFromJsonAsync<IEnumerable<HardwareResponse>>("Hardware/ExibirTodos");
    }
    public async Task CreateHardwareAsync(HardwareRequest hardware)
    {
        var response = await _httpClient.PostAsJsonAsync("Hardware/CriarHardware", hardware);
        response.EnsureSuccessStatusCode();
    }
    public async Task<HardwareResponse?> GetHardwareId(int hardwareId)
    {
        return await _httpClient.GetFromJsonAsync<HardwareResponse>($"Hardware/ExibirHardwarePorId?id={hardwareId}");
    }
    public async Task EditHardwareAsync(HardwareRequest hardware)
    {
        var response = await _httpClient.PutAsJsonAsync("Hardware/EditarHardware", hardware);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteHardwareAsync(int hardwareId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"Hardware/DeleteHardware/?hardwareId={hardwareId}");
            response.EnsureSuccessStatusCode();

        }catch(Exception)
        {
            throw new Exception("Erro request");
        }
    }
}
