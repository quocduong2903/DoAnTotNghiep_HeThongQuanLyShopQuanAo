using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
using DevExpress.DataProcessing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;

namespace GUI
{
    public partial class NCC_NCCSP : DevExpress.XtraEditors.XtraUserControl
    {
        private nha_cung_cap_sql_BLL ncc_bll;
        private ncc_sp_sql_BLL ncc_sp_bll;
        public san_pham_sql_BLL sp_bll;
        private int idncc = 0;
        int checkpoin = 0;
        public NCC_NCCSP()
        {
            InitializeComponent();
            this.Load += NCC_NCCSP_Load;
            GridView gridView = gct_dsncc.MainView as GridView;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.Click += GridView_Click;
            bt_them.Click += Bt_them_Click;
            bt_luu.Click += Bt_luu_Click;
            bt_xoa.Click += Bt_xoa_Click;
            bt_load.Click += Bt_load_Click;
            them.Click += Them_Click;
            sua.Click += Sua_Click;
            xoa.Click += Xoa_Click;
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ma_ncc.Text) || !int.TryParse(ma_ncc.Text, out int maNcc))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp hợp lệ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.No)
            {
                return; // Hủy thao tác xóa nếu người dùng chọn "No"
            }

            // Khởi tạo đối tượng BLL
            ncc_bll = new nha_cung_cap_sql_BLL();

            // Thực hiện xóa nhà cung cấp
            bool result = ncc_bll.DeleteNcc(maNcc);

            if (result)
            {
                MessageBox.Show("Xóa nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_data();
                // Làm mới danh sách nhà cung cấp hoặc cập nhật giao diện sau khi xóa
                load_gct(); // Gọi phương thức load_gct để làm mới dữ liệu nhà cung cấp
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa nhà cung cấp.", "Lỗi tồn tại bảng khác", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (!ValidateInput())
            {
                return; // Dừng lại nếu dữ liệu không hợp lệ
            }

            // Tạo đối tượng BLL và đối tượng nha_cung_cap
            ncc_bll = new nha_cung_cap_sql_BLL();
            nha_cung_cap updatedNcc = new nha_cung_cap
            {
                ma_nha_cung_cap = int.Parse(ma_ncc.Text),
                ten_nha_cung_cap = ten_ncc.Text,
                dia_chi = dc.Text,
                dien_thoai = dt.Text
            };

            // Thực hiện cập nhật nhà cung cấp
            bool result = ncc_bll.UpdateNcc(updatedNcc);

            if (result)
            {
                MessageBox.Show("Cập nhật nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_data();
                load_gct();
                return;
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra trường Mã Nhà Cung Cấp
            if (string.IsNullOrWhiteSpace(ma_ncc.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ma_ncc.Focus();
                return false;
            }

            // Kiểm tra xem mã nhà cung cấp có hợp lệ (phải là số nguyên)
            if (!int.TryParse(ma_ncc.Text, out int maNcc))
            {
                MessageBox.Show("Mã nhà cung cấp không hợp lệ. Vui lòng nhập số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ma_ncc.Focus();
                return false;
            }

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

            // Kiểm tra định dạng số điện thoại (giả sử chỉ cho phép 10 chữ số)
            if (!System.Text.RegularExpressions.Regex.IsMatch(dt.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dt.Focus();
                return false;
            }

            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }


       


        private void Them_Click(object sender, EventArgs e)
        {
            them_ncc them = new them_ncc();
            them.SupplierAdded += Them_SupplierAdded;
            them.ShowDialog();
        }

        private void Them_SupplierAdded(object sender, EventArgs e)
        {
            load_gct();
        }

        private void GridView_Click(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView != null)
            {
                // Lấy dữ liệu của dòng hiện tại
                var maNhaCungCap = gridView.GetFocusedRowCellValue("ma_nha_cung_cap")?.ToString();
                var tenNhaCungCap = gridView.GetFocusedRowCellValue("ten_nha_cung_cap")?.ToString();
                var diaChi = gridView.GetFocusedRowCellValue("dia_chi")?.ToString();
                var dienThoai = gridView.GetFocusedRowCellValue("dien_thoai")?.ToString();

                // Gán dữ liệu vào các TextBox
                ma_ncc.Text = maNhaCungCap;
                ten_ncc.Text = tenNhaCungCap;
                dc.Text = diaChi;
                dt.Text = dienThoai;
                idncc = int.Parse(maNhaCungCap);
                load_dgv_nccsp(idncc);
                bt_sua.Click += Bt_sua_Click;

            }
        }

        private void Bt_load_Click(object sender, EventArgs e)
        {
            load_dgv_nccsp(idncc);
        }

        private void Bt_xoa_Click(object sender, EventArgs e)
        {
            GridView gridView = gct_spncc.MainView as GridView;
            if (gridView == null)
                return;

            // Kiểm tra xem có dòng nào được chọn không
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            // Lấy giá trị của các cột "ma_nha_cung_cap" và "ma_san_pham" từ dòng được chọn
            int maNhaCungCap = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_nha_cung_cap"));
            int maSanPham = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_san_pham"));

            // Hiển thị xác nhận trước khi xóa
            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa dòng đã chọn?\nThông tin:\n" +
                $"- Mã nhà cung cấp: {maNhaCungCap}\n" +
                $"- Mã sản phẩm: {maSanPham}",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Gọi phương thức xóa từ lớp DAL
                ncc_sp_bll  = new ncc_sp_sql_BLL();
                bool deleteSuccess = ncc_sp_bll.DeleteNccSpById(maNhaCungCap, maSanPham);

                if (deleteSuccess)
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dòng khỏi GridView và làm mới lại dữ liệu hiển thị
                    gridView.DeleteRow(selectedRowHandle);
                    gct_spncc.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Lỗi tồn tải ở bảng khác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Bt_luu_Click(object sender, EventArgs e)
        {
            if (checkpoin == 1)
            {
                SaveAllDataToDatabase();
              
                return;
            }
            else if (checkpoin == 2)
            {
                SaveUpdatedGiaCungCap();
                return;
            }
            else
            {
                MessageBox.Show("Lỗi sự kiện vui lòng chọn thêm hoặc sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
        }

        private void Bt_them_Click(object sender, EventArgs e)
        {
            sp_bll = new san_pham_sql_BLL();
            AddEmptyRowToGrid(sp_bll.get_all_sp());
            checkpoin = 1;
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //GridView gridView = sender as GridView;
            //if (gridView != null)
            //{
            //    // Lấy dữ liệu của dòng hiện tại
            //    var maNhaCungCap = gridView.GetFocusedRowCellValue("ma_nha_cung_cap")?.ToString();
            //    var tenNhaCungCap = gridView.GetFocusedRowCellValue("ten_nha_cung_cap")?.ToString();
            //    var diaChi = gridView.GetFocusedRowCellValue("dia_chi")?.ToString();
            //    var dienThoai = gridView.GetFocusedRowCellValue("dien_thoai")?.ToString();

            //    // Gán dữ liệu vào các TextBox
            //    ma_ncc.Text = maNhaCungCap;
            //    ten_ncc.Text = tenNhaCungCap;
            //    dc.Text = diaChi;
            //    dt.Text = dienThoai;
            //    idncc = int.Parse(maNhaCungCap);
            //    load_dgv_nccsp(idncc);
            //    bt_sua.Click += Bt_sua_Click;

            //}
        }

        private void Bt_sua_Click(object sender, EventArgs e)
        {

            EnableEditGiaCungCapForSelectedRow();
            checkpoin = 2;
        }
        public void EnableEditGiaCungCapForSelectedRow()
        {
            // Lấy GridView từ GridControl
            GridView gridView = gct_spncc.MainView as GridView;
            if (gridView == null)
                return;

            // Kiểm tra nếu có dòng nào đang được chọn
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để chỉnh sửa.");
                return;
            }

            // Tạo RepositoryItemTextEdit cho cột `gia_cung_cap` để chỉ cho phép nhập số
            RepositoryItemTextEdit repositoryGiaCungCap = new RepositoryItemTextEdit();
            repositoryGiaCungCap.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryGiaCungCap.Mask.EditMask = "n0"; // Định dạng số nguyên, không có chữ số thập phân
            repositoryGiaCungCap.Mask.UseMaskAsDisplayFormat = true;

            // Đăng ký RepositoryItem vào GridControl để sử dụng cho cột `gia_cung_cap`
            gct_spncc.RepositoryItems.Add(repositoryGiaCungCap);
            gridView.Columns["gia_cung_cap"].ColumnEdit = repositoryGiaCungCap; // Gán RepositoryItem cho cột `gia_cung_cap`

            // Bật chế độ cho phép chỉnh sửa toàn bộ GridView
            gridView.OptionsBehavior.Editable = true;

            // Đặt AllowEdit cho tất cả các cột là false trừ "gia_cung_cap"
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = column.FieldName == "gia_cung_cap";
            }

            // Đặt focus vào cột "gia_cung_cap" trong dòng hiện đang chọn và mở chế độ chỉnh sửa
            gridView.FocusedRowHandle = selectedRowHandle;
            gridView.FocusedColumn = gridView.Columns["gia_cung_cap"];
            gridView.ShowEditor();
        }



        public void SaveUpdatedGiaCungCap()
        {
            // Lấy GridView từ GridControl
            GridView gridView = gct_spncc.MainView as GridView;
            if (gridView == null)
                return;

            // Kiểm tra nếu có dòng nào đang được chọn
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để lưu chỉnh sửa.");
                return;
            }

            // Đảm bảo cập nhật giá trị đã chỉnh sửa từ ô vào GridView
            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            // Lấy giá trị của dòng hiện tại từ GridView
            int maNhaCungCap = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_nha_cung_cap") ?? 0);
            int maSanPham = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_san_pham") ?? 0);
            decimal giaCungCap = Convert.ToDecimal(gridView.GetRowCellValue(selectedRowHandle, "gia_cung_cap") ?? 0);

            // Gọi hàm UpdateGiaNhap để lưu thay đổi vào cơ sở dữ liệu
            ncc_sp_bll = new ncc_sp_sql_BLL();
            bool result = ncc_sp_bll.UpdateGiaNhap(maNhaCungCap, maSanPham, giaCungCap);

            // Kiểm tra kết quả và hiển thị thông báo cho người dùng
            if (result)
            {
                MessageBox.Show("Cập nhật giá cung cấp thành công.", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại trạng thái
                checkpoin = 0;

                // Tải lại dữ liệu vào DataGridView để hiển thị thông tin mới
                load_dgv_nccsp(idncc);


                // Xuất thông tin chi tiết của dòng đã cập nhật: ma_nha_cung_cap, ma_san_pham, gia_cung_cap
             

                // Đặt trạng thái GridView về ban đầu (không cho phép chỉnh sửa)
                gridView.OptionsBehavior.Editable = false;
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật giá cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






         



        private void NCC_NCCSP_Load(object sender, EventArgs e)
        {
            load_gct();
            clear_data();
            
        }
        void clear_data()
        {
            ma_ncc.Text = "";
            ten_ncc.Text = "";
            dc.Text = "";
            dt.Text = "";
        }

        void load_gct()
        {
            // Lấy GridView từ GridControl
            GridView gridView = gct_dsncc.MainView as GridView;
            if (gridView == null)
                return;

            // Khởi tạo đối tượng BLL và gán dữ liệu vào GridControl
            ncc_bll = new nha_cung_cap_sql_BLL();
            gct_dsncc.DataSource = ncc_bll.get_all_ncc();

            // Thiết lập các thuộc tính hiển thị cho GridView
            gridView.OptionsBehavior.Editable = false;
            gridView.Columns["ma_nha_cung_cap"].Caption = "Mã Nhà Cung Cấp";
            gridView.Columns["ten_nha_cung_cap"].Caption = "Tên Nhà Cung Cấp";

            // Ẩn các cột không cần thiết
            gridView.Columns["dia_chi"].Visible = false;
            gridView.Columns["dien_thoai"].Visible = false;
            gridView.Columns["created_at"].Visible = false;
            gridView.Columns["updated_at"].Visible = false;

            // Thiết lập độ rộng của các cột
            gridView.Columns["ma_nha_cung_cap"].Width = 150;
            gridView.Columns["ten_nha_cung_cap"].Width = 200;

            // Tắt chế độ Master-Detail nếu không cần thiết và làm mới dữ liệu
            gridView.OptionsDetail.EnableMasterViewMode = false;
            gridView.ClearGrouping();
            gridView.RefreshData();

            // Tắt hiển thị dòng và ô được lấy nét (dòng được chọn)
            gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;

            // Đặt `FocusedRowHandle` về `InvalidRowHandle` và xóa mọi lựa chọn
            gridView.FocusedRowHandle = GridControl.InvalidRowHandle;
            gridView.ClearSelection();

            // Sử dụng `BeginInvoke` để đảm bảo không có dòng nào được chọn sau khi dữ liệu đã tải
            gridView.GridControl.BeginInvoke(new Action(() =>
            {
                gridView.FocusedRowHandle = GridControl.InvalidRowHandle;
                gridView.ClearSelection();
            }));
            load_dgv_nccsp(0);
        }


        void load_dgv_nccsp(int id)
        {
            // Khởi tạo đối tượng BLL nếu chưa có
            ncc_sp_bll = new ncc_sp_sql_BLL();

            // Xóa dữ liệu và cấu hình hiện tại của `GridControl` trước khi tải mới
            gct_spncc.DataSource = null; // Xóa dữ liệu cũ nếu có
            GridView gridView = new GridView(gct_spncc); // Tạo mới `GridView`
            gct_spncc.MainView = gridView; // Gán `GridView` mới cho `GridControl`

            // Gán dữ liệu cho GridControl
            gct_spncc.DataSource = ncc_sp_bll.get_sp_nccsp_by_id(id);

            // Đặt các tùy chọn không cho phép chỉnh sửa dữ liệu trong GridView
            gridView.OptionsBehavior.Editable = false;

            // Thiết lập cột và cấu hình hiển thị
            gridView.Columns.Clear(); // Xóa các cột cũ để tránh xung đột

            // Thêm cột "ma_san_pham"
            var maSPColumn = gridView.Columns.AddVisible("ma_san_pham", "Mã Sản Phẩm");
            maSPColumn.Width = 100;
            maSPColumn.VisibleIndex = 0;

            // Thêm cột "ten_san_pham"
            var tenSPColumn = gridView.Columns.AddVisible("ten_san_pham", "Tên Sản Phẩm");
            tenSPColumn.Width = 200;
            tenSPColumn.VisibleIndex = 1;

            // Thêm cột "gia_cung_cap"
            var giaCungCapColumn = gridView.Columns.AddVisible("gia_cung_cap", "Giá Cung Cấp");
            giaCungCapColumn.Width = 150;
            giaCungCapColumn.VisibleIndex = 2;

            // Ẩn các cột không cần thiết
            gridView.Columns.AddField("created_at").Visible = false;
            gridView.Columns.AddField("ma_nha_cung_cap").Visible = false;
            gridView.Columns.AddField("updated_at").Visible = false;
            gridView.Columns.AddField("nha_cung_cap").Visible = false;
            gridView.Columns.AddField("san_pham").Visible = false;

            // Tự động điều chỉnh chiều rộng của tất cả các cột dựa trên nội dung của chúng
            gridView.BestFitColumns();

            // Làm mới lại `GridView` để cập nhật giao diện
            gridView.RefreshData();
        }

        public void AddEmptyRowToGrid(List<san_pham_custom> sanPhamList)
        {
            // Lấy GridView từ GridControl
            GridView gridView = gct_spncc.MainView as GridView;
            if (gridView == null)
                return;

            // Tạo RepositoryItemLookUpEdit cho ComboBox trong cột `ma_san_pham`
            RepositoryItemLookUpEdit repositoryComboBoxMaSP = new RepositoryItemLookUpEdit
            {
                DataSource = sanPhamList,
                DisplayMember = "ma_san_pham", // Hiển thị mã sản phẩm sau khi chọn
                ValueMember = "ma_san_pham",   // Giá trị là mã sản phẩm khi chọn
                NullText = "Chọn sản phẩm",
                AutoHeight = true
            };

            // Thiết lập cột hiển thị cả mã và tên sản phẩm trong danh sách ComboBox
            repositoryComboBoxMaSP.PopulateColumns();
            repositoryComboBoxMaSP.Columns["ma_san_pham"].Visible = true;
            repositoryComboBoxMaSP.Columns["ten_san_pham"].Visible = true;
            repositoryComboBoxMaSP.Columns["ma_san_pham"].Caption = "Mã Sản Phẩm";
            repositoryComboBoxMaSP.Columns["ten_san_pham"].Caption = "Tên Sản Phẩm";
            repositoryComboBoxMaSP.Columns["gia_binh_quan"].Caption = "Giá Bình Quân";
            repositoryComboBoxMaSP.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            // Kích hoạt tìm kiếm theo nhiều cột và tự động hoàn tất
            repositoryComboBoxMaSP.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            repositoryComboBoxMaSP.AutoSearchColumnIndex = 1;
            repositoryComboBoxMaSP.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            // Đăng ký RepositoryItem vào GridControl
            gct_spncc.RepositoryItems.Add(repositoryComboBoxMaSP);

            // Tạo RepositoryItemTextEdit cho cột `gia_cung_cap` để chỉ cho phép nhập số
            RepositoryItemTextEdit repositoryGiaCungCap = new RepositoryItemTextEdit();
            repositoryGiaCungCap.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryGiaCungCap.Mask.EditMask = "n0"; // Định dạng số nguyên, không có chữ số thập phân
            repositoryGiaCungCap.Mask.UseMaskAsDisplayFormat = true;

            // Đăng ký RepositoryItem cho GridControl
            gct_spncc.RepositoryItems.Add(repositoryGiaCungCap);

            // Kiểm tra nếu `DataSource` là một danh sách (`List` hoặc `BindingList`)
            var dataSource = gct_spncc.DataSource as IList<nha_cung_cap_san_pham>;
            if (dataSource != null)
            {
                // Tạo một đối tượng mới và thêm vào danh sách nguồn dữ liệu
                nha_cung_cap_san_pham newRow = new nha_cung_cap_san_pham();
                dataSource.Add(newRow);

                // Cập nhật lại GridControl để hiển thị dòng mới
                gct_spncc.RefreshDataSource();

                // Đặt focus vào dòng mới để người dùng có thể bắt đầu nhập liệu
                int newRowHandle = gridView.GetRowHandle(dataSource.Count - 1);
                gridView.FocusedRowHandle = newRowHandle;

                // Gán RepositoryItem cho cột "ma_san_pham" chỉ trong dòng mới
                gridView.CustomRowCellEdit += (sender, e) =>
                {
                    if (e.RowHandle == newRowHandle && e.Column.FieldName == "ma_san_pham")
                    {
                        e.RepositoryItem = repositoryComboBoxMaSP;
                    }
                    else if (e.RowHandle == newRowHandle && e.Column.FieldName == "gia_cung_cap")
                    {
                        e.RepositoryItem = repositoryGiaCungCap;
                    }
                };

                // Xử lý sự kiện EditValueChanged để gán mã sản phẩm khi chọn trong ComboBox
                repositoryComboBoxMaSP.EditValueChanged += (sender, e) =>
                {
                    var edit = sender as LookUpEdit;
                    if (edit != null && gridView.FocusedRowHandle == newRowHandle)
                    {
                        var selectedMaSanPham = edit.EditValue;

                        // Gán mã sản phẩm vào cột "ma_san_pham" trong dòng mới
                        gridView.SetRowCellValue(newRowHandle, "ma_san_pham", selectedMaSanPham);

                        var selectedProduct = sanPhamList.FirstOrDefault(p => p.ma_san_pham.Equals(selectedMaSanPham));
                        if (selectedProduct != null)
                        {
                            gridView.SetRowCellValue(newRowHandle, "ten_san_pham", selectedProduct.ten_san_pham);
                        }
                    }
                };

                // Đặt chế độ cho phép chỉnh sửa trên GridView
                gridView.OptionsBehavior.Editable = true;
            }
            else
            {
                MessageBox.Show("DataSource của GridControl không phải là List hoặc BindingList.");
            }
        }

        public void SaveAllDataToDatabase()
        {
            // Lấy GridView từ GridControl
            GridView gridView = gct_spncc.MainView as GridView;
            if (gridView == null)
                return;

            // Buộc GridView xác nhận thay đổi hiện tại để lưu giá trị mới nhất
            gridView.CloseEditor();
            gridView.UpdateCurrentRow();

            // Tạo danh sách để lưu các sản phẩm từ GridControl
            List<nha_cung_cap_san_pham> productList = new List<nha_cung_cap_san_pham>();

            // Duyệt qua tất cả các dòng trong GridControl và thu thập dữ liệu
            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                // Lấy dữ liệu từ từng dòng
                int? maSanPham = gridView.GetRowCellValue(i, "ma_san_pham") as int?;
                string tenSanPham = gridView.GetRowCellValue(i, "ten_san_pham") as string;
                decimal? giaCungCap = gridView.GetRowCellValue(i, "gia_cung_cap") as decimal?;
                int? maNhaCungCap = gridView.GetRowCellValue(i, "ma_nha_cung_cap") as int?;

                if (maSanPham.HasValue && maNhaCungCap.HasValue)
                {
                    // Tạo đối tượng nha_cung_cap_san_pham và thêm vào danh sách
                    nha_cung_cap_san_pham product = new nha_cung_cap_san_pham
                    {
                        ma_san_pham = maSanPham.Value,
                        ten_san_pham = tenSanPham,
                        gia_cung_cap = giaCungCap ?? 0,
                        ma_nha_cung_cap = idncc
                    };
                    productList.Add(product);
                }
            }

       

            // Tạo instance của BLL và gọi hàm lưu
            ncc_sp_bll = new ncc_sp_sql_BLL();
            bool result = ncc_sp_bll.SaveProducts(productList);

            // Hiển thị thông báo kết quả
            if (result)
            {
                MessageBox.Show("Lưu dữ liệu thành công!","Chúc mừng",MessageBoxButtons.OK,MessageBoxIcon.Information);
                load_dgv_nccsp(idncc);
                checkpoin = 0;
                return;
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình lưu dữ liệu.");
                return;
            }
        }

        
    }
}
