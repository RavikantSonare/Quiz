namespace DesktopAdmin
{
    partial class frmAdminTopCategory
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
            this.lblTopCategory = new System.Windows.Forms.Label();
            this.txtTopCategory = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCateSearch = new System.Windows.Forms.Button();
            this.lblCateSearch = new System.Windows.Forms.Label();
            this.txtCateSearch = new System.Windows.Forms.TextBox();
            this.dgvTopCategory = new System.Windows.Forms.DataGridView();
            this.TopCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlPager = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCategory)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 731);
            this.panel1.TabIndex = 9;
            // 
            // lblTopCategory
            // 
            this.lblTopCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTopCategory.AutoSize = true;
            this.lblTopCategory.Location = new System.Drawing.Point(5, 16);
            this.lblTopCategory.Name = "lblTopCategory";
            this.lblTopCategory.Size = new System.Drawing.Size(71, 13);
            this.lblTopCategory.TabIndex = 9;
            this.lblTopCategory.Text = "Top Category";
            // 
            // txtTopCategory
            // 
            this.txtTopCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTopCategory.Location = new System.Drawing.Point(82, 13);
            this.txtTopCategory.Name = "txtTopCategory";
            this.txtTopCategory.Size = new System.Drawing.Size(119, 20);
            this.txtTopCategory.TabIndex = 10;
            this.txtTopCategory.TextChanged += new System.EventHandler(this.txtTopCategory_TextChanged);
            this.txtTopCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTopCategory_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(224, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 22);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 22);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Reset";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCateSearch
            // 
            this.btnCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCateSearch.Location = new System.Drawing.Point(600, 11);
            this.btnCateSearch.Name = "btnCateSearch";
            this.btnCateSearch.Size = new System.Drawing.Size(75, 22);
            this.btnCateSearch.TabIndex = 14;
            this.btnCateSearch.Text = "Search";
            this.btnCateSearch.UseVisualStyleBackColor = true;
            this.btnCateSearch.Click += new System.EventHandler(this.btnCateSearch_Click);
            // 
            // lblCateSearch
            // 
            this.lblCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCateSearch.AutoSize = true;
            this.lblCateSearch.Location = new System.Drawing.Point(383, 16);
            this.lblCateSearch.Name = "lblCateSearch";
            this.lblCateSearch.Size = new System.Drawing.Size(49, 13);
            this.lblCateSearch.TabIndex = 13;
            this.lblCateSearch.Text = "Category";
            // 
            // txtCateSearch
            // 
            this.txtCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCateSearch.Location = new System.Drawing.Point(456, 13);
            this.txtCateSearch.Name = "txtCateSearch";
            this.txtCateSearch.Size = new System.Drawing.Size(119, 20);
            this.txtCateSearch.TabIndex = 13;
            this.txtCateSearch.TextChanged += new System.EventHandler(this.txtCateSearch_TextChanged);
            this.txtCateSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCateSearch_KeyPress);
            // 
            // dgvTopCategory
            // 
            this.dgvTopCategory.AllowUserToAddRows = false;
            this.dgvTopCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopCategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TopCategoryId,
            this.TopCategory,
            this.Edit,
            this.Delete});
            this.dgvTopCategory.Location = new System.Drawing.Point(1, 46);
            this.dgvTopCategory.Name = "dgvTopCategory";
            this.dgvTopCategory.Size = new System.Drawing.Size(780, 590);
            this.dgvTopCategory.TabIndex = 15;
            this.dgvTopCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopCategory_CellClick);
            this.dgvTopCategory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopCategory_CellContentClick);
            // 
            // TopCategoryId
            // 
            this.TopCategoryId.HeaderText = "ID";
            this.TopCategoryId.Name = "TopCategoryId";
            // 
            // TopCategory
            // 
            this.TopCategory.HeaderText = "Top Category";
            this.TopCategory.Name = "TopCategory";
            // 
            // Edit
            // 
            this.Edit.DataPropertyName = "TopCategoryId";
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            this.Delete.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlPager);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.dgvTopCategory);
            this.panel3.Location = new System.Drawing.Point(227, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 731);
            this.panel3.TabIndex = 10;
            // 
            // pnlPager
            // 
            this.pnlPager.Location = new System.Drawing.Point(1, 642);
            this.pnlPager.Name = "pnlPager";
            this.pnlPager.Size = new System.Drawing.Size(780, 26);
            this.pnlPager.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCateSearch);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.txtCateSearch);
            this.groupBox1.Controls.Add(this.lblCateSearch);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtTopCategory);
            this.groupBox1.Controls.Add(this.lblTopCategory);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 40);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // frmAdminTopCategory
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
            this.Name = "frmAdminTopCategory";
            this.Text = "Top Category";
            this.Load += new System.EventHandler(this.frmAdminTopCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopCategory)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTopCategory;
        private System.Windows.Forms.Label lblTopCategory;
        private System.Windows.Forms.TextBox txtTopCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCateSearch;
        private System.Windows.Forms.Label lblCateSearch;
        private System.Windows.Forms.TextBox txtCateSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopCategory;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Panel pnlPager;
    }
}