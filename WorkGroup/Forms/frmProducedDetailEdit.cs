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
    public partial class frmProducedDetailEdit : Form
    {
        public int Count { get; set; }
        public Guid WorkerId { get; set; }
        public DateTime ProduceDate { get; set; }

        private WorkGroupContext _context = new WorkGroupContext();
        public frmProducedDetailEdit()
        {
            InitializeComponent();
        }

        private void frmProducedDetailEdit_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            dtpProduceDate.Value = ProduceDate;
            cmbWorker.DataSource = null;
            cmbWorker.ValueMember = "Id";
            cmbWorker.DisplayMember = "Name";
            cmbWorker.DataSource = _context.Workers.Where(x => x.DismissedDate == null).OrderBy(x => x.Name).ToList();
            cmbWorker.SelectedValue = WorkerId;

            nmrCount.Value = Count;  
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Count = (int)nmrCount.Value;
            ProduceDate = dtpProduceDate.Value;
            if (cmbWorker.SelectedItem == null)
            {
                MessageBox.Show("Оператор не выбран!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            WorkerId = ((Worker)cmbWorker.SelectedItem).Id;
           
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nmrCount_Enter(object sender, EventArgs e)
        {
            nmrCount.Select(0, nmrCount.Text.Length);
        }
    }
}
