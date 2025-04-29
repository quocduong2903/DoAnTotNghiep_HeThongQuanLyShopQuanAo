using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class danh_gia_san_pham
    {
        public int ma_danh_gia { get; set; } // Mã đánh giá tự động tăng
        public int ma_san_pham { get; set; } // Mã sản phẩm
        public int tai_khoan_id { get; set; } // ID của tài khoản người dùng
        public int diem_danh_gia { get; set; } // Điểm đánh giá (1-5)
        public string noi_dung { get; set; } // Nội dung đánh giá
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
