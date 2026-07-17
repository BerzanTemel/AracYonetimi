using System;

namespace AracYonetimi.Core.DTOs
{
    public class AracCreateDto
    {
        // --- 1. Grup: Temel Bilgiler ---
        public string Kod { get; set; } = string.Empty;
        public string TipKod { get; set; } = string.Empty;
        public string Plaka { get; set; } = string.Empty;
        public string MarkaKod { get; set; } = string.Empty; // Lookup'tan geleceği için 'Kod' eki var
        public string Model { get; set; } = string.Empty;
        public string TahsisTipKod { get; set; } = string.Empty;
        public string? SahipFirmaKod { get; set; }
        public string? PersonelKod { get; set; }
        public string DurumKod { get; set; } = string.Empty;
        public string? Aciklama { get; set; }

        // --- 2. Grup: Sözleşme Bilgileri ---
        public DateTime? SozlesmeBaslangicTarih { get; set; }
        public DateTime? SozlesmeBitisTarih { get; set; }
        public DateTime? SozlesmeIptalTarih { get; set; }
        public string? DovizKod { get; set; }
        public decimal? Tutar { get; set; }

        // --- 3. Grup: Km/Saat Bilgileri ---
        public int? MevcutKmSaat { get; set; }
        public int? KmSaatSinir { get; set; }
        public int? BakimPeriyot { get; set; }
        public bool KmSaatKontrol { get; set; }
        public bool BakimBildirim { get; set; }
    }
}