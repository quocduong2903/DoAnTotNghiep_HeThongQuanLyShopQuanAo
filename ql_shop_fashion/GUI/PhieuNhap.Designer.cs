
namespace GUI
{
    partial class PhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhieuNhap));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bt_them = new DevExpress.XtraBars.BarButtonItem();
            this.bt_sua = new DevExpress.XtraBars.BarButtonItem();
            this.bt_xoa = new DevExpress.XtraBars.BarButtonItem();
            this.bt_load = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bt_add_all = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.cbb_ncc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_tennv = new DevExpress.XtraEditors.TextEdit();
            this.date_ngaynhap = new System.Windows.Forms.DateTimePicker();
            this.lb_thanhtien = new DevExpress.XtraEditors.LabelControl();
            this.cbb_tensp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_gianhap = new DevExpress.XtraEditors.TextEdit();
            this.txt_dg = new DevExpress.XtraEditors.TextEdit();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.dgv_gia = new System.Windows.Forms.DataGridView();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.cbb_sl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dgv_sp_add = new System.Windows.Forms.DataGridView();
            this.gb_ttpn = new System.Windows.Forms.GroupBox();
            this.lb_tennhanvien = new DevExpress.XtraEditors.LabelControl();
            this.lb_dongia = new DevExpress.XtraEditors.LabelControl();
            this.lb_gianhap = new DevExpress.XtraEditors.LabelControl();
            this.lb_soluong = new DevExpress.XtraEditors.LabelControl();
            this.lb_ngaynhap = new DevExpress.XtraEditors.LabelControl();
            this.lb_tennhacungcap = new DevExpress.XtraEditors.LabelControl();
            this.lb_tensanpham = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_ncc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tennv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_tensp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_gianhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_sl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp_add)).BeginInit();
            this.gb_ttpn.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bt_them,
            this.bt_sua,
            this.bt_xoa,
            this.bt_load,
            this.barButtonItem2,
            this.barButtonItem3,
            this.bt_add_all});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 23;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1332, 158);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bt_them
            // 
            this.bt_them.Caption = "Thêm";
            this.bt_them.Id = 16;
            this.bt_them.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_them.ImageOptions.Image")));
            this.bt_them.ImageOptions.ImageUri.Uri = "New";
            this.bt_them.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_them.ImageOptions.LargeImage")));
            this.bt_them.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.bt_them.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_them.Name = "bt_them";
            this.bt_them.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bt_sua
            // 
            this.bt_sua.Caption = "Sửa";
            this.bt_sua.Id = 17;
            this.bt_sua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_sua.ImageOptions.Image")));
            this.bt_sua.ImageOptions.ImageUri.Uri = "Edit";
            this.bt_sua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_sua.ImageOptions.LargeImage")));
            this.bt_sua.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.bt_sua.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_sua.Name = "bt_sua";
            // 
            // bt_xoa
            // 
            this.bt_xoa.Caption = "Xóa";
            this.bt_xoa.Id = 18;
            this.bt_xoa.ImageOptions.ImageUri.Uri = "Delete";
            this.bt_xoa.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.bt_xoa.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_xoa.Name = "bt_xoa";
            // 
            // bt_load
            // 
            this.bt_load.AllowDrawArrow = false;
            this.bt_load.Caption = "Load";
            this.bt_load.Id = 19;
            this.bt_load.ImageOptions.ImageUri.Uri = "Refresh";
            this.bt_load.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.bt_load.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_load.Name = "bt_load";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 20;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 21;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // bt_add_all
            // 
            this.bt_add_all.Caption = "Tạo phiếu";
            this.bt_add_all.Id = 22;
            this.bt_add_all.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_add_all.ImageOptions.Image")));
            this.bt_add_all.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bt_add_all.ImageOptions.LargeImage")));
            this.bt_add_all.ItemAppearance.Normal.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.bt_add_all.ItemAppearance.Normal.Options.UseFont = true;
            this.bt_add_all.Name = "bt_add_all";
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bt_them);
            this.ribbonPageGroup1.ItemLinks.Add(this.bt_sua);
            this.ribbonPageGroup1.ItemLinks.Add(this.bt_xoa);
            this.ribbonPageGroup1.ItemLinks.Add(this.bt_load);
            this.ribbonPageGroup1.ItemLinks.Add(this.bt_add_all);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tasks";
            // 
            // cbb_ncc
            // 
            this.cbb_ncc.EditValue = "";
            this.cbb_ncc.Location = new System.Drawing.Point(449, 31);
            this.cbb_ncc.MenuManager = this.ribbonControl;
            this.cbb_ncc.Name = "cbb_ncc";
            this.cbb_ncc.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_ncc.Properties.Appearance.Options.UseFont = true;
            this.cbb_ncc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbb_ncc.Size = new System.Drawing.Size(317, 22);
            this.cbb_ncc.TabIndex = 4;
            // 
            // txt_tennv
            // 
            this.txt_tennv.EditValue = "";
            this.txt_tennv.Location = new System.Drawing.Point(108, 31);
            this.txt_tennv.MenuManager = this.ribbonControl;
            this.txt_tennv.Name = "txt_tennv";
            this.txt_tennv.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tennv.Properties.Appearance.Options.UseFont = true;
            this.txt_tennv.Size = new System.Drawing.Size(222, 22);
            this.txt_tennv.TabIndex = 5;
            // 
            // date_ngaynhap
            // 
            this.date_ngaynhap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_ngaynhap.Location = new System.Drawing.Point(108, 122);
            this.date_ngaynhap.Name = "date_ngaynhap";
            this.date_ngaynhap.Size = new System.Drawing.Size(222, 23);
            this.date_ngaynhap.TabIndex = 6;
            // 
            // lb_thanhtien
            // 
            this.lb_thanhtien.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thanhtien.Appearance.Options.UseFont = true;
            this.lb_thanhtien.Location = new System.Drawing.Point(11, 805);
            this.lb_thanhtien.Name = "lb_thanhtien";
            this.lb_thanhtien.Size = new System.Drawing.Size(96, 25);
            this.lb_thanhtien.TabIndex = 10;
            this.lb_thanhtien.Text = "Tổng tiền: ";
            // 
            // cbb_tensp
            // 
            this.cbb_tensp.Location = new System.Drawing.Point(108, 72);
            this.cbb_tensp.MenuManager = this.ribbonControl;
            this.cbb_tensp.Name = "cbb_tensp";
            this.cbb_tensp.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_tensp.Properties.Appearance.Options.UseFont = true;
            this.cbb_tensp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbb_tensp.Size = new System.Drawing.Size(222, 22);
            this.cbb_tensp.TabIndex = 11;
            // 
            // txt_gianhap
            // 
            this.txt_gianhap.Location = new System.Drawing.Point(108, 182);
            this.txt_gianhap.MenuManager = this.ribbonControl;
            this.txt_gianhap.Name = "txt_gianhap";
            this.txt_gianhap.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gianhap.Properties.Appearance.Options.UseFont = true;
            this.txt_gianhap.Size = new System.Drawing.Size(658, 22);
            this.txt_gianhap.TabIndex = 13;
            // 
            // txt_dg
            // 
            this.txt_dg.Location = new System.Drawing.Point(449, 72);
            this.txt_dg.MenuManager = this.ribbonControl;
            this.txt_dg.Name = "txt_dg";
            this.txt_dg.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dg.Properties.Appearance.Options.UseFont = true;
            this.txt_dg.Size = new System.Drawing.Size(317, 22);
            this.txt_dg.TabIndex = 24;
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(-16, -15);
            this.buttonEdit1.MenuManager = this.ribbonControl;
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(100, 20);
            this.buttonEdit1.TabIndex = 28;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Delete";
            this.barButtonItem1.Id = 18;
            this.barButtonItem1.ImageOptions.ImageUri.Uri = "Delete";
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // dgv_gia
            // 
            this.dgv_gia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_gia.Location = new System.Drawing.Point(802, 164);
            this.dgv_gia.Name = "dgv_gia";
            this.dgv_gia.RowHeadersWidth = 51;
            this.dgv_gia.Size = new System.Drawing.Size(735, 239);
            this.dgv_gia.TabIndex = 46;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Print and Export";
            // 
            // cbb_sl
            // 
            this.cbb_sl.Location = new System.Drawing.Point(449, 125);
            this.cbb_sl.MenuManager = this.ribbonControl;
            this.cbb_sl.Name = "cbb_sl";
            this.cbb_sl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_sl.Properties.Appearance.Options.UseFont = true;
            this.cbb_sl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbb_sl.Size = new System.Drawing.Size(317, 22);
            this.cbb_sl.TabIndex = 49;
            // 
            // dgv_sp_add
            // 
            this.dgv_sp_add.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sp_add.Location = new System.Drawing.Point(12, 409);
            this.dgv_sp_add.Name = "dgv_sp_add";
            this.dgv_sp_add.RowHeadersWidth = 51;
            this.dgv_sp_add.Size = new System.Drawing.Size(1525, 390);
            this.dgv_sp_add.TabIndex = 52;
            // 
            // gb_ttpn
            // 
            this.gb_ttpn.BackColor = System.Drawing.Color.White;
            this.gb_ttpn.Controls.Add(this.lb_tennhanvien);
            this.gb_ttpn.Controls.Add(this.lb_dongia);
            this.gb_ttpn.Controls.Add(this.cbb_sl);
            this.gb_ttpn.Controls.Add(this.lb_gianhap);
            this.gb_ttpn.Controls.Add(this.lb_soluong);
            this.gb_ttpn.Controls.Add(this.lb_ngaynhap);
            this.gb_ttpn.Controls.Add(this.lb_tennhacungcap);
            this.gb_ttpn.Controls.Add(this.lb_tensanpham);
            this.gb_ttpn.Controls.Add(this.txt_dg);
            this.gb_ttpn.Controls.Add(this.txt_tennv);
            this.gb_ttpn.Controls.Add(this.cbb_tensp);
            this.gb_ttpn.Controls.Add(this.date_ngaynhap);
            this.gb_ttpn.Controls.Add(this.cbb_ncc);
            this.gb_ttpn.Controls.Add(this.txt_gianhap);
            this.gb_ttpn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ttpn.Location = new System.Drawing.Point(12, 164);
            this.gb_ttpn.Name = "gb_ttpn";
            this.gb_ttpn.Size = new System.Drawing.Size(784, 239);
            this.gb_ttpn.TabIndex = 56;
            this.gb_ttpn.TabStop = false;
            this.gb_ttpn.Text = "Thông tin phiếu nhập";
            // 
            // lb_tennhanvien
            // 
            this.lb_tennhanvien.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tennhanvien.Appearance.Options.UseFont = true;
            this.lb_tennhanvien.Location = new System.Drawing.Point(28, 34);
            this.lb_tennhanvien.Name = "lb_tennhanvien";
            this.lb_tennhanvien.Size = new System.Drawing.Size(74, 15);
            this.lb_tennhanvien.TabIndex = 15;
            this.lb_tennhanvien.Text = "Tên nhân viên";
            // 
            // lb_dongia
            // 
            this.lb_dongia.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dongia.Appearance.Options.UseFont = true;
            this.lb_dongia.Location = new System.Drawing.Point(402, 75);
            this.lb_dongia.Name = "lb_dongia";
            this.lb_dongia.Size = new System.Drawing.Size(41, 15);
            this.lb_dongia.TabIndex = 25;
            this.lb_dongia.Text = "Đơn giá";
            // 
            // lb_gianhap
            // 
            this.lb_gianhap.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_gianhap.Appearance.Options.UseFont = true;
            this.lb_gianhap.Location = new System.Drawing.Point(55, 185);
            this.lb_gianhap.Name = "lb_gianhap";
            this.lb_gianhap.Size = new System.Drawing.Size(47, 15);
            this.lb_gianhap.TabIndex = 23;
            this.lb_gianhap.Text = "Giá nhập";
            // 
            // lb_soluong
            // 
            this.lb_soluong.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_soluong.Appearance.Options.UseFont = true;
            this.lb_soluong.Location = new System.Drawing.Point(396, 128);
            this.lb_soluong.Name = "lb_soluong";
            this.lb_soluong.Size = new System.Drawing.Size(47, 15);
            this.lb_soluong.TabIndex = 22;
            this.lb_soluong.Text = "Số lượng";
            // 
            // lb_ngaynhap
            // 
            this.lb_ngaynhap.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ngaynhap.Appearance.Options.UseFont = true;
            this.lb_ngaynhap.Location = new System.Drawing.Point(44, 122);
            this.lb_ngaynhap.Name = "lb_ngaynhap";
            this.lb_ngaynhap.Size = new System.Drawing.Size(58, 15);
            this.lb_ngaynhap.TabIndex = 17;
            this.lb_ngaynhap.Text = "Ngày nhập";
            // 
            // lb_tennhacungcap
            // 
            this.lb_tennhacungcap.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tennhacungcap.Appearance.Options.UseFont = true;
            this.lb_tennhacungcap.Location = new System.Drawing.Point(350, 34);
            this.lb_tennhacungcap.Name = "lb_tennhacungcap";
            this.lb_tennhacungcap.Size = new System.Drawing.Size(93, 15);
            this.lb_tennhacungcap.TabIndex = 16;
            this.lb_tennhacungcap.Text = "Tên nhà cung cấp";
            // 
            // lb_tensanpham
            // 
            this.lb_tensanpham.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tensanpham.Appearance.Options.UseFont = true;
            this.lb_tensanpham.Location = new System.Drawing.Point(29, 75);
            this.lb_tensanpham.Name = "lb_tensanpham";
            this.lb_tensanpham.Size = new System.Drawing.Size(73, 15);
            this.lb_tensanpham.TabIndex = 21;
            this.lb_tensanpham.Text = "Tên sản phẩm";
            // 
            // PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 717);
            this.Controls.Add(this.gb_ttpn);
            this.Controls.Add(this.dgv_sp_add);
            this.Controls.Add(this.dgv_gia);
            this.Controls.Add(this.buttonEdit1);
            this.Controls.Add(this.lb_thanhtien);
            this.Controls.Add(this.ribbonControl);
            this.Name = "PhieuNhap";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu Nhập";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_ncc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tennv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_tensp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_gianhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_sl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sp_add)).EndInit();
            this.gb_ttpn.ResumeLayout(false);
            this.gb_ttpn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bt_them;
        private DevExpress.XtraBars.BarButtonItem bt_sua;
        private DevExpress.XtraBars.BarButtonItem bt_xoa;
        private DevExpress.XtraBars.BarButtonItem bt_load;
        private DevExpress.XtraEditors.ComboBoxEdit cbb_ncc;
        private DevExpress.XtraEditors.TextEdit txt_tennv;
        private System.Windows.Forms.DateTimePicker date_ngaynhap;
        private DevExpress.XtraEditors.LabelControl lb_thanhtien;
        private DevExpress.XtraEditors.ComboBoxEdit cbb_tensp;
        private DevExpress.XtraEditors.TextEdit txt_gianhap;
        private DevExpress.XtraEditors.TextEdit txt_dg;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.DataGridView dgv_gia;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.ComboBoxEdit cbb_sl;
        private System.Windows.Forms.DataGridView dgv_sp_add;
        private DevExpress.XtraBars.BarButtonItem bt_add_all;
        private System.Windows.Forms.GroupBox gb_ttpn;
        private DevExpress.XtraEditors.LabelControl lb_tennhanvien;
        private DevExpress.XtraEditors.LabelControl lb_dongia;
        private DevExpress.XtraEditors.LabelControl lb_gianhap;
        private DevExpress.XtraEditors.LabelControl lb_soluong;
        private DevExpress.XtraEditors.LabelControl lb_ngaynhap;
        private DevExpress.XtraEditors.LabelControl lb_tennhacungcap;
        private DevExpress.XtraEditors.LabelControl lb_tensanpham;
    }
}