using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreSender.Entity
{
    public class FirstSheetCreator :BaseXlsSheet14
    {
        public FirstSheetCreator() : base()
        {
            header = HEADER;
        }

        private static readonly string HEADER = "Комплекты подключения, штуки";
    }
}
