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
    public partial class Customer_Review : Form
    {
        public Customer_Review()
        {
            InitializeComponent();
            LoadProductsForReview();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //not that proud of it but scored 192/200

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadProductsForReview()
        {
            int customerId = Session.UserID;
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var query = @"
                    SELECT p.ProductID, p.Name
                    FROM OrderItem oi
                     JOIN Product p ON oi.ProductID = p.ProductID
                     JOIN OrderTable o ON oi.OrderID = o.OrderID
                    WHERE o.CustomerID = @CustomerID AND o.Status = 'Delivered' AND NOT EXISTS (
                        SELECT * FROM Review r WHERE r.ProductID = p.ProductID AND r.CustomerID = o.CustomerID
                    )";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void submitButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int productId;
            if (!int.TryParse(textBox2.Text, out productId))
            {
                MessageBox.Show("Invalid Product ID.");
                return;
            }

            decimal rating;
            if (!decimal.TryParse(comboBox1.SelectedItem.ToString(), out rating) || rating < 0 || rating > 5)
            {
                MessageBox.Show("Invalid Rating. Please choose a valid rating.");
                return;
            }

            string reviewContent = textBox1.Text;
            int customerId = Session.UserID;

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var query = @"
                    INSERT INTO Review (Content, Rating, ReviewDate, CustomerID, ProductID)
                    VALUES (@Content, @Rating, @ReviewDate, @CustomerID, @ProductID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Content", reviewContent);
                    cmd.Parameters.AddWithValue("@Rating", rating);
                    cmd.Parameters.AddWithValue("@ReviewDate", DateTime.Today);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Review submitted successfully!");
            LoadProductsForReview();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Menu customerMenu= new Customer_Menu("");
            customerMenu.Show();
            this.Hide();
        }

        private void Customer_Review_Load(object sender, EventArgs e)
        {

        }
    }
}
