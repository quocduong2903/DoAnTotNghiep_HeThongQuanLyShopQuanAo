using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BLL;
using OfficeOpenXml;
using System.IO;
using System.Reflection;
using System.Globalization;
using DevExpress.XtraCharts;

namespace GUI
{
    public partial class UC_BaoCao_ThongKe : UserControl
    {
        private thong_ke_sql_BLL thongKeBLL;
        private enum CheDoThongKe
        {
            TheoNgay,
            TheoThang,
            TheoNam,
            NhapHangTheoThang,
            NhapHangTheoNam
        }

        private CheDoThongKe cheDoThongKeHienTai;



        public UC_BaoCao_ThongKe()
        {
            InitializeComponent();           
            thongKeBLL = new thong_ke_sql_BLL();

            bt_thongketheongay.ItemClick += Bt_thongketheongay_ItemClick;
            bt_thongketheothang.ItemClick += Bt_thongketheothang_ItemClick;
            bt_thongketheonam.ItemClick += Bt_thongketheonam_ItemClick;
            bt_thongkenhaphangtheothang.ItemClick += Bt_thongkenhaphangtheothang_ItemClick;
            bt_thongkenhaphangtheonam.ItemClick += Bt_thongkenhaphangtheonam_ItemClick;
            bt_xuatbaocao.ItemClick += Bt_xuatbaocao_ItemClick;

        }




        private void Bt_xuatbaocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string excelFilePath = "ThongKe.xlsx";
            string chartImagePath = "ChartImage.png";

