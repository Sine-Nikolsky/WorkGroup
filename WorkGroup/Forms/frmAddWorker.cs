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

    public partial class frmAddWorker : Form
    {
        public string WorkerName { get; set; }
        public int PersonalNumber { get; set; }
        public frmAddWorker()
        {
            InitializeComponent();
            
        }


        private void frmWorkers_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            txtName.Text = WorkerName;
            nmrPersonNumber.Value = (decimal)PersonalNumber;
            nmrPersonNumber.Controls[0].Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("Поле \"Фамилия\" не должно быть пустым!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (nmrPersonNumber.Value == 0)
            {
                MessageBox.Show("Значение \"Табельный №\" не должно быть равно 0!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmrPersonNumber.Focus();
                return;
            }
            WorkerName = txtName.Text;
            PersonalNumber = (int)nmrPersonNumber.Value;
            DialogResult = DialogResult.OK;
        }

        private void nmrPersonNumber_Enter(object sender, EventArgs e)
        {
            nmrPersonNumber.Select(0, nmrPersonNumber.Text.Length);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nmrPersonNumber.Focus();
            }
        }

        private void nmrPersonNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
            }
        }
    }
}
