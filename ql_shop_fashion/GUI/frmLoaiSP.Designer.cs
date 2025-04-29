
namespace GUI
{
    partial class frmLoaiSP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiSP));
            this.pnl_LoaiSP = new System.Windows.Forms.Panel();
            this.thongtinnhomloai = new System.Windows.Forms.Panel();
            this.gb_loaisp = new System.Windows.Forms.GroupBox();
            this.gct_loaisp = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbb_tennhomloai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lb_tennhomloai = new DevExpress.XtraEditors.LabelControl();
            this.txt_chitiet = new DevExpress.XtraEditors.TextEdit();
            this.lb_chitiet = new DevExpress.XtraEditors.LabelControl();
            this.txt_tenloai = new DevExpress.XtraEditors.TextEdit();
            this.txt_maloai = new DevExpress.XtraEditors.TextEdit();
            this.lb_tenloai = new DevExpress.XtraEditors.LabelControl();
            this.lb_maloai = new DevExpress.XtraEditors.LabelControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btn_themloaisp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_sualoaisp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_xoaloaisp = new DevExpress.XtraBars.BarButtonItem();
            this.btn_loadloaisp = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnl_LoaiSP.SuspendLayout();
            this.thongtinnhomloai.SuspendLayout();
            this.gb_loaisp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gct_loaisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_tennhomloai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_chitiet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tenloai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_maloai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_LoaiSP
            // 
            this.pnl_LoaiSP.Controls.Add(this.thongtinnhomloai);
            this.pnl_LoaiSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_LoaiSP.Location = new System.Drawing.Point(0, 30);
            this.pnl_LoaiSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_LoaiSP.Name = "pnl_LoaiSP";
            this.pnl_LoaiSP.Size = new System.Drawing.Size(1026, 861);
            this.pnl_LoaiSP.TabIndex = 0;
            // 
            // thongtinnhomloai
            // 
            this.thongtinnhomloai.BackColor = System.Drawing.Color.White;
            this.thongtinnhomloai.Controls.Add(this.gb_loaisp);
            this.thongtinnhomloai.Controls.Add(this.cbb_tennhomloai);
            this.thongtinnhomloai.Controls.Add(this.lb_tennhomloai);
            this.thongtinnhomloai.Controls.Add(this.txt_chitiet);
            this.thongtinnhomloai.Controls.Add(this.lb_chitiet);
            this.thongtinnhomloai.Controls.Add(this.txt_tenloai);
            this.thongtinnhomloai.Controls.Add(this.txt_maloai);
            this.thongtinnhomloai.Controls.Add(this.lb_tenloai);
            this.thongtinnhomloai.Controls.Add(this.lb_maloai);
            this.thongtinnhomloai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongtinnhomloai.Location = new System.Drawing.Point(0, 0);
            this.thongtinnhomloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thongtinnhomloai.Name = "thongtinnhomloai";
            this.thongtinnhomloai.Size = new System.Drawing.Size(1026, 861);
            this.thongtinnhomloai.TabIndex = 5;
            // 
            // gb_loaisp
            // 
            this.gb_loaisp.BackColor = System.Drawing.Color.White;
            this.gb_loaisp.Controls.Add(this.gct_loaisp);
            this.gb_loaisp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_loaisp.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_loaisp.Location = new System.Drawing.Point(0, 333);
            this.gb_loaisp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_loaisp.Name = "gb_loaisp";
            this.gb_loaisp.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_loaisp.Size = new System.Drawing.Size(1026, 528);
            this.gb_loaisp.TabIndex = 48;
            this.gb_loaisp.TabStop = false;
            this.gb_loaisp.Text = "Danh sách loại sản phẩm";
            // 
            // gct_loaisp
            // 
            this.gct_loaisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gct_loaisp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gct_loaisp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gct_loaisp.Location = new System.Drawing.Point(3, 28);
            this.gct_loaisp.MainView = this.gridView2;
            this.gct_loaisp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gct_loaisp.Name = "gct_loaisp";
            this.gct_loaisp.Size = new System.Drawing.Size(1020, 496);
            this.gct_loaisp.TabIndex = 39;
            this.gct_loaisp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 458;
            this.gridView2.FixedLineWidth = 3;
            this.gridView2.GridControl = this.gct_loaisp;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // cbb_tennhomloai
            // 
            this.cbb_tennhomloai.Location = new System.Drawing.Point(202, 193);
            this.cbb_tennhomloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbb_tennhomloai.Name = "cbb_tennhomloai";
            this.cbb_tennhomloai.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_tennhomloai.Properties.Appearance.Options.UseFont = true;
            this.cbb_tennhomloai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbb_tennhomloai.Size = new System.Drawing.Size(783, 28);
            this.cbb_tennhomloai.TabIndex = 47;
            // 
            // lb_tennhomloai
            // 
            this.lb_tennhomloai.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tennhomloai.Appearance.Options.UseFont = true;
            this.lb_tennhomloai.Location = new System.Drawing.Point(26, 196);
            this.lb_tennhomloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lb_tennhomloai.Name = "lb_tennhomloai";
            this.lb_tennhomloai.Size = new System.Drawing.Size(115, 23);
            this.lb_tennhomloai.TabIndex = 46;
            this.lb_tennhomloai.Text = "Tên Nhóm Loại";
            // 
            // txt_chitiet
            // 
            this.txt_chitiet.Location = new System.Drawing.Point(202, 275);
            this.txt_chitiet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_chitiet.Name = "txt_chitiet";
            this.txt_chitiet.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_chitiet.Properties.Appearance.Options.UseFont = true;
            this.txt_chitiet.Size = new System.Drawing.Size(783, 28);
            this.txt_chitiet.TabIndex = 7;
            // 
            // lb_chitiet
            // 
            this.lb_chitiet.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_chitiet.Appearance.Options.UseFont = true;
            this.lb_chitiet.Location = new System.Drawing.Point(26, 278);
            this.lb_chitiet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lb_chitiet.Name = "lb_chitiet";
            this.lb_chitiet.Size = new System.Drawing.Size(58, 23);
            this.lb_chitiet.TabIndex = 6;
            this.lb_chitiet.Text = "Chi Tiết";
            // 
            // txt_tenloai
            // 
            this.txt_tenloai.Location = new System.Drawing.Point(202, 110);
            this.txt_tenloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_tenloai.Name = "txt_tenloai";
            this.txt_tenloai.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenloai.Properties.Appearance.Options.UseFont = true;
            this.txt_tenloai.Size = new System.Drawing.Size(783, 28);
            this.txt_tenloai.TabIndex = 5;
            // 
            // txt_maloai
            // 
            this.txt_maloai.Enabled = false;
            this.txt_maloai.Location = new System.Drawing.Point(202, 19);
            this.txt_maloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_maloai.Name = "txt_maloai";
            this.txt_maloai.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maloai.Properties.Appearance.Options.UseFont = true;
            this.txt_maloai.Size = new System.Drawing.Size(783, 28);
            this.txt_maloai.TabIndex = 4;
            // 
            // lb_tenloai
            // 
            this.lb_tenloai.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tenloai.Appearance.Options.UseFont = true;
            this.lb_tenloai.Location = new System.Drawing.Point(26, 113);
            this.lb_tenloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lb_tenloai.Name = "lb_tenloai";
            this.lb_tenloai.Size = new System.Drawing.Size(62, 23);
            this.lb_tenloai.TabIndex = 1;
            this.lb_tenloai.Text = "Tên Loại";
            // 
            // lb_maloai
            // 
            this.lb_maloai.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_maloai.Appearance.Options.UseFont = true;
            this.lb_maloai.Location = new System.Drawing.Point(26, 22);
            this.lb_maloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lb_maloai.Name = "lb_maloai";
            this.lb_maloai.Size = new System.Drawing.Size(60, 23);
            this.lb_maloai.TabIndex = 0;
            this.lb_maloai.Text = "Mã Loại";
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
            this.btn_themloaisp,
            this.btn_sualoaisp,
            this.btn_xoaloaisp,
            this.btn_loadloaisp});
            this.barManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(52, 131);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_themloaisp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_sualoaisp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_xoaloaisp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_loadloaisp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Offset = 2;
            this.bar1.Text = "Tools";
            // 
            // btn_themloaisp
            // 
            this.btn_themloaisp.Caption = "Thêm";
            this.btn_themloaisp.Id = 0;
            this.btn_themloaisp.ImageOptions.Image = global::GUI.Properties.Resources.them;
            this.btn_themloaisp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_themloaisp.ImageOptions.LargeImage")));
            this.btn_themloaisp.Name = "btn_themloaisp";
            // 
            // btn_sualoaisp
            // 
            this.btn_sualoaisp.Caption = "Sửa";
            this.btn_sualoaisp.Id = 1;
            this.btn_sualoaisp.ImageOptions.Image = global::GUI.Properties.Resources.sua;
            this.btn_sualoaisp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_sualoaisp.ImageOptions.LargeImage")));
            this.btn_sualoaisp.Name = "btn_sualoaisp";
            // 
            // btn_xoaloaisp
            // 
            this.btn_xoaloaisp.Caption = "Xóa";
            this.btn_xoaloaisp.Id = 2;
            this.btn_xoaloaisp.ImageOptions.Image = global::GUI.Properties.Resources.xoa;
            this.btn_xoaloaisp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_xoaloaisp.ImageOptions.LargeImage")));
            this.btn_xoaloaisp.Name = "btn_xoaloaisp";
            // 
            // btn_loadloaisp
            // 
            this.btn_loadloaisp.Caption = "Load";
            this.btn_loadloaisp.Id = 3;
            this.btn_loadloaisp.ImageOptions.Image = global::GUI.Properties.Resources.load;
            this.btn_loadloaisp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_loadloaisp.ImageOptions.LargeImage")));
            this.btn_loadloaisp.Name = "btn_loadloaisp";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1026, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 891);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1026, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 861);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1026, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 861);
            // 
            // frmLoaiSP
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 891);
            this.Controls.Add(this.pnl_LoaiSP);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmLoaiSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Loại Sản Phẩm";
            this.pnl_LoaiSP.ResumeLayout(false);
            this.thongtinnhomloai.ResumeLayout(false);
            this.thongtinnhomloai.PerformLayout();
            this.gb_loaisp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gct_loaisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_tennhomloai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_chitiet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tenloai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_maloai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_LoaiSP;
        private System.Windows.Forms.Panel thongtinnhomloai;
        private DevExpress.XtraEditors.TextEdit txt_chitiet;
        private DevExpress.XtraEditors.LabelControl lb_chitiet;
        private DevExpress.XtraEditors.TextEdit txt_tenloai;
        private DevExpress.XtraEditors.TextEdit txt_maloai;
        private DevExpress.XtraEditors.LabelControl lb_tenloai;
        private DevExpress.XtraEditors.LabelControl lb_maloai;
        private DevExpress.XtraEditors.LabelControl lb_tennhomloai;
        private DevExpress.XtraEditors.ComboBoxEdit cbb_tennhomloai;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btn_themloaisp;
        private DevExpress.XtraBars.BarButtonItem btn_sualoaisp;
        private DevExpress.XtraBars.BarButtonItem btn_xoaloaisp;
        private DevExpress.XtraBars.BarButtonItem btn_loadloaisp;
        private System.Windows.Forms.GroupBox gb_loaisp;
        private DevExpress.XtraGrid.GridControl gct_loaisp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}