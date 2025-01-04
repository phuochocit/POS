namespace POS_System
{
    partial class frmPay
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
            this.btn_ttienMat = new System.Windows.Forms.Button();
            this.btn_ttmoMo = new System.Windows.Forms.Button();
            this.btn_ttchuyenKhoan = new System.Windows.Forms.Button();
            this.btn_quayLai = new System.Windows.Forms.Button();
            this.btn_taoHD = new System.Windows.Forms.Button();
            this.lbl_tongTienTT = new System.Windows.Forms.Label();
            this.lbl_tienSo = new System.Windows.Forms.Label();
            this.lbl_phuongThuc = new System.Windows.Forms.Label();
            this.lbl_tienChu = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSL = new System.Windows.Forms.Label();
            this.lblKhach = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picPay = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPay)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ttienMat
            // 
            this.btn_ttienMat.Location = new System.Drawing.Point(39, 49);
            this.btn_ttienMat.Name = "btn_ttienMat";
            this.btn_ttienMat.Size = new System.Drawing.Size(161, 55);
            this.btn_ttienMat.TabIndex = 11;
            this.btn_ttienMat.Text = "Tiền mặt";
            this.btn_ttienMat.UseVisualStyleBackColor = true;
            this.btn_ttienMat.Click += new System.EventHandler(this.btn_ttienMat_Click);
            // 
            // btn_ttmoMo
            // 
            this.btn_ttmoMo.Location = new System.Drawing.Point(39, 110);
            this.btn_ttmoMo.Name = "btn_ttmoMo";
            this.btn_ttmoMo.Size = new System.Drawing.Size(161, 55);
            this.btn_ttmoMo.TabIndex = 11;
            this.btn_ttmoMo.Text = "MoMo";
            this.btn_ttmoMo.UseVisualStyleBackColor = true;
            this.btn_ttmoMo.Click += new System.EventHandler(this.btn_ttmoMo_Click);
            // 
            // btn_ttchuyenKhoan
            // 
            this.btn_ttchuyenKhoan.Location = new System.Drawing.Point(39, 171);
            this.btn_ttchuyenKhoan.Name = "btn_ttchuyenKhoan";
            this.btn_ttchuyenKhoan.Size = new System.Drawing.Size(161, 55);
            this.btn_ttchuyenKhoan.TabIndex = 11;
            this.btn_ttchuyenKhoan.Text = "Chuyển khoản";
            this.btn_ttchuyenKhoan.UseVisualStyleBackColor = true;
            this.btn_ttchuyenKhoan.Click += new System.EventHandler(this.btn_ttchuyenKhoan_Click);
            // 
            // btn_quayLai
            // 
            this.btn_quayLai.Location = new System.Drawing.Point(428, 291);
            this.btn_quayLai.Name = "btn_quayLai";
            this.btn_quayLai.Size = new System.Drawing.Size(110, 41);
            this.btn_quayLai.TabIndex = 11;
            this.btn_quayLai.Text = "Quay lại";
            this.btn_quayLai.UseVisualStyleBackColor = true;
            this.btn_quayLai.Click += new System.EventHandler(this.btn_quayLai_Click);
            // 
            // btn_taoHD
            // 
            this.btn_taoHD.Location = new System.Drawing.Point(163, 291);
            this.btn_taoHD.Name = "btn_taoHD";
            this.btn_taoHD.Size = new System.Drawing.Size(159, 41);
            this.btn_taoHD.TabIndex = 11;
            this.btn_taoHD.Text = "Tạo hóa đơn";
            this.btn_taoHD.UseVisualStyleBackColor = true;
            this.btn_taoHD.Click += new System.EventHandler(this.btn_taoHD_Click);
            // 
            // lbl_tongTienTT
            // 
            this.lbl_tongTienTT.AutoSize = true;
            this.lbl_tongTienTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tongTienTT.Location = new System.Drawing.Point(41, 12);
            this.lbl_tongTienTT.Name = "lbl_tongTienTT";
            this.lbl_tongTienTT.Size = new System.Drawing.Size(181, 20);
            this.lbl_tongTienTT.TabIndex = 14;
            this.lbl_tongTienTT.Text = "Tổng tiền thanh toán";
            // 
            // lbl_tienSo
            // 
            this.lbl_tienSo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_tienSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tienSo.ForeColor = System.Drawing.Color.Blue;
            this.lbl_tienSo.Location = new System.Drawing.Point(27, 32);
            this.lbl_tienSo.Name = "lbl_tienSo";
            this.lbl_tienSo.Size = new System.Drawing.Size(256, 40);
            this.lbl_tienSo.TabIndex = 15;
            this.lbl_tienSo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_phuongThuc
            // 
            this.lbl_phuongThuc.AutoSize = true;
            this.lbl_phuongThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phuongThuc.Location = new System.Drawing.Point(61, 12);
            this.lbl_phuongThuc.Name = "lbl_phuongThuc";
            this.lbl_phuongThuc.Size = new System.Drawing.Size(113, 20);
            this.lbl_phuongThuc.TabIndex = 14;
            this.lbl_phuongThuc.Text = "Phương thức";
            // 
            // lbl_tienChu
            // 
            this.lbl_tienChu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_tienChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tienChu.Location = new System.Drawing.Point(26, 72);
            this.lbl_tienChu.Name = "lbl_tienChu";
            this.lbl_tienChu.Size = new System.Drawing.Size(257, 23);
            this.lbl_tienChu.TabIndex = 16;
            this.lbl_tienChu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSL);
            this.panel1.Controls.Add(this.lblKhach);
            this.panel1.Controls.Add(this.lbl_tienSo);
            this.panel1.Controls.Add(this.lbl_tienChu);
            this.panel1.Controls.Add(this.lbl_tongTienTT);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 200);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Số lượng món";
            // 
            // lblSL
            // 
            this.lblSL.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSL.Location = new System.Drawing.Point(199, 123);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(84, 23);
            this.lblSL.TabIndex = 17;
            this.lblSL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKhach
            // 
            this.lblKhach.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblKhach.Location = new System.Drawing.Point(28, 95);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new System.Drawing.Size(255, 28);
            this.lblKhach.TabIndex = 0;
            this.lblKhach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_phuongThuc);
            this.panel2.Controls.Add(this.btn_ttienMat);
            this.panel2.Controls.Add(this.btn_ttmoMo);
            this.panel2.Controls.Add(this.btn_ttchuyenKhoan);
            this.panel2.Location = new System.Drawing.Point(534, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 235);
            this.panel2.TabIndex = 18;
            // 
            // picPay
            // 
            this.picPay.Location = new System.Drawing.Point(328, 12);
            this.picPay.Name = "picPay";
            this.picPay.Size = new System.Drawing.Size(200, 200);
            this.picPay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPay.TabIndex = 19;
            this.picPay.TabStop = false;
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 353);
            this.Controls.Add(this.picPay);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_taoHD);
            this.Controls.Add(this.btn_quayLai);
            this.Name = "frmPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh Toán";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPay_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_ttienMat;
        private System.Windows.Forms.Button btn_ttmoMo;
        private System.Windows.Forms.Button btn_ttchuyenKhoan;
        private System.Windows.Forms.Button btn_quayLai;
        private System.Windows.Forms.Button btn_taoHD;
        private System.Windows.Forms.Label lbl_tongTienTT;
        private System.Windows.Forms.Label lbl_tienSo;
        private System.Windows.Forms.Label lbl_phuongThuc;
        private System.Windows.Forms.Label lbl_tienChu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picPay;
        private System.Windows.Forms.Label lblKhach;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.Label label1;
    }
}