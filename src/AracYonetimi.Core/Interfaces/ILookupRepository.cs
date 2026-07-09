using AracYonetimi.Core.Entities;

namespace AracYonetimi.Core.Interfaces;

public interface ILookupRepository
{
    Task<IEnumerable<AracTip>> GetAracTiplerAsync();
    Task<IEnumerable<AracDurum>> GetAracDurumlarAsync();
    Task<IEnumerable<AracTahsisTip>> GetAracTahsisTiplerAsync();
    Task<IEnumerable<AracMarka>> GetAracMarkalarAsync();
    Task<IEnumerable<Firma>> GetFirmalarAsync();
    Task<IEnumerable<Personel>> GetPersonellerByFirmaAsync(string firmaKod);
    Task<IEnumerable<Doviz>> GetDovizlerAsync();
}