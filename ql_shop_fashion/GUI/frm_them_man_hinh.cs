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
    public partial class frm_them_man_hinh : Form
    {
        public event EventHandler ThemThanhCong;
        private nhom_quyen_man_hinh_sql_BLL quyen_bll;
        public frm_them_man_hinh()
        {
            InitializeComponent();
            bt_them.Click += Bt_them_Click;
            this.FormClosing += Frm_them_man_hinh_FormClosing;

        }

        private void Frm_them_man_hinh_FormClosing(object sender, FormClosingEventArgs e)
        {

            ThemThanhCong?.Invoke(this, EventArgs.Empty);
        }

        private void Bt_them_Click(object sender, EventArgs e)
        {
            quyen_bll = new nhom_quyen_man_hinh_sql_BLL();
            if (kiemTra())
            {
                // Tạo đối tượng màn hình
                man_hinh a = new man_hinh
                {
                    id_man_hinh = int.Parse(txt_ma_mh.Text),
                    ten_man_hinh = txt_name_mh.Text
                };

                // Gọi BLL để thêm màn hình
                int check = quyen_bll.them_manHinh(a); // Phương thức `them_manHinh` trả về `int`

                // Kiểm tra kết quả trả về
                if (check == 1)
                {
                   
                    // Thành công
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm màn hình thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    this.Close();
                }
                else if (check == 0)
                {
                    
                    DevExpress.XtraEditors.XtraMessageBox.Show("Màn hình đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (check == -1)
                {
                    // Lỗi khi thêm
                    DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi khi thêm màn hình! Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return; // Nếu không hợp lệ, thoát khỏi sự kiện
            }
        }

        private bool kiemTra()
        {
            // Kiểm tra Mã màn hình
            if (string.IsNullOrWhiteSpace(txt_ma_mh.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập Mã màn hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ma_mh.Focus();
                return false; // Không hợp lệ
            }

            // Kiểm tra Tên màn hình
            if (string.IsNullOrWhiteSpace(txt_name_mh.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập Tên màn hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_name_mh.Focus();
                return false; // Không hợp lệ
            }

            // Kiểm tra định dạng (nếu cần thiết, ví dụ kiểm tra số nguyên cho Mã màn hình)
            if (!int.TryParse(txt_ma_mh.Text, out _))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Mã màn hình phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ma_mh.Focus();
                return false; // Không hợp lệ
            }

            // Nếu tất cả hợp lệ
            return true;
        }

    }
}
