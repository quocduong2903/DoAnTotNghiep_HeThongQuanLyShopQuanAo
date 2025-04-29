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
using DevExpress.XtraGrid.Views.Grid;

namespace GUI
{
    public partial class UC_KhachHang : DevExpress.XtraEditors.XtraUserControl
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        khach_hang_sql_BLL kh_bll = new khach_hang_sql_BLL();
        public UC_KhachHang()
        {
            InitializeComponent();
            this.Load += UC_KhachHang_Load;
            dgvDanhSach.FocusedRowChanged += DgvDanhSach_FocusedRowChanged;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
          
            btnLoad.Click += BtnLoad_Click;
            txtSDT.KeyPress += TxtSDT_KeyPress;
            txtSDT.Leave += TxtSDT_Leave;
        }

        private void TxtSDT_Leave(object sender, EventArgs e)
        {
            if (!KiemTraSoDienThoai(txtSDT.Text))
            {
               dxErrorProvider1.SetError(txtSDT, "Số điện thoại chưa hợp lệ.");
            }
            else
            {
                dxErrorProvider1.SetError(txtSDT, null); // Xóa lỗi nếu hợp lệ
            }
        }

        private void TxtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
                return;
            }

            // Giới hạn độ dài chuỗi <= 10 ký tự
            if (txtSDT.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
          
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            load();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int ma = int.Parse(txtMaKH.Text);
                    if (kh_bll.xoaKhachHang(ma))
                    {
                        // Hiển thị thông báo thành công
                        XtraMessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                    }
                    else
                    {
                        // Hiển thị thông báo thất bại
                        XtraMessageBox.Show("Xóa khách hàng thất bại. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý trường hợp lỗi khi chuyển đổi mã khuyến mãi sang số
                    XtraMessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            khach_hang kh = layThongTin();
            kh.ma_khach_hang = int.Parse(txtMaKH.Text);

            if (kh != null)
            {

                if (kh_bll.suaKhachHang(kh))
                {
                    XtraMessageBox.Show("Cập nhật khách hàng hành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật khách hàng thất bại! Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            khach_hang kh = layThongTin();
            if (kh != null)
            {

               
                // Attempt to insert the new record
                if (kh_bll.ThemKhachHang(kh))
                {
                    XtraMessageBox.Show("Thêm khách hàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
                else
                {
                    XtraMessageBox.Show("Thêm khách hàng thất bại! Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool KiemTraSoDienThoai(string soDienThoai)
        {
            // Kiểm tra độ dài chuỗi từ 1 đến 10 ký tự
            if (soDienThoai.Length == 0 || soDienThoai.Length > 10)
            {
                return false;
            }

            // Kiểm tra từng ký tự phải là số
            foreach (char c in soDienThoai)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true; // Dữ liệu hợp lệ
        }

        private khach_hang layThongTin()
        {

            if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) )
            {
                XtraMessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }


            int? maTK = null;

            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                maTK = null;
            }

            if (int.TryParse(txtTaiKhoan.Text, out int result))
            {
                maTK = result;
            }


            khach_hang kh = new khach_hang
            {
                ten_khach_hang = txtTenKH.Text,
                dia_chi = txtDiaChi.Text,
                dien_thoai = txtSDT.Text,
                tai_khoan_id = maTK,
                diem_thuong = 0,
                diem_da_doi = 0,

        };
            return kh;
        }
        private void DgvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = dgvKhachHang.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                txtMaKH.Text = Convert.ToString(gridView.GetFocusedRowCellValue("ma_khach_hang"));
                txtTenKH.Text = Convert.ToString(gridView.GetFocusedRowCellValue("ten_khach_hang"));
                txtDiaChi.Text = Convert.ToString(gridView.GetFocusedRowCellValue("dia_chi"));
                txtSDT.Text = Convert.ToString(gridView.GetFocusedRowCellValue("dien_thoai"));
                txtDiemThuong.Text = Convert.ToString(gridView.GetFocusedRowCellValue("diem_thuong"));
                txtDiemDaDoi.Text = Convert.ToString(gridView.GetFocusedRowCellValue("diem_da_doi"));
                txtTaiKhoan.Text = Convert.ToString(gridView.GetFocusedRowCellValue("tai_khoan_id"));


            }
        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            dgvKhachHang.DataSource = kh_bll.getDanhSanhKHFull();
            txtMaKH.ReadOnly = true;
            txtDiemDaDoi.ReadOnly = true;
            txtDiemThuong.ReadOnly = true;
            dgvDanhSach.OptionsBehavior.Editable = false;
            txtMaKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtDiemThuong.Text = string.Empty;
            txtDiemDaDoi.Text = string.Empty;
            txtTaiKhoan.Text = string.Empty;
           
        }


    }
}
