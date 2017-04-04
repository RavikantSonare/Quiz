namespace DesktopAdmin
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
            this.lblMerchantName = new System.Windows.Forms.Label();
            this.txtMerchantName = new System.Windows.Forms.TextBox();
            this.btnSummary = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblmsg = new System.Windows.Forms.Label();
            this.dgvSalesReports = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdreNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatusValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderConfirm = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EmailNotice = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReports)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 729);
            this.panel1.TabIndex = 0;
            // 
            // lblMerchantName
            // 
            this.lblMerchantName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMerchantName.AutoSize = true;
            this.lblMerchantName.Location = new System.Drawing.Point(5, 15);
            this.lblMerchantName.Name = "lblMerchantName";
            this.lblMerchantName.Size = new System.Drawing.Size(83, 13);
            this.lblMerchantName.TabIndex = 0;
            this.lblMerchantName.Text = "Merchant Name";
            // 
            // txtMerchantName
            // 
            this.txtMerchantName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMerchantName.Location = new System.Drawing.Point(110, 12);
            this.txtMerchantName.Name = "txtMerchantName";
            this.txtMerchantName.Size = new System.Drawing.Size(110, 20);
            this.txtMerchantName.TabIndex = 1;
            this.txtMerchantName.TextChanged += new System.EventHandler(this.txtMerchantName_TextChanged);
            this.txtMerchantName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMerchantName_KeyPress);
            // 
            // btnSummary
            // 
            this.btnSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSummary.Location = new System.Drawing.Point(241, 10);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(75, 23);
            this.btnSummary.TabIndex = 2;
            this.btnSummary.Text = "Summary";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(360, 15);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(28, 13);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "$xxx";
            // 
            // lblmsg
            // 
            this.lblmsg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(448, 15);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(161, 13);
            this.lblmsg.TabIndex = 4;
            this.lblmsg.Text = "($ is all confirmed orders amount)";
            // 
            // dgvSalesReports
            // 
            this.dgvSalesReports.AllowUserToAddRows = false;
            this.dgvSalesReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.OrdreNo,
            this.ExamCode,
            this.SecondCategory,
            this.MerchantName,
            this.Price,
            this.FeeRate,
            this.NetAmount,
            this.OrderStatusValue,
            this.OrderConfirm,
            this.EmailNotice});
            this.dgvSalesReports.Location = new System.Drawing.Point(2, 45);
            this.dgvSalesReports.Name = "dgvSalesReports";
            this.dgvSalesReports.Size = new System.Drawing.Size(785, 681);
            this.dgvSalesReports.TabIndex = 3;
            this.dgvSalesReports.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesReports_CellClick);
            this.dgvSalesReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesReports_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvSalesReports);
            this.panel2.Location = new System.Drawing.Point(225, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 729);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblmsg);
            this.groupBox1.Controls.Add(this.txtMerchantName);
            this.groupBox1.Controls.Add(this.lblAmount);
            this.groupBox1.Controls.Add(this.lblMerchantName);
            this.groupBox1.Controls.Add(this.btnSummary);
            this.groupBox1.Location = new System.Drawing.Point(1, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 40);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "Order Id";
            this.OrderId.Name = "OrderId";
            // 
            // OrdreNo
            // 
            this.OrdreNo.HeaderText = "Order No.";
            this.OrdreNo.Name = "OrdreNo";
            // 
            // ExamCode
            // 
            this.ExamCode.HeaderText = "Exam Code";
            this.ExamCode.Name = "ExamCode";
            // 
            // SecondCategory
            // 
            this.SecondCategory.HeaderText = "Second Category";
            this.SecondCategory.Name = "SecondCategory";
            // 
            // MerchantName
            // 
            this.MerchantName.HeaderText = "Merchant Name";
            this.MerchantName.Name = "MerchantName";
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
            // OrderStatusValue
            // 
            this.OrderStatusValue.HeaderText = "Status Value";
            this.OrderStatusValue.Name = "OrderStatusValue";
            // 
            // OrderConfirm
            // 
            this.OrderConfirm.DataPropertyName = "OrderConfirm";
            this.OrderConfirm.HeaderText = "Order Confirm";
            this.OrderConfirm.Name = "OrderConfirm";
            this.OrderConfirm.Text = "Processing/Confirm";
            this.OrderConfirm.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // EmailNotice
            // 
            this.EmailNotice.HeaderText = "Email Notice";
            this.EmailNotice.Name = "EmailNotice";
            this.EmailNotice.Text = "Send Email";
            this.EmailNotice.UseColumnTextForButtonValue = true;
            // 
            // frmSalesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 733);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesReports";
            this.Text = "Sales Reports";
            this.Load += new System.EventHandler(this.frmSalesReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReports)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMerchantName;
        private System.Windows.Forms.TextBox txtMerchantName;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.DataGridView dgvSalesReports;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdreNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatusValue;
        private System.Windows.Forms.DataGridViewLinkColumn OrderConfirm;
        private System.Windows.Forms.DataGridViewButtonColumn EmailNotice;
    }
}