using Microsoft.EntityFrameworkCore;
using AracYonetimi.Core.Entities;
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

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
}