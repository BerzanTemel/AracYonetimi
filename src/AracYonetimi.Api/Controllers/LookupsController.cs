using Microsoft.AspNetCore.Mvc;
using AracYonetimi.Core.Interfaces;
namespace AracYonetimi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LookupsController : ControllerBase
{
    private readonly ILookupRepository _lookupRepository;

    // Garsonumuzu (ILookupRepository) Controller'a enjekte ediyoruz
    // Mapper'ı buradan tamamen kaldırdık
    public LookupsController(ILookupRepository lookupRepository)
    {
        _lookupRepository = lookupRepository;
    }

    [HttpGet("arac-tipler")]
    public async Task<IActionResult> GetAracTipler()
    {
        // Repository zaten DTO dönüyor, doğrudan Ok() içine koyuyoruz
        var tipler = await _lookupRepository.GetAracTiplerAsync();
        return Ok(tipler);
    }

    [HttpGet("arac-durumlar")]
    public async Task<IActionResult> GetAracDurumlar()
    {
        var durumlar = await _lookupRepository.GetAracDurumlarAsync();
        return Ok(durumlar);
    }

    [HttpGet("arac-tahsis-tipler")]
    public async Task<IActionResult> GetAracTahsisTipler()
    {
        var tahsisTipler = await _lookupRepository.GetAracTahsisTiplerAsync();
        return Ok(tahsisTipler);
    }

    [HttpGet("arac-markalar")]
    public async Task<IActionResult> GetAracMarkalar()
    {
        var markalar = await _lookupRepository.GetAracMarkalarAsync();
        return Ok(markalar);
    }

    [HttpGet("firmalar")]
    public async Task<IActionResult> GetFirmalar()
    {
        var firmalar = await _lookupRepository.GetFirmalarAsync();
        return Ok(firmalar);
    }

    // Dikkat: Burada personelleri getirmek için firmaKod parametresi istiyoruz
    [HttpGet("personeller")]
    public async Task<IActionResult> GetPersoneller([FromQuery] string firmaKod)
    {
        if (string.IsNullOrWhiteSpace(firmaKod))
        {
            return BadRequest("firmaKod parametresi zorunludur.");
        }

        var personeller = await _lookupRepository.GetPersonellerByFirmaAsync(firmaKod);
        return Ok(personeller);
    }

    [HttpGet("dovizler")]
    public async Task<IActionResult> GetDovizler()
    {
        var dovizler = await _lookupRepository.GetDovizlerAsync();
        return Ok(dovizler);
    }
}