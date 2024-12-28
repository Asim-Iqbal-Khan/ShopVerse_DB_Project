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
    public partial class AdminManagesCategory : Form
    {
        public AdminManagesCategory()
        {
            InitializeComponent();
        }





        private void AdminManagesCategory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopVerseDataSet3.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.shopVerseDataSet3.Category);

        }

        private void Description_TextChanged(object sender, EventArgs e)
        {

        }

        private void CategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the CategoryID of the selected category
                int categoryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CategoryIDDataGridViewTextBoxColumn"].Value);

                // Show a confirmation dialog
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove the category with ID: {categoryId}?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    RemoveCategory(categoryId);

                    // Refresh the DataGridView
                    this.categoryTableAdapter.Fill(this.shopVerseDataSet3.Category);
                }
            }
        }

        private void RemoveCategory(int categoryId)
        {
            string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"; // Replace with your actual connection string
            string query = "DELETE FROM Category WHERE CategoryID = @CategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Category removed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void ManageCategories_Click(object sender, EventArgs e)
        {
            string categoryName = CategoryName.Text.Trim(); // TextBox for Category Name
            string description = Description.Text.Trim();   // TextBox for Description

            // Validate input
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Category Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the category name already exists
            if (CategoryExists(categoryName))
            {
                MessageBox.Show("This category already exists. Please enter a unique category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the new category to the database
            AddCategory(categoryName, description);

            // Refresh the DataGridView
            this.categoryTableAdapter.Fill(this.shopVerseDataSet3.Category);

            // Clear input fields
            CategoryName.Clear();
            Description.Clear();

            MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CategoryExists(string categoryName)
        {
            string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"; // Replace with your actual connection string
            string query = "SELECT COUNT(*) FROM Category WHERE Name = @CategoryName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Return true if the category exists
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }

        private void AddCategory(string categoryName, string description)
        {
            string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"; // Replace with your actual connection string
            string query = "INSERT INTO Category (Name, Description) VALUES (@CategoryName, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                command.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void s(object sender, EventArgs e)
        {

        }
    }
}
