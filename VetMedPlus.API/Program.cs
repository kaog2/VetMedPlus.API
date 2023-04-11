using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Xml;
using VetMedPlus.API.Interfaces;
using VetMedPlus.API.Models;
using VetMedPlus.API.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PetMedPlusContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("PetMedPlusDB"));});

/*separate this part of code into a new class where are all interfaces to include here
 somethings like this 
// Registrar todas las implementaciones de interfaces en el contenedor de inyección de dependencia
    foreach (var implementation in implementations)
    {
        services.AddScoped(implementation.GetInterfaces().First(), implementation);
    }
 */
builder.Services.AddScoped<IUserData, UserData>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