            try
            {

                // Thiết lập License cho EPPlus
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Kiểm tra DataSource của gct_hoadondoitra
                if (gct_hoadondoitra.DataSource == null)
                {
                    MessageBox.Show("Không có dữ liệu đổi trả trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu bán hàng và đổi trả
                DataTable dt = LayDuLieuBaoCao(); // Dữ liệu bán hàng
                DataTable dtDoiTra = LayDuLieuDoiTra(); // Dữ liệu đổi trả

                // Kiểm tra dữ liệu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu bán hàng để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtDoiTra == null || dtDoiTra.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu đổi trả để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Xuất biểu đồ thành ảnh
                ExportChartToImage(chartImagePath);

                // Kiểm tra nếu ảnh biểu đồ không tồn tại
                if (!File.Exists(chartImagePath))
                {
                    MessageBox.Show("Không thể xuất biểu đồ thành ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xuất dữ liệu ra file Excel
                XuatDuLieuRaExcel(dt, dtDoiTra, excelFilePath, chartImagePath);

                // Kiểm tra nếu file Excel tồn tại
                if (File.Exists(excelFilePath))
                {
                    MessageBox.Show("Xuất dữ liệu thành công! Mở file Excel...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = excelFilePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Xuất file Excel thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Xóa ảnh biểu đồ tạm nếu tồn tại
                if (File.Exists(chartImagePath))
                {
                    try
                    {
                        File.Delete(chartImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể xóa ảnh tạm: {ex.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }






        // Convert a List<T> to DataTable
        public static DataTable ConvertToDataTable<T>(List<T> data)
        {
            DataTable table = new DataTable();

            // Get properties of type T
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add columns to DataTable
            foreach (PropertyInfo prop in props)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Add rows to DataTable
            foreach (T item in data)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null) ?? DBNull.Value;
                }
                table.Rows.Add(values);
            }

            return table;
        }



        private DataTable LayDuLieuDoiTra()
        {
            DataTable dataTable2 = null;

            if (gct_hoadondoitra.DataSource != null)
            {

                if (cheDoThongKeHienTai == CheDoThongKe.TheoNgay && gct_hoadondoitra.DataSource is List<thong_ke_doi_tra_DTO> dataDoiTraNgay)
                {
                    dataTable2 = ConvertToDataTable(dataDoiTraNgay);
                    MessageBox.Show("Dữ liệu đổi trả theo ngày được xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cheDoThongKeHienTai == CheDoThongKe.TheoThang && gct_hoadondoitra.DataSource is List<thong_ke_doi_tra_thang_DTO> dataDoiTraThang)
                {
                    dataTable2 = ConvertToDataTable(dataDoiTraThang);
                    MessageBox.Show("Dữ liệu đổi trả theo tháng được xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cheDoThongKeHienTai == CheDoThongKe.TheoNam && gct_hoadondoitra.DataSource is List<thong_ke_doi_tra_nam_DTO> dataDoiTraNam)
                {
                    dataTable2 = ConvertToDataTable(dataDoiTraNam);
                    MessageBox.Show("Dữ liệu đổi trả theo năm được xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (gct_hoadondoitra.DataSource is DataTable dt)
                {
                    dataTable2 = dt.Copy();
                    MessageBox.Show("Dữ liệu đổi trả là DataTable!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (gct_hoadondoitra.DataSource is DataView dataView)
                {
                    dataTable2 = dataView.ToTable();
                    MessageBox.Show("Dữ liệu đổi trả là DataView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Không có nhánh nào được thực thi cho đổi trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Kiểm tra số dòng dữ liệu
            if (dataTable2 != null && dataTable2.Rows.Count > 0)
            {
                Console.WriteLine($"LayDuLieuDoiTra: Found {dataTable2.Rows.Count} rows.");
            }
            else
            {
                Console.WriteLine("LayDuLieuDoiTra: No data found.");
            }

            return dataTable2;
        }






        // Lấy dữ liệu từ GridControl báo cáo
        private DataTable LayDuLieuBaoCao()
        {
            DataTable dataTable1 = null;
            DataTable dataTable2 = null;

            if (gct_hoadon.DataSource == null && gct_hoadondoitra.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu trong GridControl!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // Lấy dữ liệu từ gct_hoadon
            if (gct_hoadon.DataSource != null)
            {
                if (cheDoThongKeHienTai == CheDoThongKe.TheoNgay && gct_hoadon.DataSource is List<thong_ke_ban_hang_DTO> dataNgay)
                {
                    dataTable1 = ConvertToDataTable(dataNgay);
                }
                else if (cheDoThongKeHienTai == CheDoThongKe.TheoThang && gct_hoadon.DataSource is List<thong_ke_theo_thang_DTO> dataThang)
                {
                    dataTable1 = ConvertToDataTable(dataThang);
                    RemoveUnnecessaryColumns(dataTable1, new[] { "Nam" });
                }
                else if (cheDoThongKeHienTai == CheDoThongKe.TheoNam && gct_hoadon.DataSource is List<thong_ke_theo_nam_DTO> dataNam)
                {
                    dataTable1 = ConvertToDataTable(dataNam);
                }
                else if (cheDoThongKeHienTai == CheDoThongKe.NhapHangTheoThang && gct_hoadon.DataSource is List<thong_ke_nhap_hang_theo_thang_DTO> dataNHThang)
                {
                    dataTable1 = ConvertToDataTable(dataNHThang);
                }
                else if (cheDoThongKeHienTai == CheDoThongKe.NhapHangTheoNam && gct_hoadon.DataSource is List<thong_ke_nhap_hang_theo_nam_DTO> dataNHNam)
                {
                    dataTable1 = ConvertToDataTable(dataNHNam);
                }
                else if (gct_hoadon.DataSource is DataTable dt)
                {
                    dataTable1 = dt.Copy();
                }
                else if (gct_hoadon.DataSource is DataView dataView)
                {
                    dataTable1 = dataView.ToTable();
                }
            }



            // Nếu chỉ có gct_hoadondoitra, trả về bảng đó
            if (dataTable1 == null && dataTable2 != null)
            {
                return dataTable2;
            }

            // Nếu chỉ có gct_hoadon, trả về bảng đó
            if (dataTable1 != null && dataTable2 == null)
            {
                return dataTable1;
            }

            // Kết hợp dữ liệu từ cả hai bảng
            if (dataTable1 != null && dataTable2 != null)
            {
                foreach (DataRow row in dataTable2.Rows)
                {
                    dataTable1.ImportRow(row);
                }
            }

            return dataTable1;
        }


        private void RemoveUnnecessaryColumns(DataTable dataTable, string[] columnsToRemove)
        {
            foreach (var column in columnsToRemove)
            {
                if (dataTable.Columns.Contains(column))
                {
                    dataTable.Columns.Remove(column);
                }
            }
        }

        private void ExportChartToImage(string chartImagePath)
        {
            try
            {
                chart_bc_tk.ExportToImage(chartImagePath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể xuất biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Xuất dữ liệu ra file Excel
        private void XuatDuLieuRaExcel(DataTable dt, DataTable dtDoiTra, string excelFilePath, string chartImagePath)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                // Xác định sheet theo chế độ
                string sheetName;
                switch (cheDoThongKeHienTai)
                {
                    case CheDoThongKe.TheoNgay:
                        sheetName = "Thống kê ngày";
                        break;
                    case CheDoThongKe.TheoThang:
                        sheetName = "Thống kê tháng";
                        break;
                    case CheDoThongKe.TheoNam:
                        sheetName = "Thống kê năm";
                        break;
                    case CheDoThongKe.NhapHangTheoThang:
                        sheetName = "Thống kê nhập hàng theo tháng";
                        break;
                    case CheDoThongKe.NhapHangTheoNam:
                        sheetName = "Thống kê nhập hàng theo năm";
                        break;
                    default:
                        sheetName = "Thống kê";
                        break;
                }

                var sheet = excel.Workbook.Worksheets.Add(sheetName);

                // Chèn hình ảnh biểu đồ
                if (File.Exists(chartImagePath))
                {
                    var picture = sheet.Drawings.AddPicture("ChartImage", new FileInfo(chartImagePath));
                    picture.SetPosition(0, 0, 0, 0); // Đặt hình ảnh ở góc trên bên trái
                }

                // Chèn dữ liệu từ DataTable bán hàng
                sheet.Cells["A24"].LoadFromDataTable(dt, true);

                SetupHeaders(sheet, cheDoThongKeHienTai);

                // Định dạng tiêu đề (Hàng 24)
                using (var headerRange = sheet.Cells[24, 1, 24, dt.Columns.Count])
                {
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Font.Size = 12;
                    headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                if (cheDoThongKeHienTai == CheDoThongKe.TheoNgay)
                {
                    using (var dateRange = sheet.Cells[25, 1, 24 + dt.Rows.Count, 1])
                    {
                        dateRange.Style.Numberformat.Format = "dd/MM/yyyy";
                    }
                }


                if (dtDoiTra != null && dtDoiTra.Rows.Count > 0)
                {

                    if (cheDoThongKeHienTai == CheDoThongKe.TheoThang || cheDoThongKeHienTai == CheDoThongKe.TheoNam)
                    {
                        if (dtDoiTra.Columns.Contains("ngayDoiTra"))
                        {
                            dtDoiTra.Columns.Remove("ngayDoiTra");
                        }
                    }

                    if (cheDoThongKeHienTai == CheDoThongKe.TheoNam)
                    {
                        if (dtDoiTra.Columns.Contains("Thang"))
                        {
                            dtDoiTra.Columns.Remove("Thang");
                        }
                    }

                    var sheetDoiTra = excel.Workbook.Worksheets.Add("Dữ liệu đổi trả");

                    if (File.Exists(chartImagePath))
                    {
                        var picture = sheetDoiTra.Drawings.AddPicture("ChartImage", new FileInfo(chartImagePath));
                        picture.SetPosition(0, 0, 0, 0);
                    }

                    sheetDoiTra.Cells["A24"].LoadFromDataTable(dtDoiTra, true);

                    SetupDoiTraHeaders(sheetDoiTra, cheDoThongKeHienTai);


                    using (var headerRange = sheetDoiTra.Cells[24, 1, 24, dtDoiTra.Columns.Count])
                    {
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Font.Size = 12;
                        headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }


                    sheetDoiTra.Cells[sheetDoiTra.Dimension.Address].AutoFitColumns();


                    // Định dạng cột ngày tháng nếu cần (chỉ cho chế độ Theo Ngày)
                    if (cheDoThongKeHienTai == CheDoThongKe.TheoNgay)
                    {
                        using (var dateRange = sheetDoiTra.Cells[25, 1, 24 + dtDoiTra.Rows.Count, 1]) // Cột 1 chứa ngày tháng
                        {
                            dateRange.Style.Numberformat.Format = "dd/MM/yyyy"; // Định dạng ngày tháng
                        }
                    }

                    Console.WriteLine("Dữ liệu đổi trả đã được xuất vào Excel.");
                }
                else
                {
                    Console.WriteLine("Không có dữ liệu đổi trả để xuất.");
                }



                // Tự động điều chỉnh độ rộng cột cho sheet bán hàng
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();


                // Lưu file Excel
                File.WriteAllBytes(excelFilePath, excel.GetAsByteArray());
            }
        }


        private void SetupHeaders(ExcelWorksheet sheet, CheDoThongKe cheDoThongKeHienTai)
        {
            switch (cheDoThongKeHienTai)
            {
                case CheDoThongKe.TheoNgay:
                    sheet.Cells["A23"].Value = "Dữ liệu thống kê bán hàng theo ngày";
                    sheet.Cells["A23"].Style.Font.Bold = true;
                    sheet.Cells["A23"].Style.Font.Size = 14;

                    sheet.Cells[24, 1].Value = "Ngày Bán";
                    sheet.Cells[24, 2].Value = "Mã Nhóm Loại";
                    sheet.Cells[24, 3].Value = "Tên Nhóm Loại";
                    sheet.Cells[24, 4].Value = "Số Lượng Sản Phẩm";
                    sheet.Cells[24, 5].Value = "Tổng Tiền";
                    break;

                case CheDoThongKe.TheoThang:
                    sheet.Cells["A23"].Value = "Dữ liệu thống kê bán hàng theo tháng";
                    sheet.Cells["A23"].Style.Font.Bold = true;
                    sheet.Cells["A23"].Style.Font.Size = 14;

                    sheet.Cells[24, 1].Value = "Tháng";
                    sheet.Cells[24, 2].Value = "Tổng Sản Phẩm";
                    sheet.Cells[24, 3].Value = "Tổng Tiền";
                    break;

                case CheDoThongKe.TheoNam:
                    sheet.Cells["A23"].Value = "Dữ liệu thống kê bán hàng theo năm";
                    sheet.Cells["A23"].Style.Font.Bold = true;
                    sheet.Cells["A23"].Style.Font.Size = 14;

                    sheet.Cells[24, 1].Value = "Năm";
                    sheet.Cells[24, 2].Value = "Tổng Sản Phẩm";
                    sheet.Cells[24, 3].Value = "Tổng Doanh Thu";
                    break;

                case CheDoThongKe.NhapHangTheoThang:
                    sheet.Cells["A23"].Value = "Dữ liệu thống kê nhập hàng theo tháng";
                    sheet.Cells["A23"].Style.Font.Bold = true;
                    sheet.Cells["A23"].Style.Font.Size = 14;

                    sheet.Cells[24, 1].Value = "Tháng";
                    sheet.Cells[24, 2].Value = "Mã Sản Phẩm";
                    sheet.Cells[24, 3].Value = "Tên Sản Phẩm";
                    sheet.Cells[24, 4].Value = "Tổng Sản Phẩm";
                    sheet.Cells[24, 5].Value = "Đơn Giá";
                    sheet.Cells[24, 6].Value = "Tổng Tiền Nhập";
                    break;

                case CheDoThongKe.NhapHangTheoNam:
                    sheet.Cells["A23"].Value = "Dữ liệu thống kê nhập hàng theo năm";
                    sheet.Cells["A23"].Style.Font.Bold = true;
                    sheet.Cells["A23"].Style.Font.Size = 14;

                    sheet.Cells[24, 1].Value = "Năm";
                    sheet.Cells[24, 2].Value = "Mã Sản Phẩm";
                    sheet.Cells[24, 3].Value = "Tên Sản Phẩm";
                    sheet.Cells[24, 4].Value = "Tổng Sản Phẩm";
                    sheet.Cells[24, 5].Value = "Đơn Giá";
                    sheet.Cells[24, 6].Value = "Tổng Tiền Nhập";
                    break;
            }

        }

        private void SetupDoiTraHeaders(ExcelWorksheet sheetDoiTra, CheDoThongKe cheDoThongKeHienTai)
        {

            switch (cheDoThongKeHienTai)
            {
                case CheDoThongKe.TheoNgay:
                    sheetDoiTra.Cells["A23"].Value = "Dữ liệu thống kê đổi trả theo ngày";
                    sheetDoiTra.Cells["A23"].Style.Font.Bold = true;
                    sheetDoiTra.Cells["A23"].Style.Font.Size = 14;

                    sheetDoiTra.Cells[24, 1].Value = "Ngày Đổi Trả";
                    sheetDoiTra.Cells[24, 2].Value = "Mã Nhóm Loại";
                    sheetDoiTra.Cells[24, 3].Value = "Tên Nhóm Loại";
                    sheetDoiTra.Cells[24, 4].Value = "Số Lượng Trả";
                    sheetDoiTra.Cells[24, 5].Value = "Tổng Tiền Hoàn Trả";
                    break;

                case CheDoThongKe.TheoThang:
                    sheetDoiTra.Cells["A23"].Value = "Dữ liệu thống kê đổi trả theo tháng";
                    sheetDoiTra.Cells["A23"].Style.Font.Bold = true;
                    sheetDoiTra.Cells["A23"].Style.Font.Size = 14;

                    sheetDoiTra.Cells[24, 1].Value = "Tháng";
                    sheetDoiTra.Cells[24, 2].Value = "Năm";
                    sheetDoiTra.Cells[24, 3].Value = "Tổng Số Lượng Trả";
                    sheetDoiTra.Cells[24, 4].Value = "Tổng Tiền Hoàn Trả";
                    break;

                case CheDoThongKe.TheoNam:
                    sheetDoiTra.Cells["A23"].Value = "Dữ liệu thống kê đổi trả theo năm";
                    sheetDoiTra.Cells["A23"].Style.Font.Bold = true;
                    sheetDoiTra.Cells["A23"].Style.Font.Size = 14;

                    sheetDoiTra.Cells[24, 1].Value = "Năm";
                    sheetDoiTra.Cells[24, 2].Value = "Tổng Số Lượng Trả";
                    sheetDoiTra.Cells[24, 3].Value = "Tổng Tiền Hoàn Trả";
                    break;
            }




        }








        private void Bt_thongkenhaphangtheonam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cheDoThongKeHienTai = CheDoThongKe.NhapHangTheoNam;
            int startYear = 2020;
            int endYear = DateTime.Now.Year;

            var dataNhapHangTheoNam = thongKeBLL.GetThongKeNhapHangTheoNam(startYear, endYear);

            // Hiển thị thông báo nếu không có dữ liệu
            if (dataNhapHangTheoNam.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê nhập hàng theo năm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gct_hoadon.DataSource = dataNhapHangTheoNam;
            gct_hoadondoitra.Visible = false;
            gct_hoadon.Dock = DockStyle.Fill;

            ConfigureGridColumnsNhapHangYear();

            hienThiNhapHangTheoNam(dataNhapHangTheoNam);


        }

        private void Bt_thongkenhaphangtheothang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cheDoThongKeHienTai = CheDoThongKe.NhapHangTheoThang;
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            var dataNhapHangTheoThang = thongKeBLL.GetThongKeNhapHangTheoThang(thang, nam);

            // Hiển thị thông báo nếu không có dữ liệu
            if (dataNhapHangTheoThang.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê nhập hàng theo tháng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gct_hoadon.DataSource = dataNhapHangTheoThang;
            gct_hoadondoitra.Visible = false;
            gct_hoadon.Dock = DockStyle.Fill;

            ConfigureGridColumnsNhapHangMonth();

            hienThiNhapHangTheoThang(dataNhapHangTheoThang);

        }

        private void Bt_thongketheongay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cheDoThongKeHienTai = CheDoThongKe.TheoNgay;
            DateTime ngay = DateTime.Now.Date;

            // Lấy dữ liệu
            var dataBanHang = thongKeBLL.ThongKeTheoNgay(ngay);
            var dataDoiTra = thongKeBLL.ThongKeDoiTraTheoNgay(ngay);

            // Kiểm tra dữ liệu
            if (dataBanHang == null || dataBanHang.Count == 0)
            {
                MessageBox.Show($"Không có dữ liệu bán hàng trong ngày {ngay:dd/MM/yyyy}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (dataDoiTra == null || dataDoiTra.Count == 0)
            {
                MessageBox.Show($"Không có dữ liệu đổi trả trong ngày {ngay:dd/MM/yyyy}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gct_hoadon.DataSource = dataBanHang;            
            gct_hoadondoitra.DataSource = dataDoiTra;

            gct_hoadondoitra.Visible = true; // Hiển thị lại bảng đổi trả
            gct_hoadon.Dock = DockStyle.Left; // Điều chỉnh vị trí của hai bảng nếu cần
            gct_hoadondoitra.Dock = DockStyle.Fill;

            ConfigureGridColumnsDays();

            DisplayDailyStatistics(dataBanHang, dataDoiTra);
        }





        private void Bt_thongketheothang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cheDoThongKeHienTai = CheDoThongKe.TheoThang;
            int nam = DateTime.Now.Year;
            int thang = DateTime.Now.Month;

            var dataBanHang = thongKeBLL.ThongKeTheoThang(nam);
            var dataDoiTra = thongKeBLL.ThongKeDoiTraTheoThang(nam, thang);

            if (dataBanHang == null || dataBanHang.Count == 0)
            {
                MessageBox.Show($"Không có dữ liệu thống kê bán hàng trong tháng {thang}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (dataDoiTra == null || dataDoiTra.Count == 0)
            {
                MessageBox.Show($"Không có dữ liệu thống kê đổi trả trong tháng {thang}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gct_hoadon.DataSource = dataBanHang;
            gct_hoadondoitra.DataSource = dataDoiTra;

            gct_hoadondoitra.Visible = true; // Hiển thị lại bảng đổi trả
            gct_hoadon.Dock = DockStyle.Left; // Điều chỉnh vị trí của hai bảng nếu cần
            gct_hoadondoitra.Dock = DockStyle.Fill;

            ConfigureGridColumnsMonth();

            DisplayMonthlyStatistics(dataBanHang, dataDoiTra);

           

        }








        private void Bt_thongketheonam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cheDoThongKeHienTai = CheDoThongKe.TheoNam;
            int startYear = 2020;
            int endYear = DateTime.Now.Year;

            var dataBanHang = thongKeBLL.ThongKeTheoNam(startYear, endYear);
            var dataDoiTra = thongKeBLL.ThongKeDoiTraTheoNam(startYear, endYear);

            if (dataBanHang == null || dataBanHang.Count == 0)
            {
                MessageBox.Show($"Không có dữ liệu thống kê bán hàng trong năm {endYear}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (dataDoiTra == null || dataDoiTra.Count == 0)
            {
                MessageBox.Show($"Không có dữ liệu thống kê đổi trả trong năm {endYear}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gct_hoadon.DataSource = dataBanHang;
            gct_hoadondoitra.DataSource = dataDoiTra;

            gct_hoadondoitra.Visible = true; // Hiển thị lại bảng đổi trả
            gct_hoadon.Dock = DockStyle.Left; // Điều chỉnh vị trí của hai bảng nếu cần
            gct_hoadondoitra.Dock = DockStyle.Fill;

            ConfigureGridColumnsYear();

            DisplayYearlyStatistics(dataBanHang, dataDoiTra);

            


        }




        private void DisplayDailyStatistics(List<thong_ke_ban_hang_DTO> dataBanHang, List<thong_ke_doi_tra_DTO> dataDoiTra)
        {
            // Gộp dữ liệu bán hàng theo ngày, mã nhóm loại và tên nhóm loại
            var groupedBanHangData = dataBanHang
                .GroupBy(x => new
                {
                    NgayBan = x.ngayBan?.Date ?? DateTime.MinValue, // Lấy Date hoặc gán giá trị mặc định nếu null
            MaNhomLoai = x.maNhomLoai,
                    TenNhomLoai = x.tenNhomLoai
                })
                .Select(g => new thong_ke_ban_hang_DTO
                {
                    ngayBan = g.Key.NgayBan,
                    maNhomLoai = g.Key.MaNhomLoai,
                    tenNhomLoai = g.Key.TenNhomLoai,
                    soLuongSanPham = g.Sum(x => x.soLuongSanPham ?? 0),
                    tongTien = g.Sum(x => x.tongTien ?? 0)
                })
                .ToList();

            // Gộp dữ liệu đổi trả theo ngày, mã nhóm loại và tên nhóm loại
            var groupedDoiTraData = dataDoiTra
                .GroupBy(x => new
                {
                    NgayDoiTra = x.ngayDoiTra?.Date ?? DateTime.MinValue,
                    MaNhomLoai = x.maNhomLoai,
                    TenNhomLoai = x.tenNhomLoai
                })
                .Select(g => new thong_ke_doi_tra_DTO
                {
                    ngayDoiTra = g.Key.NgayDoiTra,
                    maNhomLoai = g.Key.MaNhomLoai,
                    tenNhomLoai = g.Key.TenNhomLoai,
                    soLuongTra = g.Sum(x => x.soLuongTra ?? 0),
                    tongTienHoanTra = g.Sum(x => x.tongTienHoanTra ?? 0)
                })
                .ToList();

            // Xóa series cũ trong biểu đồ
            chart_bc_tk.Series.Clear();

            // Tạo Series cho bán hàng
            var seriesSoLuongSanPham = new DevExpress.XtraCharts.Series("Số lượng sản phẩm", DevExpress.XtraCharts.ViewType.Bar);
            var seriesTongTien = new DevExpress.XtraCharts.Series("Tổng tiền", DevExpress.XtraCharts.ViewType.Bar);

            // Thêm dữ liệu bán hàng vào Series
            foreach (var item in groupedBanHangData)
            {
                seriesSoLuongSanPham.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenNhomLoai, item.soLuongSanPham));
                seriesTongTien.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenNhomLoai, item.tongTien));
            }

            // Tạo Series cho dữ liệu đổi trả
            var seriesSoLuongTra = new DevExpress.XtraCharts.Series("Số lượng trả", DevExpress.XtraCharts.ViewType.Bar);
            var seriesTongTienHoanTra = new DevExpress.XtraCharts.Series("Tổng tiền hoàn trả", DevExpress.XtraCharts.ViewType.Bar);

            // Thêm dữ liệu đổi trả vào Series
            foreach (var item in groupedDoiTraData)
            {
                seriesSoLuongTra.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenNhomLoai, item.soLuongTra));
                seriesTongTienHoanTra.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenNhomLoai, item.tongTienHoanTra));
            }

            // Hiển thị nhãn
            seriesSoLuongSanPham.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesTongTien.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesSoLuongTra.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesTongTienHoanTra.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Định dạng nhãn
            seriesTongTien.Label.TextPattern = "{V:n0} VNĐ"; // Hiển thị tiền
            seriesSoLuongSanPham.Label.TextPattern = "{V} sản phẩm"; // Hiển thị số lượng
            seriesTongTienHoanTra.Label.TextPattern = "{V:n0} VNĐ"; // Hiển thị tiền
            seriesSoLuongTra.Label.TextPattern = "{V} sản phẩm"; // Hiển thị số lượng

            // Thêm Series vào biểu đồ
            chart_bc_tk.Series.Add(seriesSoLuongSanPham);
            chart_bc_tk.Series.Add(seriesTongTien);
            chart_bc_tk.Series.Add(seriesSoLuongTra);
            chart_bc_tk.Series.Add(seriesTongTienHoanTra);

            // Cấu hình trục
            var diagram = chart_bc_tk.Diagram as DevExpress.XtraCharts.XYDiagram;
            if (diagram != null)
            {
                diagram.AxisY.Title.Text = "Giá Trị";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                diagram.AxisX.Title.Text = "Nhóm Loại";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }

            // Thêm tiêu đề biểu đồ
            chart_bc_tk.Titles.Clear();
            chart_bc_tk.Titles.Add(new DevExpress.XtraCharts.ChartTitle
            {
                Text = $"Thống Kê Bán Hàng và Đổi - Trả Ngày {DateTime.Now:dd/MM/yyyy}"
            });

            // Hiển thị chú thích
            chart_bc_tk.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chart_bc_tk.Legend.Title.Text = "Loại dữ liệu";
            chart_bc_tk.Legend.Title.Visible = true;

            // Gán dữ liệu bán hàng vào bảng bên trái
            gct_hoadon.DataSource = groupedBanHangData;

            // Gán dữ liệu đổi trả vào bảng bên phải
            gct_hoadondoitra.DataSource = groupedDoiTraData;

            // Hiển thị tổng doanh thu
            DisplayTotalRevenue(groupedBanHangData);
        }






        private void DisplayTotalRevenue(List<thong_ke_ban_hang_DTO> data)
        {
            decimal totalRevenue = data.Sum(x => x.tongTien ?? 0);

            var gridView = gct_hoadon.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView == null)
            {
                MessageBox.Show("GridView chưa được khởi tạo!");
                return;
            }

            // Hiển thị dòng tổng cộng ở footer
            gridView.OptionsView.ShowFooter = true;

            // Đảm bảo cột "tongTien" tồn tại
            if (gridView.Columns["tongTien"] != null)
            {
                gridView.Columns["tongTien"].Width = 250; // Tăng chiều rộng cột
                gridView.Columns["tongTien"].Summary.Clear();
                gridView.Columns["tongTien"].Summary.Add(
                    DevExpress.Data.SummaryItemType.Sum,
                    "tongTien",
                    "Tổng doanh thu: {0:#,##0 VNĐ}"
                );
            }
        }







        private void DisplayMonthlyStatistics(List<thong_ke_theo_thang_DTO> dataBanHang, List<thong_ke_doi_tra_thang_DTO> dataDoiTra)
        {
            chart_bc_tk.Series.Clear();

            // Lọc dữ liệu bán hàng
            var filteredBanHangData = dataBanHang
                .Where(item => item.TongTien > 0 || item.TongSanPham > 0)
                .ToList();

            // Tạo series cho bán hàng
            var revenueSeries = new DevExpress.XtraCharts.Series("Tổng Doanh Thu", DevExpress.XtraCharts.ViewType.Bar);
            var productSeries = new DevExpress.XtraCharts.Series("Tổng Sản Phẩm", DevExpress.XtraCharts.ViewType.Bar);

            foreach (var item in filteredBanHangData)
            {
                var label = $"Tháng {item.Thang}/{item.Nam}";
                revenueSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.TongTien));
                productSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.TongSanPham));
            }

            revenueSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            productSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            chart_bc_tk.Series.Add(revenueSeries);
            chart_bc_tk.Series.Add(productSeries);

            // Lọc và nhóm dữ liệu đổi trả
            var groupedDoiTraData = dataDoiTra
                .Where(item => item.tongTienHoanTra > 0 || item.soLuongTra > 0)
                .GroupBy(x => new { Thang = x.ngayDoiTra?.Month ?? 0, Nam = x.ngayDoiTra?.Year ?? 0 })
                .Select(g => new thong_ke_doi_tra_thang_DTO
                {
                    Thang = g.Key.Thang.ToString(),
                    Nam = g.Key.Nam.ToString(),
                    soLuongTra = g.Sum(x => x.soLuongTra ?? 0),
                    tongTienHoanTra = g.Sum(x => x.tongTienHoanTra ?? 0)
                })
                .ToList();

            // Tạo series cho đổi trả
            var seriesSoLuongTra = new DevExpress.XtraCharts.Series("Tổng Số Lượng Trả", DevExpress.XtraCharts.ViewType.Bar);
            var seriesTongTienHoanTra = new DevExpress.XtraCharts.Series("Tổng Tiền Hoàn Trả", DevExpress.XtraCharts.ViewType.Bar);

            foreach (var item in groupedDoiTraData)
            {
                var label = $"Tháng {item.Thang}/{item.Nam}";
                seriesSoLuongTra.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.soLuongTra));
                seriesTongTienHoanTra.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.tongTienHoanTra));
            }

            seriesSoLuongTra.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesTongTienHoanTra.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            seriesTongTienHoanTra.Label.TextPattern = "{V:n0} VNĐ";
            seriesSoLuongTra.Label.TextPattern = "{V} sản phẩm";

            chart_bc_tk.Series.Add(seriesSoLuongTra);
            chart_bc_tk.Series.Add(seriesTongTienHoanTra);

            // Cấu hình biểu đồ
            var diagram = chart_bc_tk.Diagram as DevExpress.XtraCharts.XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.QualitativeScaleOptions.AutoGrid = false;
                diagram.AxisX.Label.TextPattern = "{A}";

                diagram.AxisX.Title.Text = "Tháng/Năm";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                diagram.AxisY.Title.Text = "Giá Trị";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }

            chart_bc_tk.Titles.Clear();
            chart_bc_tk.Titles.Add(new DevExpress.XtraCharts.ChartTitle
            {
                Text = $"Thống Kê Bán Hàng và Đổi - Trả Theo Tháng Trong Năm {DateTime.Now:yyyy}"
            });

            chart_bc_tk.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chart_bc_tk.Legend.Title.Text = "Loại Dữ Liệu";
            chart_bc_tk.Legend.Title.Visible = true;

            // Gán dữ liệu vào GridControl
            gct_hoadon.DataSource = filteredBanHangData;
            gct_hoadondoitra.DataSource = groupedDoiTraData;

            // Refresh GridControl để đảm bảo hiển thị
            gct_hoadon.RefreshDataSource();
            gct_hoadondoitra.RefreshDataSource();
        }









        private void DisplayYearlyStatistics(List<thong_ke_theo_nam_DTO> dataBanHang, List<thong_ke_doi_tra_nam_DTO> dataDoiTra)
        {
            chart_bc_tk.Series.Clear();

            // Lọc dữ liệu bán hàng
            var filteredBanHangData = dataBanHang
                .Where(item => item.TongTien > 0 || item.TongSanPham > 0)
                .ToList();

            // Tạo series cho bán hàng
            var revenueSeries = new DevExpress.XtraCharts.Series("Tổng Doanh Thu", DevExpress.XtraCharts.ViewType.Bar);
            var productSeries = new DevExpress.XtraCharts.Series("Tổng Sản Phẩm", DevExpress.XtraCharts.ViewType.Bar);

            foreach (var item in filteredBanHangData)
            {
                var label = $"Năm {item.Nam}";
                revenueSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.TongTien));
                productSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.TongSanPham));
            }

            revenueSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            productSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            chart_bc_tk.Series.Add(revenueSeries);
            chart_bc_tk.Series.Add(productSeries);

            // Nhóm và tổng hợp dữ liệu đổi trả
            var groupedDoiTraData = dataDoiTra
                .Where(item => item.tongTienHoanTra > 0 || item.soLuongTra > 0)
                .GroupBy(x => new { Year = x.ngayDoiTra?.Year ?? 0 })
                .Select(g => new thong_ke_doi_tra_nam_DTO
                {
                    Nam = g.Key.Year.ToString(),
                    soLuongTra = g.Sum(x => x.soLuongTra ?? 0),
                    tongTienHoanTra = g.Sum(x => x.tongTienHoanTra ?? 0)
                })
                .ToList();

            // Tạo series cho đổi trả
            var seriesSoLuongTra = new DevExpress.XtraCharts.Series("Tổng Số Lượng Trả", DevExpress.XtraCharts.ViewType.Bar);
            var seriesTongTienHoanTra = new DevExpress.XtraCharts.Series("Tổng Tiền Hoàn Trả", DevExpress.XtraCharts.ViewType.Bar);

            foreach (var item in groupedDoiTraData)
            {
                var label = $"Năm {item.Nam}";
                seriesSoLuongTra.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.soLuongTra));
                seriesTongTienHoanTra.Points.Add(new DevExpress.XtraCharts.SeriesPoint(label, item.tongTienHoanTra));
            }

            seriesSoLuongTra.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesTongTienHoanTra.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            seriesTongTienHoanTra.Label.TextPattern = "{A}: {V:n0} VNĐ";
            seriesSoLuongTra.Label.TextPattern = "{A}: {V} sản phẩm";

            chart_bc_tk.Series.Add(seriesSoLuongTra);
            chart_bc_tk.Series.Add(seriesTongTienHoanTra);

            // Cấu hình biểu đồ
            var diagram = chart_bc_tk.Diagram as DevExpress.XtraCharts.XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.QualitativeScaleOptions.AutoGrid = false;
                diagram.AxisX.Label.TextPattern = "{A}";

                diagram.AxisX.Title.Text = "Năm";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                diagram.AxisY.Title.Text = "Giá Trị";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }

            chart_bc_tk.Titles.Clear();
            chart_bc_tk.Titles.Add(new DevExpress.XtraCharts.ChartTitle
            {
                Text = "Thống Kê Bán Hàng và Đổi - Trả Theo Năm"
            });

            chart_bc_tk.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chart_bc_tk.Legend.Title.Text = "Loại Dữ Liệu";
            chart_bc_tk.Legend.Title.Visible = true;

            // Gán dữ liệu vào GridControl
            gct_hoadon.DataSource = filteredBanHangData;
            gct_hoadondoitra.DataSource = groupedDoiTraData;

            // Refresh GridControl để đảm bảo hiển thị
            gct_hoadon.RefreshDataSource();
            gct_hoadondoitra.RefreshDataSource();
        }





        private void hienThiNhapHangTheoThang(List<thong_ke_nhap_hang_theo_thang_DTO> data)
        {
            chart_bc_tk.Series.Clear();

            // Tạo Series cho thống kê nhập hàng theo tháng
            var revenueSeries = new DevExpress.XtraCharts.Series("Tổng Tiền Nhập", DevExpress.XtraCharts.ViewType.Bar);
            var productSeries = new DevExpress.XtraCharts.Series("Tổng Sản Phẩm", DevExpress.XtraCharts.ViewType.Bar);

            foreach (var item in data)
            {
                revenueSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenSanPham, item.thanhTien));
                productSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenSanPham, item.soLuong));
            }

            revenueSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            productSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Thêm Series vào biểu đồ
            chart_bc_tk.Series.Add(revenueSeries);
            chart_bc_tk.Series.Add(productSeries);

            // Cấu hình trục của biểu đồ
            var diagram = chart_bc_tk.Diagram as DevExpress.XtraCharts.XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.Title.Text = "Sản Phẩm";
                diagram.AxisY.Title.Text = "Giá trị / Số lượng";
            }

            // Cập nhật tiêu đề biểu đồ
            chart_bc_tk.Titles.Clear();
            chart_bc_tk.Titles.Add(new DevExpress.XtraCharts.ChartTitle
            {
                Text = $"Thống Kê Nhập Hàng Theo Tháng Trong Năm {DateTime.Now:yyyy}"
            });

            // Hiển thị chú thích
            chart_bc_tk.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chart_bc_tk.Legend.Title.Text = "Loại Dữ Liệu";
            chart_bc_tk.Legend.Title.Visible = true;

            gct_hoadondoitra.DataSource = data;
        }



