using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace ScoreSender.Entity
{
    /// <summary>
    /// Одноразовый класс для "прочитать" е-майлы из Excel'евского файла
    /// </summary>
    public class XlsMailRedaer
    {
        public void Read(string fname)
        {
            if (!File.Exists(fname))
            {
                return;
            }
            CachPointList cpl = new CachPointList();

            excelApp = new Excel.Application();
            var excelAppWorkbooks = excelApp.Workbooks;
            var excelAppWorkbook = excelApp.Workbooks.Open(fname);
            var excelSheets = excelAppWorkbook.Worksheets;
            var excelWorkSheet = (Excel.Worksheet)excelSheets.get_Item(1);

            bool endOfList = false;
            int row = 1;
            while(!endOfList)
            {
                string a = "A" + row;
                string b = "B" + row;
                string address;
                string email;

                var excelCells = excelWorkSheet.get_Range(a);
                address = Convert.ToString(excelCells.Value2);
                
                if (String.IsNullOrEmpty(address))
                {
                    endOfList = true;
                    continue;
                }

                if (address.Length < 3)
                {
                    endOfList = true;
                    continue;
                }

                excelCells = excelWorkSheet.get_Range(b);
                email = Convert.ToString(excelCells.Value2);

                CachPoint cp = new CachPoint(address, email);
                cpl.Add(cp);

                row++;
            }
            cpl.Save(@"E:\AA\emails.cfg");

            excelApp.Workbooks.Open(fname);
            excelApp.Visible = true;

        }

        private Excel.Application excelApp;
    }
}
