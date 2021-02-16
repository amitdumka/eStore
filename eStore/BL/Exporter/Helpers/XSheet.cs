using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace eStore.BL.Exporter.Database
{
    class XSheet
    {
        public XLWorkbook WB { get; private set; }
        protected IXLWorksheet TocWS { get; set; }
        public string FilePath { get; private set; }
        public XSheet(string path, string Title)
        {
            this.WB = GetWorkBook(Title, path);
            FilePath = path;
        }
        protected int Row = 9, SN = 0;

        protected void TOC(string TName, string Rem = "Added")
        {
            TocWS.Cell(Row, 1).Value = (++SN);
            TocWS.Cell(Row, 2).Value = TName;
            TocWS.Cell(Row, 3).Value = Rem;
            Row++;
        }

        private XLWorkbook GetWorkBook(string Title, string path)
        {
            var WBs = new XLWorkbook();
            WBs.Author = "eStore: AKS Labs";

            TocWS = WBs.Worksheets.Add("TableOfContent");
            TocWS.Cell(1, 4).Value = "Aprajita Retails";
            TocWS.Cell(2, 4).Value = "Data Exporting";
            TocWS.Cell(4, 4).Value = Title;
            TocWS.Cell(5, 3).Value = "Date";
            TocWS.Cell(5, 4).Value = DateTime.Now;

            TocWS.Cell(7, 4).Value = "Table Of Contents";
            TocWS.Cell(8, 1).Value = "SNo";
            TocWS.Cell(8, 1).Value = "TableName";
            TocWS.Cell(8, 2).Value = "SheetName";
            TocWS.Cell(8, 1).Value = "Remarks";
           
            WBs.SaveAs(Path.Combine(path, $"{Title}_ {DateTime.UtcNow.ToFileTimeUtc().ToString()}.xlsx"));
            return WBs;

        }
        public IXLWorksheet AddSheet<T>(string TableName, IEnumerable<T> objName)
        {
            var ws = WB.Worksheets.Add(TableName);
            ws.Cell(1, 2).Value = "TableName";
            ws.Cell(1, 3).Value = TableName;
            ws.Cell(2, 2).Value = "Date";
            ws.Cell(2, 3).Value = DateTime.Now;
            ws.Cell(6, 1).InsertTable(objName, TableName, true);
            TOC(TableName);
            WB.Save();
            return ws;
        }
        public IXLWorksheet AddSheet<T>(string TName, IEnumerable<T> objName, string SName, string CTName)
        {
            var ws = WB.Worksheets.Add(SName);
            ws.Cell(1, 2).Value = "TableName";
            ws.Cell(1, 3).Value = TName;
            ws.Cell(2, 2).Value = "Date";
            ws.Cell(2, 3).Value = DateTime.Now;
            ws.Cell(6, 1).InsertTable(objName, CTName, true);
            TOC(SName);
            WB.Save();
            return ws;
        }

        public IXLWorksheet AddSheet<T>(string TName, IEnumerable<T> objName, string SName, string CTName, SortedList<string, string> CustInfo)
        {
            var ws = WB.Worksheets.Add(SName);
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
            TOC(SName);
            WB.Save();
            return ws;
        }
    }

     

    public interface IXSRead 
    {
        public IEnumerable<T>FromXL<T>(IXLWorksheet ws);        
    }

    
}
