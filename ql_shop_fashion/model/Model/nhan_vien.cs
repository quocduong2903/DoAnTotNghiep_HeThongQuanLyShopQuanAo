using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class nhan_vien
    {
        public int ma_nhan_vien { get; set; } // Mã nhân viên
        public string ten_nhan_vien { get; set; } // Tên nhân viên
        public string chuc_vu { get; set; } // Chức vụ
        public string sdt { get; set; } // Số điện thoại
        public string dia_chi { get; set; } // Địa chỉ
        public DateTime? ngay_vao_lam { get; set; } // Ngày vào làm
        public int? tai_khoan_id { get; set; } // Mã tài khoản
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
