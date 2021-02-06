using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    public class AprajitaRetailsDBExport
    {
        private readonly AprajitaRetailsDbContext _db;

        public AprajitaRetailsDBExport(AprajitaRetailsDbContext context)
        {
            _db = context;
        }
       
    }

}
