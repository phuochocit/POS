using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class frmHomepage : Form
    {
        private bool isInShift = false;

        public frmHomepage()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            // Kiểm tra trước khi thoát
            if (isInShift)
            {
                MessageBox.Show("Bạn cần kết ca trước khi thoát chương trình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thoát chương trình
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát chương trình
            }
        }

        private void frmHomepage_Load(object sender, EventArgs e)
        {
            btn_Order.Enabled = false; // Vô hiệu hóa nút Order khi chưa vào ca
        }

        private void frmHomepage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btn_Order_Click(object sender, EventArgs e)
        {
            if (!isInShift)
            {
                MessageBox.Show("Bạn phải vào ca trước khi đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuyển sang form Order
            frmOrder orderForm = new frmOrder(this); // Truyền tham chiếu của frmHomepage
            this.Hide();
            orderForm.Show();
        }

        private void btn_VaoKetca_Click(object sender, EventArgs e)
        {
            if (isInShift)
            {
                // Nếu đang trong ca -> Kết ca
                string endTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                MessageBox.Show("Ngày giờ kết ca: " + endTime, "Thông tin ca làm việc", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật trạng thái và nút
                btn_VaoKetca.Text = "Vào ca";
                isInShift = false;
                btn_Order.Enabled = false; // Disable nút Order
            }
            else
            {
                // Nếu không trong ca -> Vào ca
                string startTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                MessageBox.Show("Ngày giờ vào ca: " + startTime, "Thông tin ca làm việc", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật trạng thái và nút
                btn_VaoKetca.Text = "Kết ca";
                isInShift = true;
                btn_Order.Enabled = true; // Enable nút Order
            }
        }

        private void btn_Baocaodoanhthu_Click(object sender, EventArgs e)
        {
            try
            {
                frmRevenueReport revenueReportForm = new frmRevenueReport(this);
                this.Hide();
                revenueReportForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Xemlaiphieu_Click(object sender, EventArgs e)
        {
            frmHistory historyForm = new frmHistory(this);
            this.Hide();
            historyForm.Show();
        }

        private void btn_Thuchikhac_Click(object sender, EventArgs e)
        {
            // TODO: Thêm logic xử lý cho nút Thu chi khác
            MessageBox.Show("Chức năng đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Chamcong_Click(object sender, EventArgs e)
        {
            // TODO: Thêm logic xử lý cho nút Chấm công
            MessageBox.Show("Chức năng đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmHomepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
