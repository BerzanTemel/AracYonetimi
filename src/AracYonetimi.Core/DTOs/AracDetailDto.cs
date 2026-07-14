using System;

namespace AracYonetimi.Core.DTOs
{
    public class AracDetailDto
    {
        public int Id { get; set; }
        
        // --- Temel Bilgiler ---
        public string Kod { get; set; } = string.Empty;
        public string TipKod { get; set; } = string.Empty;
        public string Plaka { get; set; } = string.Empty;
        public string MarkaKod { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string TahsisTipKod { get; set; } = string.Empty;
        public string? SahipFirmaKod { get; set; }
        public string? PersonelKod { get; set; }
        public string DurumKod { get; set; } = string.Empty;
        public string? Aciklama { get; set; }

        // --- Sözleşme Bilgileri ---
        public DateTime? SozlesmeBaslangicTarih { get; set; }
        public DateTime? SozlesmeBitisTarih { get; set; }
        public DateTime? SozlesmeIptalTarih { get; set; } 
        public string? DovizKod { get; set; }
        public decimal? Tutar { get; set; }

        // --- Km/Saat Bilgileri ---
        public int? MevcutKmSaat { get; set; }
        public int? KmSaatSinir { get; set; }
        public int? BakimPeriyot { get; set; }
        public bool KmSaatKontrol { get; set; }
        public bool BakimBildirim { get; set; }

        // --- Sistem Bilgileri ---
        public bool Onay { get; set; }
        public bool Iptal { get; set; }
    }
}