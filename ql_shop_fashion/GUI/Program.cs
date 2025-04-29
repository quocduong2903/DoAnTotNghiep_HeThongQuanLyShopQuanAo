using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isConfigured = false;

            while (!isConfigured)
            {
                try
                {
                    // Tải chuỗi kết nối từ JSON
                    DTO.DatabaseConfig.LoadConnectionString();
                    isConfigured = true; // Nếu thành công, đánh dấu đã cấu hình xong
                }
                catch (Exception ex)
                {
                    // Thông báo lỗi cấu hình
                    MessageBox.Show(ex.Message, "Cấu hình kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Hiển thị form thiết lập kết nối
                    using (frm_knoi frm = new frm_knoi())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // Sau khi lưu, thử kết nối lại
                            MessageBox.Show("Cấu hình thành công! Hệ thống sẽ thử kết nối lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ứng dụng cần cấu hình kết nối để chạy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Thoát ứng dụng nếu người dùng không muốn cấu hình
                        }
                    }
                }
                
            }

          if(isConfigured)
            {
                Application.Run(new frmDangNhap());
            }

        }
    }
}
