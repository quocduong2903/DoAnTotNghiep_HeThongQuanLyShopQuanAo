using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Drawing;

namespace BLL
{
    public class qr_bll
    {
        private qr_sql_DAL qr;
        public qr_bll()
        {
            qr = new qr_sql_DAL();
        }
        public Image qr_out(string noidung, double sotien)
        {
            return qr.qr_out(noidung,sotien);
        }
    }
}
