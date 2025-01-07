    using POS_BUS;
    using POS_DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

    namespace POS_System
    {
        public partial class frmOrder : Form
        {
            private readonly SanPhamService sanPhamService = new SanPhamService();
            public DataTable selectedProductsTable;
            private frmHomepage parentForm;
            public frmOrder(frmHomepage parent)
            {
                InitializeComponent();
                this.parentForm = parent;
                InitializeDataGridView();
                CreateProducts();
            }
            public List<SANPHAM> GetCartItems()
            {
            List<SANPHAM> items = new List<SANPHAM>();

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (!row.IsNewRow && row.Cells["Mã SP"].Value != null)  // Đảm bảo không lấy dòng trống
                {
                    items.Add(new SANPHAM
                    {
                        MASP = row.Cells["Mã SP"].Value.ToString(),
                        TENSP = row.Cells["Tên SP"].Value.ToString(),
                        SL = Convert.ToInt32(row.Cells["SL"].Value),
                        GIATIEN = Convert.ToDecimal(row.Cells["Giá"].Value),
                    });
                }
            }

            return items;
        }
            private void InitializeDataGridView()
            {
                // Create the table to store selected products
                selectedProductsTable = new DataTable();
                selectedProductsTable.Columns.Add("Mã SP", typeof(string));     // Column for MASP
                selectedProductsTable.Columns.Add("Tên SP", typeof(string));    // Column for TENSP
                selectedProductsTable.Columns.Add("Giá", typeof(int));         // Column for Giá
                selectedProductsTable.Columns.Add("SL", typeof(int));          // Column for SL
                selectedProductsTable.Columns.Add("Thành tiền", typeof(int)); // Column for Thành tiền
                selectedProductsTable.Columns.Add("Size", typeof(string));     // Column for Size
                selectedProductsTable.Columns.Add("Ghi chú", typeof(string));  // Column for Ghi chú

                // Bind the table to the DataGridView
                dgvGioHang.DataSource = selectedProductsTable;

                // Customize DataGridView
                dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvGioHang.AllowUserToAddRows = false;
                dgvGioHang.ReadOnly = true;
            }

            private DataTable ConvertToDataTable(List<POS_DAL.Models.SANPHAM> products)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TenSP", typeof(string));
                dt.Columns.Add("Gia", typeof(int));

                foreach (var product in products)
                {
                    dt.Rows.Add(product.TENSP, product.GIATIEN);
                }

                return dt;
            }

            private void CreateProducts()
            {
            List<SANPHAM> productsData = sanPhamService.GetProducts();

            for (int i = 0; i < productsData.Count; i++)
            {
                string productName = productsData[i].TENSP;
                int productPrice = Convert.ToInt32(productsData[i].GIATIEN);

                // Lấy danh mục của sản phẩm
                string category = GetProductCategory(productName);

                Button productButton = new Button
                {
                    Size = new Size(100, 70),
                    BackColor = Color.White,
                    Text = $"{productName}\n{productPrice} VND",
                    Tag = productName // Gắn tên sản phẩm vào Tag
                };

                int row = i / 5;
                int col = i % 5;
                productButton.Location = new Point(20 + col * 100, 100 + row * 70);

                productButton.Click += new EventHandler(ChooseProducts);
                p_Sanpham.Controls.Add(productButton);
            }
        }

        private string GetProductCategory(string productName)
        {
            foreach (var category in productCategories)
            {
                if (category.Value.Contains(productName)) // Kiểm tra tên sản phẩm có nằm trong danh mục không
                {
                    return category.Key; // Trả về tên loại sản phẩm
                }
            }
            return "Khác"; // Trường hợp sản phẩm không thuộc danh mục nào
        }

        private void ChooseProducts(object sender, EventArgs e)
            {
            Button btn = sender as Button;

            // Kiểm tra nút không bị null và Tag có chứa tên sản phẩm
            if (btn != null && btn.Tag != null)
            {
                string productName = btn.Text.Split('\n')[0]; // Lấy tên sản phẩm từ Text
                List<SANPHAM> productsData = sanPhamService.GetProducts();

                // Lấy thông tin sản phẩm theo tên
                SANPHAM selectedProduct = productsData.FirstOrDefault(p => p.TENSP == productName);

                if (selectedProduct != null)
                {
                    string productID = selectedProduct.MASP;
                    int productPrice = (int)selectedProduct.GIATIEN;

                    // Kiểm tra xem sản phẩm đã tồn tại trong DataGridView chưa
                    DataRow existingRow = selectedProductsTable.AsEnumerable()
                        .FirstOrDefault(row => row["Mã SP"].ToString() == productID);

                    if (existingRow == null)
                    {
                        // Thêm sản phẩm mới vào bảng
                        selectedProductsTable.Rows.Add(
                            productID,
                            productName,
                            productPrice,
                            1,                        // Số lượng mặc định là 1
                            productPrice,             // Thành tiền = Giá x Số lượng
                            "M",                      // Size mặc định
                            "Không có ghi chú"        // Ghi chú mặc định
                        );
                    }
                    else
                    {
                        // Cập nhật số lượng và thành tiền cho sản phẩm đã tồn tại
                        int quantity = (int)existingRow["SL"] + 1;
                        existingRow["SL"] = quantity;
                        existingRow["Thành tiền"] = quantity * productPrice;
                    }

                    UpdateTotalPrice();
                    UpdateTotalItems();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không thể xác định sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void UpdateTotalPrice()
            {
                int total = selectedProductsTable.AsEnumerable()
                .Sum(row => (int)row["Thành tiền"]);
                lbl_Thanhtien.Text = total.ToString("N0") + " VND";
            }
            private void UpdateTotalItems()
            {
                int totalItems = 0;
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (row.Cells["SL"].Value != null && row.Cells["SL"].Value.ToString() != "")
                    {
                        totalItems += Convert.ToInt32(row.Cells["SL"].Value);
                    }
                }

                lbl_SL.Text = totalItems.ToString();
            }
        
            public void ResetCart()
            {
                selectedProductsTable.Clear();
                lbl_Thanhtien.Text = "0 VND";
                lbl_SL.Text = "0";
            }
        
            private void btn_Thanhtoan_Click(object sender, EventArgs e)
            {
                string tongTienChuoi = lbl_Thanhtien.Text.Replace(" VND", "").Replace(".", "").Trim();
                string khach = cmbKhach.SelectedItem?.ToString() ?? " ";
                string sl = lbl_SL.Text.Trim();
                List<SANPHAM> cartItems = GetCartItems();
                DataTable selectedProductsTable = new DataTable();

                foreach (DataGridViewColumn column in dgvGioHang.Columns)
                {
                    selectedProductsTable.Columns.Add(column.Name, column.ValueType);
                }

                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataRow dataRow = selectedProductsTable.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dataRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;
                        }
                        selectedProductsTable.Rows.Add(dataRow);
                    }
                }

                if (int.TryParse(tongTienChuoi, out int tongTien) && tongTien > 0)
                {
                    string tienBangChu = ConvertNumberToWords(tongTien);

                    frmPay payForm = new frmPay(tongTienChuoi, tienBangChu, khach, sl, this, cartItems,selectedProductsTable);
                    payForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Chưa có đơn hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private string ConvertNumberToWords(int number)
            {
                if (number == 0)
                    return "Không đồng";

                string[] units = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string[] tens = { "", "", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string result = "";

                int billion = number / 1000000000;
                number %= 1000000000;

                int million = number / 1000000;
                number %= 1000000;

                int thousand = number / 1000;
                number %= 1000;

                int hundred = number / 100;
                number %= 100;

                if (billion > 0)
                    result += $"{ConvertNumberToWords(billion)} tỷ ";

                if (million > 0)
                    result += $"{ConvertNumberToWords(million)} triệu ";

                if (thousand > 0)
                    result += $"{ConvertNumberToWords(thousand)} nghìn ";

                if (hundred > 0)
                    result += $"{units[hundred]} trăm ";

                if (number > 0)
                {
                    if (number < 10)
                        result += $"{units[number]}";
                    else if (number < 20)
                        result += $"mười {units[number % 10]}";
                    else
                        result += $"{tens[number / 10]} mươi {units[number % 10]}";
                }

                return result.Trim() + " đồng";
            }

            private void btn_Sua_Click(object sender, EventArgs e)
            {
                if (dgvGioHang.SelectedRows.Count > 0)
                {
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = dgvGioHang.SelectedRows[0];
                    string productName = selectedRow.Cells["Tên SP"].Value.ToString();
                    int currentQuantity = (int)selectedRow.Cells["SL"].Value;
                    int productPrice = (int)selectedRow.Cells["Giá"].Value;
                    string currentSize = selectedRow.Cells["Size"].Value.ToString();
                    string currentNote = selectedRow.Cells["Ghi chú"].Value.ToString();

                    // Tạo form nhập liệu
                    Form inputForm = new Form
                    {
                        Text = "Chỉnh sửa sản phẩm",
                        Size = new Size(300, 250),
                        StartPosition = FormStartPosition.CenterParent
                    };

                    Label lblQuantity = new Label { Text = "Số lượng:", Location = new Point(20, 20), AutoSize = true };
                    TextBox txtQuantity = new TextBox { Text = currentQuantity.ToString(), Location = new Point(100, 20), Width = 150 };

                    

                    Label lblNote = new Label { Text = "Ghi chú:", Location = new Point(20, 60), AutoSize = true };
                    TextBox txtNote = new TextBox { Text = currentNote, Location = new Point(100, 60), Width = 150 };

                    Button btnOK = new Button { Text = "OK", Location = new Point(100, 150), Width = 80 };

                    btnOK.Click += (s, args) =>
                    {
                        // Kiểm tra và cập nhật dữ liệu
                        if (int.TryParse(txtQuantity.Text, out int newQuantity) && newQuantity > 0)
                        {
                            selectedRow.Cells["SL"].Value = newQuantity;
                            selectedRow.Cells["Thành tiền"].Value = newQuantity * productPrice;                     
                            selectedRow.Cells["Ghi chú"].Value = txtNote.Text;

                            UpdateTotalPrice(); // Cập nhật tổng tiền
                            UpdateTotalItems();  // Cập nhật tổng số món
                            inputForm.Close();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập một số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    // Thêm các control vào form
                    inputForm.Controls.Add(lblQuantity);
                    inputForm.Controls.Add(txtQuantity);

                    inputForm.Controls.Add(lblNote);
                    inputForm.Controls.Add(txtNote);
                    inputForm.Controls.Add(btnOK);

                    inputForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private void btn_Xoa_Click(object sender, EventArgs e)
            {
                if (dgvGioHang.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                        {
                            dgvGioHang.Rows.RemoveAt(row.Index);
                        }

                        UpdateTotalPrice();
                        UpdateTotalItems();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private void btn_Hompage_Click(object sender, EventArgs e)
            {
                this.Hide();
                parentForm.Show();
            }

            private void txt_Timsp_TextChanged(object sender, EventArgs e)
            {
            string filterText = txt_Timsp.Text.Trim().ToLower();

            foreach (Control control in p_Sanpham.Controls)
            {
                if (control is Button button)
                {
                    // So sánh tên sản phẩm trong Text
                    string productName = button.Text.Split('\n')[0].ToLower();

                    if (productName.Contains(filterText))
                    {
                        button.Visible = true;
                    }
                    else
                    {
                        button.Visible = false;
                    }
                }
            }
        }

            private void cmb_Danhmuc_SelectedIndexChanged(object sender, EventArgs e)
            {
            string selectedCategory = cmb_Danhmuc.SelectedItem.ToString();

            foreach (Control control in p_Sanpham.Controls)
            {
                if (control is Button button)
                {
                    string productCategory = GetProductCategory(button.Text.Split('\n')[0]);

                    if (selectedCategory == "Tất cả sản phẩm" || productCategory == selectedCategory)
                    {
                        button.Visible = true;
                    }
                    else
                    {
                        button.Visible = false;
                    }
                }
            }
        }
        private Dictionary<string, List<string>> productCategories = new Dictionary<string, List<string>>()
{
    { "Topping", new List<string> { "Hạt đác", "Trân châu trắng", "Trân châu Ô Long", "Trân châu đường đen", "Trái Vải", "Đào miếng", "Mứt nho", "Xí muội", "Kem Cheese" } }
};
        private void frmOrder_Load(object sender, EventArgs e)
            {
            // Thêm các loại sản phẩm vào ComboBox
                cmb_Danhmuc.Items.Add("Tất cả sản phẩm"); // Tùy chọn "Tất cả sản phẩm"
                cmb_Danhmuc.Items.Add("Topping");
               
                cmb_Danhmuc.SelectedIndex = 0; // Đặt giá trị mặc định cho ComboBox

                cmbKhach.Items.Add("Khách lẻ");
                cmbKhach.Items.Add("Khách sỉ");
                cmbKhach.SelectedIndex = 0;
                lbl_Vaoca.Text = "Vào ca: " + DateTime.Now.ToString("dd/MM/yyyy, HH:mm:ss");
                lbl_SL.Text = "0";
            }

            private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
            {
                parentForm.Show(); // Hiển thị lại frmHomepage khi form con đóng
            }

        private void frmOrder_FormClosed(object sender, FormClosedEventArgs e)
         {
             Application.Exit();
         }
     }
    }
