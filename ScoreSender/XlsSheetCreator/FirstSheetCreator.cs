using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreSender.Entity
{
    public class FirstSheetCreator : BaseXlsSheet14
    {
        public FirstSheetCreator(int quarter) : base(quarter)
        {
            header = HEADER;
            sheetNumber = SHEET_NUMBER;
        }

        private static readonly string HEADER = "Комплекты подключения, штуки";
        private static readonly int SHEET_NUMBER = 1;
    }
}
