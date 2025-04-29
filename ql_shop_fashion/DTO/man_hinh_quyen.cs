using System;

namespace DTO
{
    public class man_hinh_quyen
    {
        // Mã màn hình
        public int MaManHinh { get; set; }

        // Tên màn hình
        public string TenManHinh { get; set; }

        // Quyền: true nếu có quyền, false nếu không
        public bool CoQuyen { get; set; }

        // Không Quyền: giá trị ngược lại của "Có Quyền"
        public bool KhongQuyen
        {
            get => !CoQuyen; // Tự động lấy giá trị ngược
            set => CoQuyen = !value; // Khi đặt "Không Quyền", "Có Quyền" sẽ tự động ngược lại
        }

        // Constructor mặc định
        public man_hinh_quyen() { }

        // Constructor có tham số
        public man_hinh_quyen(int maManHinh, string tenManHinh, bool coQuyen)
        {
            MaManHinh = maManHinh;
            TenManHinh = tenManHinh;
            CoQuyen = coQuyen;
        }

        // Phương thức để đồng bộ dữ liệu nếu cần
        public void DongBoQuyen()
        {
            KhongQuyen = !CoQuyen;
        }
    }
}
