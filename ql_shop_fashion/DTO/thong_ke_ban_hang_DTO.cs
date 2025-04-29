using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class thong_ke_ban_hang_DTO
    {
        public DateTime? ngayBan { get; set; } 
        public int? maNhomLoai { get; set; }
        public string tenNhomLoai { get; set; }
        public int? soLuongSanPham { get; set; } 
        public decimal? tongTien { get; set; } 
    }

}
