namespace DesktopAdmin
{
    partial class frmAdminThirdCategory
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
            this.dgvThirdCategory = new System.Windows.Forms.DataGridView();
            this.ThirdCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThirdCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnCateSearch = new System.Windows.Forms.Button();
            this.txtCateSearch = new System.Windows.Forms.TextBox();
            this.lblCateSearch = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblThirdCategory = new System.Windows.Forms.Label();
            this.txtThirdCategory = new System.Windows.Forms.TextBox();
            this.cmbSecondCategory = new System.Windows.Forms.ComboBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThirdCategory)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThirdCategory
            // 
            this.dgvThirdCategory.AllowUserToAddRows = false;
            this.dgvThirdCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThirdCategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvThirdCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThirdCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ThirdCategoryId,
            this.ThirdCategory,
            this.SecondCategory,
            this.Edit,
            this.Delete});
            this.dgvThirdCategory.Location = new System.Drawing.Point(3, 46);
            this.dgvThirdCategory.Name = "dgvThirdCategory";
            this.dgvThirdCategory.Size = new System.Drawing.Size(775, 680);
            this.dgvThirdCategory.TabIndex = 23;
            this.dgvThirdCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThirdCategory_CellClick);
            this.dgvThirdCategory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThirdCategory_CellContentClick);
            // 
            // ThirdCategoryId
            // 
            this.ThirdCategoryId.HeaderText = "Id";
            this.ThirdCategoryId.Name = "ThirdCategoryId";
            // 
            // ThirdCategory
            // 
            this.ThirdCategory.HeaderText = "Category";
            this.ThirdCategory.Name = "ThirdCategory";
            // 
            // SecondCategory
            // 
            this.SecondCategory.HeaderText = "Second Category";
            this.SecondCategory.Name = "SecondCategory";
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
            // btnCateSearch
            // 
            this.btnCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCateSearch.Location = new System.Drawing.Point(690, 12);
            this.btnCateSearch.Name = "btnCateSearch";
            this.btnCateSearch.Size = new System.Drawing.Size(75, 22);
            this.btnCateSearch.TabIndex = 22;
            this.btnCateSearch.Text = "Search";
            this.btnCateSearch.UseVisualStyleBackColor = true;
            this.btnCateSearch.Click += new System.EventHandler(this.btnCateSearch_Click);
            // 
            // txtCateSearch
            // 
            this.txtCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCateSearch.Location = new System.Drawing.Point(570, 14);
            this.txtCateSearch.Name = "txtCateSearch";
            this.txtCateSearch.Size = new System.Drawing.Size(103, 20);
            this.txtCateSearch.TabIndex = 21;
            this.txtCateSearch.TextChanged += new System.EventHandler(this.txtCateSearch_TextChanged);
            this.txtCateSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCateSearch_KeyPress);
            // 
            // lblCateSearch
            // 
            this.lblCateSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCateSearch.AutoSize = true;
            this.lblCateSearch.Location = new System.Drawing.Point(499, 17);
            this.lblCateSearch.Name = "lblCateSearch";
            this.lblCateSearch.Size = new System.Drawing.Size(49, 13);
            this.lblCateSearch.TabIndex = 22;
            this.lblCateSearch.Text = "Category";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 730);
            this.panel1.TabIndex = 25;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(350, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 22);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblThirdCategory
            // 
            this.lblThirdCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblThirdCategory.AutoSize = true;
            this.lblThirdCategory.Location = new System.Drawing.Point(4, 17);
            this.lblThirdCategory.Name = "lblThirdCategory";
            this.lblThirdCategory.Size = new System.Drawing.Size(80, 13);
            this.lblThirdCategory.TabIndex = 20;
            this.lblThirdCategory.Text = "Category Name";
            // 
            // txtThirdCategory
            // 
            this.txtThirdCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtThirdCategory.Location = new System.Drawing.Point(90, 14);
            this.txtThirdCategory.Name = "txtThirdCategory";
            this.txtThirdCategory.Size = new System.Drawing.Size(125, 20);
            this.txtThirdCategory.TabIndex = 17;
            this.txtThirdCategory.TextChanged += new System.EventHandler(this.txtThirdCategory_TextChanged);
            this.txtThirdCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThirdCategory_KeyPress);
            // 
            // cmbSecondCategory
            // 
            this.cmbSecondCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSecondCategory.FormattingEnabled = true;
            this.cmbSecondCategory.Location = new System.Drawing.Point(221, 14);
            this.cmbSecondCategory.Name = "cmbSecondCategory";
            this.cmbSecondCategory.Size = new System.Drawing.Size(114, 21);
            this.cmbSecondCategory.TabIndex = 18;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncancel.Location = new System.Drawing.Point(420, 12);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(66, 23);
            this.btncancel.TabIndex = 20;
            this.btncancel.Text = "Reset";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvThirdCategory);
            this.panel2.Location = new System.Drawing.Point(226, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 729);
            this.panel2.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCateSearch);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblCateSearch);
            this.groupBox1.Controls.Add(this.txtThirdCategory);
            this.groupBox1.Controls.Add(this.txtCateSearch);
            this.groupBox1.Controls.Add(this.cmbSecondCategory);
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.lblThirdCategory);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 40);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // frmAdminThirdCategory
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
            this.Name = "frmAdminThirdCategory";
            this.Text = "Third Category";
            this.Load += new System.EventHandler(this.frmAdminThirdCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThirdCategory)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThirdCategory;
        private System.Windows.Forms.Button btnCateSearch;
        private System.Windows.Forms.TextBox txtCateSearch;
        private System.Windows.Forms.Label lblCateSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblThirdCategory;
        private System.Windows.Forms.TextBox txtThirdCategory;
        private System.Windows.Forms.ComboBox cmbSecondCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThirdCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThirdCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategory;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}