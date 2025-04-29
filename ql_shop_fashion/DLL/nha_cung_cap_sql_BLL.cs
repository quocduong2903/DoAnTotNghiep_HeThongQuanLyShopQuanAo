using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
   public  class nha_cung_cap_sql_BLL
    {
        nha_cung_cap_sql_DAL ncc;
        public nha_cung_cap_sql_BLL()
        {
            ncc = new nha_cung_cap_sql_DAL();
        }
        public List<string> get_ncc_list_name()
        {
            return ncc.get_name_list_ncc();
        }
        public int get_id_ncc(string name)
        {
            return ncc.get_id_ncc(name);
        }
        public string get_name_by_id(int id)
        {
            return ncc.get_name_by_id(id);
        }
        public List<nha_cung_cap> get_all_ncc()
        {
            return ncc.get_all_ncc();
        }
        public bool AddNewNcc(nha_cung_cap nccs)
        {
            return ncc.AddNewNcc(nccs.ten_nha_cung_cap, nccs.dia_chi, nccs.dien_thoai);
        }
        public bool UpdateNcc(nha_cung_cap updatedNcc)
        {
            return ncc.UpdateNcc(updatedNcc);
        }
        public bool DeleteNcc(int maNcc)
        {
            return ncc.DeleteNcc(maNcc);
        }
    }
}
