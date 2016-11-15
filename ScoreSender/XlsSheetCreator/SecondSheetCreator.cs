using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreSender.Entity
{
    public class SecondSheetCreator : BaseXlsSheet23
    {
        public SecondSheetCreator(int quarter) : base(quarter)
        {
            header = HEADER;
            sheetNumber = SHEET_NUMBER;
        }

        private static readonly string HEADER = "Денежные переводы, сборы";
        private static readonly int SHEET_NUMBER = 2;
    }
}
