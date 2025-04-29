
namespace GUI
{
    partial class frmInGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInGia));
            this.dgvSanPham = new DevExpress.XtraGrid.GridControl();
            this.dgvDS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TenSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GiaGiam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.x = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgvSanPhamThem = new DevExpress.XtraGrid.GridControl();
            this.dgvDS2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSanPham.Location = new System.Drawing.Point(0, 24);
            this.dgvSanPham.MainView = this.dgvDS;
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(5);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.x});
            this.dgvSanPham.Size = new System.Drawing.Size(1510, 659);
            this.dgvSanPham.TabIndex = 71;
            this.dgvSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDS,
            this.gridView3});
            // 
            // dgvDS
            // 
            this.dgvDS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenSP,
            this.TenKT,
            this.TenMau,
            this.GiaBan,
            this.GiaGiam,
            this.MaSP});
            this.dgvDS.DetailHeight = 581;
            this.dgvDS.FixedLineWidth = 3;
            this.dgvDS.GridControl = this.dgvSanPham;
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.OptionsView.ColumnAutoWidth = false;
            this.dgvDS.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // TenSP
            // 
            this.TenSP.Caption = "Tên sản phẩm";
            this.TenSP.FieldName = "TenSP";
            this.TenSP.MinWidth = 24;
            this.TenSP.Name = "TenSP";
            this.TenSP.Visible = true;
            this.TenSP.VisibleIndex = 1;
            this.TenSP.Width = 119;
            // 
            // TenKT
            // 
            this.TenKT.Caption = "Kích thước";
            this.TenKT.FieldName = "TenKT";
            this.TenKT.MinWidth = 24;
            this.TenKT.Name = "TenKT";
            this.TenKT.Visible = true;
            this.TenKT.VisibleIndex = 2;
            this.TenKT.Width = 94;
            // 
            // TenMau
            // 
            this.TenMau.Caption = "Màu sắc";
            this.TenMau.FieldName = "TenMau";
            this.TenMau.MinWidth = 24;
            this.TenMau.Name = "TenMau";
            this.TenMau.Visible = true;
            this.TenMau.VisibleIndex = 3;
            this.TenMau.Width = 94;
            // 
            // GiaBan
            // 
            this.GiaBan.Caption = "Giá bán";
            this.GiaBan.FieldName = "GiaBan";
            this.GiaBan.MinWidth = 24;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Visible = true;
            this.GiaBan.VisibleIndex = 4;
            this.GiaBan.Width = 94;
            // 
            // GiaGiam
            // 
            this.GiaGiam.Caption = "Giá giảm";
            this.GiaGiam.DisplayFormat.FormatString = "0,00";
            this.GiaGiam.FieldName = "GiaGiam";
            this.GiaGiam.MinWidth = 24;
            this.GiaGiam.Name = "GiaGiam";
            this.GiaGiam.Visible = true;
            this.GiaGiam.VisibleIndex = 5;
            this.GiaGiam.Width = 94;
            // 
            // MaSP
            // 
            this.MaSP.Caption = "Mã sản phẩm";
            this.MaSP.FieldName = "MaSP";
            this.MaSP.MinWidth = 24;
            this.MaSP.Name = "MaSP";
            this.MaSP.Visible = true;
            this.MaSP.VisibleIndex = 0;
            this.MaSP.Width = 94;
            // 
            // x
            // 
            this.x.AutoHeight = false;
            this.x.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.x.Name = "x";
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 581;
            this.gridView3.FixedLineWidth = 3;
            this.gridView3.GridControl = this.dgvSanPham;
            this.gridView3.Name = "gridView3";
            // 
            // dgvSanPhamThem
            // 
            this.dgvSanPhamThem.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvSanPhamThem.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSanPhamThem.Location = new System.Drawing.Point(0, 24);
            this.dgvSanPhamThem.MainView = this.dgvDS2;
            this.dgvSanPhamThem.Margin = new System.Windows.Forms.Padding(5);
            this.dgvSanPhamThem.Name = "dgvSanPhamThem";
            this.dgvSanPhamThem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.dgvSanPhamThem.Size = new System.Drawing.Size(485, 659);
            this.dgvSanPhamThem.TabIndex = 75;
            this.dgvSanPhamThem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDS2,
            this.gridView2});
            // 
            // dgvDS2
            // 
            this.dgvDS2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn6});
            this.dgvDS2.DetailHeight = 581;
            this.dgvDS2.FixedLineWidth = 3;
            this.dgvDS2.GridControl = this.dgvSanPhamThem;
            this.dgvDS2.Name = "dgvDS2";
            this.dgvDS2.OptionsView.ColumnAutoWidth = false;
            this.dgvDS2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên sản phẩm";
            this.gridColumn1.FieldName = "TenSP";
            this.gridColumn1.MinWidth = 24;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 119;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kích thước";
            this.gridColumn2.FieldName = "TenKT";
            this.gridColumn2.MinWidth = 24;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Màu sắc";
            this.gridColumn3.FieldName = "TenMau";
            this.gridColumn3.MinWidth = 24;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Giá bán";
            this.gridColumn4.FieldName = "GiaBan";
            this.gridColumn4.MinWidth = 24;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Giá giảm";
            this.gridColumn5.DisplayFormat.FormatString = "0,00";
            this.gridColumn5.FieldName = "GiaGiam";
            this.gridColumn5.MinWidth = 24;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 94;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Mã sản phẩm";
            this.gridColumn7.FieldName = "MaSP";
            this.gridColumn7.MinWidth = 24;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 94;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số tem";
            this.gridColumn6.FieldName = "So_tem";
            this.gridColumn6.MinWidth = 24;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 94;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 581;
            this.gridView2.FixedLineWidth = 3;
            this.gridView2.GridControl = this.dgvSanPhamThem;
            this.gridView2.Name = "gridView2";
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
            this.btnIn,
            this.btnThem,
            this.btnXoa});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnIn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnIn
            // 
            this.btnIn.Caption = "In giá";
            this.btnIn.Id = 0;
            this.btnIn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.ImageOptions.Image")));
            this.btnIn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIn.ImageOptions.LargeImage")));
            this.btnIn.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ItemAppearance.Normal.Options.UseFont = true;
            this.btnIn.Name = "btnIn";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 1;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ItemAppearance.Normal.Options.UseFont = true;
            this.btnThem.Name = "btnThem";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnXoa.ItemAppearance.Normal.Options.UseFont = true;
            this.btnXoa.Name = "btnXoa";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1510, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 683);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1510, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 659);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1510, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 659);
            // 
            // frmInGia
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1510, 683);
            this.Controls.Add(this.dgvSanPhamThem);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmInGia";
            this.Text = "In giá sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPhamThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDS;
        private DevExpress.XtraGrid.Columns.GridColumn TenSP;
        private DevExpress.XtraGrid.Columns.GridColumn TenKT;
        private DevExpress.XtraGrid.Columns.GridColumn TenMau;
        private DevExpress.XtraGrid.Columns.GridColumn GiaBan;
        private DevExpress.XtraGrid.Columns.GridColumn GiaGiam;
        private DevExpress.XtraGrid.Columns.GridColumn MaSP;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit x;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.GridControl dgvSanPhamThem;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDS2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}