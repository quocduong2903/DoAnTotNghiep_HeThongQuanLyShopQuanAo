using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class khach_hang_sql_BLL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        khach_hang_sql_DAL kh_DAL = new khach_hang_sql_DAL();
        public khach_hang_sql_BLL()
        {

        }
        public IQueryable getDanhSanhKH()
        {
            return kh_DAL.getDanhSanhKH();
        }
        public IQueryable getDanhSanhKHFull()
        {
            return kh_DAL.getDanhSanhKHFull();
        }
        public bool ThemKhachHang(khach_hang kh)
        {
            return kh_DAL.ThemKhachHang(kh);
        }

        public bool xoaKhachHang(int ma)
        {
            return kh_DAL.xoaKhachHang(ma);
        }

        public bool suaKhachHang(khach_hang kh)
        {

            return kh_DAL.suaKhachHang(kh);
        }
    }
}
