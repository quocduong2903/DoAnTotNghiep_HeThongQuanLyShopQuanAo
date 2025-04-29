using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;  // Sử dụng LINQ
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;

namespace GUI
{
    public partial class frmDuyetSanPham : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private thuoc_tinh_sp_sql_BLL ttsp_bll;
        private chi_tiet_nhap_sql_BLL ctnhap_bll;
        private nhap_hang_sql_BLL nhap_bll;
        public event EventHandler FormClosedEvent;
        private List<thuoc_tinh_san_pham> ttsp;
        private int iddonduyet;


        public frmDuyetSanPham(int id)
        {
            InitializeComponent();
            this.iddonduyet = id;
            ttsp_bll = new thuoc_tinh_sp_sql_BLL();
            this.Load += FrmDuyetSanPham_Load;
            // Lấy dữ liệu từ database và chuyển thành List<Product> để dễ xử lý

            ctnhap_bll = new chi_tiet_nhap_sql_BLL();
            dgv_dsnhap.Click += Dgv_dsnhap_Click;
            bt_duyet.Click += Bt_duyet_Click;
            GridView gridView1 = gdv_duyet_sp.MainView as GridView;
            bt_ht.Click += Bt_ht_Click;
            // Gắn sự kiện CellValueChanged cho gridView của gridControl1
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            this.FormClosed += FrmDuyetSanPham_FormClosed;
           
        }

        private void FrmDuyetSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void Bt_ht_Click(object sender, EventArgs e)
        {
            if (CheckTrangThaiAllApproved())
            {
                nhap_bll = new nhap_hang_sql_BLL();
                if (nhap_bll.update_tt_ht(iddonduyet))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Đã cập nhật dữ liệu.", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Có lỗi xảy ra.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Có đơn chưa hoàn thành.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        bool CheckTrangThaiAllApproved()
        {
            GridView gridView = dgv_dsnhap.MainView as GridView;
            // Lặp qua tất cả các dòng trong GridView
            for (int i = 0; i < gridView.RowCount; i++)
            {
                // Lấy giá trị của cột "trang_thai" cho dòng hiện tại
                var trangThai = gridView.GetRowCellValue(i, "trang_thai");

                // Nếu giá trị không phải là "Đã duyệt", trả về false
                if (trangThai == null || trangThai.ToString() != "Đã duyệt")
                {
                    return false;
                }
            }

            // Nếu tất cả các giá trị là "Đã duyệt", trả về true
            return true;
        }

        int kiemTra()
        {
            GridView gridView1 = dgv_dsnhap.MainView as GridView;
            GridView gridView2 = gdv_duyet_sp.MainView as GridView;

            // Kiểm tra nếu GridView không hợp lệ
            if (gridView1 == null || gridView2 == null)
            {
                return 0; // Trả về 0 nếu không có GridView hợp lệ
            }
            else
            {
                int dongChon = gridView1.FocusedRowHandle;

                // Kiểm tra nếu không có dòng được chọn trong gridView1
                if (dongChon < 0)
                {
                    return 0; // Không có dòng được chọn
                }

                // Lấy số lượng từ GridView thứ 2 (gdv_duyet_sp)
                int sl_gdv = Convert.ToInt32(gridView1.GetRowCellValue(dongChon, "so_luong"));
                int totalSoLuong = 0;
                string tt = Convert.ToString(gridView1.GetRowCellValue(dongChon, "trang_thai"));
                if (tt.Equals("Đã duyệt"))
                {
                    return 3;
                }

                // Duyệt qua tất cả các dòng trong GridView thứ 2
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    // Lấy giá trị của cột 'so_luong_ton' ở dòng thứ i
                    var soLuong = gridView2.GetRowCellValue(i, "so_luong_ton");

                    // Kiểm tra nếu giá trị hợp lệ và tính tổng
                    if (soLuong != null && int.TryParse(soLuong.ToString(), out int result))
                    {
                        totalSoLuong += result; // Cộng dồn số lượng
                    }
                }
                if (totalSoLuong == 0)
                {
                    return 0;
                }
                // Kiểm tra và trả về kết quả dựa trên so sánh giữa sl_gdv và totalSoLuong
                if (sl_gdv == totalSoLuong)
                {
                    return 1; // Trả về 1 nếu số lượng bằng
                }
                else if (sl_gdv < totalSoLuong)
                {
                    return 2; // Trả về 2 nếu sl_gdv lớn hơn totalSoLuong
                }
                else
                {
                    return -1; // Trả về -1 nếu sl_gdv nhỏ hơn totalSoLuong
                }
            }
        }

        private void GridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }





