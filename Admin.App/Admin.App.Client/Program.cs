using Admin.App.Client.Service;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<DashboardService>();
builder.Services.AddBootstrapBlazor();

builder.Services.AddTableDemoDataService();

await builder.Build().RunAsync();
