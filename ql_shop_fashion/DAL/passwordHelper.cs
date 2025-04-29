using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;


namespace DAL
{
    public class passwordHelper
    {
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Sử dụng BCrypt để xác thực mật khẩu
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public static string HashPassword(string password)
        {
            // Tạo hash mật khẩu với độ phức tạp (work factor) mặc định
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }

}
