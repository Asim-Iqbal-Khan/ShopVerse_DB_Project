namespace DB_Project
{
    partial class AdminViewsReports
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
            this.ReportsViewer = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReportsViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportsViewer
            // 
            this.ReportsViewer.AllowUserToAddRows = false;
            this.ReportsViewer.AllowUserToDeleteRows = false;
            this.ReportsViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.ReportsViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReportsViewer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.ReportsViewer.Location = new System.Drawing.Point(179, 197);
            this.ReportsViewer.Name = "ReportsViewer";
            this.ReportsViewer.ReadOnly = true;
            this.ReportsViewer.RowHeadersWidth = 62;
            this.ReportsViewer.RowTemplate.Height = 28;
            this.ReportsViewer.Size = new System.Drawing.Size(815, 364);
            this.ReportsViewer.TabIndex = 44;
            this.ReportsViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReportsViewer_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Demi", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(421, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 70);
            this.label1.TabIndex = 43;
            this.label1.Text = "View Reports";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1. Sales Performance Report",
            "2. Customer Purchase Behavior",
            "3. Inventory Management Report",
            "4. Revenue by Product Category",
            "5. Customer Feedback and Product Rating",
            "6. Order Fulfillment and Shipping",
            "7. Platform Growth and User Engagement",
            "8. User Demographic Report"});
            this.comboBox1.Location = new System.Drawing.Point(449, 157);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(280, 28);
            this.comboBox1.TabIndex = 45;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AdminViewsReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1173, 630);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ReportsViewer);
            this.Controls.Add(this.label1);
            this.Name = "AdminViewsReports";
            this.Text = "AdminViewsReports";
            this.Load += new System.EventHandler(this.AdminViewsReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportsViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReportsViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}