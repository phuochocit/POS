namespace POS_System
{
    partial class frmRevenueReport
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
            this.btnDoanhthutongthe = new System.Windows.Forms.Button();
            this.btnChiTietHoaDon = new System.Windows.Forms.Button();
            this.btnDanhsachhoadon = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvRevenueReport = new System.Windows.Forms.DataGridView();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDoanhthutongthe
            // 
            this.btnDoanhthutongthe.Location = new System.Drawing.Point(12, 51);
            this.btnDoanhthutongthe.Name = "btnDoanhthutongthe";
            this.btnDoanhthutongthe.Size = new System.Drawing.Size(197, 36);
            this.btnDoanhthutongthe.TabIndex = 1;
            this.btnDoanhthutongthe.Text = "Doanh thu tổng thể";
            this.btnDoanhthutongthe.UseVisualStyleBackColor = true;
            this.btnDoanhthutongthe.Click += new System.EventHandler(this.btnDoanhthutongthe_Click);
            // 
            // btnChiTietHoaDon
            // 
            this.btnChiTietHoaDon.Location = new System.Drawing.Point(418, 51);
            this.btnChiTietHoaDon.Name = "btnChiTietHoaDon";
            this.btnChiTietHoaDon.Size = new System.Drawing.Size(197, 36);
            this.btnChiTietHoaDon.TabIndex = 1;
            this.btnChiTietHoaDon.Text = "Chi tiết hóa đơn";
            this.btnChiTietHoaDon.UseVisualStyleBackColor = true;
            this.btnChiTietHoaDon.Click += new System.EventHandler(this.btnChiTietHoaDon_Click);
            // 
            // btnDanhsachhoadon
            // 
            this.btnDanhsachhoadon.Location = new System.Drawing.Point(215, 51);
            this.btnDanhsachhoadon.Name = "btnDanhsachhoadon";
            this.btnDanhsachhoadon.Size = new System.Drawing.Size(197, 36);
            this.btnDanhsachhoadon.TabIndex = 1;
            this.btnDanhsachhoadon.Text = "Danh sách hóa đơn";
            this.btnDanhsachhoadon.UseVisualStyleBackColor = true;
            this.btnDanhsachhoadon.Click += new System.EventHandler(this.btnDanhsachhoadon_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(854, 474);
            this.btnBack.Name = "btnBack";
            this.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBack.Size = new System.Drawing.Size(116, 53);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvRevenueReport
            // 
            this.dgvRevenueReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevenueReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRevenueReport.Location = new System.Drawing.Point(12, 93);
            this.dgvRevenueReport.Name = "dgvRevenueReport";
            this.dgvRevenueReport.RowHeadersWidth = 51;
            this.dgvRevenueReport.RowTemplate.Height = 24;
            this.dgvRevenueReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevenueReport.Size = new System.Drawing.Size(603, 375);
            this.dgvRevenueReport.TabIndex = 3;
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(621, 93);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.RowTemplate.Height = 24;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(349, 375);
            this.dgvChiTietHoaDon.TabIndex = 4;
            // 
            // frmRevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.dgvRevenueReport);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDanhsachhoadon);
            this.Controls.Add(this.btnChiTietHoaDon);
            this.Controls.Add(this.btnDoanhthutongthe);
            this.Name = "frmRevenueReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRevenueReport_FormClosed);
            this.ForeColorChanged += new System.EventHandler(this.frmRevenueReport_ForeColorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDoanhthutongthe;
        private System.Windows.Forms.Button btnChiTietHoaDon;
        private System.Windows.Forms.Button btnDanhsachhoadon;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvRevenueReport;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
    }
}