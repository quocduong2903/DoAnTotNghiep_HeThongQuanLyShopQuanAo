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
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace GUI
{
    public partial class UC_TaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        private string role;
        private nhom_quyen_sql_BLL quyen_bll;
        private tai_khoan_sql_BLL tk_bll;

        public UC_TaiKhoan(string rolee)
        {
            InitializeComponent();
            role = rolee;
            this.Load += UC_TaiKhoan_Load;
            GridView gridView = gct_tk.MainView as GridView;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            bt_rs_pass.ItemClick += Bt_rs_pass_ItemClick;
            bt_save.ItemClick += Bt_save_ItemClick;
            bt_load.ItemClick += Bt_load_ItemClick;
        }

        private void Bt_load_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetForm();
        }

        private void Bt_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Lấy GridView từ gct_tk
                var gridView = gct_tk.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Vui lòng chọn tài khoản để lưu.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Lấy ID tài khoản từ dòng được chọn
                var idValue = gridView.GetFocusedRowCellValue("id");
                if (idValue == null || !int.TryParse(idValue.ToString(), out int accountId))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Không thể lấy thông tin ID tài khoản.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // Lấy tên quyền từ ComboBox
                string roleName = cbb_quyen.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(roleName))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Vui lòng chọn quyền hợp lệ trước khi lưu.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Gọi hàm cập nhật quyền
                tk_bll = new tai_khoan_sql_BLL();
                bool isUpdated = tk_bll.UpdateRole(accountId, roleName);

                if (isUpdated)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Cập nhật quyền thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ResetForm();
                    // Làm mới dữ liệu trong GridControl
                    load_dgv(role);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Cập nhật quyền thất bại. Vui lòng kiểm tra lại.",
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

        private void Bt_rs_pass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                        load_dgv(role);
                        ResetForm();

                        // Hiển thị thông báo thành công
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Mật khẩu đã được khởi tạo lại thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

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
            try
            {
                // Lấy GridView từ sender
                var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gridView == null || gridView.FocusedRowHandle < 0)
                {
                    // Xóa dữ liệu nếu không có dòng nào được chọn
                    ResetForm();
                    return;
                }

                // Lấy dữ liệu của dòng được chọn
                txt_tk.Text = gridView.GetFocusedRowCellValue("ten_dang_nhap")?.ToString() ?? string.Empty;
                txt_mk.Text = "**********";

                // Kiểm tra trạng thái hoạt động
                var hoatDongValue = gridView.GetFocusedRowCellValue("hoat_dong");
                int id = 0;
                check_hd.Checked = hoatDongValue != null && bool.TryParse(hoatDongValue.ToString(), out bool hoatDong) && hoatDong;
                var idValue = gridView.GetFocusedRowCellValue("tai_khoan_id");

                if (idValue != null && int.TryParse(idValue.ToString(), out id))
                {
                    tk_bll = new tai_khoan_sql_BLL();
                    cbb_quyen.SelectedItem = tk_bll.GetRoleNameByAccountId(id);
                }
                // Gán giá trị vào ComboBox quyền

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"Đã xảy ra lỗi khi xử lý dòng được chọn: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void ResetForm()
        {
            // Xóa nội dung trong các textbox
            txt_tk.Text = string.Empty;
            txt_mk.Text = string.Empty;
            txt_tk.Enabled = false;
            txt_mk.Enabled = false;

            // Bỏ chọn checkbox
            check_hd.Checked = false;

            // Đặt lại ComboBox về trạng thái không có mục nào được chọn
            cbb_quyen.SelectedIndex = -1;
        }


        void load_cbb(string role)
        {
            cbb_quyen.Items.Clear();
            quyen_bll = new nhom_quyen_sql_BLL();
            cbb_quyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_quyen.DataSource = quyen_bll.load_ccb(role);
        }
        void load_dgv(string role)
        {
            try
            {
                // Lấy danh sách tài khoản theo vai trò
                tai_khoan_sql_BLL tk_bll = new tai_khoan_sql_BLL();
                var taiKhoanList = tk_bll.GetTaiKhoanByRole(role);

                // Gán dữ liệu vào GridControl
                gct_tk.DataSource = taiKhoanList;

                // Tùy chỉnh GridView (MainView của GridControl)
                var gridView = gct_tk.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gridView != null)
                {
                    gridView.PopulateColumns(); // Hiển thị các cột tự động
                    gridView.OptionsView.ShowGroupPanel = false; // Tắt GroupPanel nếu không cần

                    // Tắt dấu "+" (Master-Detail mode)
                    gridView.OptionsDetail.EnableMasterViewMode = false;

                    // Tùy chỉnh tiêu đề cột (nếu cần)
                    gridView.Columns["tai_khoan_id"].Caption = "ID";
                    gridView.Columns["ten_dang_nhap"].Caption = "Tên Đăng Nhập";
                    gridView.Columns["hoat_dong"].Caption = "Hoạt Động";
                    gridView.Columns["mat_khau_hash"].Visible = false;
                    // Ẩn các cột không cần thiết
                    gridView.Columns["is_oauth"].Visible = false;
                    gridView.Columns["created_at"].Visible = false;
                    gridView.Columns["updated_at"].Visible = false;
                    gridView.OptionsBehavior.Editable = false;

                    // Căn chỉnh cột
                    gridView.BestFitColumns();
                    gridView.ClearSelection();
                    gridView.FocusedRowHandle = GridControl.InvalidRowHandle;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    $"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }



        private void UC_TaiKhoan_Load(object sender, EventArgs e)
        {
            load_cbb(role);
            load_dgv(role);
            ResetForm();
        }
    }
}
