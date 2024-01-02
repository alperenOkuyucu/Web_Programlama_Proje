using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UcakRezervasyonSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminOncelikToKullanici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminOncelik",
                table: "Kullanicilar",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminOncelik",
                table: "Kullanicilar");
        }
    }
}
