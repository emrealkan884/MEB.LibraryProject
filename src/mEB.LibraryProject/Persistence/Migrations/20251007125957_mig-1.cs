using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eserler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DilKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeweyKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcVerisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EserTipi = table.Column<int>(type: "int", nullable: false),
                    Kategori = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eserler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kutuphaneler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KurumTuru = table.Column<int>(type: "int", nullable: false),
                    UstKutuphaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kutuphaneler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kutuphaneler_Kutuphaneler_UstKutuphaneId",
                        column: x => x.UstKutuphaneId,
                        principalTable: "Kutuphaneler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YayinEvleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinEvleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SayfaSayisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasimYili = table.Column<short>(type: "smallint", nullable: false),
                    BasimYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaskiBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Eserler_Id",
                        column: x => x.Id,
                        principalTable: "Eserler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Konumlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KutuphaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UstKonumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KonumTip = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Konumlar_Konumlar_UstKonumId",
                        column: x => x.UstKonumId,
                        principalTable: "Konumlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Konumlar_Kutuphaneler_KutuphaneId",
                        column: x => x.KutuphaneId,
                        principalTable: "Kutuphaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EserlerYazarlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YazarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EserlerYazarlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EserlerYazarlar_Eserler_EserId",
                        column: x => x.EserId,
                        principalTable: "Eserler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EserlerYazarlar_Yazarlar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitaplarYayinEvleri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KitapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YayinEviId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitaplarYayinEvleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitaplarYayinEvleri_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitaplarYayinEvleri_YayinEvleri_YayinEviId",
                        column: x => x.YayinEviId,
                        principalTable: "YayinEvleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kopyalar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KitapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KutuphaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kopyalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kopyalar_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kopyalar_Kutuphaneler_KutuphaneId",
                        column: x => x.KutuphaneId,
                        principalTable: "Kutuphaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KopyalarKonumlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KopyaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KonumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KutuphaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KopyalarKonumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KopyalarKonumlar_Konumlar_KonumId",
                        column: x => x.KonumId,
                        principalTable: "Konumlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KopyalarKonumlar_Kopyalar_KopyaId",
                        column: x => x.KopyaId,
                        principalTable: "Kopyalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KopyalarKonumlar_Kutuphaneler_KutuphaneId",
                        column: x => x.KutuphaneId,
                        principalTable: "Kutuphaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oduncler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KopyaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KutuphaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OduncAlmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GercekTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oduncler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oduncler_Kopyalar_KopyaId",
                        column: x => x.KopyaId,
                        principalTable: "Kopyalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oduncler_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oduncler_Kutuphaneler_KutuphaneId",
                        column: x => x.KutuphaneId,
                        principalTable: "Kutuphaneler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EserlerYazarlar_EserId",
                table: "EserlerYazarlar",
                column: "EserId");

            migrationBuilder.CreateIndex(
                name: "IX_EserlerYazarlar_YazarId",
                table: "EserlerYazarlar",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_KitaplarYayinEvleri_KitapId",
                table: "KitaplarYayinEvleri",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_KitaplarYayinEvleri_YayinEviId",
                table: "KitaplarYayinEvleri",
                column: "YayinEviId");

            migrationBuilder.CreateIndex(
                name: "IX_Konumlar_KutuphaneId",
                table: "Konumlar",
                column: "KutuphaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Konumlar_UstKonumId",
                table: "Konumlar",
                column: "UstKonumId");

            migrationBuilder.CreateIndex(
                name: "IX_Kopyalar_KitapId",
                table: "Kopyalar",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_Kopyalar_KutuphaneId",
                table: "Kopyalar",
                column: "KutuphaneId");

            migrationBuilder.CreateIndex(
                name: "IX_KopyalarKonumlar_KonumId",
                table: "KopyalarKonumlar",
                column: "KonumId");

            migrationBuilder.CreateIndex(
                name: "IX_KopyalarKonumlar_KopyaId",
                table: "KopyalarKonumlar",
                column: "KopyaId");

            migrationBuilder.CreateIndex(
                name: "IX_KopyalarKonumlar_KutuphaneId",
                table: "KopyalarKonumlar",
                column: "KutuphaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Kutuphaneler_UstKutuphaneId",
                table: "Kutuphaneler",
                column: "UstKutuphaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Oduncler_KopyaId",
                table: "Oduncler",
                column: "KopyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oduncler_KullaniciId",
                table: "Oduncler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Oduncler_KutuphaneId",
                table: "Oduncler",
                column: "KutuphaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EserlerYazarlar");

            migrationBuilder.DropTable(
                name: "KitaplarYayinEvleri");

            migrationBuilder.DropTable(
                name: "KopyalarKonumlar");

            migrationBuilder.DropTable(
                name: "Oduncler");

            migrationBuilder.DropTable(
                name: "Yazarlar");

            migrationBuilder.DropTable(
                name: "YayinEvleri");

            migrationBuilder.DropTable(
                name: "Konumlar");

            migrationBuilder.DropTable(
                name: "Kopyalar");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Kutuphaneler");

            migrationBuilder.DropTable(
                name: "Eserler");
        }
    }
}
