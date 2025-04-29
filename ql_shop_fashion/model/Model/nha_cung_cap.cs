using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class nha_cung_cap
    {
        // Thuộc tính mã nhà cung cấp
        public int ma_nha_cung_cap { get; set; }

        // Thuộc tính tên nhà cung cấp
        public string ten_nha_cung_cap { get; set; }

        // Thuộc tính địa chỉ
        public string dia_chi { get; set; }

        // Thuộc tính điện thoại
        public string dien_thoai { get; set; }

        // Thuộc tính thời gian tạo
        public DateTime created_at { get; set; } = DateTime.Now;

        // Thuộc tính thời gian cập nhật
        public DateTime updated_at { get; set; } = DateTime.Now;
    }

}
