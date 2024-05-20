using System.Windows.Forms;

namespace Material_System
{
    partial class FormTokusaiECOHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTokusaiECOHistory));
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btnFilterUpdateTime = new Sunny.UI.UISymbolButton();
            this.uiLine3 = new Sunny.UI.UILine();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.uiLine2 = new Sunny.UI.UILine();
            this.dgrvViewLineComfirm = new System.Windows.Forms.DataGridView();
            this.cbTokusai = new Sunny.UI.UICheckBox();
            this.cbECO = new Sunny.UI.UICheckBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.cbbLocation = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaultReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WARM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvViewLineComfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.uiLabel2);
            this.panel2.Controls.Add(this.btnFilterUpdateTime);
            this.panel2.Controls.Add(this.uiLine3);
            this.panel2.Controls.Add(this.dpTo);
            this.panel2.Controls.Add(this.dpFrom);
            this.panel2.Controls.Add(this.uiLine2);
            this.panel2.Controls.Add(this.dgrvViewLineComfirm);
            this.panel2.Controls.Add(this.cbTokusai);
            this.panel2.Controls.Add(this.cbECO);
            this.panel2.Controls.Add(this.uiLine1);
            this.panel2.Controls.Add(this.cbbLocation);
            this.panel2.Controls.Add(this.uiLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 502);
            this.panel2.TabIndex = 2;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel2.Location = new System.Drawing.Point(448, 15);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(88, 23);
            this.uiLabel2.TabIndex = 20;
            this.uiLabel2.Text = "UpdateTime";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFilterUpdateTime
            // 
            this.btnFilterUpdateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterUpdateTime.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnFilterUpdateTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterUpdateTime.Location = new System.Drawing.Point(808, 14);
            this.btnFilterUpdateTime.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFilterUpdateTime.Name = "btnFilterUpdateTime";
            this.btnFilterUpdateTime.Size = new System.Drawing.Size(53, 27);
            this.btnFilterUpdateTime.Style = Sunny.UI.UIStyle.Custom;
            this.btnFilterUpdateTime.Symbol = 61616;
            this.btnFilterUpdateTime.TabIndex = 19;
            this.btnFilterUpdateTime.Text = "Lọc";
            this.btnFilterUpdateTime.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnFilterUpdateTime.Click += new System.EventHandler(this.btnFilterUpdateTime_Click);
            // 
            // uiLine3
            // 
            this.uiLine3.FillColor = System.Drawing.Color.Transparent;
            this.uiLine3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiLine3.LineColor = System.Drawing.Color.Black;
            this.uiLine3.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine3.Location = new System.Drawing.Point(665, 24);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(10, 5);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 18;
            // 
            // dpTo
            // 
            this.dpTo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTo.Location = new System.Drawing.Point(682, 14);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(120, 27);
            this.dpTo.TabIndex = 17;
            // 
            // dpFrom
            // 
            this.dpFrom.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(542, 14);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(113, 27);
            this.dpFrom.TabIndex = 16;
            // 
            // uiLine2
            // 
            this.uiLine2.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiLine2.LineColor = System.Drawing.Color.Silver;
            this.uiLine2.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine2.Location = new System.Drawing.Point(436, 7);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(5, 48);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 15;
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
            this.dgrvViewLineComfirm.Location = new System.Drawing.Point(3, 61);
            this.dgrvViewLineComfirm.Name = "dgrvViewLineComfirm";
            this.dgrvViewLineComfirm.ReadOnly = true;
            this.dgrvViewLineComfirm.RowHeadersVisible = false;
            this.dgrvViewLineComfirm.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrvViewLineComfirm.RowTemplate.Height = 40;
            this.dgrvViewLineComfirm.RowTemplate.ReadOnly = true;
            this.dgrvViewLineComfirm.Size = new System.Drawing.Size(1148, 435);
            this.dgrvViewLineComfirm.TabIndex = 14;
            // 
            // cbTokusai
            // 
            this.cbTokusai.BackColor = System.Drawing.Color.White;
            this.cbTokusai.CheckBoxColor = System.Drawing.Color.SteelBlue;
            this.cbTokusai.Checked = true;
            this.cbTokusai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTokusai.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTokusai.Location = new System.Drawing.Point(245, 12);
            this.cbTokusai.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbTokusai.Name = "cbTokusai";
            this.cbTokusai.Size = new System.Drawing.Size(104, 29);
            this.cbTokusai.Style = Sunny.UI.UIStyle.Custom;
            this.cbTokusai.TabIndex = 13;
            this.cbTokusai.Text = "Tokusai";
            // 
            // cbECO
            // 
            this.cbECO.BackColor = System.Drawing.Color.White;
            this.cbECO.CheckBoxColor = System.Drawing.Color.SteelBlue;
            this.cbECO.Checked = true;
            this.cbECO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbECO.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbECO.Location = new System.Drawing.Point(355, 11);
            this.cbECO.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbECO.Name = "cbECO";
            this.cbECO.Size = new System.Drawing.Size(69, 29);
            this.cbECO.Style = Sunny.UI.UIStyle.Custom;
            this.cbECO.TabIndex = 12;
            this.cbECO.Text = "ECO";
            // 
            // uiLine1
            // 
            this.uiLine1.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.uiLine1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiLine1.LineColor = System.Drawing.Color.Silver;
            this.uiLine1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine1.Location = new System.Drawing.Point(222, 7);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(5, 48);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 11;
            // 
            // cbbLocation
            // 
            this.cbbLocation.DataSource = null;
            this.cbbLocation.FillColor = System.Drawing.Color.White;
            this.cbbLocation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLocation.Location = new System.Drawing.Point(85, 11);
            this.cbbLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbLocation.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbLocation.Name = "cbbLocation";
            this.cbbLocation.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbbLocation.RectColor = System.Drawing.Color.DimGray;
            this.cbbLocation.Size = new System.Drawing.Size(126, 30);
            this.cbbLocation.Style = Sunny.UI.UIStyle.Custom;
            this.cbbLocation.TabIndex = 10;
            this.cbbLocation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbbLocation.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.White;
            this.uiLabel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.Location = new System.Drawing.Point(13, 16);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(68, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 9;
            this.uiLabel1.Text = "Khu vực";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.DM.Width = 60;
            // 
            // PD
            // 
            this.PD.DataPropertyName = "PD";
            this.PD.HeaderText = "PD";
            this.PD.Name = "PD";
            this.PD.ReadOnly = true;
            this.PD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PD.Width = 80;
            // 
            // TE
            // 
            this.TE.DataPropertyName = "TE";
            this.TE.HeaderText = "TE";
            this.TE.Name = "TE";
            this.TE.ReadOnly = true;
            this.TE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // FormTokusaiECOHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 502);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTokusaiECOHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ECO/ECN/TOKUSAI History";
            this.Load += new System.EventHandler(this.FormTokusaiECOHistory_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvViewLineComfirm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UICheckBox cbTokusai;
        private Sunny.UI.UICheckBox cbECO;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIComboBox cbbLocation;
        private Sunny.UI.UILabel uiLabel1;
        private DataGridView dgrvViewLineComfirm;
        private Sunny.UI.UILine uiLine2;
        private DateTimePicker dpFrom;
        private Sunny.UI.UILine uiLine3;
        private DateTimePicker dpTo;
        private Sunny.UI.UISymbolButton btnFilterUpdateTime;
        private Sunny.UI.UILabel uiLabel2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NO;
        private DataGridViewTextBoxColumn Line;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn WO;
        private DataGridViewTextBoxColumn Part;
        private DataGridViewTextBoxColumn FaultReason;
        private DataGridViewTextBoxColumn UpdateTime;
        private DataGridViewTextBoxColumn DM;
        private DataGridViewTextBoxColumn PD;
        private DataGridViewTextBoxColumn TE;
        private DataGridViewTextBoxColumn QA;
        private DataGridViewTextBoxColumn WARM;
    }
}