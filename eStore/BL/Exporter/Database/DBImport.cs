using eStore.DL.Data;

namespace eStore.BL.Exporter.Database
{
    public class DBImport
    {
        private string PathName = "";
        private readonly string BFolder = "ExcelSheet";
        private string BasePath;
        private eStoreDbContext Db;
        public DBImport(eStoreDbContext context)
        {
            Db = context;
        }

        public bool ImportData(string fileName)
        {
            ImportPayroll iP = new ImportPayroll(Db);
            iP.ReadPayRoll(fileName);
            return true;
        }

    }


}
