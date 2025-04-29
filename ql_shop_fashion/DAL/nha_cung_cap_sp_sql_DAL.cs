using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DTO;

namespace DAL
{
    public class nha_cung_cap_sp_sql_DAL
    {
        QL_SHOP_DATADataContext data;
        public nha_cung_cap_sp_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }
        public IQueryable<dynamic> get_nccsp_by_id_sp(int id)
        {
            var ds = from i in data.nha_cung_cap_san_phams join k in data.nha_cung_caps on i.ma_nha_cung_cap equals k.ma_nha_cung_cap join ii in data.san_phams on i.ma_san_pham equals ii.ma_san_pham where i.ma_san_pham == id select new { k.ten_nha_cung_cap, ii.ten_san_pham, i.gia_cung_cap };
            return ds;
        }
        public List<string> get_list_sp_by_id(int id)
        {
            var dssp = from i in data.nha_cung_cap_san_phams
                       join k in data.san_phams on i.ma_san_pham equals k.ma_san_pham
                       where i.ma_nha_cung_cap == id
                       select k.ten_san_pham;

            return dssp.ToList();
        }
        public List<string> get_list_name_ncc_id_sp(int id)
        {
            var dssp = from i in data.nha_cung_cap_san_phams
                       join k in data.san_phams on i.ma_san_pham equals k.ma_san_pham
                       join ii in data.nha_cung_caps on i.ma_nha_cung_cap equals ii.ma_nha_cung_cap
                       where i.ma_san_pham == id
                       select ii.ten_nha_cung_cap;

            return dssp.ToList();
        }
        public List<nha_cung_cap_san_pham> get_sp_nccsp_by_id(int id)
        {
            // Truy vấn dữ liệu dưới dạng kiểu ẩn danh trước
            var dssp = (from i in data.nha_cung_cap_san_phams
                        join k in data.san_phams on i.ma_san_pham equals k.ma_san_pham
                        where i.ma_nha_cung_cap == id
                        select new
                        {
                            ma_nha_cung_cap = i.ma_nha_cung_cap,
                            ma_san_pham = i.ma_san_pham,
                            ten_san_pham = k.ten_san_pham,
                            gia_cung_cap = i.gia_cung_cap
                        }).AsEnumerable() // Chuyển về dạng IEnumerable để xử lý phía client
                          .Select(x => new nha_cung_cap_san_pham
                          {
                              ma_nha_cung_cap = x.ma_nha_cung_cap,
                              ma_san_pham = x.ma_san_pham,
                              ten_san_pham = x.ten_san_pham,
                              gia_cung_cap = x.gia_cung_cap
                          }).ToList();

            return dssp; // Trả về List<nha_cung_cap_san_pham>
        }
        public bool SaveProducts(List<nha_cung_cap_san_pham> productList)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    foreach (var product in productList)
                    {
                        // Kiểm tra xem sản phẩm đã tồn tại chưa
                        var existingProduct = data.nha_cung_cap_san_phams
                            .FirstOrDefault(p => p.ma_san_pham == product.ma_san_pham && p.ma_nha_cung_cap == product.ma_nha_cung_cap);

                        if (existingProduct != null)
                        {
                            // Nếu tồn tại, cập nhật sản phẩm
                            existingProduct.ten_san_pham = product.ten_san_pham;
                            existingProduct.gia_cung_cap = product.gia_cung_cap;
                        }
                        else
                        {
                            // Nếu chưa tồn tại, thêm sản phẩm mới
                            data.nha_cung_cap_san_phams.InsertOnSubmit(product);
                        }
                    }

                    // Thực hiện lưu tất cả thay đổi vào cơ sở dữ liệu
                    data.SubmitChanges();

                    // Cam kết transaction
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, TransactionScope sẽ tự động rollback
                    Console.WriteLine("Lỗi trong quá trình lưu dữ liệu: " + ex.Message);
                    return false;
                }
            }
        }
        public bool UpdateGiaNhap(int maNhaCungCap, int maSanPham, decimal giaNhapMoi)
        {
            try
            {
                // Tìm sản phẩm theo ma_nha_cung_cap và ma_san_pham
                var sanPham = data.nha_cung_cap_san_phams
                    .FirstOrDefault(p => p.ma_nha_cung_cap == maNhaCungCap && p.ma_san_pham == maSanPham);

                if (sanPham != null)
                {
                    // Nếu sản phẩm tồn tại, cập nhật gia_nhap
                    sanPham.gia_cung_cap = giaNhapMoi;
                    data.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true;
                }
                else
                {
                    // Nếu không tìm thấy sản phẩm
                    Console.WriteLine("Không tìm thấy sản phẩm với mã nhà cung cấp và mã sản phẩm đã cho.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                Console.WriteLine("Lỗi trong quá trình cập nhật giá nhập: " + ex.Message);
                return false;
            }
        }

        public bool DeleteNccSpById(int maNhaCungCap, int maSanPham)
        {
            try
            {
                // Tìm sản phẩm theo ma_nha_cung_cap và ma_san_pham
                var sanPham = data.nha_cung_cap_san_phams
                    .FirstOrDefault(p => p.ma_nha_cung_cap == maNhaCungCap && p.ma_san_pham == maSanPham);

                if (sanPham != null)
                {
                    // Nếu sản phẩm tồn tại, xóa sản phẩm
                    data.nha_cung_cap_san_phams.DeleteOnSubmit(sanPham);
                    data.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true;
                }
                else
                {
                    // Nếu không tìm thấy sản phẩm
                    Console.WriteLine("Không tìm thấy sản phẩm với mã nhà cung cấp và mã sản phẩm đã cho.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                Console.WriteLine("Lỗi trong quá trình xóa sản phẩm: " + ex.Message);
                return false;
            }
        }


    }
}
