using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace GUI
{
    public partial class QuetMa : Form
    {
        // Sự kiện để truyền mã được quét về form chính
        public event EventHandler<string> NumberSubmitted;

        private FilterInfoCollection filter; // Danh sách thiết bị video
        private VideoCaptureDevice captureDevice; // Thiết bị đang hoạt động

        public QuetMa()
        {
            InitializeComponent();
            this.Load += QuetMa_Load;
            this.FormClosing += QuetMa_FormClosing1;
        }

        private void QuetMa_FormClosing1(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        private void QuetMa_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách thiết bị video
                filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (filter.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thiết bị video nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Thêm các thiết bị vào ComboBox
                foreach (FilterInfo filterInfo in filter)
                {
                    cboCam.Items.Add(filterInfo.Name);
                }

                cboCam.SelectedIndex = 0; // Mặc định chọn thiết bị đầu tiên
                StartCamera(); // Bắt đầu camera
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void StartCamera()
        {
            try
            {
                // Thiết lập camera theo lựa chọn trong ComboBox
                captureDevice = new VideoCaptureDevice(filter[cboCam.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể khởi động camera: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopCamera()
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }
        private void CaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                // Tạo ảnh bitmap từ khung hình của camera
                Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

                // Điều chỉnh kích thước của ảnh sao cho phù hợp với kích thước của PictureBox
                Bitmap resizedFrame = new Bitmap(frame, picHinh.ClientSize);

                // Gán ảnh đã điều chỉnh kích thước vào PictureBox
                picHinh.Image = resizedFrame;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý khung hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picHinh.Image != null)
            {
                try
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result result = barcodeReader.Decode((Bitmap)picHinh.Image);

                    if (result != null)
                    {
                        
                        timer1.Stop();
                        StopCamera();

                        // Kích hoạt sự kiện truyền mã
                        NumberSubmitted?.Invoke(this, result.Text);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi quét mã: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void QuetMa_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera(); // Dừng camera khi đóng form
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StopCamera(); // Dừng camera hiện tại
            StartCamera(); // Khởi động camera mới theo lựa chọn
        }
    }
}
