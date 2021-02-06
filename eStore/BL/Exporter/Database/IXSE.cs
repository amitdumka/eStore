using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    interface IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path);
    }

}
