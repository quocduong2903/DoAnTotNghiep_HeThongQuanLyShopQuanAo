using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class chi_tiet_nhap_sql_BLL
    {
        chi_tiet_nhap_sql_DAL dl;
        public chi_tiet_nhap_sql_BLL()
        {
            dl = new chi_tiet_nhap_sql_DAL();
        }
        public IQueryable get_sp_by_phieu_nhap(int id)
        {
            return dl.get_sp_by_phieu_nhap(id);
        }
        public List<string> get_list_sp_by_id(int id)
        {
            return dl.get_list_sp_by_id(id);
        }
        public List<chi_tiet_nhap_hang> get_ct_list_by_id(int id)
        {
            return dl.get_ct_list_by_id(id);
        }



    }
}
