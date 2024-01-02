using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UcakRezervasyonSitesi.Migrations
{
    /// <inheritdoc />
    public partial class YeniYeniMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucaklar_KoltukYapisi_KoltukDuzeniKoltukYapisiId",
                table: "Ucaklar");

            migrationBuilder.DropTable(
                name: "KoltukYapisi");

            migrationBuilder.DropIndex(
                name: "IX_Ucaklar_KoltukDuzeniKoltukYapisiId",
                table: "Ucaklar");

            migrationBuilder.RenameColumn(
                name: "KoltukDuzeniKoltukYapisiId",
                table: "Ucaklar",
                newName: "KoltukSutun");

            migrationBuilder.AddColumn<int>(
                name: "KoltukSatir",
                table: "Ucaklar",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KoltukSatir",
                table: "Ucaklar");

            migrationBuilder.RenameColumn(
                name: "KoltukSutun",
                table: "Ucaklar",
                newName: "KoltukDuzeniKoltukYapisiId");

            migrationBuilder.CreateTable(
                name: "KoltukYapisi",
                columns: table => new
                {
                    KoltukYapisiId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sira = table.Column<int>(type: "integer", nullable: false),
                    Sutun = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoltukYapisi", x => x.KoltukYapisiId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ucaklar_KoltukDuzeniKoltukYapisiId",
                table: "Ucaklar",
                column: "KoltukDuzeniKoltukYapisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucaklar_KoltukYapisi_KoltukDuzeniKoltukYapisiId",
                table: "Ucaklar",
                column: "KoltukDuzeniKoltukYapisiId",
                principalTable: "KoltukYapisi",
                principalColumn: "KoltukYapisiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
