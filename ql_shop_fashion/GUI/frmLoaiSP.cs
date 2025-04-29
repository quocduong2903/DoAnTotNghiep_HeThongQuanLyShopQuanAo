using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Drawing;

namespace GUI
{
    public partial class frmLoaiSP : DevExpress.XtraEditors.XtraForm
    {
        private loai_sanpham_sql_BLL loai_sp_bll;
        private nhom_loai_sql_BLL nhom_loai_bll;
        private Form popup;

        public frmLoaiSP()
        {
            InitializeComponent();
            this.Load += FrmLoaiSP_Load;
            nhom_loai_bll = new nhom_loai_sql_BLL();
            loai_sp_bll = new loai_sanpham_sql_BLL();

            GridView gv_loaisp = gct_loaisp.MainView as GridView;
            gv_loaisp.Click += Gv_loaisp_Click;
            cbb_tennhomloai.EditValueChanged += Cbb_manhomloai_EditValueChanged;
            btn_themloaisp.ItemClick += Btn_themloaisp_ItemClick;
            btn_sualoaisp.ItemClick += Btn_sualoaisp_ItemClick;
            btn_xoaloaisp.ItemClick += Btn_xoaloaisp_ItemClick;
            btn_loadloaisp.ItemClick += Btn_loadloaisp_ItemClick;

            gct_loaisp.MouseMove += Gct_loaisp_MouseMove;
            gct_loaisp.MouseLeave += Gct_loaisp_MouseLeave;
        }

        private void Btn_loadloaisp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clearloaisp();
        }

