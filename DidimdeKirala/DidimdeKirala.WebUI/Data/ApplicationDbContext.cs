using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DidimdeKirala.WebUI.Models;

namespace DidimdeKirala.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<KiralikEvler> KiralananEvler { get; set; }
        public DbSet<EmlakTipi> EmlakTipleri { get; set; }
        public DbSet<EmlakResimleri> EmlaginResimleri { get; set; }
        public DbSet<Resim360> Resim360lar { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Mahalle> Mahalleler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class KiralikEvler
    {
        public int KiralikEvlerID { get; set; }
        public string IlanBaslik { get; set; }
        public string IlanAcıklama { get; set; }
        public string IlanTarihi { get; set; }
        public string IlanFiyatı { get; set; }
        public string OdaSayısı { get; set; }
        public int EmlakTipiID { get; set; }
        public EmlakTipi EmlakinTipi { get; set; }
        public int M2 { get; set; }
        public int BinaYasi { get; set; }
        public int BulunduguKat { get; set; }
        public int KatSayısı { get; set; }
        public string Isıtma { get; set; }
        public int BanyoSayısı { get; set; }
        public bool Esyalımı { get; set; }
        public bool SiteIcindemi { get; set; }

        public List<EmlakResimleri> Resimler { get; set; }
        public int SeciliIlkResimID { get; set; }
        public List<Resim360> Resim360lar { get; set; }

        public string HaritaEnlem { get; set; }
        public string HaritaBoylam { get; set; }
        public int MahalleID { get; set; }
        public Mahalle KiralıkEvinMahallesi { get; set; }

        public DateTime YaratılmaTarihi { get; set; }
        public DateTime DegismeTarihi { get; set; }
        public bool Aktifmi { get; set; }
    }
    public class EmlakTipi
    {
        public int EmlakTipiID { get; set; }
        public string EmlakTipiAdi { get; set; }
        public List<KiralikEvler> TipinEvleri { get; set; }
    }
    public class EmlakResimleri
    {
        public int EmlakResimleriID { get; set; }
        public int KiralikEvlerID { get; set; }
        public KiralikEvler ResminEvi { get; set; }
        public string ResimdosyaAd { get; set; }
    }
    public class Resim360
    {
        public int Resim360ID { get; set; }
    }
    public class Ilce {
        public int IlceID { get; set; }
        public string IlceAd { get; set; }
        public List<Mahalle> IlcedekiMahalleler { get; set; }
    }
    public class Mahalle {
        public int MahalleID { get; set; }
        public string MahalleAd { get; set; }
        public int IlceID { get; set; }
        public Ilce MahalleninIlcesi { get; set; }
        public List<KiralikEvler> KiralıkEvler { get; set; }
    }
}
