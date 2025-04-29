using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class thong_ke_sql_BLL
    {
        private thong_ke_sql_DAL thongKeDAL;

        public thong_ke_sql_BLL()
        {
            thongKeDAL = new thong_ke_sql_DAL();
        }



        public List<thong_ke_ban_hang_DTO> ThongKeTheoNgay(DateTime ngay)
        {
            return thongKeDAL.GetBanHangTheoNgay(ngay);
        }

        public List<thong_ke_theo_thang_DTO> ThongKeTheoThang(int nam)
        {
            return thongKeDAL.GetBanHangTheoThang(nam); // Gọi DAL để lấy dữ liệu theo tháng
        }


        public List<thong_ke_theo_nam_DTO> ThongKeTheoNam(int startYear, int endYear)
        {
            return thongKeDAL.GetBanHangTheoNam(startYear, endYear);
        }

        public List<thong_ke_doi_tra_DTO> ThongKeDoiTraTheoNgay(DateTime ngay)
        {
            return thongKeDAL.GetDoiTraTheoNgay(ngay);
        }

        public List<thong_ke_doi_tra_thang_DTO> ThongKeDoiTraTheoThang(int nam, int thang)
        {
            return thongKeDAL.GetDoiTraTheoThang(nam, thang);
        }


        public List<thong_ke_doi_tra_nam_DTO> ThongKeDoiTraTheoNam(int startYear, int endYear)
        {
            return thongKeDAL.GetDoiTraTheoNam(startYear, endYear);
        }

        public List<thong_ke_nhap_hang_theo_thang_DTO> GetThongKeNhapHangTheoThang(int thang, int nam)
        {
            return thongKeDAL.GetThongKeNhapHangTheoThang(thang, nam);
        }

        public List<thong_ke_nhap_hang_theo_nam_DTO> GetThongKeNhapHangTheoNam(int startYear, int endYear)
        {
            return thongKeDAL.GetThongKeNhapHangTheoNam(startYear, endYear);
        }

    }
}
