using AracYonetimi.Core.DTOs;

namespace AracYonetimi.Core.Interfaces;

public interface ILookupRepository
{
    Task<IEnumerable<AracTipListDto>> GetAracTiplerAsync();
    Task<IEnumerable<AracDurumListDto>> GetAracDurumlarAsync();
    Task<IEnumerable<AracTahsisTipListDto>> GetAracTahsisTiplerAsync();
    Task<IEnumerable<AracMarkaListDto>> GetAracMarkalarAsync();
    Task<IEnumerable<FirmaListDto>> GetFirmalarAsync();
    Task<IEnumerable<PersonelDto>> GetPersonellerByFirmaAsync(string firmaKod);
    Task<IEnumerable<DovizListDto>> GetDovizlerAsync();
}