using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    class Tailoring : IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet xs = new XSheet(path, "Tailoring");
            xs.AddSheet<TalioringBooking>("Bookings", db.TalioringBookings.OrderBy(c => c.BookingDate));
            xs.AddSheet<TalioringDelivery>("Deliveries", db.TailoringDeliveries.OrderBy(c => c.DeliveryDate));
            return xs.WB;
        }

        Task<XLWorkbook> IXSE.ToExcelAsync(AprajitaRetailsDbContext db, string path)
        {
            throw new System.NotImplementedException();
        }
    }

}
