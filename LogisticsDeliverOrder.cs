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
    public partial class LogisticsDeliverOrder : Form
    {
        public LogisticsDeliverOrder()
        {
            InitializeComponent();
            LoadShippedOrders();
        }
        private void LogisticsDeliverOrder_Load(object sender, EventArgs e)
        {
            LoadShippedOrders();
        }

        private void LoadShippedOrders()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT OrderID, Date, Status, CustomerID, PickupDate, estimateDeliveryDate, TotalAmount 
                             FROM OrderTable WHERE Status = 'Shipped'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);
                DeliverOrder(orderId);
            }
        }

        private void DeliverOrder(int orderId)
        {
            var confirmResult = MessageBox.Show("Are you sure to deliver this order?", "Confirm Delivery!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SetOrderDelivered(orderId);
            }
        }
        private void SetOrderDelivered(int orderId)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                try
                {
                    con.Open();
                    string updateQuery = @"UPDATE OrderTable SET Status = 'Delivered', deliveredDate = @DeliveredDate 
                                   WHERE OrderID = @OrderID";
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@DeliveredDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Order has been delivered successfully!");
                    LoadShippedOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            LogisticsProvider_Home logisticsProvider_Home = new LogisticsProvider_Home();
            logisticsProvider_Home.Show();
            this.Hide();
        }
    }
}
