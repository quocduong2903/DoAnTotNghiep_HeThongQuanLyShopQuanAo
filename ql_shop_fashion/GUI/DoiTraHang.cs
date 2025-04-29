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
using DTO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class DoiTraHang : DevExpress.XtraEditors.XtraForm
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        hoa_don_doi_tra_BLL doitraBLL = new hoa_don_doi_tra_BLL();
        chi_tiet_hoa_don_BLL cthd_BLL = new chi_tiet_hoa_don_BLL();
        chi_tiet_hoa_don_doi_tra_BLL cthddt_BLL = new chi_tiet_hoa_don_doi_tra_BLL();
        BLL.thuoc_tinh_sp_sql_BLL ttsp_bll = new BLL.thuoc_tinh_sp_sql_BLL();
        phuong_thuc_thanh_toan_BLL pttt = new phuong_thuc_thanh_toan_BLL();
        nhan_vien_sql_BLL nv = new nhan_vien_sql_BLL();
        int id_nv;
        public DoiTraHang(int idnv)
        {
            InitializeComponent();
            id_nv = idnv;
            txtNhanVien.Text = nv.get_name_nv_by_id(id_nv);
            this.Load += DoiTraHang_Load;
            btnQuetMaTimHD.Click += BtnQuetMaTimHD_Click;
            btnThemSP.Click += BtnThemSP_Click;
           
            dgvChiTietHD.RowCellClick += DgvChiTietHD_RowCellClick;
            dgvChiTietHD.CellValueChanged += DgvChiTietHD_CellValueChanged;
            dgvDS.FocusedRowChanged += DgvDS_FocusedRowChanged;
            btnThemSPTra.Click += BtnThemSPTra_Click;
            btnThanhToan.Click += BtnThanhToan_Click1;
            txtTienSauKhiDoiTra.TextChanged += TxtTienSauKhiDoiTra_TextChanged;
            txtMaHoaDon.TextChanged += TxtMaHoaDon_TextChanged;
            txtMaHoaDon.KeyDown += TxtMaHoaDon_KeyDown;
            
        }

        private void TxtMaHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Thực hiện logic khi nhấn Enter
                string maHD = txtMaHoaDon.Text;
                int maNV = id_nv;
                int maPT = 1;
                if (!string.IsNullOrEmpty(maHD))
                {
                    try
                    {
                        int kqThemHDDoiTra;
                        try
                        {


                            kqThemHDDoiTra = doitraBLL.ThemHoaDonDoiTra(maHD, maNV, maPT, DateTime.Now);
                            if (kqThemHDDoiTra == -1)
                            {

                                loadForm();

                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Xử lý ngoại lệ và hiển thị thông báo lỗi
                            //MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (ex.Message.Contains("The transaction ended in the trigger"))
                            {
                                // Tìm vị trí cắt
                                int endIndex = ex.Message.IndexOf("!");

                                // Trích xuất phần bỏ đi
                                string errorMessage = ex.Message.Substring(0, endIndex).Trim();

                                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy hóa đơn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }    

                            //loadForm();
                            
                            return;
                        }
                        // Gọi phương thức trong BLL hoặc DAL để lấy thông tin hóa đơn
                        object thongTinHoaDon = doitraBLL.LayThongTinHoaDon(maHD);

                        if (thongTinHoaDon != null)
                        {
                            BindingList<ChiTietHoaDon> chiTietList = cthd_BLL.layChiTietHoaDonB(int.Parse(maHD));

                            // Gán BindingList vào GridControl
                            dgvChiTietHoaDon.DataSource = chiTietList;
                            // Sử dụng Reflection để lấy thông tin từ object ẩn danh và hiển thị cho người dùng
                            var maHoaDon = thongTinHoaDon.GetType().GetProperty("ma_hoa_don").GetValue(thongTinHoaDon, null);
                            var maKhachHang = thongTinHoaDon.GetType().GetProperty("ma_khach_hang").GetValue(thongTinHoaDon, null);
                            var ngayLap = thongTinHoaDon.GetType().GetProperty("ngay_lap").GetValue(thongTinHoaDon, null);
                            var maNhanVien = thongTinHoaDon.GetType().GetProperty("ma_nhan_vien").GetValue(thongTinHoaDon, null);
                            var tongGiaTri = thongTinHoaDon.GetType().GetProperty("tong_gia_tri").GetValue(thongTinHoaDon, null);
                            var tienDoiDiem = thongTinHoaDon.GetType().GetProperty("tien_doi_diem").GetValue(thongTinHoaDon, null);
                            txtMaHoaDon.Text = maHoaDon.ToString();
                            txtMaKhachHang.Text = maKhachHang == null ? "" : maKhachHang.ToString();
                            txtMaNV.Text = maNhanVien.ToString();
                            txtNgayLap.Text = ngayLap.ToString();
                            txtTongTien.Text = tongGiaTri.ToString();
                            txtTienDoiDiem.Text = tienDoiDiem == null ? "" : tienDoiDiem.ToString();
                        }
                        else
                        {
                            MessageBox.Show("lỗi");

                            return;
                        }


                    }
                    catch (Exception ex)
                    {

                        IsProcessing = false;
                        return;
                    }
                }

            }
        }

        private bool IsProcessing = false; // Flag để kiểm tra trạng thái xử lý
        private void loadForm()
        {
            txtMaHoaDon.Text = string.Empty;
            txtMaKhachHang.Text = string.Empty;
            txtMaNV.Text = string.Empty;
            txtNgayLap.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtTienDoiDiem.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtTienSauKhiDoiTra.Text = string.Empty;
            txtTienDoiDiem.Text = string.Empty;
            txtTienPhaiTraKhach.Text = string.Empty;
            txtTienPhaiTra.Text = string.Empty;
            txtKhachThanhToan.Text = string.Empty;
            dgvChiTietHoaDon.DataSource = null;
        }
        private void TxtMaHoaDon_TextChanged(object sender, EventArgs e)
        {

            
           
            




        }

        private decimal tinhTienKhachTra()
        {
            decimal tong = 0;
            for (int i = 0; i < dgvChiTietHD.RowCount; i++)
            {
                // Lấy các giá trị từ các cột trong dòng

                string trangThai = Convert.ToString(dgvChiTietHD.GetRowCellValue(i, "trang_thai"));
                decimal thanh_tien = Convert.ToDecimal(dgvChiTietHD.GetRowCellValue(i, "thanh_tien"));
                
                // Kiểm tra nếu cột trang_thai có giá trị là "trả hàng"
                if (trangThai == "đổi hàng")
                {
                    tong += thanh_tien;
                }
            }
            return tong;
        }

        private decimal tinhTienKhachCanThanhToan()
        {
            decimal tong = 0;
            for (int i = 0; i < dgvChiTietHD.RowCount; i++)
            {
                // Lấy các giá trị từ các cột trong dòng

                string trangThai = Convert.ToString(dgvChiTietHD.GetRowCellValue(i, "trang_thai"));
                decimal thanh_tien = Convert.ToDecimal(dgvChiTietHD.GetRowCellValue(i, "thanh_tien"));

                // Kiểm tra nếu cột trang_thai có giá trị là "trả hàng"
                if (trangThai == "trả hàng")
                {
                    tong += thanh_tien;
                }
            }
            return tong;
        }
        private void Tinh()
        {
            // Đổi chỗ gán giá trị giữa txtTienPhaiTra và txtTienPhaiTraKhach
            txtTienPhaiTraKhach.Text = tinhTienKhachCanThanhToan().ToString("F2");
            txtTienPhaiTra.Text =  tinhTienKhachTra().ToString("F2");

            decimal tienPhaiTra = tinhTienKhachTra() - tinhTienKhachCanThanhToan();

            // Kiểm tra nếu tiền là âm
            if (tienPhaiTra < 0)
            {
                // Nếu tiền âm, chuyển thành dương
                tienPhaiTra = Math.Abs(tienPhaiTra);
                layThanhToan.Text = "Tiền hoàn lại: ";
                // Đổi label của txtKhachThanhToan thành "Tiền phải trả khách"
                txtKhachThanhToan.Text =  tienPhaiTra.ToString("F2");
                
            }
            else
            {
                layThanhToan.Text = "Tiền khách cần thanh toán: ";
                // Nếu tiền không âm, hiển thị bình thường
                txtKhachThanhToan.Text = tienPhaiTra.ToString("F2");
                
            }
        }
        private void TxtTienSauKhiDoiTra_TextChanged(object sender, EventArgs e)
        {
            Tinh();
        }




        private void DgvChiTietHD_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            TinhTongTien();
            Tinh();
        }

        private void Cbokich_thuoc1_EditValueChanged(object sender, EventArgs e)
        {
           
            string maTT = txtMaSanPham.Text;
            //hienThiTextBoxTheoKichThuoc(maKichThuoc, maTT);
        }
        public void ShowReport(int ma)
        {
            HoaDonDoiTra report = new HoaDonDoiTra();

            // Thiết lập giá trị cho parameter
            report.Parameters["ma_hoa_don"].Value = ma;

            report.RequestParameters = false;

            // Hiển thị report
            ReportPrintTool printTool = new ReportPrintTool(report);
            // Chỉ hiển thị trang đầu tiên
            //report.CreateDocument();

            //for (int i = report.Pages.Count - 1; i > 0; i--)
            //{
            //    report.Pages.RemoveAt(i);
            //}

            printTool.ShowPreview();

        }
        private void BtnThanhToan_Click1(object sender, EventArgs e)
        {
            string maHD = txtMaHoaDon.Text;
            GridView view = dgvChiTietHoaDon.MainView as GridView;
            if (view.RowCount > 0)
            {
                try
                {
                    themChiTietHoaDon(int.Parse(maHD));
                    SplashScreenManager splashScreen = new SplashScreenManager();
                    SplashScreenManager.ShowForm(this, typeof(WaitForm3), true, true, false);
                    try
                    {

                        dgvSanPham.DataSource = ttsp_bll.get_all_tt_SanPham();
                        loadForm();
                        ShowReport(int.Parse(maHD));
                    }
                    finally
                    {
                        SplashScreenManager.CloseForm();
                    }
                }
               catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        

      
        private void themChiTietHoaDon(int maHD)
        {
            for (int i = 0; i < dgvChiTietHD.RowCount; i++)
            {
                int maThuocTinhSP = Convert.ToInt32(dgvChiTietHD.GetRowCellValue(i, "ma_thuoc_tinh"));
                string trangThai = Convert.ToString(dgvChiTietHD.GetRowCellValue(i, "trang_thai"));
                int soLuongMua = Convert.ToInt32(dgvChiTietHD.GetRowCellValue(i, "so_luong"));
                decimal gia = Convert.ToDecimal(dgvChiTietHD.GetRowCellValue(i, "gia"));

                cthddt_BLL.ThemChiTietHoaDonDoiTra(maHD, maThuocTinhSP,trangThai, gia, soLuongMua);




            }

        }

     

        private void BtnThemSPTra_Click(object sender, EventArgs e)
        {
           
            int maThuocTinhSP;
            string tenSP;
            int soLuong;
            decimal giaBan;
            decimal giaGiam;
            decimal thanhTien;
            int soLuongTon;
            decimal tinhGG;
            try
            {
                maThuocTinhSP = int.Parse(txtMaSP.Text);
                tenSP = txtTenSanPham1.Text;
                soLuong = int.Parse(txtSoLuongMua1.Text);
                giaBan = decimal.Parse(txtGiaBan1.Text);
                tinhGG = giaBan - giaBan * decimal.Parse(txtGiaGiam1.Text) / 100;
                soLuongTon = int.Parse(txtSoLuongTon1.Text);

                giaGiam = tinhGG;
                thanhTien = giaGiam * soLuong;


                //int tongSLMua= Convert.ToInt32(dgvChiTietHoaDon.CurrentRow.Cells["so_luong"].Value);
                if (soLuong > soLuongTon)
                {
                    var dlg = XtraMessageBox.Show($"Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                AddCTHD(maThuocTinhSP, tenSP, soLuong, soLuongTon, giaBan, giaGiam, thanhTien, "đổi hàng");
                TinhTongTien();

            }
            catch (FormatException ex)
            {
                XtraMessageBox.Show("Dữ liệu nhập vào không hợp lệ. Vui lòng kiểm tra lại các trường số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void DgvDS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                txtSoLuongMua1.Value = 1;
                txtMaSP.DataBindings.Clear();
                txtTenSanPham1.DataBindings.Clear();
                txtGiaGiam1.DataBindings.Clear();
                txtGiaBan1.DataBindings.Clear();
                txtSoLuongTon1.DataBindings.Clear();

                txtMaSP.DataBindings.Add("Text", dgvSanPham.DataSource, "ma_thuoc_tinh");
                txtTenSanPham1.DataBindings.Add("Text", dgvSanPham.DataSource, "ten_san_pham");
                // Gán danh sách vào ComboBoxEdit
                txtGiaGiam1.DataBindings.Add("Text", dgvSanPham.DataSource, "GiaGiam");
                txtGiaBan1.DataBindings.Add("Text", dgvSanPham.DataSource, "gia_ban");
                txtSoLuongTon1.DataBindings.Add("Text", dgvSanPham.DataSource, "so_luong_ton");
            }


        }
       
        private void DoiTraHang_Load(object sender, EventArgs e)
        {
            loaddgvSanPham();
        }

        public void loaddgvSanPham()
        {
            dgvSanPham.DataSource = ttsp_bll.get_all_tt_SanPham();
            dgvDS.Columns["ma_san_pham"].Visible = false;
            GridColumn col = dgvDS.Columns["ma_san_pham"];
            dgvDS.Columns.Remove(col);
            dgvDS.Columns["ma_kich_thuoc"].Visible = false;
            GridColumn col1 = dgvDS.Columns["ma_kich_thuoc"];
            dgvDS.Columns.Remove(col1);
            dgvDS.Columns["ma_mau_sac"].Visible = false;
            GridColumn col2 = dgvDS.Columns["ma_mau_sac"];
            dgvDS.Columns.Remove(col2);


        }

        public void AddCTHD(int maThuocTinhSP, string tenSP, int soLuong, int? SLTon, decimal giaBan, decimal giaGiam, decimal thanhTien, string trangThai)
        {
            // Kiểm tra số lượng tồn trước khi thêm dòng mới
            if (SLTon < soLuong)
            {
                XtraMessageBox.Show($"Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy GridView từ GridControl
            GridView gridView = dgvChiTietHD;
            if (gridView != null)
            {
                bool isExisting = false;

                // Duyệt qua các dòng trong GridView để kiểm tra trùng `ma_thuoc_tinh`
                for (int i = 0; i < gridView.DataRowCount; i++)
                {
                    int existingMaThuocTinh = (int)gridView.GetRowCellValue(i, "ma_thuoc_tinh");
                    string trangthai = (string)gridView.GetRowCellValue(i, "trang_thai");
                    if (existingMaThuocTinh == maThuocTinhSP && trangthai == "đổi hàng" && trangThai == "đổi hàng")
                    {
                        // Nếu tìm thấy dòng trùng `ma_thuoc_tinh`, cộng dồn số lượng và cập nhật `thanh_tien`
                        int currentQuantity = (int)gridView.GetRowCellValue(i, "so_luong");
                        int newQuantity = currentQuantity + soLuong;

                        // Kiểm tra tồn kho với số lượng mới
                        if (newQuantity > SLTon)
                        {
                            XtraMessageBox.Show($"Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Cập nhật số lượng và `thanh_tien` trong dòng hiện tại
                        gridView.SetRowCellValue(i, "so_luong", newQuantity);
                        gridView.SetRowCellValue(i, "thanh_tien", giaGiam * newQuantity);
                        // Đặt giá trị rỗng cho ô "colxoa"
                        gridView.SetRowCellValue(i, "colxoa", "");
                        isExisting = true;
                        break;
                    }
                }

                // Nếu không tìm thấy dòng trùng, thêm một dòng mới
                if (!isExisting)
                {
                    gridView.AddNewRow();  // Thêm một dòng mới vào cuối

                    // Lấy chỉ số dòng mới được thêm vào
                    int rowIndex = gridView.GetRowHandle(gridView.DataRowCount);

                    // Cập nhật các ô trong dòng mới
                    gridView.SetRowCellValue(rowIndex, "ma_thuoc_tinh", maThuocTinhSP);
                    gridView.SetRowCellValue(rowIndex, "ten_san_pham", tenSP);
                    gridView.SetRowCellValue(rowIndex, "so_luong", soLuong);
                    gridView.SetRowCellValue(rowIndex, "gia", giaBan);
                    gridView.SetRowCellValue(rowIndex, "giagiam", giaGiam);
                    gridView.SetRowCellValue(rowIndex, "thanh_tien", thanhTien);
                    gridView.SetRowCellValue(rowIndex, "trang_thai", trangThai);
                    // Đặt giá trị rỗng cho ô "colxoa"
                    //  gridView.Set(rowIndex, "colxoa", "");
                    // Cập nhật lại dữ liệu dòng mới
                    gridView.UpdateCurrentRow();
                }
            }
        }
        private void DgvChiTietHD_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == colXoa)
            {
                object soLuongValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "so_luong") : null;
                object trang_thaiValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "trang_thai") : null;
                object gia_banValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "gia") : null;
                // Kiểm tra giá trị của "so_luong"
                if (trang_thaiValue == null || (string)trang_thaiValue == "bình thường")
                {
                    if (soLuongValue != null && Convert.ToInt32(soLuongValue) > 0)
                    {
                        // Hiển thị hộp thoại yêu cầu người dùng nhập một số
                        string inputValue = XtraInputBox.Show("Nhập số sản phẩm cần đổi:", "Số sản phẩm", "1", MessageBoxButtons.OKCancel);

                        // Kiểm tra nếu người dùng đã nhập giá trị và nhấn OK
                        if (!string.IsNullOrEmpty(inputValue))
                        {
                            // Chuyển đổi giá trị nhập vào thành số
                            if (int.TryParse(inputValue, out int number))
                            {

                                if (number > Convert.ToInt32(soLuongValue))
                                {
                                    XtraMessageBox.Show("Số lượng trả không được vượt quá số lượng mua!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    object maSPValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "ma_thuoc_tinh") : null;
                                    object tenSPValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "ten_san_pham") : null;
                                    object giaBanValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "gia") : null;
                                    object giaGiamValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "giagiam") : null;
                                    decimal thanhtien = number * (decimal)giaGiamValue;
                                    GridView gridView = dgvChiTietHD;
                                    bool isExisting = false;
                                    if (gridView != null)
                                    {


                                        for (int i = 0; i < gridView.DataRowCount; i++)
                                        {
                                            int existingMaThuocTinh = (int)gridView.GetRowCellValue(i, "ma_thuoc_tinh");
                                            string Trangthai = (string)gridView.GetRowCellValue(i, "trang_thai");
                                            decimal GG = (decimal)gridView.GetRowCellValue(i, "giagiam");
                                            if (existingMaThuocTinh == int.Parse(maSPValue.ToString()) && Trangthai == "trả hàng")
                                            {

                                                // Nếu tìm thấy dòng trùng `ma_thuoc_tinh`, cộng dồn số lượng và cập nhật `thanh_tien`
                                                int currentQuantity = (int)gridView.GetRowCellValue(i, "so_luong");
                                                int newQuantity = currentQuantity + number;

                                                // Kiểm tra tồn kho với số lượng mới


                                                // Cập nhật số lượng và `thanh_tien` trong dòng hiện tại
                                                gridView.SetRowCellValue(i, "so_luong", newQuantity);
                                                gridView.SetRowCellValue(i, "thanh_tien", Math.Round(GG, 2) * newQuantity);
                                                isExisting = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!isExisting)
                                    {
                                        AddCTHD((int)maSPValue, tenSPValue.ToString(), number, null, Math.Round((decimal)giaBanValue, 2), Math.Round((decimal)giaGiamValue, 2), thanhtien, "trả hàng");
                                    }
                                    ((GridView)sender).SetRowCellValue(e.RowHandle, "so_luong", Convert.ToInt32(soLuongValue) - number);
                               
                                    decimal thanh_tien = Convert.ToDecimal(giaGiamValue) * (Convert.ToDecimal(soLuongValue) - Convert.ToDecimal(number));

                                    ((GridView)sender).SetRowCellValue(e.RowHandle, "thanh_tien", thanh_tien);
                                    
                                }

                                MessageBox.Show($"Số bạn đã nhập là: {number}");
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập một số hợp lệ.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có giá trị được nhập.");
                        }
                    }
                }
                else if ((string)trang_thaiValue == "đổi hàng")
                {
                    // Hiển thị hộp thoại yêu cầu người dùng xác nhận có muốn xóa sản phẩm này không
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có muốn xóa sản phẩm này khỏi chi tiết hóa đơn không?",
                                                                   "Xác nhận xóa",
                                                                   MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Xóa dòng khỏi GridView
                        ((GridView)sender).DeleteRow(e.RowHandle);
                        TinhTongTien();
                        Tinh();
                        // Bạn có thể thêm các thao tác khác nếu cần, ví dụ: cập nhật lại dữ liệu sau khi xóa
                        MessageBox.Show("Sản phẩm đã được xóa khỏi chi tiết hóa đơn.");
                    }
                    else
                    {
                        MessageBox.Show("Không có gì thay đổi.");
                    }
                }
                else if ((string)trang_thaiValue == "trả hàng")
                {
                    // Hiển thị hộp thoại yêu cầu người dùng xác nhận có muốn xóa sản phẩm này khỏi danh sách trả hàng không
                    DialogResult dialogResult = XtraMessageBox.Show("Bạn có muốn xóa sản phẩm này khỏi danh sách trả hàng?",
                                                                   "Xác nhận xóa",
                                                                   MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Lấy mã sản phẩm của dòng hiện tại
                        object maSPValue = e.RowHandle >= 0 ? ((GridView)sender).GetRowCellValue(e.RowHandle, "ma_thuoc_tinh") : null;

                        // Kiểm tra nếu mã sản phẩm không null
                        if (maSPValue != null)
                        {
                            // Duyệt qua tất cả các dòng trong GridView để tìm những dòng có mã sản phẩm trùng
                            for (int i = 0; i < ((GridView)sender).RowCount; i++)
                            {
                                // Lấy mã sản phẩm và số lượng của dòng hiện tại trong vòng lặp
                                object maSPInRow = ((GridView)sender).GetRowCellValue(i, "ma_thuoc_tinh");
                                object soLuongInRow = ((GridView)sender).GetRowCellValue(i, "so_luong");
                                object giaBanInRow = ((GridView)sender).GetRowCellValue(i, "giagiam");
                                // Nếu mã sản phẩm trùng nhau
                                if (maSPValue != null && maSPInRow != null && maSPValue.Equals(maSPInRow))
                                {
                                    // Cộng dồn số lượng
                                    if (soLuongInRow != null)
                                    {
                                        int currentSoLuong = Convert.ToInt32(soLuongInRow);
                                        int soLuongToiXoa = Convert.ToInt32(((GridView)sender).GetRowCellValue(e.RowHandle, "so_luong"));
                                        decimal thanh_tien = Convert.ToDecimal(giaBanInRow) * (currentSoLuong + soLuongToiXoa);

                                        ((GridView)sender).SetRowCellValue(i, "thanh_tien", thanh_tien);
                                        // Cập nhật số lượng sau khi cộng dồn
                                        ((GridView)sender).SetRowCellValue(i, "so_luong", currentSoLuong + soLuongToiXoa);
                                       
                                    }
                                }
                            }

                            // Xóa dòng hiện tại khỏi GridView
                            ((GridView)sender).DeleteRow(e.RowHandle);
                            TinhTongTien();
                            Tinh();
                            // Thông báo thành công
                            XtraMessageBox.Show("Sản phẩm đã được xóa khỏi danh sách trả hàng và số lượng đã được cộng dồn.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có gì thay đổi.");
                    }
                }
                }
            
        }
        private void TinhTongTien()
        {
            decimal tongTien = 0;

            for (int i = 0; i < dgvChiTietHD.RowCount; i++)
            {
                decimal thanhTien = Convert.ToDecimal(dgvChiTietHD.GetRowCellValue(i, "thanh_tien"));
                tongTien += thanhTien;
            }

            // Hiển thị tổng tiền lên một label (ví dụ)
            txtTienSauKhiDoiTra.Text = tongTien.ToString("0.00");
        }
        

        

        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            QuetMa quetMaForm = new QuetMa();

            quetMaForm.Show();

            quetMaForm.NumberSubmitted += QuetMaForm_NumberSubmitted2;
        }

        private void QuetMaForm_NumberSubmitted2(object sender, string e)
        {
            txtMaSP.Text = e;
            quetma(txtMaSP.Text);
        }

        private void quetma(string ma)
        {
                if (ma == null)
                {
                    return;
                }
                int maThuocTinhSP;
                string tenSP;
                int soLuong;
                decimal giaBan;
                decimal giaGiam;
                decimal thanhTien;
                int soLuongTon;
                decimal tinhGG;
                maThuocTinhSP = int.Parse(txtMaSP.Text);
                tenSP = txtTenSanPham1.Text;
                soLuong = int.Parse(txtSoLuongMua1.Text);
                giaBan = decimal.Parse(txtGiaBan1.Text);
                tinhGG = giaBan - giaBan * decimal.Parse(txtGiaGiam1.Text) / 100;
                soLuongTon = int.Parse(txtSoLuongTon1.Text);

                giaGiam = tinhGG;
                thanhTien = giaGiam * soLuong;


                //int tongSLMua= Convert.ToInt32(dgvChiTietHoaDon.CurrentRow.Cells["so_luong"].Value);
                if (soLuong > soLuongTon)
                {
                    var dlg = XtraMessageBox.Show($"Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                AddCTHD(maThuocTinhSP, tenSP, soLuong, soLuongTon, giaBan, giaGiam, thanhTien, "đổi hàng");
                TinhTongTien();

            




        }

        private void BtnQuetMa_Click(object sender, EventArgs e)
        {
            QuetMa quetMaForm = new QuetMa();

            quetMaForm.Show();
           
         
        }

        

        private void BtnQuetMaTimHD_Click(object sender, EventArgs e)
        {
            QuetMa quetMaForm = new QuetMa();
      
            quetMaForm.Show();
          
            quetMaForm.NumberSubmitted += QuetMaForm_NumberSubmitted;
        }

        private void QuetMaForm_NumberSubmitted(object sender, string e)
        {
            txtMaHoaDon.Text = e;
        }

      
    }
}