using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class voyager2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrandName",
                table: "VoyBrandNames",
                newName: "BRANDNAME");

            migrationBuilder.RenameColumn(
                name: "BrandCode",
                table: "VoyBrandNames",
                newName: "BRANDCODE");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceDate",
                table: "TaxRegisters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductLists",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BRANDNAME",
                table: "VoyBrandNames",
                newName: "BrandName");

            migrationBuilder.RenameColumn(
                name: "BRANDCODE",
                table: "VoyBrandNames",
                newName: "BrandCode");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                table: "TaxRegisters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "ProductLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
