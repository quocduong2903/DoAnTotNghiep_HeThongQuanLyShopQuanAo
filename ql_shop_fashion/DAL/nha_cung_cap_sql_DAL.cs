using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
   public  class nha_cung_cap_sql_DAL
    {
        QL_SHOP_DATADataContext ncc;
        public nha_cung_cap_sql_DAL()
        {
            ncc = new QL_SHOP_DATADataContext();
        }
        public List<string> get_name_list_ncc()
        {
            var ds = from i in ncc.nha_cung_caps
                     select i.ten_nha_cung_cap;

            return ds.ToList();
        }
        public int get_id_ncc(string name)
        {
            var ds = from i in ncc.nha_cung_caps where i.ten_nha_cung_cap == name
                     select i.ma_nha_cung_cap;

            return ds.FirstOrDefault();
        }
        public string get_name_by_id(int id)
        {
            var ds = from i in ncc.nha_cung_caps
                     where i.ma_nha_cung_cap == id
                     select i.ten_nha_cung_cap;

            return ds.FirstOrDefault();
        }
        public List<nha_cung_cap> get_all_ncc()
        {
            // Truy vấn dữ liệu dưới dạng kiểu ẩn danh trước
            var dsncc = from i in ncc.nha_cung_caps
                        select new
                        {
                            i.ma_nha_cung_cap,
                            i.ten_nha_cung_cap,
                            i.dia_chi,
                            i.dien_thoai
                        };

            // Chuyển đổi từ kiểu ẩn danh sang danh sách các đối tượng `nha_cung_cap`
            var result = dsncc.AsEnumerable()
                              .Select(i => new nha_cung_cap
                              {
                                  ma_nha_cung_cap = i.ma_nha_cung_cap,
                                  ten_nha_cung_cap = i.ten_nha_cung_cap,
                                  dia_chi = i.dia_chi,
                                  dien_thoai = i.dien_thoai
                              }).ToList();

            return result;
        }

        public bool AddNewNcc(string tenNhaCungCap, string diaChi, string dienThoai)
        {
            try
            {
                // Tạo đối tượng nha_cung_cap mới
                nha_cung_cap newNcc = new nha_cung_cap
                {
                    ten_nha_cung_cap = tenNhaCungCap,
                    dia_chi = diaChi,
                    dien_thoai = dienThoai
                };

                // Thêm đối tượng vào bảng nha_cung_caps
                ncc.nha_cung_caps.InsertOnSubmit(newNcc);

                // Lưu thay đổi vào cơ sở dữ liệu
                ncc.SubmitChanges();

                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi nếu có
                Console.WriteLine("Lỗi khi thêm nhà cung cấp: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
        public bool UpdateNcc(nha_cung_cap updatedNcc)
        {
            try
            {
                // Tìm nhà cung cấp theo ma_nha_cung_cap
                var existingNcc = ncc.nha_cung_caps.FirstOrDefault(x => x.ma_nha_cung_cap == updatedNcc.ma_nha_cung_cap);

                if (existingNcc == null)
                {
                    // Nếu không tìm thấy nhà cung cấp, trả về false
                    Console.WriteLine("Nhà cung cấp không tồn tại.");
                    return false;
                }

                // Cập nhật thông tin nhà cung cấp
                existingNcc.ten_nha_cung_cap = updatedNcc.ten_nha_cung_cap;
                existingNcc.dia_chi = updatedNcc.dia_chi;
                existingNcc.dien_thoai = updatedNcc.dien_thoai;

                // Lưu thay đổi vào cơ sở dữ liệu
                ncc.SubmitChanges();

                return true; // Trả về true nếu sửa thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có lỗi xảy ra
                Console.WriteLine("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
        public bool DeleteNcc(int maNcc)
        {
            try
            {
                // Tìm nhà cung cấp theo ma_nha_cung_cap
                var nccToDelete = ncc.nha_cung_caps.FirstOrDefault(x => x.ma_nha_cung_cap == maNcc);

                if (nccToDelete == null)
                {
                    // Nếu không tìm thấy nhà cung cấp, trả về false
                    Console.WriteLine("Nhà cung cấp không tồn tại.");
                    return false;
                }

                // Xóa nhà cung cấp khỏi cơ sở dữ liệu
                ncc.nha_cung_caps.DeleteOnSubmit(nccToDelete);

                // Lưu thay đổi vào cơ sở dữ liệu
                ncc.SubmitChanges();

                return true; // Trả về true nếu xóa thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có lỗi xảy ra
                Console.WriteLine("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }


    }
}
