using Microsoft.EntityFrameworkCore;
using AracYonetimi.Core.Entities;
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AracYonetimi.Infrastructure.Repositories;

public class AracRepository : IAracRepository
{
    private readonly AppDbContext _context;

    public AracRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Arac?> GetByIdAsync(int id)
    {
        return await _context.Araclar.FindAsync(id);
    }

    public async Task<IEnumerable<Arac>> GetAllAsync()
    {
        return await _context.Araclar.ToListAsync();
    }

    public async Task<IEnumerable<Arac>> GetAllFilteredAsync(string? plaka, string? tipKod, string? durumKod, bool iptalGoster)
        {
            var query = _context.Araclar.AsNoTracking().AsQueryable();

        if (!iptalGoster)
            query = query.Where(x => x.DurumKod != "9");

        if (!string.IsNullOrEmpty(plaka))
            query = query.Where(x => x.Plaka!.Contains(plaka));

        if (!string.IsNullOrEmpty(tipKod))
            query = query.Where(x => x.TipKod == tipKod);

        if (!string.IsNullOrEmpty(durumKod))
            query = query.Where(x => x.DurumKod == durumKod);

        // Entity Framework burada kurulu olduğu için ToListAsync() sorunsuz çalışır!
        return await query.ToListAsync();
    }

    public async Task AddAsync(Arac arac)
    {
        await _context.Araclar.AddAsync(arac);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Arac arac)
    {
        _context.Araclar.Update(arac);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var arac = await _context.Araclar.FindAsync(id);
        if (arac != null)
        {
            _context.Araclar.Remove(arac);
            await _context.SaveChangesAsync();
        }
    }

        public async Task<Arac?> GetByKodAsync(string kod)
        {
        // _context senin AppDbContext (veritabanı) nesnendir.
        // Eğer constructor'da ismini _dbContext veya farklı bir şey yaptıysan ona göre değiştirebilirsin.
        return await _context.Araclar.FirstOrDefaultAsync(a => a.Kod == kod);
        }
}