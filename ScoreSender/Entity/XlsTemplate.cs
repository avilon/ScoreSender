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
        /// Название первого месяца квартала
        /// </summary>
        public string Month_01 { get { return month_01; } }
        /// <summary>
        /// Название второго месяца квартала
        /// </summary>
        public string Month_02 { get { return month_02; } }
        /// <summary>
        /// Название третьего месяца квартала
        /// </summary>
        public string Month_03 { get { return month_03; } }

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
        public void CreateOutFile(string addrStr, decimal quarter = 0)
        {
            logger.Trace("Create output file, params: address = {0}, quarter = {1}", addrStr, quarter);
            this.addrStr = addrStr;
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
            }

            catch(Exception e)
            {
                logger.Error(e.Message);
            }

            logger.Trace("Create template leaving");
        }

        private void SetQuarter(decimal value)
        {
            logger.Trace("Set quarter: {0}", value);
            quarter = 0;
            month_01 = "";
            month_02 = "";
            month_03 = "";

            switch ((int)value)
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
            logger.Trace("Setup first quarter");
            quarter = 1;
            this.month_01 = "январь";
            this.month_02 = "февраль";
            this.month_03 = "март";
        }

        private void SetSecondQuarter()
        {
            logger.Trace("Setup second quarter");
            quarter = 2;
            this.month_01 = "апрель";
            this.month_02 = "май";
            this.month_03 = "июнь";
        }

        private void SetThirdQuarter()
        {
            logger.Trace("Setup third quarter");
            quarter = 3;
            this.month_01 = "июль";
            this.month_02 = "август";
            this.month_03 = "сентябрь";
        }

        private void SetFouthQuarter()
        {
            logger.Trace("Setup fouth quarter");
            quarter = 4;
            this.month_01 = "октябрь";
            this.month_02 = "ноябрь";
            this.month_03 = "декабрь";
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

        private string baseFileName;
        private string destFolderName;
        private string addrStr;

        private int quarter;
        private string month_01;
        private string month_02;
        private string month_03;

        private Excel.Application completeExcel;
        private Excel.Application workExcel;
        private Excel.Workbook completeWorkBook;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    }
}
