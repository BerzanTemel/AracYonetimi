using Microsoft.AspNetCore.Mvc;
using AracYonetimi.Core.DTOs; // Artık Entity değil DTO kullanıyoruz
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Application.Services; // IAracService için gerekli

namespace AracYonetimi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AraclarController : ControllerBase
{
    private readonly IAracService _aracService;

    // Artık IAracRepository değil, iş kurallarımızın bulunduğu IAracService'i istiyoruz
    public AraclarController(IAracService aracService)
    {
        _aracService = aracService;
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(AracCreateDto createDto)
    {
        // Gelen DTO'yu servise gönderiyoruz, iş kuralları orada işletilip veritabanına eklenecek
        await _aracService.AddAsync(createDto);
        return Ok(new { Mesaj = "Araç başarıyla eklendi." });
    }

    [HttpGet]
    public async Task<IActionResult> Listele()
    {
        // Servis bize veritabanı nesnesi değil, AracListDto listesi dönecek
        var araclar = await _aracService.GetAllAsync();
        return Ok(araclar);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Getir(int id)
    {
        var arac = await _aracService.GetByIdAsync(id);
        if (arac == null)
        {
            return NotFound("Araç bulunamadı."); 
        }
        return Ok(arac);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Guncelle(int id, AracUpdateDto updateDto)
    {
        if (id != updateDto.Id)
        {
            return BadRequest("ID uyuşmazlığı!"); 
        }

        await _aracService.UpdateAsync(updateDto);
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Sil(int id)
    {
        // Servisteki "Onaylı kayıt silinemez" kuralı devreye girecek
        await _aracService.DeleteAsync(id);
        return NoContent(); 
    }

    // --- YENİ EKLENEN İŞ KURALLARI (Toplu Onay İşlemleri) ---

    [HttpPost("onayla")]
    public async Task<IActionResult> Onayla([FromBody] List<int> ids)
    {
        await _aracService.OnaylaAsync(ids);
        return Ok(new { Mesaj = "Araçlar başarıyla onaylandı." });
    }

    [HttpPost("onaykaldir")]
    public async Task<IActionResult> OnayKaldir([FromBody] List<int> ids)
    {
        await _aracService.OnayKaldirAsync(ids);
        return Ok(new { Mesaj = "Araçların onayı başarıyla kaldırıldı." });
    }
}