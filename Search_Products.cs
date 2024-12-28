using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DB_Project
{
    public partial class Search_Products : Form
    {

        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        public Search_Products()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeComboBoxes();
            searchBar.TextChanged += searchBar_TextChanged;
            SearchFilter.SelectedIndexChanged += searchBar_TextChanged;
            SortBy.SelectedIndexChanged += searchBar_TextChanged;
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = new DataTable();
        }

        private void InitializeComboBoxes()
        {
            SearchFilter.Items.AddRange(new string[] { "Product Name", "Category Name", "Product ID" });
            SearchFilter.SelectedIndex = 0;  // Default to 'Product Name'

            SortBy.Items.AddRange(new string[] { "Price Low to High", "Price High to Low" });
            SortBy.SelectedIndex = 0;  // Default to 'Price Low to High'
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            UpdateSearchResults(searchBar.Text);
        }

        private void UpdateSearchResults(string searchText)
        {
            string orderBy = SortBy.SelectedItem.ToString() == "Price Low to High" ? "ASC" : "DESC";
            string query = "";

            switch (SearchFilter.SelectedItem.ToString())
            {
                case "Product Name":
                    query = $@"SELECT p.ProductID, p.Name AS ProductName, c.Name AS CategoryName, p.Price
                               FROM Product p
                               INNER JOIN Category c ON p.CategoryID = c.CategoryID
                               WHERE p.Name LIKE @SearchText
                               ORDER BY p.Price {orderBy}";
                    break;
                case "Category Name":
                    query = $@"SELECT p.ProductID, p.Name AS ProductName, c.Name AS CategoryName, p.Price
                               FROM Product p
                               INNER JOIN Category c ON p.CategoryID = c.CategoryID
                               WHERE c.Name LIKE @SearchText
                               ORDER BY p.Price {orderBy}";
                    break;
                case "Product ID":
                    if (int.TryParse(searchText, out int productId))
                    {
                        query = $@"SELECT p.ProductID, p.Name AS ProductName, c.Name AS CategoryName, p.Price
                                   FROM Product p
                                   INNER JOIN Category c ON p.CategoryID = c.CategoryID
                                   WHERE p.ProductID = {productId}
                                   ORDER BY p.Price {orderBy}";
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", '%' + searchText + '%');

                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                    dataGridView1.DataSource = dt;
                }
            }
        }



        private void SearchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value);
                OpenProductDetail(productId);
            }
        }

        private void OpenProductDetail(int productId)
        {
            // Fetch product and category details
            Product product = new Product();
            Category category = new Category();

            using (var cmd = new SqlCommand("SELECT p.*, c.Name AS CategoryName, c.Description AS CategoryDescription FROM Product p INNER JOIN Category c ON p.CategoryID = c.CategoryID WHERE p.ProductID = @ProductID", conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product.ProductID = productId;
                        product.Name = reader["Name"].ToString();
                        product.Description = reader["Description"].ToString();
                        product.Price = (decimal)reader["Price"];
                        product.Image = reader["Image"] as byte[];
                        product.Stock = (int)reader["Stock"];
                        product.SellerID = (int)reader["SellerID"];
                        product.CategoryID = (int)reader["CategoryID"];

                        category.CategoryID = product.CategoryID;
                        category.Name = reader["CategoryName"].ToString();
                        category.Description = reader["CategoryDescription"].ToString();
                    }
                }
                conn.Close();
            }

            ProductDetail productDetailForm = new ProductDetail(product, category);
            productDetailForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Menu cm = new Customer_Menu("");
            cm.Show();
            this.Hide();

        }
    }
}
