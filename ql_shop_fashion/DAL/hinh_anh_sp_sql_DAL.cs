using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class hinh_anh_sp_sql_DAL
    {
        private QL_SHOP_DATADataContext data;

        public hinh_anh_sp_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }



        // Lấy danh sách hình ảnh theo mã sản phẩm
        public List<hinh_anh_sp_DTO> GetHinhAnhByMaSanPham(int maSanPham)
        {
            return data.hinh_anh_san_phams
                .Where(x => x.ma_san_pham == maSanPham)
                .Select(x => new hinh_anh_sp_DTO
                {
                    ma_hinh_anh = x.ma_hinh_anh,
                    ma_san_pham = (int)x.ma_san_pham,
                    hinh_anh = x.hinh_anh
                })
                .ToList();
        }


        public bool AddHinhAnhSanPham(hinh_anh_sp_DTO hinhAnh)
        {
            try
            {
                // Tạo một đối tượng mới từ DTO
                var entity = new hinh_anh_san_pham
                {
                    ma_san_pham = hinhAnh.ma_san_pham,
                    hinh_anh = hinhAnh.hinh_anh
                };

                // Thêm đối tượng vào bảng
                data.hinh_anh_san_phams.InsertOnSubmit(entity);

                // Lưu thay đổi vào cơ sở dữ liệu
                data.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteImagesByMaSanPham(int maSanPham)
        {
            try
            {
                var imagesToDelete = data.hinh_anh_san_phams.Where(x => x.ma_san_pham == maSanPham).ToList();
                data.hinh_anh_san_phams.DeleteAllOnSubmit(imagesToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



    }

}
