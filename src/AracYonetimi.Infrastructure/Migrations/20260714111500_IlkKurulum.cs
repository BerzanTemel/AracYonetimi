using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AracYonetimi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IlkKurulum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Araclar",
                table: "Araclar");

            migrationBuilder.RenameTable(
                name: "Araclar",
                newName: "arac");

            migrationBuilder.RenameColumn(
                name: "Marka",
                table: "arac",
                newName: "TipKod");

            migrationBuilder.RenameColumn(
                name: "KayitTarihi",
                table: "arac",
                newName: "CreatedTime");

            migrationBuilder.AlterColumn<string>(
                name: "Plaka",
                table: "arac",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BakimBildirim",
                table: "arac",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BakimOransalSinir",
                table: "arac",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BakimPeriyot",
                table: "arac",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByModule",
                table: "arac",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "arac",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DemirbasKod",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmanKod",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DovizKod",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DurumKod",
                table: "arac",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirmaKod",
                table: "arac",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "IlkKmSaat",
                table: "arac",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Iptal",
                table: "arac",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KmSaatKontrol",
                table: "arac",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "KmSaatSinir",
                table: "arac",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kod",
                table: "arac",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MarkaKod",
                table: "arac",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MevcutKmSaat",
                table: "arac",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Onay",
                table: "arac",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PersonelAdSoyad",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelKod",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SahipFirmaKod",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seri",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SorumluKod",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SozlesmeBaslangicTarih",
                table: "arac",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SozlesmeBitisTarih",
                table: "arac",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SozlesmeIptalTarih",
                table: "arac",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TahsisTipKod",
                table: "arac",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TesisKod",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tutar",
                table: "arac",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByModule",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUser",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "arac",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VitesTip",
                table: "arac",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_arac",
                table: "arac",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_arac",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "BakimBildirim",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "BakimOransalSinir",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "BakimPeriyot",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "CreatedByModule",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "DemirbasKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "DepartmanKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "DovizKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "DurumKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "FirmaKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "IlkKmSaat",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "Iptal",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "KmSaatKontrol",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "KmSaatSinir",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "Kod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "MarkaKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "MevcutKmSaat",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "Onay",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "PersonelAdSoyad",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "PersonelKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "SahipFirmaKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "Seri",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "SorumluKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "SozlesmeBaslangicTarih",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "SozlesmeBitisTarih",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "SozlesmeIptalTarih",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "TahsisTipKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "TesisKod",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "UpdatedByModule",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "arac");

            migrationBuilder.DropColumn(
                name: "VitesTip",
                table: "arac");

            migrationBuilder.RenameTable(
                name: "arac",
                newName: "Araclar");

            migrationBuilder.RenameColumn(
                name: "TipKod",
                table: "Araclar",
                newName: "Marka");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Araclar",
                newName: "KayitTarihi");

            migrationBuilder.AlterColumn<string>(
                name: "Plaka",
                table: "Araclar",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Araclar",
                table: "Araclar",
                column: "Id");
        }
    }
}
