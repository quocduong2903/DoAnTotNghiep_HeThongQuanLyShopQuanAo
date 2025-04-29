using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class san_pham
    {
        public int ma_san_pham { get; set; }
        public string ten_san_pham { get; set; }
        public int ma_loai { get; set; }
        public int ma_thuong_hieu { get; set; }
        public string thumbnail_image { get; set; }
        public decimal giam_gia { get; set; } = 0;
        public int so_luong_kich_thuoc { get; set; }
        public int so_luong_mau_sac { get; set; }
        public int so_luong { get; set; }
        public string slug { get; set; }
        public string mo_ta { get; set; }
        public bool hinh_thuc_ban { get; set; } = false;
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }

}
