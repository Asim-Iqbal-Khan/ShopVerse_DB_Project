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
    public partial class AdminOverseesOrders : Form
    {
        public AdminOverseesOrders()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminOverseesOrders_Load(object sender, EventArgs e)
        {
            this.orderTableTableAdapter.Fill(this.shopVerseDataSet4.OrderTable);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the OrderID of the selected order
                int orderId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["OrderIDDataGridViewTextBoxColumn"].Value);

                // Show a confirmation dialog
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove the order with OrderID: {orderId}?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    RemoveOrder(orderId);

                    // Refresh the DataGridView
                    this.orderTableTableAdapter.Fill(this.shopVerseDataSet4.OrderTable);
                }
            }
        }

        private void RemoveOrder(int orderId)
        {
            string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"; // Replace with your actual connection string
            string query = "DELETE FROM OrderTable WHERE OrderID = @OrderID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order removed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Order not found.");
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
