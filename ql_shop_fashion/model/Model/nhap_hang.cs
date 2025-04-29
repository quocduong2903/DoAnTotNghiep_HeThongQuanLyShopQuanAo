using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class nhap_hang
    {
        public int ma_nhap_hang { get; set; } // Mã nhập hàng tự động tăng
        public int ma_nhan_vien { get; set; } // Mã nhân viên
        public int ma_nha_cung_cap { get; set; } // Mã nhà cung cấp
        public DateTime ngay_nhap { get; set; } = DateTime.Now; // Ngày nhập
        public string trang_thai { get; set; } // Trạng thái
        public string ghi_chu { get; set; } // Ghi chú
        public int tong_so_luong { get; set; } // Tổng số lượng
        public decimal tong_gia_tien { get; set; } // Tổng giá tiền
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }
}
