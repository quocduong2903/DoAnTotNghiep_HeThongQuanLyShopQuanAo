using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class san_pham_sql_BLL
    {
        private san_pham_sql_DAL sp_;
        public san_pham_sql_BLL()
        {
            sp_ = new san_pham_sql_DAL();
        }
        public int get_id_sp_by_name(string name)
        {
            return sp_.get_id_sp_by_name(name);
        }
        public List<string> get_sp_all_name()
        {
            return sp_.get_all_sp_name();
        }
        public string get_name_by_id(int id)
        {
            return sp_.get_name_by_id(id);
        }
        public List<san_pham_custom> get_all_sp()
        {
            return sp_.get_all_sp();
        }

        public List<san_pham> GetAllSanPham()
        {
            return sp_.GetAllSanPham();
        }

	public List<san_pham_custom> get_all_sp_custom()
        {
            return sp_.get_all_sp_custom();
        }


        public List<san_pham_DTO> get_all_sp_dk(int masanpham)
        {
            return sp_.get_all_sp_dk(masanpham);
        }


        public san_pham GetProductDetailsById(int maSanPham)
        {
            return sp_.GetProductDetailsById(maSanPham);
        }

        public List<san_pham_DTO> get_all_sp_DTO()
        {
            return sp_.get_all_sp_DTO();
        }

        public bool UpdateThumbnail(int maSanPham, string thumbnailPath)
        {
            return sp_.UpdateThumbnail(maSanPham, thumbnailPath);
        }



        public bool SaveProducts(san_pham_DTO product)
        {
            return sp_.SaveProducts(product);
        }

        public bool AddSP(san_pham newLoaiSP)
        {
            return sp_.AddSP(newLoaiSP);
        }

        public bool DeleteSPById(int masp)
        {
            return sp_.DeleteSPById(masp);
        }

        public List<string> GetAllImagesByProductId(int maSanPham)
        {
            return sp_.GetAllImagesByProductId(maSanPham);
        }

        public bool AddImageForProduct(int maSanPham, string imagePath)
        {
            return sp_.AddImageForProduct(maSanPham, imagePath);
        }
        public List<san_pham_cus> GetSanPhamTheoTieuChi(string tieuChi)
        {
            return sp_.GetSanPhamTheoTieuChi(tieuChi);
        }

    }
}
