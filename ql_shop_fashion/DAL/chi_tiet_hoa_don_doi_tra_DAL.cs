using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
   public class chi_tiet_hoa_don_doi_tra_DAL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        public chi_tiet_hoa_don_doi_tra_DAL()
        {

        }
        public bool ThemChiTietHoaDonDoiTra(int maHD, int maSP,string trangThai, decimal giaBan, int soLuongMua)
        {
            try
            {
                var newCTHoaDon = new chi_tiet_hoa_don_doi_tra
                {
                    ma_hoa_don = maHD,
                    ma_thuoc_tinh = maSP,
                    gia = giaBan,
                    so_luong = soLuongMua
                };

                // Kiểm tra và cập nhật trạng thái
                if (string.IsNullOrEmpty(trangThai)||trangThai=="")
                {
                    newCTHoaDon.trang_thai = "bình thường";
                }
                else
                {
                    newCTHoaDon.trang_thai = trangThai;
                }

                data.chi_tiet_hoa_don_doi_tras.InsertOnSubmit(newCTHoaDon);
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
    }
}
