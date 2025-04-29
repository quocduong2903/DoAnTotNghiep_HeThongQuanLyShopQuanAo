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

namespace GUI
{
    public partial class UC_QLDonHangOnline : DevExpress.XtraEditors.XtraUserControl
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();

        hoa_don_BLL hd_bll = new hoa_don_BLL();
        chi_tiet_hoa_don_BLL cthd_bll = new chi_tiet_hoa_don_BLL();
        khach_hang_sql_BLL kh_bll = new khach_hang_sql_BLL();
        public UC_QLDonHangOnline()
        {
            InitializeComponent();
            this.Load += UC_QLDonHangOnline_Load;
            gvHoaDonOn.FocusedRowChanged += GvHoaDonOn_FocusedRowChanged;
            btnDuyetDon.Click += BtnDuyetDon_Click;
        }

        private void BtnDuyetDon_Click(object sender, EventArgs e)
        {
            
            int ma = int.Parse(txtMaHoaDon.Text);

            // Lấy trạng thái hiện tại từ GridView
            GridView gridView = gcHoaDonOn.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                string trangThaiGH = Convert.ToString(gridView.GetFocusedRowCellValue("trang_thai_giao_hang"));

                // Kiểm tra trạng thái và hiển thị xác nhận
                if (trangThaiGH == "chờ xác nhận")
                {
                    DialogResult result = XtraMessageBox.Show(
                        "Trạng thái hiện tại là 'chờ xác nhận'. Bạn có muốn chuyển sang 'đã xác nhận' không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Chuyển trạng thái nếu người dùng đồng ý
                        if (hd_bll.updateTrangThaiGiaoHang(ma, "đã xác nhận"))
                        {
                            XtraMessageBox.Show("Duyệt đơn hàng sang trạng thái 'đã xác nhận' thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadFrm();
                        }
                        else
                        {
                            XtraMessageBox.Show("Duyệt đơn hàng không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (trangThaiGH == "đã xác nhận" )
                {
                    DialogResult result = XtraMessageBox.Show(
                        "Trạng thái hiện tại là 'đã xác nhận'. Bạn có muốn chuyển sang 'đang soạn hàng' không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        if (hd_bll.updateTrangThaiGiaoHang(ma, "đang soạn hàng"))
                        {
                            XtraMessageBox.Show("Duyệt đơn hàng sang trạng thái 'đang soạn hàng' thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadFrm();
                        }
                        else
                        {
                            XtraMessageBox.Show("Duyệt đơn hàng không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (trangThaiGH == "đang soạn hàng" )
                {
                    DialogResult result = XtraMessageBox.Show(
                        "Trạng thái hiện tại là 'đang soạn hàng'. Bạn có muốn chuyển sang 'đã giao cho đơn vị vận chuyển' không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        if (hd_bll.updateTrangThaiGiaoHang(ma, "đã giao cho đơn vị vận chuyển"))
                        {
                            XtraMessageBox.Show("Duyệt đơn hàng sang trạng thái 'đã giao cho đơn vị vận chuyển' thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadFrm();
                        }
                        else
                        {
                            XtraMessageBox.Show("Duyệt đơn hàng không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Duyệt đơn hàng không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void GvHoaDonOn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = gcHoaDonOn.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                string maHD = Convert.ToString(gridView.GetFocusedRowCellValue("ma_hoa_don"));
                gcCTHDOn.DataSource = hd_bll.getChiTietHoaDonOnline(int.Parse(maHD));
                txtMaHoaDon.Text = maHD;
                khach_hang khachHang =hd_bll.getKhachHangHoaDonOnline(int.Parse(maHD));

                // Kiểm tra nếu tìm thấy khách hàng
                if (khachHang != null)
                {
                    // Gán giá trị vào các TextBox
                    txtTenKH.Text = khachHang.ten_khach_hang; // Tên khách hàng
                    txtSoDienThoai.Text = khachHang.dien_thoai;      // Số điện thoại
                    txtDiaChi.Text = khachHang.dia_chi;      // Địa chỉ
                }
                else
                {
                    // Hiển thị thông báo nếu không tìm thấy
                    MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Xóa nội dung các TextBox nếu cần
                    txtTenKH.Text = string.Empty;
                    txtSoDienThoai.Text = string.Empty;
                    txtDiaChi.Text = string.Empty;
                }
            }
        }

        private void UC_QLDonHangOnline_Load(object sender, EventArgs e)
        {
            loadFrm();
        }

        private void loadFrm()
        {
            gcHoaDonOn.DataSource = hd_bll.getHoaDonOnline();
            //cboDuyet.Items.Add("đã xác nhận");
            //cboDuyet.Items.Add("đang soạn hàng");
            //cboDuyet.Items.Add("đã giao cho đơn vị vận chuyển");

        }
    }
}
