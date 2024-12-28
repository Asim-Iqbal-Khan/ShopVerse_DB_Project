using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Project
{
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Seller_Add_Products addprod = new Seller_Add_Products();
            addprod.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void Seller_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SalesReport salesReport = new SalesReport();
            salesReport.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Seller_Inventory inventory = new Seller_Inventory();
            inventory.Show();
            this.Hide();
        }

        private void removeProducts_Click(object sender, EventArgs e)
        {
            Seller_Delete_Products delete_Products = new Seller_Delete_Products();
            delete_Products.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OrderManagementForm orderManagement=new OrderManagementForm();
            orderManagement.Show();
            this.Hide();
        }
    }
}
