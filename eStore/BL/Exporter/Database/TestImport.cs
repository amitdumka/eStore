using System;
using System.Data;
using eStore.DL.Data;
using eStore.Shared.Models.Payroll;
using Newtonsoft.Json;

namespace eStore.BL.Exporter.Database
{
    class TestImport
    {
        public DataTable TestImportExcel(eStoreDbContext db, string fileName)
        {
            Console.WriteLine(fileName);
            XSReader xS = new XSReader(fileName);

            var ws = xS.GetWS("Employees");
            var dt = XSReader.ReadSheetToDt(ws, 6);
            int c = dt.Columns.IndexOf("UserName");
            dt.Columns[c].ColumnName = "UserId";
            dt.Columns.Add("EntryStatus");
            dt.Columns.Add("IsReadOnly");
            int c1 = 101;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["EntryStatus"] = EntryStatus.Added;
                dt.Rows[i]["IsReadOnly"] = true;
                dt.Rows[i][0] = ((i + 1 * 201) * c1 / 3) * i;
                c1 = c1 + new Random(c1).Next();
            }
            dt.AcceptChanges();
            //JsonConvert.SerializeObject(dt);
            //
            var lst = CommonMethod.ConvertToList<Employee>(dt);
            //var lst = DAL.CreateListFromTable<Employee>(dt);
            db.Employees.AddRange(lst);
            Console.WriteLine(JsonConvert.SerializeObject(dt));
            Console.WriteLine("Save: " + db.SaveChanges());


            return dt;

        }
    }


}
