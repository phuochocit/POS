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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "9";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_Matkhau.Text += "0";
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_Matkhau.Text.Length > 0)
            {
                txt_Matkhau.Text = txt_Matkhau.Text.Substring(0, txt_Matkhau.Text.Length - 1);
            }
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (txt_Matkhau.Text == "123") // Replace "1234" with your desired password
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmHomepage mainForm = new frmHomepage();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mật khẩu sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_Dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frm_Dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}