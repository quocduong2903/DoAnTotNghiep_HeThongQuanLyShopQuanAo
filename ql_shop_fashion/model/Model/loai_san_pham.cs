using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class loai_san_pham
    {
        // Thuộc tính mã loại
        public int ma_loai { get; set; }

        // Thuộc tính tên loại
        public string ten_loai { get; set; }

        // Thuộc tính mã nhóm loại (khóa ngoại đến nhom_loai)
        public int ma_nhom_loai { get; set; }

        // Thuộc tính hình ảnh thumbnail
        public string thumbnail_image { get; set; }

        // Thuộc tính slug
        public string slug { get; set; }

        // Thuộc tính chi tiết
        public string chi_tiet { get; set; }

        // Thuộc tính thời gian tạo
        public DateTime created_at { get; set; } = DateTime.Now;

        // Thuộc tính thời gian cập nhật
        public DateTime updated_at { get; set; } = DateTime.Now;
    }

}
