using POS_BUS;
using POS_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class frmHistory : Form
    {
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private frmHomepage homepageForm;
        public frmHistory(frmHomepage homepage)
        {
            InitializeComponent();
            homepageForm = homepage;
        }

        private void frmHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            if (homepageForm == null)
            {
                homepageForm = new frmHomepage(); 
            }
            homepageForm.Show(); 
        }
        private void SetupComboBox()
        {
            // Thêm các lựa chọn ca làm việc
            cmbThoiGian.Items.AddRange(new string[] {
                "Ca 0: 06:00 - 22:00",
                "Ca 1: 06:00 - 14:00",
                "Ca 2: 14:00 - 22:00"
            });
            cmbThoiGian.SelectedIndex = 0;

            // Gắn sự kiện SelectedIndexChanged
            cmbThoiGian.SelectedIndexChanged += cmbThoiGian_SelectedIndexChanged;
        }
        private void LoadHoaDon()
        {
            try
            {
                List<HOADON> danhSachHoaDon = hoaDonService.GetAll(); // Lấy tất cả hóa đơn từ database
                DINHGRID(danhSachHoaDon); // Hiển thị toàn bộ hóa đơn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private void DINHGRID(List<HOADON> danhSachHoaDon)
        {
            dgvHistory.AutoGenerateColumns = false; // Tắt tự động tạo cột
            dgvHistory.Columns.Clear(); // Xóa tất cả cột trước đó

            // Định nghĩa cột
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MAHD",
                HeaderText = "Mã hóa đơn",
                Name = "MAHD"
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TENKH",
                HeaderText = "Tên khách hàng",
                Name = "TENKH"
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SL",
                HeaderText = "Số lượng",
                Name = "SL"
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "THOIGIAN",
                HeaderText = "Thời gian",
                Name = "THOIGIAN"
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HINHTHUC",
                HeaderText = "Hình thức thanh toán",
                Name = "HINHTHUC"
            });

            // Gán dữ liệu vào DataGridView
            dgvHistory.DataSource = danhSachHoaDon;
        }


        private void frmHistory_Load(object sender, EventArgs e)
        {
            SetupComboBox(); // Cài đặt ComboBox
            LoadHoaDon(); // Tải hóa đơn ban đầu
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            try
            {
                // Truyền 'homepageForm' làm tham số cho constructor của frmRevenueReport
                frmRevenueReport revenueReportForm = new frmRevenueReport(homepageForm);

                // Hiển thị form Báo cáo doanh thu
                revenueReportForm.Show();
                this.Hide(); // Ẩn form hiện tại sau khi form mới đã hiển thị
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển sang form Báo cáo doanh thu: " + ex.Message, "Lỗi");
            }
        }

        private void btnKetca_Click(object sender, EventArgs e)
        {
            
        }
        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                var selectedRow = dgvHistory.SelectedRows[0];
                if (selectedRow.Cells["MAHD"].Value != null)
                {
                    string maHoaDon = selectedRow.Cells["MAHD"].Value.ToString();

                    DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn hủy hóa đơn {maHoaDon}?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            HoaDonService hoaDonService = new HoaDonService();
                            hoaDonService.Delete(maHoaDon); // Xóa hóa đơn từ database

                            MessageBox.Show("Hóa đơn đã được hủy thành công", "Thông báo");
                            LoadHoaDon(); // Cập nhật lại danh sách
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi hủy hóa đơn: " + ex.Message, "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể tìm thấy mã hóa đơn trong dòng được chọn.", "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để hủy", "Thông báo");
                }
            }
        }

        private void cmbThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<HOADON> danhSachHoaDon = hoaDonService.GetAll(); // Lấy toàn bộ danh sách hóa đơn từ database
                List<HOADON> filteredList = new List<HOADON>();

                string selectedShift = cmbThoiGian.SelectedItem.ToString();

                // Lọc danh sách hóa đơn theo ca làm việc
                if (selectedShift == "Ca 1: 06:00 - 14:00")
                {
                    filteredList = danhSachHoaDon
                        .Where(hd => hd.THOIGIAN != null && hd.THOIGIAN.Value.Hour >= 6 && hd.THOIGIAN.Value.Hour < 14)
                        .ToList();
                }
                else if (selectedShift == "Ca 2: 14:00 - 22:00")
                {
                    filteredList = danhSachHoaDon
                        .Where(hd => hd.THOIGIAN != null && hd.THOIGIAN.Value.Hour >= 14 && hd.THOIGIAN.Value.Hour < 22)
                        .ToList();
                }
                else if (selectedShift == "Ca 0: 06:00 - 22:00")
                {
                    filteredList = danhSachHoaDon; // Hiển thị tất cả
                }

                DINHGRID(filteredList); // Hiển thị lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private void frmHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        
    }
}
