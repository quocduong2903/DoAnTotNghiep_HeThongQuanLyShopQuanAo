using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class chi_tiet_hoa_don
    {
        public int ma_hoa_don { get; set; } // Mã hóa đơn
        public int ma_thuoc_tinh { get; set; } // Mã chi tiết sản phẩm
        public int so_luong { get; set; } // Số lượng
        public decimal gia { get; set; } // Giá
        public decimal thanh_tien => gia * so_luong; // Thành tiền
        public string trang_thai { get; set; } // Trạng thái
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
