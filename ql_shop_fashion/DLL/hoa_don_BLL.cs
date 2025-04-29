using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class hoa_don_BLL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        hoa_don_DAL hd = new hoa_don_DAL();
        public hoa_don_BLL()
        {

        }

        public int? ThemHoaDon(string maKhachHang, int maNhanVien, string maKhuyenMai, int maPhuongThuc, DateTime ngay)
        {
            return hd.ThemHoaDon(maKhachHang, maNhanVien, maKhuyenMai, maPhuongThuc, ngay);
        }

        public int? ThemHoaDonCoDoiDiem(string maKhachHang, int maNhanVien, string maKhuyenMai, int maPhuongThuc, DateTime ngay, int diem)
        {
            return hd.ThemHoaDonCoDoiDiem(maKhachHang, maNhanVien, maKhuyenMai, maPhuongThuc, ngay, diem);
        }

        public IQueryable getHoaDonOnline()
        {
            return hd.getHoaDonOnline();
        }
        public khach_hang getKhachHangHoaDonOnline(int maHD)
        {
            return hd.getKhachHangHoaDonOnline(maHD);
        }

        public IQueryable getChiTietHoaDonOnline(int maHD)
        {
            return hd.getChiTietHoaDonOnline(maHD);
        }

        public bool updateTrangThaiGiaoHang(int maHD, string trangThai)
        {

            return hd.updateTrangThaiGiaoHang(maHD, trangThai);
        }

    }
}
