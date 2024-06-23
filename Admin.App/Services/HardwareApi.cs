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

    public async Task<IEnumerable<HardwareModel>> GetHardwaresAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<HardwareModel>>("Hardware/ExibirTodos");
    }
}
