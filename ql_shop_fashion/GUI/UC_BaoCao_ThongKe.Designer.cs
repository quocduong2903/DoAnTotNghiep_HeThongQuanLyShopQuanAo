
namespace GUI
{
    partial class UC_BaoCao_ThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_BaoCao_ThongKe));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            this.pnl_chinh = new System.Windows.Forms.Panel();
            this.gct_hoadondoitra = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bt_thongketheongay = new DevExpress.XtraBars.BarButtonItem();
            this.bt_thongketheothang = new DevExpress.XtraBars.BarButtonItem();
            this.bt_thongketheonam = new DevExpress.XtraBars.BarButtonItem();
            this.bt_thongkenhaphangtheothang = new DevExpress.XtraBars.BarButtonItem();
            this.bt_thongkenhaphangtheonam = new DevExpress.XtraBars.BarButtonItem();
            this.bt_xuatbaocao = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gct_hoadon = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chart_bc_tk = new DevExpress.XtraCharts.ChartControl();
            this.pnl_chinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gct_hoadondoitra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gct_hoadon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_bc_tk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_chinh
            // 
            this.pnl_chinh.Controls.Add(this.gct_hoadondoitra);
            this.pnl_chinh.Controls.Add(this.gct_hoadon);
            this.pnl_chinh.Controls.Add(this.chart_bc_tk);
            this.pnl_chinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_chinh.Location = new System.Drawing.Point(0, 32);
            this.pnl_chinh.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_chinh.Name = "pnl_chinh";
            this.pnl_chinh.Size = new System.Drawing.Size(1655, 809);
            this.pnl_chinh.TabIndex = 0;
            // 
            // gct_hoadondoitra
            // 
            this.gct_hoadondoitra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gct_hoadondoitra.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gct_hoadondoitra.Location = new System.Drawing.Point(1144, 519);
            this.gct_hoadondoitra.MainView = this.gridView2;
            this.gct_hoadondoitra.Margin = new System.Windows.Forms.Padding(4);
            this.gct_hoadondoitra.MenuManager = this.barManager1;
            this.gct_hoadondoitra.Name = "gct_hoadondoitra";
            this.gct_hoadondoitra.Size = new System.Drawing.Size(511, 290);
            this.gct_hoadondoitra.TabIndex = 2;
            this.gct_hoadondoitra.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 431;
            this.gridView2.GridControl = this.gct_hoadondoitra;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
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
            this.bt_thongketheongay,
            this.bt_thongketheothang,
            this.bt_thongketheonam,
            this.bt_xuatbaocao,
            this.bt_thongkenhaphangtheothang,
            this.bt_thongkenhaphangtheonam});
            this.barManager1.MaxItemId = 6;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_thongketheongay, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_thongketheothang, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_thongketheonam, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_thongkenhaphangtheothang, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_thongkenhaphangtheonam, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_xuatbaocao, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // bt_thongketheongay
            // 
            this.bt_thongketheongay.Caption = "Thống kê theo ngày";
            this.bt_thongketheongay.Id = 0;
            this.bt_thongketheongay.ImageOptions.Image = global::GUI.Properties.Resources.thongketheongay;
            this.bt_thongketheongay.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thongketheongay.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_thongketheongay.Name = "bt_thongketheongay";
            // 
            // bt_thongketheothang
            // 
            this.bt_thongketheothang.Caption = "Thống kê theo tháng";
            this.bt_thongketheothang.Id = 1;
            this.bt_thongketheothang.ImageOptions.Image = global::GUI.Properties.Resources.thongketheothang;
            this.bt_thongketheothang.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thongketheothang.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_thongketheothang.Name = "bt_thongketheothang";
            // 
            // bt_thongketheonam
            // 
            this.bt_thongketheonam.Caption = "Thống kê theo năm";
            this.bt_thongketheonam.Id = 2;
            this.bt_thongketheonam.ImageOptions.Image = global::GUI.Properties.Resources.thongketheonam;
            this.bt_thongketheonam.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thongketheonam.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_thongketheonam.Name = "bt_thongketheonam";
            // 
            // bt_thongkenhaphangtheothang
            // 
            this.bt_thongkenhaphangtheothang.Caption = "Thống kê nhập hàng theo tháng";
            this.bt_thongkenhaphangtheothang.Id = 4;
            this.bt_thongkenhaphangtheothang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_thongkenhaphangtheothang.ImageOptions.Image")));
            this.bt_thongkenhaphangtheothang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_thongkenhaphangtheothang.ImageOptions.LargeImage")));
            this.bt_thongkenhaphangtheothang.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.bt_thongkenhaphangtheothang.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_thongkenhaphangtheothang.Name = "bt_thongkenhaphangtheothang";
            // 
            // bt_thongkenhaphangtheonam
            // 
            this.bt_thongkenhaphangtheonam.Caption = "Thống kê nhập hàng theo năm";
            this.bt_thongkenhaphangtheonam.Id = 5;
            this.bt_thongkenhaphangtheonam.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_thongkenhaphangtheonam.ImageOptions.Image")));
            this.bt_thongkenhaphangtheonam.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_thongkenhaphangtheonam.ImageOptions.LargeImage")));
            this.bt_thongkenhaphangtheonam.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.bt_thongkenhaphangtheonam.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_thongkenhaphangtheonam.Name = "bt_thongkenhaphangtheonam";
            // 
            // bt_xuatbaocao
            // 
            this.bt_xuatbaocao.Caption = "Xuất báo cáo";
            this.bt_xuatbaocao.Id = 3;
            this.bt_xuatbaocao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_xuatbaocao.ImageOptions.Image")));
            this.bt_xuatbaocao.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_xuatbaocao.ImageOptions.LargeImage")));
            this.bt_xuatbaocao.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xuatbaocao.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_xuatbaocao.Name = "bt_xuatbaocao";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1655, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 841);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1655, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 809);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1655, 32);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 809);
            // 
            // gct_hoadon
            // 
            this.gct_hoadon.Dock = System.Windows.Forms.DockStyle.Left;
            this.gct_hoadon.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gct_hoadon.Location = new System.Drawing.Point(0, 519);
            this.gct_hoadon.MainView = this.gridView1;
            this.gct_hoadon.Margin = new System.Windows.Forms.Padding(4);
            this.gct_hoadon.MenuManager = this.barManager1;
            this.gct_hoadon.Name = "gct_hoadon";
            this.gct_hoadon.Size = new System.Drawing.Size(1144, 290);
            this.gct_hoadon.TabIndex = 1;
            this.gct_hoadon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gct_hoadon;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // chart_bc_tk
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chart_bc_tk.Diagram = xyDiagram1;
            this.chart_bc_tk.Dock = System.Windows.Forms.DockStyle.Top;
            this.chart_bc_tk.Legend.Name = "Default Legend";
            this.chart_bc_tk.Location = new System.Drawing.Point(0, 0);
            this.chart_bc_tk.Margin = new System.Windows.Forms.Padding(4);
            this.chart_bc_tk.Name = "chart_bc_tk";
            series1.Name = "Series 1";
            this.chart_bc_tk.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chart_bc_tk.Size = new System.Drawing.Size(1655, 519);
            this.chart_bc_tk.TabIndex = 0;
            // 
            // UC_BaoCao_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_chinh);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_BaoCao_ThongKe";
            this.Size = new System.Drawing.Size(1655, 841);
            this.pnl_chinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gct_hoadondoitra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gct_hoadon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_bc_tk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_chinh;
        private DevExpress.XtraCharts.ChartControl chart_bc_tk;
        private DevExpress.XtraGrid.GridControl gct_hoadon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bt_thongketheongay;
        private DevExpress.XtraBars.BarButtonItem bt_thongketheothang;
        private DevExpress.XtraBars.BarButtonItem bt_thongketheonam;
        private DevExpress.XtraBars.BarButtonItem bt_xuatbaocao;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gct_hoadondoitra;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.BarButtonItem bt_thongkenhaphangtheothang;
        private DevExpress.XtraBars.BarButtonItem bt_thongkenhaphangtheonam;
    }
}
