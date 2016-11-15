using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;


namespace ScoreSender.Entity
{
    /// <summary>
    /// Задает поведение классов, заполняющих отдельные листы с показателями.
    /// </summary>
    public interface IXlsSheet
    {
        /// <summary>
        /// Заполняет нужный лист книги workFile данными из общего файла completeFile
        /// </summary>
        /// <param name="completeFile">Общий файл с показателями для всех точек</param>
        /// <param name="workFile">Рабочий файл с показателями для конкретной точки</param>
        /// <param name="addrStr">Адрес точки, для которой заполняем workFile</param>
        void FillSheet(Excel.Workbook workBook, Excel.Application destFile, string addrStr);
    }
}