        List<thuoc_tinh_san_pham> load_ds_ttsp()
        {
            List<thuoc_tinh_san_pham> list = new List<thuoc_tinh_san_pham>();

            GridView gridView = gdv_duyet_sp.MainView as GridView;
            if (gridView == null)
                return list;

            for (int i = 0; i < gridView.RowCount; i++)
            {
                // Lấy giá trị của cột ma_thuoc_tinh
                var maThuocTinhValue = gridView.GetRowCellValue(i, "ma_thuoc_tinh");
                // Lấy giá trị của cột so_luong_ton
                var soLuongTonValue = gridView.GetRowCellValue(i, "so_luong_ton");

                if (maThuocTinhValue != null && soLuongTonValue != null)
                {
                    // Tạo một đối tượng mới và thêm vào list
                    list.Add(new thuoc_tinh_san_pham
                    {
                        ma_thuoc_tinh = Convert.ToInt32(maThuocTinhValue),
                        so_luong_ton = Convert.ToInt32(soLuongTonValue)
                    });
                }
            }

            return list;
        }
        void update_duyet()
        {
            // Lấy đối tượng GridView
            GridView gridView = dgv_dsnhap.MainView as GridView;

            if (gridView == null) return;

            // Lấy dòng đang chọn
            int dongChon = gridView.FocusedRowHandle;

            // Kiểm tra nếu dòng được chọn hợp lệ
            if (dongChon >= 0)
            {
                // Cập nhật giá trị của cột Trang_thai thành "Đã duyệt"
                gridView.SetRowCellValue(dongChon, "trang_thai", "Đã duyệt");

                // Làm mới dữ liệu trên GridView
                gridView.RefreshRow(dongChon);
                gridView.RefreshData();
            }
        }

