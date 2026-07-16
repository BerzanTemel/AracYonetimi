using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AracYonetimi.Core.DTOs;
using AracYonetimi.Core.Entities;      // Repository ve Entity'leri bağladığımızda aktif edeceğiz
using AracYonetimi.Core.Interfaces;    // IAracRepository için aktif edeceğiz
using AutoMapper;
namespace AracYonetimi.Application.Services
{
    public class AracService : IAracService
    {
        private readonly IMapper _mapper;
         private readonly IAracRepository _aracRepository; 

        // Dependency Injection (Bağımlılıkların İçeri Alınması)
        public AracService(IMapper mapper, IAracRepository aracRepository)
        {
            _mapper = mapper;
            _aracRepository = aracRepository;
        }

        public async Task<AracDetailDto> CreateAsync(AracCreateDto createDto)
        {
            // --- 1. AŞAMA: İŞ KURALLARI (BUSINESS RULES) DOĞRULAMASI ---

            // BR-014: Mevcut km/saat negatif olamaz
            if (createDto.MevcutKmSaat.HasValue && createDto.MevcutKmSaat < 0)
            {
                throw new ArgumentException("Mevcut km/saat negatif olamaz");
            }

            // BR-009: Sözleşme başlangıç ve bitiş ikisi dolu veya ikisi boş olmalıdır
            bool baslangicDolu = createDto.SozlesmeBaslangicTarih.HasValue;
            bool bitisDolu = createDto.SozlesmeBitisTarih.HasValue;

            if (baslangicDolu != bitisDolu)
            {
                throw new ArgumentException("Başlangıç ve Bitiş tarihi her ikisi de dolu veya boş olmalıdır!");
            }

            // BR-010: Bitiş tarihi >= başlangıç tarihi
            if (baslangicDolu && bitisDolu && createDto.SozlesmeBitisTarih < createDto.SozlesmeBaslangicTarih)
            {
                throw new ArgumentException("Bitiş tarihi, başlangıç tarihinden önce olamaz");
            }

            // --- 2. AŞAMA: DTO'DAN ENTITY'YE DÖNÜŞÜM (MAPPING) ---
            
            // AutoMapper, DTO'daki verileri yeni bir Arac entity'sine kopyalıyor
             var yeniArac = _mapper.Map<Arac>(createDto);

            // --- 3. AŞAMA: YENİ KAYIT VARSAYILAN DEĞER ATAMALARI ---
            
             yeniArac.DurumKod = "1";     // BR-001: Yeni kayıtta durum_kod = "1" (Aktif)
            yeniArac.Onay = true;        // BR-002: Yeni kayıtta onay = true
            yeniArac.Iptal = false;      // BR-003: Yeni kayıtta iptal = false
            yeniArac.FirmaKod = "001";   // BR-004: Yeni kayıtta firma_kod = "001"

            // --- 4. AŞAMA: VERİTABANINA KAYIT (İleride Eklenecek) ---
            await _aracRepository.AddAsync(yeniArac);

            // Kayıt sonrası veriyi tekrar DTO'ya çevirip Controller'a geri dönüyoruz
            return _mapper.Map<AracDetailDto>(yeniArac);

            throw new NotImplementedException("Veritabanı (Repository) katmanı bağlandığında bu metod tam çalışacak.");
        }

        public async Task DeleteAsync(int id)
        {
            var arac = await _aracRepository.GetByIdAsync(id);
            if (arac == null) throw new Exception("Araç bulunamadı");

            // BR-005: Onaylı kayıt silinemez
            if (arac.Onay)
            {
                throw new InvalidOperationException("Onaylı kayıtlar silinemez!");
            }

            await _aracRepository.DeleteAsync(id);            
        }

       // --- 1. OKUMA İŞLEMLERİ ---

        public async Task<IEnumerable<AracListDto>> GetAllAsync(string? plaka, string? tipKod, string? durumKod, bool iptalGoster = false)
{
    // Filtreleme işini Repository'ye devrettik. Bize filtrelenmiş liste gelecek.
    var araclar = await _aracRepository.GetAllFilteredAsync(plaka, tipKod, durumKod, iptalGoster);
    
    // Gelen listeyi DTO'ya çevirip dışarıya dönüyoruz.
    return _mapper.Map<IEnumerable<AracListDto>>(araclar);
}

        public async Task<AracDetailDto> GetByIdAsync(int id)
        {
            var arac = await _aracRepository.GetByIdAsync(id);
            if (arac == null) throw new Exception("Araç bulunamadı.");
            
            return _mapper.Map<AracDetailDto>(arac);
        }

        // --- 2. ONAY İŞLEMLERİ (BR-011, BR-012, BR-013) ---

