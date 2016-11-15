using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;

namespace ScoreSender.Entity
{
    /// <summary>
    /// Базовый алгоритм заполнения листа показателями
    /// </summary>
    public class BaseXlsSheet : IXlsSheet
    {
        public BaseXlsSheet()
        {
            values = new string[MAX_VALUES_CNT];
        }

        public void FillSheet(Excel.Workbook workbook, Excel.Application destFile, string addrStr)
        {
            this.workbook = workbook;
            this.destFile = destFile;
            this.addrStr = addrStr;

            ReadValues();
            FillSheet();
        }

        /// <summary>
        /// Считывает показатели из общего файла
        /// </summary>
        protected virtual void ReadValues()
        {

        }

        /// <summary>
        /// Записывает показатели в рабочий файл (для конкретного адреса)
        /// </summary>
        protected virtual void FillSheet()
        {

        }

        public Excel.Workbook Workbook { get { return this.workbook; } }
        public Excel.Application DestFile { get { return this.destFile; } }
        public string AddrStr { get { return this.addrStr; } }

        protected string[] values;
        protected string header;
        protected Excel.Workbooks excelAppWorkbooks;

        private Excel.Workbook workbook;
        private Excel.Application destFile;
        private string addrStr;

        private static readonly int MAX_VALUES_CNT = 9;
    }
}
