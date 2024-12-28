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
    public partial class Seller_Add_Products : Form
    {
        public Seller_Add_Products()
        {
            InitializeComponent();
            LoadCategories();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        String imgLocation = "";
        SqlCommand cmd;


        private void Seller_Add_Products_Load(object sender, EventArgs e)
        {
            LoadCategories(); // Load categories into the combo box
        }

        private void LoadCategories()
        {
            try
            {
                conn.Open();
                string query = "SELECT CategoryID, Name FROM Category";
                cmd = new SqlCommand(query, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind categories to the combo box
                //munjenko creation
                Category.DisplayMember = "Name";
                Category.ValueMember = "CategoryID";
                Category.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Seller_Manage_Products_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void uploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg|All Files (*.*)|*.*";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                imgLocation = dlg.FileName.ToString();
                pictureBox2.ImageLocation = imgLocation;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Open connection
                conn.Open();

                // Get image data as byte array
                byte[] imageBytes = null;
                if (!string.IsNullOrEmpty(imgLocation))
                {
                    FileStream fileStream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    imageBytes = binaryReader.ReadBytes((int)fileStream.Length);
                }

                // Get selected category ID from combo box
                int selectedCategoryID = Convert.ToInt32(Category.SelectedValue);

                // Insert query
                string query = "INSERT INTO Product (Name, Description, Price, Image, Stock, SellerID, CategoryID) " +
                               "VALUES (@Name, @Description, @Price, @Image, @Stock, @SellerID, @CategoryID)";

                // Initialize command
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Description", poductDescription.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(Price.Text));
                cmd.Parameters.AddWithValue("@Image", imageBytes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Stock", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@SellerID", Session.UserID); // Use the seller's ID from the session
                cmd.Parameters.AddWithValue("@CategoryID", selectedCategoryID); // Add the selected category ID

                // Execute query
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product added successfully!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close connection
                conn.Close();
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void poductDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            // Clear all textboxes
            textBox1.Text = string.Empty;
            poductDescription.Text = string.Empty;
            Price.Text = string.Empty;
            textBox4.Text = string.Empty;

            // Reset the combo box
            if (Category.Items.Count > 0)
            {
                Category.SelectedIndex = 0; // Reset to the first category
            }

            // Clear the image
            pictureBox2.Image = null;
            imgLocation = string.Empty;

            // Optionally, set focus back to the first input field
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seller s = new Seller();
            s.Show();
            this.Hide();
        }
    }




}
