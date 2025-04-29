using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class key_store
    {
        public int id { get; set; } // ID của key_store tự động tăng
        public int tai_khoan_id { get; set; } // ID của tài khoản
        public string refresh_token { get; set; } // Refresh token
        public string public_key { get; set; } // Public key
        public string private_key { get; set; } // Private key
        public DateTime create_at { get; set; } = DateTime.Now; // Thời điểm tạo bản ghi
        public DateTime update_at { get; set; } = DateTime.Now; // Thời điểm cập nhật bản ghi

    }
}
