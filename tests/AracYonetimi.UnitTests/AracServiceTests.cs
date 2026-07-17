using AracYonetimi.Core.Entities;
using AracYonetimi.Core.DTOs;
using AracYonetimi.Core.Interfaces;
using AracYonetimi.Application.Services; // AracService'i kullanabilmek için ekledik
using Moq;
using Xunit;
using AutoMapper;

namespace AracYonetimi.UnitTests;

public class AracServiceTests
{
    private readonly Mock<IMapper> _mockMapper;       // 1. Mapper için Mock eklendi
    private readonly Mock<IAracRepository> _mockRepo;
    private readonly AracService _aracService; 

    public AracServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepo = new Mock<IAracRepository>();
        _mockMapper.Setup(m => m.Map<Arac>(It.IsAny<AracCreateDto>()))
               .Returns(new Arac());
        
        // Mock nesnesini servise enjekte ediyoruz
        _aracService = new AracService(_mockMapper.Object, _mockRepo.Object);    }

    [Fact]
    public async Task Delete_OnayliKayit_ThrowsException()
    {
        // Arrange (Hazırlık): ONAYLI bir araç verisi
        var onayliArac = new Arac 
        { 
            Id = 1, 
            Kod = "ARC001", 
            Onay = true 
        };

        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(onayliArac);

        // Act & Assert (Eylem ve Doğrulama): 
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _aracService.DeleteAsync(1));        
        // Fırlatılan hatanın mesajı tam olarak istenen kurala uyuyor mu?
        Assert.Equal("Onaylı kayıtlar silinemez!", exception.Message);
    }

    [Fact]
    public async Task Save_NegatifKm_ThrowsException()
    {
        // Arrange (Hazırlık): Mevcut kilometresi negatif olan kurala aykırı bir araç verisi oluşturuyoruz
        var hataliAracDto = new AracCreateDto 
        { 
            Kod = "ARC002", 
            MevcutKmSaat = -150 // Hata vermesini beklediğimiz nokta!
        };

        // Act & Assert (Eylem ve Doğrulama): 
        // Yeni araç ekleme (CreateAsync veya AddAsync - servisinde hangi ismi verdiysen onu kullan) çağrıldığında hata fırlatmalı
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _aracService.CreateAsync(hataliAracDto));        
        // Fırlatılan hatanın mesajı tam olarak istenen kurala uymalı
        Assert.Equal("Mevcut km/saat negatif olamaz", exception.Message);
    }

    [Fact]
    public async Task Save_IptalDurum_IptalTarihiZorunlu_ThrowsException()
    {
        // Arrange (Hazırlık): Durum 'İptal' (9) yapılmış ama İptal Tarihi girilmemiş[cite: 3]
        var hataliAracDto = new AracCreateDto 
        { 
            Kod = "ARC003", 
            DurumKod = "9", 
            SozlesmeIptalTarih = null // Hata vermesini beklediğimiz kural ihlali[cite: 3]
        };

        // Act & Assert (Eylem ve Doğrulama)
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _aracService.CreateAsync(hataliAracDto));
        
        // Fırlatılan mesaj tam olarak analistin istediği mesaj olmalı[cite: 3]
        Assert.Equal("Araç durum iptal edilmiş. İptal tarih girilmesi zorunludur!", exception.Message);
    }

    [Fact]
    public async Task Save_AktifDurum_IptalTarihiDolu_ThrowsException()
    {
        // Arrange (Hazırlık): Durum 'İptal' değil (1 = Aktif) ama İptal Tarihi girilmiş[cite: 3]
        var hataliAracDto = new AracCreateDto 
        { 
            Kod = "ARC004", 
            DurumKod = "1", 
            SozlesmeIptalTarih = new DateTime(2026, 7, 17) // Hata vermesini beklediğimiz kural ihlali[cite: 3]
        };

        // Act & Assert (Eylem ve Doğrulama)
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _aracService.CreateAsync(hataliAracDto));
        
        // Fırlatılan mesaj tam olarak analistin istediği mesaj olmalı[cite: 3]
        Assert.Equal("Durum iptal değil. Bilgi girilemez!", exception.Message);
    }

    [Fact]
    public async Task Save_SozlesmeTarih_XorVeSirali_ThrowsException_WhenOnlyOneIsFilled()
    {
        // Arrange
        var hataliAracDto = new AracCreateDto 
        { 
            Kod = "ARC005", 
            SozlesmeBaslangicTarih = new DateTime(2026, 1, 1),
            SozlesmeBitisTarih = null 
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _aracService.CreateAsync(hataliAracDto));
        
        Assert.Equal("Başlangıç ve Bitiş tarihi her ikisi de dolu veya boş olmalıdır!", exception.Message);
    }

    [Fact]
    public async Task Save_SozlesmeTarih_XorVeSirali_ThrowsException_WhenBitisIsBeforeBaslangic()
    {
        // Arrange
        var hataliAracDto = new AracCreateDto 
        { 
            Kod = "ARC006", 
            SozlesmeBaslangicTarih = new DateTime(2026, 12, 1),
            SozlesmeBitisTarih = new DateTime(2026, 1, 1) 
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _aracService.CreateAsync(hataliAracDto));
        
        Assert.Equal("Bitiş tarihi, başlangıç tarihinden önce olamaz", exception.Message);
    }

    [Fact]
    public async Task Create_DuplicateKod_ThrowsException()
    {
        // Arrange
        var yeniAracDto = new AracCreateDto 
        { 
            Kod = "ARC001",
            // Mapping sırasında null hatası almamak için tüm string alanları dolu gönderiyoruz
            DurumKod = "1", 
            MevcutKmSaat = 100,
            TipKod = "TestTip"
        };
        
        // Mock ayarı: Servis kod kontrolü yapacak
        _mockRepo.Setup(repo => repo.GetByKodAsync("ARC001"))
                 .ReturnsAsync(new Arac { Kod = "ARC001" }); 

        // Act & Assert
        // Eğer Mapping düzgün çalışırsa artık 70. satırı geçip kural kontrolüne geleceğiz!
        await Assert.ThrowsAsync<InvalidOperationException>(() => _aracService.CreateAsync(yeniAracDto));
    }
    
}