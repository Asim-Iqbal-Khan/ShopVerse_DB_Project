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
    public partial class AdminViewsReports : Form
    {
        public AdminViewsReports()
        {
            InitializeComponent();
            PopulateComboBox();
        }


        private void PopulateComboBox()
        {
            var reportQueries = new Dictionary<string, string>
    {
        { "Most Active Customer", @"
            SELECT 
                C.UserID AS MostActiveCustomer,
                AVG(O.TotalAmount) AS AvgSpendPerCustomer,
                (SELECT COUNT(DISTINCT OrderID) FROM OrderTable WHERE CustomerID = C.UserID) AS RepeatPurchaseRate
            FROM Customer C
            JOIN OrderTable O ON C.UserID = O.CustomerID
            GROUP BY C.UserID
        " },
        { "Average Ratings by Product", @"
            SELECT 
                P.ProductID,
                P.Name AS ProductName,
                AVG(R.Rating) AS AverageRating
            FROM Product P
            JOIN Review R ON P.ProductID = R.ProductID
            GROUP BY P.ProductID, P.Name
            ORDER BY AverageRating DESC
        " },
        { "Product Sentiment Analysis", @"
            SELECT 
                P.ProductID,
                P.Name AS ProductName,
                R.Content,
                CASE 
                    WHEN R.Content LIKE '%excellent%' THEN 'Positive'
                    WHEN R.Content LIKE '%good%' THEN 'Positive'
                    WHEN R.Content LIKE '%poor quality%' OR R.Content LIKE '%bad%' THEN 'Negative'
                    ELSE 'Neutral'
                END AS Sentiment
            FROM Product P
            JOIN Review R ON P.ProductID = R.ProductID
        " },
        { "Top Rated Products", @"
            SELECT 
                P.ProductID,
                P.Name AS ProductName,
                AVG(R.Rating) AS AverageRating
            FROM Product P
            JOIN Review R ON P.ProductID = R.ProductID
            GROUP BY P.ProductID, P.Name
            HAVING AVG(Rating) >= 4.5
            ORDER BY AverageRating DESC
        " },
        { "Total Sales by Seller", @"
            SELECT 
                S.UserID,
                S.StoreName,
                SUM(OI.Price * OI.Quantity) AS TotalSales
            FROM Seller S
            JOIN OrderItem OI ON S.UserID = OI.SellerID
            GROUP BY S.UserID, S.StoreName
        " }
    };

            comboBox1.DataSource = new BindingSource(reportQueries, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }


        private DataTable GetDataFromDatabase(string query)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }


        //Munjenko creation

        private void ReportsViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue is string selectedQuery)
            {
                try
                {
                    DataTable reportData = GetDataFromDatabase(selectedQuery);
                    ReportsViewer.DataSource = reportData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminViewsReports_Load(object sender, EventArgs e)
        {

        }
    }
}
