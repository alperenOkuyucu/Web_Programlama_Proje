using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UcakRezervasyonSitesi.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimaryKeyToKoltukYapisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Ucaklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Model = table.Column<string>(type: "text", nullable: false),
                    KoltukFiyati = table.Column<decimal>(type: "numeric", nullable: false),
                    VarisNoktalari = table.Column<List<string>>(type: "text[]", nullable: false),
                    KoltukDuzeniKoltukYapisiId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucaklar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ucaklar_KoltukYapisi_KoltukDuzeniKoltukYapisiId",
                        column: x => x.KoltukDuzeniKoltukYapisiId,
                        principalTable: "KoltukYapisi",
                        principalColumn: "KoltukYapisiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ucaklar_KoltukDuzeniKoltukYapisiId",
                table: "Ucaklar",
                column: "KoltukDuzeniKoltukYapisiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ucaklar");

            migrationBuilder.DropTable(
                name: "KoltukYapisi");
        }
    }
}
