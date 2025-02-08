using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Text.Json.Serialization;
using System.Text.Json;
using Admin.Shared.Config;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});


builder.Services.AddServer();
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


builder.Services.AddScoped(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api");
    var jsonSerializerOptions = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    return new HttpClientWithOptions(httpClient, jsonSerializerOptions);
});

var app = builder.Build();
await app.RunAsync();




