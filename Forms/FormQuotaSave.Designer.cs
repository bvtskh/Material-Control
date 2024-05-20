namespace Material_System
{
    partial class fQuotaSave
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
            this.txtPitch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveChanged = new System.Windows.Forms.Button();
            this.txtRmax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRmin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPitch
            // 
            this.txtPitch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPitch.Location = new System.Drawing.Point(117, 59);
            this.txtPitch.Name = "txtPitch";
            this.txtPitch.Size = new System.Drawing.Size(154, 20);
            this.txtPitch.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pitch";
            // 
            // btnSaveChanged
            // 
            this.btnSaveChanged.BackColor = System.Drawing.Color.Green;
            this.btnSaveChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanged.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanged.Image = global::Material_System.Properties.Resources.Save;
            this.btnSaveChanged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanged.Location = new System.Drawing.Point(192, 164);
            this.btnSaveChanged.Name = "btnSaveChanged";
            this.btnSaveChanged.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveChanged.Size = new System.Drawing.Size(79, 30);
            this.btnSaveChanged.TabIndex = 5;
            this.btnSaveChanged.Text = "&Saves";
            this.btnSaveChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanged.UseVisualStyleBackColor = false;
            this.btnSaveChanged.Click += new System.EventHandler(this.btnSaveChanged_Click);
            // 
            // txtRmax
            // 
            this.txtRmax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRmax.Location = new System.Drawing.Point(117, 89);
            this.txtRmax.Name = "txtRmax";
            this.txtRmax.Size = new System.Drawing.Size(154, 20);
            this.txtRmax.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "R Max";
            // 
            // txtPartNo
            // 
            this.txtPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartNo.Location = new System.Drawing.Point(117, 28);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(154, 20);
            this.txtPartNo.TabIndex = 0;
            this.txtPartNo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEmNo_PreviewKeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Part No";
            // 
            // txtRmin
            // 
            this.txtRmin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRmin.Location = new System.Drawing.Point(117, 120);
            this.txtRmin.Name = "txtRmin";
            this.txtRmin.Size = new System.Drawing.Size(154, 20);
            this.txtRmin.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "R Min";
            // 
            // btnPart
            // 
            this.btnPart.Location = new System.Drawing.Point(275, 25);
            this.btnPart.Name = "btnPart";
            this.btnPart.Size = new System.Drawing.Size(38, 23);
            this.btnPart.TabIndex = 10;
            this.btnPart.Text = "...";
            this.btnPart.UseVisualStyleBackColor = true;
            this.btnPart.Click += new System.EventHandler(this.btnPart_Click);
            // 
            // fQuotaSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 221);
            this.Controls.Add(this.btnPart);
            this.Controls.Add(this.txtRmin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPartNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPitch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveChanged);
            this.Controls.Add(this.txtRmax);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fQuotaSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quote Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPitch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveChanged;
        private System.Windows.Forms.TextBox txtRmax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPartNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPart;
    }
}