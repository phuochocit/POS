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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace POS_System
{
    public partial class frmRevenueReport : Form
    {
        private frmHomepage homepageForm;
        public frmRevenueReport(frmHomepage homepage)
        {
            InitializeComponent();
            homepageForm = homepage;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (homepageForm == null)
            {
                homepageForm = new frmHomepage();
            }
            homepageForm.Show();
        }

        private void frmRevenueReport_ForeColorChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDoanhthutongthe_Click(object sender, EventArgs e)
        {

        }

        private void btnDoanhthuchitiet_Click(object sender, EventArgs e)
        {

        }

        private void btnDanhsachhoadon_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonService hoaDonService = new HoaDonService();
                List<HOADON> danhSachHoaDon = hoaDonService.GetAll(); // Lấy tất cả hóa đơn từ database

                if (danhSachHoaDon != null && danhSachHoaDon.Count > 0)
                {
                    // Chuyển danh sách sang danh sách ẩn danh chỉ chứa các cột cần thiết
                    var danhSachHienThi = danhSachHoaDon.Select(hoadon => new
                    {
                        hoadon.MAHD,        // Mã hóa đơn
                        hoadon.TENKH,       // Tên khách hàng
                        SL = hoadon.SL ?? 0, // Số lượng (nếu null thì đặt 0)
                        THOIGIAN = hoadon.THOIGIAN?.ToString("dd-MM-yyyy hh:mm:ss") ?? "N/A", // Thời gian
                        hoadon.HINHTHUC     // Hình thức thanh toán
                    }).ToList();

                    // Định nghĩa lại cột trong DataGridView
                    dgvRevenueReport.AutoGenerateColumns = false; // Tắt tự động tạo cột
                    dgvRevenueReport.Columns.Clear(); // Xóa các cột cũ

                    dgvRevenueReport.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "MAHD",
                        HeaderText = "Mã hóa đơn",
                        Name = "MAHD",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvRevenueReport.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TENKH",
                        HeaderText = "Tên khách hàng",
                        Name = "TENKH",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvRevenueReport.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "SL",
                        HeaderText = "Số lượng",
                        Name = "SL",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvRevenueReport.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "THOIGIAN",
                        HeaderText = "Thời gian",
                        Name = "THOIGIAN",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvRevenueReport.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "HINHTHUC",
                        HeaderText = "Hình thức thanh toán",
                        Name = "HINHTHUC",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    // Gán danh sách đã lọc làm nguồn dữ liệu
                    dgvRevenueReport.DataSource = danhSachHienThi;

                    MessageBox.Show("Danh sách hóa đơn đã được tải thành công.", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không có hóa đơn nào trong cơ sở dữ liệu.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private void dgvRevenueReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
