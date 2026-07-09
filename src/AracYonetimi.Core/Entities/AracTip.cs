namespace AracYonetimi.Core.Entities;
public class AracTip {
    public int Id { get; set; } 
    public  string TipAdi { get; set; } = string.Empty;
    public  string Kod { get; set; } = string.Empty; // PK
    public  string Tanim { get; set; } = string.Empty; //
}