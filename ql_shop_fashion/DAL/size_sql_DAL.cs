using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class size_sql_DAL
    {
        private QL_SHOP_DATADataContext data;
        public size_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }

        public List<kich_thuoc_DTO> get_all_size()
        {
            var ds = from i in data.kich_thuocs
                     select new kich_thuoc_DTO
                     {
                         ma_kich_thuoc = i.ma_kich_thuoc,
                         ten_kich_thuoc = i.ten_kich_thuoc,
                         phu_phi_size = i.phu_phi_size
                     };
            return ds.ToList();
        }

        public kich_thuoc getSizeById(int makichthuoc)
        {
            return data.kich_thuocs.FirstOrDefault(p => p.ma_kich_thuoc == makichthuoc);
        }


        public bool AddSize(kich_thuoc newSize)
        {
            try
            {
                data.kich_thuocs.InsertOnSubmit(newSize); // Chỉ cần thêm tên và phụ phí
                data.SubmitChanges(); // Cơ sở dữ liệu tự động tạo mã
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm kích thước: " + ex.Message);
                return false;
            }
        }



        public bool UpdateSize(kich_thuoc updatedSize)
        {
            try
            {
                var size = data.kich_thuocs.SingleOrDefault(k => k.ma_kich_thuoc == updatedSize.ma_kich_thuoc);
                if (size != null)
                {
                    size.ten_kich_thuoc = updatedSize.ten_kich_thuoc;
                    size.phu_phi_size = updatedSize.phu_phi_size;
                    data.SubmitChanges();
                    return true;
                }
                Console.WriteLine("Không tìm thấy kích thước với mã: " + updatedSize.ma_kich_thuoc);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật kích thước: " + ex.Message);
                return false;
            }
        }



        public bool DeleteSizeById(int makichthuoc)
        {
            try
            {
                // Tìm kích thước theo ma_kich_thuoc
                var kichthuoc = data.kich_thuocs
                    .FirstOrDefault(p => p.ma_kich_thuoc == makichthuoc);

                if (kichthuoc != null)
                {
                    data.kich_thuocs.DeleteOnSubmit(kichthuoc);
                    data.SubmitChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy kích thước với mã kích thước đã cho.");
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
