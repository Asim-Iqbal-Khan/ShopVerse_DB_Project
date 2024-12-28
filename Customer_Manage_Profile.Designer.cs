namespace DB_Project
{
    partial class Customer_Manage_Profile
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.payment = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.province = new System.Windows.Forms.TextBox();
            this.zipCode = new System.Windows.Forms.TextBox();
            this.city = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.ComboBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_Project.Properties.Resources.Icon;
            this.pictureBox1.Location = new System.Drawing.Point(4, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Franklin Gothic Demi Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label.Location = new System.Drawing.Point(333, 46);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(597, 42);
            this.label.TabIndex = 1;
            this.label.Text = "Please Confirm your Password to Continue";
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.passwordBox.Location = new System.Drawing.Point(340, 148);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(574, 30);
            this.passwordBox.TabIndex = 2;
            this.passwordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.button2.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(566, 212);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 54);
            this.button2.TabIndex = 30;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // payment
            // 
            this.payment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment.FormattingEnabled = true;
            this.payment.Items.AddRange(new object[] {
            "COD",
            "Credit/Debit Card"});
            this.payment.Location = new System.Drawing.Point(492, 348);
            this.payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(300, 38);
            this.payment.TabIndex = 43;
            this.payment.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label11.Location = new System.Drawing.Point(580, 466);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 23);
            this.label11.TabIndex = 42;
            this.label11.Text = "Postal/Zip Code";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label10.Location = new System.Drawing.Point(660, 398);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "State/Province";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label9.Location = new System.Drawing.Point(536, 398);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 23);
            this.label9.TabIndex = 40;
            this.label9.Text = "City";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label8.Location = new System.Drawing.Point(580, 331);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 23);
            this.label8.TabIndex = 39;
            this.label8.Text = "Street Address";
            this.label8.Visible = false;
            // 
            // province
            // 
            this.province.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.province.Location = new System.Drawing.Point(642, 360);
            this.province.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.province.Name = "province";
            this.province.Size = new System.Drawing.Size(140, 30);
            this.province.TabIndex = 38;
            this.province.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.province.Visible = false;
            // 
            // zipCode
            // 
            this.zipCode.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCode.Location = new System.Drawing.Point(495, 428);
            this.zipCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zipCode.Name = "zipCode";
            this.zipCode.Size = new System.Drawing.Size(290, 30);
            this.zipCode.TabIndex = 37;
            this.zipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zipCode.Visible = false;
            // 
            // city
            // 
            this.city.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city.Location = new System.Drawing.Point(492, 360);
            this.city.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(140, 30);
            this.city.TabIndex = 36;
            this.city.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.city.Visible = false;
            // 
            // street
            // 
            this.street.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.street.Location = new System.Drawing.Point(492, 292);
            this.street.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.street.Name = "street";
            this.street.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.street.Size = new System.Drawing.Size(290, 30);
            this.street.TabIndex = 35;
            this.street.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.street.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(570, 560);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 54);
            this.button1.TabIndex = 44;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // select
            // 
            this.select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select.Font = new System.Drawing.Font("Franklin Gothic Demi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select.FormattingEnabled = true;
            this.select.Items.AddRange(new object[] {
            "Change Password",
            "Change Payment Preference",
            "Change Address"});
            this.select.Location = new System.Drawing.Point(18, 340);
            this.select.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(410, 45);
            this.select.TabIndex = 45;
            this.select.Visible = false;
            // 
            // selectButton
            // 
            this.selectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.selectButton.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectButton.Location = new System.Drawing.Point(300, 451);
            this.selectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(130, 54);
            this.selectButton.TabIndex = 46;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = false;
            this.selectButton.Visible = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // test
            // 
            this.test.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
            this.test.Location = new System.Drawing.Point(492, 348);
            this.test.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(316, 30);
            this.test.TabIndex = 47;
            this.test.Visible = false;
            this.test.TextChanged += new System.EventHandler(this.test_TextChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(64)))), ((int)(((byte)(102)))));
            this.button3.Font = new System.Drawing.Font("Franklin Gothic Demi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(18, 624);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 54);
            this.button3.TabIndex = 48;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Customer_Manage_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.test);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.select);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.payment);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.province);
            this.Controls.Add(this.zipCode);
            this.Controls.Add(this.city);
            this.Controls.Add(this.street);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Customer_Manage_Profile";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox payment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox province;
        private System.Windows.Forms.TextBox zipCode;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.TextBox street;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox select;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.TextBox test;
        private System.Windows.Forms.Button button3;
    }
}