using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class hoa_don_doi_tra_DTO
    {
        public int MaHoaDon { get; set; }
        public DateTime? NgayDoiTra { get; set; }
        public decimal TongTienHoan { get; set; } 
        public int TongSoLuongTra { get; set; }
    }
}
