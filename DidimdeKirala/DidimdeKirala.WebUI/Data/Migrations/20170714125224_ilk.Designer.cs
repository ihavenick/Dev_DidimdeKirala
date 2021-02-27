using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DidimdeKirala.WebUI.Data;

namespace DidimdeKirala.WebUI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170714125224_ilk")]
    partial class ilk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.EmlakResimleri", b =>
                {
                    b.Property<int>("EmlakResimleriID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KiralikEvlerID");

                    b.Property<string>("ResimdosyaAd");

                    b.HasKey("EmlakResimleriID");

                    b.HasIndex("KiralikEvlerID");

                    b.ToTable("EmlaginResimleri");
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.EmlakTipi", b =>
                {
                    b.Property<int>("EmlakTipiID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmlakTipiAdi");

                    b.HasKey("EmlakTipiID");

                    b.ToTable("EmlakTipleri");
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.Ilce", b =>
                {
                    b.Property<int>("IlceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IlceAd");

                    b.HasKey("IlceID");

                    b.ToTable("Ilceler");
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.KiralikEvler", b =>
                {
                    b.Property<int>("KiralikEvlerID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Aktifmi");

                    b.Property<int>("BanyoSayısı");

                    b.Property<int>("BinaYasi");

                    b.Property<int>("BulunduguKat");

                    b.Property<DateTime>("DegismeTarihi");

                    b.Property<int>("EmlakTipiID");

                    b.Property<bool>("Esyalımı");

                    b.Property<string>("HaritaBoylam");

                    b.Property<string>("HaritaEnlem");

                    b.Property<string>("IlanAcıklama");

                    b.Property<string>("IlanBaslik");

                    b.Property<string>("IlanTarihi");

                    b.Property<string>("Isıtma");

                    b.Property<int>("KatSayısı");

                    b.Property<int>("M2");

                    b.Property<int>("MahalleID");

                    b.Property<int>("SeciliIlkResimID");

                    b.Property<bool>("SiteIcindemi");

                    b.Property<DateTime>("YaratılmaTarihi");

                    b.HasKey("KiralikEvlerID");

                    b.HasIndex("EmlakTipiID");

                    b.HasIndex("MahalleID");

                    b.ToTable("KiralananEvler");
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.Mahalle", b =>
                {
                    b.Property<int>("MahalleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IlceID");

                    b.Property<string>("MahalleAd");

                    b.HasKey("MahalleID");

                    b.HasIndex("IlceID");

                    b.ToTable("Mahalleler");
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.Resim360", b =>
                {
                    b.Property<int>("Resim360ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("KiralikEvlerID");

                    b.HasKey("Resim360ID");

                    b.HasIndex("KiralikEvlerID");

                    b.ToTable("Resim360lar");
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.EmlakResimleri", b =>
                {
                    b.HasOne("DidimdeKirala.WebUI.Data.KiralikEvler", "ResminEvi")
                        .WithMany("Resimler")
                        .HasForeignKey("KiralikEvlerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.KiralikEvler", b =>
                {
                    b.HasOne("DidimdeKirala.WebUI.Data.EmlakTipi", "EmlakinTipi")
                        .WithMany("TipinEvleri")
                        .HasForeignKey("EmlakTipiID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DidimdeKirala.WebUI.Data.Mahalle", "KiralıkEvinMahallesi")
                        .WithMany("KiralıkEvler")
                        .HasForeignKey("MahalleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.Mahalle", b =>
                {
                    b.HasOne("DidimdeKirala.WebUI.Data.Ilce", "MahalleninIlcesi")
                        .WithMany("IlcedekiMahalleler")
                        .HasForeignKey("IlceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DidimdeKirala.WebUI.Data.Resim360", b =>
                {
                    b.HasOne("DidimdeKirala.WebUI.Data.KiralikEvler")
                        .WithMany("Resim360lar")
                        .HasForeignKey("KiralikEvlerID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DidimdeKirala.WebUI.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DidimdeKirala.WebUI.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DidimdeKirala.WebUI.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
