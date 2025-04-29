namespace GUI
{
    public partial class HoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public decimal tienKhachTra;
        public HoaDon()
        {
            InitializeComponent();
        }

        public decimal TienKhachTra { get => tienKhachTra; set => tienKhachTra = value; }
    }

}
