using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addkopyabirim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KopyaBirimler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KopyaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KutuphaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KonumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    RafSira = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KopyaBirimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KopyaBirimler_Konumlar_KonumId",
                        column: x => x.KonumId,
                        principalTable: "Konumlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KopyaBirimler_Kopyalar_KopyaId",
                        column: x => x.KopyaId,
                        principalTable: "Kopyalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KopyaBirimler_Kutuphaneler_KutuphaneId",
                        column: x => x.KutuphaneId,
                        principalTable: "Kutuphaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KopyaBirimler_Barkod",
                table: "KopyaBirimler",
                column: "Barkod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KopyaBirimler_KonumId_RafSira",
                table: "KopyaBirimler",
                columns: new[] { "KonumId", "RafSira" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KopyaBirimler_KopyaId",
                table: "KopyaBirimler",
                column: "KopyaId");

            migrationBuilder.CreateIndex(
                name: "IX_KopyaBirimler_KutuphaneId",
                table: "KopyaBirimler",
                column: "KutuphaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KopyaBirimler");
        }
    }
}
