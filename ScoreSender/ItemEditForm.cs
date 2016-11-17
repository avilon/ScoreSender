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
    /// <summary>
    /// Редактирование адреса и email точки приема платежей
    /// </summary>
    public partial class ItemEditForm : Form
    {
        public ItemEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Фактический адрес точки
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Email точки
        /// </summary>
        public string Email { get; set; }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            Address = tbAddress.Text;
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            Email = tbEmail.Text;
        }

        private void ItemEditForm_Shown(object sender, EventArgs e)
        {
            tbAddress.Text = Address;
            tbEmail.Text = Email;
        }

        private void ItemEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
