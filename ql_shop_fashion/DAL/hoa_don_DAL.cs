using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class hoa_don_DAL
    {
        QL_SHOP_DATADataContext data ;
        public hoa_don_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }

        public IQueryable getHoaDonOnline()
        {
            var ds = from hd in data.hoa_dons
                     where hd.hinh_thuc_ban==true
                     select new
                       {
                          hd.ma_hoa_don,
                          hd.ma_khach_hang,
                          hd.tong_don_hang,
                          hd.ma_phuong_thuc,
                          hd.trang_thai_giao_hang
                       };

            return ds;
        }
        public khach_hang getKhachHangHoaDonOnline(int maHD)
        {
         
            var result = (from hd in data.hoa_dons
                       join kh in data.khach_hangs on hd.ma_khach_hang equals kh.ma_khach_hang
                       where hd.ma_hoa_don==maHD
                       select new
                       {
                          kh.ten_khach_hang,
                           kh.dien_thoai,
                          kh.dia_chi
                       }).FirstOrDefault();

            if (result == null)
            {
                return null;
            }
            khach_hang khach = new khach_hang
            {
                ten_khach_hang = result.ten_khach_hang,
                dien_thoai = result.dien_thoai,
                dia_chi = result.dia_chi
            };
            return khach;
        }

        public bool updateTrangThaiGiaoHang(int maHD,string trangThai)
        {

            hoa_don hd = data.hoa_dons.Where(d => d.ma_hoa_don ==maHD).FirstOrDefault();
            if (hd != null)
            {

                //Sua.code = km.code;
                hd.trang_thai_giao_hang = trangThai;

                //Sua.ma_nhan_vien = km.ma_nhan_vien;

                data.SubmitChanges();
                return true;
            }
            return false;
        }

        //public List<bar_code> GetAllSanPham()
        //{
        //    var lstSP = data.san_phams.Select(sp => sp).ToList<san_pham>();
        //    List<bar_code> intem = new List<bar_code>();
        //    bar_code bc;
        //    foreach (var item in lstSP)
        //    {
        //        bc = new bar_code();
        //        bc.Barcode = item.ma_san_pham;
        //        bc.Tensp = item.ten_san_pham;
        //        intem.Add(bc);
        //    }
        //    return intem;
        //}

        public IQueryable getChiTietHoaDonOnline(int maHD)
        {
            var ds = from hd in data.hoa_dons
                       join cthd in data.chi_tiet_hoa_dons on hd.ma_hoa_don equals cthd.ma_hoa_don
                       join ttsp in data.thuoc_tinh_san_phams on cthd.ma_thuoc_tinh equals ttsp.ma_thuoc_tinh
                       join sp in data.san_phams on ttsp.ma_san_pham equals sp.ma_san_pham
                       where hd.ma_hoa_don == maHD
                       select new
                       {
                           cthd.ma_hoa_don,
                           cthd.ma_thuoc_tinh, 
                           sp.ten_san_pham,
                           cthd.gia,
                           cthd.giagiam,
                           cthd.so_luong,
                           cthd.thanh_tien
                       };

            return ds;
        }
        public int? ThemHoaDon(string maKhachHang, int maNhanVien, string maKhuyenMai, int maPhuongThuc,DateTime date)
        {

            data = new QL_SHOP_DATADataContext();
            var newHoaDon = new hoa_don
            {
                ma_nhan_vien = maNhanVien,
                ma_phuong_thuc = maPhuongThuc,
                doi_diem = false,
                    tong_so_luong_mua = 0,
                    tien_giam = 0,
                    tong_gia_tri = 0,
                hinh_thuc_ban = false,
                ngay_lap =date
                };

               
                // Kiểm tra và gán giá trị cho ma_khach_hang và ma_khuyen_mai
                if (!string.IsNullOrEmpty(maKhachHang) && int.TryParse(maKhachHang, out int parsedMaKhachHang))
                {
                    newHoaDon.ma_khach_hang = parsedMaKhachHang;
                }

                if (!string.IsNullOrEmpty(maKhuyenMai) && int.TryParse(maKhuyenMai, out int parsedMaKhuyenMai))
                {
                    newHoaDon.ma_khuyen_mai = parsedMaKhuyenMai;
                }
            try
            {
                data.hoa_dons.InsertOnSubmit(newHoaDon);
            }
            catch (SqlException sqlEx)
            {
                // Kiểm tra mã lỗi SQL (ví dụ mã lỗi 123 từ trigger RAISERROR)
                if (sqlEx.Number == 123)
                {

                    throw new Exception("Mã khuyến mãi đã đạt số lượng tối đa và không thể sử dụng thêm.");
                }
                else
                {
                    // Ném lỗi khác
                    throw new Exception("Đã xảy ra lỗi khi thêm hóa đơn!! ");
                }
            }
            data.SubmitChanges();



                return newHoaDon.ma_hoa_don;
            
           
        }

        public int? ThemHoaDonCoDoiDiem(string maKhachHang, int maNhanVien, string maKhuyenMai, int maPhuongThuc, DateTime date,int diem)
        {
            data = new QL_SHOP_DATADataContext();
            var newHoaDon = new hoa_don
                {
                    ma_nhan_vien = maNhanVien,
                    ma_phuong_thuc = maPhuongThuc,
                    tien_doi_diem =diem,
                    doi_diem=true,
                    tong_so_luong_mua = 0,
                    tien_giam = 0,
                    tong_gia_tri = 0,
                    ngay_lap = date

                };

                // Kiểm tra và gán giá trị cho ma_khach_hang và ma_khuyen_mai
                if (!string.IsNullOrEmpty(maKhachHang) && int.TryParse(maKhachHang, out int parsedMaKhachHang))
                {
                    newHoaDon.ma_khach_hang = parsedMaKhachHang;
                }

                if (!string.IsNullOrEmpty(maKhuyenMai) && int.TryParse(maKhuyenMai, out int parsedMaKhuyenMai))
                {
                    newHoaDon.ma_khuyen_mai = parsedMaKhuyenMai;
                }
            try
            {
                data.hoa_dons.InsertOnSubmit(newHoaDon);
            }
            catch (SqlException sqlEx)
            {
                // Kiểm tra mã lỗi SQL (ví dụ mã lỗi 123 từ trigger RAISERROR)
                if (sqlEx.Number == 123)
                {
                    // Ném ngoại lệ với thông báo lỗi để truyền qua GUI
                    throw new Exception("Mã khuyến mãi đã đạt số lượng tối đa và không thể sử dụng thêm.");
                }
                if (sqlEx.Number == 5)
                {
                    // Ném ngoại lệ với thông báo lỗi để truyền qua GUI
                    throw new Exception("Không thể thêm hóa đơn vì điểm thưởng của khách hàng nhỏ hơn 50 (không áp dụng đổi điểm).");
                }
                //if (sqlEx.Number == 109)
                //{
                //    // Ném ngoại lệ với thông báo lỗi để truyền qua GUI
                //    throw new Exception(sqlEx.Message);
                //}
                else
                {
                    // Ném lỗi khác
                    throw new Exception("Đã xảy ra lỗi khi thêm hóa đơn!! ");
                }
            }
            data.SubmitChanges();



                return newHoaDon.ma_hoa_don;
            }
           
       
    }


}
