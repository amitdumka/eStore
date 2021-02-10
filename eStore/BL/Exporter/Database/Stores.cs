using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace eStore.BL.Exporter.Database
{
    class Stores : IXSE
    {
        public async System.Threading.Tasks.Task<XLWorkbook> ToExcelAsync(AprajitaRetailsDbContext db, string path)
        {
            XSheet XS = new XSheet(path, "Stores");
            XS.AddSheet<Store>("Stores",await  db.Stores.OrderBy(c => c.City).ToListAsync());
            XS.AddSheet<EndOfDay>("EndOfDays", db.EndOfDays.OrderBy(c => c.EOD_Date));
            XS.AddSheet<Shared.Models.Stores.Customer>("Customers", db.Customers.OrderBy(c => c.FirstName));
            XS.AddSheet<Contact>("Contacts", db.Contact.OrderBy(c => c.FirstName));
            XS.AddSheet<CashDetail>("CashDetails", db.CashDetail.OrderBy(c => c.OnDate));

            return XS.WB;
        }

        

        public  XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet XS = new XSheet(path, "Stores");
            XS.AddSheet<Store>("Stores",  db.Stores.OrderBy(c => c.City));
            XS.AddSheet<EndOfDay>("EndOfDays", db.EndOfDays.OrderBy(c => c.EOD_Date));
            XS.AddSheet<Shared.Models.Stores.Customer>("Customers", db.Customers.OrderBy(c => c.FirstName));
            XS.AddSheet<Contact>("Contacts", db.Contact.OrderBy(c => c.FirstName));
            XS.AddSheet<CashDetail>("CashDetails", db.CashDetail.OrderBy(c => c.OnDate));

            return XS.WB;
        }
    }

}
