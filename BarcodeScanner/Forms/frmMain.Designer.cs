namespace BarcodeScanner.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsLoggers = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.borderedPanel2 = new BarcodeScanner.Controls.BorderedPanel();
            this.tbLogs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcMain = new BarcodeScanner.Controls.BorderedTabControl();
            this.tbScanner = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.borderedPanel1 = new BarcodeScanner.Controls.BorderedPanel();
            this.barcodeRenderer = new BarcodeScanner.Controls.BarcodeRenderer();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbDriverFormats = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBarcodeDriver = new BarcodeScanner.Controls.BorderedComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbEndpointURLs = new BarcodeScanner.Controls.BorderedButtonBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.horizontalDivider1 = new BarcodeScanner.Controls.HorizontalDivider();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCameraFrameSizes = new BarcodeScanner.Controls.BorderedComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCamera = new BarcodeScanner.Controls.BorderedComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tsLoggers.SuspendLayout();
            this.panel2.SuspendLayout();
            this.borderedPanel2.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tbScanner.SuspendLayout();
            this.borderedPanel1.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsLoggers
            // 
            this.tsLoggers.AutoSize = false;
            this.tsLoggers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsLoggers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsLoggers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.btnStop,
            this.toolStripSeparator2,
            this.btnSettings});
            this.tsLoggers.Location = new System.Drawing.Point(0, 0);
            this.tsLoggers.Name = "tsLoggers";
            this.tsLoggers.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tsLoggers.Size = new System.Drawing.Size(734, 43);
            this.tsLoggers.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = false;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 40);
            this.btnStart.Text = "Start scanning";
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStart.ToolTipText = "Start scanning";
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(82, 40);
            this.btnStop.Text = "Stop scanning";
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStop.ToolTipText = "Stop scanning";
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
            // 
            // btnSettings
            // 
            this.btnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSettings.AutoSize = false;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(82, 40);
            this.btnSettings.Text = "Go settings :)";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettingsClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.panel2.Controls.Add(this.borderedPanel2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 181);
            this.panel2.TabIndex = 6;
            // 
            // borderedPanel2
            // 
            this.borderedPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderedPanel2.Controls.Add(this.tbLogs);
            this.borderedPanel2.Location = new System.Drawing.Point(21, 42);
            this.borderedPanel2.Name = "borderedPanel2";
            this.borderedPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.borderedPanel2.Size = new System.Drawing.Size(670, 121);
            this.borderedPanel2.TabIndex = 6;
            // 
            // tbLogs
            // 
            this.tbLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogs.Location = new System.Drawing.Point(1, 1);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ReadOnly = true;
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.Size = new System.Drawing.Size(668, 119);
            this.tbLogs.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(673, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "EVENTS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tbScanner);
            this.tcMain.Controls.Add(this.tpSettings);
            this.tcMain.ItemSize = new System.Drawing.Size(110, 35);
            this.tcMain.Location = new System.Drawing.Point(12, 53);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(710, 465);
            this.tcMain.TabColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.tcMain.TabColorInactive = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tcMain.TabIndex = 0;
            this.tcMain.TabRigthSeparator = 1;
            // 
            // tbScanner
            // 
            this.tbScanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.tbScanner.Controls.Add(this.label1);
            this.tbScanner.Controls.Add(this.borderedPanel1);
            this.tbScanner.Location = new System.Drawing.Point(4, 39);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.Padding = new System.Windows.Forms.Padding(3);
            this.tbScanner.Size = new System.Drawing.Size(702, 422);
            this.tbScanner.TabIndex = 0;
            this.tbScanner.Text = "Barcode scanner";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(667, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "CAMERA OUTPUT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // borderedPanel1
            // 
            this.borderedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderedPanel1.Controls.Add(this.barcodeRenderer);
            this.borderedPanel1.Location = new System.Drawing.Point(17, 52);
            this.borderedPanel1.Name = "borderedPanel1";
            this.borderedPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.borderedPanel1.Size = new System.Drawing.Size(670, 368);
            this.borderedPanel1.TabIndex = 1;
            // 
            // barcodeRenderer
            // 
            this.barcodeRenderer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.barcodeRenderer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.barcodeRenderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcodeRenderer.Location = new System.Drawing.Point(1, 1);
            this.barcodeRenderer.Name = "barcodeRenderer";
            this.barcodeRenderer.Size = new System.Drawing.Size(668, 366);
            this.barcodeRenderer.TabIndex = 0;
            this.barcodeRenderer.TabStop = false;
            this.barcodeRenderer.Text = "";
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.tpSettings.Controls.Add(this.panel4);
            this.tpSettings.Controls.Add(this.label7);
            this.tpSettings.Controls.Add(this.panel3);
            this.tpSettings.Controls.Add(this.label6);
            this.tpSettings.Controls.Add(this.horizontalDivider1);
            this.tpSettings.Controls.Add(this.panel1);
            this.tpSettings.Controls.Add(this.label3);
            this.tpSettings.Location = new System.Drawing.Point(4, 39);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(702, 422);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.tbDriverFormats);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.cbBarcodeDriver);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(17, 197);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(697, 85);
            this.panel4.TabIndex = 12;
            // 
            // tbDriverFormats
            // 
            this.tbDriverFormats.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbDriverFormats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDriverFormats.Location = new System.Drawing.Point(125, 52);
            this.tbDriverFormats.Name = "tbDriverFormats";
            this.tbDriverFormats.ReadOnly = true;
            this.tbDriverFormats.Size = new System.Drawing.Size(100, 18);
            this.tbDriverFormats.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Support formats";
            // 
            // cbBarcodeDriver
            // 
            this.cbBarcodeDriver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBarcodeDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBarcodeDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBarcodeDriver.FormattingEnabled = true;
            this.cbBarcodeDriver.Location = new System.Drawing.Point(125, 14);
            this.cbBarcodeDriver.Name = "cbBarcodeDriver";
            this.cbBarcodeDriver.Size = new System.Drawing.Size(545, 25);
            this.cbBarcodeDriver.TabIndex = 1;
            this.cbBarcodeDriver.SelectedIndexChanged += new System.EventHandler(this.CbBarcodeDriverSelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Driver";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(17, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(697, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "BARCODE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.cbEndpointURLs);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(17, 333);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(697, 54);
            this.panel3.TabIndex = 10;
            // 
            // cbEndpointURLs
            // 
            this.cbEndpointURLs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEndpointURLs.ButtonFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbEndpointURLs.ButtonImage = null;
            this.cbEndpointURLs.ButtonText = "...";
            this.cbEndpointURLs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndpointURLs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEndpointURLs.FormattingEnabled = true;
            this.cbEndpointURLs.Items.AddRange(new object[] {
            "http://localhost/BarcodeScanner.WebAPI"});
            this.cbEndpointURLs.Location = new System.Drawing.Point(125, 14);
            this.cbEndpointURLs.Name = "cbEndpointURLs";
            this.cbEndpointURLs.Size = new System.Drawing.Size(545, 25);
            this.cbEndpointURLs.TabIndex = 1;
            this.cbEndpointURLs.ButtonClick += new System.EventHandler(this.CbEndpointURLsButtonClick);
            this.cbEndpointURLs.SelectedIndexChanged += new System.EventHandler(this.cbEndpointURLs_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Endpoint URL";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(17, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(697, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "WEB SERVICE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // horizontalDivider1
            // 
            this.horizontalDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider1.Location = new System.Drawing.Point(18, 422);
            this.horizontalDivider1.Name = "horizontalDivider1";
            this.horizontalDivider1.Size = new System.Drawing.Size(694, 1);
            this.horizontalDivider1.TabIndex = 8;
            this.horizontalDivider1.Text = "horizontalDivider1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cbCameraFrameSizes);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbCamera);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(17, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 92);
            this.panel1.TabIndex = 4;
            // 
            // cbCameraFrameSizes
            // 
            this.cbCameraFrameSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameraFrameSizes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCameraFrameSizes.FormattingEnabled = true;
            this.cbCameraFrameSizes.Location = new System.Drawing.Point(125, 52);
            this.cbCameraFrameSizes.Name = "cbCameraFrameSizes";
            this.cbCameraFrameSizes.Size = new System.Drawing.Size(178, 25);
            this.cbCameraFrameSizes.TabIndex = 3;
            this.cbCameraFrameSizes.SelectedIndexChanged += new System.EventHandler(this.CbCameraFrameSizesSelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Frame resolution";
            // 
            // cbCamera
            // 
            this.cbCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCamera.FormattingEnabled = true;
            this.cbCamera.Location = new System.Drawing.Point(125, 14);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(545, 25);
            this.cbCamera.TabIndex = 1;
            this.cbCamera.SelectedIndexChanged += new System.EventHandler(this.CbCameraSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Camera";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(697, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "CAMERA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 711);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tsLoggers);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 750);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Scanner";
            this.Activated += new System.EventHandler(this.FrmMainActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainFormClosing);
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.tsLoggers.ResumeLayout(false);
            this.tsLoggers.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.borderedPanel2.ResumeLayout(false);
            this.borderedPanel2.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tbScanner.ResumeLayout(false);
            this.borderedPanel1.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BorderedTabControl tcMain;
        private System.Windows.Forms.TabPage tbScanner;
        private System.Windows.Forms.TabPage tpSettings;
        private Controls.BorderedPanel borderedPanel1;
        private Controls.BarcodeRenderer barcodeRenderer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tsLoggers;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Controls.BorderedComboBox cbCamera;
        private Controls.BorderedComboBox cbCameraFrameSizes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private Controls.BorderedPanel borderedPanel2;
        private System.Windows.Forms.TextBox tbLogs;
        private System.Windows.Forms.Label label2;
        private Controls.HorizontalDivider horizontalDivider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private Controls.BorderedButtonBox cbEndpointURLs;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private Controls.BorderedComboBox cbBarcodeDriver;
        private System.Windows.Forms.TextBox tbDriverFormats;
        private System.Windows.Forms.Label label10;
    }
}

