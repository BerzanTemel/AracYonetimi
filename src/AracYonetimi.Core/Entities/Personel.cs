namespace AracYonetimi.Core.Entities;
public class Personel {
    public int Id { get; set; }
    public  string Kod { get; set; } = string.Empty; // PK
    public  string Ad { get; set; } = string.Empty; //
    public  string Soyad { get; set; } = string.Empty; //
    public  string FirmaKod { get; set; } = string.Empty; // FK
}