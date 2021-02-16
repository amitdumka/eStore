using eStore.BL.Exporter.Importer;
using eStore.DL.Data;
using eStore.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace eStore.BL.Exporter.Database
{
    public class DBImport
    {
        private string PathName = "";
        private readonly string BFolder = "ExcelSheet";
        private string BasePath;
        private eStoreDbContext Db;
        private readonly UserManager<AppUser> _userManager;

        public DBImport(eStoreDbContext context,  UserManager<AppUser> userManager)
        {
            Db = context;
            _userManager = userManager;
        }

        public async System.Threading.Tasks.Task<bool> ImportDataAsync(string fileName)
        {
            XSReader xS = new XSReader(fileName);

            switch (xS.WorkBookName)
            {
                case "PayRoll":
                    xS = null;
                    ImportPayroll ip = new ImportPayroll(Db, _userManager);
                   await ip.ReadPayRollAsync(fileName);
                    break;
                case "Stores":
                    StoreInfoImport sii = new StoreInfoImport(Db);
                   await sii.ReadAsync(xS);

                    break;
                case "Tailoring":
                    TailoringImport ti = new TailoringImport(Db);
                    await ti.ReadAsync(xS);
                    break;
                case "Daily Sales":
                    DailySaleImport dsi = new DailySaleImport(Db);
                    await dsi.ReadAsync(xS);
                    break;
                default:
                    break;
            }

            return true;
        }

    }


}   