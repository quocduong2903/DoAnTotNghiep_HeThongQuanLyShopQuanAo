using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class nha_cung_cap_san_pham
    {
        public int ma_nha_cung_cap { get; set; } // Mã nhà cung cấp
        public int ma_san_pham { get; set; } // Mã sản phẩm
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
