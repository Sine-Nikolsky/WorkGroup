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
    public partial class frmGroups : Form
    {
        private WorkGroupContext _context = new WorkGroupContext();
        public frmGroups()
        {
            InitializeComponent();
            
            
        }

        private void frmGroups_Load(object sender, EventArgs e)
        {
            Location = new Point(100, 100);
            RefreshGroups();
            chkViewAllRecords.Checked = false;
            btnRestore.Enabled = false;
        }
        

        private IList<GroupItem> GetGroupItem(Guid groupId)
        {
            return _context.GroupItems.Where(x => x.Group.Id == groupId).ToList(); 
        }

        private IList<Detail> GetDetail(Guid groupItemId)
        {
            return _context.Details.Where(x => x.GroupItem.Id == groupItemId).ToList();
        }

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGroupItems();
        }

        private void RefreshGroups()
        {
            lstGroups.DataSource = null;
            lstGroups.DisplayMember = "Name";
            lstGroups.ValueMember = "Id";
            lstGroups.DataSource = _context.Groups.OrderBy(x=> x.Name).ToList();
        }

        private void RefreshGroupItems()
        {
            if (lstGroups.SelectedItem == null) return;
            else
            {
                Guid id = Guid.Parse(((Group)lstGroups.SelectedItem).Id.ToString());
                lstGroupItems.DataSource = null;
                lstGroupItems.DisplayMember = "Name";
                lstGroupItems.ValueMember = "Id";
                lstGroupItems.DataSource = GetGroupItem(id).OrderBy(x=>x.Name).ToList();
            }  
                //GroupItems.OrderBy(x => x.Name).ToList();
        }


        private void btnAddGroups_Click(object sender, EventArgs e)
        {
            var frm = new frmInputBox();

            frm.Text += "группы";

            var result = frm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var index = lstGroups.FindStringExact(frm.Value);
                if (index == -1)
                {
                    var group = new Group()
                    {
                        Name = frm.Value,
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        ModifyDate = DateTime.Now,
                        DeleteDate = null
                    };
                    _context.Groups.Add(group);
                    _context.SaveChanges();
                    RefreshGroups();
                }
                else
                {
                    MessageBox.Show("Запись с таким именем уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstGroups.SetSelected(index, true);
                    return;
                }
                var indx = lstGroups.FindStringExact(frm.Value);
                if (indx == -1)
                {
                    return;
                }
                else lstGroups.SetSelected(indx, true);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void frmGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnAddGroupItem_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Сначала выберите группу.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var frm = new frmInputBox();
            frm.Text += "элемента";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var index = lstGroupItems.FindStringExact(frm.Value);
                if (index == -1)
                {
                        var item = new GroupItem()
                        {

                            Name = frm.Value,
                            ModifyDate = DateTime.Now,
                            DeleteDate = null,
                            Group = (Group)lstGroups.SelectedItem
                        };
                        _context.GroupItems.Add(item);
                        _context.SaveChanges();
                        RefreshGroupItems();
                }
                else
                {
                    MessageBox.Show("Запись с таким именем уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstGroupItems.SetSelected(index, true);
                    return;
                }
                
                var indx = lstGroupItems.FindStringExact(frm.Value);
                if (indx == -1)
                {
                    return;
                }
                else lstGroupItems.SetSelected(indx, true);
            }
        }

        private void btnDeliteGroup_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите группу для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var group = (Group)lstGroups.SelectedItem;

            if (group.GroupItems != null && group.GroupItems.Any())
            {
                MessageBox.Show("Удалите все элементы группы, прежде чем удалять саму группу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show("Удалить запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
                RefreshGroups();
            }

        }

        private void btnDeleteGroupItem_Click(object sender, EventArgs e)
        {
            if (lstGroupItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите элемент группы для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var item = (GroupItem)lstGroupItems.SelectedItem;

            if (_context.Details.Any(x => x.GroupItem.Id == item.Id))
            {
                MessageBox.Show("Удалите все детали, прежде чем удалять элемент группы.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Удалить запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                _context.GroupItems.Remove(item);
                _context.SaveChanges();
                RefreshGroupItems();
            }
        }

        private void lstGroupItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var groupItem = lstGroupItems.SelectedItem as GroupItem;
            if (groupItem == null)
            {
                return;
            }
            RefreshDetails(groupItem.Id); 
        }
        

        private void RefreshDetails(Guid groupItemId)
        {
            lstDetails.DataSource = null;
            lstDetails.DisplayMember = "FullName";
            lstDetails.ValueMember = "Id";
            if (chkViewAllRecords.Checked == true)
            {
                lstDetails.DataSource = _context.Details.Where(x => x.GroupItem.Id == groupItemId)
                .OrderBy(x => x.Number).ToList();
            }
            else
            {
                lstDetails.DataSource = _context.Details.Where(x => x.GroupItem.Id == groupItemId && x.DeleteDate == null)
                .OrderBy(x => x.Number).ToList();
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var form = new frmDetail(_context.GroupItems.ToList());
            do
            {
                if (lstGroupItems.SelectedIndex == -1)
                {
                    MessageBox.Show("Сначала выберите элемент группы.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                form.Detail = new Detail() { GroupItem = (GroupItem)lstGroupItems.SelectedItem };

                if (DialogResult.OK == form.ShowDialog())
                {
                    var index = lstDetails.FindString(form.Detail.FullName);
                    if (index == -1)
                    {
                        _context.Details.Add(form.Detail);
                        _context.SaveChanges();
                        RefreshDetails(((GroupItem)lstGroupItems.SelectedItem).Id);
                    }
                    else
                    {
                        MessageBox.Show("Запись с таким именем уже существует.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lstDetails.SetSelected(index, true);
                        return;
                    }
                }
            } while (form.DialogResult == DialogResult.OK);
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (lstDetails.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите деталь для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Удалить запись?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                var groupItem = lstGroupItems.SelectedItem as GroupItem;
                var detail = (Detail)lstDetails.SelectedItem;
                detail.DeleteDate = DateTime.Now;
                if (detail.Number.IndexOf('_') == -1)
                {
                    detail.Number = "_" + detail.Number;
                }
                _context.SaveChanges();
                RefreshDetails(groupItem.Id);
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите группу для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var frm = new frmInputBox();
            frm.Text = "Изменить имя группы";
            var group = (Group)lstGroups.SelectedItem;
            frm.Value = group.Name;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                group.Name = frm.Value;
                _context.SaveChanges();
                RefreshGroups();
            }
        }

        private void btnEditGroupItem_Click(object sender, EventArgs e)
        {
            if (lstGroupItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите элемент группы для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var frm = new frmInputBox();
            frm.Text = "Изменить имя элемента группы";
            var groupItem = (GroupItem)lstGroupItems.SelectedItem;
            frm.Value = groupItem.Name;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                groupItem.Name = frm.Value;
                _context.SaveChanges();
                RefreshGroups();
            }
        }

        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            if (lstDetails.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите деталь для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var groupItem = lstGroupItems.SelectedItem as GroupItem;
            var frm = new frmDetail(_context.GroupItems.ToList());
            frm.Detail = (Detail)lstDetails.SelectedItem;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //var
                _context.SaveChanges();
                RefreshDetails(groupItem.Id);
            }
          
            
        }

        private void lstGroups_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkViewAllRecords_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewAllRecords.Checked == true)
            {
                btnRestore.Enabled = true;
                RefreshDetails(((GroupItem)lstGroupItems.SelectedItem).Id);
            }
            else if (chkViewAllRecords.Checked == false)
            {
                btnRestore.Enabled = false;
                RefreshDetails(((GroupItem)lstGroupItems.SelectedItem).Id);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var detail = (Detail)lstDetails.SelectedItem;
            detail.DeleteDate = null;
            detail.Number = detail.Number.Replace("_", "");
            _context.SaveChanges();
            RefreshDetails(((GroupItem)lstGroupItems.SelectedItem).Id);
        }
    }
}
