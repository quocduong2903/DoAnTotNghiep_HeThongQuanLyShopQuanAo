using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ChiTietHoaDon
    {
        public int ma_thuoc_tinh { get; set; }
        public string ten_san_pham { get; set; }
        public int so_luong { get; set; }
        public decimal gia { get; set; }
        public decimal giagiam { get; set; }
        public decimal thanh_tien { get; set; }
        public string trang_thai { get; set; }
    }
}
