
namespace GUI
{
    partial class UC_checkSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_checkSP));
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gb_ktsp = new System.Windows.Forms.GroupBox();
            this.pnlct_dgv = new DevExpress.XtraEditors.PanelControl();
            this.dgv_sp_add = new System.Windows.Forms.DataGridView();
            this.dgv_sp = new System.Windows.Forms.DataGridView();
            this.bt_load = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_xuatfiles = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_tk = new System.Windows.Forms.TextBox();
            this.gb_ktsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlct_dgv)).BeginInit();
            this.pnlct_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(0, 0);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(12, 1025);
            this.splitterControl1.TabIndex = 3;
            this.splitterControl1.TabStop = false;
            // 
            // gb_ktsp
            // 
            this.gb_ktsp.Controls.Add(this.pnlct_dgv);
            this.gb_ktsp.Controls.Add(this.bt_load);
            this.gb_ktsp.Controls.Add(this.label1);
            this.gb_ktsp.Controls.Add(this.bt_xuatfiles);
            this.gb_ktsp.Controls.Add(this.comboBox1);
            this.gb_ktsp.Controls.Add(this.txt_tk);
            this.gb_ktsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_ktsp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ktsp.Location = new System.Drawing.Point(12, 0);
            this.gb_ktsp.Name = "gb_ktsp";
            this.gb_ktsp.Size = new System.Drawing.Size(1765, 1025);
            this.gb_ktsp.TabIndex = 4;
            this.gb_ktsp.TabStop = false;
            this.gb_ktsp.Text = "Kiểm tra sản phẩm";
            // 
            // pnlct_dgv
            // 
            this.pnlct_dgv.Controls.Add(this.dgv_sp_add);
            this.pnlct_dgv.Controls.Add(this.dgv_sp);
            this.pnlct_dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlct_dgv.Location = new System.Drawing.Point(3, 210);
            this.pnlct_dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlct_dgv.Name = "pnlct_dgv";
            this.pnlct_dgv.Size = new System.Drawing.Size(1759, 812);
            this.pnlct_dgv.TabIndex = 82;
            // 
            // dgv_sp_add
            // 
            this.dgv_sp_add.AllowUserToAddRows = false;
            this.dgv_sp_add.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sp_add.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv_sp_add.Location = new System.Drawing.Point(951, 2);
            this.dgv_sp_add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_sp_add.Name = "dgv_sp_add";
            this.dgv_sp_add.RowHeadersWidth = 51;
            this.dgv_sp_add.RowTemplate.Height = 24;
            this.dgv_sp_add.Size = new System.Drawing.Size(806, 808);
            this.dgv_sp_add.TabIndex = 1;
            // 
            // dgv_sp
            // 
            this.dgv_sp.AllowUserToAddRows = false;
            this.dgv_sp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sp.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv_sp.Location = new System.Drawing.Point(2, 2);
            this.dgv_sp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_sp.Name = "dgv_sp";
            this.dgv_sp.RowHeadersWidth = 51;
            this.dgv_sp.RowTemplate.Height = 24;
            this.dgv_sp.Size = new System.Drawing.Size(943, 808);
            this.dgv_sp.TabIndex = 0;
            // 
            // bt_load
            // 
            this.bt_load.Appearance.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_load.Appearance.Options.UseFont = true;
            this.bt_load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_load.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_load.ImageOptions.Image")));
            this.bt_load.Location = new System.Drawing.Point(1076, 40);
            this.bt_load.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(300, 99);
            this.bt_load.TabIndex = 81;
            this.bt_load.Text = "Làm mới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 38);
            this.label1.TabIndex = 79;
            this.label1.Text = " Tìm kiếm";
            // 
            // bt_xuatfiles
            // 
            this.bt_xuatfiles.Appearance.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.bt_xuatfiles.Appearance.Options.UseFont = true;
            this.bt_xuatfiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_xuatfiles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_xuatfiles.ImageOptions.Image")));
            this.bt_xuatfiles.Location = new System.Drawing.Point(1435, 40);
            this.bt_xuatfiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_xuatfiles.Name = "bt_xuatfiles";
            this.bt_xuatfiles.Size = new System.Drawing.Size(300, 99);
            this.bt_xuatfiles.TabIndex = 80;
            this.bt_xuatfiles.Text = "Xuất files ";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-- Lọc sản phẩm theo --"});
            this.comboBox1.Location = new System.Drawing.Point(632, 127);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 40);
            this.comboBox1.TabIndex = 77;
            // 
            // txt_tk
            // 
            this.txt_tk.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tk.Location = new System.Drawing.Point(176, 40);
            this.txt_tk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_tk.Multiline = true;
            this.txt_tk.Name = "txt_tk";
            this.txt_tk.Size = new System.Drawing.Size(504, 66);
            this.txt_tk.TabIndex = 78;
            // 
            // UC_checkSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_ktsp);
            this.Controls.Add(this.splitterControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_checkSP";
            this.Size = new System.Drawing.Size(1777, 1025);
            this.gb_ktsp.ResumeLayout(false);
            this.gb_ktsp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlct_dgv)).EndInit();
            this.pnlct_dgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.GroupBox gb_ktsp;
        private DevExpress.XtraEditors.PanelControl pnlct_dgv;
        private System.Windows.Forms.DataGridView dgv_sp_add;
        private System.Windows.Forms.DataGridView dgv_sp;
        private DevExpress.XtraEditors.SimpleButton bt_load;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton bt_xuatfiles;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txt_tk;
    }
}
