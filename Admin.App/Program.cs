using Admin.App;
using Admin.App.Services;
using Admin.App.Mappings;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<HardwareApi>();
builder.Services.AddTransient<SnmpApi>();

builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiServer:Url"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

await builder.Build().RunAsync();
