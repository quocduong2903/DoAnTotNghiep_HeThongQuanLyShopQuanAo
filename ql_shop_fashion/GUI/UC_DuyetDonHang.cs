using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class UC_DuyetDonHang : UserControl
    {
        private nhap_hang_sql_BLL nhap_bll;
        private nha_cung_cap_sql_BLL ncc_bll;
        private chi_tiet_nhap_sql_BLL ct_nhap_bll;
        int id_nv;
        public UC_DuyetDonHang(int id)
        {
            InitializeComponent();
            id_nv = id;
            this.Load += FrmNhapHang_Load;
            dgv_nh.CellClick += Dgv_nh_CellClick;
            duyet.Click += Duyet_Click;
            them.Click += Them_Click;
            load.Click += Load_Click;
            check_ht.Click += Check_ht_Click;
            check_doigiao.Click += Check_doigiao_Click;
            check_doiduyet.Click += Check_doiduyet_Click;
            check_chuadusl.Click += Check_chuadusl_Click;
            check_all.Click += Check_all_Click;
            dgv_nh.EditingControlShowing += Dgv_nh_EditingControlShowing;
        }

        private void Dgv_nh_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Kiểm tra nếu có cột "ChucNang"
            if (dgv_nh.Columns.Contains("ChucNang"))
            {
                // Nếu ô hiện tại thuộc cột "ChucNang"
                if (dgv_nh.CurrentCell.ColumnIndex == dgv_nh.Columns["ChucNang"].Index)
                {
                    if (e.Control is System.Windows.Forms.ComboBox comboBox)
                    {
                        // Loại bỏ sự kiện nếu đã gắn trước đó
                        comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

                        // Gắn sự kiện SelectedIndexChanged cho ComboBox
                        comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                    }
                }
            }
            // Kiểm tra nếu có cột "ChucNang1"
            else if (dgv_nh.Columns.Contains("ChucNang1"))
            {
                // Nếu ô hiện tại thuộc cột "ChucNang1"
                if (dgv_nh.CurrentCell.ColumnIndex == dgv_nh.Columns["ChucNang1"].Index)
                {
                    if (e.Control is System.Windows.Forms.ComboBox comboBox)
                    {
                        // Loại bỏ sự kiện nếu đã gắn trước đó
                        comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

                        // Gắn sự kiện SelectedIndexChanged cho ComboBox
                        comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                    }
                }
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nhap_bll = new nhap_hang_sql_BLL();

            // Kiểm tra ComboBox có hợp lệ không
            if (!(sender is System.Windows.Forms.ComboBox comboBox))
            {
                return; // Nếu sender không phải là ComboBox, thoát khỏi sự kiện
            }

            // Kiểm tra có dòng và ô hợp lệ không
            if (dgv_nh.CurrentRow == null || dgv_nh.CurrentCell == null || dgv_nh.CurrentCell.RowIndex < 0)
            {
                return; // Thoát khỏi sự kiện nếu không có dòng hoặc ô hợp lệ
            }

            // Lấy giá trị được chọn từ ComboBox
            string selectedValue = comboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedValue))
            {
               
                return; // Nếu không có lựa chọn, thoát khỏi sự kiện
            }

            // Lấy chỉ số hàng hiện tại
            int currentRowIndex = dgv_nh.CurrentCell.RowIndex;

            // Lấy mã nhập hàng từ dòng hiện tại
            int maNhapHang = Convert.ToInt32(dgv_nh.Rows[currentRowIndex].Cells["ma_nhap_hang"].Value);

            // Xử lý cột "ChucNang" nếu tồn tại
            if (dgv_nh.Columns.Contains("ChucNang"))
            {
                if (selectedValue == "Đã giao")
                {
                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(
                        $"Bạn có muốn cập nhật tình trạng đơn hàng #{maNhapHang} thành \"Đã giao\" không?",
                        "Xác nhận cập nhật",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Cập nhật trạng thái đơn hàng
                        bool isUpdated = nhap_bll.cap_nhat_trang_thai(maNhapHang, "Đợi duyệt");

                        // Hiển thị thông báo và xử lý kết quả cập nhật
                        if (isUpdated)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                $"Đơn hàng #{maNhapHang} đã được cập nhật thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            load_dgv_sp(0); // Làm mới dữ liệu
                            load_check_danggiao(); // Làm mới dữ liệu
                            comboBox.SelectedIndex = -1;  // Reset ComboBox
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                "Cập nhật thất bại. Vui lòng thử lại.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else if (selectedValue == "Chưa đủ số lượng")
                {
                    // Xử lý cập nhật khi chọn "Chưa đủ số lượng"
                    DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(
                        $"Bạn có muốn cập nhật tình trạng đơn hàng #{maNhapHang} thành \"Chưa đủ số lượng\" không?",
                        "Xác nhận cập nhật",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Cập nhật trạng thái đơn hàng
                        bool isUpdated = nhap_bll.cap_nhat_trang_thai(maNhapHang, "Chưa đủ số lượng");

                        // Hiển thị thông báo và xử lý kết quả cập nhật
                        if (isUpdated)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                $"Đơn hàng #{maNhapHang} đã được cập nhật thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            load_dgv_sp(0); // Làm mới dữ liệu
                            load_check_danggiao(); // Làm mới dữ liệu
                            comboBox.SelectedIndex = -1;  // Reset ComboBox
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                "Cập nhật thất bại. Vui lòng thử lại.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            // Xử lý cột "ChucNang1" nếu tồn tại
            else if (dgv_nh.Columns.Contains("ChucNang1"))
            {
                if (selectedValue == "Đã giao đủ số lượng")
                {
                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(
                        $"Bạn có muốn cập nhật tình trạng đơn hàng #{maNhapHang} thành \"Đã giao đủ số lượng\" không?",
                        "Xác nhận cập nhật",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Cập nhật trạng thái đơn hàng
                        bool isUpdated = nhap_bll.cap_nhat_trang_thai(maNhapHang, "Đợi duyệt");

                        // Hiển thị thông báo và xử lý kết quả cập nhật
                        if (isUpdated)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                $"Đơn hàng #{maNhapHang} đã được cập nhật thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            load_chuadusl(); // Làm mới dữ liệu
                            load_dgv_sp(0); // Làm mới dữ liệu
                            comboBox.SelectedIndex = -1;  // Reset ComboBox
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                                "Cập nhật thất bại. Vui lòng thử lại.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }





        private void Check_all_Click(object sender, EventArgs e)
        {
            RemoveFunctionColumn("ChucNang");
            RemoveFunctionColumn("ChucNang1");
            nhap_bll = new nhap_hang_sql_BLL();
            dgv_nh.DataSource = nhap_bll.get_all_nhap_hang();
        }

        private void Check_chuadusl_Click(object sender, EventArgs e)
        {
            load_chuadusl();
        }
        void load_chuadusl()
        {
            RemoveFunctionColumn("ChucNang");
            nhap_bll = new nhap_hang_sql_BLL();
            dgv_nh.DataSource = nhap_bll.get_nhap_hang_by_trang_thai("Chưa đủ số lượng");
            add_chuadusl();
            CustomizeDataGridView(dgv_nh);
        }

        private void Check_doiduyet_Click(object sender, EventArgs e)
        {
            RemoveFunctionColumn("ChucNang");
            RemoveFunctionColumn("ChucNang1");
            nhap_bll = new nhap_hang_sql_BLL();
            dgv_nh.DataSource = nhap_bll.get_nhap_hang_by_trang_thai("Đợi duyệt");
        }
        private void RemoveFunctionColumn(string chucnang)
        {
            if (dgv_nh.Columns.Contains(chucnang))
            {
                dgv_nh.Columns.Remove(chucnang);
            }
        }


        private void Check_doigiao_Click(object sender, EventArgs e)
        {
            
            RemoveFunctionColumn("ChucNang1");
            load_check_danggiao();
        }
        void load_check_danggiao()
        {
            nhap_bll = new nhap_hang_sql_BLL();
            dgv_nh.DataSource = nhap_bll.get_nhap_hang_by_trang_thai("Đang đợi giao hàng");
            AddFunctionColumnToDataGridView();
            CustomizeDataGridView(dgv_nh);
        }
      
        private void AddFunctionColumnToDataGridView()
        {
            // Tạo cột chức năng dạng ComboBox
            DataGridViewComboBoxColumn functionColumn = new DataGridViewComboBoxColumn();
            functionColumn.Name = "ChucNang";
            functionColumn.HeaderText = "Chức năng";

            // Thêm các lựa chọn vào ComboBox
            functionColumn.Items.Add("-- Cập nhật tình trạng --");
            functionColumn.Items.Add("Đã giao");
            functionColumn.Items.Add("Chưa đủ số lượng");

            // Đặt giá trị mặc định
            functionColumn.DefaultCellStyle.NullValue = "-- Cập nhật tình trạng --";

            // Đặt độ rộng cho cột
         

            // Thêm cột vào DataGridView
            if (!dgv_nh.Columns.Contains("ChucNang"))
            {
                dgv_nh.Columns.Add(functionColumn);
            }
        }
        private void add_chuadusl()
        {
            // Tạo cột chức năng dạng ComboBox
            DataGridViewComboBoxColumn functionColumn = new DataGridViewComboBoxColumn();
            functionColumn.Name = "ChucNang1";
            functionColumn.HeaderText = "Chức năng";

            // Thêm các lựa chọn vào ComboBox
            functionColumn.Items.Add("-- Cập nhật tình trạng --");
            functionColumn.Items.Add("Đã giao đủ số lượng");
         

            // Đặt giá trị mặc định
            functionColumn.DefaultCellStyle.NullValue = "-- Cập nhật tình trạng --";

            // Đặt độ rộng cho cột


            // Thêm cột vào DataGridView
            if (!dgv_nh.Columns.Contains("ChucNang1"))
            {
                dgv_nh.Columns.Add(functionColumn);
            }
        }



        private void Check_ht_Click(object sender, EventArgs e)
        {
            RemoveFunctionColumn("ChucNang");
            RemoveFunctionColumn("ChucNang1");
            nhap_bll = new nhap_hang_sql_BLL();
            dgv_nh.DataSource = nhap_bll.get_nhap_hang_by_trang_thai("Hoàn thành");

        }

        void clear()
        {
            txt_ghichu.Text = "";
            txt_manhanvien.Text = "";
            txt_manhaphang.Text = "";
            cbb_manhacungcap.SelectedIndex = -1;
            cbb_trangthai.SelectedIndex = -1;

            
            txt_tonggiatien.Text = "";
            txt_tongsoluong.Text = "";
        }

        private void Load_Click(object sender, EventArgs e)
        {
            loaddgv_nhap_hang();
            load_cbb_ncc();
            load_dgv_sp(0);
            clear();
            RemoveFunctionColumn("ChucNang");
            RemoveFunctionColumn("ChucNang1");
        }

        private void Them_Click(object sender, EventArgs e)
        {
            PhieuNhap phieuNhap = new PhieuNhap(id_nv);
            phieuNhap.Show();
        }

        private void Duyet_Click(object sender, EventArgs e)
        {
            if (dgv_nh.SelectedRows.Count > 0)
            {
                if ((dgv_nh.SelectedRows[0].Cells["trang_thai"].Value.ToString()).Equals("Đợi duyệt") ||
                    (string.IsNullOrEmpty(txt_manhaphang.Text) && cbb_trangthai.SelectedItem.ToString().Equals("Đợi duyệt")))
                {
                    int maNhapHang = dgv_nh.SelectedRows[0].Cells["ma_nhap_hang"].Value != null
                        ? int.Parse(dgv_nh.SelectedRows[0].Cells["ma_nhap_hang"].Value.ToString())
                        : int.Parse(txt_manhaphang.Text);

                    frmDuyetSanPham duyet = new frmDuyetSanPham(maNhapHang);
                    duyet.FormClosedEvent += Duyet_FormClosedEvent;
                    duyet.Show();
                }
                else if ((dgv_nh.SelectedRows[0].Cells["trang_thai"].Value.ToString()).Equals("Hoàn thành") ||
                         (string.IsNullOrEmpty(txt_manhaphang.Text) && cbb_trangthai.SelectedItem.ToString().Equals("Hoàn thành")))
                {
                    XtraMessageBox.Show("Không thể duyệt đơn đã hoàn thành!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else if ((dgv_nh.SelectedRows[0].Cells["trang_thai"].Value.ToString()).Equals("Đang đợi giao hàng") ||
                         (string.IsNullOrEmpty(txt_manhaphang.Text) && cbb_trangthai.SelectedItem.ToString().Equals("Đang đợi giao hàng")))
                {
                    XtraMessageBox.Show("Đơn hàng chưa giao không thể duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else if ((dgv_nh.SelectedRows[0].Cells["trang_thai"].Value.ToString()).Equals("Chưa đủ số lượng") ||
                        (string.IsNullOrEmpty(txt_manhaphang.Text) && cbb_trangthai.SelectedItem.ToString().Equals("Chưa đủ số lượng")))
                {
                    XtraMessageBox.Show("Đơn hàng chưa giao đủ không thể duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn đơn cần duyệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Duyet_FormClosedEvent(object sender, EventArgs e)
        {
            loaddgv_nhap_hang();
        }

        private void Dgv_nh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_nh.Rows[e.RowIndex];
                int id = int.Parse(row.Cells["ma_nhap_hang"].Value.ToString());

                var hang = nhap_bll.get_nhap_hang_by_id(id).FirstOrDefault();

                if (hang != null)
                {
                    var maNhapHang = hang.GetType().GetProperty("ma_nhap_hang")?.GetValue(hang, null);
                    var ngayNhap = hang.GetType().GetProperty("ngay_nhap")?.GetValue(hang, null);
                    var tongTien = hang.GetType().GetProperty("tong_gia_tien")?.GetValue(hang, null);
                    var tenNhaCungCap = hang.GetType().GetProperty("ten_nha_cung_cap")?.GetValue(hang, null);
                    var tenNhanVien = hang.GetType().GetProperty("ten_nhan_vien")?.GetValue(hang, null);
                    var ghichu = hang.GetType().GetProperty("ghi_chu")?.GetValue(hang, null);
                    var tt = hang.GetType().GetProperty("trang_thai")?.GetValue(hang, null);
                    var tongsoluong = hang.GetType().GetProperty("tong_so_luong")?.GetValue(hang, null);

                    load_dgv_sp(maNhapHang);

                    txt_manhaphang.Text = maNhapHang?.ToString();
                    ngaynhap.Text = ngayNhap?.ToString();
                    txt_tonggiatien.Text = tongTien?.ToString();
                    cbb_manhacungcap.Text = tenNhaCungCap?.ToString();
                    txt_manhanvien.Text = tenNhanVien?.ToString();
                    txt_ghichu.Text = ghichu?.ToString();
                    cbb_trangthai.Text = tt?.ToString();
                    txt_tongsoluong.Text = tongsoluong?.ToString();
                }
            }
        }

        void load_cbb_ncc()
        {
            ncc_bll = new nha_cung_cap_sql_BLL();
            List<string> ncc = ncc_bll.get_ncc_list_name();
            cbb_manhacungcap.Properties.Items.Clear();
            cbb_manhacungcap.Properties.Items.AddRange(ncc);
        }

        void load_dgv_sp(int id)
        {
            ct_nhap_bll = new chi_tiet_nhap_sql_BLL();
            dgv_sanpham.DataSource = null;

            if (id > 0)
            {
                dgv_sanpham.DataSource = ct_nhap_bll.get_sp_by_phieu_nhap(id);
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ten_san_pham", typeof(string));
                dt.Columns.Add("so_luong", typeof(int));
                dt.Columns.Add("gia_nhap", typeof(decimal));
                dgv_sanpham.DataSource = dt;
            }

            dgv_sanpham.Columns["ten_san_pham"].HeaderText = "Sản Phẩm";
            dgv_sanpham.Columns["so_luong"].HeaderText = "Số Lượng";
            dgv_sanpham.Columns["gia_nhap"].HeaderText = "Giá";

            dgv_sanpham.Columns["ten_san_pham"].Width = 150;
            dgv_sanpham.Columns["so_luong"].Width = 80;
            dgv_sanpham.Columns["gia_nhap"].Width = 100;

    

        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            loaddgv_nhap_hang();
            load_cbb_ncc();
            load_dgv_sp(0);
            CustomizeDataGridView(dgv_nh);
            CustomizeDataGridView(dgv_sanpham);
           
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



        void loaddgv_nhap_hang()
        {
            nhap_bll = new nhap_hang_sql_BLL();

            var data = nhap_bll.get_all_nhap_hang();
            if (data != null)
            {
                dgv_nh.DataSource = data;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ma_nhap_hang", typeof(int));
                dt.Columns.Add("ngay_nhap", typeof(DateTime));
                dt.Columns.Add("tong_gia_tien", typeof(decimal));
                dt.Columns.Add("ghi_chu", typeof(string));
                dt.Columns.Add("trang_thai", typeof(string));
                dt.Columns.Add("tong_so_luong", typeof(int));
                dgv_nh.DataSource = dt;
            }

            dgv_nh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_nh.Columns["ma_nhap_hang"].HeaderText = "Mã Nhập Hàng";
            dgv_nh.Columns["ngay_nhap"].HeaderText = "Ngày Nhập";
            dgv_nh.Columns["tong_gia_tien"].HeaderText = "Tổng Giá Tiền";
            dgv_nh.Columns["ghi_chu"].HeaderText = "Ghi Chú";
            dgv_nh.Columns["trang_thai"].HeaderText = "Trạng Thái";
            dgv_nh.Columns["tong_so_luong"].HeaderText = "Tổng Số Lượng";
        }

        private void thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
            }
        }

        private void filterControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
