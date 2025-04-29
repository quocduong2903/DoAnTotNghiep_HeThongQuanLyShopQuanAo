using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid; // Để sử dụng GridView
using DevExpress.XtraEditors.Repository; // Để sử dụng RepositoryItemComboBox
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using BLL;
using DTO;
using DevExpress.XtraReports.UI;

// Namespace cho GridView


namespace GUI
{
    public partial class PhieuNhap : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private nha_cung_cap_sql_BLL ncc_bll;
        private chi_tiet_nhap_sql_BLL ct_sp_bll;
        private san_pham_sql_BLL sp_bll;
        private ncc_sp_sql_BLL nccsp_bll;
        private nhap_hang_sql_BLL nhap_bll;
        public List<string> SupplierTotals { get; set; }
        bool check = false;
        private Timer holdTimer;
        private bool isHolding = false;
        private Form popup;
        int id_nv;
        public PhieuNhap(int idnv)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            id_nv = idnv;
            this.Load += PhieuNhap_Load;

            cbb_ncc.TextChanged += Cbb_ncc_TextChanged;
            cbb_tensp.TextChanged += Cbb_tensp_TextChanged;
            cbb_tensp.SelectedIndexChanged += Cbb_tensp_SelectedIndexChanged;
            cbb_ncc.SelectedIndexChanged += Cbb_ncc_SelectedIndexChanged;
            cbb_sl.SelectedIndexChanged += Cbb_sl_SelectedIndexChanged;

            bt_them.ItemClick += Bt_them_ItemClick;
            bt_xoa.ItemClick += Bt_xoa_ItemClick;
            bt_sua.ItemClick += Bt_sua_ItemClick;

            dgv_sp_add.CellClick += Dgv_sp_add_CellClick1;
            bt_add_all.ItemClick += Bt_add_all_ItemClick;
            bt_load.ItemClick += Bt_load_ItemClick;


            holdTimer = new Timer();
            holdTimer.Interval = 1000;


