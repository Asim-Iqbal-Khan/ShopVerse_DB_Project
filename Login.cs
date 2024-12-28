using DB_Project.Properties;
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
    

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerSignUp CustomerSignUp = new CustomerSignUp();
            CustomerSignUp.Show();
            this.Hide();
        }

        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-J9J9HAS\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-15BOF6G\\SQLEXPRESS;Initial Catalog=ShopVerse;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!Admin.Checked && !Customer.Checked && !Seller.Checked && !radioButton1.Checked)
            {
                MessageBox.Show("Please select a user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            con.Open();

            string Email = email.Text;
            string Password = passwordBox.Text;
            string LoginQuery = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            if (Admin.Checked)
            {
                LoginQuery = "SELECT UserID FROM Admin WHERE Email = @Email AND Password = @Password";
            }
            else if (Customer.Checked)
            {
                LoginQuery = "SELECT UserID FROM Customer WHERE Email = @Email AND Password = @Password";
            }
            else if (Seller.Checked)
            {
                LoginQuery = "SELECT UserID FROM Seller WHERE Email = @Email AND Password = @Password AND ApprovalStatus = 1";
            }
            else if (radioButton1.Checked)
            {
                LoginQuery = "SELECT UserID FROM LogisticsProvider WHERE Email = @Email AND Password = @Password";
            }

            cmd.CommandText = LoginQuery;
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                Session.UserID = Convert.ToInt32(result);

                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Admin.Checked)
                {
                    Admin_Menu adminMenu = new Admin_Menu();
                    adminMenu.Show();
                }
                else if (Customer.Checked)
                {
                    Customer_Menu CustomerMenu = new Customer_Menu(Email);
                    CustomerMenu.Show();
                }
                else if (Seller.Checked)
                {
                    Seller sellerMenu = new Seller();
                    sellerMenu.Show();
                }
                else if (radioButton1.Checked)
                {
                    LogisticsProvider_Home logisticsMenu = new LogisticsProvider_Home();
                    logisticsMenu.Show();
                }

                this.Hide();
            }
            else
            {
                if (Seller.Checked)
                {
                    string checkApprovalQuery = "SELECT COUNT(*) FROM Seller WHERE Email = @Email AND ApprovalStatus = 0";
                    cmd.CommandText = checkApprovalQuery;
                    int notApproved = (int)cmd.ExecuteScalar();
                    if (notApproved > 0)
                    {
                        MessageBox.Show("Your account has not been approved yet. Please contact the administrator.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password. Please try again or Register your Account", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password. Please try again or Register your Account", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            con.Close();
        }



        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Seller_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Admin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    public static class Session
    {
        public static int UserID { get; set; }
    }


}
