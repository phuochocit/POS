namespace POS_System
{
    partial class frmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.p_Sanpham = new System.Windows.Forms.Panel();
            this.p_Danhmuc = new System.Windows.Forms.Panel();
            this.cmb_Danhmuc = new System.Windows.Forms.ComboBox();
            this.p_Timsp = new System.Windows.Forms.Panel();
            this.btn_Timsp = new System.Windows.Forms.Button();
            this.txt_Timsp = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Hompage = new System.Windows.Forms.Button();
            this.btn_Thanhtoan = new System.Windows.Forms.Button();
            this.lbl_Vaoca = new System.Windows.Forms.Label();
            this.p_Thanhtien = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Thanhtien = new System.Windows.Forms.Label();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.lbl_Khach = new System.Windows.Forms.Label();
            this.cmbKhach = new System.Windows.Forms.ComboBox();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_SL = new System.Windows.Forms.Label();
            this.p_Sanpham.SuspendLayout();
            this.p_Danhmuc.SuspendLayout();
            this.p_Timsp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.p_Thanhtien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Sanpham
            // 
            this.p_Sanpham.Controls.Add(this.p_Danhmuc);
            this.p_Sanpham.Controls.Add(this.p_Timsp);
            this.p_Sanpham.Location = new System.Drawing.Point(427, 3);
            this.p_Sanpham.Name = "p_Sanpham";
            this.p_Sanpham.Size = new System.Drawing.Size(743, 738);
            this.p_Sanpham.TabIndex = 0;
            // 
            // p_Danhmuc
            // 
            this.p_Danhmuc.Controls.Add(this.cmb_Danhmuc);
            this.p_Danhmuc.Location = new System.Drawing.Point(22, 66);
            this.p_Danhmuc.Name = "p_Danhmuc";
            this.p_Danhmuc.Size = new System.Drawing.Size(237, 38);
            this.p_Danhmuc.TabIndex = 8;
            // 
            // cmb_Danhmuc
            // 
            this.cmb_Danhmuc.FormattingEnabled = true;
            this.cmb_Danhmuc.Items.AddRange(new object[] {
            "Tất cả sản phẩm",
            ""});
            this.cmb_Danhmuc.Location = new System.Drawing.Point(3, 11);
            this.cmb_Danhmuc.Name = "cmb_Danhmuc";
            this.cmb_Danhmuc.Size = new System.Drawing.Size(231, 24);
            this.cmb_Danhmuc.TabIndex = 0;
            this.cmb_Danhmuc.SelectedIndexChanged += new System.EventHandler(this.cmb_Danhmuc_SelectedIndexChanged);
            // 
            // p_Timsp
            // 
            this.p_Timsp.Controls.Add(this.btn_Timsp);
            this.p_Timsp.Controls.Add(this.txt_Timsp);
            this.p_Timsp.Location = new System.Drawing.Point(22, 3);
            this.p_Timsp.Name = "p_Timsp";
            this.p_Timsp.Size = new System.Drawing.Size(398, 56);
            this.p_Timsp.TabIndex = 7;
            // 
            // btn_Timsp
            // 
            this.btn_Timsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Timsp.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Timsp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Timsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timsp.ForeColor = System.Drawing.Color.White;
            this.btn_Timsp.Location = new System.Drawing.Point(312, 19);
            this.btn_Timsp.Name = "btn_Timsp";
            this.btn_Timsp.Size = new System.Drawing.Size(83, 34);
            this.btn_Timsp.TabIndex = 6;
            this.btn_Timsp.Text = "Tìm";
            this.btn_Timsp.UseVisualStyleBackColor = false;
            this.btn_Timsp.Click += new System.EventHandler(this.btn_Timsp_Click);
            // 
            // txt_Timsp
            // 
            this.txt_Timsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Timsp.Location = new System.Drawing.Point(3, 25);
            this.txt_Timsp.Name = "txt_Timsp";
            this.txt_Timsp.Size = new System.Drawing.Size(303, 28);
            this.txt_Timsp.TabIndex = 4;
            this.txt_Timsp.TextChanged += new System.EventHandler(this.txt_Timsp_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Hompage);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 44);
            this.panel1.TabIndex = 2;
            // 
            // btn_Hompage
            // 
            this.btn_Hompage.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Hompage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_Hompage.Image = ((System.Drawing.Image)(resources.GetObject("btn_Hompage.Image")));
            this.btn_Hompage.Location = new System.Drawing.Point(0, 0);
            this.btn_Hompage.Name = "btn_Hompage";
            this.btn_Hompage.Size = new System.Drawing.Size(86, 42);
            this.btn_Hompage.TabIndex = 9;
            this.btn_Hompage.UseVisualStyleBackColor = false;
            this.btn_Hompage.Click += new System.EventHandler(this.btn_Hompage_Click);
            // 
            // btn_Thanhtoan
            // 
            this.btn_Thanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thanhtoan.Location = new System.Drawing.Point(5, 670);
            this.btn_Thanhtoan.Name = "btn_Thanhtoan";
            this.btn_Thanhtoan.Size = new System.Drawing.Size(416, 71);
            this.btn_Thanhtoan.TabIndex = 3;
            this.btn_Thanhtoan.Text = "Thanh toán";
            this.btn_Thanhtoan.UseVisualStyleBackColor = true;
            this.btn_Thanhtoan.Click += new System.EventHandler(this.btn_Thanhtoan_Click);
            // 
            // lbl_Vaoca
            // 
            this.lbl_Vaoca.BackColor = System.Drawing.Color.RoyalBlue;
            this.lbl_Vaoca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Vaoca.Location = new System.Drawing.Point(5, 571);
            this.lbl_Vaoca.Name = "lbl_Vaoca";
            this.lbl_Vaoca.Size = new System.Drawing.Size(413, 37);
            this.lbl_Vaoca.TabIndex = 8;
            this.lbl_Vaoca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_Thanhtien
            // 
            this.p_Thanhtien.Controls.Add(this.label1);
            this.p_Thanhtien.Controls.Add(this.lbl_Thanhtien);
            this.p_Thanhtien.Location = new System.Drawing.Point(3, 528);
            this.p_Thanhtien.Name = "p_Thanhtien";
            this.p_Thanhtien.Size = new System.Drawing.Size(418, 40);
            this.p_Thanhtien.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Thành tiền";
            // 
            // lbl_Thanhtien
            // 
            this.lbl_Thanhtien.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_Thanhtien.Enabled = false;
            this.lbl_Thanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Thanhtien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Thanhtien.Location = new System.Drawing.Point(145, 7);
            this.lbl_Thanhtien.Name = "lbl_Thanhtien";
            this.lbl_Thanhtien.Size = new System.Drawing.Size(270, 29);
            this.lbl_Thanhtien.TabIndex = 0;
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.Color.White;
            this.btn_Sua.Location = new System.Drawing.Point(2, 469);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(200, 53);
            this.btn_Sua.TabIndex = 11;
            this.btn_Sua.Text = "Chỉnh sửa";
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.White;
            this.btn_Xoa.Location = new System.Drawing.Point(211, 469);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(210, 53);
            this.btn_Xoa.TabIndex = 11;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // lbl_Khach
            // 
            this.lbl_Khach.AutoSize = true;
            this.lbl_Khach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Khach.Location = new System.Drawing.Point(2, 630);
            this.lbl_Khach.Name = "lbl_Khach";
            this.lbl_Khach.Size = new System.Drawing.Size(107, 20);
            this.lbl_Khach.TabIndex = 5;
            this.lbl_Khach.Text = "Khách hàng";
            // 
            // cmbKhach
            // 
            this.cmbKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhach.FormattingEnabled = true;
            this.cmbKhach.Location = new System.Drawing.Point(132, 626);
            this.cmbKhach.Name = "cmbKhach";
            this.cmbKhach.Size = new System.Drawing.Size(186, 28);
            this.cmbKhach.TabIndex = 12;
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Location = new System.Drawing.Point(5, 53);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.RowTemplate.Height = 24;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(416, 378);
            this.dgvGioHang.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Số lượng món";
            // 
            // lbl_SL
            // 
            this.lbl_SL.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_SL.Enabled = false;
            this.lbl_SL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SL.Location = new System.Drawing.Point(175, 433);
            this.lbl_SL.Name = "lbl_SL";
            this.lbl_SL.Size = new System.Drawing.Size(61, 29);
            this.lbl_SL.TabIndex = 0;
            this.lbl_SL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_SL);
            this.Controls.Add(this.dgvGioHang);
            this.Controls.Add(this.cmbKhach);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.p_Thanhtien);
            this.Controls.Add(this.lbl_Vaoca);
            this.Controls.Add(this.lbl_Khach);
            this.Controls.Add(this.btn_Thanhtoan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.p_Sanpham);
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrder_FormClosing);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.p_Sanpham.ResumeLayout(false);
            this.p_Danhmuc.ResumeLayout(false);
            this.p_Timsp.ResumeLayout(false);
            this.p_Timsp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.p_Thanhtien.ResumeLayout(false);
            this.p_Thanhtien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_Sanpham;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Thanhtoan;
        private System.Windows.Forms.Button btn_Timsp;
        private System.Windows.Forms.TextBox txt_Timsp;
        private System.Windows.Forms.Label lbl_Vaoca;
        private System.Windows.Forms.Panel p_Thanhtien;
        private System.Windows.Forms.Label lbl_Thanhtien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Hompage;
        private System.Windows.Forms.Panel p_Timsp;
        private System.Windows.Forms.Panel p_Danhmuc;
        private System.Windows.Forms.ComboBox cmb_Danhmuc;
        private System.Windows.Forms.Label lbl_Khach;
        private System.Windows.Forms.ComboBox cmbKhach;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_SL;
    }
}