            lb_thanhtien.MouseEnter += Lb_thanhtien_MouseEnter; lb_thanhtien.MouseLeave += Lb_thanhtien_MouseLeave;

        }



        private void Bt_load_ItemClick(object sender, ItemClickEventArgs e)
        {
            clear_all();
        }

        private void Lb_thanhtien_MouseLeave(object sender, EventArgs e)
        {
            popup?.Close();
        }

        private void Lb_thanhtien_MouseEnter(object sender, EventArgs e)
        {
            ShowSupplierTotalsDialog(dgv_sp_add);
        }









        public void ShowSupplierTotalsDialog(DataGridView dgv)
        {
            // Kiểm tra nếu bảng không có dữ liệu
            if (dgv == null || dgv.Rows.Count == 0)
            {
                ShowPopup("Không có dữ liệu!");
                return;
            }

            // Tính toán tổng giá nhập theo nhà cung cấp
            Dictionary<int, decimal> supplierTotals = CalculateSupplierTotals(dgv);

            // Nếu không có dữ liệu hợp lệ để tính toán
            if (supplierTotals.Count == 0)
            {
                ShowPopup("Không có dữ liệu hợp lệ để hiển thị!");
                return;
            }

            // Tạo danh sách string để hiển thị theo định dạng yêu cầu
            List<string> supplierTotalsText = supplierTotals
                .Select(item => $"Tổng tiền của hóa đơn nhà cung cấp mã {item.Key}: {item.Value} VND")
                .ToList();

            // Hiển thị popup với thông tin tổng tiền
            ShowPopup(string.Join(Environment.NewLine, supplierTotalsText));
        }

        private void ShowPopup(string message)
        {
            // Tạo form nhỏ để hiển thị thông tin
            popup = new Form
            {
                StartPosition = FormStartPosition.CenterScreen, // Đặt vị trí chính giữa màn hình
                Size = new Size(300, 150), // Kích thước form
                FormBorderStyle = FormBorderStyle.None, // Không có viền form
                BackColor = Color.Orange, // Màu nền cam để nổi bật
                Opacity = 0.95, // Mờ đi một chút
                ShowInTaskbar = false, // Không hiển thị trên taskbar
                TopMost = true // Đảm bảo form ở trên cùng
            };

            // Label để hiển thị thông tin
            Label lblInfo = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black, // Màu chữ đen để dễ đọc trên nền cam
                Padding = new Padding(10) // Thêm padding cho label
            };
            popup.Controls.Add(lblInfo);

            // Hiển thị form
            popup.Show();
        }







        public Dictionary<int, decimal> CalculateSupplierTotals(DataGridView dgv)
        {
            // Dictionary để lưu tổng giá nhập của từng nhà cung cấp
            Dictionary<int, decimal> supplierTotals = new Dictionary<int, decimal>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Kiểm tra hàng có giá trị không
                if (row.Cells["ma_nha_cung_cap"].Value != null && row.Cells["gia_nhap"].Value != null)
                {
                    // Lấy mã nhà cung cấp
                    int maNhaCungCap = Convert.ToInt32(row.Cells["ma_nha_cung_cap"].Value);

                    // Lấy giá nhập
                    decimal giaNhap = Convert.ToDecimal(row.Cells["gia_nhap"].Value);

                    // Cộng dồn giá nhập cho từng nhà cung cấp
                    if (supplierTotals.ContainsKey(maNhaCungCap))
                    {
                        supplierTotals[maNhaCungCap] += giaNhap;
                    }
                    else
                    {
                        supplierTotals[maNhaCungCap] = giaNhap;
                    }
                }
            }

            return supplierTotals;
        }


        List<DataTable> GroupProductsBySupplier()
        {
            // Khởi tạo danh sách để lưu các DataTable
            List<DataTable> productTables = new List<DataTable>();

            // Lấy danh sách các nhà cung cấp duy nhất từ DataGridView
            var uniqueSuppliers = dgv_sp_add.Rows
                .Cast<DataGridViewRow>()
                .Select(row => new
                {
                    MaNhaCungCap = Convert.ToInt32(row.Cells["ma_nha_cung_cap"].Value)

                })
                .Distinct()
                .ToList();

            // Lặp qua từng nhà cung cấp
            foreach (var supplier in uniqueSuppliers)
            {
                // Tạo một DataTable mới cho nhà cung cấp này
                DataTable dt = new DataTable();
                dt.TableName = supplier.MaNhaCungCap.ToString(); // Đặt tên cho DataTable

                // Thêm các cột vào DataTable
                dt.Columns.Add("ma_nha_cung_cap", typeof(int));
                dt.Columns.Add("ma_san_pham", typeof(int));
                dt.Columns.Add("so_luong", typeof(int));
                dt.Columns.Add("gia_nhap", typeof(decimal));

                // Lọc các sản phẩm theo nhà cung cấp
                var products = dgv_sp_add.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => Convert.ToInt32(row.Cells["ma_nha_cung_cap"].Value) == supplier.MaNhaCungCap);

                // Thêm các dòng vào DataTable
                foreach (var product in products)
                {
                    dt.Rows.Add(
                        supplier.MaNhaCungCap, // Thêm ma_nha_cung_cap
                        Convert.ToInt32(product.Cells["ma_san_pham"].Value),
                        Convert.ToInt32(product.Cells["so_luong"].Value),
                        Convert.ToDecimal(product.Cells["gia_nhap"].Value)
                    );
                }

                // Thêm DataTable vào danh sách
                productTables.Add(dt);
            }

            return productTables;
        }
        void them_phieu(int id)
        {
            List<DataTable> productTables = GroupProductsBySupplier();
            nhap_bll = new nhap_hang_sql_BLL();
            int count = 0;


            // Duyệt qua từng DataTable
            foreach (DataTable dt in productTables)
            {
                // Tạo đối tượng nhap_hang
                nhap_hang nhap = new nhap_hang();
                List<chi_tiet_nhap_hang> ct = new List<chi_tiet_nhap_hang>();

                // Duyệt qua từng hàng trong DataTable
                foreach (DataRow row in dt.Rows)
                {

                    chi_tiet_nhap_hang a = new chi_tiet_nhap_hang
                    {
                        ma_san_pham = Convert.ToInt32(row["ma_san_pham"]),
                        so_luong = Convert.ToInt32(row["so_luong"]),
                        gia_nhap = Convert.ToDecimal(row["gia_nhap"]),
                    };
                    ct.Add(a);
                }

                // Lấy mã nhà cung cấp từ tên của DataTable
                int mancc = int.Parse(dt.TableName);
                if (mancc == 0 && count == 0)
                {
                    MessageBox.Show("Không có sản phẩm nào để thêm.");
                    return;
                }
                if (count == 0)
                {
                    count = 1;
                }
                if (mancc == 0)
                {
                    clear_all();
                    return;
                }
                nhap.ma_nhan_vien = id; // Giả sử đây là mã nhân viên
                nhap.ma_nha_cung_cap = mancc;
                nhap.ngay_nhap = date_ngaynhap.Value;
                nhap.trang_thai = "Đang đợi giao hàng";

                // Hiển thị hộp thoại InputBox để nhập ghi chú
                string ghiChu = Microsoft.VisualBasic.Interaction.InputBox("Ghi chú đơn thứ " + count.ToString() + " của nhà cung cấp " + mancc.ToString() + " : ", "Nhập Ghi Chú", "Không có");

                // Nếu người dùng đóng hộp thoại (chuỗi ghi chú trống), bỏ qua việc tạo đơn hàng này
                if (string.IsNullOrWhiteSpace(ghiChu))
                {
                    MessageBox.Show("Người dùng đã tắt giao diện.");
                    continue;
                }

                // Lưu lại ghi chú vào `txt_ghichu`
                nhap.ghi_chu = ghiChu;

                // Thực hiện thêm phiếu nhập hàng
                if (nhap_bll.nhap_hang_add(nhap, ct))
                {
                    MessageBox.Show("Tạo thành công đơn " + count + " !!!");
                }
                else
                {
                    MessageBox.Show("Lỗi đơn thứ " + count + " !!!");

                    return;
                }

                count++;
            }

        }


        private void Bt_add_all_ItemClick(object sender, ItemClickEventArgs e)
        {
            them_phieu(id_nv);
        }
        private bool FindAndUpdateRow(int maSanPham, int maNhaCungCap, int newQuantity, decimal newGiaNhap)
        {
            bool found = false; // Biến đánh dấu có tìm thấy dòng hay không

            // Lặp qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dgv_sp_add.Rows)
            {
                // Lấy giá trị từ các ô trong dòng
                int rowMaSanPham = Convert.ToInt32(row.Cells["ma_san_pham"].Value);
                int rowMaNhaCungCap = Convert.ToInt32(row.Cells["ma_nha_cung_cap"].Value);

                // Kiểm tra xem có trùng khớp với ma_san_pham và ma_nha_cung_cap không
                if (rowMaSanPham == maSanPham && rowMaNhaCungCap == maNhaCungCap)
                {
                    // Nếu tìm thấy, cập nhật giá trị trong dòng
                    row.Cells["so_luong"].Value = newQuantity; // Cập nhật số lượng
                    row.Cells["gia_nhap"].Value = newGiaNhap; // Cập nhật giá nhập

                    found = true; // Đánh dấu là đã tìm thấy
                    break; // Thoát khỏi vòng lặp
                }
            }

            // Trả về giá trị của biến found
            return found;
        }
        private void Bt_sua_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (check)
            {
                if (check_in_put() == false)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!!!", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sp_bll = new san_pham_sql_BLL();
                ncc_bll = new nha_cung_cap_sql_BLL();

                // Lấy mã sản phẩm và mã nhà cung cấp từ các ComboBox
                int ma = sp_bll.get_id_sp_by_name(cbb_tensp.SelectedItem.ToString());
                int mancc = ncc_bll.get_id_ncc(cbb_ncc.SelectedItem.ToString()); // Sửa lại để lấy mã nhà cung cấp

                int sl = int.Parse(cbb_sl.SelectedItem.ToString());

                decimal gp;
                // Kiểm tra xem giá nhập có hợp lệ hay không
                if (!decimal.TryParse(txt_gianhap.Text, out gp))
                {
                    MessageBox.Show("Giá nhập không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi hàm FindAndUpdateRow để cập nhật thông tin
                if (FindAndUpdateRow(ma, mancc, sl, gp))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    check = false;
                    UpdateDataGridView();
                    clear_all();
                    capNhatTongTien();
                    return;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dòng cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Nếu check là false, thoát khỏi hàm
            }
        }
        private void Dgv_sp_add_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng RowIndex là hợp lệ
            {
                check = true;
                clear_all(); // Gọi hàm để xóa các trường trước đó
                sp_bll = new san_pham_sql_BLL();
                ncc_bll = new nha_cung_cap_sql_BLL();

                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgv_sp_add.Rows[e.RowIndex];

                // Kiểm tra giá trị của các ô để tránh lỗi
                if (selectedRow.Cells["ma_nha_cung_cap"].Value != null &&
                    selectedRow.Cells["ma_san_pham"].Value != null &&
                    selectedRow.Cells["so_luong"].Value != null &&
                    selectedRow.Cells["gia_nhap"].Value != null)
                {
                    // Lấy giá trị từ các ô
                    int maNhaCungCap = Convert.ToInt32(selectedRow.Cells["ma_nha_cung_cap"].Value);
                    int maSanPham = Convert.ToInt32(selectedRow.Cells["ma_san_pham"].Value);
                    int soLuong = Convert.ToInt32(selectedRow.Cells["so_luong"].Value);
                    decimal giaNhap = Convert.ToDecimal(selectedRow.Cells["gia_nhap"].Value);

                    // Cập nhật giao diện với các giá trị đã lấy
                    cbb_tensp.SelectedItem = sp_bll.get_name_by_id(maSanPham); // Lấy tên sản phẩm từ id
                    cbb_ncc.SelectedItem = ncc_bll.get_name_by_id(maNhaCungCap); // Lấy tên nhà cung cấp từ id
                    cbb_sl.SelectedItem = soLuong; // Chuyển đổi số lượng sang chuỗi
                    txt_gianhap.Text = giaNhap.ToString("F2"); // Định dạng giá nhập với 2 chữ số thập phân
                }
                else
                {
                    // Thông báo cho người dùng nếu có dữ liệu không hợp lệ
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void clear_all()
        {
            cbb_tensp.SelectedIndex = -1;
            cbb_ncc.SelectedIndex = -1;
            cbb_sl.SelectedIndex = 0;
            txt_gianhap.Text = "0";

            dgv_gia.Rows.Clear(); // Xóa tất cả các dòng trong DataGridView nếu có
            dgv_gia.Refresh();

            dgv_sp_add.Rows.Clear(); // Xóa tất cả các dòng trong DataGridView nếu có
            dgv_sp_add.Refresh();
            lb_thanhtien.Text = "Thành tiền: 0";


        }
        private void Dgv_sp_add_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Bt_xoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            RemoveSelectedRowFromDataGridView();
        }
        private void Bt_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            them_dgv();
        }

        void UpdateDataGridView()
        {
            // Có thể thêm logic tại đây nếu cần làm mới dữ liệu hoặc thực hiện các cập nhật khác.
            // Ví dụ: tự động cuộn đến dòng cuối cùng vừa thêm, hoặc làm mới dữ liệu từ nguồn khác nếu cần.

            // Tự động cuộn đến dòng cuối cùng vừa thêm
            if (dgv_sp_add.Rows.Count > 0)
            {
                dgv_sp_add.FirstDisplayedScrollingRowIndex = dgv_sp_add.Rows.Count - 1;
            }
        }
        bool IsDuplicateEntry(int id, int idsp)
        {
            foreach (DataGridViewRow row in dgv_sp_add.Rows)
            {
                // Kiểm tra nếu dòng không phải là dòng mới
                if (row.Cells["ma_nha_cung_cap"].Value != null && row.Cells["ma_san_pham"].Value != null)
                {
                    int existingId = Convert.ToInt32(row.Cells["ma_nha_cung_cap"].Value);
                    int existingIdsp = Convert.ToInt32(row.Cells["ma_san_pham"].Value);

                    // Kiểm tra nếu id và idsp trùng
                    if (existingId == id && existingIdsp == idsp)
                    {
                        return true; // Có trùng
                    }
                }
            }
            return false; // Không có trùng
        }
        void them_dgv()
        {
            // Khởi tạo các BLL
            ncc_bll = new nha_cung_cap_sql_BLL();
            sp_bll = new san_pham_sql_BLL();
            if (check_in_put() == false)
            {
                return;
            }
            // Lấy ID nhà cung cấp
            int id = ncc_bll.get_id_ncc(cbb_ncc.SelectedItem.ToString());

            // Lấy ID sản phẩm
            int idsp = sp_bll.get_id_sp_by_name(cbb_tensp.SelectedItem.ToString());

            if (IsDuplicateEntry(id, idsp) != true)

            {


                // Kiểm tra nếu cbb_ncc và cbb_tensp có giá trị hợp lệ
                if (id != 0 && idsp != 0)
                {
                    // Thêm dòng vào DataGridView
                    dgv_sp_add.Rows.Add(id, idsp, int.Parse(cbb_sl.SelectedItem.ToString()), txt_gianhap.Text);
                    UpdateDataGridView();
                    capNhatTongTien();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp và sản phẩm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mã sản phẩm và mã nhà cung cấp trùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        void RemoveSelectedRowFromDataGridView()
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgv_sp_add.SelectedRows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng đã chọn không?",
                                               "Xác nhận xóa",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                // Nếu người dùng chọn Yes, thực hiện xóa
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow selectedRow in dgv_sp_add.SelectedRows)
                    {
                        // Kiểm tra xem dòng có phải là dòng mới (dòng không lưu)
                        if (!selectedRow.IsNewRow)
                        {
                            MessageBox.Show("Xóa thành công.", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgv_sp_add.Rows.Remove(selectedRow);
                            UpdateDataGridView();
                            capNhatTongTien();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Cbb_sl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tinh_gia();
        }
        bool check_in_put()
        {
            if (cbb_tensp.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần nhập hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbb_ncc.SelectedIndex == -1)
            {
                MessageBox.Show("Nhà cung cấp không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbb_sl.SelectedIndex == 0 || cbb_sl.SelectedIndex == -1 || int.Parse(cbb_sl.SelectedItem.ToString()) < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị > 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Cbb_ncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_sl.SelectedIndex = 0;
            if (cbb_ncc.SelectedIndex == -1)
            {
                if (cbb_tensp.SelectedIndex != -1)
                {
                    sp_bll = new san_pham_sql_BLL();
                    load_cbb_ncc(sp_bll.get_id_sp_by_name(cbb_tensp.SelectedItem.ToString()));
                    tinh_gia();
                }
                txt_dg.Text = "0";
                return;
            }
            load_gia();


        }
        void dgv_sp()
        {
            dgv_sp_add.Columns.Clear();

            // Thêm các cột mới
            dgv_sp_add.Columns.Add("ma_nha_cung_cap", "Mã nhà cung cấp");
            dgv_sp_add.Columns.Add("ma_san_pham", "Mã sản phẩm");
            dgv_sp_add.Columns.Add("so_luong", "Số lượng");
            dgv_sp_add.Columns.Add("gia_nhap", "Tổng giá");

            // Thiết lập chế độ tự động cho các cột
            int columnWidth = dgv_sp_add.Width / dgv_sp_add.Columns.Count; // Chiều rộng bằng nhau
            foreach (DataGridViewColumn column in dgv_sp_add.Columns)
            {
                column.Width = columnWidth;
            }
            dgv_sp_add.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả dòng
            dgv_sp_add.MultiSelect = false;
            dgv_sp_add.ReadOnly = true;
        }
        private void Cbb_tensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_ncc.Properties.Items.Clear();
            cbb_ncc.SelectedIndex = -1;
            txt_dg.Text = "0";
            cbb_sl.SelectedIndex = 0;
            try
            {
                if (cbb_tensp.SelectedItem != null)
                {

                    sp_bll = new san_pham_sql_BLL();
                    int? id = sp_bll.get_id_sp_by_name(cbb_tensp.SelectedItem.ToString());

                    if (id.HasValue)
                    {

                        load_dgv_sp_ss(id.Value);

                        load_cbb_ncc(id.Value);
                        tinh_gia();
                    }
                    else
                    {

                    }


                }
                else
                {

                    txt_dg.Text = "";
                    cbb_ncc.Properties.Items.Clear();
                    cbb_ncc.SelectedIndex = -1;
                    cbb_sl.SelectedIndex = 0;
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        void load_cbb_sp()
        {
            sp_bll = new san_pham_sql_BLL();
            List<string> ctsp = sp_bll.get_sp_all_name();
            cbb_tensp.Properties.Items.Clear();
            cbb_tensp.Properties.Items.AddRange(ctsp);
        }
        void load_dgv_sp_ss(int id)
        {


            InitializeColumns(id);
        }
        void load_gia()
        {


            // Kiểm tra nếu không có dòng nào trong DataGridView thì thoát hàm
            if (dgv_gia.Rows.Count == 0)
            {
                txt_dg.Text = "0";
                return;
            }

            // Lấy giá trị cần tìm từ cbb_ncc
            string selectedValue = cbb_ncc.SelectedItem?.ToString();

            // Sử dụng LINQ để tìm dòng có giá trị "ten_nha_cung_cap" phù hợp
            var foundRow = dgv_gia.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(row => row.Cells["ten_nha_cung_cap"].Value?.ToString()
                .Equals(selectedValue, StringComparison.OrdinalIgnoreCase) == true);

            if (foundRow != null)
            {
                // Nếu tìm thấy dòng, lấy giá trị "gia_cung_cap"
                txt_dg.Text = foundRow.Cells["gia_cung_cap"].Value?.ToString();
            }
            else
            {
                // Nếu không tìm thấy dòng nào phù hợp
                txt_dg.Text = "0";
            }

        }

        private void InitializeColumns(int id)
        {

            nccsp_bll = new ncc_sp_sql_BLL();
            dgv_gia.DataSource = nccsp_bll.get_nccsp_by_id_sp(id);

            // Đặt tên tiêu đề cho các cột hiện có hoặc đã tạo
            dgv_gia.Columns["ten_nha_cung_cap"].HeaderText = "Tên Nhà Cung Cấp";
            dgv_gia.Columns["ten_san_pham"].HeaderText = "Tên Sản Phẩm";
            dgv_gia.Columns["gia_cung_cap"].HeaderText = "Giá Cung Cấp";

            // Căn chỉnh các cột
            dgv_gia.Columns["ten_nha_cung_cap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_gia.Columns["ten_san_pham"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_gia.Columns["gia_cung_cap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Căn chỉnh tiêu đề các cột
            dgv_gia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Đặt chiều rộng cột cho hợp lý
            dgv_gia.Columns["ten_nha_cung_cap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_gia.Columns["ten_san_pham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_gia.Columns["gia_cung_cap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Đảm bảo chiều rộng cố định cho các cột
            dgv_gia.Columns["ten_nha_cung_cap"].Width = 200;
            dgv_gia.Columns["ten_san_pham"].Width = 200;
            dgv_gia.Columns["gia_cung_cap"].Width = 150;
        }
        private void Cbb_tensp_TextChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBoxEdit;
            var filterText = comboBox.Text.ToLower();
            sp_bll = new san_pham_sql_BLL();
            List<string> ctsp = sp_bll.get_sp_all_name();

            var filteredItems = ctsp
                .Where(item => item.ToLower().Contains(filterText))
                .ToList();

            comboBox.Properties.Items.BeginUpdate();
            comboBox.Properties.Items.Clear();
            comboBox.Properties.Items.AddRange(filteredItems);
            comboBox.Properties.Items.EndUpdate();

            comboBox.ShowPopup();
        }
        private void Cbb_ncc_TextChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBoxEdit;
            var filterText = comboBox.Text.ToLower();

            // Kiểm tra nếu không có mục nào được chọn trong cbb_tensp
            if (cbb_tensp.SelectedItem == null || string.IsNullOrEmpty(filterText))
            {
                return;
            }

            // Khởi tạo BLL và lấy danh sách tên nhà cung cấp
            nccsp_bll = new ncc_sp_sql_BLL();
            List<string> ncc = nccsp_bll.get_list_name_ncc_id_sp(sp_bll.get_id_sp_by_name(cbb_tensp.SelectedItem.ToString()));

            // Lọc danh sách nhà cung cấp theo filterText
            var filteredItems = ncc
                .Where(item => item.ToLower().Contains(filterText))
                .ToList();

            // Cập nhật lại danh sách trong ComboBoxEdit
            comboBox.Properties.Items.BeginUpdate();
            comboBox.Properties.Items.Clear();
            comboBox.Properties.Items.AddRange(filteredItems);
            comboBox.Properties.Items.EndUpdate();

            // Hiển thị popup với các mục đã lọc
            comboBox.ShowPopup();
        }
        void tinh_gia()
        {
            // Kiểm tra xem người dùng đã chọn nhà cung cấp và số lượng hay chưa
            if (cbb_ncc.SelectedIndex != -1 && cbb_sl.SelectedIndex != -1)
            {
                // Khai báo biến để lưu trữ giá trị
                double price;
                int quantity;

                // Kiểm tra và chuyển đổi giá trị từ txt_dg
                // Sử dụng Trim() để loại bỏ khoảng trắng không cần thiết
                string priceText = txt_dg.Text.Trim();
                string quantityText = cbb_sl.SelectedItem.ToString().Trim();

                // Chuyển đổi giá trị và xử lý lỗi
                if (double.TryParse(priceText, out price) && int.TryParse(quantityText, out quantity))
                {
                    // Tính giá nhập và gán vào txt_gianhap
                    double totalPrice = price * quantity;

                    // Định dạng giá nhập để loại bỏ số 0 không cần thiết
                    txt_gianhap.Text = totalPrice.ToString("0.##"); // Định dạng với tối đa 2 chữ số thập phân
                }
                else
                {
                    // Nếu giá trị không hợp lệ, gán giá trị mặc định cho txt_gianhap
                    txt_gianhap.Text = "0"; // Gán giá trị 0 nếu không hợp lệ
                    MessageBox.Show("Giá và số lượng phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Nếu không có lựa chọn nào, gán giá trị mặc định cho txt_gianhap
                txt_gianhap.Text = "0"; // Gán giá trị 0 nếu không có lựa chọn
            }

            // Loại bỏ số .00 từ txt_dg nếu không cần thiết
            if (decimal.TryParse(txt_dg.Text, out decimal currentPrice))
            {
                txt_dg.Text = currentPrice.ToString("0.##"); // Hiển thị giá mà không có phần thập phân nếu nó bằng 0
            }
        }
        void capNhatTongTien()
        {
            decimal tongTien = 0; // Biến để lưu tổng tiền

            // Lặp qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dgv_sp_add.Rows)
            {
                // Kiểm tra xem dòng có giá trị không (tránh dòng trống)
                if (row.Cells["gia_nhap"].Value != null)
                {
                    // Lấy giá trị từ cột gia_nhap và cộng dồn vào tongTien
                    decimal giaNhap;
                    if (decimal.TryParse(row.Cells["gia_nhap"].Value.ToString(), out giaNhap))
                    {
                        tongTien += giaNhap;
                    }
                }
            }

            // Gán tổng tiền vào label
            lb_thanhtien.Text = "Tổng tiền: " + tongTien.ToString(); // Định dạng với 2 chữ số thập phân
        }
        void setDeflau()
        {

            nhan_vien_sql_BLL nv = new nhan_vien_sql_BLL();

            date_ngaynhap.Value = DateTime.Now;
            date_ngaynhap.Enabled = false;



            txt_tennv.Text = nv.get_name_nv_by_id(id_nv);
            txt_tennv.Enabled = false;
            lb_thanhtien.Text = lb_thanhtien.Text + " 0";
            cbb_sl.Properties.Items.Clear();
            txt_dg.Text = "0";

            // Thêm số từ 100 đến 1000 với khoảng cách 100
            for (int i = 0; i <= 1000; i += 100)
            {
                cbb_sl.Properties.Items.Add(i);
            }
            cbb_sl.SelectedIndex = 0;
            cbb_sl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // Đặt màu nền và viền cho DataGridView
            dgv_gia.BackgroundColor = Color.White;
            // Màu viền giữa các ô

            dgv_sp_add.BackgroundColor = Color.White;



        }
        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            load_cbb_sp();
            setDeflau();
            load_gia();
            dgv_sp();
            capNhatTongTien();
            InitializeColumns(0);
          
            CustomizeDataGridView(dgv_gia);
            CustomizeDataGridView(dgv_sp_add);

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
        void load_cbb_ncc(int id)
        {
            nccsp_bll = new ncc_sp_sql_BLL();
            List<string> ncc = nccsp_bll.get_list_name_ncc_id_sp(id);
            cbb_ncc.Properties.Items.Clear();
            cbb_ncc.Properties.Items.AddRange(ncc);
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
