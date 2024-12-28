namespace DB_Project
{
    partial class Admin_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopVerseDataSet = new DB_Project.ShopVerseDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ReviewModeration = new System.Windows.Forms.Button();
            this.ViewReports = new System.Windows.Forms.Button();
            this.ManageOrders = new System.Windows.Forms.Button();
            this.ManageCategories = new System.Windows.Forms.Button();
            this.ManageProducts = new System.Windows.Forms.Button();
            this.ManageSellers = new System.Windows.Forms.Button();
            this.ManageCustomers = new System.Windows.Forms.Button();
            this.customerTableAdapter = new DB_Project.ShopVerseDataSetTableAdapters.CustomerTableAdapter();
            this.cover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopVerseDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            this.SuspendLayout();
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.shopVerseDataSet;
            // 
            // shopVerseDataSet
            // 
            this.shopVerseDataSet.DataSetName = "ShopVerseDataSet";
            this.shopVerseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.ReviewModeration);
            this.panel1.Controls.Add(this.ViewReports);
            this.panel1.Controls.Add(this.ManageOrders);
            this.panel1.Controls.Add(this.ManageCategories);
            this.panel1.Controls.Add(this.ManageProducts);
            this.panel1.Controls.Add(this.ManageSellers);
            this.panel1.Controls.Add(this.ManageCustomers);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 74);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DB_Project.Properties.Resources.user_512;
            this.pictureBox3.Location = new System.Drawing.Point(1150, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(42, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 37;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DB_Project.Properties.Resources.settings;
            this.pictureBox2.Location = new System.Drawing.Point(1083, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // ReviewModeration
            // 
            this.ReviewModeration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.ReviewModeration.FlatAppearance.BorderSize = 0;
            this.ReviewModeration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReviewModeration.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReviewModeration.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ReviewModeration.Location = new System.Drawing.Point(898, 0);
            this.ReviewModeration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReviewModeration.Name = "ReviewModeration";
            this.ReviewModeration.Size = new System.Drawing.Size(161, 74);
            this.ReviewModeration.TabIndex = 36;
            this.ReviewModeration.Text = "Moderate Reviews";
            this.ReviewModeration.UseVisualStyleBackColor = false;
            this.ReviewModeration.Click += new System.EventHandler(this.ReviewModeration_Click);
            // 
            // ViewReports
            // 
            this.ViewReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.ViewReports.FlatAppearance.BorderSize = 0;
            this.ViewReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewReports.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewReports.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ViewReports.Location = new System.Drawing.Point(784, 0);
            this.ViewReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ViewReports.Name = "ViewReports";
            this.ViewReports.Size = new System.Drawing.Size(115, 74);
            this.ViewReports.TabIndex = 35;
            this.ViewReports.Text = "View Reports";
            this.ViewReports.UseVisualStyleBackColor = false;
            this.ViewReports.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManageOrders
            // 
            this.ManageOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.ManageOrders.FlatAppearance.BorderSize = 0;
            this.ManageOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageOrders.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageOrders.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ManageOrders.Location = new System.Drawing.Point(639, 0);
            this.ManageOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ManageOrders.Name = "ManageOrders";
            this.ManageOrders.Size = new System.Drawing.Size(137, 74);
            this.ManageOrders.TabIndex = 34;
            this.ManageOrders.Text = "Manage Orders";
            this.ManageOrders.UseVisualStyleBackColor = false;
            this.ManageOrders.Click += new System.EventHandler(this.ManageOrders_Click);
            // 
            // ManageCategories
            // 
            this.ManageCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.ManageCategories.FlatAppearance.BorderSize = 0;
            this.ManageCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageCategories.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageCategories.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ManageCategories.Location = new System.Drawing.Point(473, 0);
            this.ManageCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ManageCategories.Name = "ManageCategories";
            this.ManageCategories.Size = new System.Drawing.Size(168, 74);
            this.ManageCategories.TabIndex = 33;
            this.ManageCategories.Text = "Manage Categories";
            this.ManageCategories.UseVisualStyleBackColor = false;
            this.ManageCategories.Click += new System.EventHandler(this.ManageCategories_Click);
            // 
            // ManageProducts
            // 
            this.ManageProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.ManageProducts.FlatAppearance.BorderSize = 0;
            this.ManageProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageProducts.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ManageProducts.Location = new System.Drawing.Point(313, 0);
            this.ManageProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ManageProducts.Name = "ManageProducts";
            this.ManageProducts.Size = new System.Drawing.Size(152, 74);
            this.ManageProducts.TabIndex = 32;
            this.ManageProducts.Text = "Manage Products";
            this.ManageProducts.UseVisualStyleBackColor = false;
            this.ManageProducts.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManageSellers
            // 
            this.ManageSellers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.ManageSellers.FlatAppearance.BorderSize = 0;
            this.ManageSellers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageSellers.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageSellers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ManageSellers.Location = new System.Drawing.Point(170, 0);
            this.ManageSellers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ManageSellers.Name = "ManageSellers";
            this.ManageSellers.Size = new System.Drawing.Size(135, 74);
            this.ManageSellers.TabIndex = 31;
            this.ManageSellers.Text = "Manage Sellers";
            this.ManageSellers.UseVisualStyleBackColor = false;
            this.ManageSellers.Click += new System.EventHandler(this.ManageSellers_Click);
            // 
            // ManageCustomers
            // 
            this.ManageCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.ManageCustomers.FlatAppearance.BorderSize = 0;
            this.ManageCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageCustomers.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageCustomers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ManageCustomers.Location = new System.Drawing.Point(0, 0);
            this.ManageCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ManageCustomers.Name = "ManageCustomers";
            this.ManageCustomers.Size = new System.Drawing.Size(162, 74);
            this.ManageCustomers.TabIndex = 30;
            this.ManageCustomers.Text = "Manage Customers";
            this.ManageCustomers.UseVisualStyleBackColor = false;
            this.ManageCustomers.Click += new System.EventHandler(this.ManageCustomers_Click);
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // cover
            // 
            this.cover.Image = global::DB_Project.Properties.Resources.Cover;
            this.cover.Location = new System.Drawing.Point(-10, 61);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(1221, 619);
            this.cover.TabIndex = 1;
            this.cover.TabStop = false;
            this.cover.Click += new System.EventHandler(this.cover_Click);
            // 
            // Admin_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cover);
            this.IsMdiContainer = true;
            this.Name = "Admin_Menu";
            this.Text = "Admin_Menu";
            this.Load += new System.EventHandler(this.Admin_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopVerseDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ManageCustomers;
        private System.Windows.Forms.Button ManageProducts;
        private System.Windows.Forms.Button ManageSellers;
        private System.Windows.Forms.Button ManageCategories;
        private System.Windows.Forms.Button ManageOrders;
        private System.Windows.Forms.Button ViewReports;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ReviewModeration;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ShopVerseDataSet shopVerseDataSet;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private ShopVerseDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.PictureBox cover;
    }
}