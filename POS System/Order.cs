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
                    if (!row.IsNewRow)  // Ensure the row is not empty
                    {
                        // Ensure columns are available before accessing
                        if (dgvGioHang.Columns.Contains("Mã SP") &&
                            dgvGioHang.Columns.Contains("Tên SP") &&
                            dgvGioHang.Columns.Contains("Giá") &&
                            dgvGioHang.Columns.Contains("SL") &&
                            dgvGioHang.Columns.Contains("Thành tiền"))
                        {
                            items.Add(new SANPHAM
                            {
                                MASP = row.Cells["Mã SP"].Value.ToString(),
                                TENSP = row.Cells["Tên SP"].Value.ToString(),
                                SL = Convert.ToInt32(row.Cells["SL"].Value),
                                GIATIEN = Convert.ToDecimal(row.Cells["Giá"].Value), // Correct name for Giá
                            });
                        }
                        else
                        {
                            MessageBox.Show("One or more columns are missing in DataGridView", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                // Lấy dữ liệu sản phẩm từ SanPhamService
                List<POS_DAL.Models.SANPHAM> productsData = sanPhamService.GetProducts();

                // Chuyển đổi List thành DataTable
                DataTable productTable = ConvertToDataTable(productsData);

                // Duyệt qua danh sách sản phẩm và tạo các nút
                for (int i = 0; i < productTable.Rows.Count; i++)
                {
                    string productName = productTable.Rows[i]["TenSP"].ToString();
                    int productPrice = Convert.ToInt32(productTable.Rows[i]["Gia"]);

                    Button productButton = new Button
                    {
                        Size = new Size(100, 70),
                        BackColor = Color.White,
                        Text = $"{productName}\n{productPrice} VND",
                        Tag = i // Lưu vị trí sản phẩm hoặc ID
                    };

                    int row = i / 5;
                    int col = i % 5;
                    productButton.Location = new Point(20 + col * 100, 100 + row * 70);

                    productButton.Click += new EventHandler(ChooseProducts);
                    p_Sanpham.Controls.Add(productButton);
                }
            }

            private void ChooseProducts(object sender, EventArgs e)
            {
                //Button btn = sender as Button;
                //int productIndex = (int)btn.Tag;

                //// Lấy thông tin sản phẩm
                //List<POS_DAL.Models.SANPHAM> productsData = sanPhamService.GetProducts();
                //string productName = productsData[productIndex].TENSP;
                //int productPrice = (int)productsData[productIndex].GIATIEN;

                //// Kiểm tra sản phẩm đã có trong DataGridView chưa
                //DataRow existingRow = selectedProductsTable.AsEnumerable()
                //    .FirstOrDefault(row => row["Tên SP"].ToString() == productName);

                //if (existingRow == null)
                //{
                //    selectedProductsTable.Rows.Add(productName, productPrice, 1, productPrice, "M", "Không có ghi chú");
                //}
                //else
                //{
                //    int quantity = (int)existingRow["SL"] + 1;
                //    existingRow["SL"] = quantity;
                //    existingRow["Thành tiền"] = quantity * productPrice;
                //}

                //UpdateTotalPrice();
                //UpdateTotalItems();
                Button btn = sender as Button;
                int productIndex = (int)btn.Tag;

                // Get product information
                List<POS_DAL.Models.SANPHAM> productsData = sanPhamService.GetProducts();
                string productID = productsData[productIndex].MASP;
                string productName = productsData[productIndex].TENSP;
                int productPrice = (int)productsData[productIndex].GIATIEN;

                // Check if the product already exists in the DataGridView
                DataRow existingRow = selectedProductsTable.AsEnumerable()
                    .FirstOrDefault(row => row["Tên SP"].ToString() == productName);

                if (existingRow == null)
                {
                    selectedProductsTable.Rows.Add(productID, productName, productPrice, 1, productPrice, "M", "Không có ghi chú");
                }
                else
                {
                    int quantity = (int)existingRow["SL"] + 1;
                    existingRow["SL"] = quantity;
                    existingRow["Thành tiền"] = quantity * productPrice;
                }

                UpdateTotalPrice();
                UpdateTotalItems();
            }

            private void UpdateTotalPrice()
            {
                //int total = selectedProductsTable.AsEnumerable()
                //    .Sum(row => (int)row["Thành tiền"]);

                //lbl_Thanhtien.Text = total.ToString("N0") + " VND";
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

                    Label lblSize = new Label { Text = "Size:", Location = new Point(20, 60), AutoSize = true };
                    ComboBox comboSize = new ComboBox { Location = new Point(100, 60), Width = 150 };
                    comboSize.Items.AddRange(new string[] { "S", "M", "L" });
                    comboSize.SelectedItem = currentSize;

                    Label lblNote = new Label { Text = "Ghi chú:", Location = new Point(20, 100), AutoSize = true };
                    TextBox txtNote = new TextBox { Text = currentNote, Location = new Point(100, 100), Width = 150 };

                    Button btnOK = new Button { Text = "OK", Location = new Point(100, 150), Width = 80 };

                    btnOK.Click += (s, args) =>
                    {
                        // Kiểm tra và cập nhật dữ liệu
                        if (int.TryParse(txtQuantity.Text, out int newQuantity) && newQuantity > 0)
                        {
                            selectedRow.Cells["SL"].Value = newQuantity;
                            selectedRow.Cells["Thành tiền"].Value = newQuantity * productPrice;
                            selectedRow.Cells["Size"].Value = comboSize.SelectedItem.ToString();
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
                    inputForm.Controls.Add(lblSize);
                    inputForm.Controls.Add(comboSize);
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
                //// Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
                //if (dgvGioHang.SelectedRows.Count > 0)
                //{
                //    // Hiển thị hộp thoại xác nhận xóa món
                //    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //    if (result == DialogResult.Yes)
                //    {
                //        // Xóa tất cả các dòng đã chọn
                //        foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                //        {
                //            dgvGioHang.Rows.RemoveAt(row.Index);
                //        }

                //        // Cập nhật lại tổng tiền
                //        UpdateTotalPrice();
                //        UpdateTotalItems();  // Cập nhật tổng số món
                //    }
                //}
                //else
                //{
                //    // Nếu không có dòng nào được chọn, hiển thị thông báo
                //    MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
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

                // Duyệt qua tất cả các control trong p_Sanpham
                foreach (Control control in p_Sanpham.Controls)
                {
                    if (control is Button button)
                    {
                        // Kiểm tra văn bản trên Button (tên sản phẩm)
                        if (button.Text.ToLower().Contains(filterText))
                        {
                            // Hiển thị nút nếu khớp
                            button.Visible = true;
                        }
                        else
                        {
                            // Ẩn nút nếu không khớp
                            button.Visible = false;
                        }
                    }
                }
            }

            private void cmb_Danhmuc_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selectedCategory = cmb_Danhmuc.SelectedItem.ToString();

                // Duyệt qua tất cả các Button trong p_Sanpham
                foreach (Control control in p_Sanpham.Controls)
                {
                    if (control is Button button)
                    {
                        // Hiển thị tất cả nếu chọn "Tất cả"
                        if (selectedCategory == "Tất cả sản phẩm")
                        {
                            button.Visible = true;
                        }
                        else
                        {
                            // Kiểm tra nếu Button.Text khớp với danh mục
                            if (button.Text.Contains(selectedCategory))
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
            }

            private void frmOrder_Load(object sender, EventArgs e)
            {
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
