using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class size_sql_BLL
    {
        private size_sql_DAL size;
        public size_sql_BLL()
        {
            size = new size_sql_DAL();
        }


        public List<kich_thuoc_DTO> get_all_size()
        {
            return size.get_all_size();
        }

        public kich_thuoc getSizeById(int makichthuoc)
        {
            return size.getSizeById(makichthuoc);
        }

        public bool AddSize(kich_thuoc newSize)
        {
            return size.AddSize(newSize);
        }

        public bool UpdateSize(kich_thuoc updatedSize)
        {
            return size.UpdateSize(updatedSize);
        }




        public bool DeleteSizeById(int makichthuoc)
        {
            return size.DeleteSizeById(makichthuoc);
        }

    }
}
