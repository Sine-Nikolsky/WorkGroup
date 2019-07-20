namespace WorkGroup.Forms
{
    partial class frmGroups
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroups));
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.lstGroupItems = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddGroups = new System.Windows.Forms.Button();
            this.btnDeliteGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroupItem = new System.Windows.Forms.Button();
            this.btnAddGroupItem = new System.Windows.Forms.Button();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.btnChangeDetail = new System.Windows.Forms.Button();
            this.btnChangeGroup = new System.Windows.Forms.Button();
            this.btnChangeGroupItem = new System.Windows.Forms.Button();
            this.chkViewAllRecords = new System.Windows.Forms.CheckBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstGroups
            // 
            this.lstGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.ItemHeight = 16;
            this.lstGroups.Location = new System.Drawing.Point(10, 34);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(153, 116);
            this.lstGroups.TabIndex = 0;
            this.lstGroups.TabStop = false;
            this.lstGroups.SelectedIndexChanged += new System.EventHandler(this.lstGroups_SelectedIndexChanged);
            // 
            // lstGroupItems
            // 
            this.lstGroupItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstGroupItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstGroupItems.FormattingEnabled = true;
            this.lstGroupItems.ItemHeight = 16;
            this.lstGroupItems.Location = new System.Drawing.Point(10, 180);
            this.lstGroupItems.Name = "lstGroupItems";
            this.lstGroupItems.Size = new System.Drawing.Size(153, 228);
            this.lstGroupItems.TabIndex = 1;
            this.lstGroupItems.TabStop = false;
            this.lstGroupItems.SelectedIndexChanged += new System.EventHandler(this.lstGroupItems_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Группы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Элементы групп";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Детали";
            // 
            // btnAddGroups
            // 
            this.btnAddGroups.Location = new System.Drawing.Point(169, 34);
            this.btnAddGroups.Name = "btnAddGroups";
            this.btnAddGroups.Size = new System.Drawing.Size(87, 23);
            this.btnAddGroups.TabIndex = 0;
            this.btnAddGroups.Text = "Добавить";
            this.btnAddGroups.UseVisualStyleBackColor = true;
            this.btnAddGroups.Click += new System.EventHandler(this.btnAddGroups_Click);
            // 
            // btnDeliteGroup
            // 
            this.btnDeliteGroup.Location = new System.Drawing.Point(169, 92);
            this.btnDeliteGroup.Name = "btnDeliteGroup";
            this.btnDeliteGroup.Size = new System.Drawing.Size(87, 23);
            this.btnDeliteGroup.TabIndex = 2;
            this.btnDeliteGroup.Text = "Удалить";
            this.btnDeliteGroup.UseVisualStyleBackColor = true;
            this.btnDeliteGroup.Click += new System.EventHandler(this.btnDeliteGroup_Click);
            // 
            // btnDeleteGroupItem
            // 
            this.btnDeleteGroupItem.Location = new System.Drawing.Point(169, 238);
            this.btnDeleteGroupItem.Name = "btnDeleteGroupItem";
            this.btnDeleteGroupItem.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteGroupItem.TabIndex = 5;
            this.btnDeleteGroupItem.Text = "Удалить";
            this.btnDeleteGroupItem.UseVisualStyleBackColor = true;
            this.btnDeleteGroupItem.Click += new System.EventHandler(this.btnDeleteGroupItem_Click);
            // 
            // btnAddGroupItem
            // 
            this.btnAddGroupItem.Location = new System.Drawing.Point(169, 180);
            this.btnAddGroupItem.Name = "btnAddGroupItem";
            this.btnAddGroupItem.Size = new System.Drawing.Size(87, 23);
            this.btnAddGroupItem.TabIndex = 3;
            this.btnAddGroupItem.Text = "Добавить";
            this.btnAddGroupItem.UseVisualStyleBackColor = true;
            this.btnAddGroupItem.Click += new System.EventHandler(this.btnAddGroupItem_Click);
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDetail.Location = new System.Drawing.Point(491, 92);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteDetail.TabIndex = 9;
            this.btnDeleteDetail.Text = "Удалить";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDetail.Location = new System.Drawing.Point(490, 34);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(87, 23);
            this.btnAddDetail.TabIndex = 7;
            this.btnAddDetail.Text = "Добавить";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(490, 431);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstDetails
            // 
            this.lstDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.ItemHeight = 16;
            this.lstDetails.Location = new System.Drawing.Point(275, 34);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(209, 372);
            this.lstDetails.TabIndex = 13;
            this.lstDetails.TabStop = false;
            // 
            // btnChangeDetail
            // 
            this.btnChangeDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeDetail.Location = new System.Drawing.Point(491, 63);
            this.btnChangeDetail.Name = "btnChangeDetail";
            this.btnChangeDetail.Size = new System.Drawing.Size(87, 23);
            this.btnChangeDetail.TabIndex = 8;
            this.btnChangeDetail.Text = "Изменить";
            this.btnChangeDetail.UseVisualStyleBackColor = true;
            this.btnChangeDetail.Click += new System.EventHandler(this.btnEditDetail_Click);
            // 
            // btnChangeGroup
            // 
            this.btnChangeGroup.Location = new System.Drawing.Point(169, 63);
            this.btnChangeGroup.Name = "btnChangeGroup";
            this.btnChangeGroup.Size = new System.Drawing.Size(87, 23);
            this.btnChangeGroup.TabIndex = 1;
            this.btnChangeGroup.Text = "Изменить";
            this.btnChangeGroup.UseVisualStyleBackColor = true;
            this.btnChangeGroup.Click += new System.EventHandler(this.btnEditGroup_Click);
            // 
            // btnChangeGroupItem
            // 
            this.btnChangeGroupItem.Location = new System.Drawing.Point(169, 209);
            this.btnChangeGroupItem.Name = "btnChangeGroupItem";
            this.btnChangeGroupItem.Size = new System.Drawing.Size(87, 23);
            this.btnChangeGroupItem.TabIndex = 4;
            this.btnChangeGroupItem.Text = "Изменить";
            this.btnChangeGroupItem.UseVisualStyleBackColor = true;
            this.btnChangeGroupItem.Click += new System.EventHandler(this.btnEditGroupItem_Click);
            // 
            // chkViewAllRecords
            // 
            this.chkViewAllRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkViewAllRecords.AutoSize = true;
            this.chkViewAllRecords.Location = new System.Drawing.Point(12, 431);
            this.chkViewAllRecords.Name = "chkViewAllRecords";
            this.chkViewAllRecords.Size = new System.Drawing.Size(187, 17);
            this.chkViewAllRecords.TabIndex = 14;
            this.chkViewAllRecords.Text = "Показать удаленные элементы";
            this.chkViewAllRecords.UseVisualStyleBackColor = true;
            this.chkViewAllRecords.CheckedChanged += new System.EventHandler(this.chkViewAllRecords_CheckedChanged);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Location = new System.Drawing.Point(492, 121);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(86, 23);
            this.btnRestore.TabIndex = 15;
            this.btnRestore.Text = "Восстановить";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 466);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.chkViewAllRecords);
            this.Controls.Add(this.btnChangeGroupItem);
            this.Controls.Add(this.btnChangeGroup);
            this.Controls.Add(this.btnChangeDetail);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteDetail);
            this.Controls.Add(this.btnAddDetail);
            this.Controls.Add(this.btnDeleteGroupItem);
            this.Controls.Add(this.btnAddGroupItem);
            this.Controls.Add(this.btnDeliteGroup);
            this.Controls.Add(this.btnAddGroups);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstGroupItems);
            this.Controls.Add(this.lstGroups);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(605, 505);
            this.Name = "frmGroups";
            this.ShowIcon = false;
            this.Text = "Справочник деталей";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGroups_FormClosed);
            this.Load += new System.EventHandler(this.frmGroups_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.ListBox lstGroupItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddGroups;
        private System.Windows.Forms.Button btnDeliteGroup;
        private System.Windows.Forms.Button btnDeleteGroupItem;
        private System.Windows.Forms.Button btnAddGroupItem;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstDetails;
        private System.Windows.Forms.Button btnChangeDetail;
        private System.Windows.Forms.Button btnChangeGroup;
        private System.Windows.Forms.Button btnChangeGroupItem;
        private System.Windows.Forms.CheckBox chkViewAllRecords;
        private System.Windows.Forms.Button btnRestore;
    }
}