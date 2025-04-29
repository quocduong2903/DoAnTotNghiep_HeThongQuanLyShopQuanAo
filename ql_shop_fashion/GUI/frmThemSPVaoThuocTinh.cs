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
using DTO;
using BLL;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;


namespace GUI
{
    public partial class frmThemSPVaoThuocTinh : DevExpress.XtraEditors.XtraForm
    {
        private san_pham_sql_BLL sp_bll;
        private thuoc_tinh_sp_sql_BLL thuoc_tinh_bll;
        private size_sql_BLL size_bll;
        private mau_sac_sql_BLL mau_sac_bll;
        public frmThemSPVaoThuocTinh()
        {
            InitializeComponent();
            this.Load += FrmThemSPVaoThongTin_Load;
            thuoc_tinh_bll = new thuoc_tinh_sp_sql_BLL();
            mau_sac_bll = new mau_sac_sql_BLL();
            size_bll = new size_sql_BLL();
            sp_bll = new san_pham_sql_BLL();

            btn_themspvaott.ItemClick += Btn_themspvaott_ItemClick;
            btn_xoaspkhoitt.ItemClick += Btn_xoaspkhoitt_ItemClick;
            btn_suasptrongtt.ItemClick += Btn_suasptrongtt_ItemClick;
            btn_load.ItemClick += Btn_load_ItemClick;

            GridView gv_ttsp = gct_ttsp.MainView as GridView;
            gv_ttsp.Click += Gv_ttsp_Click;
        }

        private void Btn_load_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clear();
        }

