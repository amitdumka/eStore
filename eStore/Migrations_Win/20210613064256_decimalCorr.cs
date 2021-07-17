using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class decimalCorr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal> (
                name: "TotalSale",
                table: "SalesmanInfo",
                type: "money",
                nullable: false,
                oldClrType: typeof (decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal> (
                name: "LastYear",
                table: "SalesmanInfo",
                type: "money",
                nullable: false,
                oldClrType: typeof (decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal> (
                name: "LastMonth",
                table: "SalesmanInfo",
                type: "money",
                nullable: false,
                oldClrType: typeof (decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal> (
                name: "CurrentYear",
                table: "SalesmanInfo",
                type: "money",
                nullable: false,
                oldClrType: typeof (decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal> (
                name: "CurrentMonth",
                table: "SalesmanInfo",
                type: "money",
                nullable: false,
                oldClrType: typeof (decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal> (
                name: "Average",
                table: "SalesmanInfo",
                type: "money",
                nullable: false,
                oldClrType: typeof (decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RentAmount",
                table: "RentedLocations",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AdvanceAmount",
                table: "RentedLocations",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductLists",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CESS",
                table: "HSN",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                table: "DailySales",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSale",
                table: "SalesmanInfo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "LastYear",
                table: "SalesmanInfo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "LastMonth",
                table: "SalesmanInfo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentYear",
                table: "SalesmanInfo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentMonth",
                table: "SalesmanInfo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Average",
                table: "SalesmanInfo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "RentAmount",
                table: "RentedLocations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "AdvanceAmount",
                table: "RentedLocations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ProductLists",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "CESS",
                table: "HSN",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                table: "DailySales",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);
        }
    }
}
