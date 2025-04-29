using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
   public class hoa_don_doi_tra_BLL
    {
        hoa_don_doi_tra_DAL doitra_DAL = new hoa_don_doi_tra_DAL();
        public hoa_don_doi_tra_BLL()
        {

        }

        public int ThemHoaDonDoiTra(string maHD, int maNhanVien, int maPhuongThuc, DateTime date)
        {
            return doitra_DAL.ThemHoaDonDoiTra(maHD, maNhanVien, maPhuongThuc, date);
        }

        public object LayThongTinHoaDon(string maHD)
        {
            return doitra_DAL.LayThongTinHoaDon(maHD);
        }



    }
}
