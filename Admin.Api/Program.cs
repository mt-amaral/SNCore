using Admin.Api;
using Admin.Infrustructure;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServer();

if (builder.Environment.EnvironmentName == "Development")
{
    builder.Services.AddContextDevelopment(builder.Configuration);

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
}
else if (builder.Environment.EnvironmentName == "Production")
{
    builder.Services.AddContextProduction(builder.Configuration);
    builder.Services.AddCors(
    x => x.AddPolicy(
    Configuration.CorsPolicyPro,
    policy => policy
    .WithOrigins(
        Configuration.AdminApiConteiner,
        Configuration.AdminAppConteiner
    )
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    )
);
}
else if (builder.Environment.EnvironmentName == "Staging")
{
    builder.Services.AddContextProduction(builder.Configuration);
    builder.Services.AddCors(
        x => x.AddPolicy(
            Configuration.CorsPolicyPro,
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
}

// Configure Json.NET to ignore null values
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Title = "API Documentação Swagger",
                Description = "SNCore"
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        }
    );

var app = builder.Build();

app.UseCors(Configuration.CorsPolicyDev);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
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
app.UseAuthorization();

app.MapControllers();

app.Run();
