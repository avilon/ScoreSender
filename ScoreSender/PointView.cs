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

            /*
            MailSender ms = new MailSender();
            for ( int i = 0; i < cachPointList.Count; i++)
            {
                string email = cachPointList[i].Email;
                ms.SendMail(email, @"E:\AA\emails.cfg");

                if (onSendNextMail != null)
                {
                    onSendNextMail(cachPointList[i].Email);
                }
            }

            if (onSendEnd != null)
            {
                onSendEnd();
            }
            */

            logger.Trace("Send mail proc leaving");
        }

        public void AddSendStartListener(SendStart lst)
        {
            onSendStart += lst;
        }

        public void AddSendEndListener(SendEnd lst)
        {
            onSendEnd += lst;
        }

        public void AddSendNextMailListener(SendNextMail lst)
        {
            onSendNextMail += lst;
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
        /// Создает отдельные файлы для отправки по конкретным адресам
        /// </summary>
        private void CreateTemplates()
        {
            string destDir = Environment.CurrentDirectory;
            string quartStr = Quarter.ToString() + "_квартал_";
            destDir += "\\" + quartStr;

            XlsTemplate tmpl = new XlsTemplate(CompleteFileName, destDir);
            cachPointList = new CachPointList();
            cachPointList.Load(Properties.Settings.Default.MailListFile);

            for (int i = 0; i < cachPointList.Count; i++)
            {
                CachPoint cp = cachPointList[i];
                tmpl.CreateOutFile(cp.Address, Quarter);
            }
        }

        private SendStart onSendStart;
        private SendEnd onSendEnd;
        private SendNextMail onSendNextMail;

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
