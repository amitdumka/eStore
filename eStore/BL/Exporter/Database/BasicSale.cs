using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    class BasicSale : IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet xs = new XSheet(path, "Daily Sales");
            xs.AddSheet<DailySale>("DailySales", db.DailySales.OrderBy(c => c.SaleDate));
            xs.AddSheet<DueRecoverd>("DueRecovereds", db.DueRecoverds.OrderBy(c => c.PaidDate));
            xs.AddSheet<DuesList>("DueLists", db.DuesLists.OrderBy(c => c.DailySaleId));

            xs.AddSheet<EDCTranscation>("CardTranscations", db.CardTranscations.OrderBy(c => c.OnDate));
            xs.AddSheet<EDC>("CardMachine", db.CardMachine.OrderBy(c => c.EDCId));
            xs.AddSheet<Salesman>("Salesmans", db.Salesmen.OrderBy(c => c.SalesmanId));
            return xs.WB;
        }

        Task<XLWorkbook> IXSE.ToExcelAsync(AprajitaRetailsDbContext db, string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
