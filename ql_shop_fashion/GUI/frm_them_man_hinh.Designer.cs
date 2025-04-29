
namespace GUI
{
    partial class frm_them_man_hinh
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
            this.pnl_themncc = new System.Windows.Forms.Panel();
            this.bt_them = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ma_mh = new DevExpress.XtraEditors.TextEdit();
            this.txt_name_mh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pnl_themncc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ma_mh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name_mh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_themncc
            // 
            this.pnl_themncc.BackColor = System.Drawing.Color.White;
            this.pnl_themncc.Controls.Add(this.bt_them);
            this.pnl_themncc.Controls.Add(this.labelControl2);
            this.pnl_themncc.Controls.Add(this.txt_ma_mh);
            this.pnl_themncc.Controls.Add(this.txt_name_mh);
            this.pnl_themncc.Controls.Add(this.labelControl3);
            this.pnl_themncc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_themncc.Location = new System.Drawing.Point(0, 0);
            this.pnl_themncc.Name = "pnl_themncc";
            this.pnl_themncc.Size = new System.Drawing.Size(423, 216);
            this.pnl_themncc.TabIndex = 19;
            // 
            // bt_them
            // 
            this.bt_them.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_them.ForeColor = System.Drawing.Color.Black;
            this.bt_them.Location = new System.Drawing.Point(127, 126);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(158, 41);
            this.bt_them.TabIndex = 15;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 34);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Mã màn hình";
            // 
            // txt_ma_mh
            // 
            this.txt_ma_mh.Location = new System.Drawing.Point(148, 31);
            this.txt_ma_mh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ma_mh.Name = "txt_ma_mh";
            this.txt_ma_mh.Size = new System.Drawing.Size(228, 20);
            this.txt_ma_mh.TabIndex = 10;
            // 
            // txt_name_mh
            // 
            this.txt_name_mh.Location = new System.Drawing.Point(148, 76);
            this.txt_name_mh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_name_mh.Name = "txt_name_mh";
            this.txt_name_mh.Size = new System.Drawing.Size(228, 20);
            this.txt_name_mh.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Tên màn hình";
            // 
            // frm_them_man_hinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 216);
            this.Controls.Add(this.pnl_themncc);
            this.Name = "frm_them_man_hinh";
            this.Text = "Thêm Màn Hình";
            this.pnl_themncc.ResumeLayout(false);
            this.pnl_themncc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ma_mh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name_mh.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_themncc;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_ma_mh;
        private DevExpress.XtraEditors.TextEdit txt_name_mh;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Button bt_them;
    }
}