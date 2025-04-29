using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frm_QR_TT : Form
    {
        private qr_bll qr_bll;
        private string noidungtt;
        private double sotien;
        public delegate void SukienHandler();
        public event SukienHandler sukien_tt;

        public frm_QR_TT(string noidung, double sotien)
        {

           
            InitializeComponent();
            this.noidungtt = noidung;
            this.sotien = sotien;
            bt_tt.Click += Bt_tt_Click;
            this.Load += Frm_QR_TT_Load;
        }

        private void Frm_QR_TT_Load(object sender, EventArgs e)
        {
            qr_bll = new qr_bll();
            pictureBox1.Image = qr_bll.qr_out(noidungtt, sotien);
        }

        private void Bt_tt_Click(object sender, EventArgs e)
        {
          
            sukien_tt?.Invoke();
            this.Close();
        }
    }
}
