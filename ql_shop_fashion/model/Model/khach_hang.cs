using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class khach_hang
    {
        public int ma_khach_hang { get; set; } // Mã khách hàng
        public string ten_khach_hang { get; set; } // Tên khách hàng
        public string dien_thoai { get; set; } // Điện thoại
        public string dia_chi { get; set; } // Địa chỉ
        public int diem_thuong { get; set; } = 0; // Điểm thưởng
        public int? tai_khoan_id { get; set; } // Mã tài khoản
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
