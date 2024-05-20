namespace Material_System.UCCustom
{
    partial class UConfirmInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbTitle = new Sunny.UI.UICheckBox();
            this.subTitle = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // cbTitle
            // 
            this.cbTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbTitle.Location = new System.Drawing.Point(15, 7);
            this.cbTitle.Margin = new System.Windows.Forms.Padding(4);
            this.cbTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(553, 40);
            this.cbTitle.TabIndex = 0;
            this.cbTitle.Text = "4. Đã hoàn thành SAVE(Lưu giữ) chương trình gắn";
            this.cbTitle.CheckedChanged += new System.EventHandler(this.cbTitle_CheckedChanged);
            // 
            // subTitle
            // 
            this.subTitle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTitle.ForeColor = System.Drawing.Color.Red;
            this.subTitle.Location = new System.Drawing.Point(45, 43);
            this.subTitle.Name = "subTitle";
            this.subTitle.Size = new System.Drawing.Size(523, 23);
            this.subTitle.Style = Sunny.UI.UIStyle.Custom;
            this.subTitle.TabIndex = 1;
            this.subTitle.Text = "(Sai pitch sẽ gây tổn thất linh kiện hàng loạt, ảnh hưởng đến độ loss)";
            this.subTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UConfirmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.subTitle);
            this.Controls.Add(this.cbTitle);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UConfirmInfo";
            this.Size = new System.Drawing.Size(587, 75);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UICheckBox cbTitle;
        private Sunny.UI.UILabel subTitle;
    }
}
