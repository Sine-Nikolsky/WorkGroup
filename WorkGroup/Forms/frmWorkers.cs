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
    public partial class frmWorkers : Form
    {
        private WorkGroupContext _context = new WorkGroupContext();
        public frmWorkers()
        {
            InitializeComponent();
        }
        public void RefreshWorkers()
        {
            lstWorkerList.DataSource = null;
            lstWorkerList.DisplayMember = "FullName";
            lstWorkerList.ValueMember = "Id";
            if (checkBox.Checked == true)
            {
                lstWorkerList.DataSource = _context.Workers.Where(x => x.Id != null).OrderBy(x => x.Name).ToList();
            }
            else
            {
                lstWorkerList.DataSource = _context.Workers.Where(x => x.DismissedDate == null).OrderBy(x => x.Name).ToList();
            }
        }
        private void frmWorkers_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            RefreshWorkers();
            btnRestore.Visible = false;
            checkBox.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var worker = new Worker();
            var frmAddWorker = new frmAddWorker();
            frmAddWorker.WorkerName = worker.Name;
            frmAddWorker.PersonalNumber = worker.PersonalNumber;
            if (frmAddWorker.ShowDialog() == DialogResult.OK)
            {
                int index = lstWorkerList.FindStringExact(frmAddWorker.WorkerName + "   (" + frmAddWorker.PersonalNumber + ")");
                worker.Name = frmAddWorker.WorkerName;
                worker.PersonalNumber = frmAddWorker.PersonalNumber;
                worker.ModifyDate = worker.CreateDate;
                    if (index == -1)
                    {
                        _context.Workers.Add(worker);
                        _context.SaveChanges();
                        RefreshWorkers();
                    }
                    else
                    {
                        MessageBox.Show("Запись с таким именем уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lstWorkerList.SetSelected(index, true);
                        return;
                    }
            }
            //поиск в Листбоксе строки с таким же названием
            var indx = lstWorkerList.FindStringExact(frmAddWorker.WorkerName + "   (" + frmAddWorker.PersonalNumber + ")");
            // фокус на нем
            if (indx == -1)
            {
                return;
            }
            else lstWorkerList.SetSelected(indx, true);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstWorkerList.SelectedItem == null)
            {
                MessageBox.Show("Запись не выбрана!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frmAddWorker = new frmAddWorker();
            var worker = (Worker)lstWorkerList.SelectedItem;
            frmAddWorker.WorkerName = worker.Name;
            frmAddWorker.PersonalNumber = worker.PersonalNumber;
            if (frmAddWorker.ShowDialog() == DialogResult.OK)
            {
                int index = lstWorkerList.FindStringExact(frmAddWorker.WorkerName + "   (" + frmAddWorker.PersonalNumber + ")");
                if (index == -1)
                {
                    worker.Name = frmAddWorker.WorkerName;
                    worker.PersonalNumber = frmAddWorker.PersonalNumber;
                    worker.ModifyDate = worker.CreateDate;
                    _context.SaveChanges();
                    RefreshWorkers();
                }
                else
                {
                    MessageBox.Show("Запись с таким именем уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstWorkerList.SetSelected(index, true);
                    return;
                }
            }
            //поиск в Листбоксе строки с таким же названием
            var indx = lstWorkerList.FindStringExact(frmAddWorker.WorkerName + "   (" + frmAddWorker.PersonalNumber + ")");
            // фокус на нем
            if (indx == -1)
            {
                return;
            }
            else lstWorkerList.SetSelected(indx, true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstWorkerList.SelectedItem == null)
            {
                MessageBox.Show("Запись не выбрана!","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if ((MessageBox.Show("Уволить сотрудника?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))  == DialogResult.OK)
            {
                var worker = (Worker)lstWorkerList.SelectedItem;
                var tmp = _context.Workers.First(x => x.Id == worker.Id);
                tmp.DismissedDate = DateTime.Now;
                if (tmp.Name.IndexOf('_') == -1)
                {
                    tmp.Name = "_" + tmp.Name;
                }
                _context.SaveChanges();
                lstWorkerList.DataSource = null;
                lstWorkerList.DisplayMember = "FullName";
                lstWorkerList.ValueMember = "Id";
                RefreshWorkers();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (lstWorkerList.SelectedItem == null)
            {
                MessageBox.Show("Запись не выбрана!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((MessageBox.Show("Восстановить сотрудника?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                var worker = (Worker)lstWorkerList.SelectedItem;
                string workerName = worker.Name.Replace("_", "");
                var tmp = _context.Workers.First(x => x.Id == worker.Id);
                tmp.DismissedDate = null;
                tmp.Name = workerName;
                _context.SaveChanges();
                RefreshWorkers();
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                btnRestore.Visible = true;
                var list = _context.Workers.Where(x => x.Id != null).ToList();
                lstWorkerList.DataSource = null;
                lstWorkerList.ValueMember = "Id";
                lstWorkerList.DisplayMember = "FullName";
                lstWorkerList.DataSource = list.OrderBy(x => x.Name).ToList();
            }
            else
            {
                btnRestore.Visible = false;
                var list = _context.Workers.Where(x => x.DismissedDate == null).ToList();
                lstWorkerList.DataSource = null;
                lstWorkerList.ValueMember = "Id";
                lstWorkerList.DisplayMember = "FullName";
                lstWorkerList.DataSource = list.OrderBy(x => x.Name).ToList();
            }
        }


    }
}
