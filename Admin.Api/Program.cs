using Admin.Api;
using Admin.Application.Mappings;
using Admin.Infrustructure;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);

// Cors config
builder.Services.AddCors(
   x => x.AddPolicy(
        Configuration.CorsPolicy,
        policy => policy
        .WithOrigins(
            Configuration.AdminAppUrl,
            Configuration.AdminApiUrl,
            Configuration.AdminAppConteiner,
            Configuration.AdminApiConteiner,
            Configuration.AdminApiConnectionsConteiner
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    )
);

builder.Services.AddAutoMapper(typeof(DomainMappingProfile));

// Configure Json.NET to ignore null values
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(Configuration.CorsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
    });
    app.UseHttpsRedirection();
    app.UseCors("DefaultPolicy");
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
    });
    app.UseHttpsRedirection();
    app.UseCors("DefaultPolicy");
}
if (app.Environment.IsStaging())
{
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
