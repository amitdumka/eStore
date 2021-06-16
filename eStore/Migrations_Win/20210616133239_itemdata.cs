using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class itemdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemDatas",
                table: "ItemDatas");

            migrationBuilder.AlterColumn<string>(
                name: "BARCODE",
                table: "ItemDatas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "ItemDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemDatas",
                table: "ItemDatas",
                column: "BARCODE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemDatas",
                table: "ItemDatas");

            migrationBuilder.AlterColumn<string>(
                name: "BrandName",
                table: "ItemDatas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BARCODE",
                table: "ItemDatas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemDatas",
                table: "ItemDatas",
                column: "BrandName");
        }
    }
}
