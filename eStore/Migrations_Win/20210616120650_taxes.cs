using Microsoft.EntityFrameworkCore.Migrations;

namespace eStore.Migrations
{
    public partial class taxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDatas",
                columns: table => new
                {
                    BrandName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BARCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "money", nullable: false),
                    TaxDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDatas", x => x.BrandName);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxNameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxType = table.Column<int>(type: "int", nullable: false),
                    CompositeRate = table.Column<decimal>(type: "money", nullable: false),
                    OutPutTax = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxNameId);
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxNameId", "CompositeRate", "Name", "OutPutTax", "TaxType" },
                values: new object[,]
                {
                    { 1, 5m, "Local Output GST@ 5%  ", false, 0 },
                    { 2, 12m, "Local Output GST@ 12%  ", false, 0 },
                    { 3, 5m, "Output IGST@ 5%  ", false, 3 },
                    { 4, 12m, "Output IGST@ 12%  ", false, 3 },
                    { 5, 5m, "Output Vat@ 12%  ", false, 4 },
                    { 6, 12m, "Output VAT@ 5%  ", false, 4 },
                    { 7, 0m, "Output Vat Free  ", false, 4 },
                    { 8, 5m, "Local Input GST@ 5%  ", true, 0 },
                    { 9, 12m, "Local Input GST@ 12%  ", true, 0 },
                    { 10, 5m, "Input IGST@ 5%  ", true, 3 },
                    { 11, 12m, "Input IGST@ 12%  ", true, 3 },
                    { 12, 5m, "Input Vat@ 12%  ", true, 4 },
                    { 13, 12m, "Input VAT@ 5%  ", true, 4 },
                    { 14, 0m, "Input Vat Free  ", true, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDatas");

            migrationBuilder.DropTable(
                name: "Taxes");
        }
    }
}
