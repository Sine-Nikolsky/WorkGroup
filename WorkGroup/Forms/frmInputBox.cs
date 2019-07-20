using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkGroup.Context;
using WorkGroup.Entities;

namespace WorkGroup.Forms
{
    public partial class frmInputBox : Form
   {
        public string Value { get; set; }

        public frmInputBox()
        {
            InitializeComponent();
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            txtName.Text = Value;
            txtName.Focus();

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Окно ввода пусто!");
                return;
            }

            Value = txtName.Text;
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }

        }
    }
}
