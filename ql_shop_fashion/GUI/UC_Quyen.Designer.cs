
namespace GUI
{
    partial class UC_Quyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Quyen));
            this.gct_nhom_quyen = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.quyen = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bt_them = new DevExpress.XtraBars.BarButtonItem();
            this.bt_update = new DevExpress.XtraBars.BarButtonItem();
            this.bt_xoa = new DevExpress.XtraBars.BarButtonItem();
            this.bt_save = new DevExpress.XtraBars.BarButtonItem();
            this.bt_them_man_hinh = new DevExpress.XtraBars.BarButtonItem();
            this.bt_sua_name_mh = new DevExpress.XtraBars.BarButtonItem();
            this.bt_delete_mh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gct_nhom_quyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gct_nhom_quyen
            // 
            this.gct_nhom_quyen.Dock = System.Windows.Forms.DockStyle.Left;
            this.gct_nhom_quyen.Location = new System.Drawing.Point(0, 28);
            this.gct_nhom_quyen.MainView = this.gridView1;
            this.gct_nhom_quyen.Name = "gct_nhom_quyen";
            this.gct_nhom_quyen.Size = new System.Drawing.Size(454, 683);
            this.gct_nhom_quyen.TabIndex = 0;
            this.gct_nhom_quyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gct_nhom_quyen;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // quyen
            // 
            this.quyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quyen.Location = new System.Drawing.Point(454, 28);
            this.quyen.MainView = this.gridView3;
            this.quyen.Name = "quyen";
            this.quyen.Size = new System.Drawing.Size(920, 683);
            this.quyen.TabIndex = 2;
            this.quyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.quyen;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bt_them,
            this.bt_update,
            this.bt_xoa,
            this.bt_save,
            this.bt_them_man_hinh,
            this.bt_sua_name_mh,
            this.bt_delete_mh});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_them, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_update, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_xoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_save, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_them_man_hinh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_sua_name_mh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_delete_mh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bt_them
            // 
            this.bt_them.Caption = "Thêm";
            this.bt_them.Id = 0;
            this.bt_them.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_them.ImageOptions.Image")));
            this.bt_them.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_them.ImageOptions.LargeImage")));
            this.bt_them.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_them.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_them.Name = "bt_them";
            // 
            // bt_update
            // 
            this.bt_update.Caption = "Sửa";
            this.bt_update.Id = 1;
            this.bt_update.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_update.ImageOptions.Image")));
            this.bt_update.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_update.ImageOptions.LargeImage")));
            this.bt_update.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_update.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_update.Name = "bt_update";
            // 
            // bt_xoa
            // 
            this.bt_xoa.Caption = "Xóa";
            this.bt_xoa.Id = 2;
            this.bt_xoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_xoa.ImageOptions.Image")));
            this.bt_xoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_xoa.ImageOptions.LargeImage")));
            this.bt_xoa.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_xoa.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_xoa.Name = "bt_xoa";
            // 
            // bt_save
            // 
            this.bt_save.Caption = "Lưu lại";
            this.bt_save.Id = 3;
            this.bt_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.ImageOptions.Image")));
            this.bt_save.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_save.ImageOptions.LargeImage")));
            this.bt_save.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_save.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_save.Name = "bt_save";
            // 
            // bt_them_man_hinh
            // 
            this.bt_them_man_hinh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bt_them_man_hinh.Caption = "Thêm màn hình";
            this.bt_them_man_hinh.Id = 4;
            this.bt_them_man_hinh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_them_man_hinh.ImageOptions.Image")));
            this.bt_them_man_hinh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_them_man_hinh.ImageOptions.LargeImage")));
            this.bt_them_man_hinh.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_them_man_hinh.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_them_man_hinh.Name = "bt_them_man_hinh";
            // 
            // bt_sua_name_mh
            // 
            this.bt_sua_name_mh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bt_sua_name_mh.Caption = "Sửa tên màn hình";
            this.bt_sua_name_mh.Id = 5;
            this.bt_sua_name_mh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_sua_name_mh.ImageOptions.Image")));
            this.bt_sua_name_mh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_sua_name_mh.ImageOptions.LargeImage")));
            this.bt_sua_name_mh.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_sua_name_mh.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_sua_name_mh.Name = "bt_sua_name_mh";
            // 
            // bt_delete_mh
            // 
            this.bt_delete_mh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bt_delete_mh.Caption = "Xóa màn hình";
            this.bt_delete_mh.Id = 6;
            this.bt_delete_mh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_delete_mh.ImageOptions.Image")));
            this.bt_delete_mh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_delete_mh.ImageOptions.LargeImage")));
            this.bt_delete_mh.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bt_delete_mh.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_delete_mh.Name = "bt_delete_mh";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1374, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 711);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1374, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 683);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1374, 28);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 683);
            // 
            // UC_Quyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.quyen);
            this.Controls.Add(this.gct_nhom_quyen);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UC_Quyen";
            this.Size = new System.Drawing.Size(1374, 711);
            ((System.ComponentModel.ISupportInitialize)(this.gct_nhom_quyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gct_nhom_quyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl quyen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bt_them;
        private DevExpress.XtraBars.BarButtonItem bt_update;
        private DevExpress.XtraBars.BarButtonItem bt_xoa;
        private DevExpress.XtraBars.BarButtonItem bt_save;
        private DevExpress.XtraBars.BarButtonItem bt_them_man_hinh;
        private DevExpress.XtraBars.BarButtonItem bt_sua_name_mh;
        private DevExpress.XtraBars.BarButtonItem bt_delete_mh;
    }
}
