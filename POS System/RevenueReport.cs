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
            try
            {
                HoaDonService hoaDonService = new HoaDonService();
                List<HOADON> danhSachHoaDon = hoaDonService.GetAll(); // Lấy tất cả hóa đơn từ database

                decimal tongDoanhThuTienMat = 0;
                decimal tongDoanhThuMomo = 0;
                decimal tongDoanhThuChuyenKhoan = 0;

                if (danhSachHoaDon != null && danhSachHoaDon.Count > 0)
                {
                    CTHDService cthdService = new CTHDService();

                    // Lặp qua từng hóa đơn và tính doanh thu từ chi tiết hóa đơn
                    foreach (var hoadon in danhSachHoaDon)
                    {
                        // Lấy danh sách chi tiết hóa đơn của từng hóa đơn
                        var chiTietHoaDon = cthdService.GetByInvoiceId(hoadon.MAHD);

                        if (chiTietHoaDon != null && chiTietHoaDon.Count > 0)
                        {
                            // Tính doanh thu cho từng phương thức thanh toán
                            decimal doanhThuHoaDon = chiTietHoaDon.Sum(cthd => (cthd.SL ?? 0) * (cthd.GIATIEN ?? 0));

                            // Phân loại theo phương thức thanh toán (chuẩn hóa giá trị)
                            string hinhThucThanhToan = hoadon.HINHTHUC?.Trim().ToLower(); // Chuẩn hóa tên phương thức thanh toán

                            if (hinhThucThanhToan == "tiền mặt")
                            {
                                tongDoanhThuTienMat += doanhThuHoaDon;
                            }
                            else if (hinhThucThanhToan == "momo")
                            {
                                tongDoanhThuMomo += doanhThuHoaDon;
                            }
                            else if (hinhThucThanhToan == "chuyển khoản")
                            {
                                tongDoanhThuChuyenKhoan += doanhThuHoaDon;
                            }
                        }
                    }

                    // Tạo DataTable để hiển thị doanh thu lên DataGridView
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Phương thức thanh toán", typeof(string));
                    dt.Columns.Add("Doanh thu", typeof(decimal));

                    // Thêm các dòng cho từng phương thức thanh toán
                    dt.Rows.Add("Tiền mặt", tongDoanhThuTienMat);
                    dt.Rows.Add("Momo", tongDoanhThuMomo);
                    dt.Rows.Add("Chuyển khoản", tongDoanhThuChuyenKhoan);

                    // Tính tổng doanh thu của cả 3 phương thức
                    decimal tongDoanhThu = tongDoanhThuTienMat + tongDoanhThuMomo + tongDoanhThuChuyenKhoan;
                    dt.Rows.Add("Tổng doanh thu", tongDoanhThu);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    dgvRevenueReport.DataSource = dt;

                    // Hiển thị thông báo
                    MessageBox.Show($"Doanh thu tổng thể: {tongDoanhThu:C}", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không có hóa đơn nào trong cơ sở dữ liệu.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính doanh thu tổng thể: " + ex.Message, "Lỗi");
            }
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
                        THOIGIAN = hoadon.THOIGIAN?.ToString("dd-MM-yyyy hh:mm:ss") ?? "N/A", // Thời gian (kiểm tra null)
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

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHoaDon.CurrentRow != null)
            {
                string maHoaDon = dgvChiTietHoaDon.CurrentRow.Cells["MAHD"].Value.ToString();
                HienThiChiTietHoaDon(maHoaDon);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trước!", "Thông báo");
            }
        }

        private void frmRevenueReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvRevenueReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem bạn có đang làm việc với bảng doanh thu tổng thể không
            if (dgvRevenueReport.Columns.Count > 0 && e.RowIndex >= 0)
            {
                // Kiểm tra nếu bạn đang làm việc với cột tổng doanh thu (không có cột MAHD ở đây)
                if (dgvRevenueReport.Columns[e.ColumnIndex].Name == "Doanh thu")
                {
                    // Không làm gì khi nhấn vào cột "Doanh thu" của tổng doanh thu
                    return;
                }

                // Nếu bạn không nhấn vào cột tổng doanh thu, tiếp tục với cột MAHD
                try
                {
                    // Kiểm tra nếu cột MAHD tồn tại trong DataGridView
                    string maHoaDon = dgvRevenueReport.Rows[e.RowIndex].Cells["MAHD"].Value.ToString();

                    // Gọi hàm hiển thị chi tiết hóa đơn
                    HienThiChiTietHoaDon(maHoaDon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy mã hóa đơn: " + ex.Message, "Lỗi");
                }
            }
        }
        private void HienThiChiTietHoaDon(string maHoaDon)
        {
            try
            {
                // Tạo một instance của CTHDService
                CTHDService cthdService = new CTHDService();

                // Gọi phương thức GetByInvoiceId thông qua đối tượng
                var chiTietHoaDon = cthdService.GetByInvoiceId(maHoaDon);

                if (chiTietHoaDon != null && chiTietHoaDon.Count > 0)
                {
                    // Định dạng dữ liệu để hiển thị
                    var danhSachHienThi = chiTietHoaDon.Select(cthd => new
                    {
                        cthd.MAHD,                   // Mã hóa đơn
                        cthd.MASP,                   // Mã sản phẩm
                        TENSP = cthd.SANPHAM.TENSP,  // Tên sản phẩm từ bảng liên quan
                        cthd.SL,                     // Số lượng
                        cthd.GIATIEN                 // Giá tiền
                    }).ToList();

                    // Cập nhật DataGridView
                    dgvChiTietHoaDon.DataSource = danhSachHienThi;

                    // Định nghĩa lại cột trong DataGridView
                    dgvChiTietHoaDon.AutoGenerateColumns = false; // Tắt tự động tạo cột
                    dgvChiTietHoaDon.Columns.Clear(); // Xóa các cột cũ

                    dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "MAHD",
                        HeaderText = "Mã hóa đơn",
                        Name = "MAHD",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "MASP",
                        HeaderText = "Mã sản phẩm",
                        Name = "MASP",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TENSP",
                        HeaderText = "Tên sản phẩm",
                        Name = "TENSP",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "SL",
                        HeaderText = "Số lượng",
                        Name = "SL",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });

                    dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "GIATIEN",
                        HeaderText = "Giá tiền",
                        Name = "GIATIEN",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });
                }
                else
                {
                    dgvChiTietHoaDon.DataSource = null;
                    MessageBox.Show("Không có chi tiết hóa đơn cho mã hóa đơn này.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết hóa đơn: " + ex.Message, "Lỗi");
            }
        }
    }
}
