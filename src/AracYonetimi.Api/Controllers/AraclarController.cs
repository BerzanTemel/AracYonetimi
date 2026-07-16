using Microsoft.AspNetCore.Mvc;
using AracYonetimi.Core.DTOs;
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Application.Services;

namespace AracYonetimi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AraclarController : ControllerBase
{
    private readonly IAracService _aracService;

    public AraclarController(IAracService aracService)
    {
        _aracService = aracService;
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(AracCreateDto createDto)
    {
        await _aracService.AddAsync(createDto);
        return Ok(new { Mesaj = "Araç başarıyla eklendi." });
    }

    // --- FİLTRELEME İÇİN GÜNCELLENEN KISIM ---
    [HttpGet]
    public async Task<IActionResult> Listele(
        [FromQuery] string? plaka, 
        [FromQuery] string? tipKod, 
        [FromQuery] string? durumKod, 
        [FromQuery] bool iptalGoster = false)
    {
        // URL'den gelen query parametrelerini servise paslıyoruz.
        var araclar = await _aracService.GetAllAsync(plaka, tipKod, durumKod, iptalGoster);
        return Ok(araclar);
    }
    // ----------------------------------------
    
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
        await _aracService.DeleteAsync(id);
        return NoContent(); 
    }

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