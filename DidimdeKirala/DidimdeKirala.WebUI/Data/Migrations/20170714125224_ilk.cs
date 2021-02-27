using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DidimdeKirala.WebUI.Data.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "EmlakTipleri",
                columns: table => new
                {
                    EmlakTipiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmlakTipiAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmlakTipleri", x => x.EmlakTipiID);
                });

            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    IlceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IlceAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.IlceID);
                });

            migrationBuilder.CreateTable(
                name: "Mahalleler",
                columns: table => new
                {
                    MahalleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IlceID = table.Column<int>(nullable: false),
                    MahalleAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalleler", x => x.MahalleID);
                    table.ForeignKey(
                        name: "FK_Mahalleler_Ilceler_IlceID",
                        column: x => x.IlceID,
                        principalTable: "Ilceler",
                        principalColumn: "IlceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KiralananEvler",
                columns: table => new
                {
                    KiralikEvlerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktifmi = table.Column<bool>(nullable: false),
                    BanyoSayısı = table.Column<int>(nullable: false),
                    BinaYasi = table.Column<int>(nullable: false),
                    BulunduguKat = table.Column<int>(nullable: false),
                    DegismeTarihi = table.Column<DateTime>(nullable: false),
                    EmlakTipiID = table.Column<int>(nullable: false),
                    Esyalımı = table.Column<bool>(nullable: false),
                    HaritaBoylam = table.Column<string>(nullable: true),
                    HaritaEnlem = table.Column<string>(nullable: true),
                    IlanAcıklama = table.Column<string>(nullable: true),
                    IlanBaslik = table.Column<string>(nullable: true),
                    IlanTarihi = table.Column<string>(nullable: true),
                    Isıtma = table.Column<string>(nullable: true),
                    KatSayısı = table.Column<int>(nullable: false),
                    M2 = table.Column<int>(nullable: false),
                    MahalleID = table.Column<int>(nullable: false),
                    SeciliIlkResimID = table.Column<int>(nullable: false),
                    SiteIcindemi = table.Column<bool>(nullable: false),
                    YaratılmaTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiralananEvler", x => x.KiralikEvlerID);
                    table.ForeignKey(
                        name: "FK_KiralananEvler_EmlakTipleri_EmlakTipiID",
                        column: x => x.EmlakTipiID,
                        principalTable: "EmlakTipleri",
                        principalColumn: "EmlakTipiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KiralananEvler_Mahalleler_MahalleID",
                        column: x => x.MahalleID,
                        principalTable: "Mahalleler",
                        principalColumn: "MahalleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmlaginResimleri",
                columns: table => new
                {
                    EmlakResimleriID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KiralikEvlerID = table.Column<int>(nullable: false),
                    ResimdosyaAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmlaginResimleri", x => x.EmlakResimleriID);
                    table.ForeignKey(
                        name: "FK_EmlaginResimleri_KiralananEvler_KiralikEvlerID",
                        column: x => x.KiralikEvlerID,
                        principalTable: "KiralananEvler",
                        principalColumn: "KiralikEvlerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resim360lar",
                columns: table => new
                {
                    Resim360ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KiralikEvlerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resim360lar", x => x.Resim360ID);
                    table.ForeignKey(
                        name: "FK_Resim360lar_KiralananEvler_KiralikEvlerID",
                        column: x => x.KiralikEvlerID,
                        principalTable: "KiralananEvler",
                        principalColumn: "KiralikEvlerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmlaginResimleri_KiralikEvlerID",
                table: "EmlaginResimleri",
                column: "KiralikEvlerID");

            migrationBuilder.CreateIndex(
                name: "IX_KiralananEvler_EmlakTipiID",
                table: "KiralananEvler",
                column: "EmlakTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_KiralananEvler_MahalleID",
                table: "KiralananEvler",
                column: "MahalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Mahalleler_IlceID",
                table: "Mahalleler",
                column: "IlceID");

            migrationBuilder.CreateIndex(
                name: "IX_Resim360lar_KiralikEvlerID",
                table: "Resim360lar",
                column: "KiralikEvlerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmlaginResimleri");

            migrationBuilder.DropTable(
                name: "Resim360lar");

            migrationBuilder.DropTable(
                name: "KiralananEvler");

            migrationBuilder.DropTable(
                name: "EmlakTipleri");

            migrationBuilder.DropTable(
                name: "Mahalleler");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
