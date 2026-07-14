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

        modelBuilder.Entity<Arac>().ToTable("arac");

        modelBuilder.Entity<AracTahsisTip>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<AracDurum>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<AracMarka>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<AracTip>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<Doviz>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<Firma>().HasIndex(x => x.Kod).IsUnique();
        modelBuilder.Entity<Personel>().HasIndex(x => x.Kod).IsUnique();
    }
}