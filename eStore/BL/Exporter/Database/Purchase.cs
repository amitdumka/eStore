using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace eStore.BL.Exporter.Database
{
    class Purchase : IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet xs = new XSheet(path, "Purchase");

            xs.AddSheet("Brand"/*Expenses*/, db.Brands.OrderBy(c => c.BrandId));
            xs.AddSheet("Category"/*Payments*/, db.Categories.OrderBy(c => c.CategoryId));
            xs.AddSheet("ProductItem"/*Receipts*/, db.ProductItems.OrderBy(c => c.Barcode));
            xs.AddSheet("Supplier"/*CashReceipts*/, db.Suppliers.OrderBy(c => c.SuppilerName));
            xs.AddSheet("Stock"/*CashPayments*/, db.Stocks.OrderBy(c => c.ProductItemId));
            xs.AddSheet("PurchaseItem"/*PettyCashExpenses*/, db.PurchaseItems.OrderBy(c => c.PurchaseItemId));
            xs.AddSheet("PurchaseTaxType"/*ArvindPayments*/, db.PurchaseTaxTypes.OrderBy(c => c.PurchaseTaxTypeId));

            return xs.WB;
        }

        Task<XLWorkbook> IXSE.ToExcelAsync(AprajitaRetailsDbContext db, string path)
        {
            throw new System.NotImplementedException();
        }
    }
}




