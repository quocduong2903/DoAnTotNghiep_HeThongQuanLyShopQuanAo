using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class thong_ke_sql_DAL
    {
        QL_SHOP_DATADataContext data;
        public thong_ke_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }





        public List<thong_ke_ban_hang_DTO> GetBanHangTheoNgay(DateTime ngay)
        {
            return data.hoa_dons
                .Where(h => h.ngay_lap.HasValue && h.ngay_lap.Value.Date == ngay.Date)
                .SelectMany(h => data.chi_tiet_hoa_dons
                    .Where(ct => ct.ma_hoa_don == h.ma_hoa_don)
                    .Join(data.thuoc_tinh_san_phams,
                          ct => ct.ma_thuoc_tinh,
                          tt => tt.ma_thuoc_tinh,
                          (ct, tt) => new { ct, tt })
                    .Join(data.san_phams,
                          ct_tt => ct_tt.tt.ma_san_pham,
                          sp => sp.ma_san_pham,
                          (ct_tt, sp) => new { ct_tt.ct, sp })
                    .Join(data.loai_san_phams,
                          sp_ct => sp_ct.sp.ma_loai,
                          l => l.ma_loai,
                          (sp_ct, l) => new { sp_ct.ct, sp_ct.sp, l })
                    .Join(data.nhom_loais,
                          l_sp_ct => l_sp_ct.l.ma_nhom_loai,
                          nl => nl.ma_nhom_loai,
                          (l_sp_ct, nl) => new
                          {
                              l_sp_ct.ct.ma_hoa_don,
                              ngayBan = h.ngay_lap,
                              soLuongSanPham = l_sp_ct.ct.so_luong,
                              tongTien = l_sp_ct.ct.thanh_tien,
                              maNhomLoai = nl.ma_nhom_loai,
                              tenNhomLoai = nl.ten_nhom_loai
                          }))
                .GroupBy(x => new { x.ngayBan, x.maNhomLoai, x.tenNhomLoai })
                .Select(g => new thong_ke_ban_hang_DTO
                {
                    ngayBan = g.Key.ngayBan ?? DateTime.Now,
                    maNhomLoai = g.Key.maNhomLoai,
                    tenNhomLoai = g.Key.tenNhomLoai,
                    soLuongSanPham = g.Sum(x => x.soLuongSanPham),
                    tongTien = g.Sum(x => x.tongTien)
                })
                .ToList();
        }







        public List<thong_ke_theo_thang_DTO> GetBanHangTheoThang(int nam)
        {
            return data.hoa_dons
                .Where(h => h.ngay_lap.HasValue && h.ngay_lap.Value.Year == nam)
                .GroupBy(h => h.ngay_lap.Value.Month)
                .Select(g => new thong_ke_theo_thang_DTO
                {
                    Thang = $"{g.Key}/{nam}",
                    TongTien = g.Sum(h => h.tong_tien ?? 0),
                    TongSanPham = data.chi_tiet_hoa_dons
                                      .Where(ct => g.Select(h => h.ma_hoa_don).Contains(ct.ma_hoa_don))
                                      .Sum(ct => (int?)ct.so_luong) ?? 0, // Sử dụng int?
                })
                .ToList();
        }









        public List<thong_ke_theo_nam_DTO> GetBanHangTheoNam(int startYear, int endYear)
        {
            return data.hoa_dons
                .Where(h => h.ngay_lap.HasValue &&
                            h.ngay_lap.Value.Year >= startYear &&
                            h.ngay_lap.Value.Year <= endYear) // Lọc năm
                .GroupJoin(
                    data.chi_tiet_hoa_dons,
                    h => h.ma_hoa_don,
                    ct => ct.ma_hoa_don,
                    (hoaDon, chiTietHoaDons) => new { hoaDon, chiTietHoaDons } // Nhóm hoá đơn với chi tiết hoá đơn
                )
                .GroupBy(g => g.hoaDon.ngay_lap.Value.Year) // Nhóm theo năm
                .Select(g => new thong_ke_theo_nam_DTO
                {
                    Nam = g.Key, // Năm
                    TongTien = g.Sum(h => h.hoaDon.tong_tien ?? 0), // Tổng tiền (nếu null thì mặc định là 0)
                    TongSanPham = g.Sum(h => h.chiTietHoaDons.Sum(ct => ct.so_luong)) // Tổng sản phẩm
                })
                .OrderBy(dto => dto.Nam) // Sắp xếp theo năm (tăng dần)
                .ToList();
        }



        public List<thong_ke_doi_tra_DTO> GetDoiTraTheoNgay(DateTime ngay)
        {
            return data.hoa_don_doi_tras
                .Where(dt => dt.ngay_doi_tra.HasValue && dt.ngay_doi_tra.Value.Date == ngay.Date)
                .SelectMany(dt => dt.chi_tiet_hoa_don_doi_tras.Select(ct => new
                {
                    ngayDoiTra = dt.ngay_doi_tra.Value,
                    maNhomLoai = data.thuoc_tinh_san_phams
                                  .Where(tt => tt.ma_thuoc_tinh == ct.ma_thuoc_tinh)
                                  .Join(data.san_phams,
                                        tt => tt.ma_san_pham,
                                        sp => sp.ma_san_pham,
                                        (tt, sp) => sp.loai_san_pham.ma_nhom_loai)
                                  .FirstOrDefault(),
                    tenNhomLoai = data.thuoc_tinh_san_phams
                                  .Where(tt => tt.ma_thuoc_tinh == ct.ma_thuoc_tinh)
                                  .Join(data.san_phams,
                                        tt => tt.ma_san_pham,
                                        sp => sp.ma_san_pham,
                                        (tt, sp) => sp.loai_san_pham.nhom_loai.ten_nhom_loai)
                                  .FirstOrDefault(),
                    soLuongTra = ct.so_luong,
                    tongTienHoanTra = (ct.gia - ct.giagiam) * ct.so_luong
                }))
                .GroupBy(x => new { x.ngayDoiTra, x.maNhomLoai, x.tenNhomLoai })
                .Select(g => new thong_ke_doi_tra_DTO
                {
                    ngayDoiTra = g.Key.ngayDoiTra,
                    maNhomLoai = g.Key.maNhomLoai,
                    tenNhomLoai = g.Key.tenNhomLoai,
                    soLuongTra = g.Sum(x => x.soLuongTra),
                    tongTienHoanTra = g.Sum(x => x.tongTienHoanTra)
                })
                .ToList();
        }








        public List<thong_ke_doi_tra_thang_DTO> GetDoiTraTheoThang(int nam, int thang)
        {
            return data.hoa_don_doi_tras
                .Where(hd => hd.ngay_doi_tra.HasValue &&
                             hd.ngay_doi_tra.Value.Year == nam &&
                             hd.ngay_doi_tra.Value.Month == thang)
                .Select(hd => new thong_ke_doi_tra_thang_DTO
                {
                    ngayDoiTra = hd.ngay_doi_tra.Value,
                    soLuongTra = hd.tong_so_luong ?? 0,
                    tongTienHoanTra = hd.tien_hoan ?? 0
                })
                .ToList();
        }






        public List<thong_ke_doi_tra_nam_DTO> GetDoiTraTheoNam(int startYear, int endYear)
        {
            if (startYear > endYear)
            {
                throw new ArgumentException("Start year cannot be greater than end year.");
            }

            return data.hoa_don_doi_tras
                .Where(hd => hd.ngay_doi_tra.HasValue &&
                             hd.ngay_doi_tra.Value.Year >= startYear &&
                             hd.ngay_doi_tra.Value.Year <= endYear)
                .Select(hd => new thong_ke_doi_tra_nam_DTO
                {
                    ngayDoiTra = hd.ngay_doi_tra.Value,
                    soLuongTra = hd.tong_so_luong ?? 0,
                    tongTienHoanTra = hd.tien_hoan ?? 0
                })
                .ToList();
        }




        public List<thong_ke_nhap_hang_theo_thang_DTO> GetThongKeNhapHangTheoThang(int thang, int nam)
        {
            return data.chi_tiet_nhap_hangs
                .Where(ct => ct.nhap_hang.ngay_nhap.Value.Month == thang && ct.nhap_hang.ngay_nhap.Value.Year == nam)
                .GroupBy(ct => new { ct.ma_san_pham, ct.san_pham.ten_san_pham }) // Sử dụng join với san_pham để lấy tên sản phẩm
                .Select(g => new thong_ke_nhap_hang_theo_thang_DTO
                {
                    thang = thang,
                    maSanPham = g.Key.ma_san_pham,
                    tenSanPham = g.Key.ten_san_pham,
                    soLuong = g.Sum(ct => ct.so_luong),
                    donGia = g.FirstOrDefault().gia_nhap, // Sử dụng 'gia_nhap' thay vì 'don_gia'
                    thanhTien = g.Sum(ct => ct.so_luong * ct.gia_nhap) // Sử dụng 'gia_nhap'
                })
                .ToList();
        }



        public List<thong_ke_nhap_hang_theo_nam_DTO> GetThongKeNhapHangTheoNam(int startYear, int endYear)
        {
            return data.chi_tiet_nhap_hangs
                .Where(ct => ct.nhap_hang.ngay_nhap.HasValue &&
                            ct.nhap_hang.ngay_nhap.Value.Year >= startYear &&
                            ct.nhap_hang.ngay_nhap.Value.Year <= endYear)
                .GroupBy(ct => new { ct.nhap_hang.ngay_nhap.Value.Year, ct.ma_san_pham, ct.san_pham.ten_san_pham })
                .Select(g => new thong_ke_nhap_hang_theo_nam_DTO
                {
                    nam = g.Key.Year,
                    maSanPham = g.Key.ma_san_pham,
                    tenSanPham = g.Key.ten_san_pham,
                    soLuong = g.Sum(ct => ct.so_luong),
                    donGia = g.FirstOrDefault() != null ? g.FirstOrDefault().gia_nhap : 0,
                    thanhTien = g.Sum(ct => ct.so_luong * ct.gia_nhap)
                })
                .ToList();
        }










    }
}
