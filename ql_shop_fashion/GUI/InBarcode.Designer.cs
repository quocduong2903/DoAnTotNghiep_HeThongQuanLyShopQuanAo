
namespace GUI
{
    partial class InBarcode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrGiaGiam = new DevExpress.XtraReports.UI.XRLabel();
            this.xrGiaBan = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTenSP = new DevExpress.XtraReports.UI.XRLabel();
            this.xrMaSP = new DevExpress.XtraReports.UI.XRBarCode();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrGiaGiam,
            this.xrGiaBan,
            this.xrTenSP,
            this.xrMaSP});
            this.Detail.HeightF = 218F;
            this.Detail.MultiColumn.ColumnWidth = 200F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            // 
            // xrGiaGiam
            // 
            this.xrGiaGiam.LocationFloat = new DevExpress.Utils.PointFloat(0F, 128.5F);
            this.xrGiaGiam.Multiline = true;
            this.xrGiaGiam.Name = "xrGiaGiam";
            this.xrGiaGiam.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrGiaGiam.SizeF = new System.Drawing.SizeF(188.3333F, 23F);
            this.xrGiaGiam.StylePriority.UseTextAlignment = false;
            this.xrGiaGiam.Text = "xrGiaGiam";
            this.xrGiaGiam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrGiaGiam.TextFormatString = "Giảm còn: {0}";
            // 
            // xrGiaBan
            // 
            this.xrGiaBan.LocationFloat = new DevExpress.Utils.PointFloat(0F, 105.5F);
            this.xrGiaBan.Multiline = true;
            this.xrGiaBan.Name = "xrGiaBan";
            this.xrGiaBan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrGiaBan.SizeF = new System.Drawing.SizeF(188.3333F, 22.99999F);
            this.xrGiaBan.StylePriority.UseTextAlignment = false;
            this.xrGiaBan.Text = "xrGiaBan";
            this.xrGiaBan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrGiaBan.TextFormatString = "Giá bán: {0}";
            // 
            // xrTenSP
            // 
            this.xrTenSP.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTenSP.Multiline = true;
            this.xrTenSP.Name = "xrTenSP";
            this.xrTenSP.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTenSP.SizeF = new System.Drawing.SizeF(188.3333F, 30.50001F);
            this.xrTenSP.StylePriority.UseTextAlignment = false;
            this.xrTenSP.Text = "xrTenSP";
            this.xrTenSP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrMaSP
            // 
            this.xrMaSP.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30.50001F);
            this.xrMaSP.Name = "xrMaSP";
            this.xrMaSP.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrMaSP.SizeF = new System.Drawing.SizeF(188.3333F, 75F);
            this.xrMaSP.StylePriority.UseTextAlignment = false;
            this.xrMaSP.Symbology = code128Generator1;
            this.xrMaSP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // InBarcode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrTenSP;
        private DevExpress.XtraReports.UI.XRBarCode xrMaSP;
        private DevExpress.XtraReports.UI.XRLabel xrGiaGiam;
        private DevExpress.XtraReports.UI.XRLabel xrGiaBan;
    }
}
