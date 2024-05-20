namespace Material_System.DialogCustom
{
    partial class DConfirmDefaultScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DConfirmDefaultScreen));
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.btnNo = new Sunny.UI.UIButton();
            this.btnYes = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.Location = new System.Drawing.Point(4, 9);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(265, 72);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Bạn có muốn hiển thị màn hình này là màn hình mặc định không?";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.FillColor = System.Drawing.Color.Silver;
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNo.Location = new System.Drawing.Point(8, 107);
            this.btnNo.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNo.Name = "btnNo";
            this.btnNo.RectColor = System.Drawing.Color.Silver;
            this.btnNo.Size = new System.Drawing.Size(100, 35);
            this.btnNo.Style = Sunny.UI.UIStyle.Custom;
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "Không";
            this.btnNo.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnYes.Location = new System.Drawing.Point(142, 107);
            this.btnYes.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(100, 35);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "Có";
            this.btnYes.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // DConfirmDefaultScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(273, 154);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.uiLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DConfirmDefaultScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton btnNo;
        private Sunny.UI.UIButton btnYes;
    }
}