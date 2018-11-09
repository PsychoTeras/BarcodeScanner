namespace BarcodeScanner.Forms
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tplMain = new BarcodeScanner.Controls.BorderedTableLayoutPanel();
            this.tpInner = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tplMain.SuspendLayout();
            this.tpInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tplMain
            // 
            this.tplMain.ColumnCount = 2;
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplMain.Controls.Add(this.tpInner, 0, 0);
            this.tplMain.Controls.Add(this.btnOk, 0, 1);
            this.tplMain.Controls.Add(this.btnCancel, 1, 1);
            this.tplMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplMain.Location = new System.Drawing.Point(12, 14);
            this.tplMain.Name = "tplMain";
            this.tplMain.RowCount = 2;
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tplMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tplMain.Size = new System.Drawing.Size(351, 176);
            this.tplMain.TabIndex = 1;
            // 
            // tpInner
            // 
            this.tpInner.ColumnCount = 2;
            this.tplMain.SetColumnSpan(this.tpInner, 2);
            this.tpInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tpInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpInner.Controls.Add(this.label1, 0, 1);
            this.tpInner.Controls.Add(this.tbUserName, 1, 1);
            this.tpInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.tpInner.Location = new System.Drawing.Point(3, 3);
            this.tpInner.Name = "tpInner";
            this.tpInner.RowCount = 2;
            this.tpInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tpInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tpInner.Size = new System.Drawing.Size(345, 83);
            this.tpInner.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "User name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbUserName
            // 
            this.tbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserName.Location = new System.Drawing.Point(88, 54);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(254, 25);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.Text = "anonymous";
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(165, 138);
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
            this.btnCancel.Location = new System.Drawing.Point(257, 138);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 8, 7, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 204);
            this.Controls.Add(this.tplMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.Padding = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login into Barcode Scanner";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.tplMain.ResumeLayout(false);
            this.tpInner.ResumeLayout(false);
            this.tpInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BorderedTableLayoutPanel tplMain;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tpInner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserName;
    }
}