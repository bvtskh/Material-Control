namespace Material_System
{
    partial class FormTokusaiAlarm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTokusaiAlarm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            this.uiLine3 = new Sunny.UI.UILine();
            this.btnPlan = new Sunny.UI.UIImageButton();
            this.uiLine2 = new Sunny.UI.UILine();
            this.btnHistory = new Sunny.UI.UIImageButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.cbDemo = new Sunny.UI.UICheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBackToHome = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSignal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSetting = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbbLocation = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.dgrvViewLineComfirm = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaultReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DM = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PD = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.QA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WARM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new Sunny.UI.UIContextMenuStrip();
            this.copyCellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHistory)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvViewLineComfirm)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.uiImageButton1);
            this.panel2.Controls.Add(this.uiLine3);
            this.panel2.Controls.Add(this.btnPlan);
            this.panel2.Controls.Add(this.uiLine2);
            this.panel2.Controls.Add(this.btnHistory);
            this.panel2.Controls.Add(this.uiLine1);
            this.panel2.Controls.Add(this.cbDemo);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.cbbLocation);
            this.panel2.Controls.Add(this.uiLabel1);
            this.panel2.Controls.Add(this.dgrvViewLineComfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 559);
            this.panel2.TabIndex = 1;
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiImageButton1.Image = global::Material_System.Properties.Resources.icons8_circuit_35;
            this.uiImageButton1.ImageDisabled = global::Material_System.Properties.Resources.icons8_circuit_35_hover;
            this.uiImageButton1.ImageHover = global::Material_System.Properties.Resources.icons8_circuit_35_hover;
            this.uiImageButton1.ImageLocation = "";
            this.uiImageButton1.ImageOffset = new System.Drawing.Point(20, 0);
            this.uiImageButton1.ImagePress = global::Material_System.Properties.Resources.icons8_circuit_35_hover;
            this.uiImageButton1.ImageSelected = global::Material_System.Properties.Resources.icons8_circuit_35_hover;
            this.uiImageButton1.Location = new System.Drawing.Point(499, 7);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(77, 59);
            this.uiImageButton1.TabIndex = 21;
            this.uiImageButton1.TabStop = false;
            this.uiImageButton1.Text = "MainSub";
            this.uiImageButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiImageButton1.Click += new System.EventHandler(this.uiImageButton1_Click);
            // 
            // uiLine3
            // 
            this.uiLine3.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine3.FillColor = System.Drawing.Color.White;
            this.uiLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLine3.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine3.Location = new System.Drawing.Point(468, 6);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(10, 60);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 20;
            // 
            // btnPlan
            // 
            this.btnPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlan.Image = global::Material_System.Properties.Resources.icons8_blueprint_35;
            this.btnPlan.ImageDisabled = global::Material_System.Properties.Resources.icons8_blueprint_35_hover;
            this.btnPlan.ImageHover = global::Material_System.Properties.Resources.icons8_blueprint_35_hover;
            this.btnPlan.ImageLocation = "";
            this.btnPlan.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnPlan.ImagePress = global::Material_System.Properties.Resources.icons8_blueprint_35_hover;
            this.btnPlan.ImageSelected = global::Material_System.Properties.Resources.icons8_blueprint_35_hover;
            this.btnPlan.Location = new System.Drawing.Point(368, 7);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(81, 59);
            this.btnPlan.TabIndex = 19;
            this.btnPlan.TabStop = false;
            this.btnPlan.Text = "Kế hoạch";
            this.btnPlan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // uiLine2
            // 
            this.uiLine2.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine2.FillColor = System.Drawing.Color.White;
            this.uiLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLine2.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine2.Location = new System.Drawing.Point(337, 6);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(10, 60);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 18;
            // 
            // btnHistory
            // 
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.Image = global::Material_System.Properties.Resources.icons8_genealogy_40;
            this.btnHistory.ImageDisabled = global::Material_System.Properties.Resources.icons8_genealogy_40_hover;
            this.btnHistory.ImageHover = global::Material_System.Properties.Resources.icons8_genealogy_40_hover;
            this.btnHistory.ImageLocation = "";
            this.btnHistory.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnHistory.ImagePress = global::Material_System.Properties.Resources.icons8_genealogy_40_hover;
            this.btnHistory.ImageSelected = global::Material_System.Properties.Resources.icons8_genealogy_40_hover;
            this.btnHistory.Location = new System.Drawing.Point(234, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(81, 59);
            this.btnHistory.TabIndex = 17;
            this.btnHistory.TabStop = false;
            this.btnHistory.Text = "Lịch sử";
            this.btnHistory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // uiLine1
            // 
            this.uiLine1.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLine1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine1.Location = new System.Drawing.Point(203, 6);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(10, 60);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 16;
            // 
            // cbDemo
            // 
            this.cbDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDemo.BackColor = System.Drawing.Color.White;
            this.cbDemo.CheckBoxColor = System.Drawing.Color.SteelBlue;
            this.cbDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbDemo.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDemo.Location = new System.Drawing.Point(1038, 14);
            this.cbDemo.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbDemo.Name = "cbDemo";
            this.cbDemo.Size = new System.Drawing.Size(104, 29);
            this.cbDemo.Style = Sunny.UI.UIStyle.Custom;
            this.cbDemo.TabIndex = 14;
            this.cbDemo.Text = "Dữ liệu Test";
            this.cbDemo.CheckedChanged += new System.EventHandler(this.cbDemo_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.lblVersion,
            this.lblBackToHome,
            this.toolStripSignal,
            this.toolStripSetting});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1154, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabel4.Image = global::Material_System.Properties.Resources.copyright_16px;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(227, 17);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "PI-IT";
            this.toolStripStatusLabel4.ToolTipText = "Copyright by PE-IT";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblVersion.Image = global::Material_System.Properties.Resources.versions_16px;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(227, 17);
            this.lblVersion.Spring = true;
            this.lblVersion.Text = "0";
            this.lblVersion.ToolTipText = "Version";
            // 
            // lblBackToHome
            // 
            this.lblBackToHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBackToHome.ForeColor = System.Drawing.Color.Green;
            this.lblBackToHome.Image = global::Material_System.Properties.Resources.icons8_home_30;
            this.lblBackToHome.Name = "lblBackToHome";
            this.lblBackToHome.Size = new System.Drawing.Size(227, 17);
            this.lblBackToHome.Spring = true;
            this.lblBackToHome.Text = "Home";
            this.lblBackToHome.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripSignal
            // 
            this.toolStripSignal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripSignal.Image = global::Material_System.Properties.Resources.icons8_signal_16;
            this.toolStripSignal.Name = "toolStripSignal";
            this.toolStripSignal.Size = new System.Drawing.Size(227, 17);
            this.toolStripSignal.Spring = true;
            // 
            // toolStripSetting
            // 
            this.toolStripSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripSetting.Image = global::Material_System.Properties.Resources.tools_16;
            this.toolStripSetting.Name = "toolStripSetting";
            this.toolStripSetting.Size = new System.Drawing.Size(227, 17);
            this.toolStripSetting.Spring = true;
            this.toolStripSetting.Text = "Alt+X";
            // 
            // cbbLocation
            // 
            this.cbbLocation.DataSource = null;
            this.cbbLocation.FillColor = System.Drawing.Color.White;
            this.cbbLocation.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLocation.Location = new System.Drawing.Point(68, 16);
            this.cbbLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbLocation.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbLocation.Name = "cbbLocation";
            this.cbbLocation.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbbLocation.Size = new System.Drawing.Size(126, 23);
            this.cbbLocation.Style = Sunny.UI.UIStyle.Custom;
            this.cbbLocation.TabIndex = 10;
            this.cbbLocation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbbLocation.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.White;
            this.uiLabel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 16);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(68, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 9;
            this.uiLabel1.Text = "Khu vực";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrvViewLineComfirm
            // 
            this.dgrvViewLineComfirm.AllowUserToAddRows = false;
            this.dgrvViewLineComfirm.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgrvViewLineComfirm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrvViewLineComfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrvViewLineComfirm.BackgroundColor = System.Drawing.Color.White;
            this.dgrvViewLineComfirm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvViewLineComfirm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrvViewLineComfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvViewLineComfirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NO,
            this.Line,
            this.Product,
            this.WO,
            this.Part,
            this.FaultReason,
            this.UpdateTime,
            this.DM,
            this.PD,
            this.TE,
            this.QA,
            this.WARM});
            this.dgrvViewLineComfirm.EnableHeadersVisualStyles = false;
            this.dgrvViewLineComfirm.Location = new System.Drawing.Point(3, 72);
            this.dgrvViewLineComfirm.Name = "dgrvViewLineComfirm";
            this.dgrvViewLineComfirm.ReadOnly = true;
            this.dgrvViewLineComfirm.RowHeadersVisible = false;
            this.dgrvViewLineComfirm.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrvViewLineComfirm.RowTemplate.Height = 40;
            this.dgrvViewLineComfirm.RowTemplate.ReadOnly = true;
            this.dgrvViewLineComfirm.Size = new System.Drawing.Size(1148, 462);
            this.dgrvViewLineComfirm.TabIndex = 1;
            this.dgrvViewLineComfirm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvViewLineComfirm_CellContentClick);
            this.dgrvViewLineComfirm.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgrvViewLineComfirm_CellFormatting);
            this.dgrvViewLineComfirm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgrvViewLineComfirm_MouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 29;
            // 
            // NO
            // 
            this.NO.DataPropertyName = "NO";
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.Width = 40;
            // 
            // Line
            // 
            this.Line.DataPropertyName = "LINE_ID";
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            this.Line.Width = 40;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "PRODUCT_ID";
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 150;
            // 
            // WO
            // 
            this.WO.DataPropertyName = "WO";
            this.WO.HeaderText = "WO";
            this.WO.Name = "WO";
            this.WO.ReadOnly = true;
            // 
            // Part
            // 
            this.Part.DataPropertyName = "PART_ID";
            this.Part.HeaderText = "Part";
            this.Part.Name = "Part";
            this.Part.ReadOnly = true;
            this.Part.Width = 120;
            // 
            // FaultReason
            // 
            this.FaultReason.DataPropertyName = "REASON";
            this.FaultReason.HeaderText = "FaultReason";
            this.FaultReason.Name = "FaultReason";
            this.FaultReason.ReadOnly = true;
            this.FaultReason.Width = 200;
            // 
            // UpdateTime
            // 
            this.UpdateTime.DataPropertyName = "TIME_STOP";
            this.UpdateTime.HeaderText = "UpdateTime";
            this.UpdateTime.Name = "UpdateTime";
            this.UpdateTime.ReadOnly = true;
            this.UpdateTime.Width = 160;
            // 
            // DM
            // 
            this.DM.DataPropertyName = "DM";
            this.DM.HeaderText = "DM";
            this.DM.Name = "DM";
            this.DM.ReadOnly = true;
            this.DM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DM.Width = 60;
            // 
            // PD
            // 
            this.PD.DataPropertyName = "PD";
            this.PD.HeaderText = "PD";
            this.PD.Name = "PD";
            this.PD.ReadOnly = true;
            this.PD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PD.Width = 80;
            // 
            // TE
            // 
            this.TE.DataPropertyName = "TE";
            this.TE.HeaderText = "TE";
            this.TE.Name = "TE";
            this.TE.ReadOnly = true;
            this.TE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TE.Width = 80;
            // 
            // QA
            // 
            this.QA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QA.DataPropertyName = "QA";
            this.QA.HeaderText = "QA";
            this.QA.Name = "QA";
            this.QA.ReadOnly = true;
            this.QA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // WARM
            // 
            this.WARM.DataPropertyName = "WARM";
            this.WARM.HeaderText = "WARM";
            this.WARM.Name = "WARM";
            this.WARM.ReadOnly = true;
            this.WARM.Visible = false;
            this.WARM.Width = 78;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCellToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(140, 76);
            // 
            // copyCellToolStripMenuItem
            // 
            this.copyCellToolStripMenuItem.Image = global::Material_System.Properties.Resources.icons8_copy_16;
            this.copyCellToolStripMenuItem.Name = "copyCellToolStripMenuItem";
            this.copyCellToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.copyCellToolStripMenuItem.Text = "Copy Cell";
            this.copyCellToolStripMenuItem.Click += new System.EventHandler(this.copyCellToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Image = global::Material_System.Properties.Resources.icons8_sell_stock_16;
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Image = global::Material_System.Properties.Resources.icons8_genealogy_16;
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // FormTokusaiAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 559);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormTokusaiAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ECO/ECN/TOKUSAI Control System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTokusaiAlarm_FormClosed);
            this.Load += new System.EventHandler(this.FormTokusaiAlarm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormTokusaiAlarm_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHistory)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvViewLineComfirm)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrvViewLineComfirm;
        private Sunny.UI.UIComboBox cbbLocation;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel lblBackToHome;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSetting;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSignal;
        private Sunny.UI.UIContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyCellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private Sunny.UI.UICheckBox cbDemo;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIImageButton btnHistory;
        private Sunny.UI.UIImageButton btnPlan;
        private Sunny.UI.UILine uiLine2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn WO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Part;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaultReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTime;
        private System.Windows.Forms.DataGridViewButtonColumn DM;
        private System.Windows.Forms.DataGridViewButtonColumn PD;
        private System.Windows.Forms.DataGridViewButtonColumn TE;
        private System.Windows.Forms.DataGridViewButtonColumn QA;
        private System.Windows.Forms.DataGridViewTextBoxColumn WARM;
        private Sunny.UI.UIImageButton uiImageButton1;
        private Sunny.UI.UILine uiLine3;
    }
}