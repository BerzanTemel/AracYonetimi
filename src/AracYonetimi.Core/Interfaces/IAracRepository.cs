using AracYonetimi.Core.Entities;

namespace AracYonetimi.Core.Interfaces;

public interface IAracRepository
{
    Task<Arac?> GetByIdAsync(int id);
    Task<IEnumerable<Arac>> GetAllAsync();
    Task AddAsync(Arac arac);
    Task UpdateAsync(Arac arac);
    Task DeleteAsync(int id);
}