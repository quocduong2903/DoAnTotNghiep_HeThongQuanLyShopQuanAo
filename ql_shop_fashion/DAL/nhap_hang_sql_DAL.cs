using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class nhap_hang_sql_DAL
    {
        QL_SHOP_DATADataContext data;
        public nhap_hang_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }
        public IQueryable get_all_nhap_hang()
        {
            var ds = from i in data.nhap_hangs
                    
                    
                     select new
                     {
                         i.ma_nhap_hang,
                         i.ngay_nhap,
                         i.tong_gia_tien,
                        
                         i.ghi_chu,
                         i.trang_thai,
                         i.tong_so_luong,
                         
                     };
            return ds;
        }
        public IQueryable<dynamic> get_nhap_hang_by_id(int maNhapHang)
        {
            var nhapHang = from i in data.nhap_hangs
                           join ncc in data.nha_cung_caps on i.ma_nha_cung_cap equals ncc.ma_nha_cung_cap
                           join nv in data.nhan_viens on i.ma_nhan_vien equals nv.ma_nhan_vien
                           where i.ma_nhap_hang == maNhapHang
                           select new
                           {
                               i.ma_nhap_hang,
                               i.ngay_nhap,
                               i.tong_gia_tien,

                               i.ghi_chu,
                               i.trang_thai,
                               i.tong_so_luong,
                               ncc.ten_nha_cung_cap, // giả sử bạn muốn lấy tên nhà cung cấp
                               nv.ten_nhan_vien      // giả sử bạn muốn lấy tên nhân viên
                           };
            return nhapHang;
        }
        public bool nhap_hang_add(nhap_hang newNhapHang, List<chi_tiet_nhap_hang> chiTietNhapHangs)
        {
            try
            {
                // Thêm bản ghi nhập hàng
                data.nhap_hangs.InsertOnSubmit(newNhapHang);
                data.SubmitChanges(); // Lưu bản ghi nhập hàng vào cơ sở dữ liệu

                // Thêm chi tiết nhập hàng
                if (chiTietNhapHangs != null && chiTietNhapHangs.Count > 0)
                {
                    foreach (var chiTiet in chiTietNhapHangs)
                    {
                        // Gán mã nhập hàng cho chi tiết
                        chiTiet.ma_nhap_hang = newNhapHang.ma_nhap_hang;

                        data.chi_tiet_nhap_hangs.InsertOnSubmit(chiTiet);
                    }
                }

                data.SubmitChanges(); // Lưu chi tiết nhập hàng vào cơ sở dữ liệu
                return true; // Trả về true nếu thành công
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ đã xảy ra
                throw new Exception("Có lỗi xảy ra khi thêm phiếu nhập hàng.", ex);
                return false;
            }
        }
        public bool update_tt_ht(int id)
        {
            // Tìm đối tượng cần cập nhật trong bảng nhap_hangs
            var item = data.nhap_hangs.SingleOrDefault(i => i.ma_nhap_hang == id);

            // Kiểm tra nếu đối tượng không null (tìm thấy sản phẩm cần cập nhật)
            if (item != null)
            {
                // Cập nhật trạng thái sản phẩm thành "Đã duyệt"
                item.trang_thai = "Hoàn thành";

                try
                {
                    // Lưu thay đổi vào cơ sở dữ liệu
                    data.SubmitChanges();

                    // Trả về true nếu cập nhật thành công
                    return true;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có (ví dụ: lỗi khi lưu vào cơ sở dữ liệu)
                    Console.WriteLine($"Lỗi khi cập nhật trạng thái: {ex.Message}");

                    // Trả về false nếu có lỗi
                    return false;
                }
            }

            // Nếu không tìm thấy đối tượng với id tương ứng, trả về false
            return false;
        }
        // Hàm lấy danh sách phiếu nhập hàng theo trạng thái
        public IQueryable get_nhap_hang_by_trang_thai(string trangThai)
        {
            var ds = from i in data.nhap_hangs
                     where i.trang_thai == trangThai // Lọc theo trạng thái
                     select new
                     {
                         i.ma_nhap_hang,
                         i.ngay_nhap,
                         i.tong_gia_tien,
                         i.ghi_chu,
                         i.trang_thai,
                         i.tong_so_luong,
                     };
            return ds;
        }
        public bool cap_nhat_trang_thai(int maNhapHang, string trangThaiMoi)
        {
            try
            {
                var nhapHang = data.nhap_hangs.FirstOrDefault(nh => nh.ma_nhap_hang == maNhapHang);
                if (nhapHang != null)
                {
                    nhapHang.trang_thai = trangThaiMoi;
                    data.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true;
                }
                return false; // Không tìm thấy đơn hàng
            }
            catch
            {
                return false; // Lỗi xảy ra
            }
        }







    }
}