        private void Bt_duyet_Click(object sender, EventArgs e)
        {
            int check = kiemTra();
            if (check == 3)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Sản phẩm đã duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (check == 1)
            {
                ttsp_bll = new thuoc_tinh_sp_sql_BLL();
                ttsp = load_ds_ttsp();
                if (ttsp_bll.updated_tt_sp(ttsp))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Duyệt thành công!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    update_duyet();
                    load_gdv_duyet_sp(0);
                    return;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Duyệt thất bại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (check == -1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng nhập chưa đủ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (check == 2)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng vượt quá số lượng có.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi đầu vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Dgv_dsnhap_Click(object sender, EventArgs e)
        {
            GridView gridView = dgv_dsnhap.MainView as GridView;
            if (gridView != null)
            {
                int focusedRowHandle = gridView.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    var maSanPham = gridView.GetRowCellValue(focusedRowHandle, "ma_san_pham");
                    var tt = gridView.GetRowCellValue(focusedRowHandle, "trang_thai");
                    if (tt.Equals("Đã duyệt"))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Sản phẩm đã duyệt rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (maSanPham != null)
                    {
                        load_gdv_duyet_sp(int.Parse(maSanPham.ToString()));
                    }
                }
            }
        }



        // Xử lý sự kiện MouseClick


        private void FrmDuyetSanPham_Load(object sender, EventArgs e)
        {
            load_gdv_duyet_sp(0);
            load_dgv_sp(dgv_dsnhap, ctnhap_bll.get_ct_list_by_id(iddonduyet));
       
        }

        void load_gdv_duyet_sp(int id)
        {
            var products = ttsp_bll.get_all_ttsp_by_id(id).ToList();
            SetupGridControl(gdv_duyet_sp, products);
        }
        int soluonggoc(int ma, List<chi_tiet_nhap_hang> products)
        {
            // Sử dụng LINQ để tìm sản phẩm có mã `ma`
            var product = products.FirstOrDefault(p => p.ma_san_pham == ma);

            // Nếu tìm thấy sản phẩm, trả về số lượng; nếu không, trả về 0 hoặc giá trị mặc định
            return product != null ? product.so_luong : 0;
        }

        void load_dgv_sp(GridControl gridControl, List<chi_tiet_nhap_hang> products)
        {
            GridView gridView = gridControl.MainView as GridView;
            if (gridView == null)
                return;




            gridControl.DataSource = products;
            gridView.OptionsBehavior.Editable = false;
            gridView.Columns["ma_nhap_hang"].Caption = "Mã Nhập Hàng";
            gridView.Columns["ma_san_pham"].Caption = "Mã Sản phẩm";
            gridView.Columns["so_luong"].Caption = "Tổng Số Lượng";
            gridView.Columns["gia_nhap"].Caption = "Tổng Giá Nhập";
            gridView.Columns["trang_thai"].Caption = "Trạng Thái";
            var columnTrangThai = gridView.Columns["trang_thai"];
            if (columnTrangThai != null)
            {
                columnTrangThai.VisibleIndex = gridView.Columns.Count - 1; // Đặt cột "trang_thai" là cột cuối cùng
            }

            gridView.Columns["created_at"].Visible = false;
            gridView.Columns["updated_at"].Visible = false;
            gridView.Columns["nhap_hang"].Visible = false;
            gridView.Columns["san_pham"].Visible = false;
            gridView.Columns["san_pham1"].Visible = false;
            gridView.Columns["nhap_hang1"].Visible = false;
            gridView.RefreshData();
        }
        private void SetupGridControl(GridControl gridControl, List<product> products)
        {
            GridView gridView = gridControl.MainView as GridView;

            if (gridView == null)
                return;

            // Gán DataSource từ List<Product>
            gridControl.DataSource = products;

            // Cho phép chỉnh sửa trên GridView
            gridView.OptionsBehavior.Editable = true;

            // Thay đổi tiêu đề các cột
            gridView.Columns["ma_thuoc_tinh"].Caption = "Mã Thuộc Tính";
            gridView.Columns["ten_san_pham"].Caption = "Tên Sản Phẩm";
            gridView.Columns["ten_kich_thuoc"].Caption = "Tên Kích Thước";
            gridView.Columns["ten_mau_sac"].Caption = "Tên Màu Sắc";
            gridView.Columns["so_luong_ton"].Caption = "Số Lượng Duyệt";

            // Căn chỉnh các cột tiêu đề và dữ liệu
            gridView.Columns["ma_thuoc_tinh"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["ten_san_pham"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["ten_kich_thuoc"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["ten_mau_sac"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["so_luong_ton"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridView.Columns["ma_thuoc_tinh"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["ten_san_pham"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["ten_kich_thuoc"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["ten_mau_sac"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["so_luong_ton"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // Thiết lập chiều rộng cột tự động
            gridView.Columns["ten_san_pham"].BestFit();  // Cột 'Tên Sản Phẩm' sẽ có chiều rộng tối ưu theo dữ liệu

            // Căn chỉnh chiều rộng các cột còn lại để không bị quá hẹp
            gridView.Columns["ma_thuoc_tinh"].Width = 50;  // Chiều rộng cột Mã Thuộc Tính
            gridView.Columns["ten_kich_thuoc"].Width = 50; // Chiều rộng cột Tên Kích Thước
            gridView.Columns["ten_mau_sac"].Width = 50;    // Chiều rộng cột Tên Màu Sắc
            gridView.Columns["so_luong_ton"].Width = 70;   // Chiều rộng cột Số Lượng Tồn
            gridView.Columns["ma_mau_sac"].Visible = false;
            gridView.Columns["ma_kich_thuoc"].Visible = false;
            gridView.Columns["ma_san_pham"].Visible = false;
            SetupSpinEditForColumn(gridView);

        }

        private void SetupSpinEditForColumn(GridView gridView)
        {
            // Kiểm tra và thiết lập SpinEdit cho cột "so_luong_ton"
            if (gridView.Columns.Contains(gridView.Columns["so_luong_ton"]))
            {
                RepositoryItemSpinEdit spinEdit = new RepositoryItemSpinEdit
                {
                    MinValue = 0,  // Giá trị tối thiểu
                    MaxValue = 1000,  // Giá trị tối đa
                    Increment = 1,  // Đơn vị tăng mỗi lần
                    EditMask = "N0" // Hiển thị định dạng số
                };

                // Gán RepositoryItemSpinEdit cho cột "so_luong_ton"
                gridView.Columns["so_luong_ton"].ColumnEdit = spinEdit;
            }
        }

        private void bt_duyet_CheckedChanged(object sender, EventArgs e)
        {

        }
    }



}
