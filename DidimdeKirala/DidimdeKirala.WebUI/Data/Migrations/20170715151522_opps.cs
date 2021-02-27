using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DidimdeKirala.WebUI.Data.Migrations
{
    public partial class opps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IlanFiyatı",
                table: "KiralananEvler",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IlanFiyatı",
                table: "KiralananEvler");
        }
    }
}
