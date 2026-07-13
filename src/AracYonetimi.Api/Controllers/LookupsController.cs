using Microsoft.AspNetCore.Mvc;
using AracYonetimi.Core.Interfaces;
using AutoMapper;
using AracYonetimi.Core.DTOs;
namespace AracYonetimi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LookupsController : ControllerBase
{
    private readonly ILookupRepository _lookupRepository;
    private readonly IMapper _mapper;

    // Garsonumuzu (ILookupRepository) Controller'a enjekte ediyoruz
    public LookupsController(ILookupRepository lookupRepository, IMapper mapper)
    {
        _lookupRepository = lookupRepository;
        _mapper = mapper;
    }


    [HttpGet("arac-tipler")]
    public async Task<IActionResult> GetAracTipler()
    {
        
        var tipler = await _lookupRepository.GetAracTiplerAsync();

        var tiplerDto = _mapper.Map<List<AracTipListDto>>(tipler);
        return Ok(tiplerDto);
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
        var tahsisTiplerDto = _mapper.Map<List<AracTahsisTipListDto>>(tahsisTipler);
        return Ok(tahsisTiplerDto);
    }

    [HttpGet("arac-markalar")]
    public async Task<IActionResult> GetAracMarkalar()
    {
        var markalar = await _lookupRepository.GetAracMarkalarAsync();
        var markalarDto = _mapper.Map<List<AracMarkaListDto>>(markalar);
        return Ok(markalarDto);
    }

    [HttpGet("firmalar")]
    public async Task<IActionResult> GetFirmalar()
    {
        var firmalar = await _lookupRepository.GetFirmalarAsync();
        var firmalarDto = _mapper.Map<List<FirmaListDto>>(firmalar);
        return Ok(firmalarDto);
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
        var personellerDto = _mapper.Map<List<PersonelDto>>(personeller);
        return Ok(personellerDto);
    }

    [HttpGet("dovizler")]
    public async Task<IActionResult> GetDovizler()
    {
        var dovizler = await _lookupRepository.GetDovizlerAsync();
        return Ok(dovizler);
    }
}