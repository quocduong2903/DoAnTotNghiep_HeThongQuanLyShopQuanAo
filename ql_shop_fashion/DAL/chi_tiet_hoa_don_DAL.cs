using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class chi_tiet_hoa_don_DAL
    {

        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        public chi_tiet_hoa_don_DAL()
        {

        }


        public bool ThemChiTietHoaDon(int  maHD, int maSP,decimal giaBan, int soLuongMua)
        {
            try
            {
                var newCTHoaDon = new chi_tiet_hoa_don
                {
                    ma_hoa_don=maHD,
                    ma_thuoc_tinh=maSP,
                    gia=giaBan,
                    so_luong=soLuongMua,
                    trang_thai="bình thường"
                   
                };

                
                data.chi_tiet_hoa_dons.InsertOnSubmit(newCTHoaDon);
                data.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                return false;
            }
        }

        public IQueryable layChiTietHoaDon(int maHD)
        {

            var ttsp = from hd in data.hoa_dons
                       join cthd in data.chi_tiet_hoa_dons on hd.ma_hoa_don equals cthd.ma_hoa_don
                       join thuoc_tinh in data.thuoc_tinh_san_phams on cthd.ma_thuoc_tinh equals thuoc_tinh.ma_thuoc_tinh
                       join sp in data.san_phams on thuoc_tinh.ma_san_pham equals sp.ma_san_pham
                       where hd.ma_hoa_don == maHD
                       select new
                       {
                           cthd.ma_thuoc_tinh,
                           sp.ten_san_pham,
                           cthd.so_luong,
                           cthd.thanh_tien,
                           cthd.gia,
                           cthd.giagiam,
                           cthd.trang_thai
                       };
            return ttsp;
        }

        public BindingList<ChiTietHoaDon> layChiTietHoaDonB(int maHD)
        {
            var ttsp = from hd in data.hoa_dons
                       join cthd in data.chi_tiet_hoa_dons on hd.ma_hoa_don equals cthd.ma_hoa_don
                       join thuoc_tinh in data.thuoc_tinh_san_phams on cthd.ma_thuoc_tinh equals thuoc_tinh.ma_thuoc_tinh
                       join sp in data.san_phams on thuoc_tinh.ma_san_pham equals sp.ma_san_pham
                       where hd.ma_hoa_don == maHD
                       select new ChiTietHoaDon
                       {
                           ma_thuoc_tinh = cthd.ma_thuoc_tinh,
                           ten_san_pham = sp.ten_san_pham,
                           so_luong = cthd.so_luong,
                           gia = cthd.gia,
                           giagiam = (decimal)cthd.giagiam,
                           thanh_tien = (decimal)cthd.thanh_tien,
                           trang_thai = cthd.trang_thai
                       };

            // Chuyển đổi kết quả từ IQueryable sang List để có thể khởi tạo BindingList
            List<ChiTietHoaDon> chiTietList = ttsp.ToList();

            // Trả về BindingList thay vì IQueryable
            return new BindingList<ChiTietHoaDon>(chiTietList);
        }
    }
}
