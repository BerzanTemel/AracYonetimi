using Microsoft.AspNetCore.Mvc;
using AracYonetimi.Core.Entities;
using AracYonetimi.Core.Interfaces; // AppDbContext yerine bunu kullanıyoruz

namespace AracYonetimi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AraclarController : ControllerBase
{
    private readonly IAracRepository _aracRepository;

    // Artık Controller oluşturulurken AppDbContext değil, IAracRepository (Garson) istiyoruz
    public AraclarController(IAracRepository aracRepository)
    {
        _aracRepository = aracRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(Arac arac)
    {
        // Veritabanına ekleme işini Repository'ye devrettik
        await _aracRepository.AddAsync(arac);
        
        return Ok(arac);
    }

    [HttpGet]
    public async Task<IActionResult> Listele()
    {
        // Listeleme işini Repository'den istiyoruz
        var araclar = await _aracRepository.GetAllAsync();
        
        return Ok(araclar);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Getir(int id)
    {
        var arac = await _aracRepository.GetByIdAsync(id);
        if (arac == null)
        {
            return NotFound("Araç bulunamadı."); // 404 Hatası döndürür
        }
        return Ok(arac);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Guncelle(int id, Arac arac)
    {
        if (id != arac.Id)
        {
            return BadRequest("ID uyuşmazlığı!"); // 400 Hatası döndürür
        }

        await _aracRepository.UpdateAsync(arac);
        return NoContent(); // 204 Kodu (Başarılı ama geriye veri dönmüyoruz)
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Sil(int id)
    {
        var arac = await _aracRepository.GetByIdAsync(id);
        if (arac == null)
        {
            return NotFound("Silinecek araç bulunamadı.");
        }

        await _aracRepository.DeleteAsync(id);
        return NoContent(); // 204 Kodu
    }
}