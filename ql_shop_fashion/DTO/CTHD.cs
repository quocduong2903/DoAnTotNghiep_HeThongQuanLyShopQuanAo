using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHD
    {
        private int ma_thuoc_tinh;
        private decimal? giaGiam;

        public CTHD(int ma_thuoc_tinh, string ten_san_pham, decimal gia_ban, decimal? giaGiam)
        {
            this.ma_thuoc_tinh = ma_thuoc_tinh;
            this.ten_san_pham = ten_san_pham;
            this.gia_ban = gia_ban;
            this.giaGiam = giaGiam;
        }

        public int ma { get; set; }
        public string ten_san_pham { get; set; }
        public decimal gia_ban { get; set; }
        public decimal GiaGiam { get; set; }
    }
}
