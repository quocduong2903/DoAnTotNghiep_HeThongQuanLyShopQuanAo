using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.ComponentModel;

namespace BLL
{
   public  class chi_tiet_hoa_don_BLL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        chi_tiet_hoa_don_DAL cthd = new chi_tiet_hoa_don_DAL();
        public chi_tiet_hoa_don_BLL()
        {

        }
        public bool ThemChiTietHoaDon(int maHD, int maSP, decimal giaBan, int soLuongMua)
        {
            return cthd.ThemChiTietHoaDon(maHD, maSP, giaBan, soLuongMua);
        }
        public IQueryable layChiTietHoaDon(int maHD)
        {
            return cthd.layChiTietHoaDon(maHD);
        }
        public BindingList<ChiTietHoaDon> layChiTietHoaDonB(int maHD)
        {
            return cthd.layChiTietHoaDonB(maHD);
        }
    }
}
