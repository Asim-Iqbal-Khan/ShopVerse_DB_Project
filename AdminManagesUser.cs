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
    public partial class AdminManagesUser : Form
    {
        public AdminManagesUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminManagesUser_Load(object sender, EventArgs e)
        {
            

            // TODO: This line of code loads data into the 'shopVerseDataSet1.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.shopVerseDataSet1.Customer);

            string columnNames = "Columns in DataGridView:\n";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames += column.Name + "\n";
            }
            MessageBox.Show(columnNames);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Use the actual column name as it appears in the DataGridView
                var userId = dataGridView1.Rows[e.RowIndex].Cells["userIDDataGridViewTextBoxColumn"].Value;

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove User ID: {userId}?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    RemoveCustomer(Convert.ToInt32(userId));
                }
            }
        }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        private void RemoveCustomer(int userId)
        {
            string query = "DELETE FROM Customer WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer removed successfully.");

                        // Refresh the DataGridView
                        this.customerTableAdapter.Fill(this.shopVerseDataSet1.Customer);
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }


    }
}