        private void Btn_suasptrongtt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suaSPTrongTT();
        }

        private void Btn_xoaspkhoitt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoaSPKhoiTT();
        }

        private void Btn_themspvaott_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themSPVaoTT();
        }

        private void Gv_ttsp_Click(object sender, EventArgs e)
        {
            loadTTSPLenControls();
        }


        private void FrmThemSPVaoThongTin_Load(object sender, EventArgs e)
        {
            loadThuocTinhSP();
            loadSizeVaMSLenComboBox();
            loadMaSanPhamLenCombobox();
        }


        private void loadThuocTinhSP()
        {
            try
            {
                var bll = new thuoc_tinh_sp_sql_BLL();
                var productList = bll.GetAllProducts();

                // Gắn dữ liệu vào GridControl hoặc DataGridView
                gct_ttsp.DataSource = productList;

                // Cấu hình GridView để ẩn các cột không mong muốn
                GridView gridView = gct_ttsp.MainView as GridView;
                if (gridView != null)
                {
                    gridView.OptionsBehavior.Editable = false;

                    gridView.Columns["ten_kich_thuoc"].Visible = false; // Ẩn cột tên kích thước
                    gridView.Columns["ten_mau_sac"].Visible = false; // Ẩn cột tên màu sắc
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void loadSizeVaMSLenComboBox()
        {
            try
            {
                // Khởi tạo BLL
                var sizeBll = new size_sql_BLL();
                var mausacBll = new mau_sac_sql_BLL();

                // Load danh sách kích thước
                var kichThuocList = sizeBll.get_all_size();
                cbb_makichthuoc.Properties.Items.Clear();
                foreach (var item in kichThuocList)
                {
                    cbb_makichthuoc.Properties.Items.Add(item.ma_kich_thuoc);
                }

                if (cbb_makichthuoc.Properties.Items.Count > 0)
                    cbb_makichthuoc.SelectedIndex = 0;

                // Load danh sách màu sắc
                var mauSacList = mausacBll.get_all_mau_sac();
                cbb_mamausac.Properties.Items.Clear();
                foreach (var item in mauSacList)
                {
                    cbb_mamausac.Properties.Items.Add(item.ma_mau_sac);
                }

                if (cbb_mamausac.Properties.Items.Count > 0)
                    cbb_mamausac.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadMaSanPhamLenCombobox()
        {
            try
            {
                List<san_pham_DTO> List = sp_bll.get_all_sp_DTO();

                // Xóa các item cũ
                cbb_masanpham.Properties.Items.Clear();

                // Thêm dữ liệu vào ComboBoxEdit thủ công
                foreach (var nhomLoai in List)
                {
                    cbb_masanpham.Properties.Items.Add(nhomLoai.ma_san_pham);
                }

                // Không chọn mục nào mặc định
                cbb_masanpham.EditValue = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void loadTTSPLenControls()
        {
            GridView gridView = gct_ttsp.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                // Get the selected "ma_san_pham" and "ma_thong_tin_san_pham"
                string maTTSanPham = Convert.ToString(gridView.GetFocusedRowCellValue("ma_thuoc_tinh"));
                int maSanPham = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_san_pham"));
                int maSize = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_kich_thuoc"));
                int maMauSac = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_mau_sac"));
                string soluongton = Convert.ToString(gridView.GetFocusedRowCellValue("so_luong_ton"));
                string giaban = Convert.ToString(gridView.GetFocusedRowCellValue("gia_ban"));

                // Set the combo box values based on the selected row
                txt_mathuoctinh.Text = maTTSanPham;
                cbb_masanpham.EditValue = maSanPham;
                cbb_makichthuoc.EditValue = maSize;
                cbb_mamausac.EditValue = maMauSac;
                txt_soluongton.Text = soluongton;
                txt_giaban.Text = giaban;
            }
        }



        private void clear()
        {
            txt_mathuoctinh.Text = null;
            cbb_masanpham.EditValue = null;
            cbb_makichthuoc.EditValue = null;
            cbb_mamausac.EditValue = null;
            txt_soluongton.Text = null;
            txt_giaban.Text = null;
        }

        private bool kiemTra()
        {

            // Kiểm tra ComboBox Mã Loại
            if (cbb_masanpham.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_masanpham.Focus();
                return false;
            }

            // Kiểm tra ComboBox Mã Thương Hiệu
            if (cbb_makichthuoc.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn mã kích thước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_makichthuoc.Focus();
                return false;
            }

            // Kiểm tra ComboBox Mã Thương Hiệu
            if (cbb_makichthuoc.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn mã màu sắc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_mamausac.Focus();
                return false;
            }
            // Kiểm tra ComboBox Mã Thương Hiệu
            if (txt_soluongton.Text == null)
            {
                XtraMessageBox.Show("Vui lòng điền số lượng tồn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_makichthuoc.Focus();
                return false;
            }

            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }


        private void themSPVaoTT()
        {
            // Kiểm tra dữ liệu đầu vào
            if (!kiemTra())
            {
                return;
            }

            try
            {
                // Tạo BLL
                var bll = new thuoc_tinh_sp_sql_BLL();

                // Tạo đối tượng DTO từ dữ liệu nhập
                var newThuocTinh = new thuoc_tinh_san_pham
                {
                    ma_san_pham = Convert.ToInt32(cbb_masanpham.EditValue), // Lấy mã sản phẩm từ ComboBox
                    ma_kich_thuoc = Convert.ToInt32(cbb_makichthuoc.EditValue), // Lấy mã kích thước từ ComboBox
                    ma_mau_sac = Convert.ToInt32(cbb_mamausac.EditValue), // Lấy mã màu sắc từ ComboBox
                    so_luong_ton = Convert.ToInt32(txt_soluongton.Text) // Chuyển đổi số lượng tồn từ TextBox
                };

                // Gọi BLL để thêm thuộc tính sản phẩm
                if (bll.addThuocTinhSanPham(newThuocTinh))
                {
                    // Thêm thành công
                    XtraMessageBox.Show("Thêm thuộc tính sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadThuocTinhSP();
                    clear();
                }
                else
                {
                    // Thêm thất bại
                    XtraMessageBox.Show("Thêm thuộc tính sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                // Lỗi định dạng dữ liệu
                XtraMessageBox.Show("Dữ liệu nhập vào không hợp lệ! Vui lòng kiểm tra lại.\nChi tiết lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Lỗi chung
                XtraMessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private thong_tin_sanpham_DTO ConvertToThongTinSanPhamDTO(thuoc_tinh_DTO tt)
        {
            return new thong_tin_sanpham_DTO
            {
                ma_thong_tin_san_pham = tt.ma_thuoc_tinh,
                ma_san_pham = tt.ma_san_pham,
                key_attribute = tt.ma_kich_thuoc.ToString(),
                value_attribute = tt.ma_mau_sac.ToString()
            };
        }


        private void suaSPTrongTT()
        {
            try
            {
                // Kiểm tra và lấy giá trị từ các điều khiển
                if (!string.IsNullOrWhiteSpace(txt_mathuoctinh.Text) &&
                    int.TryParse(txt_mathuoctinh.Text, out int maThuocTinh) &&
                    int.TryParse(cbb_masanpham.EditValue?.ToString(), out int maSanPham) &&
                    int.TryParse(cbb_makichthuoc.EditValue?.ToString(), out int maKichThuoc) &&
                    int.TryParse(cbb_mamausac.EditValue?.ToString(), out int maMauSac) &&
                    int.TryParse(txt_soluongton.Text, out int soLuongTon) &&
                    decimal.TryParse(txt_giaban.Text, out decimal giaBan))
                {
                    // Tạo đối tượng thuoc_tinh_DTO
                    var updatedInfo = new thuoc_tinh_DTO
                    {
                        ma_thuoc_tinh = maThuocTinh,
                        ma_san_pham = maSanPham,
                        ma_kich_thuoc = maKichThuoc,
                        ma_mau_sac = maMauSac,
                        so_luong_ton = soLuongTon,
                        gia_ban = giaBan
                    };

                    // Gọi BLL để thực hiện cập nhật
                    if (thuoc_tinh_bll.updateThuocTinhSanPham(updatedInfo))
                    {
                        XtraMessageBox.Show("Cập nhật thuộc tính sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách thuộc tính
                        loadThuocTinhSP();
                        clear();
                    }
                    else
                    {
                        XtraMessageBox.Show("Cập nhật thuộc tính sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void xoaSPKhoiTT()
        {
            try
            {
                // Kiểm tra giá trị từ TextBox
                if (!string.IsNullOrWhiteSpace(txt_mathuoctinh.Text) &&
                    int.TryParse(txt_mathuoctinh.Text, out int maThuocTinh))
                {
                    // Gọi BLL để thực hiện xóa
                    if (thuoc_tinh_bll.deleteThuocTinhSanPham(maThuocTinh))
                    {
                        XtraMessageBox.Show("Xóa thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách thuộc tính
                        loadThuocTinhSP();
                        clear();
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa thông tin sản phẩm thất bại! Không tìm thấy thuộc tính sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng nhập mã thuộc tính hợp lệ để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









    }
}