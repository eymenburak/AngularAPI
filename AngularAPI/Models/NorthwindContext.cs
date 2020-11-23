using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngularAPI.Models
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlfabetikSiraliUrunlerListesi> AlfabetikSiraliUrunlerListesi { get; set; }
        public virtual DbSet<AyrintiliSatisDetaylari> AyrintiliSatisDetaylari { get; set; }
        public virtual DbSet<BitenUrunlerListesi> BitenUrunlerListesi { get; set; }
        public virtual DbSet<Bolge> Bolge { get; set; }
        public virtual DbSet<Bolgeler> Bolgeler { get; set; }
        public virtual DbSet<Faturalar> Faturalar { get; set; }
        public virtual DbSet<HerUcAylikSatislar> HerUcAylikSatislar { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<KategorilereGore1997YiliSatislari> KategorilereGore1997YiliSatislari { get; set; }
        public virtual DbSet<KategorilereGoreSatislar> KategorilereGoreSatislar { get; set; }
        public virtual DbSet<KategorilereGoreUrunler> KategorilereGoreUrunler { get; set; }
        public virtual DbSet<MusteriDemographics> MusteriDemographics { get; set; }
        public virtual DbSet<MusteriMusteriDemo> MusteriMusteriDemo { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<Nakliyeciler> Nakliyeciler { get; set; }
        public virtual DbSet<OrtalamaMaliyetinUzerindekiUrunler> OrtalamaMaliyetinUzerindekiUrunler { get; set; }
        public virtual DbSet<OzetCeyrekSatislar> OzetCeyrekSatislar { get; set; }
        public virtual DbSet<OzetYillikSatislar> OzetYillikSatislar { get; set; }
        public virtual DbSet<PersonelBolgeler> PersonelBolgeler { get; set; }
        public virtual DbSet<Personeller> Personeller { get; set; }
        public virtual DbSet<SatisAltToplamlari> SatisAltToplamlari { get; set; }
        public virtual DbSet<SatisDetaylari> SatisDetaylari { get; set; }
        public virtual DbSet<Satislar> Satislar { get; set; }
        public virtual DbSet<SatislarSorgusu> SatislarSorgusu { get; set; }
        public virtual DbSet<SatislarinToplamMiktari> SatislarinToplamMiktari { get; set; }
        public virtual DbSet<SehirlereGoreMusteriVeTedarikciler> SehirlereGoreMusteriVeTedarikciler { get; set; }
        public virtual DbSet<Tedarikciler> Tedarikciler { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }


        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<_1997YiliUrunSatislari> _1997YiliUrunSatislari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Northwind;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlfabetikSiraliUrunlerListesi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Alfabetik Sirali Urunler Listesi");

                entity.Property(e => e.BirimFiyati).HasColumnType("money");

                entity.Property(e => e.BirimdekiMiktar).HasMaxLength(20);

                entity.Property(e => e.KategoriAdi)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.TedarikciId).HasColumnName("TedarikciID");

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.UrunId).HasColumnName("UrunID");
            });

            modelBuilder.Entity<AyrintiliSatisDetaylari>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ayrintili Satis Detaylari");

                entity.Property(e => e.BirimFiyati).HasColumnType("money");

                entity.Property(e => e.ExtendedPrice).HasColumnType("money");

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.UrunId).HasColumnName("UrunID");
            });

            modelBuilder.Entity<BitenUrunlerListesi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Biten Urunler Listesi");

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.UrunId)
                    .HasColumnName("UrunID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Bolge>(entity =>
            {
                entity.HasKey(e => e.BolgeId)
                    .IsClustered(false);

                entity.Property(e => e.BolgeId)
                    .HasColumnName("BolgeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BolgeTanimi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Bolgeler>(entity =>
            {
                entity.HasKey(e => e.TerritoryId)
                    .IsClustered(false);

                entity.Property(e => e.TerritoryId)
                    .HasColumnName("TerritoryID")
                    .HasMaxLength(20);

                entity.Property(e => e.BolgeId).HasColumnName("BolgeID");

                entity.Property(e => e.TerritoryTanimi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Bolge)
                    .WithMany(p => p.Bolgeler)
                    .HasForeignKey(d => d.BolgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bolgeler_Bolge");
            });

            modelBuilder.Entity<Faturalar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Faturalar");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.BirimFiyati).HasColumnType("money");

                entity.Property(e => e.Bolge).HasMaxLength(15);

                entity.Property(e => e.ExtendedPrice).HasColumnType("money");

                entity.Property(e => e.MusteriId)
                    .HasColumnName("MusteriID")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MusteriName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.NakliyeUcreti).HasColumnType("money");

                entity.Property(e => e.NakliyeciName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.PersonelSatislari)
                    .IsRequired()
                    .HasMaxLength(31);

                entity.Property(e => e.PostaKodu).HasMaxLength(10);

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.SatisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Sehir).HasMaxLength(15);

                entity.Property(e => e.SevkAdi).HasMaxLength(40);

                entity.Property(e => e.SevkAdresi).HasMaxLength(60);

                entity.Property(e => e.SevkBolgesi).HasMaxLength(15);

                entity.Property(e => e.SevkPostaKodu).HasMaxLength(10);

                entity.Property(e => e.SevkSehri).HasMaxLength(15);

                entity.Property(e => e.SevkTarihi).HasColumnType("datetime");

                entity.Property(e => e.SevkUlkesi).HasMaxLength(15);

                entity.Property(e => e.Ulke).HasMaxLength(15);

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.UrunId).HasColumnName("UrunID");
            });

            modelBuilder.Entity<HerUcAylikSatislar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Her Uc Aylik Satislar");

                entity.Property(e => e.MusteriId)
                    .HasColumnName("MusteriID")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Sehir).HasMaxLength(15);

                entity.Property(e => e.SirketAdi).HasMaxLength(40);

                entity.Property(e => e.Ulke).HasMaxLength(15);
            });

            modelBuilder.Entity<Kategoriler>(entity =>
            {
                entity.HasKey(e => e.KategoriId);

                entity.HasIndex(e => e.KategoriAdi)
                    .HasName("KategoriAdi");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.KategoriAdi)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.Tanimi).HasColumnType("ntext");
            });

            modelBuilder.Entity<KategorilereGore1997YiliSatislari>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kategorilere Gore 1997 Yili Satislari");

                entity.Property(e => e.KategoriAdi)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.KategoriSales).HasColumnType("money");
            });

            modelBuilder.Entity<KategorilereGoreSatislar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kategorilere Gore Satislar");

                entity.Property(e => e.KategoriAdi)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Urunlerales).HasColumnType("money");
            });

            modelBuilder.Entity<KategorilereGoreUrunler>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Kategorilere Gore Urunler");

                entity.Property(e => e.BirimdekiMiktar).HasMaxLength(20);

                entity.Property(e => e.KategoriAdi)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<MusteriDemographics>(entity =>
            {
                entity.HasKey(e => e.MusteriTypeId)
                    .IsClustered(false);

                entity.Property(e => e.MusteriTypeId)
                    .HasColumnName("MusteriTypeID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MusteriDesc).HasColumnType("ntext");
            });

            modelBuilder.Entity<MusteriMusteriDemo>(entity =>
            {
                entity.HasKey(e => new { e.MusteriId, e.MusteriTypeId })
                    .IsClustered(false);

                entity.Property(e => e.MusteriId)
                    .HasColumnName("MusteriID")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MusteriTypeId)
                    .HasColumnName("MusteriTypeID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.MusteriMusteriDemo)
                    .HasForeignKey(d => d.MusteriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MusteriMusteriDemo_Musteriler");

                entity.HasOne(d => d.MusteriType)
                    .WithMany(p => p.MusteriMusteriDemo)
                    .HasForeignKey(d => d.MusteriTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MusteriMusteriDemo");
            });

            modelBuilder.Entity<Musteriler>(entity =>
            {
                entity.HasKey(e => e.MusteriId);

                entity.HasIndex(e => e.Bolge)
                    .HasName("Bolge");

                entity.HasIndex(e => e.PostaKodu)
                    .HasName("PostaKodu");

                entity.HasIndex(e => e.Sehir)
                    .HasName("Sehir");

                entity.HasIndex(e => e.SirketAdi)
                    .HasName("SirketAdi");

                entity.Property(e => e.MusteriId)
                    .HasColumnName("MusteriID")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Bolge).HasMaxLength(15);

                entity.Property(e => e.Faks).HasMaxLength(24);

                entity.Property(e => e.MusteriAdi).HasMaxLength(30);

                entity.Property(e => e.MusteriUnvani).HasMaxLength(30);

                entity.Property(e => e.PostaKodu).HasMaxLength(10);

                entity.Property(e => e.Sehir).HasMaxLength(15);

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(24);

                entity.Property(e => e.Ulke).HasMaxLength(15);
            });

            modelBuilder.Entity<Nakliyeciler>(entity =>
            {
                entity.HasKey(e => e.NakliyeciId);

                entity.Property(e => e.NakliyeciId).HasColumnName("NakliyeciID");

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(24);
            });

            modelBuilder.Entity<OrtalamaMaliyetinUzerindekiUrunler>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ortalama Maliyetin Uzerindeki Urunler");

                entity.Property(e => e.BirimFiyati).HasColumnType("money");

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<OzetCeyrekSatislar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ozet Ceyrek Satislar");

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.SevkTarihi).HasColumnType("datetime");

                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<OzetYillikSatislar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ozet Yillik Satislar");

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.SevkTarihi).HasColumnType("datetime");

                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<PersonelBolgeler>(entity =>
            {
                entity.HasKey(e => new { e.PersonelId, e.TerritoryId })
                    .IsClustered(false);

                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

                entity.Property(e => e.TerritoryId)
                    .HasColumnName("TerritoryID")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.PersonelBolgeler)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonelBolgeler_Personeller");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.PersonelBolgeler)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonelBolgeler_Bolgeler");
            });

            modelBuilder.Entity<Personeller>(entity =>
            {
                entity.HasKey(e => e.PersonelId);

                entity.HasIndex(e => e.PostaKodu)
                    .HasName("PostaKodu");

                entity.HasIndex(e => e.SoyAdi)
                    .HasName("SoyAdi");

                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Bolge).HasMaxLength(15);

                entity.Property(e => e.DogumTarihi).HasColumnType("datetime");

                entity.Property(e => e.EvTelefonu).HasMaxLength(24);

                entity.Property(e => e.Extension).HasMaxLength(4);

                entity.Property(e => e.Fotograf).HasColumnType("image");

                entity.Property(e => e.FotografPath).HasMaxLength(255);

                entity.Property(e => e.IseBaslamaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Notlar).HasColumnType("ntext");

                entity.Property(e => e.PostaKodu).HasMaxLength(10);

                entity.Property(e => e.Sehir).HasMaxLength(15);

                entity.Property(e => e.SoyAdi)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Ulke).HasMaxLength(15);

                entity.Property(e => e.Unvan).HasMaxLength(30);

                entity.Property(e => e.UnvanEki).HasMaxLength(25);

                entity.HasOne(d => d.BagliCalistigiKisiNavigation)
                    .WithMany(p => p.InverseBagliCalistigiKisiNavigation)
                    .HasForeignKey(d => d.BagliCalistigiKisi)
                    .HasConstraintName("FK_Personeller_Personeller");
            });

            modelBuilder.Entity<SatisAltToplamlari>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Satis Alt Toplamlari");

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            modelBuilder.Entity<SatisDetaylari>(entity =>
            {
                entity.HasKey(e => new { e.SatisId, e.UrunId })
                    .HasName("PK_Order_Details");

                entity.ToTable("Satis Detaylari");

                entity.HasIndex(e => e.SatisId)
                    .HasName("SatislarOrder_Details");

                entity.HasIndex(e => e.UrunId)
                    .HasName("UrunlerOrder_Details");

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.BirimFiyati).HasColumnType("money");

                entity.Property(e => e.Miktar).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Satis)
                    .WithMany(p => p.SatisDetaylari)
                    .HasForeignKey(d => d.SatisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Satislar");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.SatisDetaylari)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Urunler");
            });

            modelBuilder.Entity<Satislar>(entity =>
            {
                entity.HasKey(e => e.SatisId);

                entity.HasIndex(e => e.MusteriId)
                    .HasName("MusterilerSatislar");

                entity.HasIndex(e => e.PersonelId)
                    .HasName("PersonellerSatislar");

                entity.HasIndex(e => e.SatisTarihi)
                    .HasName("SatisTarihi");

                entity.HasIndex(e => e.SevkPostaKodu)
                    .HasName("SevkPostaKodu");

                entity.HasIndex(e => e.SevkTarihi)
                    .HasName("SevkTarihi");

                entity.HasIndex(e => e.ShipVia)
                    .HasName("NakliyecilerSatislar");

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.MusteriId)
                    .HasColumnName("MusteriID")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.NakliyeUcreti)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

                entity.Property(e => e.SatisTarihi).HasColumnType("datetime");

                entity.Property(e => e.SevkAdi).HasMaxLength(40);

                entity.Property(e => e.SevkAdresi).HasMaxLength(60);

                entity.Property(e => e.SevkBolgesi).HasMaxLength(15);

                entity.Property(e => e.SevkPostaKodu).HasMaxLength(10);

                entity.Property(e => e.SevkSehri).HasMaxLength(15);

                entity.Property(e => e.SevkTarihi).HasColumnType("datetime");

                entity.Property(e => e.SevkUlkesi).HasMaxLength(15);

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.Satislar)
                    .HasForeignKey(d => d.MusteriId)
                    .HasConstraintName("FK_Satislar_Musteriler");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.Satislar)
                    .HasForeignKey(d => d.PersonelId)
                    .HasConstraintName("FK_Satislar_Personeller");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Satislar)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Satislar_Nakliyeciler");
            });

            modelBuilder.Entity<SatislarSorgusu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Satislar Sorgusu");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Bolge).HasMaxLength(15);

                entity.Property(e => e.MusteriId)
                    .HasColumnName("MusteriID")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.NakliyeUcreti).HasColumnType("money");

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.PersonelId).HasColumnName("PersonelID");

                entity.Property(e => e.PostaKodu).HasMaxLength(10);

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.SatisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Sehir).HasMaxLength(15);

                entity.Property(e => e.SevkAdi).HasMaxLength(40);

                entity.Property(e => e.SevkAdresi).HasMaxLength(60);

                entity.Property(e => e.SevkBolgesi).HasMaxLength(15);

                entity.Property(e => e.SevkPostaKodu).HasMaxLength(10);

                entity.Property(e => e.SevkSehri).HasMaxLength(15);

                entity.Property(e => e.SevkTarihi).HasColumnType("datetime");

                entity.Property(e => e.SevkUlkesi).HasMaxLength(15);

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Ulke).HasMaxLength(15);
            });

            modelBuilder.Entity<SatislarinToplamMiktari>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Satislarin Toplam Miktari");

                entity.Property(e => e.SaleAmount).HasColumnType("money");

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.SevkTarihi).HasColumnType("datetime");

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<SehirlereGoreMusteriVeTedarikciler>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sehirlere Gore Musteri ve Tedarikciler");

                entity.Property(e => e.MusteriAdi).HasMaxLength(30);

                entity.Property(e => e.Relationship)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Sehir).HasMaxLength(15);

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Tedarikciler>(entity =>
            {
                entity.HasKey(e => e.TedarikciId);

                entity.HasIndex(e => e.PostaKodu)
                    .HasName("PostaKodu");

                entity.HasIndex(e => e.SirketAdi)
                    .HasName("SirketAdi");

                entity.Property(e => e.TedarikciId).HasColumnName("TedarikciID");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Bolge).HasMaxLength(15);

                entity.Property(e => e.Faks).HasMaxLength(24);

                entity.Property(e => e.MusteriAdi).HasMaxLength(30);

                entity.Property(e => e.MusteriUnvani).HasMaxLength(30);

                entity.Property(e => e.PostaKodu).HasMaxLength(10);

                entity.Property(e => e.Sehir).HasMaxLength(15);

                entity.Property(e => e.SirketAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(24);

                entity.Property(e => e.Ulke).HasMaxLength(15);

                entity.Property(e => e.WebSayfasi).HasColumnType("ntext");
            });

            modelBuilder.Entity<Urunler>(entity =>
            {
                entity.HasKey(e => e.UrunId);

                entity.HasIndex(e => e.KategoriId)
                    .HasName("KategorilerUrunler");

                entity.HasIndex(e => e.TedarikciId)
                    .HasName("TedarikcilerUrunler");

                entity.HasIndex(e => e.UrunAdi)
                    .HasName("UrunAdi");

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.BirimFiyati)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BirimdekiMiktar).HasMaxLength(20);

                entity.Property(e => e.EnAzYenidenSatisMikatari).HasDefaultValueSql("((0))");

                entity.Property(e => e.HedefStokDuzeyi).HasDefaultValueSql("((0))");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.TedarikciId).HasColumnName("TedarikciID");

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.YeniSatis).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Urunler)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Urunler_Kategoriler");

                entity.HasOne(d => d.Tedarikci)
                    .WithMany(p => p.Urunler)
                    .HasForeignKey(d => d.TedarikciId)
                    .HasConstraintName("FK_Urunler_Tedarikciler");
            });

            modelBuilder.Entity<_1997YiliUrunSatislari>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("1997 Yili Urun Satislari");

                entity.Property(e => e.KategoriAdi)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UrunAdi)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Urunlerales).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
