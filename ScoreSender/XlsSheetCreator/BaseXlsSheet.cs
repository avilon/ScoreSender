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
        public BaseXlsSheet(int quarter)
        {
            values = new string[MAX_VALUES_CNT];
            SetupQuarter(quarter);
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

        private void SetupQuarter(int quarter)
        {
            switch(quarter)
            {
                case 1: SetFirstQuarter(); break;
                case 2: SetSecondQuarter(); break;
                case 3: SetThirdQuarter(); break;
                case 4: SetFouthQuarter(); break;
                default: break;
            }
        }

        private void SetFirstQuarter()
        {
            quarter = "1 квартал";
            month_01 = "январь";
            month_02 = "февраль";
            month_03 = "март";
        }

        private void SetSecondQuarter()
        {
            quarter = "2 квартал";
            month_01 = "апрель";
            month_02 = "май";
            month_03 = "июнь";
        }

        private void SetThirdQuarter()
        {
            quarter = "3 квартал";
            month_01 = "июль";
            month_02 = "август";
            month_03 = "сентябрь";
        }

        private void SetFouthQuarter()
        {
            quarter = "4 квартал";
            month_01 = "октябрь";
            month_02 = "ноябрь";
            month_03 = "декабрь";
        }

        public Excel.Workbook Workbook { get { return this.workbook; } }
        public Excel.Application DestFile { get { return this.destFile; } }
        public string AddrStr { get { return this.addrStr; } }

        protected string[] values;
        protected string header;
        protected Excel.Workbooks excelAppWorkbooks;
        protected int sheetNumber;
        
        protected string quarter;
        protected string month_01;
        protected string month_02;
        protected string month_03;

        private Excel.Workbook workbook;
        private Excel.Application destFile;
        private string addrStr;

        private static readonly int MAX_VALUES_CNT = 9;
    }
}
