using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class nhom_quyen_man_hinh_sql_BLL
    {
        private quyen_man_hinh_sql_DAL quyen_dal;
        public nhom_quyen_man_hinh_sql_BLL()
        {
            quyen_dal = new quyen_man_hinh_sql_DAL();
        }
        public List<man_hinh> get_list_man_hinh()
        {
            return quyen_dal.get_list_man_hinh();
        }
        public List<man_hinh_quyen> GetDanhSachManHinhTheoNhomQuyen(int idNhomQuyen)
        {
            return quyen_dal.GetDanhSachManHinhTheoNhomQuyen(idNhomQuyen);
        }
        public void UpdateDanhSachManHinhTheoNhomQuyen(int idNhomQuyen, List<man_hinh_quyen> danhSachQuyen)
        {
            try
            {
                foreach (var quyen in danhSachQuyen)
                {
                    quyen_dal.UpdateQuyen(idNhomQuyen, quyen.MaManHinh, quyen.CoQuyen);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật danh sách quyền: {ex.Message}");
            }
        }
        public int them_manHinh(man_hinh ma)
        {
            return quyen_dal.ThemManHinh(ma);
        }
        public bool sua_manhinh(int ma, string name)
        {
            return quyen_dal.SuaManHinh(ma, name);
        }
        public bool xoa_manHinh(int ma)
        {
            return quyen_dal.XoaManHinh(ma);
        }

    }
}
