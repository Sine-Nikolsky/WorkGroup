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
using WorkGroup.Dpo;
using WorkGroup.Entities;

namespace WorkGroup.Forms
{
    public partial class frmAddProducedDetails : Form
    {
        private IList<ProducedDetail> _producedDetails =  new List<ProducedDetail>();
        private IList<WorkersWH> _workersWH;
        private IList<Worker> _workers;
        private IList<Group> _groups;
        private IList<GroupItem> _groupItems;
        private IList<Detail> _details;
        private WorkGroupContext _context = new WorkGroupContext();

        public frmAddProducedDetails()
        {
            InitializeComponent();
            _workers = _context.Workers.Where(x => x.DismissedDate == null).ToList();
            _groups = _context.Groups.ToList();

        }

        private void frmAddProducedDetails_Load(object sender, EventArgs e)
        {
            grid.AutoGenerateColumns = false;

            lstGroups.DataSource = null;
            lstGroups.DisplayMember = "Name";
            lstGroups.ValueMember = "Id";
            lstGroups.DataSource = _groups.OrderBy(x => x.Name).ToList();
            

            lstWorkers.DataSource = null;
            lstWorkers.DisplayMember = "Name";
            lstWorkers.ValueMember = "Id";
            var workers = _workers.ToList();
            workers.Add(new Worker { Name = "", Id = Guid.Empty });
            lstWorkers.DataSource = workers.OrderBy(x => x.Name).ToList();

        }

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGroups.SelectedIndex == -1) return;
            Guid id = ((Group)lstGroups.SelectedItem).Id;
            _groupItems = _context.GroupItems.Where(x => x.Group.Id == id).OrderBy(x => x.Name).ToList();
            lstGroupItems.DataSource = null;
            lstGroupItems.DisplayMember = "Name";
            lstGroupItems.ValueMember = "Id";
            lstGroupItems.DataSource = _groupItems;
        }

        private void RefreshProdusedList()
        {
            grid.DataSource = null;

            grid.DataSource = _producedDetails.OrderByDescending(x => x.CreateDate).ToList();
            CalculateWH();
        }

        private void lstGroupItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGroupItems.SelectedIndex == -1) return;
            Guid id = ((GroupItem)lstGroupItems.SelectedItem).Id;
            _details = _context.Details.Where(x => x.GroupItem.Id == id && x.DeleteDate == null).OrderBy(x => x.Number).ToList();
            lstDetails.DataSource = null;
            lstDetails.DisplayMember = "FullName";
            lstDetails.ValueMember = "Id";
            lstDetails.DataSource = _details;
        }

        private void lstDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (((Worker)lstWorkers.SelectedItem).Name == "")
            {
                MessageBox.Show("Операторо не выбран!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var inp = new frmInputNum();
           
            if (inp.ShowDialog() != DialogResult.OK) return;
            

            int quant = inp.Value;

            var detail = lstDetails.SelectedItem as Detail;

            var producedDeatil = new ProducedDetail
            {
                Count = quant,
                Detail = detail,
                ProducedDate = dtpProducedData.Value,
                Worker = lstWorkers.SelectedItem as Worker,

            };
            _context.ProducedDetails.Add(producedDeatil);
            _producedDetails.Add(producedDeatil);
            _context.SaveChanges();
            RefreshProdusedList();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Рссчитывает сумму нормочасов за месяц у выбранного оператора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void cmbWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateWH();
        }

        private void CalculateWH ()
        {
            if (lstWorkers.SelectedItem == null) return;
            var worker = ((Worker)lstWorkers.SelectedItem);
            if (worker == null)
            {
                lblSummHour.Visible = false;
                return;
            }

            var date = dtpProducedData.Value;
            var year = date.Year;
            var month = date.Month;
            var startPeriod = new DateTime(year, month, 1);
            var endPeriod = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);

            //Выбираем все детали произведенные оператором за текущй месяц
            var details = _context.ProducedDetails.Where(x => x.Worker.Id == worker.Id
                                                && x.ProducedDate >= startPeriod
                                                && x.ProducedDate <= endPeriod)
                                                .ToList();
            var summWh = 0.0;
            //рассчет нормочасов
            foreach (var detail in details)
            {
                summWh += detail.MultiplyWh;
            }
            string[] monthName = new string[] {
                "январь", "февраль", "март",
                "апрель","май","июнь",
                "июль","август","сентябрь",
                "октябрь","ноябрь","декабрь"};

            lblSummHour.Text = $"Сумма н/ч за { monthName[month-1] } = { summWh }";
            lblSummHour.Visible = true;
        }

        private void dtpProducedData_ValueChanged_1(object sender, EventArgs e)
        {
            CalculateWH();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Запись для редактирования не выбрана!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var frm = new frmInputNum();
            var id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());
            var detail = _producedDetails.First(x => x.Id == id);
            frm.Value = detail.Count;
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                detail.Count = frm.Value;
                _context.SaveChanges();
                RefreshProdusedList();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());
            var tmp = _context.ProducedDetails.First(x => x.Id == id);
            if ((MessageBox.Show("Удалить запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                _context.ProducedDetails.Remove(tmp);
                _context.SaveChanges();
                RefreshProdusedList();
            } 
        }

        private void button1_Click(object sender, MouseEventArgs e)
        {
            lstDetails_MouseDoubleClick(sender, e);
        }

        private void btnTommorow_Click(object sender, EventArgs e)
        {
            dtpProducedData.Value = dtpProducedData.Value.AddDays(1);
        }

        private void btnYesterday_Click(object sender, EventArgs e)
        {
            dtpProducedData.Value = dtpProducedData.Value.AddDays(-1);
        }

        private void lstWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateWH();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grid_MouseDoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void lstDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((Worker)lstWorkers.SelectedItem).Name == "")
            {
                MessageBox.Show("Операторо не выбран!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var inp = new frmInputNum();

            if (inp.ShowDialog() != DialogResult.OK) return;


            int quant = inp.Value;

            var detail = lstDetails.SelectedItem as Detail;

            var producedDeatil = new ProducedDetail
            {
                Count = quant,
                Detail = detail,
                ProducedDate = dtpProducedData.Value,
                Worker = lstWorkers.SelectedItem as Worker,

            };
            _context.ProducedDetails.Add(producedDeatil);
            _producedDetails.Add(producedDeatil);
            _context.SaveChanges();
            RefreshProdusedList();
        }
    }
}
