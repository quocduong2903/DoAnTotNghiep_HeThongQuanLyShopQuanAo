using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using VietQRHelper;

namespace DAL
{
    public class qr_sql_DAL
    {
        public qr_sql_DAL()
        {

        }
        public Image qr_out(string noidung, double sotien)
        {
            try
            {
                // Kiểm tra số tiền hợp lệ
                if (sotien <= 0)
                {
                    throw new ArgumentException("Số tiền phải lớn hơn 0.");
                }

                // Tạo nội dung mã QR
                var qrPay = QRPay.InitVietQR(
                    bankBin: BankApp.BanksObject[BankKey.VIETINBANK].bin,
                    bankNumber: "109875084193", // Số tài khoản
                    amount: sotien.ToString("F0"), // Số tiền
                    purpose: noidung // Nội dung chuyển tiền
                );
                var content = qrPay.Build();

                // Tạo mã QR từ nội dung
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20); // Tạo mã QR

                        // Điều chỉnh kích thước mã QR về 384x323
                        Bitmap resizedQR = new Bitmap(qrCodeImage, new Size(384, 323));

                        // Trả về ảnh (Image) mã QR
                        return resizedQR;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu cần) và trả về null
                MessageBox.Show($"Đã xảy ra lỗi khi tạo mã QR: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }


}
