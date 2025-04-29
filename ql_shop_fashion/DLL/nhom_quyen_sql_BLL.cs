using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class nhom_quyen_sql_BLL
    {
        private nhom_quyen_sql_DAL quyen_dal;
        public nhom_quyen_sql_BLL()
        {
            quyen_dal = new nhom_quyen_sql_DAL();

        }
        public List<string> load_ccb(string role)
        {
            return quyen_dal.load_ccb(role);
        }
        public List<nhom_quyen> get_list_nhomquyen()
        {
            return quyen_dal.get_list_nhomquyen();
        }
        public bool AddNhomQuyen(string tenNhomQuyen, string moTa)
        {
            return quyen_dal.AddNhomQuyen(tenNhomQuyen, moTa);
        }
        public bool UpdateNhomQuyen(int idNhomQuyen, string tenNhomQuyen, string moTa)
        {
            return quyen_dal.UpdateNhomQuyen(idNhomQuyen, tenNhomQuyen, moTa);
        }
        public bool DeleteNhomQuyen(int idNhomQuyen)
        {
            try
            {
                return quyen_dal.DeleteNhomQuyen(idNhomQuyen);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa nhóm quyền: {ex.Message}");
            }
        }


    }
}
