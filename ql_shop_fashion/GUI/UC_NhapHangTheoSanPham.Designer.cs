
namespace GUI
{
    partial class UC_NhapHangTheoSanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_NhapHangTheoSanPham));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.themsp = new DevExpress.XtraBars.BarButtonItem();
            this.suasp = new DevExpress.XtraBars.BarButtonItem();
            this.xoasp = new DevExpress.XtraBars.BarButtonItem();
            this.nhaphangsp = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txt_tenncc = new DevExpress.XtraEditors.TextEdit();
            this.timkiemsanphamcuancc = new DevExpress.XtraEditors.LabelControl();
            this.txt_timkiemsanphamcuancc = new DevExpress.XtraEditors.TextEdit();
            this.timkiemncc = new DevExpress.XtraEditors.LabelControl();
            this.dgv_ncc = new System.Windows.Forms.DataGridView();
            this.dgv_sanphamcuancc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tenncc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_timkiemsanphamcuancc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ncc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanphamcuancc)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.themsp,
            this.suasp,
            this.xoasp,
            this.nhaphangsp});
            this.barManager1.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.themsp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.suasp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.xoasp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.nhaphangsp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // themsp
            // 
            this.themsp.Caption = "Thêm";
            this.themsp.Id = 0;
            this.themsp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("themsp.ImageOptions.Image")));
            this.themsp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("themsp.ImageOptions.LargeImage")));
            this.themsp.Name = "themsp";
            // 
            // suasp
            // 
            this.suasp.Caption = "Sửa";
            this.suasp.Id = 1;
            this.suasp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("suasp.ImageOptions.Image")));
            this.suasp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("suasp.ImageOptions.LargeImage")));
            this.suasp.Name = "suasp";
            // 
            // xoasp
            // 
            this.xoasp.Caption = "Xóa";
            this.xoasp.Id = 2;
            this.xoasp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xoasp.ImageOptions.Image")));
            this.xoasp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("xoasp.ImageOptions.LargeImage")));
            this.xoasp.Name = "xoasp";
            // 
            // nhaphangsp
            // 
            this.nhaphangsp.Caption = "Nhập Hàng";
            this.nhaphangsp.Id = 3;
            this.nhaphangsp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nhaphangsp.ImageOptions.Image")));
            this.nhaphangsp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nhaphangsp.ImageOptions.LargeImage")));
            this.nhaphangsp.Name = "nhaphangsp";
            this.nhaphangsp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.nhaphangsp_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(974, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 756);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(974, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 726);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(974, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 726);
            // 
            // txt_tenncc
            // 
            this.txt_tenncc.Location = new System.Drawing.Point(3, 33);
            this.txt_tenncc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_tenncc.Name = "txt_tenncc";
            this.txt_tenncc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenncc.Properties.Appearance.Options.UseFont = true;
            this.txt_tenncc.Size = new System.Drawing.Size(478, 26);
            this.txt_tenncc.TabIndex = 10;
            // 
            // timkiemsanphamcuancc
            // 
            this.timkiemsanphamcuancc.Appearance.BackColor = System.Drawing.Color.White;
            this.timkiemsanphamcuancc.Appearance.Options.UseBackColor = true;
            this.timkiemsanphamcuancc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.timkiemsanphamcuancc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.timkiemsanphamcuancc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.timkiemsanphamcuancc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("timkiemsanphamcuancc.ImageOptions.Image")));
            this.timkiemsanphamcuancc.Location = new System.Drawing.Point(944, 33);
            this.timkiemsanphamcuancc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timkiemsanphamcuancc.Name = "timkiemsanphamcuancc";
            this.timkiemsanphamcuancc.Size = new System.Drawing.Size(27, 25);
            this.timkiemsanphamcuancc.TabIndex = 13;
            // 
            // txt_timkiemsanphamcuancc
            // 
            this.txt_timkiemsanphamcuancc.Location = new System.Drawing.Point(492, 32);
            this.txt_timkiemsanphamcuancc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_timkiemsanphamcuancc.Name = "txt_timkiemsanphamcuancc";
            this.txt_timkiemsanphamcuancc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timkiemsanphamcuancc.Properties.Appearance.Options.UseFont = true;
            this.txt_timkiemsanphamcuancc.Size = new System.Drawing.Size(478, 26);
            this.txt_timkiemsanphamcuancc.TabIndex = 12;
            // 
            // timkiemncc
            // 
            this.timkiemncc.Appearance.BackColor = System.Drawing.Color.White;
            this.timkiemncc.Appearance.Options.UseBackColor = true;
            this.timkiemncc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.timkiemncc.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.timkiemncc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.timkiemncc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("timkiemncc.ImageOptions.Image")));
            this.timkiemncc.Location = new System.Drawing.Point(455, 34);
            this.timkiemncc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timkiemncc.Name = "timkiemncc";
            this.timkiemncc.Size = new System.Drawing.Size(27, 25);
            this.timkiemncc.TabIndex = 11;
            // 
            // dgv_ncc
            // 
            this.dgv_ncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ncc.Location = new System.Drawing.Point(3, 69);
            this.dgv_ncc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_ncc.Name = "dgv_ncc";
            this.dgv_ncc.RowHeadersWidth = 51;
            this.dgv_ncc.Size = new System.Drawing.Size(478, 683);
            this.dgv_ncc.TabIndex = 15;
            // 
            // dgv_sanphamcuancc
            // 
            this.dgv_sanphamcuancc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sanphamcuancc.Location = new System.Drawing.Point(492, 69);
            this.dgv_sanphamcuancc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_sanphamcuancc.Name = "dgv_sanphamcuancc";
            this.dgv_sanphamcuancc.RowHeadersWidth = 51;
            this.dgv_sanphamcuancc.Size = new System.Drawing.Size(478, 683);
            this.dgv_sanphamcuancc.TabIndex = 14;
            // 
            // UC_NhapHangTheoSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timkiemsanphamcuancc);
            this.Controls.Add(this.timkiemncc);
            this.Controls.Add(this.dgv_ncc);
            this.Controls.Add(this.dgv_sanphamcuancc);
            this.Controls.Add(this.txt_tenncc);
            this.Controls.Add(this.txt_timkiemsanphamcuancc);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_NhapHangTheoSanPham";
            this.Size = new System.Drawing.Size(974, 756);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tenncc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_timkiemsanphamcuancc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ncc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanphamcuancc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem themsp;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem suasp;
        private DevExpress.XtraBars.BarButtonItem xoasp;
        private DevExpress.XtraBars.BarButtonItem nhaphangsp;
        private DevExpress.XtraEditors.TextEdit txt_tenncc;
        private DevExpress.XtraEditors.LabelControl timkiemsanphamcuancc;
        private DevExpress.XtraEditors.TextEdit txt_timkiemsanphamcuancc;
        private DevExpress.XtraEditors.LabelControl timkiemncc;
        private System.Windows.Forms.DataGridView dgv_ncc;
        private System.Windows.Forms.DataGridView dgv_sanphamcuancc;
    }
}
