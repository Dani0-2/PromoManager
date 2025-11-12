// -------------------------------------------------------------
// DIP: Configura la inyección de dependencias, enlazando las
// abstracciones con sus implementaciones concretas.
// -------------------------------------------------------------
// Estructura Clean Architecture correcta (API → Application → Domain).
// -------------------------------------------------------------
using PromoManager.Application.Interfaces;
using PromoManager.Application.Services;
using PromoManager.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICouponRepository, InMemoryCouponRepository>();
builder.Services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
builder.Services.AddScoped<CouponService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   
}
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();