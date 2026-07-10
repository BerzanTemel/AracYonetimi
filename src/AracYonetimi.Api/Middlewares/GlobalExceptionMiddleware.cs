using System.Net;
using System.Text.Json;

namespace AracYonetimi.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        // _next: Boru hattındaki (pipeline) bir sonraki adımı temsil eder.
        private readonly RequestDelegate _next;
        // _logger: Hataları konsola veya dosyaya yazdırmak (loglamak) için kullanırız.
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // İstek API'ye her geldiğinde ilk buraya uğrar.
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Sorun yoksa isteği sistemin içine (Controller'lara) gönder.
                await _next(context);
            }
            catch (Exception ex)
            {
                // İçeride bir yerde sistem patlarsa (Exception fırlatırsa) havada yakala.
                _logger.LogError(ex, "Sistemde beklenmeyen bir hata oluştu.");
                
                // Yakalanan hatayı düzgün bir JSON'a çevirip dışarı yolla.
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Dışarıya gidecek paketin tipini JSON olarak belirliyoruz.
            context.Response.ContentType = "application/json";
            
            // Hata kodunu 500 (Internal Server Error) olarak ayarlıyoruz.
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Dışarıya verilecek temiz mesaj nesnesi
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Sunucu tarafında beklenmeyen bir hata meydana geldi.",
                // Not: Geliştirme aşamasında 'Detailed' kısmını açabiliriz, 
                // ancak canlı (production) ortamda güvenlik için burayı gizlemeliyiz.
                Detailed = exception.Message 
            };

            // Nesneyi JSON metnine çevir (Serialize) ve Frontend'e gönder.
            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}