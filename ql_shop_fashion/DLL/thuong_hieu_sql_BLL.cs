using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class thuong_hieu_sql_BLL
    {
        private thuong_hieu_sql_DAL thuonghieu;
        public thuong_hieu_sql_BLL()
        {
            thuonghieu = new thuong_hieu_sql_DAL();
        }


        public List<thuong_hieu_DTO> get_all_thuong_hieu()
        {
            return thuonghieu.get_all_thuong_hieu();
        }

        public thuong_hieu getThuongHieucById(int mathuonghieu)
        {
            return thuonghieu.getThuongHieuById(mathuonghieu);
        }


        public bool AddTH(thuong_hieu newTH)
        {
            return thuonghieu.AddTH(newTH);
        }

        public bool UpdateTH(thuong_hieu updatedTH)
        {
            return thuonghieu.UpdateTH(updatedTH);
        }

        public bool DeleteTHById(int mathuongieu)
        {
            return thuonghieu.DeleteTHById(mathuongieu);
        }
    }
}
