using ConnectionControl.Api;
using ConnectionControl.Application.Mappings;
using ConnectionControl.Infrustructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(
   x => x.AddPolicy(
        Configuration.CorsPolicy,
        policy => policy
        .WithOrigins([
            Configuration.AdminAppUrl,
            Configuration.AdminApiUrl,
            Configuration.AdminAppConteiner,
            Configuration.AdminApiConteiner,
            Configuration.AdminApiConnectionsConteiner,
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
