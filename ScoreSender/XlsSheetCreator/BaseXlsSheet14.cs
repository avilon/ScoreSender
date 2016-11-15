using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;


namespace ScoreSender.Entity
{
    public class BaseXlsSheet14 : BaseXlsSheet
    {
        public BaseXlsSheet14(int quarter) : base(quarter)
        {
        }

        protected override void ReadValues()
        {
            base.ReadValues();
            Excel.Sheets sheets = Workbook.Worksheets;
            Excel.Worksheet sheet = (Excel.Worksheet)sheets.get_Item(sheetNumber);
            var cell = sheet.get_Range("B4", "B4");

            bool isFound = false;
            int rowId = 4;
            while (!isFound)
            {
                string cellNumber = "B" + rowId.ToString();
                string cellVal;
                string str;
                cell = sheet.get_Range(cellNumber, cellNumber);
                cellVal = Convert.ToString(cell.Value2);

                if (cellVal == AddrStr)
                {
                    cellNumber = "C" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[0] = str;

                    cellNumber = "D" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[1] = str;

                    cellNumber = "E" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[2] = str;

                    cellNumber = "F" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[3] = str;

                    cellNumber = "G" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[4] = str;

                    cellNumber = "H" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[5] = str;

                    cellNumber = "I" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[6] = str;

                    cellNumber = "J" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[7] = str;

                    cellNumber = "K" + rowId;
                    cell = sheet.get_Range(cellNumber, cellNumber);
                    str = cell.Text;
                    values[8] = str;

                    isFound = true;
                }
                rowId++;
            }
        }

        protected override void FillSheet()
        {
            base.FillSheet();

            var excelAppWorkbooks = DestFile.Workbooks;
            var excelAppWorkbook = excelAppWorkbooks[1];
            var excelSheets = excelAppWorkbook.Worksheets;
            var excelWorkSheet = (Excel.Worksheet)excelSheets.get_Item(sheetNumber);
            var excelCells = excelWorkSheet.get_Range("A2", "A2");
            excelCells.Value2 = this.header;

            var ec = excelWorkSheet.get_Range("A4", "A5");
            ec.Merge(Type.Missing);
            ec.Value2 = "ППДС";
            ec.Font.Bold = true;
            ec.EntireColumn.ColumnWidth = 40;
            ec.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ec.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; ;

            ec = excelWorkSheet.get_Range("B4", "J4");
            ec.Merge(Type.Missing);
            ec.Value2 = quarter;
            ec.Font.Bold = true;
            ec.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ec.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; ;

            ec = excelWorkSheet.get_Range("B5", "B5");
            ec.Value2 = month_01;
            ec.EntireColumn.ColumnWidth = 15;
            ec.Font.Bold = true;
            ec.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ec.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; ;

            ec = excelWorkSheet.get_Range("C5", "C5");
            ec.EntireColumn.ColumnWidth = 15;
            ec = excelWorkSheet.get_Range("D5", "D5");
            ec.EntireColumn.ColumnWidth = 15;
            ec = excelWorkSheet.get_Range("E5", "E5");
            ec.EntireColumn.ColumnWidth = 15;
            ec = excelWorkSheet.get_Range("F5", "F5");
            ec.EntireColumn.ColumnWidth = 15;
            ec = excelWorkSheet.get_Range("G5", "G5");
            ec.EntireColumn.ColumnWidth = 15;
            ec = excelWorkSheet.get_Range("H5", "H5");
            ec.EntireColumn.ColumnWidth = 15;
            ec = excelWorkSheet.get_Range("I5", "I5");
            ec.EntireColumn.ColumnWidth = 15;
            ec = excelWorkSheet.get_Range("J5", "J5");
            ec.EntireColumn.ColumnWidth = 15;

            ec = excelWorkSheet.get_Range("F5", "F5");
            ec.Value2 = month_02;
            ec.Font.Bold = true;
            ec.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ec.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; ;

            ec = excelWorkSheet.get_Range("H5", "H5");
            ec.Value2 = "выполнение";
            ec.Font.Bold = true;
            ec.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ec.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; ;

            ec = excelWorkSheet.get_Range("I5", "I5");
            ec.Value2 = "премия";
            ec.Font.Bold = true;
            ec.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ec.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; ;

            ec = excelWorkSheet.get_Range("J5", "J5");
            ec.Value2 = month_03;
            ec.Font.Bold = true;
            ec.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ec.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; ;

            ec = excelWorkSheet.get_Range("A4", "J5");
            ec.Borders.LineStyle = Excel.XlLineStyle.xlDouble;

            ec = excelWorkSheet.get_Range("A6", "A6");
            ec.Value2 = this.AddrStr;
            ec = excelWorkSheet.get_Range("B6", "B6");
            ec.Value2 = values[0];
            ec = excelWorkSheet.get_Range("C6", "C6");
            ec.Value2 = values[1];
            ec = excelWorkSheet.get_Range("D6", "D6");
            ec.Value2 = values[2];
            ec = excelWorkSheet.get_Range("E6", "E6");
            ec.Value2 = values[3];
            ec = excelWorkSheet.get_Range("F6", "F6");
            ec.Value2 = values[4];
            ec = excelWorkSheet.get_Range("G6", "G6");
            ec.Value2 = values[5];
            ec = excelWorkSheet.get_Range("H6", "H6");
            ec.Value2 = values[6];
            ec = excelWorkSheet.get_Range("I6", "I6");
            ec.Value2 = values[7];
            ec = excelWorkSheet.get_Range("J6", "J6");
            ec.Value2 = values[8];

            ec = excelWorkSheet.get_Range("A6", "J6");
            ec.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
        }
    }
}
