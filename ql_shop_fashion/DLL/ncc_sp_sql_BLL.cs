using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ncc_sp_sql_BLL
    {
        private nha_cung_cap_sp_sql_DAL sp;
        public ncc_sp_sql_BLL()
        {
            sp = new nha_cung_cap_sp_sql_DAL();
        }
        public IQueryable<dynamic> get_nccsp_by_id_sp(int id)
        {
            return sp.get_nccsp_by_id_sp(id);
        }
        public List<string> get_list_sp_by_id(int id)
        {
            return sp.get_list_sp_by_id(id);
        }
        public List<string> get_list_name_ncc_id_sp(int id)
        {
            return sp.get_list_name_ncc_id_sp(id);
        }
        public List<nha_cung_cap_san_pham> get_sp_nccsp_by_id(int id)
        {
            return sp.get_sp_nccsp_by_id(id);
        }
        public bool SaveProducts(List<nha_cung_cap_san_pham> productList)
        {
            return sp.SaveProducts(productList);
        }
        public bool UpdateGiaNhap(int maNhaCungCap, int maSanPham, decimal giaNhapMoi)
        {
            return sp.UpdateGiaNhap(maNhaCungCap, maSanPham, giaNhapMoi);
        }
        public bool DeleteNccSpById(int maNhaCungCap, int maSanPham)
        {
            return sp.DeleteNccSpById(maNhaCungCap, maSanPham);
        }    

    }
}
