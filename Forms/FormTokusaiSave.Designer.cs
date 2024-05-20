namespace Material_System
{
    partial class FormTokusaiSave
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
            this.txtPartFm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveChanged = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rModels = new System.Windows.Forms.RichTextBox();
            this.txtEmNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOsQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPartFm
            // 
            this.txtPartFm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartFm.Location = new System.Drawing.Point(117, 59);
            this.txtPartFm.Name = "txtPartFm";
            this.txtPartFm.Size = new System.Drawing.Size(327, 20);
            this.txtPartFm.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Parts From:";
            // 
            // btnSaveChanged
            // 
            this.btnSaveChanged.BackColor = System.Drawing.Color.Green;
            this.btnSaveChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanged.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanged.Image = global::Material_System.Properties.Resources.Save;
            this.btnSaveChanged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanged.Location = new System.Drawing.Point(365, 368);
            this.btnSaveChanged.Name = "btnSaveChanged";
            this.btnSaveChanged.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveChanged.Size = new System.Drawing.Size(79, 30);
            this.btnSaveChanged.TabIndex = 5;
            this.btnSaveChanged.Text = "&Saves";
            this.btnSaveChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanged.UseVisualStyleBackColor = false;
            this.btnSaveChanged.Click += new System.EventHandler(this.btnSaveChanged_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Models:";
            // 
            // txtPartTo
            // 
            this.txtPartTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartTo.Location = new System.Drawing.Point(117, 89);
            this.txtPartTo.Name = "txtPartTo";
            this.txtPartTo.Size = new System.Drawing.Size(327, 20);
            this.txtPartTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Parts To:";
            // 
            // rModels
            // 
            this.rModels.Location = new System.Drawing.Point(117, 164);
            this.rModels.Name = "rModels";
            this.rModels.Size = new System.Drawing.Size(327, 194);
            this.rModels.TabIndex = 4;
            this.rModels.Text = "";
            // 
            // txtEmNo
            // 
            this.txtEmNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmNo.Location = new System.Drawing.Point(117, 28);
            this.txtEmNo.Name = "txtEmNo";
            this.txtEmNo.Size = new System.Drawing.Size(327, 20);
            this.txtEmNo.TabIndex = 0;
            this.txtEmNo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtEmNo_PreviewKeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "E/M No:";
            // 
            // txtOsQty
            // 
            this.txtOsQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOsQty.Location = new System.Drawing.Point(117, 120);
            this.txtOsQty.Name = "txtOsQty";
            this.txtOsQty.Size = new System.Drawing.Size(327, 20);
            this.txtOsQty.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Os Qty:";
            // 
            // FormAddTokusai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 420);
            this.Controls.Add(this.txtOsQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rModels);
            this.Controls.Add(this.txtPartFm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveChanged);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPartTo);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddTokusai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Tokusai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPartFm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveChanged;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rModels;
        private System.Windows.Forms.TextBox txtEmNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOsQty;
        private System.Windows.Forms.Label label5;
    }
}