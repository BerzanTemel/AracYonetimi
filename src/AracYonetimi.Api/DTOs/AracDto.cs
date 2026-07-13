using System;

namespace AracYonetimi.Api.DTOs
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