        public async Task OnaylaAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var arac = await _aracRepository.GetByIdAsync(id);
                if (arac != null)
                {
                    arac.Onay = true; // BR-011: Onayla
                    await _aracRepository.UpdateAsync(arac);
                }
            }
        }

        public async Task OnayKaldirAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                var arac = await _aracRepository.GetByIdAsync(id);
                if (arac != null)
                {
                    // BR-005: Onaylı kayıt silinemez kuralını burada da hatırlıyoruz, 
                    // onay kaldırma işlemi onaylı kayıtlara yapılabilir.
                    arac.Onay = false; // BR-013: Onayı kaldır
                    await _aracRepository.UpdateAsync(arac);
                }
            }
        }
        public async Task UpdateAsync(AracUpdateDto updateDto)
        {
            // Veritabanından mevcut kaydı çek
            var mevcutArac = await _aracRepository.GetByIdAsync(updateDto.Id);
            if (mevcutArac == null) throw new Exception("Araç bulunamadı.");

            // BR-014: Mevcut km/saat negatif olamaz
            if (updateDto.MevcutKmSaat.HasValue && updateDto.MevcutKmSaat < 0)
            {
                throw new ArgumentException("Mevcut km/saat negatif olamaz");
            }

            // BR-006 & BR-007: İptal Tarihi kuralları
            if (updateDto.DurumKod == "9") // İptal durumu
            {
                if (!updateDto.SozlesmeIptalTarih.HasValue)
                    throw new ArgumentException("Araç durum iptal edilmiş. İptal tarih girilmesi zorunludur!");
                
                mevcutArac.Iptal = true; // BR-008
            }
            else
            {
                if (updateDto.SozlesmeIptalTarih.HasValue)
                    throw new ArgumentException("Durum iptal değil. İptal tarihi girilemez!");
                
                mevcutArac.Iptal = false; // BR-008
            }

            // BR-009 & BR-010: Sözleşme tarihleri kuralları
            bool baslangicDolu = updateDto.SozlesmeBaslangicTarih.HasValue;
            bool bitisDolu = updateDto.SozlesmeBitisTarih.HasValue;

            if (baslangicDolu != bitisDolu)
                throw new ArgumentException("Başlangıç ve Bitiş tarihi her ikisi de dolu veya boş olmalıdır!");

            if (baslangicDolu && bitisDolu && updateDto.SozlesmeBitisTarih < updateDto.SozlesmeBaslangicTarih)
                throw new ArgumentException("Bitiş tarihi, başlangıç tarihinden önce olamaz");

            // --- GÜNCELLEME İŞLEMİ ---
            // AutoMapper ile DTO'daki yeni verileri mevcut entity'nin üzerine yaz
            _mapper.Map(updateDto, mevcutArac);

            await _aracRepository.UpdateAsync(mevcutArac);
        }

        public async Task AddAsync(AracCreateDto createDto)
        {
            // --- 1. İŞ KURALLARI VE KONTROLLER (VALIDATION) ---
    
            // Kural 1: Kilometre negatif olamaz
            if (createDto.MevcutKmSaat < 0)
            {
                throw new Exception("Mevcut KM veya Saat değeri 0'dan küçük olamaz!");
            }

            // Kural 2: Sözleşme bitiş tarihi, başlangıç tarihinden önce olamaz
            if (createDto.SozlesmeBitisTarih.HasValue && createDto.SozlesmeBaslangicTarih.HasValue)
            {
            if (createDto.SozlesmeBitisTarih < createDto.SozlesmeBaslangicTarih)
                {
                    throw new Exception("Sözleşme bitiş tarihi, başlangıç tarihinden daha eski bir tarih olamaz!");
                }
            }

            // Kural 3: Plaka zorunluluğu (Temel veri bütünlüğü)
            if (string.IsNullOrWhiteSpace(createDto.Plaka))
            {
                throw new Exception("Araç plakası boş bırakılamaz!");
            }

            // --- 2. ÇEVİRİ İŞLEMİ (DTO -> Entity) ---
            var arac = _mapper.Map<Arac>(createDto);

            // --- 3. VARSAYILAN DEĞER ATAMALARI ---
            // Kullanıcı durum kodu göndermemişse varsayılan olarak "AKTIF" yapıyoruz
            if (string.IsNullOrWhiteSpace(arac.DurumKod))
            {
                arac.DurumKod = "AKTIF";
            }

            // Eğer Entity sınıfında (Arac.cs) bir 'Onay' veya 'AktifMi' gibi bool alanın varsa 
            // onu da burada true olarak set edebilirsin. Örneğin:
            arac.Onay = true; 

            // --- 4. VERİTABANINA KAYIT ---
            await _aracRepository.AddAsync(arac);
        }
    }
}