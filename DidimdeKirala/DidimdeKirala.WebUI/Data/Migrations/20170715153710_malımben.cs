using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DidimdeKirala.WebUI.Data.Migrations
{
    public partial class malımben : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OdaSayısı",
                table: "KiralananEvler",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdaSayısı",
                table: "KiralananEvler");
        }
    }
}
