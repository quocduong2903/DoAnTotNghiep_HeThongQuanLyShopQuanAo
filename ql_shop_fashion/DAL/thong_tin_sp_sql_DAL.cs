using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class thong_tin_sp_sql_DAL
    {
        private QL_SHOP_DATADataContext data;

        public thong_tin_sp_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }


        public List<thong_tin_sanpham_DTO> get_all_ttsp()
        {
            var ds = from i in data.thong_tin_san_phams
                     select new thong_tin_sanpham_DTO
                     {
                         ma_thong_tin_san_pham = i.ma_thong_tin_san_pham,
                         ma_san_pham = (int)i.ma_san_pham,
                         key_attribute = i.key_attribute,
                         value_attribute = i.value_attribute
                     };
            return ds.ToList();
        }


        public List<thong_tin_sanpham_DTO> getThongTinSanPhamByMaSP(int maSanPham)
        {
            // Thực hiện truy vấn
            var ds = from i in data.thong_tin_san_phams
                     where i.ma_san_pham == maSanPham
                     select new thong_tin_sanpham_DTO
                     {
                         ma_thong_tin_san_pham = i.ma_thong_tin_san_pham,
                         ma_san_pham = (int)i.ma_san_pham,
                         key_attribute = i.key_attribute,
                         value_attribute = i.value_attribute
                     };

            return ds.ToList();
        }

        public thong_tin_sanpham_DTO getThongTinSanPhamByMaTT(int maThongTin)
        {
            var result = data.thong_tin_san_phams
                .Where(x => x.ma_thong_tin_san_pham == maThongTin)
                .Select(x => new thong_tin_sanpham_DTO
                {
                    ma_thong_tin_san_pham = x.ma_thong_tin_san_pham,
                    ma_san_pham = (int)x.ma_san_pham,
                    key_attribute = x.key_attribute,
                    value_attribute = x.value_attribute
                })
                .FirstOrDefault();

            return result;
        }

        public int getNextMaThongTin()
        {
            return data.thong_tin_san_phams.Max(x => x.ma_thong_tin_san_pham) + 1;
        }




        public bool addThongTinSanPham(thong_tin_sanpham_DTO tt)
        {
            try
            {
                var newRecord = new thong_tin_san_pham
                {
                    ma_san_pham = tt.ma_san_pham,
                    key_attribute = tt.key_attribute,
                    value_attribute = tt.value_attribute
                };

                data.thong_tin_san_phams.InsertOnSubmit(newRecord);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateThongTinSanPham(thong_tin_sanpham_DTO tt)
        {
            try
            {
                var record = data.thong_tin_san_phams.FirstOrDefault(x => x.ma_thong_tin_san_pham == tt.ma_thong_tin_san_pham);
                if (record != null)
                {
                    record.key_attribute = tt.key_attribute;
                    record.value_attribute = tt.value_attribute;
                    data.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteThongTinSanPham(int maThongTin)
        {
            try
            {
                var record = data.thong_tin_san_phams.FirstOrDefault(x => x.ma_thong_tin_san_pham == maThongTin);
                if (record != null)
                {
                    data.thong_tin_san_phams.DeleteOnSubmit(record);
                    data.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


    }
}
