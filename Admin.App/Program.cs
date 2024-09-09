using Admin.App;
using Admin.App.Mappings;
using Admin.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register APIs
builder.Services.AddTransient<HardwareApi>();
builder.Services.AddTransient<SnmpApi>();
builder.Services.AddTransient<TelnetApi>();

// Configure HttpClient
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiServer:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
})
.ConfigureHttpClient(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

// Configure JsonSerializerOptions globally
builder.Services.AddScoped(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api");
    var jsonSerializerOptions = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    return new HttpClientWithOptions(httpClient, jsonSerializerOptions);
});

await builder.Build().RunAsync();

// Custom HttpClient to include JsonSerializerOptions
public class HttpClientWithOptions
{
    public HttpClient HttpClient { get; }
    public JsonSerializerOptions JsonSerializerOptions { get; }

    public HttpClientWithOptions(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        HttpClient = httpClient;
        JsonSerializerOptions = jsonSerializerOptions;
    }
}
