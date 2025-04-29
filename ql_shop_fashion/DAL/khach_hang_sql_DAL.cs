using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
     public class khach_hang_sql_DAL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        public khach_hang_sql_DAL()
        {

        }
        public IQueryable getDanhSanhKH()
        {
            var ttkh = from kh in data.khach_hangs
                       select new
                       {
                           kh.ma_khach_hang,
                           kh.ten_khach_hang,
                           kh.dien_thoai,
                           kh.diem_thuong
                       };

            return ttkh;
        }

        public IQueryable getDanhSanhKHFull()
        {
            var ttkh = from kh in data.khach_hangs
                       select new
                       {
                           kh.ma_khach_hang,
                           kh.ten_khach_hang,
                           kh.dia_chi,
                           kh.dien_thoai,
                           kh.diem_thuong,
                           kh.diem_da_doi,
                           kh.tai_khoan_id
                       };

            return ttkh;
        }


        public bool ThemKhachHang(khach_hang kh)
        {
            try
            {
                data.khach_hangs.InsertOnSubmit(kh);
                data.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }


        public bool xoaKhachHang(int ma)
        {
           khach_hang Xoa = data.khach_hangs.Where(d => d.ma_khach_hang == ma).FirstOrDefault();
            if (Xoa != null)
            {
                try
                {
                    data.khach_hangs.DeleteOnSubmit(Xoa);
                    data.SubmitChanges();
                }
                catch (SqlException sqlEX)
                {
                    throw new Exception("Không được xóa khách hàng này");
                }

                return true;
            }
            return false;
        }

        public bool suaKhachHang(khach_hang kh)
        {

            khach_hang Sua = data.khach_hangs.Where(d => d.ma_khach_hang == kh.ma_khach_hang).FirstOrDefault();
            if (Sua != null)
            {
                Sua.ten_khach_hang = kh.ten_khach_hang;
                Sua.tai_khoan_id = kh.tai_khoan_id;
                Sua.dien_thoai = kh.dien_thoai;
                Sua.dia_chi = kh.dia_chi;
                //Sua.diem_thuong = kh.diem_thuong;
                //Sua.diem_da_doi = kh.diem_da_doi;
                data.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
