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
    public partial class frmDetail : Form
    {
        public Detail Detail { get; set; }

        private IList<GroupItem> _groupItems;
        

        public frmDetail(IList<GroupItem> groupItems)
        {
            InitializeComponent();
            _groupItems = groupItems;
            
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {
            Location = new Point(100,100);
            nmrApplicability.Controls[0].Visible = false;
            nmrWorkingHour.Controls[0].Visible = false;
            txtNumber.Focus();
            cmbGroupItem.DataSource = null;
            cmbGroupItem.DisplayMember = "Name";
            cmbGroupItem.ValueMember = "Id";
            cmbGroupItem.DataSource = _groupItems.OrderBy(x => x.Name).ToList();

            txtNumber.Text = Detail.Number;
            txtName.Text = Detail.Name;
            nmrWorkingHour.Value = (decimal)Detail.WorkingHour;
            nmrApplicability.Value = Detail.Applicability;
            if (Detail.GroupItem != null)
                cmbGroupItem.SelectedValue = Detail.GroupItem.Id;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Detail.Number = txtNumber.Text;
            Detail.Name = txtName.Text;
            Detail.WorkingHour = (double)nmrWorkingHour.Value;
            Detail.Applicability = (int)nmrApplicability.Value;
            Detail.ModifyDate = Detail.CreateDate;
            Detail.GroupItem = (GroupItem)cmbGroupItem.SelectedItem;
            txtNumber.Focus();
            DialogResult = DialogResult.OK;
            this.Refresh();
        }

        private void nmrWorkingHour_Enter(object sender, EventArgs e)
        {
            nmrWorkingHour.Select(0, nmrWorkingHour.Text.Length);
        }

        private void nmrApplicability_Enter(object sender, EventArgs e)
        {
            nmrApplicability.Select(0, nmrApplicability.Text.Length);
        }

        private void cmbGroupItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
