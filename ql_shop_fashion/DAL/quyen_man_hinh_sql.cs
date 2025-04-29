using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class quyen_man_hinh_sql_DAL
    {
        private QL_SHOP_DATADataContext data;
        public quyen_man_hinh_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();

        }
        public List<man_hinh> get_list_man_hinh()
        {
            var names = from i in data.man_hinhs
                        select i;

            return names.ToList(); // Chuyển đổi sang List<string>
        }
        public List<man_hinh_quyen> GetDanhSachManHinhTheoNhomQuyen(int idNhomQuyen)
        {
            // Danh sách kết quả
            var danhSachManHinhQuyen = new List<man_hinh_quyen>();

            // Lấy danh sách tất cả các màn hình từ bảng `man_hinhs`
            var tatCaManHinh = data.man_hinhs
                                   .Select(m => new
                                   {
                                       MaManHinh = m.id_man_hinh,
                                       TenManHinh = m.ten_man_hinh
                                   })
                                   .Distinct() // Lấy duy nhất mỗi màn hình
                                   .ToList();

            // Lấy danh sách mã màn hình có quyền ứng với nhóm quyền (idNhomQuyen)
            var manHinhCoQuyen = data.phan_quyens
                                     .Where(nqm => nqm.id_nhom_quyen == idNhomQuyen && nqm.co_quyen == true)
                                     .Select(nqm => nqm.id_man_hinh)
                                     .ToList();

            // Duyệt tất cả màn hình và thêm vào danh sách kết quả
            foreach (var manHinh in tatCaManHinh)
            {
                danhSachManHinhQuyen.Add(new man_hinh_quyen
                {
                    MaManHinh = manHinh.MaManHinh,
                    TenManHinh = manHinh.TenManHinh, // Lấy tên màn hình
                    CoQuyen = manHinhCoQuyen.Contains(manHinh.MaManHinh) // True nếu có quyền, False nếu không
                });
            }

            return danhSachManHinhQuyen;
        }

        public void UpdateQuyen(int idNhomQuyen, int maManHinh, bool coQuyen)
        {
            try
            {
                // Tìm quyền cần cập nhật
                var quyen = data.phan_quyens.FirstOrDefault(pq => pq.id_nhom_quyen == idNhomQuyen && pq.id_man_hinh == maManHinh);

                if (quyen != null)
                {
                    // Cập nhật giá trị quyền
                    quyen.co_quyen = coQuyen;
                }
                else
                {
                    // Nếu chưa có, thêm mới
                    data.phan_quyens.InsertOnSubmit(new phan_quyen
                    {
                        id_nhom_quyen = idNhomQuyen,
                        id_man_hinh = maManHinh,
                        co_quyen = coQuyen
                    });
                }

                // Lưu thay đổi vào database
                data.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật quyền: {ex.Message}");
            }
        }
        // Thêm màn hình mới
        public int ThemManHinh(man_hinh manHinhMoi)
        {
            try
            {
                // Kiểm tra xem màn hình có tồn tại hay không
                var tonTai = data.man_hinhs.Any(mh => mh.ten_man_hinh == manHinhMoi.ten_man_hinh);
                if (tonTai)
                {
                    return 0; // Đã tồn tại
                }

                // Thêm màn hình mới
                data.man_hinhs.InsertOnSubmit(manHinhMoi);
                data.SubmitChanges();
                return 1; // Thành công
            }
            catch (Exception)
            {
                return -1; // Thất bại
            }
        }


        // Sửa thông tin màn hình
        public bool SuaManHinh(int idManHinh, string tenManHinhMoi)
        {
            try
            {
                // Tìm màn hình cần sửa
                var manHinh = data.man_hinhs.FirstOrDefault(mh => mh.id_man_hinh == idManHinh);
                if (manHinh != null)
                {
                    // Cập nhật thông tin màn hình
                    manHinh.ten_man_hinh = tenManHinhMoi;
                    data.SubmitChanges();
                    return true; // Thành công
                }
                return false; // Không tìm thấy màn hình
            }
            catch (Exception)
            {
                return false; // Thất bại
            }
        }

        // Xóa màn hình
        public bool XoaManHinh(int idManHinh)
        {
            try
            {
                // Tìm màn hình cần xóa
                var manHinh = data.man_hinhs.FirstOrDefault(mh => mh.id_man_hinh == idManHinh);
                if (manHinh != null)
                {
                    // Xóa các bản ghi liên quan trong bảng khác
                    var phanQuyens = data.phan_quyens.Where(pq => pq.id_man_hinh == idManHinh).ToList();
                    if (phanQuyens.Count > 0)
                    {
                        data.phan_quyens.DeleteAllOnSubmit(phanQuyens);
                    }

                    // Xóa màn hình
                    data.man_hinhs.DeleteOnSubmit(manHinh);

                    // Lưu thay đổi
                    data.SubmitChanges();
                    return true; // Thành công
                }

                return false; // Không tìm thấy màn hình
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa màn hình: {ex.Message}");
                return false; // Thất bại
            }
        }







    }
}
