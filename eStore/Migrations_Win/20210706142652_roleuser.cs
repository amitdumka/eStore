using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class roleuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ProductItems_ProductItemBarcode",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductItemBarcode",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductItemBarcode",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "BarCode",
                table: "Stocks",
                newName: "Barcode");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegisteredUserId",
                table: "RegisteredUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "RegisteredUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "RegisteredUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Barcode",
                table: "Stocks",
                column: "Barcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ProductItems_Barcode",
                table: "Stocks",
                column: "Barcode",
                principalTable: "ProductItems",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ProductItems_Barcode",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_Barcode",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "RegisteredUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "RegisteredUsers");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Stocks",
                newName: "BarCode");

            migrationBuilder.AlterColumn<string>(
                name: "BarCode",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductItemBarcode",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RegisteredUserId",
                table: "RegisteredUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductItemBarcode",
                table: "Stocks",
                column: "ProductItemBarcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ProductItems_ProductItemBarcode",
                table: "Stocks",
                column: "ProductItemBarcode",
                principalTable: "ProductItems",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
