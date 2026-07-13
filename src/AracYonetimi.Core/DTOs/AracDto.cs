using System;

namespace AracYonetimi.Core.DTOs
{
    public class AracDto
    {
        public int Id { get; set; }
        public string Plaka { get; set; } = string.Empty;
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public DateTime KayitTarihi { get; set; }
    }
}