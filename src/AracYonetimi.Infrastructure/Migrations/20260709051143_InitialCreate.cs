using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AracYonetimi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AracDurumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DurumAdi = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    Tanim = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracDurumlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Plaka = table.Column<string>(type: "text", nullable: false),
                    Marka = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AracMarkalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MarkaAdi = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    Tanim = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracMarkalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AracTahsisTipler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TahsisTipAdi = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    Tanim = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracTahsisTipler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AracTipler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipAdi = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    Tanim = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracTipler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dovizler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DovizCinsi = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    Tanim = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dovizler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firmalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirmaAdi = table.Column<string>(type: "text", nullable: false),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    Ad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    FirmaKod = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AracDurumlar_Kod",
                table: "AracDurumlar",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AracMarkalar_Kod",
                table: "AracMarkalar",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AracTahsisTipler_Kod",
                table: "AracTahsisTipler",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AracTipler_Kod",
                table: "AracTipler",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dovizler_Kod",
                table: "Dovizler",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firmalar_Kod",
                table: "Firmalar",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_Kod",
                table: "Personeller",
                column: "Kod",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AracDurumlar");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "AracMarkalar");

            migrationBuilder.DropTable(
                name: "AracTahsisTipler");

            migrationBuilder.DropTable(
                name: "AracTipler");

            migrationBuilder.DropTable(
                name: "Dovizler");

            migrationBuilder.DropTable(
                name: "Firmalar");

            migrationBuilder.DropTable(
                name: "Personeller");
        }
    }
}
