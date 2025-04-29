
namespace GUI
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.thoat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dangnhap = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.matkhau = new System.Windows.Forms.Label();
            this.nhapmk = new DevExpress.XtraEditors.TextEdit();
            this.taikhoan = new System.Windows.Forms.Label();
            this.nhaptk = new DevExpress.XtraEditors.TextEdit();
            this.welcome = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dong = new System.Windows.Forms.Button();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.header.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhapmk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaptk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.NavajoWhite;
            this.header.Controls.Add(this.label1);
            this.header.Controls.Add(this.thoat);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(879, 34);
            this.header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shop Fashion";
            // 
            // thoat
            // 
            this.thoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("thoat.BackgroundImage")));
            this.thoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.thoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.thoat.FlatAppearance.BorderSize = 0;
            this.thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thoat.Location = new System.Drawing.Point(834, 0);
            this.thoat.Name = "thoat";
            this.thoat.Size = new System.Drawing.Size(45, 34);
            this.thoat.TabIndex = 0;
            this.thoat.UseVisualStyleBackColor = true;
            this.thoat.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.dangnhap);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.matkhau);
            this.panel2.Controls.Add(this.nhapmk);
            this.panel2.Controls.Add(this.taikhoan);
            this.panel2.Controls.Add(this.nhaptk);
            this.panel2.Controls.Add(this.welcome);
            this.panel2.Location = new System.Drawing.Point(498, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 389);
            this.panel2.TabIndex = 1;
            // 
            // dangnhap
            // 
            this.dangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dangnhap.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.dangnhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dangnhap.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangnhap.ForeColor = System.Drawing.Color.Black;
            this.dangnhap.Location = new System.Drawing.Point(97, 299);
            this.dangnhap.Name = "dangnhap";
            this.dangnhap.Size = new System.Drawing.Size(163, 45);
            this.dangnhap.TabIndex = 9;
            this.dangnhap.Text = "Đăng Nhập";
            this.dangnhap.UseVisualStyleBackColor = true;
            this.dangnhap.Click += new System.EventHandler(this.dangnhap_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::GUI.Properties.Resources.matkhau;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(25, 265);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 24);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.tk;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(25, 141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // matkhau
            // 
            this.matkhau.AutoSize = true;
            this.matkhau.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhau.ForeColor = System.Drawing.Color.Black;
            this.matkhau.Location = new System.Drawing.Point(49, 185);
            this.matkhau.Name = "matkhau";
            this.matkhau.Size = new System.Drawing.Size(93, 25);
            this.matkhau.TabIndex = 6;
            this.matkhau.Text = "Mật Khẩu";
            // 
            // nhapmk
            // 
            this.nhapmk.Location = new System.Drawing.Point(54, 267);
            this.nhapmk.Name = "nhapmk";
            this.nhapmk.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhapmk.Properties.Appearance.Options.UseFont = true;
            this.nhapmk.Properties.PasswordChar = '*';
            this.nhapmk.Size = new System.Drawing.Size(274, 26);
            this.nhapmk.TabIndex = 5;
            this.nhapmk.EditValueChanged += new System.EventHandler(this.nhapmk_EditValueChanged);
            // 
            // taikhoan
            // 
            this.taikhoan.AutoSize = true;
            this.taikhoan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taikhoan.ForeColor = System.Drawing.Color.Black;
            this.taikhoan.Location = new System.Drawing.Point(49, 88);
            this.taikhoan.Name = "taikhoan";
            this.taikhoan.Size = new System.Drawing.Size(94, 25);
            this.taikhoan.TabIndex = 4;
            this.taikhoan.Text = "Tài Khoản";
            // 
            // nhaptk
            // 
            this.nhaptk.Location = new System.Drawing.Point(54, 145);
            this.nhaptk.Name = "nhaptk";
            this.nhaptk.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhaptk.Properties.Appearance.Options.UseFont = true;
            this.nhaptk.Size = new System.Drawing.Size(274, 26);
            this.nhaptk.TabIndex = 3;
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.ForeColor = System.Drawing.Color.Black;
            this.welcome.Location = new System.Drawing.Point(106, 13);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(136, 37);
            this.welcome.TabIndex = 0;
            this.welcome.Text = "Welcome";
            // 
            // background
            // 
            this.background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(879, 547);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 2;
            this.background.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(840, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 37);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(142, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Welcome";
            // 
            // dong
            // 
            this.dong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dong.BackgroundImage")));
            this.dong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dong.Dock = System.Windows.Forms.DockStyle.Right;
            this.dong.FlatAppearance.BorderSize = 0;
            this.dong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dong.Location = new System.Drawing.Point(840, 0);
            this.dong.Name = "dong";
            this.dong.Size = new System.Drawing.Size(39, 37);
            this.dong.TabIndex = 0;
            this.dong.UseVisualStyleBackColor = true;
            this.dong.Click += new System.EventHandler(this.button1_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(49, 96);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(274, 20);
            this.textEdit1.TabIndex = 3;
            // 
            // frmDangNhap
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(879, 547);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.header);
            this.Controls.Add(this.background);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhapmk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaptk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Button thoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label matkhau;
        private DevExpress.XtraEditors.TextEdit nhapmk;
        private System.Windows.Forms.Label taikhoan;
        private DevExpress.XtraEditors.TextEdit nhaptk;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Button dangnhap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button dong;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}