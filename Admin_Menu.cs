using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Project
{
    public partial class Admin_Menu : Form
    {
        AdminManagesUser AdminUser;
        AdminManagesSeller AdminSeller;
        AdminManagesProduct AdminProduct;
        AdminManagesCategory AdminCategory;
        AdminOverseesOrders AdminOrders;
        AdminViewsReports AdminReports;
        AdminModerateReviews AdminModerateReviews;

        public Admin_Menu()
        {
            InitializeComponent();
        }

        



        private void Admin_Menu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopVerseDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.shopVerseDataSet.Customer);

        }

        private void CloseAllChildForms()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ManageCustomers_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            cover.Hide();
            if (AdminUser == null)
            {
                AdminUser = new AdminManagesUser();
                AdminUser.FormClosed += AdminUser_FormClosed;
                AdminUser.MdiParent = this;
                AdminUser.WindowState = FormWindowState.Maximized;
                AdminUser.Show();
            }
            else
            {
                AdminUser.WindowState = FormWindowState.Maximized;
                AdminUser.Activate();
            }
        }
        private void AdminUser_FormClosed(object sender,FormClosedEventArgs e)
        {
            AdminUser=null;
        }

        private void ManageSellers_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            cover.Hide();
            if (AdminSeller == null)
            {
                AdminSeller = new AdminManagesSeller();
                AdminSeller.FormClosed += AdminSeller_FormClosed;
                AdminSeller.MdiParent = this;
                AdminSeller.WindowState = FormWindowState.Maximized;

                AdminSeller.Show();
            }
            else
            {
                AdminSeller.WindowState = FormWindowState.Maximized;

                AdminSeller.Activate();
            }
        }
        private void AdminSeller_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminSeller = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            cover.Hide();
            if (AdminProduct == null)
            {
                AdminProduct = new AdminManagesProduct();
                AdminProduct.FormClosed += AdminProduct_FormClosed;
                AdminProduct.MdiParent = this;
                AdminProduct.WindowState = FormWindowState.Maximized;

                AdminProduct.Show();
            }
            else
            {
                AdminProduct.WindowState = FormWindowState.Maximized;

                AdminProduct.Activate();
            }
        }

        private void AdminProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminProduct = null;
        }

        private void ManageCategories_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            cover.Hide();
            if (AdminCategory == null)
            {
                AdminCategory = new AdminManagesCategory();
                AdminCategory.FormClosed += AdminCategory_FormClosed;
                AdminCategory.MdiParent = this;
                AdminCategory.WindowState = FormWindowState.Maximized;
                AdminCategory.Show();
            }
            else
            {
                AdminCategory.WindowState = FormWindowState.Maximized;
                AdminCategory.Activate();
            }
        }

        private void AdminCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminCategory = null;
        }

        private void cover_Click(object sender, EventArgs e)
        {

        }


        private void ManageOrders_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            cover.Hide();
            if (AdminOrders == null)
            {
                AdminOrders = new AdminOverseesOrders();
                AdminOrders.FormClosed += AdminOrders_FormClosed;
                AdminOrders.MdiParent = this;
                AdminOrders.WindowState = FormWindowState.Maximized;
                AdminOrders.Show();
            }
            else
            {
                AdminOrders.WindowState = FormWindowState.Maximized;
                AdminOrders.Activate();
            }
        }
        private void AdminOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminOrders = null;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            cover.Hide();
            if (AdminReports == null)
            {
                AdminReports = new AdminViewsReports();
                AdminReports.FormClosed += AdminReports_FormClosed;
                AdminReports.MdiParent = this;
                AdminReports.WindowState = FormWindowState.Maximized;
                AdminReports.Show();
            }
            else
            {
                AdminReports.WindowState = FormWindowState.Maximized;
                AdminReports.Activate();
            }
        }

        private void AdminReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminReports = null;
        }

        private void ReviewModeration_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            cover.Hide();
            if (AdminModerateReviews == null)
            {
                AdminModerateReviews = new AdminModerateReviews();
                AdminModerateReviews.FormClosed += AdminModerateReviews_FormClosed;
                AdminModerateReviews.MdiParent = this;
                AdminModerateReviews.WindowState = FormWindowState.Maximized;
                AdminModerateReviews.Show();
            }
            else
            {
                AdminModerateReviews.WindowState = FormWindowState.Maximized;
                AdminModerateReviews.Activate();
            }
        }

        private void AdminModerateReviews_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminModerateReviews = null;
        }
    }
}
