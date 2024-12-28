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
    public partial class AdminManagesProduct : Form
    {
        public AdminManagesProduct()
        {
            InitializeComponent();
        }

        private void AdminManagesProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopVerseDataSet5.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.shopVerseDataSet5.Product);
            // TODO: This line of code loads data into the 'productManagement.Product' table. You can move, or remove it, as needed.
            //this.productTableAdapter.Fill(this.productManagement.Product);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the ProductID of the selected product
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["productIDDataGridViewTextBoxColumn"].Value);

                // Show a confirmation dialog
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove the product with ProductID: {productId}?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Call the RemoveProduct method
                    RemoveProduct(productId);
                }
            }
        }

        private void RemoveProduct(int productId)
        {
            string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"; // Replace with your actual connection string
            string query = "DELETE FROM Product WHERE ProductID = @ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product removed successfully.");

                        // Refresh the DataGridView
                        this.productTableAdapter1.Fill(this.shopVerseDataSet5.Product);
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
