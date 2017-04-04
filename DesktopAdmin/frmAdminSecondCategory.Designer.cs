namespace DesktopAdmin
{
    partial class frmAdminSecondCategory
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
            this.btnCateSearch = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.lblCateSearch = new System.Windows.Forms.Label();
            this.txtCateSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbTopCategory = new System.Windows.Forms.ComboBox();
            this.txtSecondCategory = new System.Windows.Forms.TextBox();
            this.lblSecondCategory = new System.Windows.Forms.Label();
            this.dgvSecondCategory = new System.Windows.Forms.DataGridView();
            this.SecondCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecondCategory)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 731);
            this.panel1.TabIndex = 17;
            // 
            // btnCateSearch
            // 
            this.btnCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCateSearch.Location = new System.Drawing.Point(707, 12);
            this.btnCateSearch.Name = "btnCateSearch";
            this.btnCateSearch.Size = new System.Drawing.Size(57, 23);
            this.btnCateSearch.TabIndex = 22;
            this.btnCateSearch.Text = "Search";
            this.btnCateSearch.UseVisualStyleBackColor = true;
            this.btnCateSearch.Click += new System.EventHandler(this.btnCateSearch_Click);
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncancel.Location = new System.Drawing.Point(435, 12);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 20;
            this.btncancel.Text = "Reset";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // lblCateSearch
            // 
            this.lblCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCateSearch.AutoSize = true;
            this.lblCateSearch.Location = new System.Drawing.Point(523, 17);
            this.lblCateSearch.Name = "lblCateSearch";
            this.lblCateSearch.Size = new System.Drawing.Size(49, 13);
            this.lblCateSearch.TabIndex = 22;
            this.lblCateSearch.Text = "Category";
            // 
            // txtCateSearch
            // 
            this.txtCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCateSearch.Location = new System.Drawing.Point(578, 14);
            this.txtCateSearch.Name = "txtCateSearch";
            this.txtCateSearch.Size = new System.Drawing.Size(119, 20);
            this.txtCateSearch.TabIndex = 21;
            this.txtCateSearch.TextChanged += new System.EventHandler(this.txtCateSearch_TextChanged);
            this.txtCateSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCateSearch_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(362, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 23);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbTopCategory
            // 
            this.cmbTopCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTopCategory.FormattingEnabled = true;
            this.cmbTopCategory.Location = new System.Drawing.Point(229, 14);
            this.cmbTopCategory.Name = "cmbTopCategory";
            this.cmbTopCategory.Size = new System.Drawing.Size(113, 21);
            this.cmbTopCategory.TabIndex = 18;
            // 
            // txtSecondCategory
            // 
            this.txtSecondCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSecondCategory.Location = new System.Drawing.Point(90, 14);
            this.txtSecondCategory.Name = "txtSecondCategory";
            this.txtSecondCategory.Size = new System.Drawing.Size(121, 20);
            this.txtSecondCategory.TabIndex = 17;
            this.txtSecondCategory.TextChanged += new System.EventHandler(this.txtSecondCategory_TextChanged);
            this.txtSecondCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecondCategory_KeyPress);
            // 
            // lblSecondCategory
            // 
            this.lblSecondCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSecondCategory.AutoSize = true;
            this.lblSecondCategory.Location = new System.Drawing.Point(4, 17);
            this.lblSecondCategory.Name = "lblSecondCategory";
            this.lblSecondCategory.Size = new System.Drawing.Size(80, 13);
            this.lblSecondCategory.TabIndex = 20;
            this.lblSecondCategory.Text = "Category Name";
            // 
            // dgvSecondCategory
            // 
            this.dgvSecondCategory.AllowUserToAddRows = false;
            this.dgvSecondCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSecondCategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvSecondCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecondCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SecondCategoryId,
            this.SecondCategory,
            this.TopCategory,
            this.Edit,
            this.Delete});
            this.dgvSecondCategory.Location = new System.Drawing.Point(2, 45);
            this.dgvSecondCategory.Name = "dgvSecondCategory";
            this.dgvSecondCategory.Size = new System.Drawing.Size(775, 685);
            this.dgvSecondCategory.TabIndex = 23;
            this.dgvSecondCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSecondCategory_CellClick);
            this.dgvSecondCategory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSecondCategory_CellContentClick);
            // 
            // SecondCategoryId
            // 
            this.SecondCategoryId.HeaderText = "Id";
            this.SecondCategoryId.Name = "SecondCategoryId";
            // 
            // SecondCategory
            // 
            this.SecondCategory.HeaderText = "Category";
            this.SecondCategory.Name = "SecondCategory";
            // 
            // TopCategory
            // 
            this.TopCategory.HeaderText = "Top Category";
            this.TopCategory.Name = "TopCategory";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvSecondCategory);
            this.panel2.Location = new System.Drawing.Point(227, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 732);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCateSearch);
            this.groupBox1.Controls.Add(this.txtSecondCategory);
            this.groupBox1.Controls.Add(this.txtCateSearch);
            this.groupBox1.Controls.Add(this.lblSecondCategory);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.lblCateSearch);
            this.groupBox1.Controls.Add(this.cmbTopCategory);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 40);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // frmAdminSecondCategory
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
            this.Name = "frmAdminSecondCategory";
            this.Text = "Second Category";
            this.Load += new System.EventHandler(this.frmAdminSecondCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecondCategory)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSecondCategory;
        private System.Windows.Forms.TextBox txtSecondCategory;
        private System.Windows.Forms.ComboBox cmbTopCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCateSearch;
        private System.Windows.Forms.Label lblCateSearch;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnCateSearch;
        private System.Windows.Forms.DataGridView dgvSecondCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopCategory;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}