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
    public partial class Customer_Cart : Form
    {
        public Customer_Cart()
        {
            InitializeComponent();
            LoadCartItems();
            Price.Text = CalculateTotalAmount().ToString();
            SetupDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Customer_Menu customer_Menu = new Customer_Menu("");
            customer_Menu.Show();
            this.Hide();
        }

        private void LoadCartItems()
        {
            int customerId = Session.UserID; // Assuming you use a session like structure to keep track of the logged-in user
            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var query = @"
            SELECT ci.ProductID, p.Name, p.Price, ci.Quantity, (p.Price * ci.Quantity) AS Total
            FROM CartItem ci
            JOIN Product p ON ci.ProductID = p.ProductID
            JOIN Cart c ON ci.CartID = c.CartID
            WHERE c.CustomerID = @CustomerID AND c.CheckoutStatus IS NULL";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }


        private void SetupDataGridView()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Text = "Remove";
            btn.Name = "btnRemove";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnRemove"].Index && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value);
                RemoveCartItem(productId);
                LoadCartItems(); // Refresh the cart display
            }

            Price.Text = CalculateTotalAmount().ToString();
        }

        private void RemoveCartItem(int productId)
        {
            int customerId = Session.UserID;
            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var query = @"
            DELETE FROM CartItem
            WHERE ProductID = @ProductID AND CartID IN (
                SELECT CartID FROM Cart WHERE CustomerID = @CustomerID AND CheckoutStatus IS NULL)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadCartItems();
        }


        private void Price_Click(object sender, EventArgs e)
        {

        }

        private decimal CalculateTotalAmount()
        {
            int customerId = Session.UserID; // Using the session to get the user ID
            decimal totalAmount = 0m;

            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var query = @"
            SELECT SUM(p.Price * ci.Quantity) AS TotalAmount
            FROM CartItem ci
            JOIN Product p ON ci.ProductID = p.ProductID
            JOIN Cart c ON ci.CartID = c.CartID
            WHERE c.CustomerID = @CustomerID AND c.CheckoutStatus IS NULL";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    var result = cmd.ExecuteScalar(); // This should return the first column of the first row in the result set
                    if (result != DBNull.Value)
                    {
                        totalAmount = Convert.ToDecimal(result);
                    }
                }
            }

            return totalAmount;
        }


        private void CheckOut_Click(object sender, EventArgs e)
        {
            int customerId = Session.UserID; // Session-like structure assumed
            decimal totalAmount = CalculateTotalAmount();

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    // Check if enough stock is available for all items in the cart
                    var stockCheckQuery = @"
                SELECT p.ProductID, p.Stock, ci.Quantity
                FROM CartItem ci
                JOIN Product p ON ci.ProductID = p.ProductID
                WHERE ci.CartID IN (SELECT CartID FROM Cart WHERE CustomerID = @CustomerID AND CheckoutStatus IS NULL)";
                    var stockCmd = new SqlCommand(stockCheckQuery, conn, transaction);
                    stockCmd.Parameters.AddWithValue("@CustomerID", customerId);

                    using (var reader = stockCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int stock = reader.GetInt32(1);
                            int quantity = reader.GetInt32(2);
                            if (quantity > stock)
                            {
                                throw new Exception($"Not enough stock for Product ID {reader.GetInt32(0)}. Available: {stock}, requested: {quantity}.");
                            }
                        }
                    }

                    // Create a new order in OrderTable
                    var orderQuery = @"
                INSERT INTO OrderTable (Date, Status, CustomerID, TotalAmount)
                OUTPUT INSERTED.OrderID
                VALUES (GETDATE(), 'Pending', @CustomerID, @TotalAmount)";
                    var orderCmd = new SqlCommand(orderQuery, conn, transaction);
                    orderCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    orderCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    int orderId = (int)orderCmd.ExecuteScalar();

                    // Transfer cart items to OrderItem table
                    var transferQuery = @"
                INSERT INTO OrderItem (OrderID, ProductID, Quantity, Price, SellerID)
                SELECT @OrderID, ci.ProductID, ci.Quantity, p.Price, p.SellerID
                FROM CartItem ci
                JOIN Product p ON ci.ProductID = p.ProductID
                WHERE ci.CartID IN (SELECT CartID FROM Cart WHERE CustomerID = @CustomerID AND CheckoutStatus IS NULL)";
                    var transferCmd = new SqlCommand(transferQuery, conn, transaction);
                    transferCmd.Parameters.AddWithValue("@OrderID", orderId);
                    transferCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    transferCmd.ExecuteNonQuery();

                    // Clear the cart
                    var clearCartQuery = "DELETE FROM CartItem WHERE CartID IN (SELECT CartID FROM Cart WHERE CustomerID = @CustomerID AND CheckoutStatus IS NULL)";
                    var clearCartCmd = new SqlCommand(clearCartQuery, conn, transaction);
                    clearCartCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    clearCartCmd.ExecuteNonQuery();

                    // Commit transaction
                    transaction.Commit();
                    MessageBox.Show("Checkout successful!");
                    LoadCartItems(); // Refresh the display to show an empty cart
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        private void Customer_Cart_Load(object sender, EventArgs e)
        {

        }
    }
}
