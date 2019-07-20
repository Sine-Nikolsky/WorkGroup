using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkGroup.Forms
{
    public partial class frmInputNum : Form
    {
        public int Value { get; set; }
        public frmInputNum()
        {
            InitializeComponent();
            nmrValue.Controls[0].Visible = false;
        }

        private void frmInputNum_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            nmrValue.Value = Value;
            nmrValue.Focus();
        }

        private void nmrValue_Enter(object sender, EventArgs e)
        {
            nmrValue.Select(0, nmrValue.Text.Length);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (nmrValue.Value == 0)
            {
                MessageBox.Show("Введите значение", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Value = (int)nmrValue.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void nmrValue_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void nmrValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnOk_Click(sender, e);
        }
    }
}
