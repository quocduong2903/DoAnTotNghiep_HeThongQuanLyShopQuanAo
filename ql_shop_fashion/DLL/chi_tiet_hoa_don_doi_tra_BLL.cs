using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
   public class chi_tiet_hoa_don_doi_tra_BLL
    {
        chi_tiet_hoa_don_doi_tra_DAL doitra_DAL = new chi_tiet_hoa_don_doi_tra_DAL();
        public chi_tiet_hoa_don_doi_tra_BLL()
        {

        }
        public bool ThemChiTietHoaDonDoiTra(int maHD, int maSP, string trangThai, decimal giaBan, int soLuongMua)
        {
            return doitra_DAL.ThemChiTietHoaDonDoiTra(maHD,maSP,trangThai,giaBan,soLuongMua);

        }




    }
}
