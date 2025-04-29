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
    public partial class UC_checkSP : UserControl
    {
        private san_pham_sql_BLL sp;
        public UC_checkSP()
        {
            InitializeComponent();
            txt_tk.Enter += Txt_tk_Enter;
            txt_tk.Leave += Txt_tk_Leave;
            txt_tk.Text = "Nhập mã hoặc tên sản phẩm...";
            txt_tk.ForeColor = Color.Gray;
            comboBox1.SelectedIndex = 0;
            this.Load += UC_checkSP_Load;
            comboBox1.SelectedIndexChanged += Cbb_tk_SelectedIndexChanged;
            txt_tk.TextChanged += Txt_tk_TextChanged;
            dgv_sp.CellContentClick += Dgv_sp_CellContentClick;
            dgv_sp_add.CellContentClick += Dgv_sp_add_CellContentClick;
            bt_xuatfiles.Click += Bt_xuatfiles_Click;
            bt_load.Click += Bt_load_Click;
        }

        private void Bt_load_Click(object sender, EventArgs e)
        {
            dgv_sp_add.Rows.Clear();
        }

        private void Bt_xuatfiles_Click(object sender, EventArgs e)
        {
            // Tạo SaveFileDialog để người dùng chọn nơi lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = "ds_sp_nhap.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Tạo workbook mới
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            // Tạo worksheet
                            var worksheet = workbook.Worksheets.Add("Sản phẩm");

                            // Thêm tiêu đề chính
                            var titleCell = worksheet.Cell(1, 1);
                            titleCell.Value = "DANH SÁCH SẢN PHẨM CẦN NHẬP";
                            titleCell.Style.Font.Bold = true;
                            titleCell.Style.Font.FontSize = 16;
                            titleCell.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                            titleCell.Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;

                            // Hợp nhất các ô để làm tiêu đề chính
                            int totalColumns = dgv_sp_add.Columns.Cast<DataGridViewColumn>().Count(c => c.Name != "xoa");
                            worksheet.Range(1, 1, 1, totalColumns).Merge();

                            // Thêm tiêu đề cột
                            int colIndex = 1;
                            foreach (DataGridViewColumn column in dgv_sp_add.Columns)
                            {
                                if (column.Name != "xoa") // Bỏ qua cột "xoa"
                                {
                                    worksheet.Cell(2, colIndex).Value = column.HeaderText;
                                    worksheet.Cell(2, colIndex).Style.Font.Bold = true;
                                    worksheet.Cell(2, colIndex).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                                    worksheet.Cell(2, colIndex).Style.Alignment.Vertical = ClosedXML.Excel.XLAlignmentVerticalValues.Center;
                                    worksheet.Cell(2, colIndex).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightBlue;
                                    colIndex++;
                                }
                            }

                            // Thêm dữ liệu từ DataGridView
                            int rowIndex = 3; // Bắt đầu từ hàng thứ 3 vì hàng 1 là tiêu đề chính, hàng 2 là tiêu đề cột
                            foreach (DataGridViewRow row in dgv_sp_add.Rows)
                            {
                                colIndex = 1;
                                foreach (DataGridViewColumn column in dgv_sp_add.Columns)
                                {
                                    if (column.Name != "xoa" && row.Cells[column.Name].Value != null) // Bỏ qua cột "xoa"
                                    {
                                        worksheet.Cell(rowIndex, colIndex).Value = row.Cells[column.Name].Value.ToString();
                                        colIndex++;
                                    }
                                }
                                rowIndex++;
                            }

                            // Tự động điều chỉnh độ rộng cột
                            worksheet.Columns().AdjustToContents();

                            // Lưu file
                            workbook.SaveAs(saveFileDialog.FileName);

                            // Thông báo thành công
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                "Xuất file Excel thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        // Thông báo lỗi
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            $"Có lỗi xảy ra khi xuất file: {ex.Message}",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }



        private void Dgv_sp_add_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Kiểm tra nếu cột là cột "xoa"
                if (dgv_sp_add.Columns[e.ColumnIndex].Name == "xoa")
                {
                    // Lấy dữ liệu từ dòng được nhấp
                    string maSanPham = dgv_sp_add.Rows[e.RowIndex].Cells["ma_san_pham"].Value.ToString();
                    string tenSanPham = dgv_sp_add.Rows[e.RowIndex].Cells["ten_san_pham"].Value.ToString();

                    // Hiển thị hộp thoại xác nhận từ DevExpress
                    var result = DevExpress.XtraEditors.XtraMessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa sản phẩm:\nMã: {maSanPham}\nTên: {tenSanPham}?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    // Nếu người dùng chọn "Yes", xóa dòng
                    if (result == DialogResult.Yes)
                    {
                        dgv_sp_add.Rows.RemoveAt(e.RowIndex);
                        DevExpress.XtraEditors.XtraMessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void Dgv_sp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Kiểm tra nếu cột là cột "Thêm"
                if (dgv_sp.Columns[e.ColumnIndex].Name == "them")
                {
                    // Lấy dữ liệu từ dòng được nhấp
                    string maSanPham = dgv_sp.Rows[e.RowIndex].Cells["ma_san_pham"].Value.ToString();
                    string tenSanPham = dgv_sp.Rows[e.RowIndex].Cells["ten_san_pham"].Value.ToString();

                    // Tạo XtraForm nhỏ để chọn số lượng
                    DevExpress.XtraEditors.XtraForm form = new DevExpress.XtraEditors.XtraForm
                    {
                        Text = $"Chọn số lượng nhập: {tenSanPham}",
                        StartPosition = FormStartPosition.CenterParent,
                        Size = new Size(300, 200),
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false,
                        MinimizeBox = false,
                        LookAndFeel = { SkinName = "Office 2019 Colorful" } // Giao diện hiện đại
                    };

                    // Tạo ComboBoxEdit để chọn số lượng
                    DevExpress.XtraEditors.ComboBoxEdit comboBox = new DevExpress.XtraEditors.ComboBoxEdit
                    {
                        Location = new Point(50, 40),
                        Width = 200,
                        Properties =
                {
                    TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor // Chỉ cho phép chọn
                }
                    };

                    // Thêm các giá trị từ 0 đến 1000 với bước nhảy 100
                    for (int i = 0; i <= 1000; i += 100)
                    {
                        comboBox.Properties.Items.Add(i);
                    }

                    comboBox.SelectedIndex = 1; // Mặc định chọn giá trị "100"

                    // Tạo nút xác nhận
                    DevExpress.XtraEditors.SimpleButton btnOk = new DevExpress.XtraEditors.SimpleButton
                    {
                        Text = "Xác nhận",
                        Location = new Point(50, 100),
                        Width = 80
                    };

                    // Tạo nút hủy
                    DevExpress.XtraEditors.SimpleButton btnCancel = new DevExpress.XtraEditors.SimpleButton
                    {
                        Text = "Hủy",
                        Location = new Point(150, 100),
                        Width = 80
                    };

                    // Thêm sự kiện cho nút
                    btnOk.Click += (s, args) =>
                    {
                        if (comboBox.SelectedItem != null)
                        {
                            int soLuongNhap = (int)comboBox.SelectedItem;
                            if (soLuongNhap == 0)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(
                                    "Số lượng nhập không thể bằng 0. Vui lòng chọn số lượng hợp lệ.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return; // Dừng xử lý tại đây
                            }

                            AddToDgvSpAdd(maSanPham, tenSanPham, soLuongNhap); // Thêm vào danh sách
                            form.DialogResult = DialogResult.OK;
                            form.Close();
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    btnCancel.Click += (s, args) =>
                    {
                        form.DialogResult = DialogResult.Cancel;
                        form.Close();
                    };

                    // Thêm ComboBox và nút vào XtraForm
                    form.Controls.Add(comboBox);
                    form.Controls.Add(btnOk);
                    form.Controls.Add(btnCancel);

                    // Hiển thị Form
                    form.ShowDialog();
                }
            }
        }




        private void Txt_tk_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(); // Lọc lại danh sách khi người dùng nhập
        }
        private void CustomizeDataGridView(DataGridView a)
        {
            // Loại bỏ viền
            a.BorderStyle = BorderStyle.None;

            // Màu nền và lưới
            a.BackgroundColor = Color.White; // Màu nền chính
            a.DefaultCellStyle.BackColor = Color.White; // Màu nền cho các ô
            a.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Màu nền cho dòng xen kẽ
            a.GridColor = Color.LightGray; // Màu lưới

            // Cấu hình tiêu đề cột
            a.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue; // Màu xanh nước biển nhạt
            a.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Màu chữ của tiêu đề
            a.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Tiêu đề căn giữa

            // Thiết lập tự căn chỉnh cột
            a.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự căn chỉnh cột theo kích thước bảng
            a.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; // Không tự động thay đổi chiều cao dòng

            // Căn chỉnh nội dung trong ô
            a.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Căn trái nội dung trong ô
            a.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Font chữ cho tiêu đề
            a.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular); // Font chữ cho ô dữ liệu

            // Loại bỏ đường viền của tiêu đề cột
            a.EnableHeadersVisualStyles = false; // Cho phép tùy chỉnh tiêu đề
        }
        private void Cbb_tk_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if(comboBox1.SelectedIndex<0)
            {
                return;
            }    
            ApplyFilter();
        }
        void ApplyFilter()
        {
            string keyword = txt_tk.Text.Trim();
            string filter = comboBox1.SelectedItem?.ToString() ?? "Tất cả sản phẩm";

            // Kiểm tra nếu là gợi ý
            if (keyword == "Nhập mã hoặc tên sản phẩm...")
                keyword = string.Empty;

            // Lấy dữ liệu theo tiêu chí
            List<san_pham_cus> result = new List<san_pham_cus>();
            sp = new san_pham_sql_BLL();

            // Lọc theo tiêu chí trong ComboBox
            switch (filter)
            {
                case "Tất cả sản phẩm":
                    result = sp.GetSanPhamTheoTieuChi("Tất cả sản phẩm");
                    break;

                case "Sản phẩm sắp hết hàng":
                    result = sp.GetSanPhamTheoTieuChi("Sản phẩm sắp hết hàng");
                    break;

                case "Sản phẩm hết hàng":
                    result = sp.GetSanPhamTheoTieuChi("Sản phẩm hết hàng");
                    break;

                case "Sản phẩm còn hàng":
                    result = sp.GetSanPhamTheoTieuChi("Sản phẩm còn hàng");
                    break;

                default:
                    MessageBox.Show("Vui lòng chọn tiêu chí lọc hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Lọc theo từ khóa (nếu có)
            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(sp =>
                    (sp.ten_san_pham != null && sp.ten_san_pham.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    sp.ma_san_pham.ToString().Contains(keyword)
                ).ToList();
            }

            // Xóa các hàng hiện tại trong DataGridView
            dgv_sp.Rows.Clear();

            // Thêm dữ liệu vào DataGridView
            foreach (var item in result)
            {
                dgv_sp.Rows.Add(item.ma_san_pham, item.ten_san_pham, item.so_luong, item.gia_binh_quan);
            }
        }
        void load_all()
        {
            sp = new san_pham_sql_BLL();
            var reslt = sp.GetSanPhamTheoTieuChi("Tất cả sản phẩm");
            foreach (var item in reslt)
            {
                dgv_sp.Rows.Add(item.ma_san_pham, item.ten_san_pham, item.so_luong, item.gia_binh_quan);
            }
        }

        private void UC_checkSP_Load(object sender, EventArgs e)
        {
            load_cbb();
            InitializeGridViewColumns();
            InitializeGridViewColumns_sp_add();
            CustomizeDataGridView(dgv_sp);
            CustomizeDataGridView(dgv_sp_add);
            load_all();
        }
        private void InitializeGridViewColumns()
        {
            dgv_sp.Columns.Clear(); // Xóa các cột cũ nếu có

            // Thêm các cột
            dgv_sp.Columns.Add("ma_san_pham", "Mã Sản Phẩm");
            dgv_sp.Columns.Add("ten_san_pham", "Tên Sản Phẩm");
            dgv_sp.Columns.Add("so_luong", "Số Lượng Còn");
            dgv_sp.Columns.Add("gia_binh_quan", "Giá Bình Quân");

            // Cột chứa nút (hoặc icon)
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn
            {
                Name = "them",
                HeaderText = "Thêm",
                Image = Properties.Resources.themphieu, // Đường dẫn đến icon trong Resources
                Width = 50,
                ImageLayout = DataGridViewImageCellLayout.Zoom // Tùy chỉnh hiển thị
            };
            dgv_sp.Columns.Add(iconColumn);
        }
        private void AddToDgvSpAdd(string maSanPham, string tenSanPham, int soLuongNhap)
        {
            // Kiểm tra xem sản phẩm đã tồn tại trong dgv_sp_add chưa
            foreach (DataGridViewRow row in dgv_sp_add.Rows)
            {
                if (row.Cells["ma_san_pham"].Value?.ToString() == maSanPham)
                {
                    // Nếu sản phẩm đã tồn tại, cộng dồn số lượng nhập
                    row.Cells["so_luong_nhap"].Value = Convert.ToInt32(row.Cells["so_luong_nhap"].Value) + soLuongNhap;
                    return;
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm mới vào DataGridView
            dgv_sp_add.Rows.Add(maSanPham, tenSanPham, soLuongNhap);
        }

        private void InitializeGridViewColumns_sp_add()
        {
            dgv_sp_add.Columns.Clear(); // Xóa các cột cũ nếu có

            // Thêm các cột
            dgv_sp_add.Columns.Add("ma_san_pham", "Mã Sản Phẩm");
            dgv_sp_add.Columns.Add("ten_san_pham", "Tên Sản Phẩm");
            dgv_sp_add.Columns.Add("so_luong_nhap", "Số Lượng Nhập");
           

            // Cột chứa nút (hoặc icon)
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn
            {
                Name = "xoa",
                HeaderText = "Xóa",
                Image = Properties.Resources.thoat, // Đường dẫn đến icon trong Resources
                Width = 50,
                ImageLayout = DataGridViewImageCellLayout.Zoom // Tùy chỉnh hiển thị
            };
            dgv_sp_add.Columns.Add(iconColumn);
        }

        void load_cbb()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "-- Lọc sản phẩm theo --";
      
            comboBox1.Items.Add("Tất cả sản phẩm");
            comboBox1.Items.Add("Sản phẩm sắp hết hàng");
            comboBox1.Items.Add("Sản phẩm hết hàng");
            comboBox1.Items.Add("Sản phẩm còn hàng");
            comboBox1.SelectedIndex = -1;
        }
        private void Txt_tk_Leave(object sender, EventArgs e)
        {
            // Nếu TextBox rỗng, hiển thị gợi ý
            if (string.IsNullOrWhiteSpace(txt_tk.Text))
            {
                txt_tk.Text = "Nhập mã hoặc tên sản phẩm..."; // Hiển thị gợi ý
                txt_tk.ForeColor = Color.Gray; // Đổi màu chữ sang màu gợi ý
            }
        }


        private void Txt_tk_Enter(object sender, EventArgs e)
        {
            // Nếu TextBox chứa gợi ý, xóa gợi ý khi người dùng nhập
            if (txt_tk.Text == "Nhập mã hoặc tên sản phẩm...")
            {
                txt_tk.Text = ""; // Xóa nội dung gợi ý
                txt_tk.ForeColor = Color.Black; // Đổi màu chữ về màu nhập thông thường
            }
        }

    }
}
