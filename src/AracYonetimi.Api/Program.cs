using Microsoft.EntityFrameworkCore;
using AracYonetimi.Infrastructure.Data;
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Infrastructure.Repositories;
using AracYonetimi.Api.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IAracRepository, AracRepository>();
builder.Services.AddScoped<ILookupRepository, LookupRepository>();

// 1. Servis Kayıtları (Dependency Injection)
// Swagger'ı sisteme tanıtıyoruz
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı Yöneticisini (DbContext) sisteme kaydediyoruz
// "DefaultConnection" bilgisini appsettings.Development.json'dan alıyor
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Kendi yazdığımız hata yakalayıcı bekçiyi sisteme dahil ediyoruz:
app.UseMiddleware<GlobalExceptionMiddleware>();

// 2. HTTP İstek Hattı (Middleware)
// Sadece geliştirme ortamında Swagger arayüzünü açıyoruz
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

// 3. Nabız Noktası (Health Check)
// Uygulamanın ayağa kalkıp kalkmadığını kontrol ettiğimiz basit uç nokta
app.MapGet("/health", () => "Sistem Avrupa Serbest Bölgesi'nde Aktif!");

app.Run();