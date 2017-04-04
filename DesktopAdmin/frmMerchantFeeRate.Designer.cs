namespace DesktopAdmin
{
    partial class frmMerchantFeeRate
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
            this.lblMerchantFeeRate = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMerchantFeeRate = new System.Windows.Forms.TextBox();
            this.cmbMerchantLevel = new System.Windows.Forms.ComboBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.dgvMerchantFeeRate = new System.Windows.Forms.DataGridView();
            this.MerchantFeeRateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantFeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantFeeRate)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMerchantFeeRate
            // 
            this.lblMerchantFeeRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMerchantFeeRate.AutoSize = true;
            this.lblMerchantFeeRate.Location = new System.Drawing.Point(5, 16);
            this.lblMerchantFeeRate.Name = "lblMerchantFeeRate";
            this.lblMerchantFeeRate.Size = new System.Drawing.Size(99, 13);
            this.lblMerchantFeeRate.TabIndex = 0;
            this.lblMerchantFeeRate.Text = "Merchant Fee Rate";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(409, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMerchantFeeRate
            // 
            this.txtMerchantFeeRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMerchantFeeRate.Location = new System.Drawing.Point(120, 13);
            this.txtMerchantFeeRate.Name = "txtMerchantFeeRate";
            this.txtMerchantFeeRate.Size = new System.Drawing.Size(120, 20);
            this.txtMerchantFeeRate.TabIndex = 2;
            this.txtMerchantFeeRate.TextChanged += new System.EventHandler(this.txtMerchantFeeRate_TextChanged);
            this.txtMerchantFeeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMerchantFeeRate_KeyPress);
            // 
            // cmbMerchantLevel
            // 
            this.cmbMerchantLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMerchantLevel.FormattingEnabled = true;
            this.cmbMerchantLevel.Location = new System.Drawing.Point(258, 13);
            this.cmbMerchantLevel.Name = "cmbMerchantLevel";
            this.cmbMerchantLevel.Size = new System.Drawing.Size(120, 21);
            this.cmbMerchantLevel.TabIndex = 3;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncancel.Location = new System.Drawing.Point(500, 11);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "Reset";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // dgvMerchantFeeRate
            // 
            this.dgvMerchantFeeRate.AllowUserToAddRows = false;
            this.dgvMerchantFeeRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMerchantFeeRate.BackgroundColor = System.Drawing.Color.White;
            this.dgvMerchantFeeRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerchantFeeRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MerchantFeeRateId,
            this.MerchantFeeRate,
            this.MerchantLevel,
            this.Edit,
            this.Delete});
            this.dgvMerchantFeeRate.Location = new System.Drawing.Point(3, 44);
            this.dgvMerchantFeeRate.Name = "dgvMerchantFeeRate";
            this.dgvMerchantFeeRate.ReadOnly = true;
            this.dgvMerchantFeeRate.Size = new System.Drawing.Size(779, 686);
            this.dgvMerchantFeeRate.TabIndex = 6;
            this.dgvMerchantFeeRate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerchantFeeRate_CellClick);
            this.dgvMerchantFeeRate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerchantFeeRate_CellContentClick);
            // 
            // MerchantFeeRateId
            // 
            this.MerchantFeeRateId.HeaderText = "Id";
            this.MerchantFeeRateId.Name = "MerchantFeeRateId";
            // 
            // MerchantFeeRate
            // 
            this.MerchantFeeRate.HeaderText = "Merchant Fee Rate";
            this.MerchantFeeRate.Name = "MerchantFeeRate";
            // 
            // MerchantLevel
            // 
            this.MerchantLevel.HeaderText = "Merchant Level";
            this.MerchantLevel.Name = "MerchantLevel";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            this.Delete.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dgvMerchantFeeRate);
            this.panel1.Location = new System.Drawing.Point(226, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 733);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.lblMerchantFeeRate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtMerchantFeeRate);
            this.groupBox1.Controls.Add(this.cmbMerchantLevel);
            this.groupBox1.Location = new System.Drawing.Point(4, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 40);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 733);
            this.panel2.TabIndex = 3;
            // 
            // frmMerchantFeeRate
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
            this.Name = "frmMerchantFeeRate";
            this.Text = "Merchant Fee Rate";
            this.Load += new System.EventHandler(this.frmMerchantFeeRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantFeeRate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblMerchantFeeRate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMerchantFeeRate;
        private System.Windows.Forms.DataGridView dgvMerchantFeeRate;
        private System.Windows.Forms.ComboBox cmbMerchantLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantFeeRateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantFeeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantLevel;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}