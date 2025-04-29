using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class thong_ke_nhap_hang_theo_thang_DTO
    {
        public int thang { get; set; }
        public int maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public int soLuong { get; set; }
        public decimal donGia { get; set; }
        public decimal thanhTien { get; set; }
    }
}
