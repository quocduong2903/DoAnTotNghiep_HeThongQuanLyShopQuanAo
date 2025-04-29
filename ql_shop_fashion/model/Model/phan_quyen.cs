using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class phan_quyen
    {
        public int id_man_hinh { get; set; } // ID của màn hình
        public int id_nhom_quyen { get; set; } // ID của nhóm quyền
        public bool? co_quyen { get; set; } // Nhóm quyền đó có thể vào màn hình không
        public DateTime create_at { get; set; } = DateTime.Now; // Thời điểm tạo bản ghi
        public DateTime update_at { get; set; } = DateTime.Now; // Thời điểm cập nhật bản ghi
    }
}
