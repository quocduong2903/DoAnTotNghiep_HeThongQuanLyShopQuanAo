using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class thuong_hieu_sql_DAL
    {
        private QL_SHOP_DATADataContext data;
        public thuong_hieu_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }

        public List<thuong_hieu_DTO> get_all_thuong_hieu()
        {
            var ds = from i in data.thuong_hieus
                     select new thuong_hieu_DTO
                     {
                         ma_thuong_hieu = i.ma_thuong_hieu,
                         ten_thuong_hieu = i.ten_thuong_hieu,
                         mo_ta = i.mo_ta
                     };
            return ds.ToList();
        }

        public thuong_hieu getThuongHieuById(int mathuonghieu)
        {
            return data.thuong_hieus.FirstOrDefault(p => p.ma_thuong_hieu == mathuonghieu);
        }

        public bool AddTH(thuong_hieu newTH)
        {
            try
            {
                data.thuong_hieus.InsertOnSubmit(newTH);
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTH(thuong_hieu updatedTH)
        {
            try
            {
                var thuonghieu = data.thuong_hieus.SingleOrDefault(k => k.ma_thuong_hieu == updatedTH.ma_thuong_hieu);
                if (thuonghieu != null)
                {
                    thuonghieu.ten_thuong_hieu = updatedTH.ten_thuong_hieu;
                    thuonghieu.mo_ta = updatedTH.mo_ta;
                    data.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteTHById(int mathuonghieu)
        {
            try
            {
                // Tìm thương hiệu theo ma_thuong_hieu
                var thuonghieu = data.thuong_hieus
                    .FirstOrDefault(p => p.ma_thuong_hieu == mathuonghieu);

                if (thuonghieu != null)
                {
                    data.thuong_hieus.DeleteOnSubmit(thuonghieu);
                    data.SubmitChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy thương hiệu với mã thương hiệu đã cho.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                Console.WriteLine("Lỗi trong quá trình xóa sản phẩm: " + ex.Message);
                return false;
            }
        }

    }
}
