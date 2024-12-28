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
using System.IO;


namespace DB_Project
{
    public partial class Customer_Menu : Form
    {
        private string userEmail;

        public Customer_Menu(string userEmail)
        {
            InitializeComponent();
            this.userEmail = userEmail;
            DisplayProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_Products search_Products = new Search_Products();
            search_Products.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void cover_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Customer_Cart customer_Cart = new Customer_Cart();
            customer_Cart.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customer_Wishlist customer_Wishlist = new Customer_Wishlist();
            customer_Wishlist.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Customer_Manage_Profile obj = new Customer_Manage_Profile(userEmail);
            obj.Show();
            this.Hide();
        }




        public List<Product> GetProductsWithImages()
        {
            var connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"; // Update with your actual connection string
            var products = new List<Product>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT ProductID, Name, Description, Price, Image, Stock, SellerID, CategoryID FROM Product WHERE Image IS NOT NULL";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                ProductID = (int)reader["ProductID"],
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Price = (decimal)reader["Price"],
                                Image = (byte[])reader["Image"],
                                Stock = (int)reader["Stock"],
                                SellerID = (int)reader["SellerID"],
                                CategoryID = (int)reader["CategoryID"]
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        private void DisplayProducts()
        {
            List<Product> products = GetProductsWithImages();
            foreach (var product in products)
            {
                Panel panel = new Panel();
                panel.Size = new Size(200, 260);

                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(180, 180);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromStream(new MemoryStream(product.Image));
                pictureBox.Click += (sender, e) => OpenProductDetailForm(product);
                pictureBox.MouseEnter += PictureBox_MouseEnter;
                pictureBox.MouseLeave += PictureBox_MouseLeave;
                pictureBox.Dock = DockStyle.Top;  // This will keep the image at the top of the panel

                Label nameLabel = new Label();
                nameLabel.Text = product.Name;
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Dock = DockStyle.Bottom;  // Ensures this label is below the PictureBox
                nameLabel.Height = 30;

                Label priceLabel = new Label();
                priceLabel.Text = $"Price: ${product.Price}";
                priceLabel.TextAlign = ContentAlignment.MiddleCenter;
                priceLabel.Dock = DockStyle.Bottom;  // This label appears below the nameLabel
                priceLabel.Height = 30;

                // Add controls in reverse order of how they should appear vertically
                panel.Controls.Add(priceLabel);
                panel.Controls.Add(nameLabel);
                panel.Controls.Add(pictureBox);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }





        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.BorderStyle = BorderStyle.None;
            }
        }


        private Category GetCategoryByProductId(int categoryId)
        {
            Category category = null;
            string query = "SELECT CategoryID, Name, Description FROM Category WHERE CategoryID = @CategoryID";
            using (var command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        category = new Category
                        {
                            CategoryID = (int)reader["CategoryID"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return category;
        }


        private void OpenProductDetailForm(Product product)
        {
            Category category=GetCategoryByProductId(product.CategoryID);
            ProductDetail pd = new ProductDetail(product,category);
            pd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_Order customer_Order = new Customer_Order();
            customer_Order.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Customer_Review customer_Review = new Customer_Review();
            customer_Review.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
