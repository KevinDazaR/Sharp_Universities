using Microsoft.EntityFrameworkCore;
using HTML_Componentes.Infrastructure.Data;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BaseContext>(Options =>
    Options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Registrar repositorios
builder.Services.AddScoped<IExcelRepository, ExcelRepository>();
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IUniversidadRepository, UniversidadRepository>();
builder.Services.AddScoped<IInscripcionRepository, InscripcionRepository>();
builder.Services.AddScoped<ICarreraRepository, CarreraRepository>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<ISemestreRepository, SemestreRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Agregar esta línea para codigo Razor - Componentes

app.Run();
