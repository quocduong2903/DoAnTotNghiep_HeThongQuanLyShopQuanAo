
namespace GUI
{
    partial class UC_TaiKhoan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TaiKhoan));
            this.gct_tk = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gb_thongtintk = new System.Windows.Forms.GroupBox();
            this.check_hd = new System.Windows.Forms.CheckBox();
            this.cbb_quyen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_mk = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_tk = new System.Windows.Forms.TextBox();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bt_save = new DevExpress.XtraBars.BarButtonItem();
            this.bt_rs_pass = new DevExpress.XtraBars.BarButtonItem();
            this.bt_load = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gct_tk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.gb_thongtintk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gct_tk
            // 
            this.gct_tk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gct_tk.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gct_tk.Location = new System.Drawing.Point(0, 341);
            this.gct_tk.MainView = this.gridView1;
            this.gct_tk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gct_tk.Name = "gct_tk";
            this.gct_tk.Size = new System.Drawing.Size(1542, 684);
            this.gct_tk.TabIndex = 9;
            this.gct_tk.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gct_tk;
            this.gridView1.Name = "gridView1";
            // 
            // gb_thongtintk
            // 
            this.gb_thongtintk.BackColor = System.Drawing.Color.White;
            this.gb_thongtintk.Controls.Add(this.check_hd);
            this.gb_thongtintk.Controls.Add(this.cbb_quyen);
            this.gb_thongtintk.Controls.Add(this.label1);
            this.gb_thongtintk.Controls.Add(this.txt_mk);
            this.gb_thongtintk.Controls.Add(this.label7);
            this.gb_thongtintk.Controls.Add(this.label6);
            this.gb_thongtintk.Controls.Add(this.txt_tk);
            this.gb_thongtintk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_thongtintk.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_thongtintk.Location = new System.Drawing.Point(0, 34);
            this.gb_thongtintk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_thongtintk.Name = "gb_thongtintk";
            this.gb_thongtintk.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_thongtintk.Size = new System.Drawing.Size(1542, 307);
            this.gb_thongtintk.TabIndex = 12;
            this.gb_thongtintk.TabStop = false;
            this.gb_thongtintk.Text = "Thông tin tài khoản";
            // 
            // check_hd
            // 
            this.check_hd.AutoSize = true;
            this.check_hd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_hd.Location = new System.Drawing.Point(1409, 233);
            this.check_hd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.check_hd.Name = "check_hd";
            this.check_hd.Size = new System.Drawing.Size(114, 27);
            this.check_hd.TabIndex = 16;
            this.check_hd.Text = "Hoạt động";
            this.check_hd.UseVisualStyleBackColor = true;
            // 
            // cbb_quyen
            // 
            this.cbb_quyen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_quyen.FormattingEnabled = true;
            this.cbb_quyen.Location = new System.Drawing.Point(119, 181);
            this.cbb_quyen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbb_quyen.Name = "cbb_quyen";
            this.cbb_quyen.Size = new System.Drawing.Size(1404, 29);
            this.cbb_quyen.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Quyền";
            // 
            // txt_mk
            // 
            this.txt_mk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mk.Location = new System.Drawing.Point(119, 114);
            this.txt_mk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_mk.Name = "txt_mk";
            this.txt_mk.Size = new System.Drawing.Size(1404, 29);
            this.txt_mk.TabIndex = 11;
            this.txt_mk.Text = "**********";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Mật Khẩu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tài khoản";
            // 
            // txt_tk
            // 
            this.txt_tk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tk.Location = new System.Drawing.Point(119, 48);
            this.txt_tk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_tk.Name = "txt_tk";
            this.txt_tk.Size = new System.Drawing.Size(1404, 29);
            this.txt_tk.TabIndex = 9;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bt_save,
            this.bt_rs_pass,
            this.bt_load});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_save, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_rs_pass, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_load, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // bt_save
            // 
            this.bt_save.Caption = "Lưu thông tin";
            this.bt_save.Id = 0;
            this.bt_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.ImageOptions.Image")));
            this.bt_save.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_save.ImageOptions.LargeImage")));
            this.bt_save.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_save.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_save.Name = "bt_save";
            // 
            // bt_rs_pass
            // 
            this.bt_rs_pass.Caption = "Tạo mới mật khẩu";
            this.bt_rs_pass.Id = 1;
            this.bt_rs_pass.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_rs_pass.ImageOptions.Image")));
            this.bt_rs_pass.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_rs_pass.ImageOptions.LargeImage")));
            this.bt_rs_pass.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.bt_rs_pass.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_rs_pass.Name = "bt_rs_pass";
            // 
            // bt_load
            // 
            this.bt_load.Caption = "Load";
            this.bt_load.Id = 2;
            this.bt_load.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_load.ImageOptions.Image")));
            this.bt_load.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_load.ImageOptions.LargeImage")));
            this.bt_load.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.bt_load.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_load.Name = "bt_load";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.BackColor = System.Drawing.Color.White;
            this.barDockControlTop.Appearance.BackColor2 = System.Drawing.Color.White;
            this.barDockControlTop.Appearance.Options.UseBackColor = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1542, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1025);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1542, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 991);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1542, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 991);
            // 
            // UC_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_thongtintk);
            this.Controls.Add(this.gct_tk);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_TaiKhoan";
            this.Size = new System.Drawing.Size(1542, 1025);
            ((System.ComponentModel.ISupportInitialize)(this.gct_tk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.gb_thongtintk.ResumeLayout(false);
            this.gb_thongtintk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gct_tk;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox gb_thongtintk;
        private System.Windows.Forms.ComboBox cbb_quyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_mk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_tk;
        private System.Windows.Forms.CheckBox check_hd;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bt_save;
        private DevExpress.XtraBars.BarButtonItem bt_rs_pass;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bt_load;
    }
}
