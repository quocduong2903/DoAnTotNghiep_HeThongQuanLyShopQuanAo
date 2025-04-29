using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class nhom_loai_sql_BLL
    {
        private nhom_loai_sql_DAL nhomloai;
        public nhom_loai_sql_BLL()
        {
            nhomloai = new nhom_loai_sql_DAL();
        }


        public List<nhom_loai_DTO> get_all_nhom_loai()
        {
            return nhomloai.get_all_nhom_loai();
        }

        public nhom_loai getNhomLoaiById(int manhomloai)
        {
            return nhomloai.getNhomLoaiById(manhomloai);
        }


        public bool AddNL(nhom_loai newNL)
        {
            return nhomloai.AddNL(newNL);
        }

        public bool UpdateNL(nhom_loai updatedNL)
        {
            return nhomloai.UpdateNL(updatedNL);
        }

        public bool DeleteNLById(int manhomloai)
        {
            return nhomloai.DeleteNLById(manhomloai);
        }
    }
}
