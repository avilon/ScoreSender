using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreSender
{
    public partial class MailSettingsForm : Form
    {
        public MailSettingsForm()
        {
            InitializeComponent();
            Init();
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.MailFrom = tbMailFrom.Text;
            Properties.Settings.Default.SmtpServer = tbSmtpServer.Text;
            Properties.Settings.Default.SmtpPort = tbSmtpPort.Text;
            Properties.Settings.Default.MailUser = tbMailUser.Text;
            Properties.Settings.Default.MailPassword = Entity.StringCryptor.CryptString(tbMailPassword.Text, Entity.Common.CryptKey);
            Properties.Settings.Default.MessageSubject = tbMessageSubject.Text;
            Properties.Settings.Default.MessageBody = tbMessageBody.Text;
            Properties.Settings.Default.MailListFile = tbMailList.Text;
        }

        private void Init()
        {
            ReadSettings();
        }

        private void ReadSettings()
        {
            tbMailFrom.Text = Properties.Settings.Default.MailFrom;
            tbSmtpServer.Text = Properties.Settings.Default.SmtpServer;
            tbSmtpPort.Text = Properties.Settings.Default.SmtpPort;
            tbMailUser.Text = Properties.Settings.Default.MailUser;
            tbMailPassword.Text = Entity.StringCryptor.DecryptString(Properties.Settings.Default.MailPassword, Entity.Common.CryptKey);
            tbMessageSubject.Text = Properties.Settings.Default.MessageSubject;
            tbMessageBody.Text = Properties.Settings.Default.MessageBody;
            tbMailList.Text = Properties.Settings.Default.MailListFile;
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbMailList.Text = openFileDialog.FileName;
            }
        }

    }
}
