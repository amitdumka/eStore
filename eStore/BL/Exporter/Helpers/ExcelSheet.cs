using System;
using System.Collections.Generic;
using ClosedXML.Excel;

namespace eStore.BL.Exporter.Database
{
    public class ExcelSheet
    {
        public static IXLWorksheet AddSheet<T>(XLWorkbook wb, string TableName, IEnumerable<T> objName)
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

        public static IXLWorksheet AddSheet<T>(XLWorkbook wb, string TName, IEnumerable<T> objName, string SName, string CTName, SortedList<string, string> CustInfo)
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
                ws.Cell(R++, C + 1).Value = item.Key;
            }
            ws.Cell(R + 4, 1).InsertTable(objName, CTName, true);
            wb.Save();
            return ws;
        }
    }

}
