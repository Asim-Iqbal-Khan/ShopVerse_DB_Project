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
    public partial class Seller_Inventory : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        public Seller_Inventory()
        {
            InitializeComponent();
            LoadInventory();
        }


        private void LoadInventory()
        {
            try
            {
                conn.Open();
                string query = "SELECT ProductID, Name, Stock FROM Product WHERE SellerID = @SellerID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SellerID", Session.UserID); // Assuming Session.UserID contains the current seller's ID

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt; // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateInventory_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = int.Parse(textBox1.Text); // Get Product ID from TextBox1
                int newStock = int.Parse(textBox2.Text); // Get Quantity from TextBox2

                conn.Open();

                string query = "UPDATE Product SET Stock = @Stock WHERE ProductID = @ProductID AND SellerID = @SellerID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Stock", newStock);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@SellerID", Session.UserID); // Ensure the product belongs to the seller

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Inventory updated successfully!");
                    LoadInventory(); // Refresh inventory in DataGridView
                }
                else
                {
                    MessageBox.Show("Product not found or you do not have permission to update it.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Product ID and Quantity.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seller s = new Seller();
            s.Show();
            this.Hide();
        }
    }
}
