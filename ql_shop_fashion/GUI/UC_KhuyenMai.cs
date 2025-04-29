using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class UC_KhuyenMai : DevExpress.XtraEditors.XtraUserControl
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        khuyen_mai_sql_BLL km_bll = new khuyen_mai_sql_BLL();
      

        public UC_KhuyenMai()
        {
            InitializeComponent();
            this.Load += UC_KhuyenMai_Load;
            dgvDanhSach.FocusedRowChanged += DgvDanhSach_FocusedRowChanged;
            btnThem.Click += BtnThem_Click;
            GridView gv_km= dgvKhuyenMai.MainView as GridView;
          
            btnXoa.Click += BtnXoa_Click;
            btnSua.Click += BtnSua_Click;
            btnLoad.Click += BtnLoad_Click;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            load();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            khuyen_mai km1 = layThongTin();
            km1.ma_khuyen_mai = int.Parse(txtMaKM.Text);
    
            if (km1 != null)
            {

                if (km_bll.suaKhuyenMai(km1))
                {
                    XtraMessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật khuyến mãi thất bại! Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKM.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn khuyến mãi cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int ma = int.Parse(txtMaKM.Text);
                    if (km_bll.xoaKhuyenMai(ma))
                    {
                        // Hiển thị thông báo thành công
                        XtraMessageBox.Show("Xóa khuyến mãi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load(); 
                    }
                    else
                    {
                        // Hiển thị thông báo thất bại
                        XtraMessageBox.Show("Xóa khuyến mãi thất bại. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý trường hợp lỗi khi chuyển đổi mã khuyến mãi sang số
                    XtraMessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

     
        private khuyen_mai layThongTin()
        {

            if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTri.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTriHoaDonToiThieu.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuongToiDa.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuongDaDung.Text) ||
                string.IsNullOrWhiteSpace(txtGhiChu.Text) ||
                string.IsNullOrWhiteSpace(txtNgayBatDau.Text) ||
                string.IsNullOrWhiteSpace(txtNgayKetThuc.Text))
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null; 
            }
            if (!km_bll.kiemTraTrungCode(txtCode.Text))
            {
                XtraMessageBox.Show("Trùng mã code! Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (!decimal.TryParse(txtGiaTri.Text, out decimal giaTri) ||
                !decimal.TryParse(txtGiaTriHoaDonToiThieu.Text, out decimal giaTriHoaDonToiThieu) ||
                !int.TryParse(txtSoLuongToiDa.Text, out int soLuongToiDa) 
               )
            {
                XtraMessageBox.Show("Dữ liệu nhập không hợp lệ! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (!DateTime.TryParse(txtNgayBatDau.Text, out DateTime ngayBatDau) ||
                !DateTime.TryParse(txtNgayKetThuc.Text, out DateTime ngayKetThuc))
            {
                XtraMessageBox.Show("Thời gian không hợp lệ! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (ngayBatDau > ngayKetThuc)
            {
                XtraMessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


            khuyen_mai km = new khuyen_mai
            {
                ma_nhan_vien = 1,
                code = txtCode.Text,
                gia_tri = giaTri,
                gia_tri_hoa_don_toi_thieu = giaTriHoaDonToiThieu,
                so_luong_toi_da = soLuongToiDa,
                so_luong_da_dung = int.Parse(txtSoLuongDaDung.Text),
                ghi_chu = txtGhiChu.Text,
                thoi_gian_bat_dau = ngayBatDau,
                thoi_gian_ket_thuc = ngayKetThuc
            };
            return km;
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            khuyen_mai km = layThongTin();
            if(km!=null)
            {

                
                // Attempt to insert the new record
                if (km_bll.ThenKhuyenMai(km))
                {
                    XtraMessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                else
                {
                    XtraMessageBox.Show("Thêm khuyến mãi thất bại! Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
          
        }

        private void DgvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = dgvKhuyenMai.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                txtMaKM.Text = Convert.ToString(gridView.GetFocusedRowCellValue("ma_khuyen_mai"));
                txtCode.Text = Convert.ToString(gridView.GetFocusedRowCellValue("code"));
                txtGhiChu.Text = Convert.ToString(gridView.GetFocusedRowCellValue("ghi_chu"));
                txtGiaTriHoaDonToiThieu.Text = Convert.ToString(gridView.GetFocusedRowCellValue("gia_tri_hoa_don_toi_thieu"));
                txtNgayBatDau.Text = Convert.ToString(gridView.GetFocusedRowCellValue("thoi_gian_bat_dau"));
                txtNgayKetThuc.Text = Convert.ToString(gridView.GetFocusedRowCellValue("thoi_gian_ket_thuc"));
                txtGiaTri.Text = Convert.ToString(gridView.GetFocusedRowCellValue("gia_tri"));
                txtSoLuongDaDung.Text = Convert.ToString(gridView.GetFocusedRowCellValue("so_luong_da_dung"));
                txtSoLuongToiDa.Text = Convert.ToString(gridView.GetFocusedRowCellValue("so_luong_toi_da"));
                txtTrinhTrang.Text = Convert.ToString(gridView.GetFocusedRowCellValue("tinh_trang"));
                txtTenNguoiTao.Text = Convert.ToString(gridView.GetFocusedRowCellValue("ten_nhan_vien"));

            }
        }

        public void load()
        {
            
            dgvKhuyenMai.DataSource = km_bll.GetKhuyenMaiCoNhanVien();
            txtMaKM.ReadOnly = true;        
            txtTrinhTrang.ReadOnly = true;
            txtTenNguoiTao.ReadOnly = true;
            dgvDanhSach.OptionsBehavior.Editable = false;
            txtMaKM.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtGiaTri.Text = string.Empty;
            txtGiaTriHoaDonToiThieu.Text = string.Empty;
            txtSoLuongToiDa.Text = string.Empty;
            txtSoLuongDaDung.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            txtNgayBatDau.Text = string.Empty;
            txtNgayKetThuc.Text = string.Empty;
            txtTrinhTrang.Text = string.Empty;
        }
        private void UC_KhuyenMai_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
