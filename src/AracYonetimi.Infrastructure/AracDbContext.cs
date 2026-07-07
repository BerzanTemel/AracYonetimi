using Microsoft.EntityFrameworkCore;
using AracYonetimi.Core.Entities;

namespace AracYonetimi.Infrastructure;

public class AracDbContext : DbContext
{
    public AracDbContext(DbContextOptions<AracDbContext> options) : base(options)
    {
    }
    public DbSet<Arac> Araclar { get; set; } 
}