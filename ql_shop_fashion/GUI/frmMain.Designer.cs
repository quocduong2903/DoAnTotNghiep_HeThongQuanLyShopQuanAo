
namespace GUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ac_thongtin = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.ace_manhinhchinh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_danhmuc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_sanpham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_banhang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_quanlynhaphang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_hoadon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_kiemduyetsanpham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_nhacungcap = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_baocaothongke = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_hethongquanly = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_nhanvien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_khachhang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_taikhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_quyen = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_thongtincanhan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_dangxuat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluent_QuanLyForm = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.panel_chinh = new System.Windows.Forms.Panel();
            this.pn_main = new System.Windows.Forms.Panel();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ac_thongtin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluent_QuanLyForm)).BeginInit();
            this.panel_chinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // ac_thongtin
            // 
            this.ac_thongtin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ac_thongtin.Dock = System.Windows.Forms.DockStyle.Left;
            this.ac_thongtin.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ace_manhinhchinh,
            this.ace_danhmuc,
            this.ace_hethongquanly});
            this.ac_thongtin.Location = new System.Drawing.Point(0, 31);
            this.ac_thongtin.Name = "ac_thongtin";
            this.ac_thongtin.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.ac_thongtin.Size = new System.Drawing.Size(191, 711);
            this.ac_thongtin.TabIndex = 1;
            this.ac_thongtin.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // ace_manhinhchinh
            // 
            this.ace_manhinhchinh.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_manhinhchinh.Appearance.Normal.Options.UseFont = true;
            this.ace_manhinhchinh.Height = 65;
            this.ace_manhinhchinh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_manhinhchinh.ImageOptions.Image")));
            this.ace_manhinhchinh.Name = "ace_manhinhchinh";
            this.ace_manhinhchinh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_manhinhchinh.Tag = 1;
            this.ace_manhinhchinh.Text = "Màn Hình Chính";
            // 
            // ace_danhmuc
            // 
            this.ace_danhmuc.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_danhmuc.Appearance.Normal.Options.UseFont = true;
            this.ace_danhmuc.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ace_sanpham,
            this.ace_banhang,
            this.ace_quanlynhaphang,
            this.ace_nhacungcap,
            this.ace_baocaothongke});
            this.ace_danhmuc.Expanded = true;
            this.ace_danhmuc.Height = 55;
            this.ace_danhmuc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_danhmuc.ImageOptions.Image")));
            this.ace_danhmuc.Name = "ace_danhmuc";
            this.ace_danhmuc.Tag = 2;
            this.ace_danhmuc.Text = "Danh Mục";
            // 
            // ace_sanpham
            // 
            this.ace_sanpham.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_sanpham.Appearance.Normal.Options.UseFont = true;
            this.ace_sanpham.Height = 40;
            this.ace_sanpham.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_sanpham.ImageOptions.Image")));
            this.ace_sanpham.Name = "ace_sanpham";
            this.ace_sanpham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_sanpham.Tag = 3;
            this.ace_sanpham.Text = "Sản Phẩm";
            // 
            // ace_banhang
            // 
            this.ace_banhang.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_banhang.Appearance.Normal.Options.UseFont = true;
            this.ace_banhang.Height = 40;
            this.ace_banhang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_banhang.ImageOptions.Image")));
            this.ace_banhang.Name = "ace_banhang";
            this.ace_banhang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_banhang.Tag = 4;
            this.ace_banhang.Text = "Bán Hàng";
            // 
            // ace_quanlynhaphang
            // 
            this.ace_quanlynhaphang.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_quanlynhaphang.Appearance.Normal.Options.UseFont = true;
            this.ace_quanlynhaphang.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ace_hoadon,
            this.ace_kiemduyetsanpham});
            this.ace_quanlynhaphang.Expanded = true;
            this.ace_quanlynhaphang.Height = 40;
            this.ace_quanlynhaphang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_quanlynhaphang.ImageOptions.Image")));
            this.ace_quanlynhaphang.Name = "ace_quanlynhaphang";
            this.ace_quanlynhaphang.Tag = 5;
            this.ace_quanlynhaphang.Text = "Nhập Hàng";
            // 
            // ace_hoadon
            // 
            this.ace_hoadon.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_hoadon.Appearance.Normal.Options.UseFont = true;
            this.ace_hoadon.Height = 40;
            this.ace_hoadon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_hoadon.ImageOptions.Image")));
            this.ace_hoadon.Name = "ace_hoadon";
            this.ace_hoadon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_hoadon.Tag = 6;
            this.ace_hoadon.Text = "Hóa Đơn";
            // 
            // ace_kiemduyetsanpham
            // 
            this.ace_kiemduyetsanpham.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_kiemduyetsanpham.Appearance.Normal.Options.UseFont = true;
            this.ace_kiemduyetsanpham.Height = 40;
            this.ace_kiemduyetsanpham.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_kiemduyetsanpham.ImageOptions.Image")));
            this.ace_kiemduyetsanpham.Name = "ace_kiemduyetsanpham";
            this.ace_kiemduyetsanpham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_kiemduyetsanpham.Tag = 7;
            this.ace_kiemduyetsanpham.Text = "Kiểm tra sản phẩm";
            // 
            // ace_nhacungcap
            // 
            this.ace_nhacungcap.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_nhacungcap.Appearance.Normal.Options.UseFont = true;
            this.ace_nhacungcap.Height = 40;
            this.ace_nhacungcap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_nhacungcap.ImageOptions.Image")));
            this.ace_nhacungcap.Name = "ace_nhacungcap";
            this.ace_nhacungcap.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_nhacungcap.Tag = 8;
            this.ace_nhacungcap.Text = "Nhà Cung Cấp";
            // 
            // ace_baocaothongke
            // 
            this.ace_baocaothongke.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ace_baocaothongke.Appearance.Normal.Options.UseFont = true;
            this.ace_baocaothongke.Height = 40;
            this.ace_baocaothongke.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_baocaothongke.ImageOptions.Image")));
            this.ace_baocaothongke.Name = "ace_baocaothongke";
            this.ace_baocaothongke.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_baocaothongke.Tag = 9;
            this.ace_baocaothongke.Text = "Báo Cáo - Thống Kê";
            // 
            // ace_hethongquanly
            // 
            this.ace_hethongquanly.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ace_hethongquanly.Appearance.Normal.Options.UseFont = true;
            this.ace_hethongquanly.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ace_nhanvien,
            this.ace_khachhang,
            this.ace_taikhoan,
            this.ace_quyen,
            this.ace_thongtincanhan,
            this.ace_dangxuat});
            this.ace_hethongquanly.Expanded = true;
            this.ace_hethongquanly.Height = 55;
            this.ace_hethongquanly.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_hethongquanly.ImageOptions.Image")));
            this.ace_hethongquanly.Name = "ace_hethongquanly";
            this.ace_hethongquanly.Tag = 10;
            this.ace_hethongquanly.Text = "Hệ Thống Quản Lý";
            // 
            // ace_nhanvien
            // 
            this.ace_nhanvien.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ace_nhanvien.Appearance.Normal.Options.UseFont = true;
            this.ace_nhanvien.Height = 40;
            this.ace_nhanvien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_nhanvien.ImageOptions.Image")));
            this.ace_nhanvien.Name = "ace_nhanvien";
            this.ace_nhanvien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_nhanvien.Tag = 11;
            this.ace_nhanvien.Text = "Nhân Viên";
            // 
            // ace_khachhang
            // 
            this.ace_khachhang.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ace_khachhang.Appearance.Normal.Options.UseFont = true;
            this.ace_khachhang.Height = 40;
            this.ace_khachhang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_khachhang.ImageOptions.Image")));
            this.ace_khachhang.Name = "ace_khachhang";
            this.ace_khachhang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_khachhang.Tag = 12;
            this.ace_khachhang.Text = "Khách Hàng";
            // 
            // ace_taikhoan
            // 
            this.ace_taikhoan.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ace_taikhoan.Appearance.Normal.Options.UseFont = true;
            this.ace_taikhoan.Height = 40;
            this.ace_taikhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_taikhoan.ImageOptions.Image")));
            this.ace_taikhoan.Name = "ace_taikhoan";
            this.ace_taikhoan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_taikhoan.Tag = 13;
            this.ace_taikhoan.Text = "Tài Khoản";
            // 
            // ace_quyen
            // 
            this.ace_quyen.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ace_quyen.Appearance.Normal.Options.UseFont = true;
            this.ace_quyen.Height = 40;
            this.ace_quyen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_quyen.ImageOptions.Image")));
            this.ace_quyen.Name = "ace_quyen";
            this.ace_quyen.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_quyen.Tag = 14;
            this.ace_quyen.Text = "Quyền";
            // 
            // ace_thongtincanhan
            // 
            this.ace_thongtincanhan.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ace_thongtincanhan.Appearance.Normal.Options.UseFont = true;
            this.ace_thongtincanhan.Height = 40;
            this.ace_thongtincanhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_thongtincanhan.ImageOptions.Image")));
            this.ace_thongtincanhan.Name = "ace_thongtincanhan";
            this.ace_thongtincanhan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_thongtincanhan.Tag = 15;
            this.ace_thongtincanhan.Text = "Thông Tin Cá Nhân";
            // 
            // ace_dangxuat
            // 
            this.ace_dangxuat.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ace_dangxuat.Appearance.Normal.Options.UseFont = true;
            this.ace_dangxuat.Height = 40;
            this.ace_dangxuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ace_dangxuat.ImageOptions.Image")));
            this.ace_dangxuat.Name = "ace_dangxuat";
            this.ace_dangxuat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_dangxuat.Tag = 16;
            this.ace_dangxuat.Text = "Đăng Xuất";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluent_QuanLyForm;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1554, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluent_QuanLyForm
            // 
            this.fluent_QuanLyForm.DockingEnabled = false;
            this.fluent_QuanLyForm.Form = this;
            // 
            // panel_chinh
            // 
            this.panel_chinh.BackColor = System.Drawing.Color.White;
            this.panel_chinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_chinh.Controls.Add(this.pn_main);
            this.panel_chinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_chinh.Location = new System.Drawing.Point(191, 31);
            this.panel_chinh.Name = "panel_chinh";
            this.panel_chinh.Size = new System.Drawing.Size(1363, 711);
            this.panel_chinh.TabIndex = 3;
            // 
            // pn_main
            // 
            this.pn_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_main.Location = new System.Drawing.Point(0, 0);
            this.pn_main.Name = "pn_main";
            this.pn_main.Size = new System.Drawing.Size(1363, 711);
            this.pn_main.TabIndex = 0;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2,
            this.accordionControlElement3});
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Áo";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Áo thun";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Áo khoác";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "Quần";
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement5.Text = "Phụ Kiện";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 742);
            this.Controls.Add(this.panel_chinh);
            this.Controls.Add(this.ac_thongtin);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmMain";
            this.NavigationControl = this.ac_thongtin;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ac_thongtin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluent_QuanLyForm)).EndInit();
            this.panel_chinh.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl ac_thongtin;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_danhmuc;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluent_QuanLyForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_hethongquanly;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_nhanvien;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_khachhang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_dangxuat;
        public System.Windows.Forms.Panel panel_chinh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_taikhoan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_manhinhchinh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_quanlynhaphang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_hoadon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_kiemduyetsanpham;
        private System.Windows.Forms.Panel pn_main;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_banhang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_nhacungcap;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_thongtincanhan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_sanpham;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_baocaothongke;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_quyen;
    }
}