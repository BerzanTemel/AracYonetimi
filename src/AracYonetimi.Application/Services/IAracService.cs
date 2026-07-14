using AracYonetimi.Core.DTOs;

namespace AracYonetimi.Application.Services
{
    public interface IAracService
    {
        // 1. Temel CRUD İşlemleri
        Task<IEnumerable<AracListDto>> GetAllAsync();
        Task<AracDetailDto> GetByIdAsync(int id);
        Task<AracDetailDto> CreateAsync(AracCreateDto createDto);
        Task UpdateAsync(AracUpdateDto updateDto);
        Task DeleteAsync(int id); // BR-005: Onaylı kayıt silinemez kuralı burada işleyecek

        // 2. İş Kurallarına Özel İşlemler
        Task OnaylaAsync(List<int> ids);       // BR-011, BR-012: Toplu onaylama
        Task OnayKaldirAsync(List<int> ids);   // BR-013: Toplu onay kaldırma
        Task AddAsync(AracCreateDto createDto);
    }
}