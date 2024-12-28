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
    public partial class SalesReport : Form
    {
        public SalesReport()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            var reportQueries = new Dictionary<string, string>
            {
                { "Seller Performance Report", @"
                    SELECT 
                        p.Name AS ProductName, 
                        SUM(oi.Quantity) AS TotalSold, 
                        SUM(oi.Quantity * oi.Price) AS TotalRevenue
                    FROM OrderItem oi
                    INNER JOIN Product p ON oi.ProductID = p.ProductID
                    WHERE oi.SellerID = @SellerID
                    GROUP BY p.Name
                " },
                { "Inventory Management Report", @"
                    SELECT 
                        p.ProductID, 
                        p.Name AS ProductName, 
                        p.Stock AS QuantityAvailable 
                    FROM Product p
                    WHERE p.SellerID = @SellerID
                " },
                { "Order Fulfillment and Shipping", @"
                    SELECT 
                        o.OrderID, 
                        o.Date AS OrderDate, 
                        CASE 
                            WHEN EXISTS (SELECT 1 FROM OrderItem oi WHERE oi.OrderID = o.OrderID AND oi.ApprovedBySeller = 0) 
                            THEN 'Pending Approval'
                            ELSE 'Approved'
                        END AS ShippingStatus
                    FROM OrderTable o
                    INNER JOIN OrderItem oi ON o.OrderID = oi.OrderID
                    WHERE oi.SellerID = @SellerID
                    GROUP BY o.OrderID, o.Date
                " },
                { "Total Sales", @"
                    SELECT 
                        SUM(oi.Price * oi.Quantity) AS TotalSales
                    FROM OrderItem oi WHERE oi.SellerID = @SellerID
                " },
                { "Average Order Value", @"
                    SELECT 
                        SUM(oi.Price * oi.Quantity) / COUNT(DISTINCT o.OrderID) AS AverageOrderValue
                    FROM OrderItem oi
                    JOIN OrderTable o ON oi.OrderID = o.OrderID
                    WHERE oi.SellerID = @SellerID
                " },
                { "Best Selling Product", @"
                    SELECT 
                        TOP 1 p.Name AS BestSellingProduct,
                        SUM(oi.Quantity) AS TotalQuantitySold
                    FROM OrderItem oi
                    JOIN Product p ON oi.ProductID = p.ProductID
                    WHERE oi.SellerID = @SellerID
                    GROUP BY p.Name
                    ORDER BY SUM(oi.Quantity) DESC
                " },
                { "Top Sales Category", @"
                    SELECT 
                        TOP 1 c.Name AS TopCategory,
                        SUM(oi.Price * oi.Quantity) AS TotalSalesByCategory
                    FROM OrderItem oi
                    JOIN Product p ON oi.ProductID = p.ProductID
                    JOIN Category c ON p.CategoryID = c.CategoryID
                    WHERE oi.SellerID = @SellerID
                    GROUP BY c.Name
                    ORDER BY SUM(oi.Price * oi.Quantity) DESC
                " },
                { "Low Stock Alert", @"
                    SELECT 
                        ProductID, 
                        Name AS ProductName, 
                        Stock
                    FROM Product
                    WHERE Stock < 10 AND SellerID = @SellerID
                " },
                { "Dead Stock", @"
                    SELECT 
                        P.ProductID,
                        P.Name AS ProductName,
                        P.Stock
                    FROM Product P
                    WHERE P.ProductID NOT IN (
                        SELECT DISTINCT OI.ProductID
                        FROM OrderItem OI
                        JOIN OrderTable OT ON OI.OrderID = OT.OrderID
                        WHERE DATEDIFF(DAY, OT.Date, GETDATE()) <= 30
                    ) AND P.SellerID = @SellerID
                " },
                { "Stock Turnover Rate", @"
                    SELECT 
                        P.ProductID,
                        P.Name AS ProductName,
                        SUM(OI.Quantity) AS TotalUnitsSold,
                        (P.OpeningStock + P.Stock) / 2 AS AverageInventory,
                        SUM(OI.Quantity) / NULLIF((P.OpeningStock + P.Stock) / 2, 0) AS StockTurnoverRate
                    FROM Product P
                    JOIN OrderItem OI ON P.ProductID = OI.ProductID
                    WHERE P.SellerID = @SellerID
                    GROUP BY P.ProductID, P.Name, P.OpeningStock, P.Stock
                " },
                { "Highest Negative Reviews", @"
                    SELECT 
                        P.ProductID,
                        P.Name AS ProductName,
                        COALESCE(SUM(RR.Quantity), 0) AS TotalReturns,
                        AVG(R.Rating) AS AverageRating
                    FROM Product P
                    LEFT JOIN Review R ON P.ProductID = R.ProductID
                    LEFT JOIN ReturnRequest RR ON P.ProductID = RR.ProductID
                    WHERE P.SellerID = @SellerID
                    GROUP BY P.ProductID, P.Name
                    HAVING AVG(R.Rating) <= 2.0
                    ORDER BY TotalReturns DESC, AverageRating ASC
                " }
            };

            comboBox1.DataSource = new BindingSource(reportQueries, null);
            comboBox1.DisplayMember = "Key";  // Display report names
            comboBox1.ValueMember = "Value"; // Store SQL queries
        }

        private DataTable GetDataFromDatabase(string query)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"; // Replace with your connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@SellerID", Session.UserID); // Ensure SellerID is passed dynamically
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure SelectedValue is not null and is valid
            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue is string selectedQuery)
            {
                try
                {
                    DataTable reportData = GetDataFromDatabase(selectedQuery);
                    ReportsViewer.DataSource = reportData; // Assuming ReportsViewer is your DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReportsViewer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content clicks if necessary
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seller seller=new Seller();
            seller.Show();
            this.Hide();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
