using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class tai_khoan
    {
        public int id { get; set; } // ID của tài khoản
        public string ten_dang_nhap { get; set; } // Tên đăng nhập
        public string mat_khau_hash { get; set; } // Mật khẩu đã băm
        public bool? hoat_dong { get; set; } // Trạng thái của tài khoản
        public bool is_oauth { get; set; } = false; // Xác định tài khoản có sử dụng OAuth hay không
        public DateTime create_at { get; set; } = DateTime.Now; // Thời điểm tạo bản ghi
        public DateTime update_at { get; set; } = DateTime.Now; // Thời điểm cập nhật bản ghi
    }

}
