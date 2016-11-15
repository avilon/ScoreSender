using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;
using NLog;
using System.Windows.Forms;

namespace ScoreSender.Entity
{
    /// <summary>
    /// Читает сводный файл с показателями 
    /// на его основе формирует набор отдельных файлов для рассылки по адресам 
    /// </summary>
    public class XlsTemplate
    {
        /// <summary>
        /// Инициализация класса
        /// </summary>
        /// <param name="baseFileName">Путь к сводному файлу с показателями</param>
        /// <param name="destFolderName">Каталог, в который записываются файлы для рассылки</param>
        public XlsTemplate(string baseFileName, string destFolderName)
        {
            this.baseFileName = baseFileName;
            this.destFolderName = destFolderName;
            CreateCompleteExcelApplication();
        }

        public string BaseFileName { get { return baseFileName; } }
        public string DestFolderName { get { return DestFolderName; } }

        /// <summary>
        /// Квартал, за который рассылаются показатели
        /// </summary>
        public decimal Quarter { get { return quarter; } set { SetQuarter(value); } }

        /// <summary>
        /// Завершение процесса создания отдельных файлов.
        /// Общий файл при этом у нас был постоянно открыт - нужно захлопнуть его
        /// </summary>
        public void Complete()
        {
            if (completeExcel != null)
            {
                completeExcel.Quit();
            }
        }

        /// <summary>
        /// Создает xls - файл с набором показателей для конкретного адреса
        /// </summary>
        /// <param name="addrStr">Адрес, для которого нужно выбрать данные</param>
        /// <param name="quarter">Квартал, за который рассылаются данные</param>
        public void CreateOutFile(string addrStr, string destFileName, decimal quarter = 0)
        {
            logger.Trace("Create output file, params: address = {0}, quarter = {1}", addrStr, quarter);
            this.addrStr = addrStr;
            this.destFileName = destFileName;
            if ((quarter > 0) && (quarter < 5))
            {
                this.Quarter = quarter; 
            }
            CreateTemplate();
        }

        private void CreateTemplate()
        {
            logger.Trace("Create template starting");
            try
            {
                if ((quarter <= 0) && (quarter > 4))
                {
                    logger.Debug("Incorrect quarter: {0}, cannot create template", quarter);
                    return;
                }

                CheckDestFolder();
                CreateWorkExcelApplications();

                logger.Trace("Fill first sheet");
                IXlsSheet sheet = new FirstSheetCreator((int)Quarter);
                sheet.FillSheet(completeWorkBook, workExcel, addrStr);

                logger.Trace("Fill second sheet");
                sheet = new SecondSheetCreator((int)Quarter);
                sheet.FillSheet(completeWorkBook, workExcel, addrStr);

                logger.Trace("Fill third sheet");
                sheet = new ThirdSheetCreator((int)Quarter);
                sheet.FillSheet(completeWorkBook, workExcel, addrStr);

                logger.Trace("Fill fouth sheet");
                sheet = new FouthSheetCreator((int)Quarter);
                sheet.FillSheet(completeWorkBook, workExcel, addrStr);
            }

            catch(Exception e)
            {
                logger.Error(e.Message);
            }
            finally
            {
                SaveWorkBook();
            }

            logger.Trace("Create template leaving");
        }

        private void SetQuarter(decimal value)
        {
            logger.Trace("Set quarter: {0}", value);
            quarter = value;
        }

        private void CreateCompleteExcelApplication()
        {
            if (!System.IO.File.Exists(this.baseFileName))
            {
                logger.Trace("Incorrect file name for complete Excel: {0}", this.baseFileName);
                return;
            }

            try
            {
                completeExcel = new Excel.Application();
                SetupExcelApplication(completeExcel);
                completeWorkBook = completeExcel.Workbooks.Open(baseFileName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                MessageBox.Show("Ошибка во время создания файла Excel: " + ex.Message, Common.AppName);
            }
        }

        private void CreateWorkExcelApplications()
        {
            try
            {
                workExcel = new Excel.Application();
                SetupExcelApplication(workExcel);
                workExcel.SheetsInNewWorkbook = 4;
                workExcel.Workbooks.Add(Type.Missing);
                workExcel.Sheets[1].Name = "Комплекты";
                workExcel.Sheets[2].Name = "Ден.переводы";
                workExcel.Sheets[3].Name = "Кредиты";
                workExcel.Sheets[4].Name = "Мобильная связь";
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                MessageBox.Show("Ошибка во время создания файла Excel: " + ex.Message, Common.AppName);
            }
        }

        private void SetupExcelApplication(Excel.Application app)
        {
            app.Visible = false;
            app.DefaultSaveFormat = Excel.XlFileFormat.xlExcel7;
            // Не задавать вопрос о перезаписи уже существующего файла
            app.DisplayAlerts = false;
        }

        private void CheckDestFolder()
        {
            try
            {
                if (!System.IO.Directory.Exists(destFolderName))
                {
                    System.IO.Directory.CreateDirectory(destFolderName);
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
        }

        private void SaveWorkBook()
        {
            var workbooks = workExcel.Workbooks;
            var workbook = workbooks[1];
            var excelSheets = workbook.Worksheets;
            var excelWorkSheet = (Excel.Worksheet)excelSheets.get_Item(1);
            string outputFileName = destFolderName + "\\" + destFileName + ".xls";
            //outputFileName = @"E:\AA\wb.xls";
            excelWorkSheet.SaveAs(outputFileName);
            //workbook.Save(outputFileName);
            workExcel.Quit();
        }

        private string baseFileName;
        private string destFileName;
        private string destFolderName;
        private string addrStr;

        private decimal quarter;

        private Excel.Application completeExcel;
        private Excel.Application workExcel;
        private Excel.Workbook completeWorkBook;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    }
}
