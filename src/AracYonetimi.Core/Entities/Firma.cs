namespace AracYonetimi.Core.Entities;
public class Firma {
    public int Id { get; set; } 
    public  string FirmaAdi { get; set; } = string.Empty;
    public  string Kod { get; set; } = string.Empty; // PK
    public  string Ad { get; set; } = string.Empty; //
}