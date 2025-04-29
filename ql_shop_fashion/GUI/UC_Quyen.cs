using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.XtraBars;

namespace GUI
{
    public partial class UC_Quyen : UserControl
    {
        private nhom_quyen_man_hinh_sql_BLL quyen_bll;
        private nhom_quyen_sql_BLL nhom_quyen_bll;
        private int selectedIdNhomQuyen;

        public UC_Quyen()
        {
            InitializeComponent();
            this.Load += UC_Quyen_Load;

            var gridViewNhomQuyen = gct_nhom_quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridViewNhomQuyen != null)
            {
                gridViewNhomQuyen.RowClick += GridViewNhomQuyen_RowClick;
            }



            bt_save.ItemClick += Bt_save_ItemClick;
            bt_them.ItemClick += Bt_them_ItemClick;
            bt_update.ItemClick += Bt_update_ItemClick;
            bt_update.ItemClick += Bt_update_ItemClick1;
            bt_them_man_hinh.ItemClick += Bt_them_man_hinh_ItemClick;
            bt_sua_name_mh.ItemClick += Bt_sua_name_mh_ItemClick; 
            bt_delete_mh.ItemClick += Bt_delete_mh_ItemClick;
        }

        private void Bt_delete_mh_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView; // gct_nhom_quyen là GridControl
            if (gridView == null || gridView.DataRowCount == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Không có dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dòng được chọn
            var rowHandle = gridView.FocusedRowHandle;
            if (rowHandle < 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID màn hình từ dòng được chọn
            int idManHinh = Convert.ToInt32(gridView.GetRowCellValue(rowHandle, "MaManHinh"));

            // Xác nhận trước khi xóa
            DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa màn hình có ID {idManHinh} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No)
                return;

            // Gọi BLL để xóa
            var quyenBll = new nhom_quyen_man_hinh_sql_BLL();
            bool result = quyenBll.xoa_manHinh(idManHinh);

            // Kiểm tra kết quả và hiển thị thông báo
            if (result)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Xóa màn hình thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới dữ liệu trong GridControl
                load_quyen(selectedIdNhomQuyen);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi khi xóa màn hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Bt_sua_name_mh_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Kiểm tra GridControl và GridView
            var gridView = quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null || gridView.DataRowCount == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Không có dữ liệu trong bảng hoặc bảng không được hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dòng được chọn
            var rowHandle = gridView.FocusedRowHandle;
            if (rowHandle < 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn một dòng để sửa tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã và tên màn hình từ dòng đang chọn
            int maManHinh;
            try
            {
                maManHinh = Convert.ToInt32(gridView.GetRowCellValue(rowHandle, "MaManHinh"));
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Không thể lấy Mã màn hình từ dòng được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenManHinhCu = gridView.GetRowCellValue(rowHandle, "TenManHinh")?.ToString();
            if (string.IsNullOrEmpty(tenManHinhCu))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Không thể lấy Tên màn hình từ dòng được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại để nhập tên mới
            string tenManHinhMoi = DevExpress.XtraEditors.XtraInputBox.Show(
                $"Tên màn hình hiện tại: {tenManHinhCu}\nNhập tên màn hình mới:",
                "Sửa Tên Màn Hình",
                tenManHinhCu);

            // Kiểm tra xem người dùng có nhập tên mới không
            if (string.IsNullOrWhiteSpace(tenManHinhMoi))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Tên mới không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi BLL để cập nhật tên màn hình
            var quyen_bll = new nhom_quyen_man_hinh_sql_BLL();
            bool result = quyen_bll.sua_manhinh(maManHinh, tenManHinhMoi);

            // Kiểm tra kết quả và hiển thị thông báo
            if (result)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Đổi tên màn hình thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách quyền (GridControl)
                load_quyen(selectedIdNhomQuyen);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi khi đổi tên màn hình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Bt_them_man_hinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_them_man_hinh them = new frm_them_man_hinh();
            them.ThemThanhCong += Them_ThemThanhCong;
            them.ShowDialog();
           
        }

        private void Them_ThemThanhCong(object sender, EventArgs e)
        {
           
            load_quyen(selectedIdNhomQuyen);
        }

        private void Bt_update_ItemClick1(object sender, ItemClickEventArgs e)
        {
            // Lấy GridView từ GridControl
            var gridView = gct_nhom_quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ bảng nhóm quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dòng hiện tại được chọn
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ dòng được chọn
            var idNhomQuyen = (int)gridView.GetRowCellValue(selectedRowHandle, "id_nhom_quyen");
            var tenNhomQuyen = gridView.GetRowCellValue(selectedRowHandle, "ten_nhom")?.ToString();

            // Hiển thị hộp thoại xác nhận
            DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhóm quyền '{tenNhomQuyen}' và tất cả dữ liệu liên quan không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    nhom_quyen_bll = new nhom_quyen_sql_BLL();

                    // Gọi hàm xóa nhóm quyền từ BLL
                    bool isDeleted = nhom_quyen_bll.DeleteNhomQuyen(idNhomQuyen);

                    if (isDeleted)
                    {
                        UncheckAllRows();
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Xóa nhóm quyền thành công.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Reload lại dữ liệu sau khi xóa
                        load_ds_quyen();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                            "Không thể xóa nhóm quyền này.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                        $"Có lỗi xảy ra khi xóa nhóm quyền: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Hủy thao tác xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void Bt_update_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Lấy GridView từ GridControl
            var gridView = gct_nhom_quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ bảng nhóm quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dòng hiện tại được chọn
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
            {
                if (column.FieldName == "id_nhom_quyen")
                {
                    column.OptionsColumn.AllowEdit = false; // Không cho phép chỉnh sửa
                }
                else
                {
                    column.OptionsColumn.AllowEdit = true; // Cho phép chỉnh sửa
                }
            }

            // Bật chế độ chỉnh sửa chỉ cho dòng được chọn
            gridView.OptionsBehavior.Editable = true;
            gridView.ShowEditor();

            // Lắng nghe sự kiện sau khi kết thúc chỉnh sửa
            gridView.RowUpdated += (s, eArgs) =>
            {
                // Chỉ xử lý dòng hiện tại được chọn
                if (eArgs.RowHandle == selectedRowHandle)
                {
                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Bạn có muốn lưu những thay đổi vừa thực hiện không?",
                        "Xác nhận lưu",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Lấy dữ liệu từ dòng được chỉnh sửa
                        var idNhomQuyen = (int)gridView.GetRowCellValue(selectedRowHandle, "id_nhom_quyen");
                        var tenNhomQuyen = gridView.GetRowCellValue(selectedRowHandle, "ten_nhom")?.ToString();
                        var moTa = gridView.GetRowCellValue(selectedRowHandle, "mo_ta")?.ToString();

                        try
                        {
                            nhom_quyen_bll = new nhom_quyen_sql_BLL();
                            bool isUpdated = nhom_quyen_bll.UpdateNhomQuyen(idNhomQuyen, tenNhomQuyen, moTa);

                            if (isUpdated)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật nhóm quyền thành công.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Tắt chế độ chỉnh sửa
                                gridView.OptionsBehavior.Editable = false;

                                // Reload lại dữ liệu
                                load_ds_quyen();
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Không tìm thấy nhóm quyền cần cập nhật.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show($"Có lỗi xảy ra khi cập nhật nhóm quyền: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thay đổi không được lưu.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hoàn nguyên dữ liệu về trạng thái trước khi chỉnh sửa
                        gridView.CancelUpdateCurrentRow();

                        // Tắt chế độ chỉnh sửa
                        gridView.OptionsBehavior.Editable = false;

                        // Reload lại dữ liệu
                        load_ds_quyen();
                    }
                }
            };
        }

        // Nút Lưu: Lưu thay đổi quyền vào cơ sở dữ liệu
        private void Bt_save_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridViewNhomQuyen = gct_nhom_quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridViewNhomQuyen == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ bảng nhóm quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy ID Nhóm Quyền từ dòng được chọn
            int idNhomQuyen = (int)gridViewNhomQuyen.GetFocusedRowCellValue("id_nhom_quyen");

            var gridView = quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ bảng quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy danh sách quyền đã chỉnh sửa từ GridView
            var danhSachQuyenDaSua = new List<man_hinh_quyen>();
            for (int i = 0; i < gridView.RowCount; i++)
            {
                var manHinhQuyen = gridView.GetRow(i) as man_hinh_quyen;
                if (manHinhQuyen != null)
                {
                    danhSachQuyenDaSua.Add(manHinhQuyen);
                }
            }

            // Cập nhật cơ sở dữ liệu
            try
            {
                quyen_bll.UpdateDanhSachManHinhTheoNhomQuyen(idNhomQuyen, danhSachQuyenDaSua);
                MessageBox.Show("Lưu thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lưu thay đổi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_them_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Hiển thị hộp thoại nhập tên nhóm quyền
            DevExpress.XtraEditors.XtraInputBoxArgs argsTen = new DevExpress.XtraEditors.XtraInputBoxArgs
            {
                Caption = "Thêm Nhóm Quyền",
                Prompt = "Nhập tên nhóm quyền mới:",
                DefaultResponse = ""
            };

            string tenNhomQuyen = DevExpress.XtraEditors.XtraInputBox.Show(argsTen)?.ToString();

            // Kiểm tra giá trị nhập
            if (string.IsNullOrWhiteSpace(tenNhomQuyen))
            {
                MessageBox.Show("Tên nhóm quyền không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị hộp thoại nhập mô tả nhóm quyền
            DevExpress.XtraEditors.XtraInputBoxArgs argsMoTa = new DevExpress.XtraEditors.XtraInputBoxArgs
            {
                Caption = "Thêm Nhóm Quyền",
                Prompt = "Nhập mô tả cho nhóm quyền:",
                DefaultResponse = ""
            };

            string moTa = DevExpress.XtraEditors.XtraInputBox.Show(argsMoTa)?.ToString();

            // Tạo nhóm quyền mới và lưu vào cơ sở dữ liệu
            try
            {
                nhom_quyen_bll = new nhom_quyen_sql_BLL();

                // Gọi phương thức thêm nhóm quyền trong BLL
                bool isAdded = nhom_quyen_bll.AddNhomQuyen(tenNhomQuyen, moTa);

                if (isAdded)
                {
                    MessageBox.Show("Thêm nhóm quyền thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại danh sách nhóm quyền
                    load_ds_quyen();
                }
                else
                {
                    MessageBox.Show("Thêm nhóm quyền thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi thêm nhóm quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UncheckAllRows()
        {
            // Lấy GridView từ GridControl
            var gridView = quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView == null)
            {
                MessageBox.Show("Không thể lấy dữ liệu từ bảng quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lặp qua từng dòng trong GridView
            for (int i = 0; i < gridView.RowCount; i++)
            {
                // Đặt giá trị cột "CoQuyen" về false
                gridView.SetRowCellValue(i, "CoQuyen", false);

                // Đồng bộ giá trị ngược lại của "KhongQuyen"
                gridView.SetRowCellValue(i, "KhongQuyen", true);
            }

            // Hiển thị thông báo sau khi hoàn tất
            MessageBox.Show("Đã bỏ tích tất cả các dòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void UC_Quyen_Load(object sender, EventArgs e)
        {
            load_ds_quyen();

        }




        // Xử lý sự kiện chọn nhóm quyền
        private void GridViewNhomQuyen_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                selectedIdNhomQuyen = (int)gridView.GetFocusedRowCellValue("id_nhom_quyen");
                load_quyen(selectedIdNhomQuyen);
            }
        }
      

        // Load danh sách nhóm quyền
        private void load_ds_quyen()
        {
            nhom_quyen_bll = new nhom_quyen_sql_BLL();
            gct_nhom_quyen.DataSource = nhom_quyen_bll.get_list_nhomquyen();

            var gridView = gct_nhom_quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns["create_at"].Visible = false;
                gridView.Columns["update_at"].Visible = false;

                gridView.Columns["id_nhom_quyen"].Caption = "Mã Nhóm Quyền";
                gridView.Columns["ten_nhom"].Caption = "Tên Nhóm Quyền";
                gridView.Columns["mo_ta"].Caption = "Mô Tả";

                gridView.OptionsDetail.EnableMasterViewMode = false;
                gridView.OptionsBehavior.Editable = false;
                gridView.BestFitColumns();
            }
        }

        // Load danh sách màn hình


        // Load danh sách quyền theo nhóm quyền
        private void load_quyen(int idNhomQuyen)
        {
            if (idNhomQuyen == 0)
            {
                return; // idNhomQuyen không hợp lệ
            }
            quyen_bll = new nhom_quyen_man_hinh_sql_BLL();
            var danhSachQuyen = quyen_bll.GetDanhSachManHinhTheoNhomQuyen(idNhomQuyen);

            if (danhSachQuyen == null || !danhSachQuyen.Any())
            {
                MessageBox.Show("Danh sách quyền trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            quyen.DataSource = danhSachQuyen;

            var gridView = quyen.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns.Clear();

                var columnIdManHinh = gridView.Columns.AddVisible("MaManHinh", "Mã Màn Hình");
                var columnTenManHinh = gridView.Columns.AddVisible("TenManHinh", "Tên Màn Hình");
                var columnCoQuyen = gridView.Columns.AddVisible("CoQuyen", "Có Quyền");
                var columnKhongQuyen = gridView.Columns.AddVisible("KhongQuyen", "Không Quyền");

                columnIdManHinh.OptionsColumn.AllowEdit = false;
                columnTenManHinh.OptionsColumn.AllowEdit = false;

                columnCoQuyen.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
                columnKhongQuyen.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;

                gridView.OptionsDetail.EnableMasterViewMode = false;
                gridView.BestFitColumns();

                gridView.CustomUnboundColumnData += (s, e) =>
                {
                    var manHinhQuyen = e.Row as man_hinh_quyen;
                    if (manHinhQuyen == null) return;

                    if (e.Column.FieldName == "CoQuyen")
                    {
                        e.Value = manHinhQuyen.CoQuyen;
                    }
                    else if (e.Column.FieldName == "KhongQuyen")
                    {
                        e.Value = manHinhQuyen.KhongQuyen;
                    }
                };
            }
        }
    }
}