        private void Btn_xoaloaisp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xoaLoaiSP();
        }

        private void Btn_sualoaisp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            suaLoaiSP();
        }

        private void Btn_themloaisp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            themLoaiSP();
        }

        private void Gct_loaisp_MouseLeave(object sender, EventArgs e)
        {
            if (popup != null && popup.Visible)
            {
                popup.Hide();
            }
        }

        private void Gct_loaisp_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Cbb_manhomloai_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmLoaiSP_Load(object sender, EventArgs e)
        {
            loadLoaiSP();
            loadNhomLoaiLenComboBox();
        }


        private void Gv_loaisp_Click(object sender, EventArgs e)
        {
            loadLoaiSPLenControls();
        }

        private void loadNhomLoaiLenComboBox()
        {
            try
            {
                List<nhom_loai_DTO> nhomLoaiList = nhom_loai_bll.get_all_nhom_loai();

                // Xóa các item cũ
                cbb_tennhomloai.Properties.Items.Clear();

                // Thêm dữ liệu vào ComboBoxEdit thủ công
                foreach (var nhomLoai in nhomLoaiList)
                {
                    cbb_tennhomloai.Properties.Items.Add(nhomLoai.ten_nhom_loai);
                }

                // Không chọn mục nào mặc định
                cbb_tennhomloai.EditValue = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}");
            }
        }



        private void loadLoaiSP()
        {
            gct_loaisp.DataSource = loai_sp_bll.get_all_loai_sp();

            GridView gridView = gct_loaisp.MainView as GridView;
            if (gridView != null)
            {
                gridView.OptionsBehavior.Editable = false;
                gridView.Columns["ma_loai"].Caption = "Mã Loại";
                gridView.Columns["ten_loai"].Caption = "Tên Loại";
                gridView.Columns["ma_nhom_loai"].Caption = "Mã Nhóm Loại";
                gridView.Columns["chi_tiet"].Caption = "Chi Tiết";
                gridView.BestFitColumns();
            }
        }

        private void loadLoaiSPLenControls()
        {
            GridView gridView = gct_loaisp.MainView as GridView;
            if (gridView != null && gridView.FocusedRowHandle >= 0)
            {
                // Get the selected "ma_loai" from the grid
                int maloaisp = Convert.ToInt32(gridView.GetFocusedRowCellValue("ma_loai"));

                // Retrieve the LoaiSP details
                var loaispDetails = loai_sp_bll.getLoaiSPById(maloaisp);

                if (loaispDetails != null)
                {
                    // Populate the fields
                    txt_maloai.Text = loaispDetails.ma_loai.ToString();
                    txt_tenloai.Text = loaispDetails.ten_loai;
                    txt_chitiet.Text = loaispDetails.chi_tiet;

                    // Check if ma_nhom_loai is not null
                    if (loaispDetails.ma_nhom_loai.HasValue)
                    {
                        // Retrieve the NhomLoai details
                        var nhomloaiDetails = nhom_loai_bll.getNhomLoaiById(loaispDetails.ma_nhom_loai.Value);

                        if (nhomloaiDetails != null)
                        {
                            // Set the combo box with the name of the NhomLoai
                            cbb_tennhomloai.EditValue = nhomloaiDetails.ten_nhom_loai;
                        }
                        else
                        {
                            // Clear the combo box if no NhomLoai is found
                            cbb_tennhomloai.EditValue = null;
                        }
                    }
                    else
                    {
                        // Clear the combo box if ma_nhom_loai is null
                        cbb_tennhomloai.EditValue = null;
                    }
                }
            }
        }



        private void clearloaisp()
        {
            txt_maloai.Text = "";
            txt_tenloai.Text = "";
            txt_chitiet.Text = "";
            cbb_tennhomloai.EditValue = null;
        }

        private bool kiemTraLoaiSP()
        {

            if (string.IsNullOrWhiteSpace(txt_tenloai.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenloai.Focus();
                return false;
            }

            if (cbb_tennhomloai.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn mã nhóm loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_tennhomloai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_chitiet.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập chi tiết loại sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_chitiet.Focus();
                return false;
            }

            return true;
        }

        public void themLoaiSP()
        {
            if (!kiemTraLoaiSP())
            {
                return;
            }

            try
            {
                // Fetch the selected group's ID based on the displayed name
                string selectedGroupName = cbb_tennhomloai.EditValue?.ToString();
                var selectedGroup = loai_sp_bll.getNhomLoaiByName(selectedGroupName); // Add a method to fetch by name

                if (selectedGroup != null)
                {
                    var newLoaiSP = new loai_san_pham
                    {
                        ten_loai = txt_tenloai.Text,
                        ma_nhom_loai = selectedGroup.ma_nhom_loai,
                        chi_tiet = txt_chitiet.Text
                    };

                    bool isAdded = loai_sp_bll.AddLoaiSP(newLoaiSP);

                    if (isAdded)
                    {
                        XtraMessageBox.Show("Thêm loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearloaisp();
                        loadLoaiSP();
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm loại sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Không tìm thấy mã nhóm loại tương ứng với tên được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void suaLoaiSP()
        {
            if (!kiemTraLoaiSP())
            {
                return;
            }

            try
            {
                if (int.TryParse(txt_maloai.Text, out int maLoai))
                {
                    // Fetch the selected group's ID based on the displayed name
                    string selectedGroupName = cbb_tennhomloai.EditValue?.ToString();
                    var selectedGroup = loai_sp_bll.getNhomLoaiByName(selectedGroupName);

                    if (selectedGroup != null)
                    {
                        var updatedLoaiSP = new loai_san_pham
                        {
                            ma_loai = maLoai,
                            ten_loai = txt_tenloai.Text,
                            ma_nhom_loai = selectedGroup.ma_nhom_loai,
                            chi_tiet = txt_chitiet.Text
                        };

                        bool isUpdated = loai_sp_bll.UpdateLoaiSP(updatedLoaiSP);

                        if (isUpdated)
                        {
                            XtraMessageBox.Show("Sửa loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearloaisp();
                            loadLoaiSP();
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa loại sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Không tìm thấy mã nhóm loại tương ứng với tên được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Mã loại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void xoaLoaiSP()
        {
            GridView gridView = gct_loaisp.MainView as GridView;
            if (gridView == null)
                return;

            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            int maloai = Convert.ToInt32(gridView.GetRowCellValue(selectedRowHandle, "ma_loai"));

            var confirmResult = XtraMessageBox.Show("Bạn có chắc chắn muốn xóa " + $"mã loại: {maloai}", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                bool deleteSuccess = loai_sp_bll.DeleteLoaiSPById(maloai);

                if (deleteSuccess)
                {
                    XtraMessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridView.DeleteRow(selectedRowHandle);
                    clearloaisp();
                    gct_loaisp.RefreshDataSource();
                }
                else
                {
                    XtraMessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Lỗi tồn tải ở bảng khác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                clearloaisp();
                gct_loaisp.RefreshDataSource();
            }
        }

        
    }
}
