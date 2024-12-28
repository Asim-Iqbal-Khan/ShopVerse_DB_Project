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
    public partial class Seller_Delete_Products : Form
    {
        public Seller_Delete_Products()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        private void Seller_Delete_Products_Load(object sender, EventArgs e)
        {
            LoadProducts(); // Load products when the form loads
            
        }

        private void LoadProducts()
        {
            try
            {
                conn.Open();
                string query = "SELECT ProductID, Name, Description, Price, Stock FROM Product WHERE SellerID = @SellerID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SellerID", Session.UserID);

                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {

                string columnNames = "Columns in DataGridView:\n";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames += column.Name + "\n";
            }
            MessageBox.Show(columnNames);
                conn.Close();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Delete Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();
                        int productID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value);

                        string query = "DELETE FROM Products WHERE ProductID = @ProductID AND SellerID = @SellerID";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ProductID", productID);
                        cmd.Parameters.AddWithValue("@SellerID", Session.UserID);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Product deleted successfully!");

                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void Seller_Delete_Products_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seller seller = new Seller();
            seller.Show();
            this.Hide();
        }
    }
}
