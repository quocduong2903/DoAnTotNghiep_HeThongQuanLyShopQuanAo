using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.XtraSplashScreen;

namespace GUI
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
       
        private tai_khoan_sql_BLL tk_bll;
        public frmDangNhap()
        {
            InitializeComponent();
           
        }

        private void LoadGifToPictureBox()
        {
            string filePath = @"background_dn.gif";
            if (File.Exists(filePath)) // Kiểm tra xem file có tồn tại không
            {
                background.Image = Image.FromFile(filePath);
                background.SizeMode = PictureBoxSizeMode.StretchImage; // Để ảnh lấp đầy PictureBox

                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 20;
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                this.Region = new Region(path);

                frmMain main = new frmMain();
                main.FormClosed += (s, args) => Application.Exit();
            }
            else
            {
                MessageBox.Show("Không tìm thấy file GIF!");
            }
        }


        private void frmDangNhap_Load(object sender, EventArgs e)
        {
           LoadGifToPictureBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }

        }

        private void dangnhap_Click(object sender, EventArgs e)
        {
            string tk = nhaptk.Text;
            string mk = nhapmk.Text; 


            int userRoleId;

            tk_bll = new tai_khoan_sql_BLL();
            
            // Kiểm tra tài khoản hợp lệ
            if (tk_bll.CheckLogin(tk, mk, out userRoleId))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Đăng nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                int id_nv = tk_bll.get_id_nv_by_tk(tk);
                // Hiển thị các màn hình mà người dùng có quyền truy cập
                CheckAccessAndDisplayScreens(userRoleId);
                Properties.Settings.Default.id_user_login = id_nv;
                Properties.Settings.Default.Save();
                // Ẩn form đăng nhập
                this.Hide();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckAccessAndDisplayScreens(int userRoleId)
        {
            // Khởi tạo BLL để lấy danh sách các màn hình mà người dùng có quyền truy cập
            var tk_bll = new tai_khoan_sql_BLL();

            // Lấy danh sách các màn hình được phép truy cập
            // Tạo biến tạm cho tên quyền
            string tempRoleName;

            // Gọi phương thức và gán kết quả vào biến tạm
            var accessibleScreens = tk_bll.GetAccessibleScreens(userRoleId, out tempRoleName);

            // Gán giá trị từ biến tạm vào thuộc tính name_role
            Properties.Settings.Default.name_role = tempRoleName;

            // Lưu lại thay đổi trong settings nếu cần
            Properties.Settings.Default.Save();

            // Kiểm tra danh sách các màn hình
            if (accessibleScreens == null || accessibleScreens.Count == 0)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào bất kỳ màn hình nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Xuất ra danh sách ID màn hình cho phép truy cập (dành cho mục đích debug, nếu cần)
            Console.WriteLine("Accessible Screens:");
            foreach (var screen in accessibleScreens)
            {
                Console.WriteLine($"Screen ID: {screen}");
            }

            // Tạo và hiển thị form chính với các màn hình được phép
            frmMain main = new frmMain();

            // Truyền danh sách các màn hình được phép vào form chính
            main.ShowScreens(accessibleScreens);

            // Xử lý sự kiện đóng form chính để đóng toàn bộ ứng dụng
            main.FormClosed += (s, args) => this.Close();
            main.Show();
        }


        private void taikhoan_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void nhapmk_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}