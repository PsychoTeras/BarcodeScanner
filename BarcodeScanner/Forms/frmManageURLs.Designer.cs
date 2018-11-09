namespace BarcodeScanner.Forms
{
    partial class frmManageURLs
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
            this.tplMain = new BarcodeScanner.Controls.BorderedTableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbURLs = new System.Windows.Forms.TextBox();
            this.tplMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplMain
            // 
            this.tplMain.ColumnCount = 2;
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplMain.Controls.Add(this.btnOk, 0, 1);
            this.tplMain.Controls.Add(this.btnCancel, 1, 1);
            this.tplMain.Controls.Add(this.tbURLs, 0, 0);
            this.tplMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplMain.Location = new System.Drawing.Point(12, 14);
            this.tplMain.Name = "tplMain";
            this.tplMain.RowCount = 2;
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tplMain.Size = new System.Drawing.Size(610, 463);
            this.tplMain.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(424, 425);
            this.btnOk.Margin = new System.Windows.Forms.Padding(5, 8, 3, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(516, 425);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 8, 7, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbURLs
            // 
            this.tbURLs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tplMain.SetColumnSpan(this.tbURLs, 2);
            this.tbURLs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbURLs.Location = new System.Drawing.Point(3, 3);
            this.tbURLs.Multiline = true;
            this.tbURLs.Name = "tbURLs";
            this.tbURLs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbURLs.Size = new System.Drawing.Size(604, 411);
            this.tbURLs.TabIndex = 1;
            // 
            // frmManageURLs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 491);
            this.Controls.Add(this.tplMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 530);
            this.Name = "frmManageURLs";
            this.Padding = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Endpoint URLs";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManageURLs_KeyDown);
            this.tplMain.ResumeLayout(false);
            this.tplMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BorderedTableLayoutPanel tplMain;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbURLs;
    }
}