using System.Linq;
using System.Threading.Tasks;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    class Banking : IXSE
    {
      

        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet xs = new XSheet(path, "Banking");
            xs.AddSheet<BankAccountInfo>("BankAccountInfo", db.BankAccountInfos.OrderBy(c => c.BankAccountInfoId));
            xs.AddSheet<BankDeposit>("BankDeposits", db.BankDeposits.OrderBy(c => c.DepoDate));
            xs.AddSheet<BankWithdrawal>("BankWithdrawal", db.BankWithdrawals.OrderBy(c => c.DepoDate));
            xs.AddSheet<AccountNumber>("AccountNumber", db.AccountNumbers.OrderBy(c => c.AccountNumberId));
            xs.AddSheet<ChequesLog>("ChequeLogs", db.ChequesLogs.OrderBy(c => c.ChequesDate));
            xs.AddSheet<Bank>("Bank", db.Banks.OrderBy(c => c.BankId));

            return xs.WB;
        }

        Task<XLWorkbook> IXSE.ToExcelAsync(AprajitaRetailsDbContext db, string path)
        {
            throw new System.NotImplementedException();
        }
    }

}
