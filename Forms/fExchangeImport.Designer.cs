namespace Material_System
{
    partial class fExchangeImport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.chkFG = new Sunny.UI.UICheckBox();
            this.chkSemi = new Sunny.UI.UICheckBox();
            this.txtPath = new Sunny.UI.UITextBox();
            this.btnPath = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel1.Size = new System.Drawing.Size(720, 35);
            this.panel1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(670, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(517, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 26);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(613, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 26);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(28, 90);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(72, 23);
            this.uiLabel1.TabIndex = 10;
            this.uiLabel1.Text = "File Path";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkFG
            // 
            this.chkFG.Checked = true;
            this.chkFG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkFG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkFG.Location = new System.Drawing.Point(32, 148);
            this.chkFG.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkFG.Name = "chkFG";
            this.chkFG.Size = new System.Drawing.Size(69, 29);
            this.chkFG.TabIndex = 11;
            this.chkFG.Text = "FG";
            // 
            // chkSemi
            // 
            this.chkSemi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chkSemi.Location = new System.Drawing.Point(107, 148);
            this.chkSemi.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkSemi.Name = "chkSemi";
            this.chkSemi.Size = new System.Drawing.Size(74, 29);
            this.chkSemi.TabIndex = 12;
            this.chkSemi.Text = "Semi";
            // 
            // txtPath
            // 
            this.txtPath.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPath.Location = new System.Drawing.Point(107, 84);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPath.Name = "txtPath";
            this.txtPath.Padding = new System.Windows.Forms.Padding(5);
            this.txtPath.ShowText = false;
            this.txtPath.Size = new System.Drawing.Size(319, 29);
            this.txtPath.TabIndex = 13;
            this.txtPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPath.Watermark = "";
            // 
            // btnPath
            // 
            this.btnPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPath.Image = global::Material_System.Properties.Resources.folder_saved_search_16;
            this.btnPath.Location = new System.Drawing.Point(446, 89);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(18, 23);
            this.btnPath.TabIndex = 36;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // fExchangeImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(720, 373);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.chkSemi);
            this.Controls.Add(this.chkFG);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fExchangeImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UICheckBox chkFG;
        private Sunny.UI.UICheckBox chkSemi;
        private Sunny.UI.UITextBox txtPath;
        private System.Windows.Forms.Label btnPath;
    }
}