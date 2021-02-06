using System.Linq;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    class Stores : IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet XS = new XSheet(path, "Stores");
            XS.AddSheet<Store>("EndOfDays", db.Stores.OrderBy(c => c.City));
            XS.AddSheet<EndOfDay>("EndOfDays", db.EndOfDays.OrderBy(c => c.EOD_Date));
            XS.AddSheet<Shared.Models.Stores.Customer>("EndOfDays", db.Customers.OrderBy(c => c.FullName));
            XS.AddSheet<Contact>("EndOfDays", db.Contact.OrderBy(c => c.FirstName));
            return XS.WB;
        }
    }

}
