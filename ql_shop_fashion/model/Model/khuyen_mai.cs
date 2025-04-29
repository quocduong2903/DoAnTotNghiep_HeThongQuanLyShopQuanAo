using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class khuyen_mai
    {
        public int ma_khuyen_mai { get; set; } // Mã khuyến mãi
        public string code { get; set; } // Mã khuyến mãi
        public decimal gia_tri { get; set; } // Giá trị khuyến mãi
        public DateTime? thoi_gian_bat_dau { get; set; } // Thời gian bắt đầu
        public DateTime? thoi_gian_ket_thuc { get; set; } // Thời gian kết thúc
        public int? so_luong_toi_da { get; set; } // Số lượng tối đa
        public int so_luong_da_dung { get; set; } = 0; // Số lượng đã dùng
        public string tinh_trang { get; set; } // Tình trạng
        public string ghi_chu { get; set; } // Ghi chú
        public decimal gia_tri_hoa_don_toi_thieu { get; set; } // Giá trị hóa đơn tối thiểu áp dụng
        public int? ma_nhan_vien { get; set; } // Mã nhân viên tạo
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
