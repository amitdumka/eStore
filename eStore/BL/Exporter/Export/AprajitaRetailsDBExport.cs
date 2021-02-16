using System;
using System.IO;
using System.IO.Compression;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    public class AprajitaRetailsDBExport
    {
        private readonly AprajitaRetailsDbContext _db;
        private string PathName = "";
        private readonly string BFolder = "ExcelSheet";
        private string BasePath;

        public AprajitaRetailsDBExport(AprajitaRetailsDbContext context, string bpath)
        {
            _db = context;
            BasePath = bpath;
        }

        public string DownloadFirstToExcell()
        {
            // Create Store Data First
            string bpath = Path.Combine(BasePath, BFolder, DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString());
            string path = Path.Combine(bpath, DateTime.Today.Day.ToString());
            Console.WriteLine(bpath);
            Console.WriteLine(path);
            using (new Stores().ToExcel(_db, path)) { }
            using (new Banking().ToExcel(_db, path)) { }
            using (new BasicSale().ToExcel(_db, path)) { }
            using (new Expenses().ToExcel(_db, path)) { }

            string ZipFileName = Path.Combine(bpath, "AprajitaRetailsDBExp_" + DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year + DateTime.UtcNow.ToFileTimeUtc().ToString() + ".zip");
            ZipFolder(path, ZipFileName);
            return ZipFileName;

        }

        public string DownloadSecondToExcel()
        {
            // Create Store Data First
            string bpath = Path.Combine(BasePath, BFolder, DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString());
            string path = Path.Combine(bpath, DateTime.Today.Day.ToString());
            Console.WriteLine(bpath);
            Console.WriteLine(path);

            
            using (new Tailoring().ToExcel(_db, path)) { }
            using (new Imports().ToExcel(_db, path)) { }

            string ZipFileName = Path.Combine(bpath, "AprajitaRetailsDBExp_" + DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year+DateTime.UtcNow.ToFileTimeUtc().ToString() + ".zip");
            ZipFolder(path, ZipFileName);
            return ZipFileName;
        }

        public string DownloadThirdToExcel()
        {
            // Create Store Data First
            string bpath = Path.Combine(BasePath, BFolder, DateTime.Today.Year.ToString(), DateTime.Today.Month.ToString());
            string path = Path.Combine(bpath, DateTime.Today.Day.ToString());
            Console.WriteLine(bpath);
            Console.WriteLine(path);

            using (new Payroll().ToExcel(_db, path)) { }
            using (new Purchase().ToExcel(_db, path)) { }

           
            string ZipFileName = Path.Combine(bpath, "AprajitaRetailsDBExp_" + DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year + DateTime.UtcNow.ToFileTimeUtc().ToString() + ".zip");
            ZipFolder(path, ZipFileName);
            return ZipFileName;
        }

        private void ZipFolder(string sourceFolder,string zipFileName)
        {
             
            ZipFile.CreateFromDirectory(sourceFolder, zipFileName);
            Directory.Delete(sourceFolder,true);
        }

    }

}
