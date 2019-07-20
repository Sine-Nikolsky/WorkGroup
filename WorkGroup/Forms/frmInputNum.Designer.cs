namespace WorkGroup.Forms
{
    partial class frmInputNum
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
            this.components = new System.ComponentModel.Container();
            this.nmrValue = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nmrValue)).BeginInit();
            this.SuspendLayout();
            // 
            // nmrValue
            // 
            this.nmrValue.Location = new System.Drawing.Point(12, 12);
            this.nmrValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrValue.MaximumSize = new System.Drawing.Size(137, 0);
            this.nmrValue.MinimumSize = new System.Drawing.Size(137, 0);
            this.nmrValue.Name = "nmrValue";
            this.nmrValue.Size = new System.Drawing.Size(137, 20);
            this.nmrValue.TabIndex = 0;
            this.nmrValue.Enter += new System.EventHandler(this.nmrValue_Enter);
            this.nmrValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nmrValue_KeyDown);
            this.nmrValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nmrValue_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(42, 39);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmInputNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 74);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.nmrValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(150, 150);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(255, 138);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(177, 113);
            this.Name = "frmInputNum";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Введите кол-во";
            this.Load += new System.EventHandler(this.frmInputNum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmrValue;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}