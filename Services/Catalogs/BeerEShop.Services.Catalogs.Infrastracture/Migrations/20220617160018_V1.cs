using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerEShop.Services.Catalogs.Infrastracture.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "breweries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "breweries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "breweries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "breweries",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "breweries");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "breweries");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "breweries");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "breweries");
        }
    }
}
