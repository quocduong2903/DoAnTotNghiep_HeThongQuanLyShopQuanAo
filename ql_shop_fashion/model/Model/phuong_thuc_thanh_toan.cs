using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class phuong_thuc_thanh_toan
    {
        public int ma_phuong_thuc { get; set; } // Mã phương thức
        public string ten_phuong_thuc { get; set; } // Tên phương thức thanh toán
        public string mo_ta { get; set; } // Mô tả phương thức thanh toán
        public string trang_thai { get; set; } // Trạng thái thanh toán
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
