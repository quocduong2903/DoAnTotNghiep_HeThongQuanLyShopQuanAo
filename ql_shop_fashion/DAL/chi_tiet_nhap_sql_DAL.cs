using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    
    public class chi_tiet_nhap_sql_DAL
    {
        QL_SHOP_DATADataContext data;
        public chi_tiet_nhap_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }
        public IQueryable get_sp_by_phieu_nhap(int id)
        {
            var dssp = from i in data.chi_tiet_nhap_hangs join k in data.san_phams on i.ma_san_pham equals k.ma_san_pham where i.ma_nhap_hang == id select new { 
                k.ten_san_pham,i.so_luong,i.gia_nhap
            };
            return dssp;
        }
        public List<string> get_list_sp_by_id(int id)
        {
            var dssp = from i in data.chi_tiet_nhap_hangs
                       join k in data.san_phams on i.ma_san_pham equals k.ma_san_pham
                       where i.ma_nhap_hang == id
                       select k.ten_san_pham; 

            return dssp.ToList(); 
        }
        public List<chi_tiet_nhap_hang> get_ct_list_by_id(int id)
        {
            var dssp = (from i in data.chi_tiet_nhap_hangs
                        where i.ma_nhap_hang == id
                        select i).AsEnumerable()  // Chuyển đổi thành Enumerable để không gặp vấn đề về Entity
                        .Select(x => new chi_tiet_nhap_hang
                        {
                            ma_nhap_hang = x.ma_nhap_hang,
                            ma_san_pham = x.ma_san_pham,
                            so_luong = x.so_luong,
                            gia_nhap = x.gia_nhap,
                            trang_thai = "Chưa duyệt"
                        }).ToList();

            return dssp; // Trả về List<chi_tiet_nhap_hang>
        }




    }
}
