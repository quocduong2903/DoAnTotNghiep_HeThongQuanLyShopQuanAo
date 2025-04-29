using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class khuyen_mai_sql_DAL
    {
        QL_SHOP_DATADataContext data;
        public khuyen_mai_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }
        public IQueryable get_all_khuyen_mai()
        {
            var ds = from i in data.khuyen_mais


                     select new
                     {
                         i.ma_khuyen_mai,
                         i.code,
                         i.gia_tri,

                         i.gia_tri_hoa_don_toi_thieu,

                     };
            return ds;
        }

        public IQueryable getKhuyenMai()
        {
            var ds = from i in data.khuyen_mais
                     select new
                     {
                         i.ma_khuyen_mai,
                         i.code,
                         i.gia_tri,
                         i.thoi_gian_bat_dau,
                         i.thoi_gian_ket_thuc,
                         i.so_luong_toi_da,
                         i.so_luong_da_dung,
                         i.tinh_trang,
                         i.gia_tri_hoa_don_toi_thieu
                       

                     };
            return ds;
        }
        public IQueryable GetKhuyenMaiCoNhanVien()
        {
            var khuyenMai = from i in data.khuyen_mais
                            join nv in data.nhan_viens on i.ma_nhan_vien equals nv.ma_nhan_vien
                            select new
                            {
                                i.ma_khuyen_mai,
                                i.code,
                                i.gia_tri,
                                i.thoi_gian_bat_dau,
                                i.thoi_gian_ket_thuc,
                                i.so_luong_toi_da,
                                i.so_luong_da_dung,
                                i.gia_tri_hoa_don_toi_thieu,
                                i.tinh_trang,                               
                                i.ghi_chu,
                                nv.ten_nhan_vien      
                            };
            return khuyenMai;
        }

        public bool ThenKhuyenMai(khuyen_mai km)
        {
            try
            {
                data.khuyen_mais.InsertOnSubmit(km);
                data.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool kiemTraTrungCode(string code)
        {
            try
            {
               khuyen_mai isDuplicate = data.khuyen_mais.Where(d => d.code == code).FirstOrDefault();
                if (isDuplicate!=null)
                {
                    return false; 
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaKhuyenMai(int ma)
        {
            khuyen_mai Xoa = data.khuyen_mais.Where(d => d.ma_khuyen_mai==ma).FirstOrDefault();
            if (Xoa != null)
            {
                try
                {
                    data.khuyen_mais.DeleteOnSubmit(Xoa);
                    data.SubmitChanges();
                }
                catch(SqlException sqlEX)
                {
                    throw new Exception("Khuyến mãi đang được sử dụng không được xóa");
                }
                
                return true;
            }
            return false;
        }

        public bool suaKhuyenMai(khuyen_mai km)
        {

            khuyen_mai Sua = data.khuyen_mais.Where(d => d.ma_khuyen_mai == km.ma_khuyen_mai).FirstOrDefault();
            if (Sua != null)
            {
      
                //Sua.code = km.code;
                Sua.gia_tri = km.gia_tri;
                Sua.thoi_gian_bat_dau = km.thoi_gian_bat_dau;
                Sua.thoi_gian_ket_thuc = km.thoi_gian_ket_thuc;
                Sua.so_luong_toi_da = km.so_luong_toi_da;
                Sua.so_luong_da_dung = km.so_luong_da_dung;
                Sua.gia_tri_hoa_don_toi_thieu = km.gia_tri_hoa_don_toi_thieu;
                Sua.tinh_trang = km.tinh_trang;
                Sua.ghi_chu = km.ghi_chu;
                //Sua.ma_nhan_vien = km.ma_nhan_vien;

                data.SubmitChanges();
                return true;
            }
            return false;
        }
        public List<khuyen_mai> GetKhuyeMaiTest()
        {
            return data.khuyen_mais.Select(mh => mh).ToList<khuyen_mai>();
        }
    }
}
