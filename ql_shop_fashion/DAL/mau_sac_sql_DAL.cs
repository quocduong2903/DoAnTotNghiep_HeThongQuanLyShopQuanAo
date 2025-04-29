using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class mau_sac_sql_DAL
    {
        private QL_SHOP_DATADataContext data;
        public mau_sac_sql_DAL()
        {
            data = new QL_SHOP_DATADataContext();
        }

        public List<mau_sac_DTO> get_all_mau_sac()
        {
            var ds = from i in data.mau_sacs
                     select new mau_sac_DTO
                     {
                         ma_mau_sac = i.ma_mau_sac,
                         ten_mau_sac = i.ten_mau_sac,
                         phu_phi_mau_sac = i.phu_phi_mausac
                     };
            return ds.ToList();
        }

        public mau_sac getMauSacById(int mamausac)
        {
            return data.mau_sacs.FirstOrDefault(p => p.ma_mau_sac == mamausac);
        }

        public bool AddMS(mau_sac newMS)
        {
            try
            {
                data.mau_sacs.InsertOnSubmit(newMS);
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateMS(mau_sac updatedMS)
        {
            try
            {
                var size = data.mau_sacs.SingleOrDefault(k => k.ma_mau_sac == updatedMS.ma_mau_sac);
                if (size != null)
                {
                    size.ten_mau_sac = updatedMS.ten_mau_sac;
                    size.phu_phi_mausac = updatedMS.phu_phi_mausac;
                    data.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteMSById(int mamausac)
        {
            try
            {
                // Tìm màu sắc theo ma_mau_sac
                var mausac = data.mau_sacs
                    .FirstOrDefault(p => p.ma_mau_sac == mamausac);

                if (mausac != null)
                {
                    data.mau_sacs.DeleteOnSubmit(mausac);
                    data.SubmitChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy màu sắc với mã màu sắc đã cho.");
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
