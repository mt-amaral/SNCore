using System.Text.Json;
using System.Text.Json.Serialization;
using Admin.App;
using Admin.App.Client.Config;
using Admin.App.Components;
using Admin.App.Middleware;
using Admin.App.Security;
using Admin.Application.Hub;
using Admin.Domain.Account;
using Admin.Infrustructure;
using Admin.Persistence.Context;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using Microsoft.AspNetCore.SignalR;
using MudBlazor.Services;
using Newtonsoft.Json;
using Admin.App.Client;
using Admin.App.Client.Service;
using Admin.Shared.Interfaces;
using ApexCharts;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

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
builder.Services.AddApexCharts();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsDev", policy => policy
        .WithOrigins(Acl.AdminDevUrl)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());

    options.AddPolicy("CorsProd", policy => policy
        .WithOrigins(Acl.AdminProUrl)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets<Program>() // ou AddUserSecrets(typeof(Program).Assembly)
    .AddEnvironmentVariables();

builder.Services.AddServerWeb();
builder.Services.AddServer(builder.Configuration);
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddIdentityContext(builder.Configuration);


builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSignalR();

builder.Services.AddControllers(options =>
    
    {
        var policy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter(policy));
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
{
    {
        var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
        c.SwaggerDoc("v1", new()
        {
            Title = "SNCore Documentação Api",
            Description = ""
        });
    }
});

builder.Services.AddSingleton<IHubConnectionSocket, ClientSocket>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<CookieDelegatingHandler>();

builder.Services.AddHttpClient("Api", client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["ApiServer:Url"]!);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    })
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    })
    .ConfigureHttpClient(client =>
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }).AddHttpMessageHandler<CookieDelegatingHandler>();
builder.Services.AddScoped(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api");
    var jsonSerializerOptions = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    return new HttpClientWithOptions(httpClient, jsonSerializerOptions);
});

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();


builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/app/keys"));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.Events.OnRedirectToLogin = context =>
    {
        if(context.Request.Path.StartsWithSegments("/api"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("CorsDev");
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
    app.UseWebAssemblyDebugging();
}
if (app.Environment.IsProduction())
{
    app.UseCors("CorsProd");
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}
if (app.Environment.IsStaging())
{
    app.UseCors("WebAppDev");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var userContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
        dbContext.Database.Migrate();
        userContext.Database.Migrate();
    }
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Admin.App.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 
app.MapHub<NotificationHub>("/hubs/notification");
//app.MapAdditionalIdentityEndpoints();

app.Run();
