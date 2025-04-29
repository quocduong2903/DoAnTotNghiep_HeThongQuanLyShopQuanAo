using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class oauth_provider
    {
        public int id { get; set; } // ID của nhà cung cấp OAuth
        public int tai_khoan_id { get; set; } // ID của tài khoản
        public string provider { get; set; } // Tên nhà cung cấp OAuth
        public string provider_id { get; set; } // ID của người dùng từ nhà cung cấp OAuth
        public DateTime create_at { get; set; } = DateTime.Now; // Thời điểm tạo bản ghi
        public DateTime update_at { get; set; } = DateTime.Now; // Thời điểm cập nhật bản ghi
    }

}
