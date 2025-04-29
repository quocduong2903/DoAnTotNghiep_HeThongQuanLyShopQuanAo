
namespace GUI
{
    partial class frmDuyetSanPham
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lct_dsspcd = new DevExpress.XtraLayout.LayoutControl();
            this.gdv_duyet_sp = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lct_dsdonsp = new DevExpress.XtraLayout.LayoutControl();
            this.dgv_dsnhap = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bt_duyet = new DevExpress.XtraEditors.CheckButton();
            this.bt_ht = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.lct_dsspcd)).BeginInit();
            this.lct_dsspcd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_duyet_sp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lct_dsdonsp)).BeginInit();
            this.lct_dsdonsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsnhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lct_dsspcd
            // 
            this.lct_dsspcd.BackColor = System.Drawing.Color.White;
            this.lct_dsspcd.Controls.Add(this.gdv_duyet_sp);
            this.lct_dsspcd.Location = new System.Drawing.Point(565, 70);
            this.lct_dsspcd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lct_dsspcd.Name = "lct_dsspcd";
            this.lct_dsspcd.Root = this.Root;
            this.lct_dsspcd.Size = new System.Drawing.Size(563, 775);
            this.lct_dsspcd.TabIndex = 53;
            this.lct_dsspcd.Text = "layoutControl1";
            // 
            // gdv_duyet_sp
            // 
            this.gdv_duyet_sp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdv_duyet_sp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdv_duyet_sp.Location = new System.Drawing.Point(12, 38);
            this.gdv_duyet_sp.MainView = this.gridView1;
            this.gdv_duyet_sp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdv_duyet_sp.Name = "gdv_duyet_sp";
            this.gdv_duyet_sp.Size = new System.Drawing.Size(539, 725);
            this.gdv_duyet_sp.TabIndex = 4;
            this.gdv_duyet_sp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gdv_duyet_sp;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(563, 775);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.gdv_duyet_sp;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(543, 755);
            this.layoutControlItem1.Text = "Danh sách sản phẩm cần duyệt";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(246, 23);
            // 
            // lct_dsdonsp
            // 
            this.lct_dsdonsp.BackColor = System.Drawing.Color.White;
            this.lct_dsdonsp.Controls.Add(this.dgv_dsnhap);
            this.lct_dsdonsp.Location = new System.Drawing.Point(-3, 9);
            this.lct_dsdonsp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lct_dsdonsp.Name = "lct_dsdonsp";
            this.lct_dsdonsp.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(538, 362, 650, 400);
            this.lct_dsdonsp.Root = this.layoutControlGroup1;
            this.lct_dsdonsp.Size = new System.Drawing.Size(575, 837);
            this.lct_dsdonsp.TabIndex = 54;
            this.lct_dsdonsp.Text = "lct_dsdsp";
            // 
            // dgv_dsnhap
            // 
            this.dgv_dsnhap.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_dsnhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_dsnhap.Location = new System.Drawing.Point(12, 38);
            this.dgv_dsnhap.MainView = this.gridView2;
            this.dgv_dsnhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_dsnhap.Name = "dgv_dsnhap";
            this.dgv_dsnhap.Size = new System.Drawing.Size(551, 787);
            this.dgv_dsnhap.TabIndex = 4;
            this.dgv_dsnhap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 431;
            this.gridView2.GridControl = this.dgv_dsnhap;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(575, 837);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.dgv_dsnhap;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem1";
            this.layoutControlItem2.Size = new System.Drawing.Size(555, 817);
            this.layoutControlItem2.Text = "Danh sách đơn sản phẩm";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(200, 23);
            // 
            // bt_duyet
            // 
            this.bt_duyet.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_duyet.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_duyet.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_duyet.Appearance.Options.UseBackColor = true;
            this.bt_duyet.Appearance.Options.UseFont = true;
            this.bt_duyet.Appearance.Options.UseForeColor = true;
            this.bt_duyet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_duyet.Location = new System.Drawing.Point(864, 9);
            this.bt_duyet.Margin = new System.Windows.Forms.Padding(4);
            this.bt_duyet.Name = "bt_duyet";
            this.bt_duyet.Size = new System.Drawing.Size(264, 50);
            this.bt_duyet.TabIndex = 57;
            this.bt_duyet.Text = "Duyệt";
            this.bt_duyet.CheckedChanged += new System.EventHandler(this.bt_duyet_CheckedChanged);
            // 
            // bt_ht
            // 
            this.bt_ht.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_ht.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ht.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bt_ht.Appearance.Options.UseBackColor = true;
            this.bt_ht.Appearance.Options.UseFont = true;
            this.bt_ht.Appearance.Options.UseForeColor = true;
            this.bt_ht.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_ht.Location = new System.Drawing.Point(579, 9);
            this.bt_ht.Margin = new System.Windows.Forms.Padding(4);
            this.bt_ht.Name = "bt_ht";
            this.bt_ht.Size = new System.Drawing.Size(277, 50);
            this.bt_ht.TabIndex = 60;
            this.bt_ht.Text = "Hoàn thành đơn";
            // 
            // frmDuyetSanPham
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 842);
            this.Controls.Add(this.bt_duyet);
            this.Controls.Add(this.lct_dsdonsp);
            this.Controls.Add(this.bt_ht);
            this.Controls.Add(this.lct_dsspcd);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDuyetSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDuyetSanPham";
            ((System.ComponentModel.ISupportInitialize)(this.lct_dsspcd)).EndInit();
            this.lct_dsspcd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdv_duyet_sp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lct_dsdonsp)).EndInit();
            this.lct_dsdonsp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsnhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lct_dsspcd;
        private DevExpress.XtraGrid.GridControl gdv_duyet_sp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl lct_dsdonsp;
        private DevExpress.XtraGrid.GridControl dgv_dsnhap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckButton bt_duyet;
        private DevExpress.XtraEditors.CheckButton bt_ht;
    }
}