using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using DevExpress.XtraGrid;
using System.Diagnostics;

namespace GUI
{
    public partial class UC_SanPham : XtraUserControl
    {
        private san_pham_sql_BLL sp_bll;
        private thuoc_tinh_sp_sql_BLL thuoc_tinh_bll;
        private thong_tin_sp_sql_BLL thong_tin_bll;
        private size_sql_BLL size_bll;
        private mau_sac_sql_BLL mau_sac_bll;
        private thuong_hieu_sql_BLL thuong_hieu_bll;
        private nhom_loai_sql_BLL nhom_loai_bll;
        private loai_sanpham_sql_BLL loai_sanpham_bll;
        private string selectedProductInfo;
        private Form popup;

        public UC_SanPham()
        {
            InitializeComponent();
            this.Load += UC_SanPham_Load;
            khoiTao();

            cauHinhThanhTimKiemCacGrid();


            btn_themkt.Click += Btn_themkt_Click;
            btn_suakt.Click += Btn_suakt_Click;
            btn_xoakt.Click += Btn_xoakt_Click;
            btn_loadkt.Click += Btn_loadkt_Click;

            btn_themms.Click += Btn_themms_Click;
            btn_suams.Click += Btn_suams_Click;
            btn_xoams.Click += Btn_xoams_Click;
            btn_loadms.Click += Btn_loadms_Click;

            btn_themth.Click += Btn_themth_Click;
            btn_xoath.Click += Btn_xoath_Click;
            btn_suath.Click += Btn_suath_Click;
            btn_loadth.Click += Btn_loadth_Click;

            btn_themnl.Click += Btn_themnl_Click;
            btn_xoanl.Click += Btn_xoanl_Click;
            btn_suanl.Click += Btn_suanl_Click;
            btn_loadnl.Click += Btn_loadnl_Click;
            btn_thongtinloaisp.Click += Btn_thongtinloaisp_Click;

            btn_themsp.Click += Btn_themsp_Click;
            btn_xoasp.Click += Btn_xoasp_Click;
            btn_luusp.Click += Btn_luusp_Click;
            btn_loadsp.Click += Btn_loadsp_Click;

            btn_themspvaothuoctinh.Click += Btn_themspvaothuoctinh_Click;

            btn_mochonanhsp.Click += Btn_mochonanhsp_Click;

            var gridView = gct_sp.MainView as GridView;
            gridView.FocusedRowChanged += GridView_FocusedRowChanged;

            lb_thongtinsp.MouseHover += Lb_thongtinsp_MouseHover;
            lb_thongtinsp.MouseLeave += Lb_thongtinsp_MouseLeave;


            // Gán sự kiện MouseEnter và MouseLeave cho nút
            doiMauNutKhiHover(btn_themsp);
            doiMauNutKhiHover(btn_xoasp);
            doiMauNutKhiHover(btn_luusp);
            doiMauNutKhiHover(btn_loadsp);
            doiMauNutKhiHover(btn_themspvaothuoctinh);
            doiMauNutKhiHover(btn_mochonanhsp);


            doiMauNutKhiHover(btn_themkt);
            doiMauNutKhiHover(btn_suakt);
            doiMauNutKhiHover(btn_xoakt);
            doiMauNutKhiHover(btn_loadkt);

            doiMauNutKhiHover(btn_themms);
            doiMauNutKhiHover(btn_suams);
            doiMauNutKhiHover(btn_xoams);
            doiMauNutKhiHover(btn_loadms);

            doiMauNutKhiHover(btn_themth);
            doiMauNutKhiHover(btn_suath);
            doiMauNutKhiHover(btn_xoath);
            doiMauNutKhiHover(btn_loadth);

            doiMauNutKhiHover(btn_themnl);
            doiMauNutKhiHover(btn_suanl);
            doiMauNutKhiHover(btn_xoanl);
            doiMauNutKhiHover(btn_loadnl);


        }



        private void khoiTao()
        {
            thuoc_tinh_bll = new thuoc_tinh_sp_sql_BLL();
            thuong_hieu_bll = new thuong_hieu_sql_BLL();
            loai_sanpham_bll = new loai_sanpham_sql_BLL();
            thong_tin_bll = new thong_tin_sp_sql_BLL();
        }

        // Tách logic cấu hình các GridView
        private void cauHinhThanhTimKiemCacGrid()
        {
            cauHinhThanhTimKiemGrid(gct_sp, "ten_san_pham", Gv_sp_Click);
            cauHinhThanhTimKiemGrid(gct_size, "ten_kich_thuoc", Gv_size_Click);
            cauHinhThanhTimKiemGrid(gct_mausac, "ten_mau_sac", Gv_mausac_Click);
            cauHinhThanhTimKiemGrid(gct_thuonghieu, "ten_thuong_hieu", Gv_thuonghieu_Click);
            cauHinhThanhTimKiemGrid(gct_nhomloai, "ten_nhom_loai", Gv_nhomloai_Click);
        }

        // Phương thức cấu hình GridView
        private void cauHinhThanhTimKiemGrid(GridControl gridControl, string findColumns, EventHandler clickEvent)
        {
            GridView gridView = gridControl.MainView as GridView;
            if (gridView == null) return;

            gridView.Click += clickEvent; // Gán sự kiện Click
            gridView.OptionsFind.AlwaysVisible = true; // Luôn hiển thị thanh tìm kiếm
            gridView.OptionsFind.ShowClearButton = true; // Hiển thị nút xóa
            gridView.OptionsFind.ShowFindButton = false; // Tự tìm khi gõ
            gridView.OptionsFind.FindFilterColumns = findColumns; // Cột tìm kiếm
        }

        private void doiMauNutKhiHover(SimpleButton button)
        {
            button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat; // Kiểu giao diện phẳng
            button.LookAndFeel.UseDefaultLookAndFeel = false; // Tắt giao diện mặc định

            // Màu khi hover
            button.AppearanceHovered.BackColor = Color.White;
            button.AppearanceHovered.ForeColor = Color.Black;

            // Màu khi nhấn
            button.AppearancePressed.BackColor = Color.Gray;
            button.AppearancePressed.ForeColor = Color.Black;

        }



        


        private string selectedImagePath; // Khai báo biến toàn cục để lưu đường dẫn file gốc

