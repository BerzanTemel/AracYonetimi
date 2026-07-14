using System;

namespace AracYonetimi.Core.DTOs
{
    public class AracListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; } = string.Empty;
        public string Plaka { get; set; } = string.Empty;
        public string MarkaKod { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string TipKod { get; set; } = string.Empty;
        public string TahsisTipKod { get; set; } = string.Empty;
        public string DurumKod { get; set; } = string.Empty;
        public bool Onay { get; set; }
        public bool Iptal { get; set; }
    }
}