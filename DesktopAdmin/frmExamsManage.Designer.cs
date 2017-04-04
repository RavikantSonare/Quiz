namespace DesktopAdmin
{
    partial class frmExamsManage
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
            this.dgvExamManage = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblMerchantName = new System.Windows.Forms.Label();
            this.lblSecondCategory = new System.Windows.Forms.Label();
            this.lblExamCode = new System.Windows.Forms.Label();
            this.txtExamCode = new System.Windows.Forms.TextBox();
            this.txtSecondCategory = new System.Windows.Forms.TextBox();
            this.txtMerchantName = new System.Windows.Forms.TextBox();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExamManageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamManage)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 731);
            this.panel1.TabIndex = 0;
            // 
            // dgvExamManage
            // 
            this.dgvExamManage.AllowUserToAddRows = false;
            this.dgvExamManage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExamManage.BackgroundColor = System.Drawing.Color.White;
            this.dgvExamManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExamManageId,
            this.ExamCode,
            this.SecondCategoryId,
            this.MerchantName,
            this.LevelId,
            this.IsActive,
            this.Active});
            this.dgvExamManage.GridColor = System.Drawing.Color.DarkGray;
            this.dgvExamManage.Location = new System.Drawing.Point(3, 74);
            this.dgvExamManage.Name = "dgvExamManage";
            this.dgvExamManage.Size = new System.Drawing.Size(778, 660);
            this.dgvExamManage.TabIndex = 9;
            this.dgvExamManage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamManage_CellClick);
            this.dgvExamManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamManage_CellContentClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.84894F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.15106F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel3.Controls.Add(this.lblLevel, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblMerchantName, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblSecondCategory, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblExamCode, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtExamCode, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtSecondCategory, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMerchantName, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtLevel, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnSearch, 4, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 10);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(768, 60);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lblLevel
            // 
            this.lblLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(545, 8);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(33, 13);
            this.lblLevel.TabIndex = 3;
            this.lblLevel.Text = "Level";
            // 
            // lblMerchantName
            // 
            this.lblMerchantName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMerchantName.AutoSize = true;
            this.lblMerchantName.Location = new System.Drawing.Point(359, 8);
            this.lblMerchantName.Name = "lblMerchantName";
            this.lblMerchantName.Size = new System.Drawing.Size(83, 13);
            this.lblMerchantName.TabIndex = 2;
            this.lblMerchantName.Text = "Merchant Name";
            // 
            // lblSecondCategory
            // 
            this.lblSecondCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSecondCategory.AutoSize = true;
            this.lblSecondCategory.Location = new System.Drawing.Point(188, 8);
            this.lblSecondCategory.Name = "lblSecondCategory";
            this.lblSecondCategory.Size = new System.Drawing.Size(103, 13);
            this.lblSecondCategory.TabIndex = 1;
            this.lblSecondCategory.Text = "Secondary Category";
            // 
            // lblExamCode
            // 
            this.lblExamCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblExamCode.AutoSize = true;
            this.lblExamCode.Location = new System.Drawing.Point(49, 8);
            this.lblExamCode.Name = "lblExamCode";
            this.lblExamCode.Size = new System.Drawing.Size(61, 13);
            this.lblExamCode.TabIndex = 0;
            this.lblExamCode.Text = "Exam Code";
            // 
            // txtExamCode
            // 
            this.txtExamCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtExamCode.Location = new System.Drawing.Point(5, 35);
            this.txtExamCode.Name = "txtExamCode";
            this.txtExamCode.Size = new System.Drawing.Size(150, 20);
            this.txtExamCode.TabIndex = 4;
            this.txtExamCode.TextChanged += new System.EventHandler(this.txtExamCode_TextChanged);
            this.txtExamCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamCode_KeyPress);
            // 
            // txtSecondCategory
            // 
            this.txtSecondCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSecondCategory.Location = new System.Drawing.Point(165, 35);
            this.txtSecondCategory.Name = "txtSecondCategory";
            this.txtSecondCategory.Size = new System.Drawing.Size(150, 20);
            this.txtSecondCategory.TabIndex = 5;
            this.txtSecondCategory.TextChanged += new System.EventHandler(this.txtSecondCategory_TextChanged);
            this.txtSecondCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecondCategory_KeyPress);
            // 
            // txtMerchantName
            // 
            this.txtMerchantName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMerchantName.Location = new System.Drawing.Point(325, 35);
            this.txtMerchantName.Name = "txtMerchantName";
            this.txtMerchantName.Size = new System.Drawing.Size(150, 20);
            this.txtMerchantName.TabIndex = 6;
            this.txtMerchantName.TextChanged += new System.EventHandler(this.txtMerchantName_TextChanged);
            this.txtMerchantName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMerchantName_KeyPress);
            // 
            // txtLevel
            // 
            this.txtLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLevel.Location = new System.Drawing.Point(487, 35);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(150, 20);
            this.txtLevel.TabIndex = 7;
            this.txtLevel.TextChanged += new System.EventHandler(this.txtLevel_TextChanged);
            this.txtLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLevel_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Location = new System.Drawing.Point(668, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvExamManage);
            this.panel2.Location = new System.Drawing.Point(226, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 731);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Location = new System.Drawing.Point(3, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 75);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // ExamManageId
            // 
            this.ExamManageId.HeaderText = "Id";
            this.ExamManageId.Name = "ExamManageId";
            // 
            // ExamCode
            // 
            this.ExamCode.HeaderText = "Exam Code";
            this.ExamCode.Name = "ExamCode";
            // 
            // SecondCategoryId
            // 
            this.SecondCategoryId.HeaderText = "Second Category";
            this.SecondCategoryId.Name = "SecondCategoryId";
            // 
            // MerchantName
            // 
            this.MerchantName.HeaderText = "Merchant Name";
            this.MerchantName.Name = "MerchantName";
            // 
            // LevelId
            // 
            this.LevelId.HeaderText = "Level";
            this.LevelId.Name = "LevelId";
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "Active";
            this.IsActive.Name = "IsActive";
            // 
            // Active
            // 
            this.Active.HeaderText = "Active (Default is Active)";
            this.Active.Name = "Active";
            this.Active.Text = "Actived/Non-Actived";
            this.Active.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // frmExamsManage
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
            this.Name = "frmExamsManage";
            this.Text = "Exams Manage";
            this.Load += new System.EventHandler(this.frmExamsManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamManage)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvExamManage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblMerchantName;
        private System.Windows.Forms.Label lblSecondCategory;
        private System.Windows.Forms.Label lblExamCode;
        private System.Windows.Forms.TextBox txtExamCode;
        private System.Windows.Forms.TextBox txtSecondCategory;
        private System.Windows.Forms.TextBox txtMerchantName;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamManageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewLinkColumn Active;
    }
}