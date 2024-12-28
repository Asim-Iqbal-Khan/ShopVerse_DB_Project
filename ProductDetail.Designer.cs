namespace DB_Project
{
    partial class ProductDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cartCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ProductName = new System.Windows.Forms.Label();
            this.ProductDescription = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.CategoryName = new System.Windows.Forms.Label();
            this.CategoryDescription = new System.Windows.Forms.Label();
            this.AddToCart = new System.Windows.Forms.Button();
            this.AddToWishlist = new System.Windows.Forms.Button();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            this.BackButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.cartCount);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 74);
            this.panel1.TabIndex = 38;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DB_Project.Properties.Resources.icons8_wishlist_64;
            this.pictureBox2.Location = new System.Drawing.Point(1011, 16);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
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
            // cartCount
            // 
            this.cartCount.AutoSize = true;
            this.cartCount.BackColor = System.Drawing.Color.Transparent;
            this.cartCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartCount.ForeColor = System.Drawing.Color.Snow;
            this.cartCount.Location = new System.Drawing.Point(1117, 41);
            this.cartCount.Name = "cartCount";
            this.cartCount.Size = new System.Drawing.Size(17, 17);
            this.cartCount.TabIndex = 39;
            this.cartCount.Text = "1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_Project.Properties.Resources.Icon_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(1076, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(731, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 66);
            this.button3.TabIndex = 30;
            this.button3.Text = "Track Orders";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(324, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 66);
            this.button2.TabIndex = 29;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(549, 8);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 66);
            this.button4.TabIndex = 31;
            this.button4.Text = "Reviews And Ratings";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(420, 8);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 66);
            this.button5.TabIndex = 32;
            this.button5.Text = "Order History";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.exitButton.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitButton.Location = new System.Drawing.Point(1067, 9);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(122, 51);
            this.exitButton.TabIndex = 37;
            this.exitButton.Text = "Logout";
            this.exitButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.pictureBox4.Location = new System.Drawing.Point(52, 158);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(427, 405);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // ProductName
            // 
            this.ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductName.Location = new System.Drawing.Point(703, 112);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(325, 71);
            this.ProductName.TabIndex = 40;
            this.ProductName.Text = "Name";
            this.ProductName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ProductDescription
            // 
            this.ProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductDescription.Location = new System.Drawing.Point(617, 199);
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.Size = new System.Drawing.Size(499, 100);
            this.ProductDescription.TabIndex = 41;
            this.ProductDescription.Text = "Description";
            this.ProductDescription.Click += new System.EventHandler(this.ProductDescription_Click);
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Price.Location = new System.Drawing.Point(819, 490);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(93, 32);
            this.Price.TabIndex = 42;
            this.Price.Text = "Name";
            this.Price.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Price.Click += new System.EventHandler(this.label2_Click);
            // 
            // CategoryName
            // 
            this.CategoryName.AutoSize = true;
            this.CategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryName.Location = new System.Drawing.Point(819, 319);
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Size = new System.Drawing.Size(93, 32);
            this.CategoryName.TabIndex = 43;
            this.CategoryName.Text = "Name";
            this.CategoryName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CategoryDescription
            // 
            this.CategoryDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryDescription.Location = new System.Drawing.Point(617, 367);
            this.CategoryDescription.Name = "CategoryDescription";
            this.CategoryDescription.Size = new System.Drawing.Size(499, 100);
            this.CategoryDescription.TabIndex = 44;
            this.CategoryDescription.Text = "Description";
            // 
            // AddToCart
            // 
            this.AddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.AddToCart.FlatAppearance.BorderSize = 0;
            this.AddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToCart.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToCart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddToCart.Location = new System.Drawing.Point(666, 536);
            this.AddToCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddToCart.Name = "AddToCart";
            this.AddToCart.Size = new System.Drawing.Size(131, 44);
            this.AddToCart.TabIndex = 40;
            this.AddToCart.Text = "Add To Cart";
            this.AddToCart.UseVisualStyleBackColor = false;
            this.AddToCart.Click += new System.EventHandler(this.AddToCart_Click);
            // 
            // AddToWishlist
            // 
            this.AddToWishlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.AddToWishlist.FlatAppearance.BorderSize = 0;
            this.AddToWishlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToWishlist.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToWishlist.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddToWishlist.Location = new System.Drawing.Point(935, 536);
            this.AddToWishlist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddToWishlist.Name = "AddToWishlist";
            this.AddToWishlist.Size = new System.Drawing.Size(135, 44);
            this.AddToWishlist.TabIndex = 45;
            this.AddToWishlist.Text = "Add to Wishlist";
            this.AddToWishlist.UseVisualStyleBackColor = false;
            this.AddToWishlist.Click += new System.EventHandler(this.AddToWishlist_Click);
            // 
            // Quantity
            // 
            this.Quantity.Location = new System.Drawing.Point(812, 554);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(116, 26);
            this.Quantity.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(833, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Quantity:";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(0, 0);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(80, 55);
            this.BackButton.TabIndex = 40;
            this.BackButton.Text = "<-- Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.AddToWishlist);
            this.Controls.Add(this.AddToCart);
            this.Controls.Add(this.CategoryDescription);
            this.Controls.Add(this.CategoryName);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.ProductDescription);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exitButton);
            this.Name = "ProductDetail";
            this.Text = "ProductDetail";
            this.Load += new System.EventHandler(this.ProductDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label cartCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label ProductName;
        private System.Windows.Forms.Label ProductDescription;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label CategoryName;
        private System.Windows.Forms.Label CategoryDescription;
        private System.Windows.Forms.Button AddToCart;
        private System.Windows.Forms.Button AddToWishlist;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
    }
}