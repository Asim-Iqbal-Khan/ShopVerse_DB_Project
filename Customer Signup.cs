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
using static System.Windows.Forms.AxHost;

namespace DB_Project
{
    public partial class CustomerSignUp : Form
    {
        public CustomerSignUp()
        {
            InitializeComponent();
        }
        //Masabs database connection
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-J9J9HAS\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        //asims database connection
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CustomerSignUp_Load(object sender, EventArgs e)
        {

        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                con.Open();

                // Retrieve user input
                string Email = email.Text.Trim();
                string Password = password.Text.Trim();
                string Fname = fname.Text.Trim();
                string Lname = lname.Text.Trim();
                string Street = street.Text.Trim();
                string City = city.Text.Trim();
                string Province = province.Text.Trim();
                string ZipCode = zipCode.Text.Trim();
                string Payment = payment.Text.Trim();

                // Construct the full address
                string Address = $"{Street}, {City}, {Province}, {ZipCode}";

                // SQL query to insert a new customer
                string insertQuery = @"
            INSERT INTO Customer (FName, LName, Email, Address, PaymentPreference, Password)
            VALUES (@FName, @LName, @Email, @Address, @PaymentPreference, @Password)";

                // Create the SQL command
                SqlCommand cmd = new SqlCommand(insertQuery, con);

                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@FName", Fname);
                cmd.Parameters.AddWithValue("@LName", Lname);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@PaymentPreference", Payment);
                cmd.Parameters.AddWithValue("@Password", Password);

                // Execute the query
                cmd.ExecuteNonQuery();

                // Notify the user of successful registration
                MessageBox.Show("Your account has been registered!", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to the Login form
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Display the error message if something goes wrong
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed to release resources
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        private void email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
