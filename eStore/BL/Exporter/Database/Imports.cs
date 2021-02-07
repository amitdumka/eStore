using System.Linq;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    class Imports : IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet xs = new XSheet(path, "Imports");

            xs.AddSheet("ImportInWards", db.ImportInWards.OrderBy(c => c.InvoiceDate));
            xs.AddSheet("ImportPurchases", db.ImportPurchases.OrderBy(c => c.InvoiceDate));
            xs.AddSheet("ImportSaleItemWises", db.ImportSaleItemWises.OrderBy(c => c.InvoiceDate));
            xs.AddSheet("ImportSaleRegisters", db.ImportSaleRegisters.OrderBy(c => c.InvoiceDate));
            xs.AddSheet("ImportBookEntries", db.ImportBookEntries.OrderBy(c => c.OnDate));
            xs.AddSheet("BankStatements", db.BankStatements.OrderBy(c => c.OnDateTranscation).ThenBy(c=>c.OnDateValue));
            xs.AddSheet("ImportSearches", db.ImportSearches.OrderBy(c => c.OnDate));

            return xs.WB;
        }
    }
}

