namespace AracYonetimi.Core.Entities;

public class Arac
{
    public int Id { get; set; }
    public string Plaka { get; set; } = string.Empty;
    public string Marka { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateTime KayitTarihi { get; set; } = DateTime.UtcNow;
}