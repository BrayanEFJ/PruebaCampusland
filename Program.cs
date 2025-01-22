using Microsoft.EntityFrameworkCore;
using PruebaBrayanFigueroa.Models;
using PruebaBrayanFigueroa.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PruebaBfContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IPedidosService, PedidosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
