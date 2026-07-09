namespace AracYonetimi.Core.Entities;
public class AracDurum {
    
    public int Id { get; set; } 
    public  string DurumAdi { get; set; } = string.Empty;
    public  string Kod { get; set; } = string.Empty; // PK
    public  string Tanim { get; set; } = string.Empty; //
}