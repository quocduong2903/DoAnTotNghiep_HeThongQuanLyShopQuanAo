using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DTO;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class add_NV : Form
    {
        private string role;
        private nhom_quyen_sql_BLL quyen_bll;
        private nhan_vien_sql_BLL nv_bll;

        // Sự kiện để thông báo khi nhân viên được thêm
        public event EventHandler NhanVienAdded;

        public add_NV(string name_role)
        {
            InitializeComponent();
            role = name_role;
            this.Load += Add_NV_Load;
            bt_add.Click += Bt_add_Click;
        }

        private void Bt_add_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (KiemTraDuLieuDauVao())
            {
                // Khởi tạo đối tượng BLL
                nv_bll = new nhan_vien_sql_BLL();

                // Tạo đối tượng nhân viên với thông tin từ các trường trên form
                nhan_vien nv = new nhan_vien
                {
                    ten_nhan_vien = txt_hoten.Text.Trim(),
                    chuc_vu = cbb_cv.SelectedItem.ToString(),
                    sdt = txt_sdt.Text.Trim(),
                    dia_chi = txt_dc.Text.Trim(),
                    ngay_vao_lam = ngay_vl.Value
                };

                // Lấy tên nhóm quyền từ ComboBox quyền
                string tenNhomQuyen = cbb_quyen.SelectedItem.ToString();

                // Gọi hàm thêm nhân viên và tài khoản từ lớp BLL
                bool isAdded = nv_bll.add_nv_tk_user(nv, tenNhomQuyen);

                // Kiểm tra kết quả thêm và hiển thị thông báo
                if (isAdded)
                {
                    XtraMessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Phát sự kiện thông báo thành công
                    NhanVienAdded?.Invoke(this, EventArgs.Empty);

                    
                    ClearFields();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Thêm nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu dữ liệu đầu vào không hợp lệ, dừng lại và không tiếp tục
                return;
            }
        }

        // Hàm làm sạch các trường nhập liệu sau khi thêm thành công
        private void ClearFields()
        {
            txt_hoten.Clear();
            txt_sdt.Clear();
            txt_dc.Clear();
            cbb_cv.SelectedIndex = -1;
            cbb_quyen.SelectedIndex = -1;
            ngay_vl.Value = DateTime.Now;
        }

        private bool KiemTraDuLieuDauVao()
        {
            // Kiểm tra tên họ không để trống
            if (string.IsNullOrWhiteSpace(txt_hoten.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_hoten.Focus();
                return false;
            }

            // Kiểm tra chức vụ đã được chọn
            if (cbb_cv.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn chức vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_cv.Focus();
                return false;
            }

            // Kiểm tra số điện thoại không để trống và chỉ chứa số
            if (string.IsNullOrWhiteSpace(txt_sdt.Text) || !txt_sdt.Text.All(char.IsDigit))
            {
                XtraMessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (chỉ chứa số).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sdt.Focus();
                return false;
            }

            // Kiểm tra địa chỉ không để trống
            if (string.IsNullOrWhiteSpace(txt_dc.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập địa chỉ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dc.Focus();
                return false;
            }

            // Kiểm tra ngày vào làm đã được chọn
            if (ngay_vl.Value == null || ngay_vl.Value.Date > DateTime.Now)
            {
                XtraMessageBox.Show("Vui lòng chọn ngày vào làm hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ngay_vl.Focus();
                return false;
            }

            // Kiểm tra quyền đã được chọn
            if (cbb_quyen.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Vui lòng chọn quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_quyen.Focus();
                return false;
            }

            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }

        private void Add_NV_Load(object sender, EventArgs e)
        {
            load_cbb(role);
            load_cbb_quyen(role);
        }

        void load_cbb_quyen(string namerole)
        {
            quyen_bll = new nhom_quyen_sql_BLL();
            cbb_quyen.Items.Clear();
            cbb_quyen.DataSource = quyen_bll.load_ccb(namerole);
            cbb_quyen.SelectedIndex = -1;
        }

        void load_cbb(string name)
        {
            // Đặt DropDownStyle để chỉ cho phép chọn từ danh sách
            cbb_cv.DropDownStyle = ComboBoxStyle.DropDownList;

            if (name.Equals("Admin"))
            {
                cbb_cv.Items.Clear();
                cbb_cv.Items.Add("Quản lý");
                cbb_cv.Items.Add("Nhân viên");
                cbb_cv.SelectedIndex = -1; // Không chọn giá trị mặc định
            }
            else
            {
                cbb_cv.Items.Clear();
                cbb_cv.Items.Add("Nhân viên");
                cbb_cv.SelectedIndex = 0; // Mặc định chọn "Nhân viên"
            }
        }
    }
}
