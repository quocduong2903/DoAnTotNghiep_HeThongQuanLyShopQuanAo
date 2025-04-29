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
    public partial class frmNhapHang : DevExpress.XtraEditors.XtraForm
    {
        private nhap_hang_sql_BLL nhap_bll;
        private EventHandler EventHandler;
        private nha_cung_cap_sql_BLL ncc_bll;
        private chi_tiet_nhap_sql_BLL ct_nhap_bll;
        int id_nv;

        public frmNhapHang(int id)
        {
            InitializeComponent();
            id_nv = id;
            this.Load += FrmNhapHang_Load;
            dgv_nh.CellClick += Dgv_nh_CellClick;
            duyet.Click += Duyet_Click;
            them.Click += Them_Click;
            load.Click += Load_Click;
        }

        void clear()
        {
            txt_ghichu.Text = "";
            txt_manhanvien.Text = "";
            txt_manhaphang.Text = "";
            cbb_manhacungcap.SelectedIndex = -1;
            cbb_trangthai.SelectedIndex = -1;

            txt_tenncc.Text = "";
            txt_tonggiatien.Text = "";
            txt_tongsoluong.Text = "";
        }

        private void Load_Click(object sender, EventArgs e)
        {
            loaddgv_nhap_hang();
            load_cbb_ncc();
            load_dgv_sp(0);
            clear();
        }

        private void Them_Click(object sender, EventArgs e)
        {
        


        }

        private void Duyet_Click(object sender, EventArgs e)
        {
            if (dgv_nh.SelectedRows.Count > 0)
            {
                if ((dgv_nh.SelectedRows[0].Cells["trang_thai"].Value.ToString()).Equals("Đã giao - Đợi duyệt") ||
                    (string.IsNullOrEmpty(txt_manhaphang.Text) && cbb_trangthai.SelectedItem.ToString().Equals("Đã giao - Đợi duyệt")))
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
                else if ((dgv_nh.SelectedRows[0].Cells["trang_thai"].Value.ToString()).Equals("Đang đợi giao hàng - thiếu hàng") ||
                        (string.IsNullOrEmpty(txt_manhaphang.Text) && cbb_trangthai.SelectedItem.ToString().Equals("Đang đợi giao hàng - thiếu hàng")))
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

            dgv_sanpham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_sanpham.Columns["so_luong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_sanpham.Columns["gia_nhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            loaddgv_nhap_hang();
            load_cbb_ncc();
            load_dgv_sp(0);
           
            CustomizeDataGridView(dgv_sanpham);
            CustomizeDataGridView(dgv_nh);
        }
        private void CustomizeDataGridView(DataGridView a)
        {
             a.BorderStyle = BorderStyle.None;
            a.BackgroundColor = Color.White; // Màu nền chính
            a.DefaultCellStyle.BackColor = Color.White; // Màu nền cho các ô
            a.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Màu nền cho dòng xen kẽ
            a.GridColor = Color.LightGray; // Màu lưới
            a.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; // Màu tiêu đề cột
            a.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Màu chữ của tiêu đề
            a.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Tiêu đề căn giữa
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
                this.Close();
            }
        }

        private void chon_Click(object sender, EventArgs e)
        {

        }
    }
}
