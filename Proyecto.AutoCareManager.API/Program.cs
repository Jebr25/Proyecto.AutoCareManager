using Microsoft.EntityFrameworkCore;
using Proyecto.AutoCareManager.DOMAIN.Core.Interfaces;
using Proyecto.AutoCareManager.DOMAIN.Core.Services;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Data;
using Proyecto.AutoCareManager.DOMAIN.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var _cnx = _config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<AutocaremanagerContext>(options => { options.UseSqlServer(_cnx); });

//-------------------------------------------------------------------------------------//

// Agregar Interfaz de Articulo
builder.Services.AddTransient<IArticuloRepository, ArticuloRepository>();

// Agregar Interfaz de Usuario
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

// Agregar Interfaz de FacturaVenta
//builder.Services.AddScoped<IFacturaVentaRepository, FacturaVentaRepository>();
//builder.Services.AddScoped<IFacturaVentaService, FacturaVentaService>();

// Agregar Interfaz de Vehiculo
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();

// Agregar Interfaz de Taller

// Agregar Interfaz de Empleado
builder.Services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();

//-------------------------------------------------------------------------------------//

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();

    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
