using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class mau_sac_sql_BLL
    {
        private mau_sac_sql_DAL mausac;
        public mau_sac_sql_BLL()
        {
            mausac = new mau_sac_sql_DAL();
        }


        public List<mau_sac_DTO> get_all_mau_sac()
        {
            return mausac.get_all_mau_sac();
        }

        public mau_sac getMauSacById(int mamausac)
        {
            return mausac.getMauSacById(mamausac);
        }

        public bool AddMS(mau_sac newMS)
        {
            return mausac.AddMS(newMS);
        }

        public bool UpdateMS(mau_sac updatedMS)
        {
            return mausac.UpdateMS(updatedMS);
        }


        public bool DeleteMSById(int mamausac)
        {
            return mausac.DeleteMSById(mamausac);
        }
    }
}
