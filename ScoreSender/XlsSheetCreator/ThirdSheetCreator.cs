﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreSender.Entity
{
    public class ThirdSheetCreator : BaseXlsSheet23
    {
        public ThirdSheetCreator(int quarter) : base(quarter)
        {
            header = HEADER;
            sheetNumber = SHEET_NUMBER;
        }

        private static readonly string HEADER = "Погашение кредитов, сборы";
        private static readonly int SHEET_NUMBER = 3;
    }
}
