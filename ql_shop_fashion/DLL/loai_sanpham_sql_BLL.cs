using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class loai_sanpham_sql_BLL
    {
        private loai_sanpham_sql_DAL loaisp;
        public loai_sanpham_sql_BLL()
        {
            loaisp = new loai_sanpham_sql_DAL();
        }


        public List<loai_sanpham_DTO> get_all_loai_sp()
        {
            return loaisp.get_all_loai_sp();
        }

        public loai_san_pham getLoaiSPById(int maloaisp)
        {
            return loaisp.getLoaiSPById(maloaisp);
        }

        public nhom_loai getNhomLoaiByName(string tenNhomLoai)
        {
            return loaisp.getNhomLoaiByName(tenNhomLoai);
        }



        public bool AddLoaiSP(loai_san_pham newLoaiSP)
        {
            return loaisp.AddLoaiSP(newLoaiSP);
        }

        public bool UpdateLoaiSP(loai_san_pham updatedLoaiSP)
        {
            return loaisp.UpdateLoaiSP(updatedLoaiSP);
        }

        public bool DeleteLoaiSPById(int maloaisp)
        {
            return loaisp.DeleteLoaiSPById(maloaisp);
        }
    }
}
