using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{

    public class khuyen_mai_sql_BLL
    {


        private khuyen_mai_sql_DAL km_dal;


        public khuyen_mai_sql_BLL()
        {
            km_dal = new khuyen_mai_sql_DAL();
        }

        public IQueryable get_all_khuyen_mai()
        {
            return km_dal.get_all_khuyen_mai();
        }

        public IQueryable getKhuyenMai()
        {

            return km_dal.getKhuyenMai();
        }

        public List<khuyen_mai> GetKhuyeMaiTest()
        {
            return km_dal.GetKhuyeMaiTest();
        }

        public IQueryable GetKhuyenMaiCoNhanVien()
        {
            return km_dal.GetKhuyenMaiCoNhanVien();
        }

        public bool ThenKhuyenMai(khuyen_mai km)
        {
            return km_dal.ThenKhuyenMai(km);

        }

        public bool kiemTraTrungCode(string code)
        {
            return km_dal.kiemTraTrungCode(code);
        }

        public bool xoaKhuyenMai(int ma)
        {

            return km_dal.xoaKhuyenMai(ma);
        }

        public bool suaKhuyenMai(khuyen_mai km)
        {

            return km_dal.suaKhuyenMai(km);
        }
    }
}
