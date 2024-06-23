using Admin.Api;
using Admin.Application.Mappings;
using Admin.Infrustructure;
using Microsoft.AspNetCore.Cors.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
// Cors config
builder.Services.AddCors(
   x => x.AddPolicy(
        Configuration.CorsPolicy,
        policy => policy
        .WithOrigins([
            Configuration.AdminAppUrl, 
            Configuration.AdminApiUrl,
            Configuration.AdminAppConteiner,
            Configuration.AdminApiConteiner
            ])
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        )
    );

builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(Configuration.CorsPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseCors("DefaultPolicy");
}
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseCors("DefaultPolicy");
}
if (app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
