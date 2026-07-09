namespace AracYonetimi.Core.Entities;
public class AracMarka {
    public int Id { get; set; } 
    public  string MarkaAdi { get; set; } = string.Empty;
    public  string Kod { get; set; } = string.Empty; // PK
    public  string Tanim { get; set; } = string.Empty; //
}