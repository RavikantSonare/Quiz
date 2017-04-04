namespace DesktopAdmin
{
    partial class frmWithDrawManage
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
            this.dgvWithDrawManage = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.WithDrawId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WithDrawOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderConfirm = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWithDrawManage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 730);
            this.panel1.TabIndex = 0;
            // 
            // dgvWithDrawManage
            // 
            this.dgvWithDrawManage.AllowUserToAddRows = false;
            this.dgvWithDrawManage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWithDrawManage.BackgroundColor = System.Drawing.Color.White;
            this.dgvWithDrawManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWithDrawManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WithDrawId,
            this.WithDrawOrderNo,
            this.Amount,
            this.MerchantName,
            this.StatusValue,
            this.OrderConfirm});
            this.dgvWithDrawManage.Location = new System.Drawing.Point(2, 2);
            this.dgvWithDrawManage.Name = "dgvWithDrawManage";
            this.dgvWithDrawManage.Size = new System.Drawing.Size(782, 725);
            this.dgvWithDrawManage.TabIndex = 0;
            this.dgvWithDrawManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWithDrawManage_CellClick);
            this.dgvWithDrawManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWithDrawManage_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvWithDrawManage);
            this.panel2.Location = new System.Drawing.Point(226, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 730);
            this.panel2.TabIndex = 1;
            // 
            // WithDrawId
            // 
            this.WithDrawId.HeaderText = "WithDraw Id";
            this.WithDrawId.Name = "WithDrawId";
            // 
            // WithDrawOrderNo
            // 
            this.WithDrawOrderNo.HeaderText = "WithDraw Order No";
            this.WithDrawOrderNo.Name = "WithDrawOrderNo";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // MerchantName
            // 
            this.MerchantName.HeaderText = "Merchant Name";
            this.MerchantName.Name = "MerchantName";
            // 
            // StatusValue
            // 
            this.StatusValue.HeaderText = "Status Value";
            this.StatusValue.Name = "StatusValue";
            // 
            // OrderConfirm
            // 
            this.OrderConfirm.HeaderText = "Order Confirm";
            this.OrderConfirm.Name = "OrderConfirm";
            this.OrderConfirm.Text = "Processing/Confirm";
            this.OrderConfirm.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // frmWithDrawManage
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
            this.Name = "frmWithDrawManage";
            this.Text = "WithDraw Manage";
            this.Load += new System.EventHandler(this.frmWithDrawManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWithDrawManage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvWithDrawManage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithDrawId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithDrawOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusValue;
        private System.Windows.Forms.DataGridViewLinkColumn OrderConfirm;
    }
}