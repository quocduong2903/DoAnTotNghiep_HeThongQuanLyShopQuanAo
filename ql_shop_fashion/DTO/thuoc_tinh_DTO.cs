using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class thuoc_tinh_DTO
    {
        public int ma_thuoc_tinh { get; set; }
        public int ma_san_pham { get; set; }
        public int ma_kich_thuoc { get; set; }
        public int ma_mau_sac { get; set; }
        public string ten_kich_thuoc { get; set; }
        public string ten_mau_sac { get; set; }
        public int? so_luong_ton { get; set; }
        public decimal gia_ban { get; set; }
    }
}
