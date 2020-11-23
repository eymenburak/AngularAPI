﻿// <auto-generated />
using System;
using AngularAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularAPI.Migrations
{
    [DbContext(typeof(NorthwindContext))]
    [Migration("20200808173903_mig_6")]
    partial class mig_6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularAPI.Models.Bolge", b =>
                {
                    b.Property<int>("BolgeId")
                        .HasColumnName("BolgeID")
                        .HasColumnType("int");

                    b.Property<string>("BolgeTanimi")
                        .IsRequired()
                        .HasColumnType("nchar(50)")
                        .IsFixedLength(true)
                        .HasMaxLength(50);

                    b.HasKey("BolgeId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Bolge");
                });

            modelBuilder.Entity("AngularAPI.Models.Bolgeler", b =>
                {
                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("BolgeId")
                        .HasColumnName("BolgeID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryTanimi")
                        .IsRequired()
                        .HasColumnType("nchar(50)")
                        .IsFixedLength(true)
                        .HasMaxLength(50);

                    b.HasKey("TerritoryId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("BolgeId");

                    b.ToTable("Bolgeler");
                });

            modelBuilder.Entity("AngularAPI.Models.Kategoriler", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("KategoriID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<byte[]>("Resim")
                        .HasColumnType("image");

                    b.Property<string>("Tanimi")
                        .HasColumnType("ntext");

                    b.HasKey("KategoriId");

                    b.HasIndex("KategoriAdi")
                        .HasName("KategoriAdi");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("AngularAPI.Models.MusteriDemographics", b =>
                {
                    b.Property<string>("MusteriTypeId")
                        .HasColumnName("MusteriTypeID")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("MusteriDesc")
                        .HasColumnType("ntext");

                    b.HasKey("MusteriTypeId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("MusteriDemographics");
                });

            modelBuilder.Entity("AngularAPI.Models.MusteriMusteriDemo", b =>
                {
                    b.Property<string>("MusteriId")
                        .HasColumnName("MusteriID")
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true)
                        .HasMaxLength(5);

                    b.Property<string>("MusteriTypeId")
                        .HasColumnName("MusteriTypeID")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.HasKey("MusteriId", "MusteriTypeId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("MusteriTypeId");

                    b.ToTable("MusteriMusteriDemo");
                });

            modelBuilder.Entity("AngularAPI.Models.Musteriler", b =>
                {
                    b.Property<string>("MusteriId")
                        .HasColumnName("MusteriID")
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true)
                        .HasMaxLength(5);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Bolge")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Faks")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("MusteriAdi")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("MusteriUnvani")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PostaKodu")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SirketAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("Ulke")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("MusteriId");

                    b.HasIndex("Bolge")
                        .HasName("Bolge");

                    b.HasIndex("PostaKodu")
                        .HasName("PostaKodu");

                    b.HasIndex("Sehir")
                        .HasName("Sehir");

                    b.HasIndex("SirketAdi")
                        .HasName("SirketAdi");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("AngularAPI.Models.Nakliyeciler", b =>
                {
                    b.Property<int>("NakliyeciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NakliyeciID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SirketAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.HasKey("NakliyeciId");

                    b.ToTable("Nakliyeciler");
                });

            modelBuilder.Entity("AngularAPI.Models.PersonelBolgeler", b =>
                {
                    b.Property<int>("PersonelId")
                        .HasColumnName("PersonelID")
                        .HasColumnType("int");

                    b.Property<string>("TerritoryId")
                        .HasColumnName("TerritoryID")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("PersonelId", "TerritoryId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("TerritoryId");

                    b.ToTable("PersonelBolgeler");
                });

            modelBuilder.Entity("AngularAPI.Models.Personeller", b =>
                {
                    b.Property<int>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PersonelID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int?>("BagliCalistigiKisi")
                        .HasColumnType("int");

                    b.Property<string>("Bolge")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("DogumTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("EvTelefonu")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<byte[]>("Fotograf")
                        .HasColumnType("image");

                    b.Property<string>("FotografPath")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("IseBaslamaTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("Notlar")
                        .HasColumnType("ntext");

                    b.Property<string>("PostaKodu")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SoyAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Ulke")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Unvan")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("UnvanEki")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("PersonelId");

                    b.HasIndex("BagliCalistigiKisi");

                    b.HasIndex("PostaKodu")
                        .HasName("PostaKodu");

                    b.HasIndex("SoyAdi")
                        .HasName("SoyAdi");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("AngularAPI.Models.SatisDetaylari", b =>
                {
                    b.Property<int>("SatisId")
                        .HasColumnName("SatisID")
                        .HasColumnType("int");

                    b.Property<int>("UrunId")
                        .HasColumnName("UrunID")
                        .HasColumnType("int");

                    b.Property<decimal>("BirimFiyati")
                        .HasColumnType("money");

                    b.Property<short>("Miktar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("((1))");

                    b.Property<float>("İndirim")
                        .HasColumnType("real");

                    b.HasKey("SatisId", "UrunId")
                        .HasName("PK_Order_Details");

                    b.HasIndex("SatisId")
                        .HasName("SatislarOrder_Details");

                    b.HasIndex("UrunId")
                        .HasName("UrunlerOrder_Details");

                    b.ToTable("Satis Detaylari");
                });

            modelBuilder.Entity("AngularAPI.Models.Satislar", b =>
                {
                    b.Property<int>("SatisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SatisID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MusteriId")
                        .HasColumnName("MusteriID")
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true)
                        .HasMaxLength(5);

                    b.Property<decimal?>("NakliyeUcreti")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("OdemeTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("PersonelId")
                        .HasColumnName("PersonelID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SatisTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("SevkAdi")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("SevkAdresi")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("SevkBolgesi")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SevkPostaKodu")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("SevkSehri")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("SevkTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("SevkUlkesi")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int?>("ShipVia")
                        .HasColumnType("int");

                    b.HasKey("SatisId");

                    b.HasIndex("MusteriId")
                        .HasName("MusterilerSatislar");

                    b.HasIndex("PersonelId")
                        .HasName("PersonellerSatislar");

                    b.HasIndex("SatisTarihi")
                        .HasName("SatisTarihi");

                    b.HasIndex("SevkPostaKodu")
                        .HasName("SevkPostaKodu");

                    b.HasIndex("SevkTarihi")
                        .HasName("SevkTarihi");

                    b.HasIndex("ShipVia")
                        .HasName("NakliyecilerSatislar");

                    b.ToTable("Satislar");
                });

            modelBuilder.Entity("AngularAPI.Models.Tedarikciler", b =>
                {
                    b.Property<int>("TedarikciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TedarikciID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Bolge")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Faks")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("MusteriAdi")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("MusteriUnvani")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PostaKodu")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Sehir")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("SirketAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(24)")
                        .HasMaxLength(24);

                    b.Property<string>("Ulke")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("WebSayfasi")
                        .HasColumnType("ntext");

                    b.HasKey("TedarikciId");

                    b.HasIndex("PostaKodu")
                        .HasName("PostaKodu");

                    b.HasIndex("SirketAdi")
                        .HasName("SirketAdi");

                    b.ToTable("Tedarikciler");
                });

            modelBuilder.Entity("AngularAPI.Models.Urunler", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UrunID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BirimFiyati")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("BirimdekiMiktar")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<short?>("EnAzYenidenSatisMikatari")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("((0))");

                    b.Property<short?>("HedefStokDuzeyi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("KategoriId")
                        .HasColumnName("KategoriID")
                        .HasColumnType("int");

                    b.Property<bool>("Sonlandi")
                        .HasColumnType("bit");

                    b.Property<int?>("TedarikciId")
                        .HasColumnName("TedarikciID")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<short?>("YeniSatis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("UrunId");

                    b.HasIndex("KategoriId")
                        .HasName("KategorilerUrunler");

                    b.HasIndex("TedarikciId")
                        .HasName("TedarikcilerUrunler");

                    b.HasIndex("UrunAdi")
                        .HasName("UrunAdi");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("AngularAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AngularAPI.Models.Bolgeler", b =>
                {
                    b.HasOne("AngularAPI.Models.Bolge", "Bolge")
                        .WithMany("Bolgeler")
                        .HasForeignKey("BolgeId")
                        .HasConstraintName("FK_Bolgeler_Bolge")
                        .IsRequired();
                });

            modelBuilder.Entity("AngularAPI.Models.MusteriMusteriDemo", b =>
                {
                    b.HasOne("AngularAPI.Models.Musteriler", "Musteri")
                        .WithMany("MusteriMusteriDemo")
                        .HasForeignKey("MusteriId")
                        .HasConstraintName("FK_MusteriMusteriDemo_Musteriler")
                        .IsRequired();

                    b.HasOne("AngularAPI.Models.MusteriDemographics", "MusteriType")
                        .WithMany("MusteriMusteriDemo")
                        .HasForeignKey("MusteriTypeId")
                        .HasConstraintName("FK_MusteriMusteriDemo")
                        .IsRequired();
                });

            modelBuilder.Entity("AngularAPI.Models.PersonelBolgeler", b =>
                {
                    b.HasOne("AngularAPI.Models.Personeller", "Personel")
                        .WithMany("PersonelBolgeler")
                        .HasForeignKey("PersonelId")
                        .HasConstraintName("FK_PersonelBolgeler_Personeller")
                        .IsRequired();

                    b.HasOne("AngularAPI.Models.Bolgeler", "Territory")
                        .WithMany("PersonelBolgeler")
                        .HasForeignKey("TerritoryId")
                        .HasConstraintName("FK_PersonelBolgeler_Bolgeler")
                        .IsRequired();
                });

            modelBuilder.Entity("AngularAPI.Models.Personeller", b =>
                {
                    b.HasOne("AngularAPI.Models.Personeller", "BagliCalistigiKisiNavigation")
                        .WithMany("InverseBagliCalistigiKisiNavigation")
                        .HasForeignKey("BagliCalistigiKisi")
                        .HasConstraintName("FK_Personeller_Personeller");
                });

            modelBuilder.Entity("AngularAPI.Models.SatisDetaylari", b =>
                {
                    b.HasOne("AngularAPI.Models.Satislar", "Satis")
                        .WithMany("SatisDetaylari")
                        .HasForeignKey("SatisId")
                        .HasConstraintName("FK_Order_Details_Satislar")
                        .IsRequired();

                    b.HasOne("AngularAPI.Models.Urunler", "Urun")
                        .WithMany("SatisDetaylari")
                        .HasForeignKey("UrunId")
                        .HasConstraintName("FK_Order_Details_Urunler")
                        .IsRequired();
                });

            modelBuilder.Entity("AngularAPI.Models.Satislar", b =>
                {
                    b.HasOne("AngularAPI.Models.Musteriler", "Musteri")
                        .WithMany("Satislar")
                        .HasForeignKey("MusteriId")
                        .HasConstraintName("FK_Satislar_Musteriler");

                    b.HasOne("AngularAPI.Models.Personeller", "Personel")
                        .WithMany("Satislar")
                        .HasForeignKey("PersonelId")
                        .HasConstraintName("FK_Satislar_Personeller");

                    b.HasOne("AngularAPI.Models.Nakliyeciler", "ShipViaNavigation")
                        .WithMany("Satislar")
                        .HasForeignKey("ShipVia")
                        .HasConstraintName("FK_Satislar_Nakliyeciler");
                });

            modelBuilder.Entity("AngularAPI.Models.Urunler", b =>
                {
                    b.HasOne("AngularAPI.Models.Kategoriler", "Kategori")
                        .WithMany("Urunler")
                        .HasForeignKey("KategoriId")
                        .HasConstraintName("FK_Urunler_Kategoriler");

                    b.HasOne("AngularAPI.Models.Tedarikciler", "Tedarikci")
                        .WithMany("Urunler")
                        .HasForeignKey("TedarikciId")
                        .HasConstraintName("FK_Urunler_Tedarikciler");
                });
#pragma warning restore 612, 618
        }
    }
}
