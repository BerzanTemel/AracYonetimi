using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AracYonetimi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedLookupData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Personeller",
                columns: new[] { "Id", "Ad", "FirmaKod", "Kod", "Soyad" },
                values: new object[,]
                {
                    { 1, "Ahmet", "FRM-01", "PRS-01", "Yılmaz" },
                    { 2, "Ayşe", "FRM-01", "PRS-02", "Çelik" },
                    { 3, "Mehmet", "FRM-02", "PRS-03", "Kaya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
