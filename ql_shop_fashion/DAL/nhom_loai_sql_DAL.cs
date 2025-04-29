using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class nhom_loai_sql_DAL
    {
        private QL_SHOP_DATADataContext data;
        public nhom_loai_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }

        public List<nhom_loai_DTO> get_all_nhom_loai()
        {
            var ds = from i in data.nhom_loais
                     select new nhom_loai_DTO
                     {
                         ma_nhom_loai = i.ma_nhom_loai,
                         ten_nhom_loai = i.ten_nhom_loai,
                         chi_tiet = i.chi_tiet
                     };
            return ds.ToList();
        }

        public nhom_loai getNhomLoaiById(int manhomloai)
        {
            return data.nhom_loais.FirstOrDefault(p => p.ma_nhom_loai == manhomloai);
        }

        public bool AddNL(nhom_loai newNL)
        {
            try
            {
                data.nhom_loais.InsertOnSubmit(newNL);
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateNL(nhom_loai updatedNL)
        {
            try
            {
                var nhomloai = data.nhom_loais.SingleOrDefault(k => k.ma_nhom_loai == updatedNL.ma_nhom_loai);
                if (nhomloai != null)
                {
                    nhomloai.ten_nhom_loai = updatedNL.ten_nhom_loai;
                    nhomloai.chi_tiet = updatedNL.chi_tiet;
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


        public bool DeleteNLById(int manhomloai)
        {
            try
            {
                // Tìm nhóm loại theo ma_nhom_loai
                var nhomloai = data.nhom_loais
                    .FirstOrDefault(p => p.ma_nhom_loai == manhomloai);

                if (nhomloai != null)
                {
                    data.nhom_loais.DeleteOnSubmit(nhomloai);
                    data.SubmitChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy nhóm loại với mã nhóm loại đã cho.");
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
