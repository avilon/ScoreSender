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
    public partial class ItemEditForm : Form
    {
        public ItemEditForm()
        {
            InitializeComponent();
        }

        public string Address { get; set; }
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
    }
}
