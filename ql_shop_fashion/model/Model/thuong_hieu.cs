using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_shop_fashion.Model
{
    public class thuong_hieu
    {
        // Thuộc tính mã thương hiệu
        public int ma_thuong_hieu { get; set; }

        // Thuộc tính tên thương hiệu
        public string ten_thuong_hieu { get; set; }

        // Thuộc tính mô tả thương hiệu
        public string mo_ta { get; set; }

        // Thuộc tính hình ảnh thumbnail
        public string thumbnail_image { get; set; }

        // Thuộc tính thời gian tạo
        public DateTime created_at { get; set; } = DateTime.Now;

        // Thuộc tính thời gian cập nhật
        public DateTime updated_at { get; set; } = DateTime.Now;
    }

}
