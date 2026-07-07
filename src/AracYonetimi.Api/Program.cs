using Microsoft.EntityFrameworkCore;
using AracYonetimi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 1. Servis Kayıtları (Dependency Injection)
// Swagger'ı sisteme tanıtıyoruz
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı Yöneticisini (DbContext) sisteme kaydediyoruz
// "DefaultConnection" bilgisini appsettings.Development.json'dan alıyor
builder.Services.AddDbContext<AracDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. HTTP İstek Hattı (Middleware)
// Sadece geliştirme ortamında Swagger arayüzünü açıyoruz
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. Nabız Noktası (Health Check)
// Uygulamanın ayağa kalkıp kalkmadığını kontrol ettiğimiz basit uç nokta
app.MapGet("/health", () => "Sistem Avrupa Serbest Bölgesi'nde Aktif!");

app.Run();