using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class loai_sanpham_sql_DAL
    {
        private QL_SHOP_DATADataContext data;
        public loai_sanpham_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }

        public List<loai_sanpham_DTO> get_all_loai_sp()
        {
            var ds = from i in data.loai_san_phams
                     select new loai_sanpham_DTO
                     {
                         ma_loai = i.ma_loai,
                         ten_loai = i.ten_loai,
                         ma_nhom_loai = i.ma_nhom_loai,
                         chi_tiet = i.chi_tiet
                     };
            return ds.ToList();
        }

        public nhom_loai getNhomLoaiByName(string tenNhomLoai)
        {
            return data.nhom_loais.FirstOrDefault(n => n.ten_nhom_loai == tenNhomLoai);
        }


        public loai_san_pham getLoaiSPById(int maloai)
        {
            return data.loai_san_phams.FirstOrDefault(p => p.ma_loai == maloai);
        }

        public bool AddLoaiSP(loai_san_pham newLoaiSP)
        {
            try
            {
                data.loai_san_phams.InsertOnSubmit(newLoaiSP);
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLoaiSP(loai_san_pham updatedLoaiSP)
        {
            try
            {
                var loaisp = data.loai_san_phams.SingleOrDefault(k => k.ma_loai == updatedLoaiSP.ma_loai);
                if (loaisp != null)
                {
                    loaisp.ten_loai = updatedLoaiSP.ten_loai;
                    loaisp.ma_nhom_loai = updatedLoaiSP.ma_nhom_loai;
                    loaisp.chi_tiet = updatedLoaiSP.chi_tiet;
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


        public bool DeleteLoaiSPById(int maloai)
        {
            try
            {
                // Tìm thương hiệu theo ma_thuong_hieu
                var loaisp = data.loai_san_phams
                    .FirstOrDefault(p => p.ma_loai == maloai);

                if (loaisp != null)
                {
                    data.loai_san_phams.DeleteOnSubmit(loaisp);
                    data.SubmitChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy loại sản phẩm với mã loại sản phẩm đã cho.");
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