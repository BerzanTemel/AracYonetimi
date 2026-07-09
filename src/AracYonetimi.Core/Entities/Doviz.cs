namespace AracYonetimi.Core.Entities;
public class Doviz {
    public int Id { get; set; } 
    public  string DovizCinsi { get; set; } = string.Empty;
    public  string Kod { get; set; } = string.Empty; // PK
    public  string Tanim { get; set; } = string.Empty; //
}