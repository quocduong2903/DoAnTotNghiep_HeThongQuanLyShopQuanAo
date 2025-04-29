using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class hinh_anh_sp_sql_BLL
    {
        hinh_anh_sp_sql_DAL hinhanh;
        public hinh_anh_sp_sql_BLL()
        {
            hinhanh = new hinh_anh_sp_sql_DAL();
        }

        public bool AddHinhAnhSanPham(hinh_anh_sp_DTO hinhAnh)
        {
            return hinhanh.AddHinhAnhSanPham(hinhAnh);
        }


        // Lấy danh sách hình ảnh sản phẩm theo mã sản phẩm
        public List<hinh_anh_sp_DTO> GetHinhAnhByMaSanPham(int maSanPham)
        {
            return hinhanh.GetHinhAnhByMaSanPham(maSanPham);
        }
    }
}
