using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeweySiniflamalar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kod = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeweySiniflamalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DijitalIcerikler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tur = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DijitalIcerikler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcKayitlari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Yazarlik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YayinYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YayinTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcKayitlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcAlanlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarcKaydiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ind1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ind2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcAlanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarcAlanlar_MarcKayitlari_MarcKaydiId",
                        column: x => x.MarcKaydiId,
                        principalTable: "MarcKayitlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeweySiniflamalar_Kod",
                table: "DeweySiniflamalar",
                column: "Kod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarcAlanlar_MarcKaydiId_Tag",
                table: "MarcAlanlar",
                columns: new[] { "MarcKaydiId", "Tag" });

            migrationBuilder.CreateIndex(
                name: "IX_MarcKayitlari_Isbn",
                table: "MarcKayitlari",
                column: "Isbn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeweySiniflamalar");

            migrationBuilder.DropTable(
                name: "DijitalIcerikler");

            migrationBuilder.DropTable(
                name: "MarcAlanlar");

            migrationBuilder.DropTable(
                name: "MarcKayitlari");
        }
    }
}
