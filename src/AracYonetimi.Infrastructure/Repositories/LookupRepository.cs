using Microsoft.EntityFrameworkCore;
using AracYonetimi.Core.Entities;
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Infrastructure.Data;
using AracYonetimi.Core.DTOs;

namespace AracYonetimi.Infrastructure.Repositories;

public class LookupRepository : ILookupRepository
{
    private readonly AppDbContext _context;

    public LookupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AracTipListDto>> GetAracTiplerAsync()
    {
        return await _context.AracTipler.AsNoTracking()
            .Select(x => new AracTipListDto { Kod = x.Kod, TipAdi = x.TipAdi }).ToListAsync();
    }

    public async Task<IEnumerable<AracDurumListDto>> GetAracDurumlarAsync()
    {
        return await _context.AracDurumlar.AsNoTracking()
            .Select(x => new AracDurumListDto { Kod = x.Kod, DurumAdi = x.DurumAdi }).ToListAsync();
    }

    public async Task<IEnumerable<AracTahsisTipListDto>> GetAracTahsisTiplerAsync()
    {
        return await _context.AracTahsisTipler.AsNoTracking()
            .Select(x => new AracTahsisTipListDto { Kod = x.Kod, TahsisTipAdi = x.TahsisTipAdi }).ToListAsync();
    }

    public async Task<IEnumerable<AracMarkaListDto>> GetAracMarkalarAsync()
    {
        return await _context.AracMarkalar.AsNoTracking()
            .Select(x => new AracMarkaListDto { Kod = x.Kod, MarkaAdi = x.MarkaAdi }).ToListAsync();
    }

    public async Task<IEnumerable<FirmaListDto>> GetFirmalarAsync()
    {
        return await _context.Firmalar.AsNoTracking()
            .Select(x => new FirmaListDto { Kod = x.Kod, FirmaAdi = x.FirmaAdi }).ToListAsync();
    }

    public async Task<IEnumerable<PersonelDto>> GetPersonellerByFirmaAsync(string firmaKod)
    {
        return await _context.Personeller.AsNoTracking()
            .Where(p => p.FirmaKod == firmaKod)
            .Select(x => new PersonelDto { Kod = x.Kod, Ad = x.Ad }).ToListAsync();
    }

    public async Task<IEnumerable<DovizListDto>> GetDovizlerAsync()
    {
        return await _context.Dovizler.AsNoTracking()
            .Select(x => new DovizListDto { Kod = x.Kod, DovizCinsi = x.DovizCinsi }).ToListAsync();
    }
}