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
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class frmInGia : DevExpress.XtraEditors.XtraForm
    {
        BLL.thuoc_tinh_sp_sql_BLL ttsp_bll = new BLL.thuoc_tinh_sp_sql_BLL();

        public frmInGia()
        {
            InitializeComponent();
            this.Load += FrmTesttt_Load;          
            this.Load += FrmInGia_Load;
            btnIn.ItemClick += BtnIn_ItemClick;
            btnThem.ItemClick += BtnThem_ItemClick;
            btnXoa.ItemClick += BtnXoa_ItemClick;
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int focusedRowHandle = dgvDS.FocusedRowHandle;
            if (focusedRowHandle >= 0)
            {
                object MaSP = dgvDS.GetRowCellValue(focusedRowHandle, "MaSP");
                object TenSP = dgvDS.GetRowCellValue(focusedRowHandle, "TenSP");
                object TenKT = dgvDS.GetRowCellValue(focusedRowHandle, "TenKT");
                object TenMau = dgvDS.GetRowCellValue(focusedRowHandle, "TenMau");
                object giaBan = dgvDS.GetRowCellValue(focusedRowHandle, "GiaBan");
                decimal giaGiam = (decimal)(dgvDS.GetRowCellValue(focusedRowHandle, "GiaGiam"));

                // Kiểm tra xem DataSource của dgvSanPhamThem có phải là DataTable không
                if (!(dgvSanPhamThem.DataSource is DataTable dataTable))
                {
                    // Nếu DataSource chưa phải là DataTable, khởi tạo DataTable mới và cấu hình các cột
                    dataTable = new DataTable();
                    dataTable.Columns.Add("MaSP", typeof(int));
                    dataTable.Columns.Add("TenSP", typeof(string));
                    dataTable.Columns.Add("TenKT", typeof(string));
                    dataTable.Columns.Add("TenMau", typeof(string));
                    dataTable.Columns.Add("GiaBan", typeof(string));
                    dataTable.Columns.Add("GiaGiam", typeof(string));
                    dataTable.Columns.Add("So_tem", typeof(int)); // Đảm bảo So_tem là kiểu int
                                                                  // Gán DataTable mới tạo vào DataSource của dgvSanPhamThem
                    dgvSanPhamThem.DataSource = dataTable;
                }

                // Kiểm tra xem sản phẩm đã tồn tại trong DataTable chưa
                DataRow[] existingRows = dataTable.Select($"MaSP = {MaSP}");

                if (existingRows.Length > 0) // Nếu sản phẩm đã tồn tại
                {
                    // Lấy hàng đầu tiên trùng mã sản phẩm
                    DataRow existingRow = existingRows[0];

                    // Cộng dồn số tem vào sản phẩm đã tồn tại
                    existingRow["So_tem"] = (int)existingRow["So_tem"] + 1;
                }
                else
                {
                    // Tạo một hàng mới và thêm dữ liệu vào DataTable
                    DataRow newRow = dataTable.NewRow();
                    newRow["MaSP"] = MaSP;
                    newRow["TenSP"] = TenSP;
                    newRow["TenKT"] = TenKT;
                    newRow["TenMau"] = TenMau;
                    newRow["GiaBan"] = giaBan;
                    newRow["GiaGiam"] = giaGiam.ToString("0.##");
                    newRow["So_tem"] = 1;

                    // Thêm hàng mới vào DataTable
                    dataTable.Rows.Add(newRow);
                }
            }
        }

        private void BtnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<tem_gia> lst = new List<tem_gia>();
            tem_gia tem;

            for (int i = 0; i < dgvDS2.RowCount; i++)
            {
                if (dgvDS2.GetRowCellValue(i, "So_tem") != null)
                {
                    for (int j = 0; j < int.Parse(dgvDS2.GetRowCellValue(i, "So_tem").ToString()); j++)
                    {
                        tem = new tem_gia();
                        tem.MaSP = int.Parse(dgvDS2.GetRowCellValue(i, "MaSP").ToString());
                        tem.TenSP = dgvDS2.GetRowCellValue(i, "TenSP").ToString();
                        tem.GiaBan = Math.Round(decimal.Parse(dgvDS2.GetRowCellValue(i, "GiaBan").ToString()), 2);
                        tem.GiaGiam = Math.Round(decimal.Parse(dgvDS2.GetRowCellValue(i, "GiaGiam").ToString()), 2);
                        lst.Add(tem);
                    }



                }
            }
            InBarcode rp = new InBarcode();
            rp.DataSource = lst;
            rp.ShowPreviewDialog();
            load();
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn không
            int focusedRowHandle = dgvDS2.FocusedRowHandle;

            if (focusedRowHandle >= 0) // Nếu có dòng đang được chọn
            {
                // Xác nhận trước khi xóa
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    // Xóa dòng đang được chọn
                    dgvDS2.DeleteRow(focusedRowHandle);
                }
            }
            else
            {
                // Nếu không có dòng nào được chọn
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmInGia_Load(object sender, EventArgs e)
        {
            dgvDS2.Columns["So_tem"].OptionsColumn.AllowEdit = true;
        }



        private void FrmTesttt_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            dgvSanPham.DataSource = ttsp_bll.Get_SP_INGIA();
            DataTable dataTable = new DataTable();

            // Thêm các cột vào DataTable (giữ nguyên cấu trúc cột của dgvDS2)
            dataTable.Columns.Add("MaSP", typeof(int));
            dataTable.Columns.Add("TenSP", typeof(string));
            dataTable.Columns.Add("TenKT", typeof(string));
            dataTable.Columns.Add("TenMau", typeof(string));
            dataTable.Columns.Add("GiaBan", typeof(string));
            dataTable.Columns.Add("GiaGiam", typeof(string));
            dataTable.Columns.Add("So_tem", typeof(int));

            // Gán DataTable rỗng vào DataSource của dgvDS2
            dgvSanPhamThem.DataSource = dataTable;
        }
    }
}