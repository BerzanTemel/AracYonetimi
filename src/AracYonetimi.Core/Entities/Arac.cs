using System;

namespace AracYonetimi.Core.Entities
{
    public class Arac
    {
        // Anahtar Kelime (Primary Key)
        public int Id { get; set; }

        // --- Temel Bilgiler ---
        public string Kod { get; set; } = string.Empty;
        public string FirmaKod { get; set; } = string.Empty;
        public string? TesisKod { get; set; }
        public string TipKod { get; set; } = string.Empty;
        public string? Plaka { get; set; }
        public string MarkaKod { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string? Seri { get; set; }
        public string? VitesTip { get; set; }
        public string TahsisTipKod { get; set; } = string.Empty;
        public string? SahipFirmaKod { get; set; }
        public string? PersonelKod { get; set; }
        public string? PersonelAdSoyad { get; set; }
        public string? SorumluKod { get; set; }
        public string? DepartmanKod { get; set; }
        public string? DemirbasKod { get; set; }
        public string DurumKod { get; set; } = string.Empty;
        public string? Aciklama { get; set; }

        // --- Sözleşme ve Finans Bilgileri ---
        public string? DovizKod { get; set; }
        public decimal? Tutar { get; set; }
        public DateTime? SozlesmeBaslangicTarih { get; set; }
        public DateTime? SozlesmeBitisTarih { get; set; }
        public DateTime? SozlesmeIptalTarih { get; set; }

        // --- Km/Saat ve Bakım Bilgileri ---
        public decimal IlkKmSaat { get; set; }
        public int? MevcutKmSaat { get; set; }
        public int? KmSaatSinir { get; set; }
        public bool KmSaatKontrol { get; set; }
        public int? BakimPeriyot { get; set; }
        public int? BakimOransalSinir { get; set; }
        public bool BakimBildirim { get; set; }

        // --- Sistem ve Durum Bayrakları ---
        public bool Onay { get; set; }
        public bool Iptal { get; set; }

        // --- Denetim (Audit) Alanları ---
        public string CreatedByUser { get; set; } = string.Empty;
        public string CreatedByModule { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; }
        public string? UpdatedByUser { get; set; }
        public string? UpdatedByModule { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}