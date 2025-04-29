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
using DTO;

namespace GUI
{
    public partial class them_ncc : Form
    {
        private nha_cung_cap_sql_BLL ncc_bll;
        public event EventHandler SupplierAdded;
        public them_ncc()
        {
            InitializeComponent();
            this.FormClosed += Them_ncc_FormClosed;
            btthem.Click += Btthem_Click;
            
        }

        private void Btthem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (!ValidateInput())
            {
                return; // Nếu dữ liệu không hợp lệ, dừng lại
            }

            // Tạo đối tượng nha_cung_cap và gán giá trị từ các trường nhập liệu
            ncc_bll = new nha_cung_cap_sql_BLL();
            nha_cung_cap a = new nha_cung_cap
            {
                ten_nha_cung_cap = ten_ncc.Text,
                dia_chi = dc.Text,
                dien_thoai = dt.Text
            };

            // Thực hiện thêm nhà cung cấp
            if (themncc(a, ncc_bll))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Cập nhật lại danh sách nhà cung cấp

                // Xóa các ô nhập liệu sau khi thêm thành công
                ten_ncc.Text = "";
                dc.Text = "";
                dt.Text = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Them_ncc_FormClosed(object sender, FormClosedEventArgs e)
        {
            SupplierAdded?.Invoke(this, EventArgs.Empty);
        }


        private bool ValidateInput()
        {
            // Kiểm tra trường Tên Nhà Cung Cấp
            if (string.IsNullOrWhiteSpace(ten_ncc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ten_ncc.Focus();
                return false;
            }

            // Kiểm tra trường Địa Chỉ
            if (string.IsNullOrWhiteSpace(dc.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dc.Focus();
                return false;
            }

            // Kiểm tra trường Số Điện Thoại
            if (string.IsNullOrWhiteSpace(dt.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt.Focus();
                return false;
            }

            // Kiểm tra định dạng số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(dt.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt.Focus();
                return false;
            }

            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }

        bool themncc(nha_cung_cap ncc, nha_cung_cap_sql_BLL nc)
        {
            return nc.AddNewNcc(ncc);
        }
    }
}