        private void Btn_mochonanhsp_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                ofd.Title = "Chọn hình ảnh sản phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName; // Lưu đường dẫn file đã chọn
                    pb_anhsp.Image = Image.FromFile(selectedImagePath); // Hiển thị ảnh trong PictureBox
                    pb_anhsp.SizeMode = PictureBoxSizeMode.StretchImage;

                    Debug.WriteLine($"Hình ảnh đã được chọn: {selectedImagePath}");
                }
            }
        }



        private void Lb_thongtinsp_MouseLeave(object sender, EventArgs e)
        {
            HidePopup();
        }

        private void Lb_thongtinsp_MouseHover(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedProductInfo))
            {
                ShowPopup();
            }
        }

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var gridView = sender as GridView;

            if (gridView != null)
            {
                // Lấy mã sản phẩm từ hàng được chọn
                var maSP = (int)gridView.GetRowCellValue(e.FocusedRowHandle, "ma_san_pham");

                // Gọi phương thức lấy thông tin chi tiết sản phẩm từ BLL
                var thongTinSanPhamList = thong_tin_bll.get_all_ttsp()
                    .Where(tt => tt.ma_san_pham == maSP)
                    .ToList();

                // Kiểm tra nếu không có thông tin chi tiết
                if (!thongTinSanPhamList.Any())
                {
                    selectedProductInfo = "";
                    HidePopup();
                    return;
                }

                // Lưu thông tin chi tiết vào biến selectedProductInfo
                StringBuilder infoContent = new StringBuilder();
                infoContent.AppendLine($"Mã sản phẩm: {maSP}");
                foreach (var item in thongTinSanPhamList)
                {
                    infoContent.AppendLine($"{item.key_attribute}: {item.value_attribute}");
                }

                // Cập nhật trực tiếp vào nội dung của popup nếu đã tồn tại
                selectedProductInfo = infoContent.ToString();
                if (popup != null && popup.Controls.Count > 0)
                {
                    var lblInfo = popup.Controls[0] as Label;
                    if (lblInfo != null)
                    {
                        lblInfo.Text = selectedProductInfo;
                        lblInfo.Refresh(); // Làm mới nội dung của Label
                    }
                }
            }
        }

        

        private void ShowPopup()
        {
            if (popup == null || popup.IsDisposed)
            {
                popup = new Form
                {
                    StartPosition = FormStartPosition.Manual,
                    Size = new Size(450, 150),
                    FormBorderStyle = FormBorderStyle.None,
                    BackColor = Color.LightYellow,
                    Opacity = 0.9,
                    ShowInTaskbar = false,
                    TopMost = true
                };

                // Tạo Label để hiển thị thông tin
                popup.Controls.Clear();
                Label lblInfo = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.TopLeft,
                    ForeColor = Color.Black,
                    Padding = new Padding(10),
                    AutoSize = true,
                    Text = selectedProductInfo
                };

                popup.Controls.Add(lblInfo);
            }

            // Đặt vị trí hiển thị popup gần con trỏ chuột
            var mousePosition = Control.MousePosition;
            popup.Location = new Point(mousePosition.X + 10, mousePosition.Y + 10);

            // Hiển thị form nếu chưa hiển thị
            if (!popup.Visible)
            {
                popup.Show();
            }
        }


        private void HidePopup()
        {
            if (popup != null && popup.Visible)
            {
                popup.Hide();
            }
        }


        
        private void Btn_themspvaothuoctinh_Click(object sender, EventArgs e)
        {
            frmThemSPVaoThuocTinh sp = new frmThemSPVaoThuocTinh();
            sp.ShowDialog();
        }


        private void Btn_xoasp_Click(object sender, EventArgs e)
        {
            xoaSP();
        }

        private void Btn_luusp_Click(object sender, EventArgs e)
        {
            luuSP();
        }

        private void Btn_themsp_Click(object sender, EventArgs e)
        {
            themSP();
        }

        private void Btn_thongtinloaisp_Click(object sender, EventArgs e)
        {
            frmLoaiSP loaiSP = new frmLoaiSP();
            loaiSP.ShowDialog();
        }

        private void Btn_loadnl_Click(object sender, EventArgs e)
        {
            clearnhomloai();
        }

        private void Btn_suanl_Click(object sender, EventArgs e)
        {
            suaNL();
        }

        private void Btn_xoanl_Click(object sender, EventArgs e)
        {
            xoaNL();
        }

        private void Btn_themnl_Click(object sender, EventArgs e)
        {
            themNL();
        }


        private void Btn_suath_Click(object sender, EventArgs e)
        {
            suaTH();
        }

        private void Btn_xoath_Click(object sender, EventArgs e)
        {
            xoaTH();
        }

        private void Btn_themth_Click(object sender, EventArgs e)
        {
            themTH();
        }

        private void Btn_xoams_Click(object sender, EventArgs e)
        {
            xoaMS();
        }

        private void Btn_suams_Click(object sender, EventArgs e)
        {
            suaMS();
        }

        private void Btn_themms_Click(object sender, EventArgs e)
        {
            themMS();
        }

        private void Btn_suakt_Click(object sender, EventArgs e)
        {
            suaSize();
        }    
                

        private void Btn_themkt_Click(object sender, EventArgs e)
        {
            themSize();
        }

        private void Btn_xoakt_Click(object sender, EventArgs e)
        {
            xoaSize();
        }

        private void Btn_loadth_Click(object sender, EventArgs e)
        {
            clearthuonghieu();
        }

        private void Btn_loadms_Click(object sender, EventArgs e)
        {
            clearmausac();
        }

        private void Btn_loadkt_Click(object sender, EventArgs e)
        {
            clearsize();
        }
        private void Btn_loadsp_Click(object sender, EventArgs e)
        {
            clearsp();
        }

        private void Gv_mausac_Click(object sender, EventArgs e)
        {
            loadColourLenControls();
        }

        private void Gv_size_Click(object sender, EventArgs e)
        {
            loadSizeLenControls();
        }

        private void Gv_sp_Click(object sender, EventArgs e)
        {
            loadSPLenControls();
            loadThuocTinhSP();
        }

        private void Gv_thuonghieu_Click(object sender, EventArgs e)
        {
            loadThuongHieuLenControls();
        }


        private void Gv_nhomloai_Click(object sender, EventArgs e)
        {
            loadNhomLoaiLenControls();
        }



        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            loadSP();
            loadMaLoaiLenCombobox();
            loadThuongHieuLenCombobox();
            loadHinhThucBanLenCombobox();
            loadSize();
            loadMauSac();
            loadThuongHieu();
            loadNhomLoai();
            clearsp();
        }



        private void loadThuocTinhSP()
        {
            try
            {
                // Kiểm tra nếu giá trị trong txt_masanpham là hợp lệ và chuyển đổi được
                if (int.TryParse(txt_masanpham.Text, out int masanpham))
                {
                    // Lấy thông tin sản phẩm từ BLL
                    var thongTinSanPhamTable = thuoc_tinh_bll.get_all_ttsp_by_id_DTO(masanpham); // Sửa phương thức gọi

                    if (thongTinSanPhamTable.Count > 0) // Nếu có dữ liệu
                    {
                        // Gắn dữ liệu vào GridControl
                        gct_ttsp.DataSource = thongTinSanPhamTable;

                        // Cấu hình lại GridView
                        GridView gridViewDetails = gct_ttsp.MainView as GridView;
                        if (gridViewDetails != null)
                        {
                            gridViewDetails.OptionsBehavior.Editable = false;

                            // Tự động điều chỉnh kích thước cột
                            gridViewDetails.BestFitColumns();

                            // Cấu hình cột để hiển thị thông tin rõ ràng hơn
                            gridViewDetails.Columns["ma_thuoc_tinh"].Caption = "Mã Thuộc Tính";
                            gridViewDetails.Columns["ma_san_pham"].Caption = "Mã Sản Phẩm";
                            gridViewDetails.Columns["ten_kich_thuoc"].Caption = "Tên Kích Thước";
                            gridViewDetails.Columns["ten_mau_sac"].Caption = "Tên Màu Sắc";
                            gridViewDetails.Columns["so_luong_ton"].Caption = "Số Lượng Tồn";
                            gridViewDetails.Columns["gia_ban"].Caption = "Giá Bán";

                            gridViewDetails.Columns["ma_kich_thuoc"].Visible = false; // Ẩn cột tên kích thước
                            gridViewDetails.Columns["ma_mau_sac"].Visible = false; // Ẩn cột tên màu sắc

                            // Bật tự động tăng chiều cao hàng (nếu cần cho nội dung dài)
                            gridViewDetails.OptionsView.RowAutoHeight = true;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Không tìm thấy thuộc tính sản phẩm cho mã sản phẩm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gct_ttsp.DataSource = null; // Xóa dữ liệu cũ nếu không tìm thấy
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mã sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        private void loadMaLoaiLenCombobox()
        {
            try
            {
                List<loai_sanpham_DTO> List = loai_sanpham_bll.get_all_loai_sp();

                // Xóa các item cũ
                cbb_maloai.Properties.Items.Clear();

                // Thêm dữ liệu vào ComboBoxEdit thủ công
                foreach (var nhomLoai in List)
                {
                    cbb_maloai.Properties.Items.Add(nhomLoai.ma_loai);
                }

                // Không chọn mục nào mặc định
                cbb_maloai.EditValue = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }


        private void loadThuongHieuLenCombobox()
        {
            try
            {
                List<thuong_hieu_DTO> List = thuong_hieu_bll.get_all_thuong_hieu();

                // Xóa các item cũ
                cbb_mathuonghieu.Properties.Items.Clear();

                // Thêm dữ liệu vào ComboBoxEdit thủ công
                foreach (var nhomLoai in List)
                {
                    cbb_mathuonghieu.Properties.Items.Add(nhomLoai.ma_thuong_hieu);
                }

                // Không chọn mục nào mặc định
                cbb_mathuonghieu.EditValue = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }


        private void loadHinhThucBanLenCombobox()
        {
            // Xóa các mục cũ trong ComboBoxEdit
            cbb_hinhthucban.Properties.Items.Clear();

            // Thêm danh sách chuỗi vào ComboBoxEdit
            cbb_hinhthucban.Properties.Items.Add("0");
            cbb_hinhthucban.Properties.Items.Add("1");
            cbb_hinhthucban.Properties.Items.Add("2");

            // Chọn mục mặc định nếu cần
            cbb_hinhthucban.SelectedIndex = 0; // Chọn mục đầu tiên
        }






        private void loadSP()
        {
            // Khởi tạo lớp BLL và lấy dữ liệu sản phẩm
            sp_bll = new san_pham_sql_BLL();
            gct_sp.DataSource = sp_bll.get_all_sp_custom();

            // Cấu hình GridView (gct_sp phải là một GridControl)
            GridView gridView = gct_sp.MainView as GridView;
            if (gridView != null)
            {
                gridView.OptionsBehavior.Editable = false;

                // Thiết lập tên hiển thị cho các cột
                gridView.Columns["ma_san_pham"].Caption = "Mã Sản Phẩm";
                gridView.Columns["ten_san_pham"].Caption = "Tên Sản Phẩm";
                gridView.Columns["gia_binh_quan"].Caption = "Giá Bình Quân";


                // Tự động điều chỉnh độ rộng các cột dựa trên nội dung
                gridView.BestFitColumns();
            }
            else
            {
                return;
            }
        }



        private void loadSPLenControls()
        {
            GridView gridView = gct_sp.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                int maSanPham = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_san_pham"));

                // Lấy chi tiết sản phẩm
                var productDetails = sp_bll.GetProductDetailsById(maSanPham);
                var imagePaths = sp_bll.GetAllImagesByProductId(maSanPham); // Lấy tất cả đường dẫn hình ảnh

                if (productDetails != null)
                {
                    // Hiển thị thông tin sản phẩm
                    txt_masanpham.Text = productDetails.ma_san_pham.ToString();
                    txt_tensanpham.Text = productDetails.ten_san_pham;
                    cbb_maloai.EditValue = productDetails.ma_loai;
                    cbb_mathuonghieu.EditValue = productDetails.ma_thuong_hieu;
                    txt_giamgia.Text = productDetails.giam_gia.ToString();
                    txt_soluongkichthuoc.Text = productDetails.so_luong_kich_thuoc.ToString();
                    txt_soluongmausac.Text = productDetails.so_luong_mau_sac.ToString();
                    txt_soluong.Text = productDetails.so_luong.ToString();
                    txt_mota.Text = productDetails.mo_ta;
                    txt_giabinhquan.Text = productDetails.gia_binh_quan.ToString();
                    cbb_hinhthucban.EditValue = productDetails.hinh_thuc_ban;

                    // Hiển thị hình ảnh đầu tiên nếu có
                    if (imagePaths != null && imagePaths.Count > 0)
                    {
                        string firstImagePath = imagePaths[0];
                        if (File.Exists(firstImagePath))
                        {
                            pb_anhsp.Image = Image.FromFile(firstImagePath);
                            pb_anhsp.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            pb_anhsp.Image = null; // Xóa ảnh nếu file không tồn tại
                            Debug.WriteLine($"File không tồn tại: {firstImagePath}");
                        }
                    }
                    else
                    {
                        pb_anhsp.Image = null; // Không có ảnh nào
                        XtraMessageBox.Show("Không tìm thấy hình ảnh cho sản phẩm này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    clearsp(); // Xóa thông tin nếu không tìm thấy sản phẩm
                }
            }
            else
            {
                clearsp(); // Xóa thông tin nếu không có dòng nào được chọn
            }
        }











        private void loadSize()
        {
            // Khởi tạo lớp BLL và lấy dữ liệu kích thước
            size_bll = new size_sql_BLL();
            var sizes = size_bll.get_all_size();

            if (sizes != null && sizes.Count > 0)
            {
                // Gán dữ liệu cho GridControl
                gct_size.DataSource = sizes;

                // Cấu hình GridView (gct_size phải là một GridControl)
                GridView gridView = gct_size.MainView as GridView;
                if (gridView != null)
                {
                    gridView.OptionsBehavior.Editable = false;
                    gridView.Columns["ma_kich_thuoc"].Caption = "Mã Kích Thước";
                    gridView.Columns["ten_kich_thuoc"].Caption = "Tên Kích Thước";
                    gridView.Columns["phu_phi_size"].Caption = "Phụ Phí Size";

                    // Tự động điều chỉnh độ rộng các cột dựa trên nội dung
                    gridView.BestFitColumns();
                }
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu kích thước để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadSizeLenControls()
        {
            GridView gridView = gct_size.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                int makichthuoc = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_kich_thuoc"));

                var sizeDetails = size_bll.getSizeById(makichthuoc); // Gọi phương thức mới thêm trong BLL

                if (sizeDetails != null)
                {
                    txt_makichthuoc.Text = sizeDetails.ma_kich_thuoc.ToString();
                    txt_tenkichthuoc.Text = sizeDetails.ten_kich_thuoc;
                    txt_phuphisize.Text = sizeDetails.phu_phi_size.ToString();
                }
            }
        }

        private void loadMauSac()
        {
            // Khởi tạo lớp BLL và lấy dữ liệu màu sắc
            mau_sac_bll = new mau_sac_sql_BLL();
            var ms = mau_sac_bll.get_all_mau_sac();

            if (ms != null && ms.Count > 0)
            {
                // Gán dữ liệu cho GridControl
                gct_mausac.DataSource = ms;

                // Cấu hình GridView (gct_mausac phải là một GridControl)
                GridView gridView = gct_mausac.MainView as GridView;
                if (gridView != null)
                {
                    gridView.OptionsBehavior.Editable = false;
                    gridView.Columns["ma_mau_sac"].Caption = "Mã Màu Sắc";
                    gridView.Columns["ten_mau_sac"].Caption = "Tên Màu Sắc";
                    gridView.Columns["phu_phi_mau_sac"].Caption = "Phụ Phí Màu Sắc";

                    // Tự động điều chỉnh độ rộng các cột dựa trên nội dung
                    gridView.BestFitColumns();
                }
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu kích thước để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadColourLenControls()
        {
            GridView gridView = gct_mausac.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                int mamausac = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_mau_sac"));

                var msDetails = mau_sac_bll.getMauSacById(mamausac); // Gọi phương thức mới thêm trong BLL

                if (msDetails != null)
                {
                    txt_mamausac.Text = msDetails.ma_mau_sac.ToString();
                    txt_tenmausac.Text = msDetails.ten_mau_sac;
                    txt_phuphimausac.Text = msDetails.phu_phi_mausac.ToString();
                }
            }
        }


        private void loadThuongHieu()
        {
            // Khởi tạo lớp BLL và lấy dữ liệu thương hiệu
            thuong_hieu_bll = new thuong_hieu_sql_BLL();
            var th = thuong_hieu_bll.get_all_thuong_hieu();

            if (th != null && th.Count > 0)
            {
                // Gán dữ liệu cho GridControl
                gct_thuonghieu.DataSource = th;

                // Cấu hình GridView (gct_thuonghieu phải là một GridControl)
                GridView gridView = gct_thuonghieu.MainView as GridView;
                if (gridView != null)
                {
                    gridView.OptionsBehavior.Editable = false;
                    gridView.Columns["ma_thuong_hieu"].Caption = "Mã Thương Hiệu";
                    gridView.Columns["ten_thuong_hieu"].Caption = "Tên Thương Hiệu";
                    gridView.Columns["mo_ta"].Caption = "Mô Tả";

                    // Tự động điều chỉnh độ rộng các cột dựa trên nội dung
                    gridView.BestFitColumns();
                }
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu kích thước để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadThuongHieuLenControls()
        {
            GridView gridView = gct_thuonghieu.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                int mathuonghieu = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_thuong_hieu"));

                var thDetails = thuong_hieu_bll.getThuongHieucById(mathuonghieu); // Gọi phương thức mới thêm trong BLL

                if (thDetails != null)
                {
                    txt_math.Text = thDetails.ma_thuong_hieu.ToString();
                    txt_tenth.Text = thDetails.ten_thuong_hieu;
                    txt_motath.Text = thDetails.mo_ta.ToString();
                }
            }
        }


        private void loadNhomLoai()
        {
            // Khởi tạo lớp BLL và lấy dữ liệu nhóm loại
            nhom_loai_bll = new nhom_loai_sql_BLL();
            var nl = nhom_loai_bll.get_all_nhom_loai();

            if (nl != null && nl.Count > 0)
            {
                // Gán dữ liệu cho GridControl
                gct_nhomloai.DataSource = nl;

                // Cấu hình GridView (gct_nhomloai phải là một GridControl)
                GridView gridView = gct_nhomloai.MainView as GridView;
                if (gridView != null)
                {
                    gridView.OptionsBehavior.Editable = false;
                    gridView.Columns["ma_nhom_loai"].Caption = "Mã Nhóm Loại";
                    gridView.Columns["ten_nhom_loai"].Caption = "Tên Nhóm Loại";
                    gridView.Columns["chi_tiet"].Caption = "Chi Tiết";

                    // Tự động điều chỉnh độ rộng các cột dựa trên nội dung
                    gridView.BestFitColumns();
                }
            }
            else
            {
                XtraMessageBox.Show("Không có dữ liệu kích thước để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadNhomLoaiLenControls()
        {
            GridView gridView = gct_nhomloai.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                int manhomloai = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_nhom_loai"));

                var nlDetails = nhom_loai_bll.getNhomLoaiById(manhomloai); // Gọi phương thức mới thêm trong BLL

                if (nlDetails != null)
                {
                    txt_manhomloai.Text = nlDetails.ma_nhom_loai.ToString();
                    txt_tennhomloai.Text = nlDetails.ten_nhom_loai;
                    txt_chitiet.Text = nlDetails.chi_tiet.ToString();
                }
            }
        }


        private void clearsp()
        {
            txt_masanpham.Text = "";
            txt_tensanpham.Text = "";
            cbb_maloai.EditValue = null;
            cbb_mathuonghieu.EditValue = null;
            cbb_hinhthucban.EditValue = null;
            txt_giamgia.Text = "";
            txt_soluongkichthuoc.Text = "";
            txt_soluongmausac.Text = "";
            txt_soluong.Text = "";
            txt_mota.Text = "";
            txt_giabinhquan.Text = "";
            gct_ttsp.DataSource = null;
            if (pb_anhsp.Image != null)
            {
                pb_anhsp.Image.Dispose(); // Giải phóng tài nguyên hình ảnh
                pb_anhsp.Image = null;    // Xóa hình ảnh trong PictureBox
            }
        }

        private void clearsize()
        {
            txt_makichthuoc.Text = "";
            txt_tenkichthuoc.Text = "";
            txt_phuphisize.Text = "";
        }

        private void clearmausac()
        {
            txt_mamausac.Text = "";
            txt_tenmausac.Text = "";
            txt_phuphimausac.Text = "";
        }

        private void clearthuonghieu()
        {
            txt_math.Text = "";
            txt_tenth.Text = "";
            txt_motath.Text = "";
        }

        private void clearnhomloai()
        {
            txt_manhomloai.Text = "";
            txt_tennhomloai.Text = "";
            txt_chitiet.Text = "";
        }


        public void ShowSupplierTotalsDialog(DataGridView dgv)
        {
            // Tính toán tổng giá nhập theo nhà cung cấp
            Dictionary<int, decimal> supplierTotals = CalculateSupplierTotals(dgv);

            // Tạo danh sách string để hiển thị theo định dạng yêu cầu
            List<string> supplierTotalsText = supplierTotals
                .Select(item => $"Thông tin chi tiết sản phẩm {item.Key}: {item.Value}")
                .ToList();

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

            // Label để hiển thị thông tin tổng tiền nhà cung cấp
            Label lblInfo = new Label
            {
                Text = string.Join(Environment.NewLine, supplierTotalsText),
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
                if (row.Cells["ma_san_pham"].Value != null)
                {
                    // Lấy mã nhà cung cấp
                    int mattsp = Convert.ToInt32(row.Cells["ma_thong_tin_san_pham"].Value);

                    // Lấy giá nhập
                    int masp = Convert.ToInt32(row.Cells["ma_san_pham"].Value);
                }
            }

            return supplierTotals;
        }



        private bool kiemTraSP()
        {

            // Kiểm tra trường Tên Sản Phẩm
            if (string.IsNullOrWhiteSpace(txt_tensanpham.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tensanpham.Focus();
                return false;
            }

            // Kiểm tra ComboBox Mã Loại
            if (cbb_maloai.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn mã loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_maloai.Focus();
                return false;
            }

            // Kiểm tra ComboBox Mã Thương Hiệu
            if (cbb_mathuonghieu.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn mã thương hiệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_mathuonghieu.Focus();
                return false;
            }

            // Kiểm tra ComboBox Hình Thức Bán
            if (cbb_hinhthucban.SelectedItem == null)
            {
                XtraMessageBox.Show("Vui lòng chọn hình thức bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_hinhthucban.Focus();
                return false;
            }

            // Kiểm tra trường Giảm Giá
            if (!decimal.TryParse(txt_giamgia.Text, out decimal giamGia) || giamGia < 0 || giamGia > 100)
            {
                XtraMessageBox.Show("Giảm giá không hợp lệ. Vui lòng nhập một số trong khoảng 0-100.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_giamgia.Focus();
                return false;
            }

            // Kiểm tra trường Số Lượng Kích Thước
            if (!int.TryParse(txt_soluongkichthuoc.Text, out int soLuongKichThuoc) || soLuongKichThuoc < 0)
            {
                XtraMessageBox.Show("Số lượng kích thước không hợp lệ. Vui lòng nhập một số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soluongkichthuoc.Focus();
                return false;
            }

            // Kiểm tra trường Số Lượng Màu Sắc
            if (!int.TryParse(txt_soluongmausac.Text, out int soLuongMauSac) || soLuongMauSac < 0)
            {
                XtraMessageBox.Show("Số lượng màu sắc không hợp lệ. Vui lòng nhập một số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soluongmausac.Focus();
                return false;
            }

            // Kiểm tra trường Số Lượng
            if (!int.TryParse(txt_soluong.Text, out int soLuong) || soLuong < 0)
            {
                XtraMessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập một số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soluong.Focus();
                return false;
            }

            // Kiểm tra trường Mô Tả
            if (string.IsNullOrWhiteSpace(txt_mota.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập mô tả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mota.Focus();
                return false;
            }

            // Kiểm tra trường Giá Bình Quân
            if (!decimal.TryParse(txt_giabinhquan.Text, out decimal giaBinhQuan) || giaBinhQuan < 0)
            {
                XtraMessageBox.Show("Giá bình quân không hợp lệ. Vui lòng nhập một số không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_giabinhquan.Focus();
                return false;
            }

            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }


        private string SaveImageToLocalFolder(string imagePath, int productId)
        {
            try
            {
                string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string newImagePath = Path.Combine(directoryPath, $"{productId}_{Path.GetFileName(imagePath)}");
                File.Copy(imagePath, newImagePath, true); // Ghi đè nếu tệp đã tồn tại
                return newImagePath;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi khi sao chép hình ảnh: " + ex.Message);
                return null;
            }
        }












        public void themSP()
        {
            if (!kiemTraSP()) return;

            try
            {
                // Tạo đối tượng san_pham_DTO từ các control
                var newProductDTO = new san_pham_DTO
                {
                    ten_san_pham = txt_tensanpham.Text,
                    ma_loai = int.Parse(cbb_maloai.EditValue.ToString()),
                    ma_thuong_hieu = int.Parse(cbb_mathuonghieu.EditValue.ToString()),
                    giam_gia = decimal.Parse(txt_giamgia.Text),
                    so_luong_kich_thuoc = int.Parse(txt_soluongkichthuoc.Text),
                    so_luong_mau_sac = int.Parse(txt_soluongmausac.Text),
                    so_luong = int.Parse(txt_soluong.Text),
                    mo_ta = txt_mota.Text,
                    gia_binh_quan = decimal.Parse(txt_giabinhquan.Text),
                    hinh_thuc_ban = int.Parse(cbb_hinhthucban.EditValue.ToString())
                };

                // Chuyển đổi từ san_pham_DTO sang san_pham
                var newProduct = new san_pham
                {
                    ten_san_pham = newProductDTO.ten_san_pham,
                    ma_loai = newProductDTO.ma_loai,
                    ma_thuong_hieu = newProductDTO.ma_thuong_hieu,
                    giam_gia = newProductDTO.giam_gia,
                    so_luong_kich_thuoc = newProductDTO.so_luong_kich_thuoc,
                    so_luong_mau_sac = newProductDTO.so_luong_mau_sac,
                    so_luong = newProductDTO.so_luong,
                    mo_ta = newProductDTO.mo_ta,
                    gia_binh_quan = newProductDTO.gia_binh_quan,
                    hinh_thuc_ban = newProductDTO.hinh_thuc_ban
                };

                // Gọi BLL để thêm sản phẩm
                bool isAdded = sp_bll.AddSP(newProduct);

                if (isAdded)
                {
                    int newProductId = sp_bll.get_id_sp_by_name(newProduct.ten_san_pham);

                    // Lưu hình ảnh nếu có
                    if (pb_anhsp.Image != null && !string.IsNullOrEmpty(selectedImagePath))
                    {
                        string newImagePath = SaveImageToLocalFolder(selectedImagePath, newProductId);

                        if (!string.IsNullOrEmpty(newImagePath))
                        {
                            sp_bll.AddImageForProduct(newProductId, newImagePath);
                        }
                    }

                    XtraMessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadSP();
                    clearsp();
                }
                else
                {
                    XtraMessageBox.Show("Thêm sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void luuSP()
        {
            try
            {
                var product = new san_pham_DTO
                {
                    ma_san_pham = int.Parse(txt_masanpham.Text),
                    ten_san_pham = txt_tensanpham.Text,
                    ma_loai = int.Parse(cbb_maloai.EditValue.ToString()),
                    ma_thuong_hieu = int.Parse(cbb_mathuonghieu.EditValue.ToString()),
                    giam_gia = decimal.Parse(txt_giamgia.Text),
                    so_luong_kich_thuoc = int.Parse(txt_soluongkichthuoc.Text),
                    so_luong_mau_sac = int.Parse(txt_soluongmausac.Text),
                    so_luong = int.Parse(txt_soluong.Text),
                    mo_ta = txt_mota.Text,
                    gia_binh_quan = decimal.Parse(txt_giabinhquan.Text),
                    hinh_thuc_ban = int.Parse(cbb_hinhthucban.EditValue.ToString())
                };

                // Lưu sản phẩm
                bool isSaved = sp_bll.SaveProducts(product);

                if (isSaved)
                {
                    Debug.WriteLine($"Sản phẩm {product.ten_san_pham} được lưu thành công.");

                    // Kiểm tra nếu có hình ảnh mới đã chọn
                    if (!string.IsNullOrEmpty(selectedImagePath))
                    {
                        string savedImagePath = SaveImageToLocalFolder(selectedImagePath, product.ma_san_pham);

                        if (!string.IsNullOrEmpty(savedImagePath))
                        {
                            bool isImageSaved = sp_bll.AddImageForProduct(product.ma_san_pham, savedImagePath);
                            if (isImageSaved)
                            {
                                Debug.WriteLine("Hình ảnh được lưu hoặc cập nhật thành công.");
                            }
                            else
                            {
                                Debug.WriteLine("Không thể lưu hoặc cập nhật hình ảnh vào cơ sở dữ liệu.");
                            }
                        }
                    }

                    // Thông báo thành công và tải lại danh sách sản phẩm
                    XtraMessageBox.Show("Lưu sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadSP();
                    clearsp();
                }
                else
                {
                    XtraMessageBox.Show("Lưu sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi: {ex.Message}");
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void xoaSP()
        {
            GridView gridView = gct_sp.MainView as GridView;
            if (gridView == null)
                return;

            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            int masp = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_san_pham"));

            var confirmResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa " + $"mã sản phẩm: {masp}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                bool deleteSuccess = sp_bll.DeleteSPById(masp);

                if (deleteSuccess)
                {
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridView.DeleteRow(selectedRowHandle);
                    clearsp();
                    gct_sp.RefreshDataSource();
                }
                else
                {
                    XtraMessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Lỗi tồn tải ở bảng khác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                clearsp();
                gct_sp.RefreshDataSource();
            }
        }



        private bool kiemTraSize()
        {

            // Kiểm tra trường Tên Sản Phẩm
            if (string.IsNullOrWhiteSpace(txt_tenkichthuoc.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên kích thước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenkichthuoc.Focus();
                return false;
            }

            // Kiểm tra trường Phụ Phí Size
            if (string.IsNullOrWhiteSpace(txt_phuphisize.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập phụ phí size.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phuphisize.Focus();
                return false;
            }

            if (!decimal.TryParse(txt_phuphisize.Text, out decimal phuPhiSize))
            {
                XtraMessageBox.Show("Phụ phí size không hợp lệ. Vui lòng nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phuphisize.Focus();
                return false;
            }


            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }

        private bool kiemTraTenKichThuoc(string tenKichThuoc)
        {
            // Danh sách các kích thước hợp lệ
            var validSizes = new List<string> { "S", "M", "L", "XL", "XXL", "3XL", "4XL", "5XL", "Freesize" };

            if (!validSizes.Contains(tenKichThuoc))
            {
                XtraMessageBox.Show("Tên kích thước không hợp lệ. Vui lòng nhập đúng tên kích thước (S, M, L, XL,...).",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        public void themSize()
        {
            if (!kiemTraSize())
            {
                return; // Dừng nếu kiểm tra không hợp lệ
            }

            try
            {
                // Kiểm tra tên kích thước
                if (!kiemTraTenKichThuoc(txt_tenkichthuoc.Text))
                {
                    return; // Dừng nếu tên kích thước không hợp lệ
                }

                var newSize = new kich_thuoc
                {
                    ten_kich_thuoc = txt_tenkichthuoc.Text,
                    phu_phi_size = decimal.Parse(txt_phuphisize.Text)
                };

                // Gọi BLL để thêm kích thước
                bool isAdded = size_bll.AddSize(newSize);

                if (isAdded)
                {
                    XtraMessageBox.Show("Thêm kích thước thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearsize(); // Xóa dữ liệu trên form
                    loadSize(); // Tải lại danh sách kích thước
                }
                else
                {
                    XtraMessageBox.Show("Thêm kích thước thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi không xác định: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public void suaSize()
        {
            if (!kiemTraSize())
            {
                return; // Dừng nếu kiểm tra không hợp lệ
            }

            // Danh sách các kích thước hợp lệ
            var validSizes = new List<string> { "S", "M", "L", "XL", "XXL", "3XL", "4XL", "5XL", "Freesize" };

            try
            {
                if (int.TryParse(txt_makichthuoc.Text, out int maKichThuoc))
                {
                    // Kiểm tra tên kích thước hợp lệ
                    if (!validSizes.Contains(txt_tenkichthuoc.Text))
                    {
                        XtraMessageBox.Show("Tên kích thước không hợp lệ. Vui lòng nhập đúng tên kích thước (S, M, L, XL,...).",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var updatedSize = new kich_thuoc
                    {
                        ma_kich_thuoc = maKichThuoc,
                        ten_kich_thuoc = txt_tenkichthuoc.Text,
                        phu_phi_size = decimal.Parse(txt_phuphisize.Text)
                    };

                    // Gọi BLL để sửa kích thước
                    bool isUpdated = size_bll.UpdateSize(updatedSize);

                    if (isUpdated)
                    {
                        XtraMessageBox.Show("Sửa kích thước thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadSize(); // Tải lại danh sách kích thước
                        clearsize(); // Xóa dữ liệu trên form
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa kích thước thất bại. Mã kích thước không tồn tại.",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mã kích thước không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi không xác định: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void xoaSize()
        {
            GridView gridView = gct_size.MainView as GridView;
            if (gridView == null || gridView.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn một kích thước để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã kích thước từ dòng được chọn
            int maKichThuoc = Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, "ma_kich_thuoc"));

            // Hiển thị xác nhận trước khi xóa
            var confirmResult = XtraMessageBox.Show($"Bạn có chắc chắn muốn xóa kích thước có mã {maKichThuoc}?",
                                                     "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Gọi BLL để xóa kích thước
                    bool isDeleted = size_bll.DeleteSizeById(maKichThuoc);

                    if (isDeleted)
                    {
                        XtraMessageBox.Show("Xóa kích thước thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearsize();
                        loadSize(); // Tải lại danh sách kích thước
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa kích thước thất bại. Có thể kích thước đang được sử dụng ở bảng khác.",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lỗi khi xóa kích thước: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private bool kiemTraMS()
        {

            // Kiểm tra trường Tên Màu Sắc
            if (string.IsNullOrWhiteSpace(txt_tenmausac.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên màu sắc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenmausac.Focus();
                return false;
            }

            // Kiểm tra trường Phụ Phí Màu Sắc
            if (string.IsNullOrWhiteSpace(txt_phuphimausac.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập phụ phí màu sắc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phuphimausac.Focus();
                return false;
            }
            if (!decimal.TryParse(txt_phuphimausac.Text, out decimal phuPhiMauSac))
            {
                XtraMessageBox.Show("Phụ phí màu sắc không hợp lệ. Vui lòng nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_phuphimausac.Focus();
                return false;
            }


            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }


        public void themMS()
        {
            if (!kiemTraMS())
            {
                return;
            }

            try
            {
                var newMS = new mau_sac
                {
                    ten_mau_sac = txt_tenmausac.Text,
                    phu_phi_mausac = decimal.Parse(txt_phuphimausac.Text)
                };

                bool isAdded = mau_sac_bll.AddMS(newMS);

                if (isAdded)
                {
                    XtraMessageBox.Show("Thêm màu sắc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearmausac();
                    loadMauSac();
                }
                else
                {
                    XtraMessageBox.Show("Thêm màu sắc thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suaMS()
        {
            try
            {
                if (int.TryParse(txt_mamausac.Text, out int maMauSac))
                {
                    var updatedMS = new mau_sac
                    {
                        ma_mau_sac = maMauSac,
                        ten_mau_sac = txt_tenmausac.Text,
                        phu_phi_mausac = decimal.Parse(txt_phuphimausac.Text)
                    };

                    bool isUpdated = mau_sac_bll.UpdateMS(updatedMS);

                    if (isUpdated)
                    {
                        XtraMessageBox.Show("Sửa màu sắc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearmausac();
                        loadMauSac();                      
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa màu sắc thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mã màu sắc không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void xoaMS()
        {
            GridView gridView = gct_mausac.MainView as GridView;
            if (gridView == null)
                return;

            // Kiểm tra xem có dòng nào được chọn không
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            // Lấy giá trị của các cột "ma_mau_sac" từ dòng được chọn
            int maMS = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_mau_sac"));

            // Hiển thị xác nhận trước khi xóa
            var confirmResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa " + $"mã màu sắc: {maMS}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Gọi phương thức xóa từ lớp DAL
                mau_sac_bll = new mau_sac_sql_BLL();
                bool deleteSuccess = mau_sac_bll.DeleteMSById(maMS);

                if (deleteSuccess)
                {
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dòng khỏi GridView và làm mới lại dữ liệu hiển thị
                    gridView.DeleteRow(selectedRowHandle);
                    clearmausac();
                    gct_mausac.RefreshDataSource();
                }
                else
                {
                    XtraMessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Lỗi tồn tải ở bảng khác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                clearmausac();
                gct_mausac.RefreshDataSource();
            }
        }


        private bool kiemTraTH()
        {

            // Kiểm tra trường Tên Thương Hiệu
            if (string.IsNullOrWhiteSpace(txt_tenth.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên thương hiệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenth.Focus();
                return false;
            }

            // Kiểm tra trường Mô Tả Thương Hiệu
            if (string.IsNullOrWhiteSpace(txt_motath.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập mô tả thương hiệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_motath.Focus();
                return false;
            }

            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }


        public void themTH()
        {
            if (!kiemTraTH())
            {
                return;
            }

            try
            {
                var newTH = new thuong_hieu
                {
                    ten_thuong_hieu = txt_tenth.Text,
                    mo_ta = txt_motath.Text
                };

                bool isAdded = thuong_hieu_bll.AddTH(newTH);

                if (isAdded)
                {
                    XtraMessageBox.Show("Thêm thương hiệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearthuonghieu();
                    loadThuongHieu();
                }
                else
                {
                    XtraMessageBox.Show("Thêm thương hiệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suaTH()
        {
            try
            {
                if (int.TryParse(txt_math.Text, out int maThuongHieu))
                {
                    var updatedMS = new thuong_hieu
                    {
                        ma_thuong_hieu = maThuongHieu,
                        ten_thuong_hieu = txt_tenth.Text,
                        mo_ta = txt_motath.Text
                    };

                    bool isUpdated = thuong_hieu_bll.UpdateTH(updatedMS);

                    if (isUpdated)
                    {
                        XtraMessageBox.Show("Sửa thương hiệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearthuonghieu();
                        loadThuongHieu();
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa thương hiệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mã thương hiệu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void xoaTH()
        {
            GridView gridView = gct_thuonghieu.MainView as GridView;
            if (gridView == null)
                return;

            // Kiểm tra xem có dòng nào được chọn không
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            // Lấy giá trị của các cột "ma_thuong_hieu" từ dòng được chọn
            int maTH = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_thuong_hieu"));

            // Hiển thị xác nhận trước khi xóa
            var confirmResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa " + $"mã thương hiệu: {maTH}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Gọi phương thức xóa từ lớp DAL
                thuong_hieu_bll = new thuong_hieu_sql_BLL();
                bool deleteSuccess = thuong_hieu_bll.DeleteTHById(maTH);

                if (deleteSuccess)
                {
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dòng khỏi GridView và làm mới lại dữ liệu hiển thị
                    gridView.DeleteRow(selectedRowHandle);
                    clearthuonghieu();
                    gct_thuonghieu.RefreshDataSource();
                }
                else
                {
                    XtraMessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Lỗi tồn tải ở bảng khác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                clearthuonghieu();
                gct_thuonghieu.RefreshDataSource();
            }
        }


        private bool kiemTraNL()
        {

            // Kiểm tra trường Tên Nhóm Loại
            if (string.IsNullOrWhiteSpace(txt_tennhomloai.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên nhóm loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tennhomloai.Focus();
                return false;
            }

            // Kiểm tra trường Chi Tiết Nhóm Loại
            if (string.IsNullOrWhiteSpace(txt_chitiet.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập chi tiết nhóm loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_chitiet.Focus();
                return false;
            }

            // Nếu tất cả các kiểm tra đều hợp lệ
            return true;
        }


        public void themNL()
        {
            if (!kiemTraNL())
            {
                return;
            }

            try
            {
                var newNL = new nhom_loai
                {
                    ten_nhom_loai = txt_tennhomloai.Text,
                    chi_tiet = txt_chitiet.Text
                };

                bool isAdded = nhom_loai_bll.AddNL(newNL);

                if (isAdded)
                {
                    XtraMessageBox.Show("Thêm nhóm loại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearnhomloai();
                    loadNhomLoai();
                }
                else
                {
                    XtraMessageBox.Show("Thêm nhóm loại thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suaNL()
        {
            try
            {
                if (int.TryParse(txt_manhomloai.Text, out int maNhomLoai))
                {
                    var updatedNL = new nhom_loai
                    {
                        ma_nhom_loai = maNhomLoai,
                        ten_nhom_loai = txt_tennhomloai.Text,
                        chi_tiet = txt_chitiet.Text
                    };

                    bool isUpdated = nhom_loai_bll.UpdateNL(updatedNL);

                    if (isUpdated)
                    {
                        XtraMessageBox.Show("Sửa nhóm loại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearnhomloai();
                        loadNhomLoai();
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa nhóm loại thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mã nhóm loại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void xoaNL()
        {
            GridView gridView = gct_nhomloai.MainView as GridView;
            if (gridView == null)
                return;

            // Kiểm tra xem có dòng nào được chọn không
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            // Lấy giá trị của các cột "ma_thuong_hieu" từ dòng được chọn
            int maNL = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_nhom_loai"));

            // Hiển thị xác nhận trước khi xóa
            var confirmResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa " + $"mã nhóm loại: {maNL}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Gọi phương thức xóa từ lớp DAL
                nhom_loai_bll = new nhom_loai_sql_BLL();
                bool deleteSuccess = nhom_loai_bll.DeleteNLById(maNL);

                if (deleteSuccess)
                {
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dòng khỏi GridView và làm mới lại dữ liệu hiển thị
                    gridView.DeleteRow(selectedRowHandle);
                    clearnhomloai();
                    gct_nhomloai.RefreshDataSource();
                }
                else
                {
                    XtraMessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Lỗi tồn tải ở bảng khác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                clearnhomloai();
                gct_nhomloai.RefreshDataSource();
            }
        }





        private void ShowWarning(string message)
        {
            XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }




    }
}
