using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class san_pham_DTO
    {
        public int ma_san_pham { get; set; }
        public string ten_san_pham { get; set; }
        public int? ma_loai { get; set; }
        public int? ma_thuong_hieu { get; set; }
        public decimal? giam_gia { get; set; }
        public int? so_luong_kich_thuoc { get; set; }
        public int? so_luong_mau_sac { get; set; }
        public int so_luong { get; set; }
        public string mo_ta { get; set; }
        public decimal? gia_binh_quan { get; set; }
        public int hinh_thuc_ban { get; set; }
    }

}
