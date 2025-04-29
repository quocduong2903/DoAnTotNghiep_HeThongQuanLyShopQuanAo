using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class nhom_quyen
    {
        public int id_nhom_quyen { get; set; } // ID của nhóm quyền
        public string ten_nhom { get; set; } // Tên của nhóm quyền
        public string mo_ta { get; set; } // Mô tả của nhóm quyền
        public DateTime create_at { get; set; } = DateTime.Now; // Thời điểm tạo bản ghi
        public DateTime update_at { get; set; } = DateTime.Now; // Thời điểm cập nhật bản ghi
    }
}
