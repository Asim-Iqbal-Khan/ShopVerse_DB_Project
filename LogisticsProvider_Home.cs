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
    public partial class LogisticsProvider_Home : Form
    {
        private string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public LogisticsProvider_Home()
        {
            InitializeComponent();
            LoadApprovedOrders();
        }

        private void LoadApprovedOrders()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = @"
                SELECT o.OrderID, o.Date, o.Status, o.TotalAmount
                FROM OrderTable o
                WHERE NOT EXISTS (
                    SELECT *
                    FROM OrderItem oi
                    WHERE oi.OrderID = o.OrderID AND oi.ApprovedBySeller = 0
                ) AND o.Status NOT IN ('Shipped', 'Delivered')";
                using (var cmd = new SqlCommand(query, conn))
                {
                    DataTable dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    dataGridView1.DataSource = dt;
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PickupDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ExpectedDeliveryDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void OrderID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(OrderID.Text, out int orderId))
            {
                MessageBox.Show("Please enter a valid Order ID.");
                return;
            }

            var pickupDate = PickupDate.Value;
            var deliveryDate = ExpectedDeliveryDate.Value;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var updateQuery = @"
                UPDATE OrderTable
                SET Status = 'Shipped', PickupDate = @PickupDate, estimateDeliveryDate = @DeliveryDate
                WHERE OrderID = @OrderID AND Status NOT IN ('Shipped', 'Delivered')";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PickupDate", pickupDate);
                    cmd.Parameters.AddWithValue("@DeliveryDate", deliveryDate);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Order updated successfully.");
                        LoadApprovedOrders();
                    }
                    else
                    {
                        MessageBox.Show("No order was updated. Please check if the order ID is correct and the order is not already shipped or delivered.");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogisticsDeliverOrder logisticsDeliverOrder = new LogisticsDeliverOrder();
            logisticsDeliverOrder.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
