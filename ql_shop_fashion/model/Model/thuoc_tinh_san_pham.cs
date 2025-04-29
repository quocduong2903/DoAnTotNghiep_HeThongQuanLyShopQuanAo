using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class thuoc_tinh_san_pham
    {
        public int ma_thuoc_tinh { get; set; }
        public int ma_san_pham { get; set; }
        public int ma_kich_thuoc { get; set; }
        public int ma_mau_sac { get; set; }
        public int so_luong_ton { get; set; } = 0;
        public decimal gia_ban { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }

}
