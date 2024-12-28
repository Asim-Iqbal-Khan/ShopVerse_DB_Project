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
    public partial class AdminManagesSeller : Form
    {
        public AdminManagesSeller()
        {
            InitializeComponent();
        }

        private void AdminManagesSeller_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sellerManagement.Seller' table. You can move, or remove it, as needed.
            this.sellerTableAdapter.Fill(this.sellerManagement.Seller);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the UserID of the selected seller
                int userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["userIDDataGridViewTextBoxColumn"].Value);

                // Show a confirmation dialog for approval or disapproval
                DialogResult dialogResult = MessageBox.Show(
                    $"Do you want to approve or disapprove the seller with UserID : {userId}?press yes to approve and no to disapprove",
                    "Approve or Disapprove",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes) // Approve
                {
                    ApproveSeller(userId);
                }
                else if (dialogResult == DialogResult.No) // Disapprove
                {
                    RemoveSeller(userId);
                }
                else
                {
                    MessageBox.Show("Action canceled.");
                }
            }
        }
        private void ApproveSeller(int userId)
        {
            string query = "UPDATE Seller SET ApprovalStatus = 1 WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Seller approved successfully.");

                    // Refresh the DataGridView
                    this.sellerTableAdapter.Fill(this.sellerManagement.Seller);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
        private void RemoveSeller(int userId)
        {
            string query = "DELETE FROM Seller WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Seller removed successfully.");

                    // Refresh the DataGridView
                    this.sellerTableAdapter.Fill(this.sellerManagement.Seller);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }


    }
}
