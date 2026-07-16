using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AracYonetimi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLookupSeedDataFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AracDurumlar",
                columns: new[] { "Id", "DurumAdi", "Kod", "Tanim" },
                values: new object[,]
                {
                    { 101, "Aktif", "1", "" },
                    { 102, "Pasif", "2", "" },
                    { 103, "İptal", "9", "" }
                });

            migrationBuilder.InsertData(
                table: "AracMarkalar",
                columns: new[] { "Id", "Kod", "MarkaAdi", "Tanim" },
                values: new object[,]
                {
                    { 101, "1", "Renault", "" },
                    { 102, "2", "Fiat", "" },
                    { 103, "3", "Ford", "" }
                });

            migrationBuilder.InsertData(
                table: "AracTipler",
                columns: new[] { "Id", "Kod", "Tanim", "TipAdi" },
                values: new object[,]
                {
                    { 101, "1", "", "Binek" },
                    { 102, "2", "", "Ticari" },
                    { 103, "3", "", "Arazi" }
                });

            migrationBuilder.InsertData(
                table: "Firmalar",
                columns: new[] { "Id", "Ad", "FirmaAdi", "Kod" },
                values: new object[] { 101, "Avrupa Serbest Bölgesi A.Ş.", "", "ASB-TEST" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AracDurumlar",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AracDurumlar",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AracDurumlar",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AracMarkalar",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AracMarkalar",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AracMarkalar",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AracTipler",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AracTipler",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AracTipler",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Firmalar",
                keyColumn: "Id",
                keyValue: 101);
        }
    }
}
