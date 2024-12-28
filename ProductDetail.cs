using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace DB_Project
{
    public partial class ProductDetail : Form
    {
        private Product _product;
        private Category _category;
        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        public ProductDetail(Product product,Category category)
        {
            _category = category;
            _product = product;
            InitializeComponent();
        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {
            ProductName.Text = _product.Name;
            ProductDescription.Text = "Description: "+_product.Description;
            Price.Text = $"Price: ${_product.Price.ToString("N2")}";
            CategoryName.Text = "Category: " + _category.Name;
            CategoryDescription.Text = "Description: " + _category.Description;

            if (_product.Image != null)
            {
                using (var ms = new MemoryStream(_product.Image))
                {
                    pictureBox4.Image = Image.FromStream(ms);
                }
            }
        }


        private int EnsureCartExists()
        {
            int customerId = Session.UserID;
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

        private void AddToCartFun()
        {
            int productId = _product.ProductID;
            int quantity;
            if (!int.TryParse(Quantity.Text, out quantity) || quantity < 1)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            int cartId = EnsureCartExists();

            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var checkItemQuery = "SELECT Quantity FROM CartItem WHERE CartID = @CartID AND ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(checkItemQuery, conn);
                cmd.Parameters.AddWithValue("@CartID", cartId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                object existingQuantity = cmd.ExecuteScalar();

                if (existingQuantity != null)
                {
                    var updateItemQuery = "UPDATE CartItem SET Quantity = Quantity + @Quantity WHERE CartID = @CartID AND ProductID = @ProductID";
                    cmd = new SqlCommand(updateItemQuery, conn);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@CartID", cartId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    var addItemQuery = "INSERT INTO CartItem (ProductID, CartID, Quantity) VALUES (@ProductID, @CartID, @Quantity)";
                    cmd = new SqlCommand(addItemQuery, conn);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@CartID", cartId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ProductDescription_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private int EnsureWishlistExists()
        {
            int customerId = Session.UserID;
            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                var checkWishlistQuery = "SELECT WishlistID FROM Wishlist WHERE CustomerID = @CustomerID";
                using (var cmd = new SqlCommand(checkWishlistQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    var wishlistId = cmd.ExecuteScalar();

                    if (wishlistId != null)
                    {
                        return (int)wishlistId;
                    }
                    else
                    {
                        string insertWishlistQuery = "INSERT INTO Wishlist (CustomerID) OUTPUT INSERTED.WishlistID VALUES (@CustomerID)";
                        using (var insertCmd = new SqlCommand(insertWishlistQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@CustomerID", customerId);
                            int newWishlistId = (int)insertCmd.ExecuteScalar();
                            return newWishlistId;
                        }
                    }
                }
            }
        }

        private void AddToWishlistFun()
        {
            int productId = _product.ProductID;
            int wishlistId = EnsureWishlistExists();

            using (var conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"))
            {
                conn.Open();
                // Check if the product is already in the wishlist
                var checkItemQuery = "SELECT ProductID FROM WishlistItem WHERE WishlistID = @WishlistID AND ProductID = @ProductID";
                using (var checkCmd = new SqlCommand(checkItemQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@WishlistID", wishlistId);
                    checkCmd.Parameters.AddWithValue("@ProductID", productId);
                    var result = checkCmd.ExecuteScalar();

                    if (result == null)
                    {
                        // Product is not in the wishlist, add it
                        var addItemQuery = "INSERT INTO WishlistItem (CustomerID, WishlistID, ProductID) VALUES (@CustomerID, @WishlistID, @ProductID)";
                        using (var addCmd = new SqlCommand(addItemQuery, conn))
                        {
                            addCmd.Parameters.AddWithValue("@CustomerID", Session.UserID);
                            addCmd.Parameters.AddWithValue("@WishlistID", wishlistId);
                            addCmd.Parameters.AddWithValue("@ProductID", productId);
                            addCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        private void AddToWishlist_Click(object sender, EventArgs e)
        {
            try
            {
                AddToWishlistFun();
                MessageBox.Show("Product added to wishlist successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add product to wishlist. Error: {ex.Message}");
            }
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                AddToCartFun();
                MessageBox.Show("Product added to cart successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add product to cart. Error: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Customer_Menu cm=new Customer_Menu("");
            cm.Show();
            this.Hide();
        }
    }
}
