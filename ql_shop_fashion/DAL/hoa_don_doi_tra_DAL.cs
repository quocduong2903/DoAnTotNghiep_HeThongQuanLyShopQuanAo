using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class hoa_don_doi_tra_DAL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        public hoa_don_doi_tra_DAL()
        {

        }
        public int ThemHoaDonDoiTra(string maHD, int maNhanVien, int maPhuongThuc, DateTime date)
        {
            // Chuỗi kết nối


            // Khởi tạo DataContext với chuỗi kết nối (kết nối vẫn mở)
            var data = new QL_SHOP_DATADataContext();

            var newHoaDon = new hoa_don_doi_tra
            {
                ma_nhan_vien = maNhanVien,
                ma_phuong_thuc = maPhuongThuc,
                ma_hoa_don = int.Parse(maHD),
                ngay_doi_tra = date
            };

            try
            {
                data.hoa_don_doi_tras.InsertOnSubmit(newHoaDon);

                data.SubmitChanges();
                return int.Parse(maHD);
            }

            catch (System.Data.SqlClient.SqlException sqlEx)
            {

                if (sqlEx.Number == 199)
                {
                    // Ném ngoại lệ với thông báo lỗi để truyền qua GUI
                    throw new Exception("Hóa đơn đã quá 7 ngày không được đổi trả!!");
                }
                else if (sqlEx.Number == 29)
                {
                    // Ném ngoại lệ với thông báo lỗi để truyền qua GUI
                    throw new Exception("Hóa đơn không đủ điều kiện đổi trả vì đã áp dụng khuyến mãi!!");
                }
                else if (sqlEx.Number == 18)
                {
                    // Ném ngoại lệ với thông báo lỗi để truyền qua GUI
                    throw new Exception("Hóa đơn này đã được đổi trả, không thể thực hiện thêm lần nữa!!");
                }
                else if (sqlEx.Number == 211)
                {
                    // Ném ngoại lệ với thông báo lỗi để truyền qua GUI
                    throw new Exception("Hóa đơn không được đổi trả vì không thanh toán bằng tiền mặt!");
                }
                else
                {
                    // Ném lỗi khác
                    throw new Exception("Đã xảy ra lỗi khi thêm hóa đơn: " + sqlEx.Message);
                }
                return -1;
            }
        }

        public object LayThongTinHoaDon(string maHD)
        {
            var ttsp = (from hd in data.hoa_dons
                        where hd.ma_hoa_don == int.Parse(maHD)
                        select new
                        {
                            hd.ma_hoa_don,
                            hd.ma_khach_hang,
                            hd.ngay_lap,
                            hd.ma_nhan_vien,
                            hd.tong_gia_tri,
                            hd.tien_doi_diem
                        }).FirstOrDefault();

            return ttsp;
        }
        //}
        //public int ThemHoaDonDoiTra(string maHD, int maNhanVien, int maPhuongThuc, DateTime date)
        //{
        //    var newHoaDon = new hoa_don_doi_tra
        //    {
        //        ma_nhan_vien = maNhanVien,
        //        ma_phuong_thuc = maPhuongThuc,
        //        ma_hoa_don = int.Parse(maHD),
        //        ngay_doi_tra = date
        //    };

        //    try
        //    {
        //        data.hoa_don_doi_tras.InsertOnSubmit(newHoaDon);

        //        // Sử dụng TransactionScope để quản lý giao dịch
        //        using (var transaction = new System.Transactions.TransactionScope())
        //        {
        //            data.SubmitChanges();
        //            transaction.Complete(); // Xác nhận hoàn tất giao dịch nếu không có lỗi
        //            return int.Parse(maHD);
        //        }
        //    }
        //    catch (System.Data.SqlClient.SqlException sqlEx)
        //    {

        //        if (sqlEx.Number == 179)
        //        {
        //            throw new Exception("Hóa đơn đã quá 7 ngày không được đổi trả!");
        //            data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, data.hoa_don_doi_tras);
        //        }
        //        else if (sqlEx.Number == 29)
        //        {
        //            throw new Exception("Hóa đơn không đủ điều kiện đổi trả vì đã áp dụng khuyến mãi!");
        //            data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, data.hoa_don_doi_tras);
        //        }
        //        else if (sqlEx.Number == 18)
        //        {
        //            throw new Exception("Hóa đơn này đã được đổi trả, không thể thực hiện thêm lần nữa!");
        //        }
        //        else
        //        {
        //            throw new Exception("Đã xảy ra lỗi khi thêm hóa đơn: " + sqlEx.Message);
        //            data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, data.hoa_don_doi_tras);
        //        }
        //    }
        //    return -1;
        //}


   

          
    }
}
