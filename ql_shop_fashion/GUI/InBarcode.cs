using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace GUI
{
    public partial class InBarcode : DevExpress.XtraReports.UI.XtraReport
    {
        public InBarcode()
        {
            InitializeComponent();
            xrTenSP.DataBindings.Add("Text", this.DataSource, "TenSP");
            xrMaSP.DataBindings.Add("Text", this.DataSource, "MaSP");
 
            xrGiaBan.DataBindings.Add("Text", this.DataSource, "GiaBan");
            xrGiaGiam.DataBindings.Add("Text", this.DataSource, "GiaGiam");
        }

    }
}
