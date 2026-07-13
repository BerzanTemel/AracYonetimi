namespace AracYonetimi.Api.DTOs
{
    public class PersonelDto
    {
        public int Id { get; set; }
        public string Kod { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string FirmaKod { get; set; } = string.Empty;
    }
}