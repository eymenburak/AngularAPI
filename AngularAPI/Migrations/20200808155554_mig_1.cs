using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularAPI.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolge",
                columns: table => new
                {
                    BolgeID = table.Column<int>(nullable: false),
                    BolgeTanimi = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolge", x => x.BolgeID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(maxLength: 15, nullable: false),
                    Tanimi = table.Column<string>(type: "ntext", nullable: true),
                    Resim = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "MusteriDemographics",
                columns: table => new
                {
                    MusteriTypeID = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    MusteriDesc = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriDemographics", x => x.MusteriTypeID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    MusteriID = table.Column<string>(fixedLength: true, maxLength: 5, nullable: false),
                    SirketAdi = table.Column<string>(maxLength: 40, nullable: false),
                    MusteriAdi = table.Column<string>(maxLength: 30, nullable: true),
                    MusteriUnvani = table.Column<string>(maxLength: 30, nullable: true),
                    Adres = table.Column<string>(maxLength: 60, nullable: true),
                    Sehir = table.Column<string>(maxLength: 15, nullable: true),
                    Bolge = table.Column<string>(maxLength: 15, nullable: true),
                    PostaKodu = table.Column<string>(maxLength: 10, nullable: true),
                    Ulke = table.Column<string>(maxLength: 15, nullable: true),
                    Telefon = table.Column<string>(maxLength: 24, nullable: true),
                    Faks = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.MusteriID);
                });

            migrationBuilder.CreateTable(
                name: "Nakliyeciler",
                columns: table => new
                {
                    NakliyeciID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketAdi = table.Column<string>(maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nakliyeciler", x => x.NakliyeciID);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    PersonelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoyAdi = table.Column<string>(maxLength: 20, nullable: false),
                    Adi = table.Column<string>(maxLength: 10, nullable: false),
                    Unvan = table.Column<string>(maxLength: 30, nullable: true),
                    UnvanEki = table.Column<string>(maxLength: 25, nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    IseBaslamaTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Adres = table.Column<string>(maxLength: 60, nullable: true),
                    Sehir = table.Column<string>(maxLength: 15, nullable: true),
                    Bolge = table.Column<string>(maxLength: 15, nullable: true),
                    PostaKodu = table.Column<string>(maxLength: 10, nullable: true),
                    Ulke = table.Column<string>(maxLength: 15, nullable: true),
                    EvTelefonu = table.Column<string>(maxLength: 24, nullable: true),
                    Extension = table.Column<string>(maxLength: 4, nullable: true),
                    Fotograf = table.Column<byte[]>(type: "image", nullable: true),
                    Notlar = table.Column<string>(type: "ntext", nullable: true),
                    BagliCalistigiKisi = table.Column<int>(nullable: true),
                    FotografPath = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.PersonelID);
                    table.ForeignKey(
                        name: "FK_Personeller_Personeller",
                        column: x => x.BagliCalistigiKisi,
                        principalTable: "Personeller",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tedarikciler",
                columns: table => new
                {
                    TedarikciID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketAdi = table.Column<string>(maxLength: 40, nullable: false),
                    MusteriAdi = table.Column<string>(maxLength: 30, nullable: true),
                    MusteriUnvani = table.Column<string>(maxLength: 30, nullable: true),
                    Adres = table.Column<string>(maxLength: 60, nullable: true),
                    Sehir = table.Column<string>(maxLength: 15, nullable: true),
                    Bolge = table.Column<string>(maxLength: 15, nullable: true),
                    PostaKodu = table.Column<string>(maxLength: 10, nullable: true),
                    Ulke = table.Column<string>(maxLength: 15, nullable: true),
                    Telefon = table.Column<string>(maxLength: 24, nullable: true),
                    Faks = table.Column<string>(maxLength: 24, nullable: true),
                    WebSayfasi = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tedarikciler", x => x.TedarikciID);
                });

            migrationBuilder.CreateTable(
                name: "Bolgeler",
                columns: table => new
                {
                    TerritoryID = table.Column<string>(maxLength: 20, nullable: false),
                    TerritoryTanimi = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false),
                    BolgeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolgeler", x => x.TerritoryID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Bolgeler_Bolge",
                        column: x => x.BolgeID,
                        principalTable: "Bolge",
                        principalColumn: "BolgeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusteriMusteriDemo",
                columns: table => new
                {
                    MusteriID = table.Column<string>(fixedLength: true, maxLength: 5, nullable: false),
                    MusteriTypeID = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriMusteriDemo", x => new { x.MusteriID, x.MusteriTypeID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_MusteriMusteriDemo_Musteriler",
                        column: x => x.MusteriID,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusteriMusteriDemo",
                        column: x => x.MusteriTypeID,
                        principalTable: "MusteriDemographics",
                        principalColumn: "MusteriTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    SatisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriID = table.Column<string>(fixedLength: true, maxLength: 5, nullable: true),
                    PersonelID = table.Column<int>(nullable: true),
                    SatisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    SevkTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipVia = table.Column<int>(nullable: true),
                    NakliyeUcreti = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    SevkAdi = table.Column<string>(maxLength: 40, nullable: true),
                    SevkAdresi = table.Column<string>(maxLength: 60, nullable: true),
                    SevkSehri = table.Column<string>(maxLength: 15, nullable: true),
                    SevkBolgesi = table.Column<string>(maxLength: 15, nullable: true),
                    SevkPostaKodu = table.Column<string>(maxLength: 10, nullable: true),
                    SevkUlkesi = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.SatisID);
                    table.ForeignKey(
                        name: "FK_Satislar_Musteriler",
                        column: x => x.MusteriID,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Satislar_Personeller",
                        column: x => x.PersonelID,
                        principalTable: "Personeller",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Satislar_Nakliyeciler",
                        column: x => x.ShipVia,
                        principalTable: "Nakliyeciler",
                        principalColumn: "NakliyeciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(maxLength: 40, nullable: false),
                    TedarikciID = table.Column<int>(nullable: true),
                    KategoriID = table.Column<int>(nullable: true),
                    BirimdekiMiktar = table.Column<string>(maxLength: 20, nullable: true),
                    BirimFiyati = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    HedefStokDuzeyi = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    YeniSatis = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    EnAzYenidenSatisMikatari = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    Sonlandi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunID);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Urunler_Tedarikciler",
                        column: x => x.TedarikciID,
                        principalTable: "Tedarikciler",
                        principalColumn: "TedarikciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonelBolgeler",
                columns: table => new
                {
                    PersonelID = table.Column<int>(nullable: false),
                    TerritoryID = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelBolgeler", x => new { x.PersonelID, x.TerritoryID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PersonelBolgeler_Personeller",
                        column: x => x.PersonelID,
                        principalTable: "Personeller",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonelBolgeler_Bolgeler",
                        column: x => x.TerritoryID,
                        principalTable: "Bolgeler",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Satis Detaylari",
                columns: table => new
                {
                    SatisID = table.Column<int>(nullable: false),
                    UrunID = table.Column<int>(nullable: false),
                    BirimFiyati = table.Column<decimal>(type: "money", nullable: false),
                    Miktar = table.Column<short>(nullable: false, defaultValueSql: "((1))"),
                    İndirim = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => new { x.SatisID, x.UrunID });
                    table.ForeignKey(
                        name: "FK_Order_Details_Satislar",
                        column: x => x.SatisID,
                        principalTable: "Satislar",
                        principalColumn: "SatisID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Details_Urunler",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolgeler_BolgeID",
                table: "Bolgeler",
                column: "BolgeID");

            migrationBuilder.CreateIndex(
                name: "KategoriAdi",
                table: "Kategoriler",
                column: "KategoriAdi");

            migrationBuilder.CreateIndex(
                name: "Bolge",
                table: "Musteriler",
                column: "Bolge");

            migrationBuilder.CreateIndex(
                name: "PostaKodu",
                table: "Musteriler",
                column: "PostaKodu");

            migrationBuilder.CreateIndex(
                name: "Sehir",
                table: "Musteriler",
                column: "Sehir");

            migrationBuilder.CreateIndex(
                name: "SirketAdi",
                table: "Musteriler",
                column: "SirketAdi");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriMusteriDemo_MusteriTypeID",
                table: "MusteriMusteriDemo",
                column: "MusteriTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelBolgeler_TerritoryID",
                table: "PersonelBolgeler",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_BagliCalistigiKisi",
                table: "Personeller",
                column: "BagliCalistigiKisi");

            migrationBuilder.CreateIndex(
                name: "PostaKodu",
                table: "Personeller",
                column: "PostaKodu");

            migrationBuilder.CreateIndex(
                name: "SoyAdi",
                table: "Personeller",
                column: "SoyAdi");

            migrationBuilder.CreateIndex(
                name: "SatislarOrder_Details",
                table: "Satis Detaylari",
                column: "SatisID");

            migrationBuilder.CreateIndex(
                name: "UrunlerOrder_Details",
                table: "Satis Detaylari",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "MusterilerSatislar",
                table: "Satislar",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "PersonellerSatislar",
                table: "Satislar",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "SatisTarihi",
                table: "Satislar",
                column: "SatisTarihi");

            migrationBuilder.CreateIndex(
                name: "SevkPostaKodu",
                table: "Satislar",
                column: "SevkPostaKodu");

            migrationBuilder.CreateIndex(
                name: "SevkTarihi",
                table: "Satislar",
                column: "SevkTarihi");

            migrationBuilder.CreateIndex(
                name: "NakliyecilerSatislar",
                table: "Satislar",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "PostaKodu",
                table: "Tedarikciler",
                column: "PostaKodu");

            migrationBuilder.CreateIndex(
                name: "SirketAdi",
                table: "Tedarikciler",
                column: "SirketAdi");

            migrationBuilder.CreateIndex(
                name: "KategorilerUrunler",
                table: "Urunler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "TedarikcilerUrunler",
                table: "Urunler",
                column: "TedarikciID");

            migrationBuilder.CreateIndex(
                name: "UrunAdi",
                table: "Urunler",
                column: "UrunAdi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusteriMusteriDemo");

            migrationBuilder.DropTable(
                name: "PersonelBolgeler");

            migrationBuilder.DropTable(
                name: "Satis Detaylari");

            migrationBuilder.DropTable(
                name: "MusteriDemographics");

            migrationBuilder.DropTable(
                name: "Bolgeler");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Bolge");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "Nakliyeciler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Tedarikciler");
        }
    }
}
