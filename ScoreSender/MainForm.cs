﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NLog;
    
namespace ScoreSender
{
    public partial class MainForm : Form
    {
        private PointView pointView;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public MainForm()
        {
            InitializeComponent();
            Init();
            ShowPointView();
        }

        private void Init()
        {
            lbInfo.Text = "";
            edQuart.Value = (DateTime.Now.Month - 1) / 3 + 1;
        }

        private void LoadSettings()
        {
            this.Top = Properties.Settings.Default.MainForm_Top;
            this.Left = Properties.Settings.Default.MainForm_Left;
            this.Width = Properties.Settings.Default.MainForm_Width;
            this.Height = Properties.Settings.Default.MainForm_Height;
            this.tbDataFile.Text = Properties.Settings.Default.DataFilePath;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.MainForm_Top = this.Top;
            Properties.Settings.Default.MainForm_Left = this.Left;
            Properties.Settings.Default.MainForm_Width = this.Width;
            Properties.Settings.Default.MainForm_Height = this.Height;
            Properties.Settings.Default.DataFilePath = tbDataFile.Text;
            Properties.Settings.Default.Save();
        }

        private void ShowPointView()
        {
            logger.Trace("Show PointView starting");
            if (pointView == null)
            {
                pointView = new PointView();
                pointView.Anchor = AnchorStyles.Left | AnchorStyles.Right 
                                 | AnchorStyles.Top | AnchorStyles.Bottom;
                pnlWorkArea.Controls.Add(pointView);
                pointView.Dock = DockStyle.Fill;

                pointView.AddSendEndListener(SendEnd);
                pointView.AddSendNextMailListener(SendNextMail);

                pointView.Quarter = edQuart.Value;
            }
            pointView.Show();
            pointView.BringToFront();
            logger.Trace("Show PointView leaving");
        }

        private void ShowEmailSettings()
        {
            MailSettingsForm msf = new MailSettingsForm();
            if (msf.ShowDialog() == DialogResult.OK)
            {
                msf.SaveSettings();
            }
        }

        private void SendStart()
        {
            lbInfo.Text = "";
        }

        private void SendEnd()
        {
            lbInfo.Text = "";
            MessageBox.Show("Завершено", Entity.Common.AppName);
        }

        private void SendNextMail(string address)
        {
            lbInfo.Text = "Отправляется: " + address;
            Application.DoEvents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pointView != null)
                pointView.Close();
            SaveSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowEmailSettings();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            logger.Trace("Run button event started");
            try
            {
                if (pointView != null)
                {
                    pointView.SendMail();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                MessageBox.Show(ex.Message, Entity.Common.AppName);
            }
            logger.Trace("Run button event leaving");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Файлы Excel (*.xls)|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbDataFile.Text = openFileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void edQuart_ValueChanged(object sender, EventArgs e)
        {
            if (pointView != null)
            {
                pointView.Quarter = edQuart.Value;
            }
        }

        private void tbDataFile_TextChanged(object sender, EventArgs e)
        {
            if (pointView != null)
            {
                pointView.CompleteFileName = tbDataFile.Text;
            }
        }
    }
}
