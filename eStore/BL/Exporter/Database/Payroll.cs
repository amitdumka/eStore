using System.Collections.Generic;
using System.Linq;
using AprajitaRetails.ImportDatabase.Models;
using ClosedXML.Excel;
using eStore.ImportDatabase.Data;

namespace eStore.BL.Exporter.Database
{
    class Payroll : IXSE
    {
        public XLWorkbook ToExcel(AprajitaRetailsDbContext db, string path)
        {
            XSheet xs = new XSheet(path, "PayRoll");
            var empList = db.Employees.OrderBy(c => c.EmployeeId);
            xs.AddSheet<Employee>("Employees", empList);
            
            foreach (var emp in empList)
            {
                SortedList<string, string> info = new SortedList<string, string>();
                info.Add("EmployeeId", emp.EmployeeId.ToString());
                info.Add("EmployeeName", emp.StaffName);

                var attList = db.Attendances.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.AttDate);
                if (attList != null)
                     xs.AddSheet<Attendance>("Attendance", attList, $"Att_{emp.StaffName}", "Attendance_" + emp.StaffName,info);
                var SalList = db.SalaryPayments.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.PaymentDate);
                if (SalList != null)
                    xs.AddSheet<SalaryPayment>("SalaryPayments", SalList, $"Sal_{emp.StaffName}", "Salary_" + emp.StaffName, info);
                var AdvList = db.StaffAdvanceReceipts.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.ReceiptDate);
                if (AdvList != null)
                    xs.AddSheet<StaffAdvanceReceipt>("StaffAdvanceReceipts", AdvList, $"Adv_{emp.StaffName}", "Advance_" + emp.StaffName, info);

                var CSList = db.CurrentSalaries.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.EmployeeId).ThenBy(c=>c.EffectiveDate);
                if (CSList != null)
                    xs.AddSheet<CurrentSalary>("StaffAdvanceReceipts", CSList, $"CurrSal_{emp.StaffName}", "CurrentSalary_" + emp.StaffName, info);

                var PSList = db.PaySlips.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.EmployeeId).ThenBy(c => c.OnDate);
                if (PSList != null)
                    xs.AddSheet<PaySlip>("PaySlip", PSList, $"PS_{emp.StaffName}", "PaySlip" + emp.StaffName, info);
                var AdvPayList = db.StaffAdvancePayments.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.PaymentDate);
                if (AdvPayList != null)
                    xs.AddSheet<StaffAdvancePayment>("StaffAdvancePayments", AdvPayList, $"AdvPay_{emp.StaffName}", "AdvancePay_" + emp.StaffName, info);
            }
            return xs.WB;
        }
    }

}
