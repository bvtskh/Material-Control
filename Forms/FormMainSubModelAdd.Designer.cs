namespace Material_System
{
    partial class FormMainSubModelAdd
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
            this.txbPartTo = new System.Windows.Forms.TextBox();
            this.btnSaveChanged = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPartFrom = new System.Windows.Forms.TextBox();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.rdoSpecial = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txbPartTo
            // 
            this.txbPartTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPartTo.Location = new System.Drawing.Point(81, 73);
            this.txbPartTo.Name = "txbPartTo";
            this.txbPartTo.Size = new System.Drawing.Size(233, 21);
            this.txbPartTo.TabIndex = 2;
            // 
            // btnSaveChanged
            // 
            this.btnSaveChanged.BackColor = System.Drawing.Color.Green;
            this.btnSaveChanged.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanged.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanged.Image = global::Material_System.Properties.Resources.Save;
            this.btnSaveChanged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanged.Location = new System.Drawing.Point(153, 131);
            this.btnSaveChanged.Name = "btnSaveChanged";
            this.btnSaveChanged.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveChanged.Size = new System.Drawing.Size(83, 35);
            this.btnSaveChanged.TabIndex = 3;
            this.btnSaveChanged.Text = "&Saves";
            this.btnSaveChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanged.UseVisualStyleBackColor = false;
            this.btnSaveChanged.Click += new System.EventHandler(this.btnSaveChanged_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Part To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Part From";
            // 
            // txbPartFrom
            // 
            this.txbPartFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPartFrom.Location = new System.Drawing.Point(81, 34);
            this.txbPartFrom.Name = "txbPartFrom";
            this.txbPartFrom.Size = new System.Drawing.Size(233, 21);
            this.txbPartFrom.TabIndex = 1;
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Location = new System.Drawing.Point(210, 101);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(106, 17);
            this.rdoNormal.TabIndex = 9;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "Main-Sub thường";
            this.rdoNormal.UseVisualStyleBackColor = true;
            // 
            // rdoSpecial
            // 
            this.rdoSpecial.AutoSize = true;
            this.rdoSpecial.Location = new System.Drawing.Point(73, 101);
            this.rdoSpecial.Name = "rdoSpecial";
            this.rdoSpecial.Size = new System.Drawing.Size(113, 17);
            this.rdoSpecial.TabIndex = 10;
            this.rdoSpecial.TabStop = true;
            this.rdoSpecial.Text = "Main-Sub Đặc biệt";
            this.rdoSpecial.UseVisualStyleBackColor = true;
            // 
            // FormMainSubModelAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 178);
            this.Controls.Add(this.rdoNormal);
            this.Controls.Add(this.rdoSpecial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPartFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveChanged);
            this.Controls.Add(this.txbPartTo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMainSubModelAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New";
            this.Load += new System.EventHandler(this.FormMainSubModelAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbPartTo;
        private System.Windows.Forms.Button btnSaveChanged;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPartFrom;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.RadioButton rdoSpecial;
    }
}