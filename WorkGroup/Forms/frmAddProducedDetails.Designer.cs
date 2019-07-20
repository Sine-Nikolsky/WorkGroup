namespace WorkGroup.Forms
{
    partial class frmAddProducedDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMultipyWh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstGroupItems = new System.Windows.Forms.ListBox();
            this.dtpProducedData = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSummHour = new System.Windows.Forms.Label();
            this.lstWorkers = new System.Windows.Forms.ListBox();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTommorow = new System.Windows.Forms.Button();
            this.btnYesterday = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(951, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colCount,
            this.colWh,
            this.colMultipyWh,
            this.colWorker,
            this.colDate});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(214, 295);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(731, 211);
            this.grid.TabIndex = 32;
            this.grid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid_MouseDoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "DetailInfo";
            this.colName.HeaderText = "Деталь";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 235;
            // 
            // colCount
            // 
            this.colCount.DataPropertyName = "Count";
            this.colCount.HeaderText = "Кол-во";
            this.colCount.Name = "colCount";
            this.colCount.Width = 70;
            // 
            // colWh
            // 
            this.colWh.DataPropertyName = "WorkingHour";
            this.colWh.FillWeight = 40F;
            this.colWh.HeaderText = "н/ч";
            this.colWh.Name = "colWh";
            this.colWh.ReadOnly = true;
            this.colWh.Width = 50;
            // 
            // colMultipyWh
            // 
            this.colMultipyWh.DataPropertyName = "MultiplyWh";
            this.colMultipyWh.HeaderText = "Сумм. н/ч";
            this.colMultipyWh.Name = "colMultipyWh";
            this.colMultipyWh.ReadOnly = true;
            this.colMultipyWh.Width = 80;
            // 
            // colWorker
            // 
            this.colWorker.DataPropertyName = "WorkerName";
            this.colWorker.HeaderText = "Оператор";
            this.colWorker.Name = "colWorker";
            this.colWorker.ReadOnly = true;
            this.colWorker.Width = 150;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "ProducedDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDate.HeaderText = "Дата";
            this.colDate.Name = "colDate";
            // 
            // lstDetails
            // 
            this.lstDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDetails.ColumnWidth = 250;
            this.lstDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.ItemHeight = 16;
            this.lstDetails.Location = new System.Drawing.Point(367, 30);
            this.lstDetails.MultiColumn = true;
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(578, 228);
            this.lstDetails.TabIndex = 43;
            this.lstDetails.TabStop = false;
            this.lstDetails.SelectedIndexChanged += new System.EventHandler(this.lstDetails_SelectedIndexChanged);
            this.lstDetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstDetails_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Детали";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Элементы групп";
            // 
            // lstGroupItems
            // 
            this.lstGroupItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstGroupItems.FormattingEnabled = true;
            this.lstGroupItems.ItemHeight = 16;
            this.lstGroupItems.Location = new System.Drawing.Point(214, 30);
            this.lstGroupItems.Name = "lstGroupItems";
            this.lstGroupItems.Size = new System.Drawing.Size(147, 228);
            this.lstGroupItems.TabIndex = 39;
            this.lstGroupItems.TabStop = false;
            this.lstGroupItems.SelectedIndexChanged += new System.EventHandler(this.lstGroupItems_SelectedIndexChanged);
            // 
            // dtpProducedData
            // 
            this.dtpProducedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpProducedData.Location = new System.Drawing.Point(22, 156);
            this.dtpProducedData.Name = "dtpProducedData";
            this.dtpProducedData.Size = new System.Drawing.Size(183, 22);
            this.dtpProducedData.TabIndex = 45;
            this.dtpProducedData.ValueChanged += new System.EventHandler(this.dtpProducedData_ValueChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Оператор";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(951, 295);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(951, 324);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 50;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Изготовлено за смену";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "Группы";
            // 
            // lblSummHour
            // 
            this.lblSummHour.AutoSize = true;
            this.lblSummHour.Location = new System.Drawing.Point(25, 245);
            this.lblSummHour.Name = "lblSummHour";
            this.lblSummHour.Size = new System.Drawing.Size(34, 13);
            this.lblSummHour.TabIndex = 56;
            this.lblSummHour.Text = "summ";
            this.lblSummHour.Visible = false;
            // 
            // lstWorkers
            // 
            this.lstWorkers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstWorkers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstWorkers.FormattingEnabled = true;
            this.lstWorkers.ItemHeight = 16;
            this.lstWorkers.Location = new System.Drawing.Point(25, 293);
            this.lstWorkers.Name = "lstWorkers";
            this.lstWorkers.Size = new System.Drawing.Size(180, 212);
            this.lstWorkers.TabIndex = 57;
            this.lstWorkers.SelectedIndexChanged += new System.EventHandler(this.lstWorkers_SelectedIndexChanged);
            // 
            // lstGroups
            // 
            this.lstGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.ItemHeight = 16;
            this.lstGroups.Location = new System.Drawing.Point(22, 30);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(186, 100);
            this.lstGroups.TabIndex = 58;
            this.lstGroups.SelectedIndexChanged += new System.EventHandler(this.lstGroups_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(951, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTommorow
            // 
            this.btnTommorow.Location = new System.Drawing.Point(129, 185);
            this.btnTommorow.Name = "btnTommorow";
            this.btnTommorow.Size = new System.Drawing.Size(75, 23);
            this.btnTommorow.TabIndex = 60;
            this.btnTommorow.Text = "Завтра";
            this.btnTommorow.UseVisualStyleBackColor = true;
            this.btnTommorow.Click += new System.EventHandler(this.btnTommorow_Click);
            // 
            // btnYesterday
            // 
            this.btnYesterday.Location = new System.Drawing.Point(22, 185);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(75, 23);
            this.btnYesterday.TabIndex = 61;
            this.btnYesterday.Text = "Вчера";
            this.btnYesterday.UseVisualStyleBackColor = true;
            this.btnYesterday.Click += new System.EventHandler(this.btnYesterday_Click);
            // 
            // frmAddProducedDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 518);
            this.Controls.Add(this.btnYesterday);
            this.Controls.Add(this.btnTommorow);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstGroups);
            this.Controls.Add(this.lstWorkers);
            this.Controls.Add(this.lblSummHour);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpProducedData);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstGroupItems);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.MinimumSize = new System.Drawing.Size(1056, 445);
            this.Name = "frmAddProducedDetails";
            this.ShowIcon = false;
            this.Text = "Добавить изготовленные детали";
            this.Load += new System.EventHandler(this.frmAddProducedDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ListBox lstDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstGroupItems;
        private System.Windows.Forms.DateTimePicker dtpProducedData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSummHour;
        private System.Windows.Forms.ListBox lstWorkers;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTommorow;
        private System.Windows.Forms.Button btnYesterday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMultipyWh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    }
}