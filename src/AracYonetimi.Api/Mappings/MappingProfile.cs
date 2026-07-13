using AracYonetimi.Api.DTOs;
using AracYonetimi.Core.Entities;
using AutoMapper;

namespace AracYonetimi.Api.Mappings
{
    // AutoMapper kurallarını yazabilmek için Profile sınıfından miras alıyoruz
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- TANIM/REFERANS EŞLEŞTİRMELERİ (Entity -> DTO) ---
            CreateMap<AracTip, AracTipListDto>();
            CreateMap<AracMarka, AracMarkaListDto>();
            CreateMap<Firma, FirmaListDto>();
            CreateMap<AracTahsisTip, AracTahsisTipListDto>();

            // --- EKLEME (CREATE) EŞLEŞTİRMELERİ (DTO -> Entity) ---
            // Burada veri dışarıdan (DTO'dan) gelip veritabanına (Entity'ye) yazılacağı için yönü ters çeviriyoruz
            CreateMap<AracTipCreateDto, AracTip>();
            CreateMap<FirmaCreateDto, Firma>();
            CreateMap<AracCreateDto, Arac>();
            CreateMap<PersonelCreateDto, Personel>();

            // --- LİSTELEME VE DETAY EŞLEŞTİRMELERİ (Entity -> DTO) ---
            CreateMap<Personel, PersonelDto>();
            CreateMap<Arac, AracDto>();
        }
    }
}