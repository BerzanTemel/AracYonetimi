namespace AracYonetimi.Core.Entities;
public class AracTahsisTip {

    public int Id { get; set; } 
    public  string TahsisTipAdi { get; set; } = string.Empty;
    public  string Kod { get; set; } = string.Empty; // zorunlu alan
    public  string Tanim { get; set; } = string.Empty; //
}