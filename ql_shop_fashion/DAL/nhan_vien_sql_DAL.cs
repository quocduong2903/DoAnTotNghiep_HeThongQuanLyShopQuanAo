using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class nhan_vien_sql_DAL
    {
        private QL_SHOP_DATADataContext data;

        public nhan_vien_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }

        public bool add_nv_tk_user(nhan_vien a, string tenNhomQuyen)
        {
            try
            {
                // 1. Thêm nhân viên vào bảng nhan_vien
                data.nhan_viens.InsertOnSubmit(a);
                data.SubmitChanges();

                // Lấy ID của nhân viên vừa thêm (được tự động tạo trong cơ sở dữ liệu)
                int maNhanVien = a.ma_nhan_vien;

                // 2. Tạo tên đăng nhập và mật khẩu tự động cho nhân viên
                string tenDangNhap = $"user" + a.ma_nhan_vien;

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(tenDangNhap);

                // 3. Tạo tài khoản cho nhân viên trong bảng tai_khoan
                var taiKhoan = new tai_khoan
                {
                    ten_dang_nhap = tenDangNhap,
                    mat_khau_hash = hashedPassword,
                    hoat_dong = true,
                    is_oauth = false
                };
                data.tai_khoans.InsertOnSubmit(taiKhoan);
                data.SubmitChanges();

                // Lấy ID của tài khoản vừa thêm
                int idTaiKhoan = taiKhoan.tai_khoan_id;

                // 4. Gán tài khoản với nhân viên
                a.tai_khoan_id = idTaiKhoan;
                data.SubmitChanges();

                // 5. Lấy ID của nhóm quyền dựa trên tên nhóm quyền
                var nhomQuyen = data.nhom_quyens.FirstOrDefault(nq => nq.ten_nhom == tenNhomQuyen);
                if (nhomQuyen == null)
                {
                    throw new Exception("Tên nhóm quyền không tồn tại.");
                }

                int idNhomQuyen = nhomQuyen.id_nhom_quyen;

                // 6. Gán quyền cho tài khoản trong bảng tai_khoan_nhom_quyen
                var taiKhoanNhomQuyen = new tai_khoan_nhom_quyen
                {
                    tai_khoan_id = idTaiKhoan,
                    id_nhom_quyen = idNhomQuyen,
                    create_at = DateTime.Now
                };
                data.tai_khoan_nhom_quyens.InsertOnSubmit(taiKhoanNhomQuyen);
                data.SubmitChanges();

                return true; // Thêm thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Lỗi khi thêm nhân viên và tài khoản: {ex.Message}");
                return false; // Thêm thất bại
            }
        }
        public List<nhan_vien> GetNhanVienTheoQuyen(string quyen)
        {
            try
            {
                if (quyen.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    // Nếu là Admin, trả về tất cả nhân viên
                    return data.nhan_viens.ToList();
                }
                else
                {
                    // Nếu không phải Admin, chỉ trả về nhân viên không có chức vụ "Admin" hoặc "Quản lý"
                    return data.nhan_viens
                        .Where(nv => nv.chuc_vu != "Admin" && nv.chuc_vu != "Quản lý")
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
                return new List<nhan_vien>(); // Trả về danh sách rỗng nếu xảy ra lỗi
            }
        }
        public bool UpdateNhanVien(nhan_vien updatedNhanVien)
        {
            try
            {
                // Tìm nhân viên trong cơ sở dữ liệu theo ID
                var existingNhanVien = data.nhan_viens.FirstOrDefault(nv => nv.ma_nhan_vien == updatedNhanVien.ma_nhan_vien);
                if (existingNhanVien == null)
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }

                // Cập nhật các thuộc tính
                existingNhanVien.ten_nhan_vien = updatedNhanVien.ten_nhan_vien;
                existingNhanVien.chuc_vu = updatedNhanVien.chuc_vu;
                existingNhanVien.sdt = updatedNhanVien.sdt;
                existingNhanVien.dia_chi = updatedNhanVien.dia_chi;
                existingNhanVien.ngay_vao_lam = updatedNhanVien.ngay_vao_lam;

                // Lưu thay đổi vào cơ sở dữ liệu
                data.SubmitChanges();

                return true; // Cập nhật thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Lỗi khi cập nhật thông tin nhân viên: {ex.Message}");
                return false; // Cập nhật thất bại
            }
        }
        public bool DeleteNhanVien(int maNhanVien)
        {
            try
            {
                // Tìm nhân viên theo ID
                var nhanVien = data.nhan_viens.FirstOrDefault(nv => nv.ma_nhan_vien == maNhanVien);
                if (nhanVien == null)
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }

                // Lấy tài khoản liên kết với nhân viên (nếu có)
                var taiKhoan = data.tai_khoans.FirstOrDefault(tk => tk.tai_khoan_id == nhanVien.tai_khoan_id);
                if (taiKhoan != null)
                {
                    // Xóa tất cả nhóm quyền liên quan đến tài khoản
                    var taiKhoanNhomQuyens = data.tai_khoan_nhom_quyens.Where(tknq => tknq.tai_khoan_id == taiKhoan.tai_khoan_id).ToList();
                    data.tai_khoan_nhom_quyens.DeleteAllOnSubmit(taiKhoanNhomQuyens);

                    // Xóa tài khoản
                    data.tai_khoans.DeleteOnSubmit(taiKhoan);
                }

                // Xóa nhân viên
                data.nhan_viens.DeleteOnSubmit(nhanVien);

                // Lưu thay đổi
                data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa nhân viên: {ex.Message}");
                return false;
            }
        }
        public string get_name_nv_by_id(int id)
        {
            // Sử dụng LINQ để tìm nhân viên có mã nhân viên khớp
            var name = data.nhan_viens
                           .Where(i => i.ma_nhan_vien == id) // Lọc theo mã nhân viên
                           .Select(i => i.ten_nhan_vien) // Chọn tên nhân viên
                           .FirstOrDefault(); // Lấy giá trị đầu tiên hoặc null nếu không tìm thấy

            return name; // Trả về tên nhân viên hoặc null
        }
        public nhan_vien GetNhanVienByMaNV(int maNhanVien)
        {
            try
            {
                // Sử dụng LINQ để tìm nhân viên theo mã nhân viên
                var nhanVien = data.nhan_viens.FirstOrDefault(nv => nv.ma_nhan_vien == maNhanVien);

                if (nhanVien == null)
                {
                    throw new Exception($"Không tìm thấy nhân viên với mã: {maNhanVien}");
                }

                return nhanVien; // Trả về nhân viên tìm được
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin nhân viên: {ex.Message}");
                return null; // Trả về null nếu xảy ra lỗi
            }
        }



    }

}
