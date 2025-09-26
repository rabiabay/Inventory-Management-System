using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokYonetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class TumTablolar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depo",
                columns: table => new
                {
                    DepoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepoAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SorumluPersonelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depo", x => x.DepoID);
                });

            migrationBuilder.CreateTable(
                name: "Etiket",
                columns: table => new
                {
                    EtiketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtiketAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiket", x => x.EtiketID);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Tedarikci",
                columns: table => new
                {
                    TedarikciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tedarikci", x => x.TedarikciID);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Barkod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Birim = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    KritikStok = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.UrunID);
                    table.ForeignKey(
                        name: "FK_Urun_Kategori_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategori",
                        principalColumn: "KategoriID");
                });

            migrationBuilder.CreateTable(
                name: "ZamanlanmisIslem",
                columns: table => new
                {
                    IslemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CronIfadesi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamanlanmisIslem", x => x.IslemID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SifreHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanici_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "Yetki",
                columns: table => new
                {
                    YetkiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    TabloAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YetkiTuru = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetki", x => x.YetkiID);
                    table.ForeignKey(
                        name: "FK_Yetki_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TedarikciID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK_Siparis_Tedarikci_TedarikciID",
                        column: x => x.TedarikciID,
                        principalTable: "Tedarikci",
                        principalColumn: "TedarikciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    StokID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    DepoID = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.StokID);
                    table.ForeignKey(
                        name: "FK_Stok_Depo_DepoID",
                        column: x => x.DepoID,
                        principalTable: "Depo",
                        principalColumn: "DepoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stok_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StokHareketi",
                columns: table => new
                {
                    HareketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    DepoID = table.Column<int>(type: "int", nullable: false),
                    HareketTipi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KullaniciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHareketi", x => x.HareketID);
                    table.ForeignKey(
                        name: "FK_StokHareketi_Depo_DepoID",
                        column: x => x.DepoID,
                        principalTable: "Depo",
                        principalColumn: "DepoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StokHareketi_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UrunEtiket",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    EtiketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunEtiket", x => new { x.UrunID, x.EtiketID });
                    table.ForeignKey(
                        name: "FK_UrunEtiket_Etiket_EtiketID",
                        column: x => x.EtiketID,
                        principalTable: "Etiket",
                        principalColumn: "EtiketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunEtiket_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bildirim",
                columns: table => new
                {
                    BildirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OkunduMu = table.Column<bool>(type: "bit", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bildirim", x => x.BildirimID);
                    table.ForeignKey(
                        name: "FK_Bildirim_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriUrunler",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriUrunler", x => new { x.KullaniciID, x.UrunID });
                    table.ForeignKey(
                        name: "FK_FavoriUrunler_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriUrunler_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabloAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IslemTuru = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    KullaniciID = table.Column<int>(type: "int", nullable: true),
                    Zaman = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_Log_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID");
                });

            migrationBuilder.CreateTable(
                name: "LoginLog",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: true),
                    GirisZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Basarili = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginLog", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_LoginLog_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID");
                });

            migrationBuilder.CreateTable(
                name: "RaporLog",
                columns: table => new
                {
                    RaporLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    RaporAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlinmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporLog", x => x.RaporLogID);
                    table.ForeignKey(
                        name: "FK_RaporLog_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaporSablonu",
                columns: table => new
                {
                    RaporID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaporAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SorguMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturanKullaniciID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporSablonu", x => x.RaporID);
                    table.ForeignKey(
                        name: "FK_RaporSablonu_Kullanici_OlusturanKullaniciID",
                        column: x => x.OlusturanKullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    FaturaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.FaturaID);
                    table.ForeignKey(
                        name: "FK_Fatura_Siparis_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparis",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetay",
                columns: table => new
                {
                    SiparisDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetay", x => x.SiparisDetayID);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Siparis_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparis",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaturaDetay",
                columns: table => new
                {
                    FaturaDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaID = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaDetay", x => x.FaturaDetayID);
                    table.ForeignKey(
                        name: "FK_FaturaDetay_Fatura_FaturaID",
                        column: x => x.FaturaID,
                        principalTable: "Fatura",
                        principalColumn: "FaturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaDetay_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bildirim_KullaniciID",
                table: "Bildirim",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Fatura_SiparisID",
                table: "Fatura",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_FaturaID",
                table: "FaturaDetay",
                column: "FaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetay_UrunID",
                table: "FaturaDetay",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriUrunler_UrunID",
                table: "FavoriUrunler",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_RolID",
                table: "Kullanici",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_KullaniciID",
                table: "Log",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_LoginLog_KullaniciID",
                table: "LoginLog",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_RaporLog_KullaniciID",
                table: "RaporLog",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_RaporSablonu_OlusturanKullaniciID",
                table: "RaporSablonu",
                column: "OlusturanKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_TedarikciID",
                table: "Siparis",
                column: "TedarikciID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisID",
                table: "SiparisDetay",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_UrunID",
                table: "SiparisDetay",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_DepoID",
                table: "Stok",
                column: "DepoID");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_UrunID",
                table: "Stok",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketi_DepoID",
                table: "StokHareketi",
                column: "DepoID");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketi_UrunID",
                table: "StokHareketi",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriID",
                table: "Urun",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_UrunEtiket_EtiketID",
                table: "UrunEtiket",
                column: "EtiketID");

            migrationBuilder.CreateIndex(
                name: "IX_Yetki_RolID",
                table: "Yetki",
                column: "RolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bildirim");

            migrationBuilder.DropTable(
                name: "FaturaDetay");

            migrationBuilder.DropTable(
                name: "FavoriUrunler");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "LoginLog");

            migrationBuilder.DropTable(
                name: "RaporLog");

            migrationBuilder.DropTable(
                name: "RaporSablonu");

            migrationBuilder.DropTable(
                name: "SiparisDetay");

            migrationBuilder.DropTable(
                name: "Stok");

            migrationBuilder.DropTable(
                name: "StokHareketi");

            migrationBuilder.DropTable(
                name: "UrunEtiket");

            migrationBuilder.DropTable(
                name: "Yetki");

            migrationBuilder.DropTable(
                name: "ZamanlanmisIslem");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Depo");

            migrationBuilder.DropTable(
                name: "Etiket");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Tedarikci");
        }
    }
}
