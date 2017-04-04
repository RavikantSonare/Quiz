namespace DesktopMerchant
{
    partial class frmSalesReports
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
            this.dgvSalesReports = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderConfirmation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReports)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 732);
            this.panel1.TabIndex = 0;
            // 
            // dgvSalesReports
            // 
            this.dgvSalesReports.AllowUserToAddRows = false;
            this.dgvSalesReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.OrderNo,
            this.OrderDate,
            this.Category,
            this.ExamCode,
            this.OrderConfirmation,
            this.Price,
            this.FeeRate,
            this.NetAmount});
            this.dgvSalesReports.GridColor = System.Drawing.Color.DarkGray;
            this.dgvSalesReports.Location = new System.Drawing.Point(3, 2);
            this.dgvSalesReports.Name = "dgvSalesReports";
            this.dgvSalesReports.Size = new System.Drawing.Size(779, 727);
            this.dgvSalesReports.TabIndex = 20;
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "Order Id";
            this.OrderId.Name = "OrderId";
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "Order No";
            this.OrderNo.Name = "OrderNo";
            // 
            // OrderDate
            // 
            this.OrderDate.HeaderText = "OrderDate";
            this.OrderDate.Name = "OrderDate";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // ExamCode
            // 
            this.ExamCode.HeaderText = "Exam Code";
            this.ExamCode.Name = "ExamCode";
            // 
            // OrderConfirmation
            // 
            this.OrderConfirmation.HeaderText = "Order Confirmation";
            this.OrderConfirmation.Name = "OrderConfirmation";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // FeeRate
            // 
            this.FeeRate.HeaderText = "Fee Rate";
            this.FeeRate.Name = "FeeRate";
            // 
            // NetAmount
            // 
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSalesReports);
            this.panel3.Location = new System.Drawing.Point(227, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(785, 732);
            this.panel3.TabIndex = 1;
            // 
            // frmSalesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 733);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesReports";
            this.Text = "Sales Reports";
            this.Load += new System.EventHandler(this.frmSalesReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReports)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSalesReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderConfirmation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.Panel panel3;
    }
}