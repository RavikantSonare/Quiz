namespace DesktopMerchant
{
    partial class MDIfrmMerchantDashboard
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
            this.dgvExamMerchant = new System.Windows.Forms.DataGridView();
            this.Review = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.OnlyTestOnce = new System.Windows.Forms.DataGridViewLinkColumn();
            this.AllowPrint = new System.Windows.Forms.DataGridViewLinkColumn();
            this.AllowSales = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMerchantProfile = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MerchantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Upgrade = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Renewal = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblrequestaddnewcat = new System.Windows.Forms.Label();
            this.txtRequestAddNewCat = new System.Windows.Forms.TextBox();
            this.cmbTopcat = new System.Windows.Forms.ComboBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMyExam = new System.Windows.Forms.Button();
            this.btnManageQuestion = new System.Windows.Forms.Button();
            this.btnConfigexam = new System.Windows.Forms.Button();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.lblNavigation = new System.Windows.Forms.Label();
            this.btnMyUser = new System.Windows.Forms.Button();
            this.btnSalesReports = new System.Windows.Forms.Button();
            this.btnFinanceReports = new System.Windows.Forms.Button();
            this.btnFinanceConfig = new System.Windows.Forms.Button();
            this.btnFinanceWithDraw = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExamReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamMerchant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantProfile)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExamMerchant
            // 
            this.dgvExamMerchant.AllowUserToAddRows = false;
            this.dgvExamMerchant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExamMerchant.BackgroundColor = System.Drawing.Color.White;
            this.dgvExamMerchant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamMerchant.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Review,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewLinkColumn1,
            this.dataGridViewLinkColumn2,
            this.OnlyTestOnce,
            this.AllowPrint,
            this.AllowSales,
            this.ItemPrice});
            this.dgvExamMerchant.Location = new System.Drawing.Point(3, 105);
            this.dgvExamMerchant.Name = "dgvExamMerchant";
            this.dgvExamMerchant.Size = new System.Drawing.Size(786, 628);
            this.dgvExamMerchant.TabIndex = 2;
            // 
            // Review
            // 
            this.Review.HeaderText = "Review";
            this.Review.Name = "Review";
            this.Review.Text = "Review";
            this.Review.UseColumnTextForLinkValue = true;
            this.Review.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ExamCodeID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Exam Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "Exam Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn3.HeaderText = "Category";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TestTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "Test Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ValidDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Valid Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.HeaderText = "Exam Simulator";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.Text = "Generate";
            this.dataGridViewLinkColumn1.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn1.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.HeaderText = "Exam Simulator Demo";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.Text = "Generate";
            this.dataGridViewLinkColumn2.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn2.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // OnlyTestOnce
            // 
            this.OnlyTestOnce.HeaderText = "Only Test Once";
            this.OnlyTestOnce.Name = "OnlyTestOnce";
            this.OnlyTestOnce.Text = "Yes/No";
            this.OnlyTestOnce.UseColumnTextForLinkValue = true;
            this.OnlyTestOnce.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // AllowPrint
            // 
            this.AllowPrint.HeaderText = "Allow Print";
            this.AllowPrint.Name = "AllowPrint";
            this.AllowPrint.Text = "Yes/No";
            this.AllowPrint.UseColumnTextForLinkValue = true;
            this.AllowPrint.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // AllowSales
            // 
            this.AllowSales.HeaderText = "Allow Sales";
            this.AllowSales.Name = "AllowSales";
            this.AllowSales.Text = "Yes/No";
            this.AllowSales.UseColumnTextForLinkValue = true;
            this.AllowSales.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // ItemPrice
            // 
            this.ItemPrice.HeaderText = "Item Price";
            this.ItemPrice.Name = "ItemPrice";
            // 
            // dgvMerchantProfile
            // 
            this.dgvMerchantProfile.AllowUserToAddRows = false;
            this.dgvMerchantProfile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMerchantProfile.BackgroundColor = System.Drawing.Color.White;
            this.dgvMerchantProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMerchantProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ValidDate,
            this.MerchantName,
            this.UserName,
            this.Level,
            this.Upgrade,
            this.Renewal});
            this.dgvMerchantProfile.Location = new System.Drawing.Point(4, 5);
            this.dgvMerchantProfile.Name = "dgvMerchantProfile";
            this.dgvMerchantProfile.Size = new System.Drawing.Size(785, 56);
            this.dgvMerchantProfile.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Merchant Id";
            this.Id.Name = "Id";
            // 
            // ValidDate
            // 
            this.ValidDate.HeaderText = "Valid Date";
            this.ValidDate.Name = "ValidDate";
            // 
            // MerchantName
            // 
            this.MerchantName.HeaderText = "Merchant Name";
            this.MerchantName.Name = "MerchantName";
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Login Name";
            this.UserName.Name = "UserName";
            // 
            // Level
            // 
            this.Level.HeaderText = "Currently Level";
            this.Level.Name = "Level";
            // 
            // Upgrade
            // 
            this.Upgrade.HeaderText = "Upgrade";
            this.Upgrade.Name = "Upgrade";
            this.Upgrade.Text = "Upgrade";
            this.Upgrade.UseColumnTextForLinkValue = true;
            this.Upgrade.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // Renewal
            // 
            this.Renewal.HeaderText = "Renewal";
            this.Renewal.Name = "Renewal";
            this.Renewal.Text = "Renewal";
            this.Renewal.UseColumnTextForLinkValue = true;
            this.Renewal.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // lblrequestaddnewcat
            // 
            this.lblrequestaddnewcat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblrequestaddnewcat.AutoSize = true;
            this.lblrequestaddnewcat.Location = new System.Drawing.Point(20, 16);
            this.lblrequestaddnewcat.Name = "lblrequestaddnewcat";
            this.lblrequestaddnewcat.Size = new System.Drawing.Size(148, 13);
            this.lblrequestaddnewcat.TabIndex = 0;
            this.lblrequestaddnewcat.Text = "Request Add New Category : ";
            // 
            // txtRequestAddNewCat
            // 
            this.txtRequestAddNewCat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRequestAddNewCat.Location = new System.Drawing.Point(185, 13);
            this.txtRequestAddNewCat.Name = "txtRequestAddNewCat";
            this.txtRequestAddNewCat.Size = new System.Drawing.Size(159, 20);
            this.txtRequestAddNewCat.TabIndex = 1;
            // 
            // cmbTopcat
            // 
            this.cmbTopcat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTopcat.FormattingEnabled = true;
            this.cmbTopcat.Location = new System.Drawing.Point(367, 13);
            this.cmbTopcat.Name = "cmbTopcat";
            this.cmbTopcat.Size = new System.Drawing.Size(145, 21);
            this.cmbTopcat.TabIndex = 2;
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRequest.Location = new System.Drawing.Point(530, 13);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 3;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnMyExam, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnManageQuestion, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnConfigexam, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnAddExam, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblNavigation, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMyUser, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnFinanceWithDraw, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.btnFinanceConfig, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.btnFinanceReports, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.btnSalesReports, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.btnExamReport, 0, 6);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 13;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(225, 734);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // btnMyExam
            // 
            this.btnMyExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMyExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMyExam.FlatAppearance.BorderSize = 0;
            this.btnMyExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyExam.ForeColor = System.Drawing.Color.White;
            this.btnMyExam.Location = new System.Drawing.Point(0, 120);
            this.btnMyExam.Margin = new System.Windows.Forms.Padding(0);
            this.btnMyExam.Name = "btnMyExam";
            this.btnMyExam.Size = new System.Drawing.Size(225, 30);
            this.btnMyExam.TabIndex = 10;
            this.btnMyExam.Text = "My Exam";
            this.btnMyExam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyExam.UseVisualStyleBackColor = false;
            this.btnMyExam.Click += new System.EventHandler(this.btnMyExam_Click);
            // 
            // btnManageQuestion
            // 
            this.btnManageQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnManageQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnManageQuestion.FlatAppearance.BorderSize = 0;
            this.btnManageQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageQuestion.ForeColor = System.Drawing.Color.White;
            this.btnManageQuestion.Location = new System.Drawing.Point(0, 90);
            this.btnManageQuestion.Margin = new System.Windows.Forms.Padding(0);
            this.btnManageQuestion.Name = "btnManageQuestion";
            this.btnManageQuestion.Size = new System.Drawing.Size(225, 30);
            this.btnManageQuestion.TabIndex = 9;
            this.btnManageQuestion.Text = "Manage Question";
            this.btnManageQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageQuestion.UseVisualStyleBackColor = false;
            // 
            // btnConfigexam
            // 
            this.btnConfigexam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConfigexam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfigexam.FlatAppearance.BorderSize = 0;
            this.btnConfigexam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigexam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigexam.ForeColor = System.Drawing.Color.White;
            this.btnConfigexam.Location = new System.Drawing.Point(0, 60);
            this.btnConfigexam.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfigexam.Name = "btnConfigexam";
            this.btnConfigexam.Size = new System.Drawing.Size(225, 30);
            this.btnConfigexam.TabIndex = 8;
            this.btnConfigexam.Text = "Config Exam";
            this.btnConfigexam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigexam.UseVisualStyleBackColor = false;
            this.btnConfigexam.Click += new System.EventHandler(this.btnConfigexam_Click);
            // 
            // btnAddExam
            // 
            this.btnAddExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAddExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddExam.FlatAppearance.BorderSize = 0;
            this.btnAddExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExam.ForeColor = System.Drawing.Color.White;
            this.btnAddExam.Location = new System.Drawing.Point(0, 30);
            this.btnAddExam.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(225, 30);
            this.btnAddExam.TabIndex = 7;
            this.btnAddExam.Text = "Add Exam";
            this.btnAddExam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddExam.UseVisualStyleBackColor = false;
            // 
            // lblNavigation
            // 
            this.lblNavigation.AutoSize = true;
            this.lblNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNavigation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavigation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(145)))), ((int)(((byte)(33)))));
            this.lblNavigation.Location = new System.Drawing.Point(0, 0);
            this.lblNavigation.Margin = new System.Windows.Forms.Padding(0);
            this.lblNavigation.Name = "lblNavigation";
            this.lblNavigation.Size = new System.Drawing.Size(225, 30);
            this.lblNavigation.TabIndex = 1;
            this.lblNavigation.Text = "Navigation ";
            this.lblNavigation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMyUser
            // 
            this.btnMyUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnMyUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMyUser.FlatAppearance.BorderSize = 0;
            this.btnMyUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyUser.ForeColor = System.Drawing.Color.White;
            this.btnMyUser.Location = new System.Drawing.Point(0, 150);
            this.btnMyUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnMyUser.Name = "btnMyUser";
            this.btnMyUser.Size = new System.Drawing.Size(225, 30);
            this.btnMyUser.TabIndex = 15;
            this.btnMyUser.Text = "My User";
            this.btnMyUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyUser.UseVisualStyleBackColor = false;
            this.btnMyUser.Click += new System.EventHandler(this.btnMyUser_Click);
            // 
            // btnSalesReports
            // 
            this.btnSalesReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSalesReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalesReports.FlatAppearance.BorderSize = 0;
            this.btnSalesReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReports.ForeColor = System.Drawing.Color.White;
            this.btnSalesReports.Location = new System.Drawing.Point(0, 210);
            this.btnSalesReports.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalesReports.Name = "btnSalesReports";
            this.btnSalesReports.Size = new System.Drawing.Size(225, 32);
            this.btnSalesReports.TabIndex = 11;
            this.btnSalesReports.Text = "Sales Reports";
            this.btnSalesReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesReports.UseVisualStyleBackColor = false;
            this.btnSalesReports.Click += new System.EventHandler(this.btnSalesReports_Click);
            // 
            // btnFinanceReports
            // 
            this.btnFinanceReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFinanceReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinanceReports.FlatAppearance.BorderSize = 0;
            this.btnFinanceReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanceReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceReports.ForeColor = System.Drawing.Color.White;
            this.btnFinanceReports.Location = new System.Drawing.Point(0, 242);
            this.btnFinanceReports.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinanceReports.Name = "btnFinanceReports";
            this.btnFinanceReports.Size = new System.Drawing.Size(225, 33);
            this.btnFinanceReports.TabIndex = 12;
            this.btnFinanceReports.Text = "Finance Reports";
            this.btnFinanceReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinanceReports.UseVisualStyleBackColor = false;
            // 
            // btnFinanceConfig
            // 
            this.btnFinanceConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFinanceConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinanceConfig.FlatAppearance.BorderSize = 0;
            this.btnFinanceConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanceConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceConfig.ForeColor = System.Drawing.Color.White;
            this.btnFinanceConfig.Location = new System.Drawing.Point(0, 275);
            this.btnFinanceConfig.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinanceConfig.Name = "btnFinanceConfig";
            this.btnFinanceConfig.Size = new System.Drawing.Size(225, 34);
            this.btnFinanceConfig.TabIndex = 16;
            this.btnFinanceConfig.Text = "Finance Config";
            this.btnFinanceConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinanceConfig.UseVisualStyleBackColor = false;
            this.btnFinanceConfig.Click += new System.EventHandler(this.btnFinanceConfig_Click);
            // 
            // btnFinanceWithDraw
            // 
            this.btnFinanceWithDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFinanceWithDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinanceWithDraw.FlatAppearance.BorderSize = 0;
            this.btnFinanceWithDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinanceWithDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceWithDraw.ForeColor = System.Drawing.Color.White;
            this.btnFinanceWithDraw.Location = new System.Drawing.Point(0, 309);
            this.btnFinanceWithDraw.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinanceWithDraw.Name = "btnFinanceWithDraw";
            this.btnFinanceWithDraw.Size = new System.Drawing.Size(225, 35);
            this.btnFinanceWithDraw.TabIndex = 17;
            this.btnFinanceWithDraw.Text = "Finance WithDraw";
            this.btnFinanceWithDraw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinanceWithDraw.UseVisualStyleBackColor = false;
            this.btnFinanceWithDraw.Click += new System.EventHandler(this.btnFinanceWithDraw_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dgvMerchantProfile);
            this.panel1.Controls.Add(this.dgvExamMerchant);
            this.panel1.Location = new System.Drawing.Point(225, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 733);
            this.panel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRequest);
            this.groupBox1.Controls.Add(this.cmbTopcat);
            this.groupBox1.Controls.Add(this.txtRequestAddNewCat);
            this.groupBox1.Controls.Add(this.lblrequestaddnewcat);
            this.groupBox1.Location = new System.Drawing.Point(3, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 40);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnExamReport
            // 
            this.btnExamReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnExamReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExamReport.FlatAppearance.BorderSize = 0;
            this.btnExamReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExamReport.ForeColor = System.Drawing.Color.White;
            this.btnExamReport.Location = new System.Drawing.Point(0, 180);
            this.btnExamReport.Margin = new System.Windows.Forms.Padding(0);
            this.btnExamReport.Name = "btnExamReport";
            this.btnExamReport.Size = new System.Drawing.Size(225, 30);
            this.btnExamReport.TabIndex = 18;
            this.btnExamReport.Text = "Exam Report";
            this.btnExamReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamReport.UseVisualStyleBackColor = false;
            this.btnExamReport.Click += new System.EventHandler(this.btnExamReport_Click);
            // 
            // MDIfrmMerchantDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1022, 726);
            this.Name = "MDIfrmMerchantDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merchant Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamMerchant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMerchantProfile)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnMyExam;
        private System.Windows.Forms.Button btnManageQuestion;
        private System.Windows.Forms.Button btnConfigexam;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.Label lblNavigation;
        private System.Windows.Forms.Button btnFinanceReports;
        private System.Windows.Forms.Button btnSalesReports;
        private System.Windows.Forms.Button btnMyUser;
        private System.Windows.Forms.Button btnFinanceConfig;
        private System.Windows.Forms.Button btnFinanceWithDraw;
        private System.Windows.Forms.DataGridView dgvMerchantProfile;
        private System.Windows.Forms.Label lblrequestaddnewcat;
        private System.Windows.Forms.TextBox txtRequestAddNewCat;
        private System.Windows.Forms.ComboBox cmbTopcat;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.DataGridView dgvExamMerchant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MerchantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewLinkColumn Upgrade;
        private System.Windows.Forms.DataGridViewLinkColumn Renewal;
        private System.Windows.Forms.DataGridViewLinkColumn Review;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewLinkColumn OnlyTestOnce;
        private System.Windows.Forms.DataGridViewLinkColumn AllowPrint;
        private System.Windows.Forms.DataGridViewLinkColumn AllowSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExamReport;
    }
}



