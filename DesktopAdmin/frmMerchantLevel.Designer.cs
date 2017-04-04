namespace DesktopAdmin
{
    partial class frmMerchantLevel
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
            this.lblMerchantLevel = new System.Windows.Forms.Label();
            this.lblAnnualFee = new System.Windows.Forms.Label();
            this.txtAnnualFee = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMerchantLevel = new System.Windows.Forms.TextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.dgvMerchantLevel = new System.Windows.Forms.DataGridView();
            this.MerchantLevelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnnualFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantLevel)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMerchantLevel
            // 
            this.lblMerchantLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMerchantLevel.AutoSize = true;
            this.lblMerchantLevel.Location = new System.Drawing.Point(7, 17);
            this.lblMerchantLevel.Name = "lblMerchantLevel";
            this.lblMerchantLevel.Size = new System.Drawing.Size(81, 13);
            this.lblMerchantLevel.TabIndex = 0;
            this.lblMerchantLevel.Text = "Merchant Level";
            // 
            // lblAnnualFee
            // 
            this.lblAnnualFee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAnnualFee.AutoSize = true;
            this.lblAnnualFee.Location = new System.Drawing.Point(235, 17);
            this.lblAnnualFee.Name = "lblAnnualFee";
            this.lblAnnualFee.Size = new System.Drawing.Size(61, 13);
            this.lblAnnualFee.TabIndex = 1;
            this.lblAnnualFee.Text = "Annual Fee";
            // 
            // txtAnnualFee
            // 
            this.txtAnnualFee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAnnualFee.Location = new System.Drawing.Point(302, 14);
            this.txtAnnualFee.Name = "txtAnnualFee";
            this.txtAnnualFee.Size = new System.Drawing.Size(120, 20);
            this.txtAnnualFee.TabIndex = 3;
            this.txtAnnualFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnnualFee_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(447, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 25);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMerchantLevel
            // 
            this.txtMerchantLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMerchantLevel.Location = new System.Drawing.Point(94, 14);
            this.txtMerchantLevel.Name = "txtMerchantLevel";
            this.txtMerchantLevel.Size = new System.Drawing.Size(120, 20);
            this.txtMerchantLevel.TabIndex = 2;
            this.txtMerchantLevel.TextChanged += new System.EventHandler(this.txtMerchantLevel_TextChanged);
            this.txtMerchantLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMerchantLevel_KeyPress);
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncancel.Location = new System.Drawing.Point(559, 11);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 24);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "Reset";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // dgvMerchantLevel
            // 
            this.dgvMerchantLevel.AllowUserToAddRows = false;
            this.dgvMerchantLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMerchantLevel.BackgroundColor = System.Drawing.Color.White;
            this.dgvMerchantLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerchantLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MerchantLevelId,
            this.MerchantLevel,
            this.AnnualFee,
            this.Edit,
            this.Delete});
            this.dgvMerchantLevel.Location = new System.Drawing.Point(2, 44);
            this.dgvMerchantLevel.Name = "dgvMerchantLevel";
            this.dgvMerchantLevel.ReadOnly = true;
            this.dgvMerchantLevel.Size = new System.Drawing.Size(779, 686);
            this.dgvMerchantLevel.TabIndex = 6;
            this.dgvMerchantLevel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerchantLevel_CellClick);
            this.dgvMerchantLevel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMerchantLevel_CellContentClick);
            // 
            // MerchantLevelId
            // 
            this.MerchantLevelId.HeaderText = "Id";
            this.MerchantLevelId.Name = "MerchantLevelId";
            // 
            // MerchantLevel
            // 
            this.MerchantLevel.HeaderText = "Merchant Level";
            this.MerchantLevel.Name = "MerchantLevel";
            // 
            // AnnualFee
            // 
            this.AnnualFee.HeaderText = "Annual Fee";
            this.AnnualFee.Name = "AnnualFee";
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 732);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvMerchantLevel);
            this.panel2.Location = new System.Drawing.Point(226, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 733);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.txtMerchantLevel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblMerchantLevel);
            this.groupBox1.Controls.Add(this.txtAnnualFee);
            this.groupBox1.Controls.Add(this.lblAnnualFee);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 40);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // frmMerchantLevel
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
            this.Name = "frmMerchantLevel";
            this.Text = "Merchant Level";
            this.Load += new System.EventHandler(this.frmMerchantLevel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantLevel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblMerchantLevel;
        private System.Windows.Forms.Label lblAnnualFee;
        private System.Windows.Forms.TextBox txtMerchantLevel;
        private System.Windows.Forms.TextBox txtAnnualFee;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvMerchantLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantLevelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnnualFee;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}