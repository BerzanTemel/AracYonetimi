using Microsoft.EntityFrameworkCore;
using AracYonetimi.Core.Entities;

namespace AracYonetimi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Arac> Araclar { get; set; }
    public DbSet<AracTip> AracTipler { get; set; }
    public DbSet<AracDurum> AracDurumlar { get; set; }
    public DbSet<AracMarka> AracMarkalar { get; set; }
    public DbSet<AracTahsisTip> AracTahsisTipler { get; set; }
    public DbSet<Firma> Firmalar { get; set; }
    public DbSet<Doviz> Dovizler { get; set; }
    public DbSet<Personel> Personeller { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- MEVCUT AYARLARIN (Buralara hiç dokunmadık) ---
        modelBuilder.Entity<Arac>().ToTable("arac");

        modelBuilder.Entity<AracTahsisTip>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<AracDurum>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<AracMarka>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<AracTip>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<Doviz>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<Firma>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<Personel>().HasIndex(x => x.Kod).IsUnique();

        // --- YENİ EKLENEN SEED (TOHUM) VERİLERİ ---
        
        // 1. Araç Durumları (İptal kodunu iş kuralımız gereği 9 yaptık)
        modelBuilder.Entity<AracDurum>().HasData(
            new AracDurum { Id = 101, Kod = "1", DurumAdi = "Aktif" },
            new AracDurum { Id = 102, Kod = "2", DurumAdi = "Pasif" },
            new AracDurum { Id = 103, Kod = "9", DurumAdi = "İptal" } 
        );

        // 2. Araç Tipleri
        modelBuilder.Entity<AracTip>().HasData(
            new AracTip { Id = 101, Kod = "1", TipAdi = "Binek" },
            new AracTip { Id = 102, Kod = "2", TipAdi = "Ticari" },
            new AracTip { Id = 103, Kod = "3", TipAdi = "Arazi" }
        );

        // 3. Araç Markaları (Önyüzde açılır liste boş kalmasın diye birkaç örnek)
        modelBuilder.Entity<AracMarka>().HasData(
            new AracMarka { Id = 101, Kod = "1", MarkaAdi = "Renault" },
            new AracMarka { Id = 102, Kod = "2", MarkaAdi = "Fiat" },
            new AracMarka { Id = 103, Kod = "3", MarkaAdi = "Ford" }
        );
        
        // 4. Firmalar
        modelBuilder.Entity<Firma>().HasData(
            new Firma { Id = 101, Kod = "ASB-TEST", Ad = "Avrupa Serbest Bölgesi A.Ş." }
        );
        // 5.Personeller İçin Otomatik Veriler
        modelBuilder.Entity<Personel>().HasData(
            new Personel { Id = 1, Kod = "PRS-01", Ad = "Ahmet", Soyad = "Yılmaz", FirmaKod = "FRM-01" },
            new Personel { Id = 2, Kod = "PRS-02", Ad = "Ayşe", Soyad = "Çelik", FirmaKod = "FRM-01" },
            new Personel { Id = 3, Kod = "PRS-03", Ad = "Mehmet", Soyad = "Kaya", FirmaKod = "FRM-02" }
        );
    }
}