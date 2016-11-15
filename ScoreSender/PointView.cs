using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NLog;
using ScoreSender.Entity;

namespace ScoreSender
{
    public partial class PointView : Form
    {
        private CachPointList cachPointList;        
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public delegate void CreateNextTemplate(string templateName);
        public delegate void TemplateCreateStart();
        public delegate void TemplateCreateFinish();

        public delegate void SendStart();
        public delegate void SendNextMail(string address);
        public delegate void SendEnd();

        public PointView()
        {
            InitializeComponent();
            Init();            
        }

        /// <summary>
        /// Квартал, за который нужно разослать показатели.
        /// </summary>
        public decimal Quarter { get; set; }

        /// <summary>
        /// Путь к файлу с полным списком показателей (на его основе 
        /// сформируем отдельные файлы для конкретных адресов)
        /// </summary>
        public string CompleteFileName { get; set; }

        /// <summary>
        /// Выполняет рассылку по списку получателей
        /// </summary>
        public void SendMail()
        {
            logger.Trace("Send mail proc starting");

            if (onSendStart != null)
            {
                onSendStart();
            }

            CreateTemplates();
            RunSending();

            logger.Trace("Send mail proc leaving");
        }

        public void AddSendStartListener(SendStart listener)
        {
            onSendStart += listener;
        }

        public void AddSendEndListener(SendEnd listener)
        {
            onSendEnd += listener;
        }

        public void AddSendNextMailListener(SendNextMail listener)
        {
            onSendNextMail += listener;
        }

        public void AddCreateNextTemplate(CreateNextTemplate listener)
        {
            onCreateNextTemplate += listener;
        }

        public void AddTemplateCreateStart(TemplateCreateStart listener)
        {
            onTemplateCreateStart += listener;
        }

        public void AddTemplateCreateFinish(TemplateCreateFinish listener)
        {
            onTemplateCreateFinish += listener;
        }

        private void Init()
        {
            listView.Dock = DockStyle.Fill;
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScroll = false;

            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.Columns.Add("Адрес", listView.ClientSize.Width - listView.ClientSize.Width / 8, HorizontalAlignment.Left);
            listView.Columns.Add("E-mail", listView.Width / 2, HorizontalAlignment.Left);

            fileMap = new Dictionary<string, string>();
        }

        private void ShowMailList()
        {
            listView.Items.Clear();
            cachPointList = new CachPointList();
            cachPointList.Load(Properties.Settings.Default.MailListFile);
            for ( int i = 0; i < cachPointList.Count; i++ )
            {
                CachPoint cp = cachPointList[i];
                ListViewItem lvi = new ListViewItem(cp.Address);
                ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = cp.Email;
                lvi.SubItems.Add(lvsi);
                listView.Items.Add(lvi);                
            }
        }

        /// <summary>
        /// Создает отдельные файлы для отправки по конкретным адресам,
        /// Все файлы сохраняются в выходной директории = Папка_программы\N_квартал,
        /// где N - номер квартала
        /// </summary>
        private void CreateTemplates()
        {
            string destDir = GetDestDirectory();

            XlsTemplate tmpl = new XlsTemplate(CompleteFileName, destDir);
            tmpl.Quarter = this.Quarter;
            tmpl.AddCreateNextTemplateListener(OnCreateListTemplate);

            cachPointList = new CachPointList();
            cachPointList.Load(Properties.Settings.Default.MailListFile);
            int ndx = 1;

            if (onTemplateCreateStart != null)
            {
                onTemplateCreateStart();
            }

            for (int i = 0; i < cachPointList.Count; i++)
            {
                CachPoint cp = cachPointList[i];
                cp.WorkFileName = destDir + "\\" + String.Format("{0,6:000000}", ndx) + ".xls";
                tmpl.CreateOutFile(cp.Address, String.Format("{0,6:000000}", ndx),  Quarter);
                ndx++;
            }
            tmpl.Complete();

            WriteFileMap(cachPointList);

            if (onTemplateCreateFinish != null)
            {
                onTemplateCreateFinish();
            }
        }

        /// <summary>
        /// Записываем в выходную директорию отдельный файл, в котором прописано,
        /// соответствие файлов Excel и email - адресов, на которые их нужно отправить
        /// </summary>
        /// <param name="cpl">Список с актуальным описанием точек</param>
        private void WriteFileMap(CachPointList cpl)
        {
            string fname = GetDestDirectory() + "\\filemap.txt";
            fileMap.Clear();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fname))
            for (int i = 0; i < cpl.Count; i++)
            {
                CachPoint cp = cpl[i];
                string line = cp.WorkFileName + "=" + cp.Email;
                writer.WriteLine(line);

                if (!fileMap.ContainsKey(cp.Email))
                {
                    fileMap.Add(cp.Email, cp.WorkFileName);
                }
            }
        }

        private void RunSending()
        {
            MailSender ms = new MailSender();
            for ( int i = 0; i < cachPointList.Count; i++)
            {
                string email = cachPointList[i].Email;
                string address = cachPointList[i].Address;
                ms.SendMail(email, address, (int)this.Quarter, fileMap[email]);

                if (onSendNextMail != null)
                {
                    onSendNextMail(cachPointList[i].Email);
                }
            }

            if (onSendEnd != null)
            {
                onSendEnd();
            }
        }

        private string GetDestDirectory()
        {
            string destDir = Environment.CurrentDirectory;
            string quartStr = Quarter.ToString() + "_квартал";
            destDir += "\\" + quartStr;
            return destDir;
        }

        private void OnCreateListTemplate(string templateName)
        {
            if (onCreateNextTemplate != null)
            {
                onCreateNextTemplate(templateName);
            }
        }

        private SendStart onSendStart;
        private SendEnd onSendEnd;
        private SendNextMail onSendNextMail;
        private CreateNextTemplate onCreateNextTemplate;
        private TemplateCreateStart onTemplateCreateStart;
        private TemplateCreateFinish onTemplateCreateFinish;

        /// <summary>
        /// Сопоставление электронного адреса и имени файла, 
        /// который нужно отправить на это адрес
        /// </summary>
        private Dictionary<string, string> fileMap;

        /*********************************************************
         *********************************************************/ 
        private void PointView_Load(object sender, EventArgs e)
        {
            ShowMailList();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ItemEditForm itemEdit = new ItemEditForm();
            itemEdit.Address = listView.SelectedItems[0].Text;
            itemEdit.Email = listView.SelectedItems[0].SubItems[1].Text;
            if (itemEdit.ShowDialog() == DialogResult.OK)
            {
                CachPoint cp = new CachPoint(itemEdit.Address, itemEdit.Email);
                cachPointList.UpdateByAddress(listView.SelectedItems[0].Text, cp);
                listView.SelectedItems[0].Text = itemEdit.Address;
                listView.SelectedItems[0].SubItems[1].Text = itemEdit.Email;
            }
        }

        private void PointView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cachPointList != null)
            {
                cachPointList.Save(Properties.Settings.Default.MailListFile);
            }
        }       
    }
}
