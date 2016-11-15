using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreSender.Entity
{
    public class FouthSheetCreator : BaseXlsSheet14
    {
        public FouthSheetCreator(int quarter)
            : base(quarter)
        {
            header = HEADER;
            sheetNumber = SHEET_NUMBER;
        }

        private static readonly string HEADER = "Мобильная связь, сборы";
        private static readonly int SHEET_NUMBER = 4;
    }
}
