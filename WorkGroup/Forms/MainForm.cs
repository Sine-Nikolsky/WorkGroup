using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkGroup.Context;
using WorkGroup.Dpo;
using WorkGroup.Entities;

namespace WorkGroup.Forms
{
    public partial class MainForm : Form
    {
        private WorkGroupContext _context = new WorkGroupContext(); 

        private IList<ProducedDetail> _allProducedDetails = new List<ProducedDetail>();

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            grid.Columns[1].DefaultCellStyle.Format = "dd MMMM yyyy";
            RefreshGridInitial();

            var tmp = _context.Workers.Where(x => x.DismissedDate == null).ToList();
            cmbWorker.DataSource = null;
            cmbWorker.DisplayMember = "Name";
            cmbWorker.ValueMember = "Id";
            tmp.Add(new Worker { Id = Guid.Empty, Name = "" });
            cmbWorker.DataSource = tmp.OrderBy(x => x.Name).ToList();
            CalculateWH();
        }

        public void CalculateWH()
        {
            var workersQuery = _context.Workers.Where(x => x.DismissedDate == null);

            var date = dtpEndPeriod.Value;
            var year = date.Year;
            var month = date.Month;
            var startPeriod = new DateTime(year, month, 1);
            var endPeriod = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);

            var producedDetailQuery = _context.ProducedDetails.Where(x => x.ProducedDate > startPeriod && x.ProducedDate < endPeriod).ToList();

