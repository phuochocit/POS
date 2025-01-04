namespace POS_System
{
    partial class frmHistory
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
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.btnKetca = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.cmbThoiGian = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistory
            // 
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(12, 102);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(958, 358);
            this.dgvHistory.TabIndex = 0;
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(854, 466);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Back.Size = new System.Drawing.Size(116, 53);
            this.btn_Back.TabIndex = 1;
            this.btn_Back.Text = "Quay lại";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(566, 28);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(183, 57);
            this.btnBaocao.TabIndex = 3;
            this.btnBaocao.Text = "Báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // btnKetca
            // 
            this.btnKetca.Location = new System.Drawing.Point(787, 28);
            this.btnKetca.Name = "btnKetca";
            this.btnKetca.Size = new System.Drawing.Size(183, 57);
            this.btnKetca.TabIndex = 3;
            this.btnKetca.Text = "Kết ca";
            this.btnKetca.UseVisualStyleBackColor = true;
            this.btnKetca.Click += new System.EventHandler(this.btnKetca_Click);
            // 
            // btnHuyDon
            // 
            this.btnHuyDon.Location = new System.Drawing.Point(716, 466);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(118, 53);
            this.btnHuyDon.TabIndex = 3;
            this.btnHuyDon.Text = "Hủy đơn này";
            this.btnHuyDon.UseVisualStyleBackColor = true;
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);
            // 
            // cmbThoiGian
            // 
            this.cmbThoiGian.FormattingEnabled = true;
            this.cmbThoiGian.Location = new System.Drawing.Point(277, 17);
            this.cmbThoiGian.Name = "cmbThoiGian";
            this.cmbThoiGian.Size = new System.Drawing.Size(180, 24);
            this.cmbThoiGian.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thời gian";
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbThoiGian);
            this.Controls.Add(this.btnKetca);
            this.Controls.Add(this.btnBaocao);
            this.Controls.Add(this.btnHuyDon);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.dgvHistory);
            this.Name = "frmHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem lại phiếu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHistory_FormClosing);
            this.Load += new System.EventHandler(this.frmHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btnBaocao;
        private System.Windows.Forms.Button btnKetca;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.ComboBox cmbThoiGian;
        private System.Windows.Forms.Label label1;
    }
}