        private void hienThiNhapHangTheoNam(List<thong_ke_nhap_hang_theo_nam_DTO> data)
        {
            chart_bc_tk.Series.Clear();

            // Tạo Series cho thống kê nhập hàng theo năm
            var revenueSeries = new DevExpress.XtraCharts.Series("Tổng Tiền Nhập", DevExpress.XtraCharts.ViewType.Bar);
            var productSeries = new DevExpress.XtraCharts.Series("Tổng Sản Phẩm", DevExpress.XtraCharts.ViewType.Bar);

            foreach (var item in data)
            {
                revenueSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenSanPham, item.thanhTien));
                productSeries.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.tenSanPham, item.soLuong));
            }

            revenueSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            productSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Thêm Series vào biểu đồ
            chart_bc_tk.Series.Add(revenueSeries);
            chart_bc_tk.Series.Add(productSeries);

            // Cấu hình trục của biểu đồ
            var diagram = chart_bc_tk.Diagram as DevExpress.XtraCharts.XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.Title.Text = "Sản Phẩm";
                diagram.AxisY.Title.Text = "Giá trị / Số lượng";
            }

            // Cập nhật tiêu đề biểu đồ
            chart_bc_tk.Titles.Clear();
            chart_bc_tk.Titles.Add(new DevExpress.XtraCharts.ChartTitle
            {
                Text = "Thống Kê Nhập Hàng Theo Năm"
            });

            // Hiển thị chú thích
            chart_bc_tk.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chart_bc_tk.Legend.Title.Text = "Loại Dữ Liệu";
            chart_bc_tk.Legend.Title.Visible = true;

            gct_hoadondoitra.DataSource = data;
        }











        private void ConfigureGridColumnsDays()
        {
            var gridView = gct_hoadon.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns.Clear();

                var column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "ngayBan",
                    Caption = "Ngày Bán",
                    Visible = true
                };
                gridView.Columns.Add(column);

                gridView.Columns["ngayBan"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView.Columns["ngayBan"].DisplayFormat.FormatString = "dd/MM/yyyy";

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "maNhomLoai",
                    Caption = "Mã Nhóm Loai",
                    Visible = true
                };
                gridView.Columns.Add(column);

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tenNhomLoai",
                    Caption = "Tên Nhóm Loại",
                    Visible = true
                };
                gridView.Columns.Add(column);

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "soLuongSanPham",
                    Caption = "Số Lượng Sản Phẩm",
                    Visible = true,
                    Width = 80
                };
                gridView.Columns.Add(column);

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tongTien",
                    Caption = "Tổng Tiền",
                    Visible = true
                };
                gridView.Columns.Add(column);

            }

            var gridViewDoiTra = gct_hoadondoitra.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridViewDoiTra != null)
            {
                gridViewDoiTra.Columns.Clear();

                var column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "ngayDoiTra",
                    Caption = "Ngày Đổi Trả",
                    Visible = true
                };
                gridViewDoiTra.Columns.Add(column);

                gridViewDoiTra.Columns["ngayDoiTra"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewDoiTra.Columns["ngayDoiTra"].DisplayFormat.FormatString = "dd/MM/yyyy";

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "maNhomLoai",
                    Caption = "Mã Nhóm Loai",
                    Visible = true
                };
                gridViewDoiTra.Columns.Add(column);

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tenNhomLoai",
                    Caption = "Tên Nhóm Loại",
                    Visible = true
                };
                gridViewDoiTra.Columns.Add(column);

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "soLuongTra",
                    Caption = "Số Lượng Đổi Trả",
                    Visible = true,
                    Width = 80
                };
                gridViewDoiTra.Columns.Add(column);

                column = new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tongTienHoanTra",
                    Caption = "Tổng Tiền Hoàn Trả",
                    Visible = true
                };
                gridViewDoiTra.Columns.Add(column);

                gridViewDoiTra.BestFitColumns();
            }
        }

        private void ConfigureGridColumnsMonth()
        {
            // Cấu hình cột cho bảng bán hàng
            var gridViewBanHang = gct_hoadon.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridViewBanHang != null)
            {
                gridViewBanHang.Columns.Clear();

                gridViewBanHang.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Thang",
                    Caption = "Tháng",
                    Visible = true,
                    Width = 80
                });

                gridViewBanHang.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "TongSanPham",
                    Caption = "Tổng Sản Phẩm",
                    Visible = true,
                    Width = 200
                });

                gridViewBanHang.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "TongTien",
                    Caption = "Tổng Doanh Thu",
                    Visible = true,
                    Width = 200
                });

                gridViewBanHang.BestFitColumns();
            }

            // Cấu hình cột cho bảng đổi trả
            var gridViewDoiTra = gct_hoadondoitra.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridViewDoiTra != null)
            {
                gridViewDoiTra.Columns.Clear();

                gridViewDoiTra.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Thang",
                    Caption = "Tháng",
                    Visible = true,
                    Width = 80
                });

                gridViewDoiTra.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Nam",
                    Caption = "Năm",
                    Visible = true,
                    Width = 80
                });

                gridViewDoiTra.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "soLuongTra",
                    Caption = "Tổng Số Lượng Trả",
                    Visible = true,
                    Width = 200
                });

                gridViewDoiTra.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tongTienHoanTra",
                    Caption = "Tổng Tiền Hoàn Trả",
                    Visible = true,
                    Width = 200
                });


                gridViewDoiTra.BestFitColumns();
            }
        }






        private void ConfigureGridColumnsYear()
        {
            // Cấu hình cột cho bảng bán hàng
            var gridView = gct_hoadon.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.Columns.Clear();

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Nam",
                    Caption = "Năm",
                    Visible = true,
                    Width = 100
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "TongSanPham",
                    Caption = "Tổng Sản Phẩm",
                    Visible = true,
                    Width = 150
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "TongTien",
                    Caption = "Tổng Doanh Thu",
                    Visible = true,
                    Width = 150
                });

                gridView.BestFitColumns();
            }

            // Cấu hình cột cho bảng đổi trả
            var gridViewDoiTra = gct_hoadondoitra.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridViewDoiTra != null)
            {
                gridViewDoiTra.Columns.Clear();

                gridViewDoiTra.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Nam",
                    Caption = "Năm",
                    Visible = true,
                    Width = 100
                });

                gridViewDoiTra.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "soLuongTra",
                    Caption = "Tổng Số Lượng Trả",
                    Visible = true,
                    Width = 150
                });

                gridViewDoiTra.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tongTienHoanTra",
                    Caption = "Tổng Tiền Hoàn Trả",
                    Visible = true,
                    Width = 150
                });

                gridViewDoiTra.BestFitColumns();
            }
        }





        private void ConfigureGridColumnsNhapHangMonth()
        {
            var gridView = gct_hoadon.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView != null)
            {
                gridView.Columns.Clear();

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "thang",
                    Caption = "Tháng",
                    Visible = true,
                    Width = 80
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "maSanPham",
                    Caption = "Mã Sản Phẩm",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tenSanPham",
                    Caption = "Tên Sản Phẩm",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "soLuong",
                    Caption = "Tổng Sản Phẩm",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "donGia",
                    Caption = "Đơn Giá",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "thanhTien",
                    Caption = "Tổng Tiền Nhập",
                    Visible = true,
                    Width = 200
                });

                gridView.BestFitColumns();
            }
        }

        private void ConfigureGridColumnsNhapHangYear()
        {
            var gridView = gct_hoadon.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView != null)
            {
                gridView.Columns.Clear();

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "nam",
                    Caption = "Năm",
                    Visible = true,
                    Width = 80
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "maSanPham",
                    Caption = "Mã Sản Phẩm",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "tenSanPham",
                    Caption = "Tên Sản Phẩm",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "soLuong",
                    Caption = "Tổng Sản Phẩm",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "donGia",
                    Caption = "Đơn Giá",
                    Visible = true,
                    Width = 200
                });

                gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "thanhTien",
                    Caption = "Tổng Tiền Nhập",
                    Visible = true,
                    Width = 200
                });

                gridView.BestFitColumns();
            }
        }



    }
}
