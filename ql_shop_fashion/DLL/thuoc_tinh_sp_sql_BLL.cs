using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{

    public class thuoc_tinh_sp_sql_BLL
    {
        private thuoc_tinh_sp_sql_DAL sp;
  
        public thuoc_tinh_sp_sql_BLL()
        {
            sp = new thuoc_tinh_sp_sql_DAL();
           

        }
        public IQueryable<product> get_all_ttsp_by_id(int id)
        {
            return sp.get_all_ttsp_by_id(id);
        }
        public bool updated_tt_sp(List<thuoc_tinh_san_pham> ttsp)
        {
            return sp.updated_tt_sp(ttsp);
        }


        /// </summary>
        /// <param name="tenSP"></param>
        /// <returns></returns>
        public IQueryable getKichThuocBangTenSanPham(string tenSP)
        {
            return sp.getKichThuocBangTenSanPham(tenSP);
        }

        public IQueryable getMausacBangTenSanPham(int maSP)
        {
            return sp.getMausacBangTenSanPham(maSP);
        }

        public IQueryable getMauSacTheoKichThuoc(string maKichThuoc, string maTT)
        {
            return sp.getMauSacTheoKichThuoc(maKichThuoc, maTT);
        }

        public int getSoLuongTon_MaThuocTinh(string maTT)
        {
            return sp.getSoLuongTon_MaThuocTinh(maTT);
        }

        public CTHD get_tt_SanPham_CTHD(string ma)
        {
            return sp.get_tt_SanPham_CTHD(ma);
        }

        public List<tem_gia> Get_SP_INGIA()
        {
            return sp.Get_SP_INGIA();
        }
        public IQueryable get_all_tt_SanPham()
        {
            return sp.get_all_tt_SanPham();
        }
	
	    public List<thuoc_tinh_DTO> get_all_ttsp_by_id_DTO(int masanpham)
        {
            return sp.get_all_ttsp_by_id_DTO(masanpham);
        }

        public List<thuoc_tinh_DTO> GetAllProducts()
        {
            return sp.GetAllProducts();
        }

        public bool addThuocTinhSanPham(thuoc_tinh_san_pham tt)
        {
            return sp.addThuocTinhSanPham(tt);
        }

        public bool updateThuocTinhSanPham(thuoc_tinh_DTO tt)
        {
            return sp.updateThuocTinhSanPham(tt); // Gọi tầng DAL
        }


        public bool deleteThuocTinhSanPham(int maThuocTinh)
        {
            return sp.deleteThuocTinhSanPham(maThuocTinh); // Gọi tầng DAL
        }


    }
}
