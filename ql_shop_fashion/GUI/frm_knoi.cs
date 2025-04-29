using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_knoi : Form
    {
        public string ConnectionString { get; private set; }

        public frm_knoi()
        {
            InitializeComponent();
            btnLuu.Click += BtnLuu_Click;
            btnThoat.Click += BtnThoat_Click;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string serverName = txtServerName.Text.Trim();
            string databaseName = txtDatabaseName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool useIntegratedSecurity = chkIntegratedSecurity.Checked;

            if (string.IsNullOrEmpty(serverName) || string.IsNullOrEmpty(databaseName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo chuỗi kết nối
            string connectionString;
            if (useIntegratedSecurity)
            {
                connectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;";
            }
            else
            {
                connectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={username};Password={password};";
            }

            // Lưu chuỗi kết nối vào JSON
            try
            {
                DTO.DatabaseConfig.SaveConnectionString(connectionString);
                MessageBox.Show("Lưu cấu hình kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
        }
    }
}
