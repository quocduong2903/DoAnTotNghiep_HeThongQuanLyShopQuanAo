using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class phuong_thuc_thanh_toan_BLL
    {
        QL_SHOP_DATADataContext data = new QL_SHOP_DATADataContext();
        phuong_thuc_thanh_toan_DAL pttt_DAL = new phuong_thuc_thanh_toan_DAL();

        public phuong_thuc_thanh_toan_BLL()
        {

        }

        public IQueryable getDanhSanhPTTT()
        {
            return pttt_DAL.getDanhSanhPTTT();
        }
    }
}
