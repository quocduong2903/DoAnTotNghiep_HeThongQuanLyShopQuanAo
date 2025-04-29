using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class nhap_hang_sql_BLL
    {
        nhap_hang_sql_DAL data;
        public nhap_hang_sql_BLL()
        {
            data = new nhap_hang_sql_DAL();
        }
        public IQueryable get_all_nhap_hang()
        {
            return data.get_all_nhap_hang();
        }
        public IQueryable<dynamic> get_nhap_hang_by_id(int id)
        {
            return data.get_nhap_hang_by_id(id);
        }
        public bool nhap_hang_add(nhap_hang s, List<chi_tiet_nhap_hang> a)
        {
            return data.nhap_hang_add(s,a);
        }
        public bool update_tt_ht(int id)

        {
            return data.update_tt_ht(id);
        }
        public IQueryable get_nhap_hang_by_trang_thai(string trangThai)
        {
            return data.get_nhap_hang_by_trang_thai(trangThai);
        }
        public bool cap_nhat_trang_thai(int maNhapHang, string trangThaiMoi)
        {
            return data.cap_nhat_trang_thai(maNhapHang, trangThaiMoi);
        }    
    }
}