            IList<WorkersWH> list = new List<WorkersWH>();
            foreach (var worker in workersQuery)
            {
                var tmp = new WorkersWH();
                tmp.Name = worker.Name;
                tmp.WH = 0.0;
                foreach (var detail in producedDetailQuery)
                {
                    if (detail.Worker.Id == worker.Id)
                    {
                        tmp.WH += detail.MultiplyWh;
                    }
                }
                list.Add(tmp);
            }
            var allWH = 0.0;
            foreach (var item in list)
            {
                allWH += item.WH;
            }
            lstWorkersWH.DataSource = null;
            lstWorkersWH.ValueMember = "Name";
            lstWorkersWH.DisplayMember = "Info";
            lstWorkersWH.DataSource = list.OrderBy(x => x.WH).ToList();
            label8.Text = allWH + " н/ч";
        }

        private void DownloadAllProducedDetails()
        {
            _allProducedDetails = _context.ProducedDetails.ToList();
        }

        private void DownloadAllProducedDetails(DateTime start, DateTime end)
        {
            _allProducedDetails = _context.ProducedDetails.Where(x => x.ProducedDate >= start &&
                                             x.ProducedDate <= end).ToList();
        }

        private void RefreshGridInitial()
        {
            DownloadAllProducedDetails(dtpStartPeriod.Value, dtpEndPeriod.Value);
            var date = dtpStartPeriod.Value;
            var year = date.Year;
            var month = date.Month;
            dtpStartPeriod.Value = new DateTime(year, month, 1);
            dtpEndPeriod.Value = DateTime.Now;
            //dtpEndPeriod.Value = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);
            RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
        }

        private void RefreshGrid (DateTime start, DateTime end)
        {
            DownloadAllProducedDetails(dtpStartPeriod.Value, dtpEndPeriod.Value);
            grid.DataSource = _allProducedDetails.Where(x => x.ProducedDate >= start &&
                                             x.ProducedDate <= end).Select(x =>
                                            new
                                            {
                                                x.Id,
                                                x.DetailInfo,
                                                x.ProducedDate,
                                                x.WorkerName,
                                                x.Count,
                                                x.MultiplyWh
                                            }).
                                             OrderByDescending(x => x.ProducedDate).ToList();
            CalculateWH();

        }

        private void RefreshGrid(DateTime start, DateTime end, Worker worker)
        {
            //grid.DataSource = null;
            grid.DataSource = _allProducedDetails.Where(x => x.ProducedDate >= start &&
                                             x.ProducedDate <= end && x.Worker.Name == worker.Name
                                             ).Select(x =>
                                            new
                                            {
                                                x.Id,
                                                x.DetailInfo,
                                                x.ProducedDate,
                                                x.WorkerName,
                                                x.Count,
                                                x.MultiplyWh
                                            }).
                                             OrderByDescending(x => x.ProducedDate).ToList();
        }

        private void справочникДеталейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmGroups = new frmGroups();
            frmGroups.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void списокРабочихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmWorkers();
            frm.ShowDialog();
            var tmp = _context.Workers.Where(x => x.DismissedDate == null).ToList();
            //cmbWorker.DataSource = null; exeption in cmbWorker method
            cmbWorker.DisplayMember = "Name";
            cmbWorker.ValueMember = "Id";
            tmp.Add(new Worker { Id = Guid.Empty, Name = "" });
            cmbWorker.DataSource = tmp.OrderBy(x => x.Name).ToList();
        }

        private void добавитьПроизведенныеДеталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAddProducedDetails();
            form.ShowDialog();
            RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
        }

        private void dtpStartPeriod_ValueChanged(object sender, EventArgs e)
        {
            var worker = (Worker)cmbWorker.SelectedItem;
            if (worker == null || worker.Name == "")
            {
                RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
            }
            else
            { 
                RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value, worker);
            }
        }

        private void dtpEndPeriod_ValueChanged(object sender, EventArgs e)
        {
            var worker = (Worker)cmbWorker.SelectedItem;
            if (worker == null || worker.Name == "")
            {
                RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
            }
            else
            {
                RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value, worker);
            }
        }

        private void cmbWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var worker = (Worker)cmbWorker.SelectedItem;
            if (worker.Name == "")
            {
                RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
            }
            else
            {
                RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value, worker);
            }
        }

        private void chkViewAllRecords_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewAllRecords.Checked == true)
            {
                cmbWorker.Enabled = false;
                dtpEndPeriod.Enabled = false;
                dtpStartPeriod.Enabled = false;
                DownloadAllProducedDetails();
                grid.DataSource = _allProducedDetails.Select(x =>
                                            new
                                            {
                                                x.Id,
                                                x.DetailInfo,
                                                x.ProducedDate,
                                                x.WorkerName,
                                                x.Count,
                                                x.MultiplyWh
                                            }).
                                             OrderByDescending(x => x.ProducedDate).ToList();
            }
            else if(chkViewAllRecords.Checked == false)
            {
                cmbWorker.Enabled = true;
                dtpEndPeriod.Enabled = true;
                dtpStartPeriod.Enabled = true;
                RefreshGridInitial();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text.ToLower();
            if (text.Length != 0)
            {
                var searchList = _allProducedDetails.Where(x => x.DetailInfo.ToLower().Contains(text) == true).Select(x =>
                                                new
                                                {
                                                    x.Id,
                                                    x.DetailInfo,
                                                    x.ProducedDate,
                                                    x.WorkerName,
                                                    x.Count,
                                                    x.MultiplyWh
                                                }).OrderByDescending(x => x.ProducedDate).ToList();

                grid.DataSource = searchList;
                
            }
            else MessageBox.Show("Поле не должно быть пустым!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = ""; 
            RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
        }

        private void отчетПРБToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            var producedDetailQuery = _allProducedDetails.Where(x => x.ProducedDate >= dtpStartPeriod.Value && x.ProducedDate <= dtpEndPeriod.Value);
            var list = producedDetailQuery.GroupBy(x => x.DetailInfo).Select(group => new GroupedProducedDetailDpo
            {
                Name = group.Key,
                Count = group.Sum(p => p.Count),
                sumWH = group.Sum(p => p.MultiplyWh)
            }).OrderBy(x =>x.Name).ToList();

            double summWh = 0;

            var workbook = new XLWorkbook();

            int monthNum = dtpEndPeriod.Value.Month;

            string[] monthName = new string[] {
                "январь", "февраль", "март",
                "апрель","май","июнь",
                "июль","август","сентябрь",
                "октябрь","ноябрь","декабрь"};

            var worksheet = workbook.Worksheets.Add($"Отчет за {monthName[monthNum - 1]} {dtpEndPeriod.Value.Year}г");

            worksheet.Cell(1, 2).Value = $"Отчет за {monthName[monthNum - 1]} {dtpEndPeriod.Value.Year}г";
            worksheet.Cell(1, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(1, 2).Style.Font.Bold = true;
            
            worksheet.Cell(3, 1).Value = "ID";
            worksheet.Cell(3, 2).Value = "Деталь";
            worksheet.Cell(3, 3).Value = "Кол-во";
            worksheet.Cell(3, 4).Value = " Сумм н/ч";

            int i;
            for (i = 0; i < list.Count; i++ )
            {
                worksheet.Cell(i + 4, 1).Value = i+1;
                worksheet.Cell(i + 4, 2).Value = list[i].Name;
                worksheet.Cell(i + 4, 3).Value = list[i].Count;
                worksheet.Cell(i + 4, 4).Value = list[i].sumWH;
                summWh += list[i].sumWH;
            }

            var workersQuery = _context.Workers.Where(x => x.Id != null);
            IList<WorkersWH> workersList = new List<WorkersWH>();
            foreach (var worker in workersQuery)
            {
                var tmp = new WorkersWH();
                tmp.Name = worker.Name;
                tmp.WH = 0.0;
                foreach (var detail in producedDetailQuery)
                {
                    if (detail.Worker.Id == worker.Id)
                    {
                        tmp.WH += detail.MultiplyWh;
                    }
                }
                workersList.Add(tmp);
            }
            workersList.OrderBy(x => x.Name).ToList();
            int j;
            for (j = 0; j< workersList.Count(); j++ )
            {
                worksheet.Cell(i + j + 5, 2).Value = workersList[j].Name;
                worksheet.Cell(i + j + 5, 3).Value = workersList[j].WH + " н/ч";
            }
            
            worksheet.Cell(i + j + 6, 2).Value = "Суммарно:";
            worksheet.Cell(i + j + 6, 3).Value = summWh +" н/ч";

            worksheet.Range(3, 1, 3, 4).Style.Font.Bold = true;
            worksheet.Range(3, 1, i + j + 6,  4).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Range(3, 1, i + j + 6, 4).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            worksheet.Range(i + 5, 1, i + j + 6, 4).Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            worksheet.Range(3, 3, i + j + 7, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(3, 1, 3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(i + j + 5, 1, i + j + 6, 4).Style.Font.Bold = true;

            worksheet.Columns().AdjustToContents();

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files|*.xlsx",
                Title = "Сохранить как...",
                FileName = $"Отчет ПРБ за {monthName[monthNum - 1]} {dtpEndPeriod.Value.Year}г"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Сохранение произведено успешно.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void отчетЭкономистуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = _allProducedDetails.Where(x => x.ProducedDate >= dtpStartPeriod.Value && 
                                                       x.ProducedDate <= dtpEndPeriod.Value).
                                                       OrderBy(x => x.Worker.Name).ThenBy(x=>x.Detail.Number).ToList();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add($"Наряды({dtpStartPeriod.Value.ToShortDateString()}-{dtpEndPeriod.Value.ToShortDateString()}");
      
            worksheet.Cell(1, 1).Value = "Наряды";
            worksheet.Cell(1, 3).Value = $"с {dtpStartPeriod.Value.ToShortDateString()}";
            worksheet.Cell(1, 4).Value = $"по {dtpEndPeriod.Value.ToShortDateString()}";
            
            worksheet.Range(1, 1, 1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(1, 1, 1, 4).Style.Font.Bold = true;


            worksheet.Cell(3, 1).Value = "Дата";
            worksheet.Cell(3, 2).Value = "Таб №";
            worksheet.Cell(3, 3).Value = "Оператор";
            worksheet.Cell(3, 4).Value = "Группа";
            worksheet.Cell(3, 5).Value = "Деталь";
            worksheet.Cell(3, 6).Value = "Название";
            worksheet.Cell(3, 7).Value = "Кол-во";

            int i;
            double summWH = 0.0;
            for (i = 0; i < list.Count; i++)
            {
                worksheet.Cell(i + 4, 1).Value = list[i].ProducedDate.ToShortDateString();
                worksheet.Cell(i + 4, 2).Value = list[i].Worker.PersonalNumber;
                worksheet.Cell(i + 4, 3).Value = list[i].WorkerName;
                worksheet.Cell(i + 4, 4).Value = list[i].Detail.GroupItem.Name;
                worksheet.Cell(i + 4, 5).Value = list[i].Detail.Number;
                worksheet.Cell(i + 4, 6).Value = list[i].Detail.Name;
                worksheet.Cell(i + 4, 7).Value = list[i].Count + " шт";
                summWH += list[i].MultiplyWh;
            }

            var workersQuery = _context.Workers.Where(x => x.Id != null);
            IList<WorkersWH> workersList = new List<WorkersWH>();
            foreach (var worker in workersQuery)
            {
                var tmp = new WorkersWH();
                tmp.Name = worker.Name;
                tmp.WH = 0.0;
                foreach (var detail in list)
                {
                    if (detail.Worker.Id == worker.Id)
                    {
                        tmp.WH += detail.MultiplyWh;
                    }
                }
                workersList.Add(tmp);
            }
            workersList.OrderBy(x => x.Name).ToList();
            int j;
            for (j = 0; j < workersList.Count(); j++)
            {
                worksheet.Cell(i + j + 5, 3).Value = workersList[j].Name;
                worksheet.Cell(i + j + 5, 4).Value = workersList[j].WH + " н/ч";
            }
            worksheet.Cell(i + j + 6, 3).Value = "Суммарно";
            worksheet.Cell(i + j + 6, 4).Value = summWH + " н/ч";

            worksheet.Range(3, 1, 3, 7).Style.Font.Bold = true;
            worksheet.Range(3, 1, i + j + 6, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Range(3, 1, i + j + 6, 7).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            worksheet.Range(3, 7, i + j + 7, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(3, 1, 3, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(4, 1, i + 4 , 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range(i + 5, 1, i + j + 6, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            worksheet.Range(i + j + 6, 1, i + j + 6, 7).Style.Font.Bold = true;
            worksheet.Range(1, 2, i + j + 7, 7).SetDataType(XLCellValues.Text);

            worksheet.Columns().AdjustToContents();

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files|*.xlsx",
                Title = "Сохранить как...",
                FileName = $"Наряды ({dtpStartPeriod.Value.ToShortDateString()}-{dtpEndPeriod.Value.ToShortDateString()})"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Сохранение произведено успешно.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frm = new frmProducedDetailEdit();
            var id = Guid.Parse(grid.SelectedRows[0].Cells["colId"].Value.ToString());
            var detail = _allProducedDetails.First(x => x.Id == id);
            frm.Count = detail.Count;
            frm.ProduceDate = detail.ProducedDate;
            frm.WorkerId = detail.Worker.Id;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                detail.Worker =_context.Workers.First(x => x.Id == frm.WorkerId);
                detail.Count = frm.Count;
                detail.ProducedDate = frm.ProduceDate;
                _context.SaveChanges();
                RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
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
            ProducedDetail tmp = _context.ProducedDetails.First(x => x.Id == id);
            if ((MessageBox.Show("Удалить запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                _context.ProducedDetails.Remove(tmp);
                _context.SaveChanges();
                DownloadAllProducedDetails(dtpStartPeriod.Value, dtpEndPeriod.Value);
                if (txtSearch.Text.Length == 0 && cmbWorker.SelectedIndex == 0)
                {
                    RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
                }
                else if (txtSearch.Text.Length != 0)
                {
                    RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
                    btnSearch_Click(sender, e);
                }
                else if (cmbWorker.SelectedIndex != 0)
                {
                    RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
                    cmbWorker_SelectedIndexChanged(sender, e);
                }
                
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: btnEdit_Click(sender, e);
                    break;
                case Keys.Delete:
                    btnDelete_Click(sender, e);
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            добавитьПроизведенныеДеталиToolStripMenuItem_Click(sender, e);
        }

        private void удалитьИзБазыДанныхВсеПроизведенныеДеталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ВНИМАНИЕ!\n\nСейчас произойдет удаление списка\nпроизведенных деталей за все время.\nЭто может быть необходимо для обеспечения быстродействия" +
                " приложения. \nДанное действие НЕОБРАТИМО","Предупреждение",  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (MessageBox.Show("Действительно удалить все произведенные детали?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    var list = _context.ProducedDetails.Where(x => x.Id != null).ToList();
                    _context.ProducedDetails.RemoveRange(list);
                    _context.SaveChanges();
                    RefreshGridInitial();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DownloadAllProducedDetails(dtpStartPeriod.Value, dtpEndPeriod.Value);
            RefreshGrid(dtpStartPeriod.Value, dtpEndPeriod.Value);
        }

        private void очиститьБазуДанныхПолностьюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ВНИМАНИЕ!\n\nСейчас произойдет удаление базы данных.\nДанное действие НЕОБРАТИМО. Действительно очистить базу данных?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (MessageBox.Show("Действительно очистить базу данных?\nПриложение будет закрыто", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    var prodDet = _context.ProducedDetails.Where(x => x.Id != null).ToList();
                    _context.ProducedDetails.RemoveRange(prodDet);
                    var wrk = _context.Workers.Where(x => x.Id != null).ToList();
                    _context.Workers.RemoveRange(wrk);
                    var dtl = _context.Details.Where(x => x.Id != null).ToList();
                    _context.Details.RemoveRange(dtl);
                    var grIt = _context.GroupItems.Where(x => x.Id != null).ToList();
                    _context.GroupItems.RemoveRange(grIt);
                    var gr = _context.Groups.Where(x => x.Id != null).ToList();
                    _context.Groups.RemoveRange(gr);
                   
                    _context.SaveChanges();
                    this.Close();
                    
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
