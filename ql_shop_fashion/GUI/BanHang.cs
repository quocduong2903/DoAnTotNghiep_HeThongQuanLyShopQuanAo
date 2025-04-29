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

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace GUI
{
    public partial class BanHang : DevExpress.XtraEditors.XtraForm
    {
       
        QL_SHOP_DATADataContext qlshop = new QL_SHOP_DATADataContext();
        nha_cung_cap_sql_BLL ncc = new nha_cung_cap_sql_BLL();
        san_pham_sql_BLL sp_bll = new san_pham_sql_BLL();
        thuoc_tinh_sp_sql_BLL ttsp_bll = new thuoc_tinh_sp_sql_BLL();
        
        khach_hang_sql_BLL kh_bll = new khach_hang_sql_BLL();
        khuyen_mai_sql_BLL km = new khuyen_mai_sql_BLL();
        phuong_thuc_thanh_toan_BLL pttt = new phuong_thuc_thanh_toan_BLL();
        hoa_don_BLL hd_BLL = new hoa_don_BLL();
        chi_tiet_hoa_don_BLL cthd_BLL = new chi_tiet_hoa_don_BLL();
        nhan_vien_sql_BLL nv = new nhan_vien_sql_BLL();
        private string data;

        public string Data { get => data; set => data = value; }
        private string maSP;
        int id_nv;
        public BanHang(int idnv)
        {
            InitializeComponent();

            id_nv = idnv;

            this.WindowState = FormWindowState.Maximized; // Đặt form chiếm toàn bộ màn hình
           

            this.Load += BanHang_Load;
            txtNhanVien.Text= nv.get_name_nv_by_id(id_nv);
            dgvDS.FocusedRowChanged += DgvDS_FocusedRowChanged;
            cbokich_thuoc.EditValueChanged += Cbokich_thuoc_EditValueChanged;
            btnThem.Click += BtnThem_Click;
            dgvChiTietHD.RowCellClick += DgvChiTietHD_RowCellClick;
            dgvChiTietHD.CellValueChanged += DgvChiTietHD_CellValueChanged;
            dgvKhachHang.RowCellClick += DgvKhachHang_RowCellClick;
            dgvKhuyenMai.RowCellClick += DgvKhuyenMai_RowCellClick;
            btnQuetMa.Click += BtnQuetMa_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
            txtTongTien.EditValueChanged += TxtTongTien_EditValueChanged;
            txtTienGiam.EditValueChanged += TxtTienGiam_EditValueChanged;
            txtKhachThanhToan.EditValueChanged += TxtKhachThanhToan_EditValueChanged;
            btnLoad.Click += BtnLoad_Click;
            ckbKHThanThiet.CheckedChanged += CkbKHThanThiet_CheckedChanged;
            ckbPhieuGG.CheckedChanged += CkbPhieuGG_CheckedChanged;
            ckbDoiDiem.CheckedChanged += CkbDoiDiem_CheckedChanged;
            txtTienDoiDiem.EditValueChanged += TxtTienDoiDiem_EditValueChanged;
            btnDoiTraHang.Click += BtnDoiTraHang_Click;
            txtDiem.TextChanged += TxtDiem_TextChanged;
            txtKhachThanhToan.KeyPress += TxtKhachThanhToan_KeyPress;
            btnThemKH.Click += BtnThemKH_Click;
            btnInTemGia.Click += BtnInTemGia_Click;
        }

        private void BtnInTemGia_Click(object sender, EventArgs e)
        {
            frmInGia inGia = new frmInGia();
           
            inGia.Show();
        }

        private void BtnThemKH_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem frmMain đã tồn tại hay chưa
            frmMain mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();

            if (mainForm == null)
            {
                // Nếu chưa có form chính, tạo mới
                mainForm = new frmMain();
                mainForm.Show();
            }
            else
            {
                // Nếu đã có, kích hoạt và đưa lên foreground
                mainForm.BringToFront();
            }

            // Gán UserControl UC_KhachHang vào panel chính của frmMain
            var khachHangUC = new UC_KhachHang();
            khachHangUC.Dock = DockStyle.Fill; // Để UC lấp đầy panel
            mainForm.panel_chinh.Controls.Clear(); // Xóa các control cũ trong panel
            mainForm.panel_chinh.Controls.Add(khachHangUC); // Thêm UserControl vào panel

        }

        private void TxtKhachThanhToan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                
                e.Handled = true;
            }
        }

        private void TxtDiem_TextChanged(object sender, EventArgs e)
        {
            if(ckbDoiDiem.Checked)
            {
                txtTienDoiDiem.Text = txtDiem.Text;
            }    
            else
            {
                txtTienDoiDiem.Text = "0";
            }    
            
        }

        private void BtnDoiTraHang_Click(object sender, EventArgs e)
        {
           
            // Tạo instance của UC_NhanVien và thêm vào pn_main
            DoiTraHang doiTraHang = new DoiTraHang(Properties.Settings.Default.id_user_login);
            //nhapHang.Dock = DockStyle.Fill; // Đặt dock nếu muốn chiếm toàn bộ diện tích panel
            doiTraHang.Show();
        }

        //public static BanHang GetInstance(string maSP)
        //{
        //    if (_instance == null || _instance.IsDisposed)
        //    {
        //        _instance = new BanHang(maSP);
        //    }
        //    else
        //    {
        //        _instance.UpdateMaSP(maSP);  // Cập nhật mã sản phẩm nếu form đã tồn tại
        //    }

        //    return _instance;
        //}
        private void TxtTienDoiDiem_EditValueChanged(object sender, EventArgs e)
        {
            TinhTienKhachTra();
        }

        private void QuetMaForm_NumberSubmitted(object sender, string e)
        {
            maSP = e;
            // await Task.Delay(2000);
            quetma(maSP);
        }
        public void quetma(string ma)
        {
            if (ma == null)
            {
                return;
            }
            for (int i = 0; i < dgvDS.RowCount; i++)
            {
                string maSanPhamHienTai = dgvDS.GetRowCellValue(i, "ma_thuoc_tinh").ToString();
                if (maSanPhamHienTai == ma)
                {
                    // Tìm thấy hàng, thực hiện các thao tác
                    dgvDS.FocusedRowHandle = i;

                    break;
                }
            }
            //int rowIndex = dgvDS.LocateByValue("ma_thuoc_tinh", ma);
            //if (rowIndex >= 0)
            //{
            //   dgvDS.FocusedRowHandle = rowIndex;
            //    dgvDS.SelectRow(rowIndex);
            //}
            // Giả sử bạn có các giá trị sau
            int maThuocTinhSP = int.Parse(ma);
            string tenSP = txtTenSanPham.Text;
            int soLuong = int.Parse(txtSoLuongMua.Text);
            decimal giaBan = decimal.Parse(txtGiaBan.Text);
            decimal tinhGG = giaBan - giaBan * decimal.Parse(txtGiaGiam.Text) / 100;
            decimal giaGiam = tinhGG; // Giá sau giảm
            decimal thanhTien = giaGiam * soLuong; // Tính thành tiền
            int soLuongTon = int.Parse(txtSoLuongTon.Text);
            //int tongSLMua= Convert.ToInt32(dgvChiTietHoaDon.CurrentRow.Cells["so_luong"].Value);
            if (soLuong > soLuongTon)
            {
                var dlg = XtraMessageBox.Show($"Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            AddCTHD(maThuocTinhSP, tenSP, soLuong, soLuongTon, giaBan, giaGiam, thanhTien);
        }

        private void TinhKhuyenMai(decimal giaTri = 0, decimal diem = 0)
        {
            decimal tienGiam = decimal.Parse(txtTongTien.Text) * giaTri / 100;
            txtTienGiam.Text = tienGiam.ToString("0.00");

        }
        private void CkbDoiDiem_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDoiDiem.Checked)
            {
                TinhTienKhachTra();
                decimal diem;
                if (!string.IsNullOrEmpty(txtDiem.Text) && decimal.TryParse(txtDiem.Text, out diem))
                {

                    txtTienDoiDiem.Text = diem.ToString();
                }
                else
                {

                    XtraMessageBox.Show("Điểm không hợp lệ!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ckbDoiDiem.Checked = false;
                }
            }
            else
            {
                txtTienDoiDiem.Text = "0";
            }
        }

        private async void BtnThanhToan_Click(object sender, EventArgs e)
        {

            GridView view = dgvChiTietHoaDon.MainView as GridView;
            if (view.RowCount > 0)
            {
                if (cboPTTT.Text.Equals("Chuyển khoản", StringComparison.OrdinalIgnoreCase))
                {
                    int maHoaDonMoi = themHoaDon();

                    // Sử dụng TaskCompletionSource để chờ sự kiện
                    var tcs = new TaskCompletionSource<bool>();

                    frm_QR_TT qr = new frm_QR_TT("thanhtoanhd" + maHoaDonMoi.ToString(), double.Parse(txtTongTien.Text));
                    qr.sukien_tt += () =>
                    {
                        // Khi sự kiện được kích hoạt, hoàn tất TaskCompletionSource
                        tcs.SetResult(true);
                    };

                    // Hiển thị form QR
                    qr.ShowDialog();

                    // Chờ sự kiện được kích hoạt (bất đồng bộ)
                    await tcs.Task;

                    // Chỉ thực hiện các bước này khi sự kiện được kích hoạt
                    themChiTietHoaDon(maHoaDonMoi);

                    SplashScreenManager.ShowForm(this, typeof(WaitForm3), true, true, false);
                    try
                    {
                        dgvSanPham.DataSource = ttsp_bll.get_all_tt_SanPham();
                        loadGiaoDienTrong();
                        ShowReport(maHoaDonMoi);
                    }
                    finally
                    {
                        SplashScreenManager.CloseForm();
                       
                    }
                    return;
                }

                if (txtKhachThanhToan.Text.Trim().Length > 0)
                {
                    if (XtraMessageBox.Show(this, "Xác nhận thanh toán?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        int maHoaDonMoi = themHoaDon();
                        if (maHoaDonMoi == -1)
                        {
                            //// Thêm hóa đơn thất bại, hiển thị thông báo lỗi
                            //XtraMessageBox.Show("Thêm hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        else
                        {
                            themChiTietHoaDon(maHoaDonMoi);
                            SplashScreenManager splashScreen = new SplashScreenManager();
                            SplashScreenManager.ShowForm(this, typeof(WaitForm3), true, true, false);
                            try
                            {

                                dgvSanPham.DataSource = ttsp_bll.get_all_tt_SanPham();
                                loadGiaoDienTrong();
                                ShowReport(maHoaDonMoi);
                            }
                            finally
                            {
                                SplashScreenManager.CloseForm();
                            }
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(this, "Hãy nhập số tiền đã nhận từ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show(this, "Chưa có hàng hóa để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Qr_sukien_tt1()
        {
            throw new NotImplementedException();
        }

        private void Qr_sukien_tt()
        {
            throw new NotImplementedException();
        }

        private void CkbPhieuGG_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPhieuGG.Checked)
            {
                loadCboKhuyenMai();
                txtGiaTriKhuyenMai.Text = "0";
            }
            else
            {
                cboKhuyenMai.Properties.DataSource = null;
                txtTienGiam.Text = null;
                txtGiaTriKhuyenMai.Text = null;
            }



        }

        private void CkbKHThanThiet_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbKHThanThiet.Checked)
            {
                loadCboKhachHang();
            }
            else
            {
                cboKhachHang.Properties.DataSource = null;
                ckbDoiDiem.Checked = false;
                txtDiem.Text = null;
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            loadGiaoDienTrong();
        }

        public void loadGiaoDienTrong()
        {
            dgvChiTietHoaDon.DataSource = null;
            dxErrorProvider1.SetError(txtKhachThanhToan, "");
            dxValidationProvider1.RemoveControlError(txtKhachThanhToan);
            loadTTRong();



        }
        public void ShowReport(int ma)
        {
            HoaDon report = new HoaDon();

            // Thiết lập giá trị cho parameter
            report.Parameters["ma_hoa_don"].Value = ma;

            report.RequestParameters = false;

            // Hiển thị report
            ReportPrintTool printTool = new ReportPrintTool(report);
            // Chỉ hiển thị trang đầu tiên
            report.CreateDocument();

            for (int i = report.Pages.Count - 1; i > 0; i--)
            {
                report.Pages.RemoveAt(i);
            }

            printTool.ShowPreview();

        }

        private void TxtKhachThanhToan_EditValueChanged(object sender, EventArgs e)
        {
            ValidateTongTien();
            TinhTienThua();
        }


        private void TinhTienThua()
        {
            decimal tienThua = 0;
            if (decimal.TryParse(txtTienPhaiTra.Text, out decimal phaiTra) &&
               decimal.TryParse(txtKhachThanhToan.Text, out decimal khachThanhToan))
            {

                tienThua = khachThanhToan - phaiTra;
                txtTienThua.Text = tienThua.ToString();
            }
            txtTienThua.Text = tienThua.ToString();
        }
        private void ValidateTongTien()
        {
            // Kiểm tra nếu cả hai giá trị đều hợp lệ
            if (decimal.TryParse(txtTienPhaiTra.Text, out decimal phaiTra) &&
                decimal.TryParse(txtKhachThanhToan.Text, out decimal khachThanhToan))
            {
                // Kiểm tra nếu tongTien lớn hơn khachThanhToan
                if (phaiTra <= khachThanhToan)
                {
                    // Xóa lỗi nếu điều kiện đúng
                    dxErrorProvider1.SetError(txtKhachThanhToan, "");
                    dxValidationProvider1.RemoveControlError(txtKhachThanhToan);
                }
                else
                {
                    // Đặt thông báo lỗi nếu điều kiện sai
                    dxErrorProvider1.SetError(txtKhachThanhToan, "Số tiền khách thanh toán chưa đủ, ErrorType.Critical");
                    dxErrorProvider1.SetIconAlignment(txtKhachThanhToan, ErrorIconAlignment.MiddleRight);
                }
            }

        }
        private void TxtTienGiam_EditValueChanged(object sender, EventArgs e)
        {
            TinhTienKhachTra();
        }

        private void TinhTienKhachTra()
        {
            decimal tienKhachTra = 0;
            if (string.IsNullOrEmpty(txtTienGiam.Text))
            {
                if (decimal.TryParse(txtTongTien.Text, out tienKhachTra))
                {

                }
                else
                {
                    tienKhachTra = 0;
                }

            }
            else
            {
                tienKhachTra = decimal.Parse(txtTongTien.Text) - decimal.Parse(txtTienGiam.Text);


            }
            if (!string.IsNullOrEmpty(txtTienDoiDiem.Text))
            {
                decimal tienDoiDiem;

                if (decimal.TryParse(txtTienDoiDiem.Text, out tienDoiDiem))
                {

                    tienKhachTra -= tienDoiDiem;
                    txtTienPhaiTra.Text = tienKhachTra.ToString("0.00");
                }

            }

            txtTienPhaiTra.Text = tienKhachTra.ToString("0.00");

        }
        private void TxtTongTien_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKhachThanhToan.Text))
            {
                ValidateTongTien();
                TinhTienThua();
            }

            if (!string.IsNullOrEmpty(txtTongTien.Text) && !string.IsNullOrEmpty(txtGiaTriKhuyenMai.Text))
                TinhKhuyenMai(decimal.Parse(txtGiaTriKhuyenMai.Text));
            if (!string.IsNullOrEmpty(txtTongTien.Text))
                TinhTienKhachTra();
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
            txtTongTien.Text = tongTien.ToString("0.00");
        }

        private void themChiTietHoaDon(int maHD)
        {
            for (int i = 0; i < dgvChiTietHD.RowCount; i++)
            {
                int maThuocTinhSP = Convert.ToInt32(dgvChiTietHD.GetRowCellValue(i, "ma_thuoc_tinh"));

                int soLuongMua = Convert.ToInt32(dgvChiTietHD.GetRowCellValue(i, "so_luong"));
                decimal gia = Convert.ToDecimal(dgvChiTietHD.GetRowCellValue(i, "gia"));

                cthd_BLL.ThemChiTietHoaDon(maHD, maThuocTinhSP, gia, soLuongMua);




            }

        }
        decimal? giaTriHDTT = null;
        private int themHoaDon()
        {

            int maNV = id_nv;
            //int maKH = int.Parse(cboKhachHang.EditValue.ToString());
            int? maKH = null;
            if (int.TryParse(cboKhachHang.EditValue?.ToString(), out int tempMaKH))
            {
                maKH = tempMaKH;
            }
            else
            {
                maKH = null;
            }
            int? maKhuyenMai = null;
            if (ckbPhieuGG.Checked)
            {
                if (string.IsNullOrEmpty(cboKhuyenMai.EditValue?.ToString()))
                {
                    MessageBox.Show("Vui lòng chọn mã khuyến mãi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }
                else if (int.TryParse(cboKhuyenMai.EditValue.ToString(), out int tempMaKM))
                {
                    maKhuyenMai = tempMaKM;
                    if (!string.IsNullOrEmpty(txtTongTien.Text) && giaTriHDTT != null)
                    {

                        decimal? giaTriHoaDon = decimal.Parse(txtTongTien.Text);
                        if (giaTriHoaDon < giaTriHDTT)
                        {
                            XtraMessageBox.Show("Chưa áp dụng được khuyến mãi do chưa đạt giá trị tối thiểu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                    }

                }
            }


            //int maKM = int.Parse(cboKhuyenMai.EditValue.ToString());
            int maPTTT;
            if (int.TryParse(cboPTTT.EditValue?.ToString(), out maPTTT))
            {
                int? kqThem;
                bool checkDiem = ckbDoiDiem.Checked;
                if (checkDiem)
                {

                    int diem;
                    if (string.IsNullOrEmpty(txtDiem.Text))
                    {
                        XtraMessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ckbDoiDiem.Checked = false;
                        return -1; // Dừng thực hiện hàm nếu không nhập điểm
                    }

                    // Thử ép kiểu, nếu không thành công sẽ thông báo lỗi
                    if (!int.TryParse(txtDiem.Text, out diem))
                    {
                        XtraMessageBox.Show("Điểm phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1; // Dừng thực hiện hàm nếu ép kiểu không thành công
                    }
                    try
                    {
                        kqThem = hd_BLL.ThemHoaDonCoDoiDiem(maKH.ToString(), maNV, maKhuyenMai.ToString(), maPTTT, DateTime.Now, diem);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("The transaction ended in the trigger"))
                        {
                            // Tìm vị trí cắt
                            int endIndex = ex.Message.IndexOf(".");

                            // Trích xuất phần bỏ đi
                            string errorMessage = ex.Message.Substring(0, endIndex).Trim();

                            MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return -1;
                    }


                }
                else
                {
                    try
                    {
                        kqThem = hd_BLL.ThemHoaDon(maKH.ToString(), maNV, maKhuyenMai.ToString(), maPTTT, DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("The transaction ended in the trigger"))
                        {
                            // Tìm vị trí cắt
                            int endIndex = ex.Message.IndexOf(".");

                            // Trích xuất phần bỏ đi
                            string errorMessage = ex.Message.Substring(0, endIndex).Trim();

                            MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return -1;
                    }
                }

                if (kqThem.HasValue)
                {
                    XtraMessageBox.Show("Đã thêm thành công hóa đơn mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return kqThem.Value;
                }
                else
                {
                    XtraMessageBox.Show("Không thêm được hóa đơn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }


        }


        // Phương thức cập nhật mã sản phẩm
        public void UpdateMaSP(string maSP)
        {
            this.maSP = maSP;
            quetma(maSP);
        }
        private void BanHang_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            txtSoLuongMua.Properties.MinValue = 1;
            txtSoLuongMua.Properties.MaxValue = 100000;
            loadMember();
            loaddgvSanPham();
            setmaudtgvCTHD();
            loadMember();
            //loadCboKhachHang();
            loadCboPTTT();
            // Sau khi xử lý xong sự kiện Load, đặt flag thành true và gọi quetma
            bool isLoaded = true;

            // Kiểm tra nếu Load đã hoàn tất, gọi quetma
            if (isLoaded)
            {
                quetma(maSP);
            }

        }

        private void BtnQuetMa_Click(object sender, EventArgs e)
        {
            QuetMa quetMaForm = new QuetMa();
            quetMaForm.Show();
            quetMaForm.Focus();
            quetMaForm.NumberSubmitted += QuetMaForm_NumberSubmitted;
        }

        private void DgvChiTietHD_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // Kiểm tra tên của cột mà bạn muốn theo dõi, ví dụ: "so_luong"
            if (e.Column.FieldName == "so_luong")
            {
                int rowIndex = e.RowHandle;
                int maSanPham = (int)dgvChiTietHD.GetRowCellValue(rowIndex, "ma_thuoc_tinh");
                int soLuongTon = ttsp_bll.getSoLuongTon_MaThuocTinh(maSanPham.ToString());
                decimal giaGiam = (decimal)dgvChiTietHD.GetRowCellValue(rowIndex, "giagiam");

                // Chuyển đổi e.Value thành int nếu có thể, ngược lại đặt soLuong bằng 0
                int soLuong;
                if (!int.TryParse(e.Value?.ToString(), out soLuong))
                {
                    soLuong = 0;
                }
                decimal thanhTien = Math.Round(giaGiam * soLuong, 2);

                // Cập nhật giá trị "thanh_tien" vào ô của dòng hiện tại
                dgvChiTietHD.SetRowCellValue(dgvChiTietHD.FocusedRowHandle, "thanh_tien", thanhTien);
                TinhTongTien();
                // Kiểm tra nếu số lượng mua lớn hơn số lượng tồn
                if (soLuong > soLuongTon)
                {
                    // Hiển thị thông báo lỗi
                    XtraMessageBox.Show("Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Đặt giá trị ô hiện tại thành trống
                    dgvChiTietHD.SetRowCellValue(rowIndex, e.Column, null);

                    // Đưa tiêu điểm về lại ô vừa chỉnh sửa
                    dgvChiTietHD.FocusedColumn = e.Column;
                    dgvChiTietHD.SetRowCellValue(dgvChiTietHD.FocusedRowHandle, "so_luong", 1);
                    dgvChiTietHD.FocusedRowHandle = rowIndex;
                    dgvChiTietHD.ShowEditor(); // Hiển thị trình chỉnh sửa để người dùng nhập lại

                    return;
                }
            }
        }



        private void DgvKhuyenMai_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                // Lấy giá trị của cột "ma_khach_hang" từ dòng đang được chọn (dòng có tiêu điểm)
                var rowHandle = dgvKhuyenMai.FocusedRowHandle;  // Lấy RowHandle của dòng hiện tại

                if (rowHandle >= 0)  // Kiểm tra nếu dòng hiện tại hợp lệ
                {
                    // Lấy giá trị cột "ma_khach_hang" của dòng hiện tại
                    object ma = dgvKhuyenMai.GetRowCellValue(rowHandle, "ma_khuyen_mai");
                    object giaTri = dgvKhuyenMai.GetRowCellValue(rowHandle, "gia_tri");
                    object giaTriHoaDonToiThieu = dgvKhuyenMai.GetRowCellValue(rowHandle, "gia_tri_hoa_don_toi_thieu");
                    if (giaTriHoaDonToiThieu != null)
                    {
                        giaTriHDTT = decimal.Parse(giaTriHoaDonToiThieu.ToString());
                    }

                    if (ma != null)
                    {
                        // Gán giá trị vào txtNhanVien.Text
                        txtGiaTriKhuyenMai.Text = giaTri.ToString();
                        // Đóng hoặc ẩn GridControl (GridView)
                        cboKhuyenMai.ClosePopup();

                        // Hiển thị giá trị vào ComboBoxEdit (cboKhachHang)
                        cboKhuyenMai.EditValue = ma.ToString(); // Gán giá trị vào ValueMember của cboKhachHang
                        TinhKhuyenMai(decimal.Parse(giaTri.ToString()));

                    }
                    else
                    {
                        MessageBox.Show("Cột code không có giá trị.");
                    }
                }
                else
                {
                    MessageBox.Show("Không có dòng nào được chọn.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void DgvKhachHang_RowCellClick(object sender, RowCellClickEventArgs e)
        {


            try
            {
                // Lấy giá trị của cột "ma_khach_hang" từ dòng đang được chọn (dòng có tiêu điểm)
                var rowHandle = dgvKhachHang.FocusedRowHandle;  // Lấy RowHandle của dòng hiện tại

                if (rowHandle >= 0)  // Kiểm tra nếu dòng hiện tại hợp lệ
                {
                    // Lấy giá trị cột "ma_khach_hang" của dòng hiện tại
                    object maKhachHang = dgvKhachHang.GetRowCellValue(rowHandle, "ma_khach_hang");
                    object diem = dgvKhachHang.GetRowCellValue(rowHandle, "diem_thuong");
                    if (maKhachHang != null)
                    {
                        // Gán giá trị vào txtNhanVien.Text
                        txtDiem.Text = diem.ToString();
                        // Đóng hoặc ẩn GridControl (GridView)
                        cboKhachHang.ClosePopup();

                        // Hiển thị giá trị vào ComboBoxEdit (cboKhachHang)
                        cboKhachHang.EditValue = maKhachHang.ToString(); // Gán giá trị vào ValueMember của cboKhachHang

                    }
                    else
                    {
                        MessageBox.Show("Cột 'ma_khach_hang' không có giá trị.");
                    }
                }
                else
                {
                    MessageBox.Show("Không có dòng nào được chọn.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }

        private void DgvKhachHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }



        private void DgvChiTietHD_RowCellClick(object sender, RowCellClickEventArgs e)
        {

            if (e.Column == colXoa)
            {
                var dlg = XtraMessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm này khỏi chi tiết hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    dgvChiTietHD.DeleteSelectedRows();
                    TinhTongTien();
                }
            }
        }

        public void loadCboPTTT()
        {
            cboPTTT.Properties.DataSource = pttt.getDanhSanhPTTT();
            GridView view = cboPTTT.Properties.View as GridView;
            if (view.RowCount > 0)
            {
                object firstValue = view.GetRowCellValue(0, view.Columns["ma_phuong_thuc"]); // Giả sử cột khóa chính là "ma_phuong_thuc"
                cboPTTT.EditValue = firstValue;
            }

        }
        public void loadCboKhachHang()
        {
            cboKhachHang.Properties.DataSource = kh_bll.getDanhSanhKH();

        }
        public void loadCboKhuyenMai()
        {
            cboKhuyenMai.Properties.DataSource = km.getKhuyenMai();

        }
        public void loadMember()
        {
            cboMauSac.Properties.DisplayMember = "ten_mau_sac";
            cboMauSac.Properties.ValueMember = "ma_mau_sac";
            cbokich_thuoc.Properties.ValueMember = "ma_kich_thuoc";
            cbokich_thuoc.Properties.DisplayMember = "ten_kich_thuoc";
            cboKhachHang.Properties.ValueMember = "ma_khach_hang";
            cboKhachHang.Properties.DisplayMember = "ten_khach_hang";
            cboKhuyenMai.Properties.ValueMember = "ma_khuyen_mai";
            cboKhuyenMai.Properties.DisplayMember = "code";

            cboPTTT.Properties.ValueMember = "ma_phuong_thuc";
            cboPTTT.Properties.DisplayMember = "ten_phuong_thuc";

            //Xóa cột mã kích thước
            cboMauSac.Properties.View.Columns["ma_kich_thuoc"].Visible = false;
            GridColumn col1 = dgvDS.Columns["ma_kich_thuoc"];

            cboMauSac.Properties.View.Columns.Remove(col1);
            //Xóa cột mã kích thước

            cboMauSac.Properties.View.Columns["ma_mau_sac"].Visible = false;
            // Tìm cột và xóa

            GridColumn col2 = dgvDS.Columns["ma_mau_sac"];

            cboPTTT.Properties.View.Columns["ma_phuong_thuc"].Visible = false;
            // Tìm cột và xóa

            GridColumn col3 = dgvDS.Columns["ma_phuong_thuc"];

            cboPTTT.Properties.View.Columns["trang_thai"].Visible = false;
            // Tìm cột và xóa

            GridColumn col4 = dgvDS.Columns["trang_thai"];

            cboPTTT.Properties.View.Columns["mo_ta"].Visible = false;
            // Tìm cột và xóa

            GridColumn col5 = dgvDS.Columns["mo_ta"];

        }


        public void setmaudtgvCTHD()
        {
            foreach (GridColumn column in dgvChiTietHD.Columns)
            {
                //column.AppearanceHeader.BackColor = Color.Blue;
                //column.AppearanceHeader.ForeColor = Color.White;
                if (column.FieldName != "so_luong" && column.FieldName != "nutxoa")
                {
                    column.OptionsColumn.ReadOnly = true;
                    column.OptionsColumn.AllowEdit = false;
                }
            }
            // Thay đổi màu nền cột "so_luong"
            GridColumn soLuongColumn = dgvChiTietHD.Columns["so_luong"];
            soLuongColumn.AppearanceCell.BackColor = Color.LightBlue;
        }

        private void BtnThem_Click(object sender, EventArgs e)
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
                maThuocTinhSP = int.Parse(txtMaSanPham.Text);
                tenSP = txtTenSanPham.Text;
                soLuong = int.Parse(txtSoLuongMua.Text);
                giaBan = decimal.Parse(txtGiaBan.Text);
                tinhGG = giaBan - giaBan * decimal.Parse(txtGiaGiam.Text) / 100;
                soLuongTon = int.Parse(txtSoLuongTon.Text);

                giaGiam = tinhGG;
                thanhTien = giaGiam * soLuong;


                //int tongSLMua= Convert.ToInt32(dgvChiTietHoaDon.CurrentRow.Cells["so_luong"].Value);
                if (soLuong > soLuongTon)
                {
                    var dlg = XtraMessageBox.Show($"Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                AddCTHD(maThuocTinhSP, tenSP, soLuong, soLuongTon, giaBan, giaGiam, thanhTien);
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


        //Thêm dữ liệu vào chi tiết HD
        public void AddCTHD(int maThuocTinhSP, string tenSP, int soLuong, int SLTon, decimal giaBan, decimal giaGiam, decimal thanhTien)
        {
            //capNhatSoLuongTonTrongDgvSanPham(10, maThuocTinhSP);
            // Kiểm tra xem DataSource của dgvChiTietHoaDon có phải là DataTable không
            if (!(dgvChiTietHoaDon.DataSource is DataTable dataTable))
            {
                // Nếu DataSource chưa phải là DataTable, khởi tạo DataTable mới và cấu hình các cột
                dataTable = new DataTable();
                dataTable.Columns.Add("ma_thuoc_tinh", typeof(int));
                dataTable.Columns.Add("ten_san_pham", typeof(string));
                dataTable.Columns.Add("so_luong", typeof(int));
                dataTable.Columns.Add("gia", typeof(decimal));
                dataTable.Columns.Add("giagiam", typeof(decimal));
                dataTable.Columns.Add("thanh_tien", typeof(decimal));

                // Gán DataTable mới tạo vào DataSource của dgvChiTietHoaDon
                dgvChiTietHoaDon.DataSource = dataTable;
            }

            // Kiểm tra xem maThuocTinhSP đã tồn tại trong bảng chưa
            bool isExisting = false;
            foreach (DataRow row in dataTable.Rows)
            {
                if ((int)row["ma_thuoc_tinh"] == maThuocTinhSP)
                {
                    int slmua = (int)row["so_luong"] + soLuong;
                    // Nếu tìm thấy maThuocTinhSP trùng, cập nhật số lượng và thành tiền

                    if (SLTon < slmua)
                    {
                        var dlg = XtraMessageBox.Show($"Số lượng mua lớn hơn số lượng tồn", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isExisting = true;
                        break;
                    }
                    row["so_luong"] = slmua;
                    row["thanh_tien"] = (decimal)row["giagiam"] * (int)row["so_luong"];

                    isExisting = true;
                    break;
                }
            }

            // Nếu không tìm thấy maThuocTinhSP trùng, thêm dòng mới
            if (!isExisting)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["ma_thuoc_tinh"] = maThuocTinhSP;
                newRow["ten_san_pham"] = tenSP;
                newRow["so_luong"] = soLuong;
                newRow["gia"] = giaBan;
                newRow["giagiam"] = giaGiam;
                newRow["thanh_tien"] = thanhTien;

                dataTable.Rows.Add(newRow);


            }

            // Làm mới DataGridView để hiển thị dữ liệu mới
            dgvChiTietHoaDon.Refresh();

        }
        private void hienThiTextBoxTheoKichThuoc(string maKT, string maTT)
        {

            cboMauSac.Properties.DataSource = ttsp_bll.getMauSacTheoKichThuoc(maKT, maTT);
            //Databingding
            txtGiaBan.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Clear();
            cboMauSac.DataBindings.Clear();
            cboMauSac.DataBindings.Add("EditValue", cboMauSac.Properties.DataSource, "ma_mau_sac");
            txtGiaBan.DataBindings.Add("Text", cboMauSac.Properties.DataSource, "gia_ban");
            txtSoLuongTon.DataBindings.Add("Text", cboMauSac.Properties.DataSource, "so_luong_ton");
        }
        private void Cbokich_thuoc_EditValueChanged(object sender, EventArgs e)

        {

            string maKichThuoc = cbokich_thuoc.EditValue.ToString();
            string maTT = txtMaSanPham.Text;
            hienThiTextBoxTheoKichThuoc(maKichThuoc, maTT);
        }


        private void DgvDS_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (e.FocusedRowHandle >= 0)
            {
                txtSoLuongMua.Value = 1;
                txtMaSanPham.DataBindings.Clear();
                txtTenSanPham.DataBindings.Clear();
                txtGiaGiam.DataBindings.Clear();
                cboMauSac.DataBindings.Clear();

                txtMaSanPham.DataBindings.Add("Text", dgvSanPham.DataSource, "ma_thuoc_tinh");
                txtTenSanPham.DataBindings.Add("Text", dgvSanPham.DataSource, "ten_san_pham");
                // Gán danh sách vào ComboBoxEdit
                txtGiaGiam.DataBindings.Add("Text", dgvSanPham.DataSource, "GiaGiam");
                cbokich_thuoc.DataBindings.Clear();

                //cbokich_thuoc.ItemIndex = -1;
                // Set the SelectedValue if needed
                cbokich_thuoc.DataBindings.Add("EditValue", dgvSanPham.DataSource, "ma_kich_thuoc");
                cbokich_thuoc.Properties.DataSource = ttsp_bll.getKichThuocBangTenSanPham(txtTenSanPham.Text);
            
                //
                string maKichThuoc = cbokich_thuoc.EditValue.ToString();
                string maTT = txtMaSanPham.Text;
                hienThiTextBoxTheoKichThuoc(maKichThuoc, maTT);

            }




        }



        private void DgvSanPham_Click(object sender, EventArgs e)
        {

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

            loadTTRong();

        }

        private void loadTTRong()
        {
            txtMaSanPham.Text = "";
            txtMaSanPham.ReadOnly = true;
            txtTenSanPham.Text = "";
            txtTenSanPham.ReadOnly = true;
            txtGiaGiam.Text = "0";
            txtGiaGiam.ReadOnly = true;
            txtGiaBan.Text = "0";
            txtGiaBan.ReadOnly = true;
            txtSoLuongMua.Value = 0;

            txtSoLuongTon.Text = "0";
            txtSoLuongTon.ReadOnly = true;
            txtTienGiam.Text = null;
            txtTienGiam.ReadOnly = true;
            txtKhachThanhToan.Text = null;

            txtTienThua.Text = null;
            txtTienThua.ReadOnly = true;
            txtTienPhaiTra.Text = null;
            txtTienPhaiTra.ReadOnly = true;
            txtDiem.Text = null;
            txtDiem.ReadOnly = true;
            txtTongTien.Text = null;
            txtTongTien.ReadOnly = true;
            txtGiaTriKhuyenMai.Text = null;
            txtGiaTriKhuyenMai.ReadOnly = true;
            cboMauSac.EditValue = null;
            cbokich_thuoc.Properties.DataSource = null;
            cboMauSac.Properties.DataSource = null;
            cboKhuyenMai.EditValue = null;
            cboKhachHang.EditValue = null;
            cboPTTT.EditValue = null;
            ckbDoiDiem.Checked = false;
            ckbPhieuGG.Checked = false;
            txtTienDoiDiem.Text = null;
            ckbKHThanThiet.Checked = false;
            txtNhanVien.ReadOnly = true;
            cbokich_thuoc.Enabled = false;
            cboMauSac.Enabled = false;
            txtTienDoiDiem.ReadOnly = true;
        }

        private void BanHang_Load_1(object sender, EventArgs e)
        {

        }
    }
}