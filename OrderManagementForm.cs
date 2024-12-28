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
    public partial class OrderManagementForm : Form
    {
        public OrderManagementForm()
        {
            InitializeComponent();
            LoadOrders();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        SqlCommand cmd;

        private void LoadOrders()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = @"
            SELECT 
                oi.OrderItemID, 
                oi.OrderID, 
                p.Name AS ProductName, 
                oi.Quantity, 
                oi.Price, 
                oi.ApprovedBySeller
            FROM OrderItem oi
            INNER JOIN Product p ON oi.ProductID = p.ProductID
            WHERE oi.SellerID = @SellerID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SellerID", Session.UserID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                // Get OrderItemID from the selected row
                int orderItemId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["OrderItemID"].Value);

                // Show a confirmation dialog
                DialogResult result = MessageBox.Show(
                    "Do you want to approve this order?",
                    "Order Approval",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    ApproveOrder(orderItemId);
                }
                else if (result == DialogResult.No)
                {
                    DisapproveOrder(orderItemId);
                }
            }
        }

        private void ApproveOrder(int orderItemId)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE OrderItem SET ApprovedBySeller = 1 WHERE OrderItemID = @OrderItemID AND SellerID = @SellerID", conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@OrderItemID", orderItemId);
                    cmd.Parameters.AddWithValue("@SellerID", Session.UserID);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        using (SqlCommand stockCmd = new SqlCommand("UPDATE Product SET Stock = Stock - (SELECT Quantity FROM OrderItem WHERE OrderItemID = @OrderItemID) WHERE ProductID = (SELECT ProductID FROM OrderItem WHERE OrderItemID = @OrderItemID)", conn, transaction))
                        {
                            stockCmd.Parameters.AddWithValue("@OrderItemID", orderItemId);
                            stockCmd.ExecuteNonQuery();
                        }
                    string checkAllApprovedQuery = @"
                    IF NOT EXISTS (
                        SELECT * FROM OrderItem 
                        WHERE OrderID = (SELECT OrderID FROM OrderItem WHERE OrderItemID = @OrderItemID) 
                        AND ApprovedBySeller = 0
                    )
                    BEGIN
                        UPDATE OrderTable
                        SET Status = 'Approved'
                        WHERE OrderID = (SELECT OrderID FROM OrderItem WHERE OrderItemID = @OrderItemID)
                        AND Status = 'Pending'
                    END";

                        using (SqlCommand checkAllApprovedCmd = new SqlCommand(checkAllApprovedQuery, conn, transaction))
                        {
                            checkAllApprovedCmd.Parameters.AddWithValue("@OrderItemID", orderItemId);
                            checkAllApprovedCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Order approved successfully and stock updated!");
                        LoadOrders();
                    }
                    else
                    {
                        MessageBox.Show("Order not found or you do not have permission to approve it.");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving order: " + ex.Message);
                try
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        transaction?.Rollback();
                    }
                }
                catch
                {
                }
            }
            finally
            {
                conn.Close();
            }
        }




        private void DisapproveOrder(int orderItemId)
        {
            try
            {
                conn.Open();

                string query = "DELETE FROM OrderItem WHERE OrderItemID = @OrderItemID AND SellerID = @SellerID";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderItemID", orderItemId);
                cmd.Parameters.AddWithValue("@SellerID", Session.UserID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Order disapproved and removed successfully!");
                    LoadOrders();
                }
                else
                {
                    MessageBox.Show("Order not found or you do not have permission to disapprove it.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disapproving order: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
