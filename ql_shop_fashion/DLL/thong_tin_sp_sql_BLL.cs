using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class thong_tin_sp_sql_BLL
    {
        private thong_tin_sp_sql_DAL thongtin;
        public thong_tin_sp_sql_BLL()
        {
            thongtin = new thong_tin_sp_sql_DAL();
        }


        public List<thong_tin_sanpham_DTO> get_all_ttsp()
        {
            return thongtin.get_all_ttsp();
        }


        public List<thong_tin_sanpham_DTO> getThongTinSanPhamTableByMaSP(int mathuoctinh)
        {
            return thongtin.getThongTinSanPhamByMaSP(mathuoctinh);
        }

        public thong_tin_sanpham_DTO getThongTinSanPhamByMaTT(int maThongTin)
        {
            return thongtin.getThongTinSanPhamByMaTT(maThongTin);
        }

        public int getNextMaThongTin()
        {
            return thongtin.getNextMaThongTin();
        }



        public bool addThongTinSanPham(thong_tin_sanpham_DTO tt)
        {
            return thongtin.addThongTinSanPham(tt);
        }

        public bool updateThongTinSanPham(thong_tin_sanpham_DTO tt)
        {
            return thongtin.updateThongTinSanPham(tt);
        }

        public bool deleteThongTinSanPham(int maThongTin)
        {
            return thongtin.deleteThongTinSanPham(maThongTin);
        }


    }
}
