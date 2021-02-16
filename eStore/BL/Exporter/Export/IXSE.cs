using ClosedXML.Excel;
using eStore.ImportDatabase.Data;
using System.Threading.Tasks;

namespace eStore.BL.Exporter.Database
{
    interface IXSE
    {
        public Task<XLWorkbook> ToExcelAsync(AprajitaRetailsDbContext db, string path);
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path);
    }

}
