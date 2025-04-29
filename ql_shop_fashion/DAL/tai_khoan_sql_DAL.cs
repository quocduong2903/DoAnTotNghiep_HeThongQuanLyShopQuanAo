using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BCrypt.Net;

namespace DAL
{
    public class tai_khoan_sql_DAL
    {
        QL_SHOP_DATADataContext data;
        passwordHelper passwordHelper;
        public tai_khoan_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
            passwordHelper = new passwordHelper();
        }
        public bool CheckLogin(string tk, string mk, out int userRoleId)
        {
            // Tìm tài khoản theo tên đăng nhập
            var user = data.tai_khoans.FirstOrDefault(u => u.ten_dang_nhap == tk);

            // Kiểm tra nếu tài khoản tồn tại và đang hoạt động
            if (user != null && user.hoat_dong == true)
            {
                // Kiểm tra mật khẩu nhập vào có khớp với hash mật khẩu đã lưu hay không
                bool isPasswordCorrect = passwordHelper.VerifyPassword(mk, user.mat_khau_hash);



                if (isPasswordCorrect)
                {
                    // Lấy id_nhom_quyen từ bảng tai_khoan_nhom_quyen
                    var userGroup = data.tai_khoan_nhom_quyens
                        .FirstOrDefault(ug => ug.tai_khoan_id == user.tai_khoan_id);

                    // Gán id_nhom_quyen cho userRoleId hoặc 0 nếu không tìm thấy
                    userRoleId = userGroup?.id_nhom_quyen ?? 0;
                    return true; // Đăng nhập thành công
                }
            }

            userRoleId = 0; // Gán 0 nếu không tìm thấy tài khoản hoặc mật khẩu không đúng
            return false; // Trả về false nếu tài khoản không hợp lệ hoặc mật khẩu sai
        }
        // Phương thức lấy danh sách màn hình mà người dùng có quyền truy cập
        public List<int> GetAccessibleScreens(int userRoleId, out string name)
        {
            // Lấy tên nhóm quyền từ cơ sở dữ liệu
            var roleName = data.nhom_quyens
                .Where(nq => nq.id_nhom_quyen == userRoleId)
                .Select(nq => nq.ten_nhom)
                .FirstOrDefault();

            // Gán tên nhóm quyền vào tham số out
            name = roleName;

            if (roleName == "Admin")
            {
                // Nếu là Admin, có quyền truy cập tất cả các màn hình
                return data.man_hinhs.Select(m => m.id_man_hinh).ToList();
            }
            else
            {
                // Nếu không phải Admin, chỉ có quyền truy cập các màn hình được cấp phép
                return data.phan_quyens
                    .Where(p => p.id_nhom_quyen == userRoleId && p.co_quyen == true)
                    .Select(p => p.id_man_hinh)
                    .ToList();
            }
        }


        public int get_id_nv_by_tk(string nametk)
        {
            var id = (from i in data.tai_khoans
                      join k in data.nhan_viens on i.tai_khoan_id equals k.tai_khoan_id
                      where i.ten_dang_nhap == nametk
                      select k.ma_nhan_vien).FirstOrDefault();

            return id;
        }
        public tai_khoan GetTaiKhoanByMaNhanVien(int id)
        {
            // Tìm tài khoản dựa vào mã nhân viên
            var taiKhoan = (from tk in data.tai_khoans
                            where tk.tai_khoan_id == id

                            select tk).FirstOrDefault();

            return taiKhoan; // Trả về đối tượng tài khoản nếu tìm thấy, ngược lại trả về null
        }

        public bool ChangePassword(string userId, string newPassword)
        {
            try
            {
                // Tìm tài khoản theo ID
                var user = data.tai_khoans.FirstOrDefault(u => u.ten_dang_nhap == userId);

                // Kiểm tra nếu tài khoản tồn tại
                if (user == null)
                {
                    throw new Exception("Tài khoản không tồn tại.");
                }

                // Hash mật khẩu mới
                string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                // Cập nhật mật khẩu trong cơ sở dữ liệu
                user.mat_khau_hash = hashedNewPassword;

                // Lưu thay đổi
                data.SubmitChanges();

                return true; // Đổi mật khẩu thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đổi mật khẩu: {ex.Message}");
                return false; // Đổi mật khẩu thất bại
            }
        }
        public List<tai_khoan> GetTaiKhoanByRole(string role)
        {
            try
            {
                if (role == "Admin")
                {
                    // Trả về toàn bộ tài khoản nếu role là Admin
                    return data.tai_khoans.ToList();
                }
                else
                {
                    // Trả về tài khoản có nhóm quyền không phải "Admin" hoặc "Quản Lí"
                    var excludedRoles = new List<string> { "Admin", "Quản Lí" };

                    return (from tk in data.tai_khoans
                            join tknq in data.tai_khoan_nhom_quyens on tk.tai_khoan_id equals tknq.tai_khoan_id
                            join nq in data.nhom_quyens on tknq.id_nhom_quyen equals nq.id_nhom_quyen
                            where !excludedRoles.Contains(nq.ten_nhom) // Lọc quyền không phải "Admin" hoặc "Quản Lí"
                            select tk).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách tài khoản: {ex.Message}");
                return new List<tai_khoan>(); // Trả về danh sách rỗng nếu lỗi
            }
        }


        public string GetRoleNameByAccountId(int accountId)
        {
            try
            {
                // Tìm quyền dựa vào id tài khoản
                var roleName = (from tk in data.tai_khoans
                                join tknq in data.tai_khoan_nhom_quyens on tk.tai_khoan_id equals tknq.tai_khoan_id
                                join nq in data.nhom_quyens on tknq.id_nhom_quyen equals nq.id_nhom_quyen
                                where tk.tai_khoan_id == accountId
                                select nq.ten_nhom).FirstOrDefault();

                // Trả về tên quyền, nếu không tìm thấy trả về chuỗi rỗng
                return roleName ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy tên quyền: {ex.Message}");
                return string.Empty;
            }
        }
        public bool UpdateRole(int accountId, string roleName)
        {
            try
            {
                // Tìm tài khoản theo ID
                var account = data.tai_khoans.FirstOrDefault(tk => tk.tai_khoan_id == accountId);
                if (account == null)
                {
                    throw new Exception("Tài khoản không tồn tại.");
                }

                // Tìm nhóm quyền theo tên quyền
                var role = data.nhom_quyens.FirstOrDefault(nq => nq.ten_nhom == roleName);
                if (role == null)
                {
                    throw new Exception("Tên quyền không hợp lệ.");
                }

                // Tìm bản ghi liên kết giữa tài khoản và nhóm quyền
                var accountRole = data.tai_khoan_nhom_quyens.FirstOrDefault(ar => ar.tai_khoan_id == accountId);
                if (accountRole != null)
                {
                    // Cập nhật nhóm quyền mới
                    accountRole.id_nhom_quyen = role.id_nhom_quyen;
                }
                else
                {
                    // Nếu chưa có nhóm quyền, thêm mới
                    data.tai_khoan_nhom_quyens.InsertOnSubmit(new tai_khoan_nhom_quyen
                    {
                        tai_khoan_id = accountId,
                        id_nhom_quyen = role.id_nhom_quyen,
                        create_at = DateTime.Now
                    });
                }

                // Lưu thay đổi
                data.SubmitChanges();

                return true; // Cập nhật thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật quyền: {ex.Message}");
                return false; // Cập nhật thất bại
            }
        }


    }

}
