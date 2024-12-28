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
    public partial class Customer_Order : Form
    {
        public Customer_Order()
        {
            InitializeComponent();
            LoadCustomerOrders();
        }


        private void LoadCustomerOrders()
        {
            int customerId = Session.UserID; // Assuming there is a session-like structure storing the user's ID
            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var query = @"
                SELECT OrderID, Date, Status, TotalAmount
                FROM OrderTable
                WHERE CustomerID = @CustomerID
                ORDER BY Date DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    DataTable dt = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Customer_Menu menu=new Customer_Menu("");
            menu.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Customer_Order_Load(object sender, EventArgs e)
        {

        }
    }
}
