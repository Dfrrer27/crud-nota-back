using Microsoft.EntityFrameworkCore;
using NotaCrud.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Inyección del contexto
builder.Services.AddDbContext<NotaContext>( o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200") // Permitir solo mi proyecto local
           .AllowAnyHeader()                     // Permitir cualquier encabezado
           .AllowAnyMethod()                     // Permitir cualquier método HTTP (GET, POST, etc.)
           .AllowCredentials();                  // Permitir el envío de cookies o credenciales
});

app.UseAuthorization();

app.MapControllers();

app.Run();
