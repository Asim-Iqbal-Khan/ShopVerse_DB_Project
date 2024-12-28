using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DB_Project
{
    public partial class Customer_Manage_Profile : Form
    {
        private string userEmail;
        private int Option;

        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-J9J9HAS\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        public Customer_Manage_Profile(string userEmail)
        {
            InitializeComponent();
            this.userEmail = userEmail;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string Email = userEmail;
            string Password = passwordBox.Text;

            string VerificationQuery = "SELECT COUNT(*) FROM Customer WHERE Email=@Email AND Password=@Password";

            SqlCommand cmd = new SqlCommand(VerificationQuery, con);

            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@password", Password);

            int userCount = (int)cmd.ExecuteScalar();

            if (userCount == 1)
            {
                label.Text = "Password confirmed!";
                label.ForeColor = Color.Green; // Set text color to green for success message
                ShowExtraOptions(); // Call method to display extra options
            }

            else
            {
                label.Text = "Invalid password.";
                label.ForeColor = Color.Red; // Set text color to red for error message
                
            }

            con.Close();

        }

        private void ShowExtraOptions()
        {
            select.Visible = true;
            selectButton.Visible = true;
            button1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            string option = select.Text;

            if (option == "Change Password")
            {
                payment.Visible = false;
                street.Visible = false;
                city.Visible = false;
                province.Visible = false;
                zipCode.Visible = false;

                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;

                test.Visible = true;
                Option = 1;
            }

            else if (option == "Change Payment Preference")
            {
                test.Visible = false;
                street.Visible = false;
                city.Visible = false;
                province.Visible = false;
                zipCode.Visible = false;

                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;

                payment.Visible = true;
                Option = 2;
            }

            else
            {
                street.Visible = true;
                city.Visible = true;
                province.Visible = true;
                zipCode.Visible = true;

                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;

                payment.Visible = false;
                test.Visible = false;

                Option = 3;
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string Email = userEmail;
            if (Option == 1)
            {
                string Password = test.Text;
                string UpdateQuery = "UPDATE Customer SET Password = @Password WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(UpdateQuery, con);

                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.ExecuteNonQuery();
            }

            else if (Option == 2)
            {
                string PaymentPreference = payment.Text;
                string UpdateQuery = "UPDATE Customer SET PaymentPreference = @PaymentPreference WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(UpdateQuery, con);

                cmd.Parameters.AddWithValue("@PaymentPreference", PaymentPreference);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.ExecuteNonQuery();
            }

            else 
            {
                string Street = street.Text;
                string City = city.Text;
                string Province = province.Text;
                string ZipCode = zipCode.Text;
                string Address = Street + ", " + City + ", " + Province + ", " + ZipCode;

                string UpdateQuery = "UPDATE Customer SET Address = @Address WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(UpdateQuery, con);

                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Your account settings have been updated!", "Changes Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void test_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer_Menu customer_menu= new Customer_Menu("");
            customer_menu.Show();
            this.Hide();
        }
    }
}
