using System.Net.Http.Json;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response;
using Admin.Shared.Response.Expression;

namespace Admin.App.Client.Service;

public class ExpressionService(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("Api");

    public async Task GetExpressionAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<Response<List<GetExpressionResponse>>?>("api/v1/Expression/GetAll");
        if (response is null)
            ;
        else 
            ;
    }
    
}