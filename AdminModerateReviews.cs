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
    public partial class AdminModerateReviews : Form
    {
        private string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public AdminModerateReviews()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void AdminModerateReviews_Load(object sender, EventArgs e)
        {
            LoadReviews();
        }

        private void LoadReviews()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT ReviewID, Content, Rating, ReviewDate FROM Review";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int reviewId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ReviewID"].Value);
                ConfirmAndDeleteReview(reviewId);
            }
        }

        private void ConfirmAndDeleteReview(int reviewId)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this review?", "Confirm Deletion!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DeleteReview(reviewId);
            }
        }

        private void DeleteReview(int reviewId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Review WHERE ReviewID = @ReviewID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ReviewID", reviewId);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Review deleted successfully.");
                        LoadReviews();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting review.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
