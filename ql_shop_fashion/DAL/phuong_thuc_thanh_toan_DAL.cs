using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class phuong_thuc_thanh_toan_DAL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        public phuong_thuc_thanh_toan_DAL()
        {

        }
        public IQueryable getDanhSanhPTTT()
        {
            var t = from i in data.phuong_thuc_thanh_toans
                       select new
                       {
                           i.ma_phuong_thuc,
                           i.ten_phuong_thuc,
                           i.mo_ta,
                           i.trang_thai
                       };

            return t;
        }
    }
}
