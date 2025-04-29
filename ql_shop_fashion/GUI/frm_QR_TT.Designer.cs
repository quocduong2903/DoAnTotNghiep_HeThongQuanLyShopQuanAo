
namespace GUI
{
    partial class frm_QR_TT
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
            this.bt_tt = new System.Windows.Forms.Button();
            this.lb_thanhtoanbangqrcode = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_tt
            // 
            this.bt_tt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_tt.Location = new System.Drawing.Point(406, 548);
            this.bt_tt.Margin = new System.Windows.Forms.Padding(4);
            this.bt_tt.Name = "bt_tt";
            this.bt_tt.Size = new System.Drawing.Size(221, 57);
            this.bt_tt.TabIndex = 1;
            this.bt_tt.Text = "Xác nhận thanh toán";
            this.bt_tt.UseVisualStyleBackColor = false;
            // 
            // lb_thanhtoanbangqrcode
            // 
            this.lb_thanhtoanbangqrcode.AutoSize = true;
            this.lb_thanhtoanbangqrcode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thanhtoanbangqrcode.Location = new System.Drawing.Point(326, 9);
            this.lb_thanhtoanbangqrcode.Name = "lb_thanhtoanbangqrcode";
            this.lb_thanhtoanbangqrcode.Size = new System.Drawing.Size(374, 41);
            this.lb_thanhtoanbangqrcode.TabIndex = 2;
            this.lb_thanhtoanbangqrcode.Text = "Thanh Toán Bằng QR Code";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(268, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 391);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frm_QR_TT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 655);
            this.Controls.Add(this.lb_thanhtoanbangqrcode);
            this.Controls.Add(this.bt_tt);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_QR_TT";
            this.Text = "frm_QR_TT";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bt_tt;
        private System.Windows.Forms.Label lb_thanhtoanbangqrcode;
    }
}