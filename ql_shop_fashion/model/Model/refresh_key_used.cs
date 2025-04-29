using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class refresh_key_used
    {
        public int id { get; set; } // ID của refresh_key_used tự động tăng
        public int key_store_id { get; set; } // ID của key_store
        public string refresh_token { get; set; } // Refresh token đã sử dụng
        public DateTime used_at { get; set; } = DateTime.Now; // Thời điểm sử dụng
    }

}
