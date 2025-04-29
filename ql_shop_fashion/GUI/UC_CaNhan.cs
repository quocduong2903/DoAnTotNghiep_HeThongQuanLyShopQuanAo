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

namespace GUI
{
    public partial class UC_CaNhan : UserControl
    {
        private nhan_vien_sql_BLL nv_bll;
        private tai_khoan_sql_BLL tk_bll;
        private int manv;

        public UC_CaNhan(int manv)
        {
            this.manv = manv;
            InitializeComponent();
            this.Load += UC_CaNhan_Load;
        }

        private void UC_CaNhan_Load(object sender, EventArgs e)
        {
            loadtt(manv);
            bt_rs_pass.Click += Bt_rs_pass_Click;
        }

        private void Bt_rs_pass_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận bằng DevExpress MessageBox
                var result = DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Bạn có chắc chắn muốn đổi mật khẩu không?",
                    "Xác nhận đổi mật khẩu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Nếu người dùng chọn "Yes"
                if (result == DialogResult.Yes)
                {
                    // Hiển thị form nhập mật khẩu mới
                    using (var passwordForm = new Form())
                    {
                        passwordForm.Text = "Đổi mật khẩu";
                        passwordForm.StartPosition = FormStartPosition.CenterParent;
                        passwordForm.Width = 350;
                        passwordForm.Height = 200;

                        // Label "Mật khẩu mới"
                        var lblNewPassword = new Label() { Text = "Mật khẩu mới:", Left = 20, Top = 20, Width = 100 };
                        var txtNewPassword = new TextBox() { Left = 130, Top = 20, Width = 180, PasswordChar = '*' };

                        // Label "Xác nhận mật khẩu"
                        var lblConfirmPassword = new Label() { Text = "Xác nhận mật khẩu:", Left = 20, Top = 60, Width = 100 };
                        var txtConfirmPassword = new TextBox() { Left = 130, Top = 60, Width = 180, PasswordChar = '*' };

                        // Nút xác nhận
                        var btnOK = new Button() { Text = "Xác nhận", Left = 80, Width = 80, Top = 110, DialogResult = DialogResult.OK };

                        // Nút hủy
                        var btnCancel = new Button() { Text = "Hủy", Left = 180, Width = 80, Top = 110, DialogResult = DialogResult.Cancel };

                        // Thêm các điều khiển vào form
                        passwordForm.Controls.Add(lblNewPassword);
                        passwordForm.Controls.Add(txtNewPassword);
                        passwordForm.Controls.Add(lblConfirmPassword);
                        passwordForm.Controls.Add(txtConfirmPassword);
                        passwordForm.Controls.Add(btnOK);
                        passwordForm.Controls.Add(btnCancel);

                        // Hiển thị form nhập mật khẩu
                        if (passwordForm.ShowDialog() == DialogResult.OK)
                        {
                            string newPassword = txtNewPassword.Text.Trim();
                            string confirmPassword = txtConfirmPassword.Text.Trim();

                            // Kiểm tra tính hợp lệ của mật khẩu
                            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (newPassword != confirmPassword)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Đổi mật khẩu qua BLL
                            tk_bll = new tai_khoan_sql_BLL();
                            bool isPasswordChanged = tk_bll.ChangePassword(txt_tk.Text, newPassword);

                            if (isPasswordChanged)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadtt(manv);
                                return;
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        void loadtt(int manv)
        {
            nv_bll = new nhan_vien_sql_BLL();
            nhan_vien a = nv_bll.GetNhanVienByMaNV(manv);
            txt_hoten.Text = a.ten_nhan_vien;
            txt_dc.Text = a.dia_chi;
            txt_cv.Text = a.chuc_vu;
            txt_sdt.Text = a.sdt;
            ngay_vl.Value = a.ngay_vao_lam.Value;
            tk_bll = new tai_khoan_sql_BLL();
           tai_khoan tk =  tk_bll.GetTaiKhoanByMaID(a.tai_khoan_id.Value);
            txt_tk.Text = tk.ten_dang_nhap;
            txt_mk.Text = "*******";
            ngay_vl.Enabled = false;
            txt_hoten.ReadOnly = true;
            txt_dc.ReadOnly = true;
            txt_cv.ReadOnly = true;
            txt_sdt.ReadOnly = true;
            txt_tk.ReadOnly = true;
            txt_mk.ReadOnly = true;
        }
    }
}
