using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class hoa_don
    {
        public int ma_hoa_don { get; set; } // Mã hóa đơn
        public int? ma_khach_hang { get; set; } // Mã khách hàng
        public int? ma_nhan_vien { get; set; } // Mã nhân viên
        public DateTime ngay_lap { get; set; } = DateTime.Now; // Ngày lập
        public int? ma_khuyen_mai { get; set; } // Mã khuyến mãi
        public string trang_thai_giao_hang { get; set; } // Trạng thái giao hàng
        public int? ma_phuong_thuc { get; set; } // Mã phương thức thanh toán
        public int tong_so_luong_mua { get; set; } // Tổng số lượng mua
        public DateTime? ngay_doi_tra { get; set; } // Ngày đổi trả
        public decimal tien_giam { get; set; } = 0; // Tiền giảm
        public decimal tong_gia_tri { get; set; } // Tổng giá trị
        public decimal? tong_tien_sau_khi_doi { get; set; } // Tổng tiền sau khi đổi
        public decimal tong_don_hang { get; set; } // Tổng đơn hàng
        public bool hinh_thuc_ban { get; set; } = false; // Hình thức bán
        public DateTime created_at { get; set; } = DateTime.Now; // Thời gian tạo
        public DateTime updated_at { get; set; } = DateTime.Now; // Thời gian cập nhật
    }

}
