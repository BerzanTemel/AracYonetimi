using Microsoft.EntityFrameworkCore;
using AracYonetimi.Core.Entities;
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Infrastructure.Data;

namespace AracYonetimi.Infrastructure.Repositories;

public class LookupRepository : ILookupRepository
{
    private readonly AppDbContext _context;

    public LookupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AracTip>> GetAracTiplerAsync()
    {
        return await _context.AracTipler.ToListAsync();
    }

    public async Task<IEnumerable<AracDurum>> GetAracDurumlarAsync()
    {
        return await _context.AracDurumlar.ToListAsync();
    }

    public async Task<IEnumerable<AracTahsisTip>> GetAracTahsisTiplerAsync()
    {
        return await _context.AracTahsisTipler.ToListAsync();
    }

    public async Task<IEnumerable<AracMarka>> GetAracMarkalarAsync()
    {
        return await _context.AracMarkalar.ToListAsync();
    }

    public async Task<IEnumerable<Firma>> GetFirmalarAsync()
    {
        return await _context.Firmalar.ToListAsync();
    }

    // Dikkat: Burada sadece dışarıdan gelen firmaKod'a ait personelleri filtreleyip getiriyoruz!
    public async Task<IEnumerable<Personel>> GetPersonellerByFirmaAsync(string firmaKod)
    {
        return await _context.Personeller
                             .Where(p => p.FirmaKod == firmaKod)
                             .ToListAsync();
    }

    public async Task<IEnumerable<Doviz>> GetDovizlerAsync()
    {
        return await _context.Dovizler.ToListAsync();
    }
}