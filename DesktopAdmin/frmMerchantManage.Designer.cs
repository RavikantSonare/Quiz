namespace DesktopAdmin
{
    partial class frmMerchantManage
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
            this.dgvMerchantManage = new System.Windows.Forms.DataGridView();
            this.MerchantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantLevelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActiveValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantManage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 732);
            this.panel1.TabIndex = 0;
            // 
            // dgvMerchantManage
            // 
            this.dgvMerchantManage.AllowUserToAddRows = false;
            this.dgvMerchantManage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMerchantManage.BackgroundColor = System.Drawing.Color.White;
            this.dgvMerchantManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerchantManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MerchantId,
            this.MerchantName,
            this.CountryId,
            this.StateId,
            this.Telephone,
            this.MerchantLevelId,
            this.ValidDate,
            this.ActiveValue,
            this.Active});
            this.dgvMerchantManage.Location = new System.Drawing.Point(1, 2);
            this.dgvMerchantManage.Name = "dgvMerchantManage";
            this.dgvMerchantManage.ReadOnly = true;
            this.dgvMerchantManage.Size = new System.Drawing.Size(783, 727);
            this.dgvMerchantManage.TabIndex = 0;
            this.dgvMerchantManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerchantManage_CellClick);
            this.dgvMerchantManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerchantManage_CellContentClick);
            // 
            // MerchantId
            // 
            this.MerchantId.HeaderText = "Merchant Id";
            this.MerchantId.Name = "MerchantId";
            this.MerchantId.ReadOnly = true;
            // 
            // MerchantName
            // 
            this.MerchantName.HeaderText = "Merchant Name";
            this.MerchantName.Name = "MerchantName";
            this.MerchantName.ReadOnly = true;
            // 
            // CountryId
            // 
            this.CountryId.HeaderText = "Country";
            this.CountryId.Name = "CountryId";
            this.CountryId.ReadOnly = true;
            // 
            // StateId
            // 
            this.StateId.HeaderText = "State";
            this.StateId.Name = "StateId";
            this.StateId.ReadOnly = true;
            // 
            // Telephone
            // 
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            this.Telephone.ReadOnly = true;
            // 
            // MerchantLevelId
            // 
            this.MerchantLevelId.HeaderText = "Merchant Level";
            this.MerchantLevelId.Name = "MerchantLevelId";
            this.MerchantLevelId.ReadOnly = true;
            // 
            // ValidDate
            // 
            this.ValidDate.HeaderText = "Valid Date";
            this.ValidDate.Name = "ValidDate";
            this.ValidDate.ReadOnly = true;
            // 
            // ActiveValue
            // 
            this.ActiveValue.HeaderText = "Active Value";
            this.ActiveValue.Name = "ActiveValue";
            this.ActiveValue.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.HeaderText = "Active";
            this.Active.LinkColor = System.Drawing.Color.Blue;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Text = "Actived/Non-Actived";
            this.Active.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMerchantManage);
            this.panel2.Location = new System.Drawing.Point(225, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 732);
            this.panel2.TabIndex = 1;
            // 
            // frmMerchantManage
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
            this.Name = "frmMerchantManage";
            this.Text = "Merchant Manage";
            this.Load += new System.EventHandler(this.frmMerchantManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantManage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMerchantManage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantLevelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActiveValue;
        private System.Windows.Forms.DataGridViewLinkColumn Active;
    }
}