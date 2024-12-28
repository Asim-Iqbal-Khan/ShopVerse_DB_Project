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
    public partial class Customer_Wishlist : Form
    {
        public Customer_Wishlist()
        {
            InitializeComponent();
            LoadWishlistItems();
            SetupDataGridView();
        }


        private void SetupDataGridView()
        {
            if (!dataGridView1.Columns.Contains("btnAddToCart"))
            {
                DataGridViewButtonColumn btnAddToCart = new DataGridViewButtonColumn();
                btnAddToCart.HeaderText = "Add to Cart";
                btnAddToCart.Text = "Add to Cart";
                btnAddToCart.Name = "btnAddToCart";
                btnAddToCart.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnAddToCart);
            }
        }

        private void LoadWishlistItems()
        {
            int customerId = Session.UserID;
            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var query = @"
            SELECT w.WishlistID, p.ProductID, p.Name, p.Price
            FROM WishlistItem wi
            JOIN Wishlist w ON wi.WishlistID = w.WishlistID
            JOIN Product p ON wi.ProductID = p.ProductID
            WHERE w.CustomerID = @CustomerID";
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Customer_Menu customer_Menu = new Customer_Menu("");
            customer_Menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnAddToCart"].Index && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value);
                AddItemToCart(productId, 1);  // Assuming the quantity added is always 1
            }
        }

        private int EnsureCartExists()
        {
            int customerId = Session.UserID;  // Assuming Session.UserID stores the logged-in user's ID
            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var checkCartQuery = "SELECT CartID FROM Cart WHERE CustomerID = @CustomerID AND CheckoutStatus IS NULL";
                using (var cmd = new SqlCommand(checkCartQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    var cartId = cmd.ExecuteScalar();
                    if (cartId != null)
                    {
                        return (int)cartId;
                    }
                    else
                    {
                        string insertCartQuery = "INSERT INTO Cart (CustomerID, CheckoutStatus) OUTPUT INSERTED.CartID VALUES (@CustomerID, NULL)";
                        using (var insertCmd = new SqlCommand(insertCartQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@CustomerID", customerId);
                            int newCartId = (int)insertCmd.ExecuteScalar();
                            return newCartId;
                        }
                    }
                }
            }
        }


        private void AddItemToCart(int productId, int quantity)
        {
            int cartId = EnsureCartExists();
            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var checkItemQuery = "SELECT Quantity FROM CartItem WHERE CartID = @CartID AND ProductID = @ProductID";
                using (var checkCmd = new SqlCommand(checkItemQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@CartID", cartId);
                    checkCmd.Parameters.AddWithValue("@ProductID", productId);
                    var result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Product exists in the cart, update the quantity
                        int currentQuantity = (int)result;
                        var updateItemQuery = "UPDATE CartItem SET Quantity = @NewQuantity WHERE CartID = @CartID AND ProductID = @ProductID";
                        using (var updateCmd = new SqlCommand(updateItemQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@NewQuantity", currentQuantity + quantity);
                            updateCmd.Parameters.AddWithValue("@CartID", cartId);
                            updateCmd.Parameters.AddWithValue("@ProductID", productId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Product does not exist in the cart, add new
                        var addItemQuery = "INSERT INTO CartItem (ProductID, CartID, Quantity) VALUES (@ProductID, @CartID, @Quantity)";
                        using (var addCmd = new SqlCommand(addItemQuery, conn))
                        {
                            addCmd.Parameters.AddWithValue("@ProductID", productId);
                            addCmd.Parameters.AddWithValue("@CartID", cartId);
                            addCmd.Parameters.AddWithValue("@Quantity", quantity);
                            addCmd.ExecuteNonQuery();
                        }
                    }
                    // Remove the item from the wishlist after adding to the cart
                    RemoveItemFromWishlist(productId, conn);
                }
            }
        }

        private void RemoveItemFromWishlist(int productId, SqlConnection conn)
        {
            int customerId = Session.UserID;
            var removeItemQuery = "DELETE FROM WishlistItem WHERE ProductID = @ProductID AND WishlistID IN (SELECT WishlistID FROM Wishlist WHERE CustomerID = @CustomerID)";
            using (var removeCmd = new SqlCommand(removeItemQuery, conn))
            {
                removeCmd.Parameters.AddWithValue("@ProductID", productId);
                removeCmd.Parameters.AddWithValue("@CustomerID", customerId);
                removeCmd.ExecuteNonQuery();
            }
            LoadWishlistItems();  // Refresh the wishlist display to reflect the changes
        }


        private void Customer_Wishlist_Load(object sender, EventArgs e)
        {
            LoadWishlistItems();
        }
    }
}
