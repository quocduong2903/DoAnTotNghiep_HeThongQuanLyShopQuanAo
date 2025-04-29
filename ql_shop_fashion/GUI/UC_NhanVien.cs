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
    public partial class UC_NhanVien : UserControl
    {
        private nhan_vien_sql_BLL nv_bll;
        private nhom_quyen_sql_BLL quyen_bll;
        private tai_khoan_sql_BLL tk_bll;
        string rolee;
        public UC_NhanVien(string role)
        {
            InitializeComponent();
            rolee = role;
            this.Load += UC_NhanVien_Load;
            GridView gridView = gct_nv.MainView as GridView;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;

            bt_them.ItemClick += Bt_them_ItemClick;
            bt_rs_pass.Click += Bt_rs_pass_Click;
            bt_save.ItemClick += Bt_save_ItemClick;
            bt_xoa.ItemClick += Bt_xoa_ItemClick;
        }

        private void Bt_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Lấy GridView từ MainView
                var gridView = gct_nv.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy ID nhân viên từ dòng được chọn
                var maNhanVien = gridView.GetFocusedRowCellValue("ma_nhan_vien");
                if (maNhanVien == null || !int.TryParse(maNhanVien.ToString(), out int idNhanVien))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Không thể lấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận trước khi xóa
                var confirmResult = DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhân viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi hàm xóa từ BLL
                    nv_bll = new nhan_vien_sql_BLL();
                    bool isDeleted = nv_bll.DeleteNhanVien(idNhanVien);

                    if (isDeleted)
                    {
                        // Thông báo thành công
                        DevExpress.XtraEditors.XtraMessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới lại GridControl
                        LoadGridControl(rolee);
                    }
                    else
                    {
                        // Thông báo lỗi
                        DevExpress.XtraEditors.XtraMessageBox.Show("Xóa nhân viên thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                DevExpress.XtraEditors.XtraMessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Lấy GridView từ MainView
                var gridView = gct_nv.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

                if (gridView == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Không thể lấy thông tin từ bảng nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin từ các điều khiển
                nhan_vien updatedNhanVien = new nhan_vien
                {
                    ma_nhan_vien = int.Parse(gridView.GetFocusedRowCellValue("ma_nhan_vien").ToString()), // Lấy ID từ dòng đang chọn
                    ten_nhan_vien = txt_hoten.Text.Trim(),
                    chuc_vu = cbb_cv.SelectedItem?.ToString() ?? string.Empty,
                    sdt = txt_sdt.Text.Trim(),
                    dia_chi = txt_dc.Text.Trim(),
                    ngay_vao_lam = ngay_vl.Value
                };

                // Gọi hàm sửa thông tin nhân viên từ BLL
                nv_bll = new nhan_vien_sql_BLL();
                bool isUpdated = nv_bll.UpdateNhanVien(updatedNhanVien);

                if (isUpdated)
                {
                    // Thông báo thành công
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Cập nhật thông tin nhân viên thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Làm mới lại GridControl
                    LoadGridControl(rolee);
                }
                else
                {
                    // Thông báo thất bại
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Cập nhật thông tin nhân viên thất bại. Vui lòng thử lại.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"Đã xảy ra lỗi: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void Bt_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            add_NV them_nv = new add_NV(Properties.Settings.Default.name_role);
            them_nv.StartPosition = FormStartPosition.CenterScreen;
            them_nv.Show();

            them_nv.NhanVienAdded += Them_nv_NhanVienAdded;
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Họ tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_hoten.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_sdt.Text) || !txt_sdt.Text.All(char.IsDigit))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập chỉ chứa số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_sdt.Focus();
                return false;
            }

            if (cbb_cv.SelectedIndex == -1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn chức vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbb_cv.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_dc.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_dc.Focus();
                return false;
            }

            if (ngay_vl.Value.Date > DateTime.Now)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ngày vào làm không hợp lệ. Vui lòng chọn ngày nhỏ hơn hoặc bằng ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ngay_vl.Focus();
                return false;
            }

            return true;
        }


        private void Bt_rs_pass_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            var result = DevExpress.XtraEditors.XtraMessageBox.Show(
                "Bạn có muốn khởi tạo lại mật khẩu mới không? Mật khẩu sẽ được đặt mặc định là tên đăng nhập.",
                "Xác nhận khởi tạo lại mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Kiểm tra nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                try
                {
                    tk_bll = new tai_khoan_sql_BLL();

                    // Gọi hàm đổi mật khẩu (mật khẩu mặc định là tên đăng nhập)
                    bool isPasswordReset = tk_bll.ChangePassword(txt_tk.Text, txt_tk.Text); // `txt_tk.Tag` chứa ID tài khoản

                    if (isPasswordReset)
                    {
                        var gridView = gct_nv.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                        var taiKhoanId = gridView.GetRowCellValue(gridView.FocusedRowHandle, "tai_khoan_id");
                        if (taiKhoanId != null && int.TryParse(taiKhoanId.ToString(), out int idTaiKhoan))
                        {
                            // Gọi hàm load_tk để tải lại thông tin tài khoản
                            load_tk(idTaiKhoan);

                            // Hiển thị thông báo thành công
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                "Mật khẩu đã được khởi tạo lại thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Khởi tạo mật khẩu thất bại. Vui lòng thử lại.",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        $"Đã xảy ra lỗi: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }



        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Lấy GridView từ sender
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            // Kiểm tra nếu GridView không null và có dòng được chọn
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                // Lấy dữ liệu của dòng được chọn
                var hoten = gridView.GetRowCellValue(gridView.FocusedRowHandle, "ten_nhan_vien")?.ToString();
                var diachi = gridView.GetRowCellValue(gridView.FocusedRowHandle, "dia_chi")?.ToString();
                var sodienthoai = gridView.GetRowCellValue(gridView.FocusedRowHandle, "sdt")?.ToString();
                var ngayvaolam = gridView.GetRowCellValue(gridView.FocusedRowHandle, "ngay_vao_lam");
                var chucvu = gridView.GetRowCellValue(gridView.FocusedRowHandle, "chuc_vu")?.ToString();
                var taiKhoanId = gridView.GetRowCellValue(gridView.FocusedRowHandle, "tai_khoan_id");

                // Kiểm tra nếu tai_khoan_id hợp lệ và gọi hàm load_tk
                if (taiKhoanId != null && int.TryParse(taiKhoanId.ToString(), out int taiKhoan))
                {
                    load_tk(taiKhoan);
                }

                // Gán dữ liệu vào các điều khiển trên form
                txt_hoten.Text = hoten ?? string.Empty;
                txt_dc.Text = diachi ?? string.Empty;
                txt_sdt.Text = sodienthoai ?? string.Empty;

                // Kiểm tra nếu giá trị ngày vào làm không null và gán vào DateTimePicker
                if (ngayvaolam != null && DateTime.TryParse(ngayvaolam.ToString(), out DateTime date))
                {
                    ngay_vl.Value = date;
                }
                else
                {
                    ngay_vl.Value = DateTime.Now; // Giá trị mặc định nếu ngày vào làm không hợp lệ
                }

                // Gán giá trị vào ComboBox chức vụ (nếu tồn tại)
                if (!string.IsNullOrEmpty(chucvu) && cbb_cv.Items.Contains(chucvu))
                {
                    cbb_cv.SelectedItem = chucvu;
                }
                else
                {
                    cbb_cv.SelectedIndex = -1; // Không chọn gì nếu không khớp
                }
            }
        }
        void load_tk(int tk)
        {
            tk_bll = new tai_khoan_sql_BLL();
            txt_tk.Enabled = false;
            txt_mk.Enabled = false;
            tai_khoan tkk = tk_bll.GetTaiKhoanByMaID(tk);
            txt_tk.Text = tkk.ten_dang_nhap;
            txt_mk.Text = "*********";

        }


        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            load_admin_qli(rolee);
            ResetForm();
        }

        private void Them_nv_NhanVienAdded(object sender, EventArgs e)
        {

            LoadGridControl(rolee);

        }

        void load_admin_qli(string role)
        {
            cbb_cv.DropDownStyle = ComboBoxStyle.DropDownList;



            LoadGridControl(role);

            if (role.Equals("Admin"))
            {
                cbb_cv.Items.Clear();
                cbb_cv.Items.Add("Admin");
                cbb_cv.Items.Add("Quản lí");
                cbb_cv.Items.Add("Nhân viên");
                cbb_cv.Items.Add("Nhân viên kho");
                cbb_cv.Items.Add("Nhân viên bán hàng");
            }
            else
            {
                cbb_cv.Items.Clear();
                cbb_cv.Items.Add("Nhân viên kho");
                cbb_cv.Items.Add("Nhân viên");
                cbb_cv.Items.Add("Nhân viên bán hàng");
            }

        }
        private void LoadGridControl(string role)
        {
            nv_bll = new nhan_vien_sql_BLL();

            // Gán dữ liệu trực tiếp từ BLL vào GridControl
            gct_nv.DataSource = nv_bll.GetNhanVienTheoQuyen(role);

            // Tùy chỉnh GridView (phần tử con của GridControl)
            var gridView = gct_nv.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView != null)
            {
                // Hiển thị lại toàn bộ cột, sau đó tùy chỉnh ẩn cột
                gridView.PopulateColumns();

                // Ẩn các cột không cần thiết
                gridView.Columns["tai_khoan_id"].Visible = false; // Ẩn cột tài khoản ID
                gridView.Columns["dia_chi"].Visible = false; // Ẩn cột địa chỉ
                gridView.Columns["created_at"].Visible = false; // Ẩn cột ngày tạo
                gridView.Columns["updated_at"].Visible = false; // Ẩn cột ngày cập nhật
                gridView.Columns["tai_khoan"].Visible = false; // Ẩn cột ngày cập nhật
                gridView.Columns["chuc_vu"].Visible = false;
                gridView.Columns["tai_khoan1"].Visible = false;
                // Tùy chỉnh tiêu đề cột (nếu cần)
                gridView.Columns["ma_nhan_vien"].Caption = "Mã Nhân Viên";
                gridView.Columns["ten_nhan_vien"].Caption = "Tên Nhân Viên";
                gridView.Columns["sdt"].Caption = "Số Điện Thoại";
                gridView.Columns["ngay_vao_lam"].Caption = "Ngày Vào Làm";

                // Định dạng ngày tháng cho cột "Ngày Vào Làm"
                gridView.Columns["ngay_vao_lam"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView.Columns["ngay_vao_lam"].DisplayFormat.FormatString = "dd/MM/yyyy";
                gridView.OptionsDetail.EnableMasterViewMode = false;
                // Cấu hình không chỉnh sửa và chế độ chọn cả dòng
                gridView.OptionsBehavior.Editable = false; // Không cho chỉnh sửa dữ liệu
                gridView.OptionsSelection.EnableAppearanceFocusedCell = false; // Tắt chọn ô
                gridView.OptionsSelection.MultiSelect = false; // Tắt chế độ chọn nhiều dòng
                gridView.GroupPanelText = "DANH SÁCH NHÂN VIÊN";
                gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus; // Chọn cả dòng
                gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect; // Chọn cả dòng

                gridView.BestFitColumns(); // Tự động căn chỉnh kích thước cột
            }
        }
        private void ResetForm()
        {
            // Xóa tất cả dòng chọn
            var gridView = gct_nv.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.ClearSelection();
            }

            // Xóa dữ liệu trên màn hình
            txt_tk.Text = string.Empty;
            txt_mk.Text = string.Empty;
            txt_hoten.Text = string.Empty;
            txt_dc.Text = string.Empty;
            txt_sdt.Text = string.Empty;
            ngay_vl.Value = DateTime.Now;
            cbb_cv.SelectedIndex = -1;
        }


    }
}
