using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class nhom_quyen_sql_DAL
    {
        private QL_SHOP_DATADataContext data;
        public nhom_quyen_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }
        public List<string> load_ccb(string role)
        {
            if (role.Equals("Admin"))
            {
                // Nếu role là Admin, xuất tất cả các tên nhóm quyền
                var ds = from i in data.nhom_quyens select i.ten_nhom;
                return ds.ToList();
            }
            else
            {
                var ds = from i in data.nhom_quyens
                         where i.ten_nhom != "Admin" && i.ten_nhom != "Quản lí"
                         select i.ten_nhom;
                return ds.ToList();
            }
        }
        public List<nhom_quyen> get_list_nhomquyen()
        {
            var ds = from i in data.nhom_quyens select i;
            return ds.ToList();
        }
        public bool AddNhomQuyen(string tenNhomQuyen, string moTa)
        {
            try
            {
                var nhomQuyenMoi = new nhom_quyen
                {
                    ten_nhom = tenNhomQuyen,
                    mo_ta = moTa,

                };

                data.nhom_quyens.InsertOnSubmit(nhomQuyenMoi);
                data.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm nhóm quyền: {ex.Message}");
            }
        }
        public bool UpdateNhomQuyen(int idNhomQuyen, string tenNhomQuyen, string moTa)
        {
            try
            {
                var nhomQuyen = data.nhom_quyens.FirstOrDefault(nq => nq.id_nhom_quyen == idNhomQuyen);
                if (nhomQuyen != null)
                {
                    nhomQuyen.ten_nhom = tenNhomQuyen;
                    nhomQuyen.mo_ta = moTa;
                    nhomQuyen.update_at = DateTime.Now; // Cập nhật thời gian sửa đổi

                    data.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true; // Trả về true nếu cập nhật thành công
                }
                else
                {
                    return false; // Trả về false nếu không tìm thấy nhóm quyền
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật nhóm quyền: {ex.Message}");
            }
        }
        public bool DeleteNhomQuyen(int idNhomQuyen)
        {
            try
            {
                // Tìm nhóm quyền cần xóa
                var nhomQuyen = data.nhom_quyens.FirstOrDefault(nq => nq.id_nhom_quyen == idNhomQuyen);

                if (nhomQuyen != null)
                {
                    // Xóa tất cả các bản ghi liên quan (nếu cần)
                    var phanQuyenLienQuan = data.phan_quyens.Where(pq => pq.id_nhom_quyen == idNhomQuyen).ToList();
                    data.phan_quyens.DeleteAllOnSubmit(phanQuyenLienQuan);

                    // Xóa nhóm quyền
                    data.nhom_quyens.DeleteOnSubmit(nhomQuyen);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    data.SubmitChanges();
                    return true;
                }
                return false; // Trả về false nếu không tìm thấy nhóm quyền
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa nhóm quyền: {ex.Message}");
            }
        }





    }
}
