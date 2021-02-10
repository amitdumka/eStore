using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using eStore.DL.Data;
using eStore.ImportDatabase.Data;
using eStore.Shared.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eStore.BL.Exporter.Database
{
    public class PayRollExporter
    {
        public XLWorkbook ToExcel(eStoreDbContext db)
        {
            var wb = new XLWorkbook();
            wb.Author = "eStore: AKS Labs";
            var ws = wb.Worksheets.Add("Employees");

            var empList = db.Employees.OrderBy(c => c.EmployeeId);
            ws.Cell(1, 2).Value = "TableName";
            ws.Cell(1, 3).Value = "Employees";
            ws.Cell(2, 2).Value = "Date";
            ws.Cell(2, 3).Value = DateTime.Now;
            ws.Cell(4, 1).InsertTable(empList, "Employee", true);
            wb.SaveAs("Employee_" + DateTime.UtcNow.ToString() + ".xlsx");

            foreach (var emp in empList)
            {
                // Add Attendace.
                var wsAtt = wb.Worksheets.Add($"Att_{emp.StaffName}");
                wsAtt.Cell(1, 2).Value = "TableName";
                wsAtt.Cell(1, 3).Value = "Attendances";
                wsAtt.Cell(2, 2).Value = "EmployeeName";
                wsAtt.Cell(2, 3).Value = emp.StaffName;
                wsAtt.Cell(2, 5).Value = "EmployeeId";
                wsAtt.Cell(2, 6).Value = emp.EmployeeId;

                var attList = db.Attendances.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.AttDate);
                if (attList != null)
                    wsAtt.Cell(5, 1).InsertTable(attList, "Attendance_" + emp.StaffName, true);
                wb.Save();

                var wsSal = wb.Worksheets.Add($"Sal_{emp.StaffName}");
                wsSal.Cell(1, 2).Value = "TableName";
                wsSal.Cell(1, 3).Value = "SalaryPayments";
                wsSal.Cell(2, 2).Value = "EmployeeName";
                wsSal.Cell(2, 3).Value = emp.StaffName;
                wsSal.Cell(2, 5).Value = "EmployeeId";
                wsSal.Cell(2, 6).Value = emp.EmployeeId;

                var SalList = db.SalaryPayments.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.PaymentDate);
                if (SalList != null)
                    wsSal.Cell(3, 1).InsertTable(attList, "Salary_" + emp.StaffName, true);
                wb.Save();

                var wsAdv = wb.Worksheets.Add($"Rec_{emp.StaffName}");
                wsAdv.Cell(1, 2).Value = "TableName";
                wsAdv.Cell(1, 3).Value = "StaffAdvanceReceipts";
                wsAdv.Cell(2, 2).Value = "EmployeeName";
                wsAdv.Cell(2, 3).Value = emp.StaffName;
                wsAdv.Cell(2, 5).Value = "EmployeeId";
                wsAdv.Cell(2, 6).Value = emp.EmployeeId;

                var AdvList = db.StaffAdvanceReceipts.Where(c => c.EmployeeId == emp.EmployeeId).OrderBy(c => c.ReceiptDate);

                if (wsAdv != null)
                    wsAdv.Cell(5, 1).InsertTable(attList, "AdvanceReceipt_" + emp.StaffName, true);
                wb.Save();
            }
            return wb;

        }//End Of Function

    }

    
    public class ExpenseExporter
    {
        public XLWorkbook ToExcel(eStoreDbContext db)
        {
            var wb = new XLWorkbook();
            wb.Author = "eStore: AKS Labs";
            wb.Worksheets.Add("Expenses System");
            wb.SaveAs("Expenses_" + DateTime.UtcNow.ToString() + ".xlsx");

            ExcelSheet.AddSheet<Expense>(wb, "Expenses", db.Expenses.OrderBy(c => c.StoreId).ThenBy(c => c.OnDate));
            ExcelSheet.AddSheet<Payment>(wb, "Payments", db.Payments.OrderBy(c => c.StoreId).ThenBy(c =>c.OnDate));
            ExcelSheet.AddSheet<Receipt>(wb, "Receipts", db.Receipts.OrderBy(c => c.StoreId).ThenBy(c => c.OnDate));
            ExcelSheet.AddSheet<CashPayment>(wb, "CashPayments", db.CashPayments.OrderBy(c => c.StoreId).ThenBy(c => c.PaymentDate));
            ExcelSheet.AddSheet<CashReceipt>(wb, "CashReceipts", db.CashReceipts.OrderBy(c => c.StoreId).ThenBy(c => c.InwardDate));



            return wb;
        }
    }

    public class ExcelSheet
    {
        public static IXLWorksheet AddSheet<T>( XLWorkbook wb, string TableName, IEnumerable<T> objName )
        {
            var ws = wb.Worksheets.Add(TableName);            
            ws.Cell(1, 2).Value = "TableName";
            ws.Cell(1, 3).Value = TableName;
            ws.Cell(2, 2).Value = "Date";
            ws.Cell(2, 3).Value = DateTime.Now;
            ws.Cell(6, 1).InsertTable(objName, TableName, true);
            wb.Save();
            return ws;
        }
        public static IXLWorksheet AddSheet<T>(XLWorkbook wb, string TName, IEnumerable<T> objName, string SName, string CTName)
        {
            var ws = wb.Worksheets.Add(SName);
            ws.Cell(1, 2).Value = "TableName";
            ws.Cell(1, 3).Value = TName;
            ws.Cell(2, 2).Value = "Date";
            ws.Cell(2, 3).Value = DateTime.Now;
            ws.Cell(6, 1).InsertTable(objName, CTName, true);
            wb.Save();
            return ws;
        }

        public static IXLWorksheet AddSheet<T>(XLWorkbook wb, string TName, IEnumerable<T> objName, string SName, string CTName, SortedList<string,string> CustInfo)
        {
            var ws = wb.Worksheets.Add(SName);
            ws.Cell(1, 2).Value = "TableName";
            ws.Cell(1, 3).Value = TName;
            ws.Cell(2, 2).Value = "Date";
            ws.Cell(2, 3).Value = DateTime.Now;

            int R = 3, C = 2;           
            foreach (var item in CustInfo)
            {
                ws.Cell(R, C).Value = item.Key;
                ws.Cell(R++, C+1).Value = item.Key;
            }
            ws.Cell(R+4, 1).InsertTable(objName, CTName, true);
            wb.Save();
            return ws;
        }
    }

}
