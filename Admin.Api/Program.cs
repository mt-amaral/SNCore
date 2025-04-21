using Admin.Api;
using Admin.Infrustructure;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using Admin.Api.Middleware;
using Admin.Domain.Account;
using Admin.Domain.Entities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServer();


builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddIdentityContext(builder.Configuration);

builder.Services.AddCors(
    x => x.AddPolicy(
    Configuration.CorsPolicyDev,
    policy => policy
    .WithOrigins(
        Configuration.AdminAppUrl,
        Configuration.AdminApiUrl
    )
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    )
);

// Configure Json.NET to ignore null values
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    {
        c.SwaggerDoc("v1", new()
        {
            Title = "SNCore Documentação Api",
            Description = ""
        });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<UserDbContext>();

var app = builder.Build();

app.UseCors(Configuration.CorsPolicyDev);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
    app.UseHttpsRedirection();
    app.UseCors("WebAppDev");
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
    });
    //app.UseHttpsRedirection();
    app.UseCors("WebAppProd");
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
        dbContext.Database.Migrate();
    }
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

//app.MapIdentityApi<User>();
app.MapControllers();
app.MapBlazorHub();

app.Run();
