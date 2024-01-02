using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyonSitesi.Migrations
{
    /// <inheritdoc />
    public partial class SeedKullaniciData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciId", "AdminOncelik", "KullaniciAdi", "Sifre" },
                values: new object[] { 50, false, "g201210056@sakarya.edu.tr", "sau" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "KullaniciId",
                keyValue: 50);
        }
    }
}
