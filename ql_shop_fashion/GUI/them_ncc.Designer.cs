
namespace GUI
{
    partial class them_ncc
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dt = new DevExpress.XtraEditors.TextEdit();
            this.dc = new DevExpress.XtraEditors.TextEdit();
            this.ten_ncc = new DevExpress.XtraEditors.TextEdit();
            this.pnl_themncc = new System.Windows.Forms.Panel();
            this.btthem = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ten_ncc.Properties)).BeginInit();
            this.pnl_themncc.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(27, 129);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 19);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Số điện thoại";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(27, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 19);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Địa chỉ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(27, 34);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 19);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Tên nhà cung cấp";
            // 
            // dt
            // 
            this.dt.Location = new System.Drawing.Point(148, 123);
            this.dt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dt.Name = "dt";
            this.dt.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dt.Properties.Appearance.Options.UseFont = true;
            this.dt.Size = new System.Drawing.Size(228, 24);
            this.dt.TabIndex = 12;
            // 
            // dc
            // 
            this.dc.Location = new System.Drawing.Point(148, 76);
            this.dc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dc.Name = "dc";
            this.dc.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dc.Properties.Appearance.Options.UseFont = true;
            this.dc.Size = new System.Drawing.Size(228, 24);
            this.dc.TabIndex = 11;
            // 
            // ten_ncc
            // 
            this.ten_ncc.Location = new System.Drawing.Point(148, 31);
            this.ten_ncc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ten_ncc.Name = "ten_ncc";
            this.ten_ncc.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ten_ncc.Properties.Appearance.Options.UseFont = true;
            this.ten_ncc.Size = new System.Drawing.Size(228, 24);
            this.ten_ncc.TabIndex = 10;
            // 
            // pnl_themncc
            // 
            this.pnl_themncc.BackColor = System.Drawing.Color.White;
            this.pnl_themncc.Controls.Add(this.btthem);
            this.pnl_themncc.Controls.Add(this.labelControl2);
            this.pnl_themncc.Controls.Add(this.ten_ncc);
            this.pnl_themncc.Controls.Add(this.labelControl4);
            this.pnl_themncc.Controls.Add(this.dc);
            this.pnl_themncc.Controls.Add(this.labelControl3);
            this.pnl_themncc.Controls.Add(this.dt);
            this.pnl_themncc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_themncc.Location = new System.Drawing.Point(0, 0);
            this.pnl_themncc.Name = "pnl_themncc";
            this.pnl_themncc.Size = new System.Drawing.Size(427, 252);
            this.pnl_themncc.TabIndex = 18;
            // 
            // btthem
            // 
            this.btthem.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btthem.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthem.Appearance.Options.UseBackColor = true;
            this.btthem.Appearance.Options.UseFont = true;
            this.btthem.Location = new System.Drawing.Point(130, 183);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(150, 37);
            this.btthem.TabIndex = 16;
            this.btthem.Text = "Thêm mới";
            // 
            // them_ncc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 252);
            this.Controls.Add(this.pnl_themncc);
            this.Name = "them_ncc";
            this.Text = "Thêm Nhà Cung Cấp";
            ((System.ComponentModel.ISupportInitialize)(this.dt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ten_ncc.Properties)).EndInit();
            this.pnl_themncc.ResumeLayout(false);
            this.pnl_themncc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit dt;
        private DevExpress.XtraEditors.TextEdit dc;
        private DevExpress.XtraEditors.TextEdit ten_ncc;
        private System.Windows.Forms.Panel pnl_themncc;
        private DevExpress.XtraEditors.SimpleButton btthem;
    }
}