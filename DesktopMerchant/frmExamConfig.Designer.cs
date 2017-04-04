namespace DesktopMerchant
{
    partial class frmExamConfig
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvExamManage = new System.Windows.Forms.DataGridView();
            this.ExamManageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassingPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblRandom = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblValiddate = new System.Windows.Forms.Label();
            this.txtTestoption = new System.Windows.Forms.TextBox();
            this.lblTestoption = new System.Windows.Forms.Label();
            this.cmbSecondcat = new System.Windows.Forms.ComboBox();
            this.cmbTopcate = new System.Windows.Forms.ComboBox();
            this.txtTesttimemin = new System.Windows.Forms.TextBox();
            this.lblTesttimeminute = new System.Windows.Forms.Label();
            this.txtPassingpercentage = new System.Windows.Forms.TextBox();
            this.lblPassingpercent = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtExamtitle = new System.Windows.Forms.TextBox();
            this.lblExamTitle = new System.Windows.Forms.Label();
            this.txtExamcode = new System.Windows.Forms.TextBox();
            this.lblExamcode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamManage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 738);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvExamManage);
            this.panel2.Location = new System.Drawing.Point(225, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 738);
            this.panel2.TabIndex = 0;
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
            this.ExamTitle,
            this.Category,
            this.PassingPercentage,
            this.TestTime,
            this.ValidDate,
            this.TopCategory,
            this.SecondCategory,
            this.TestOption,
            this.Edit,
            this.Delete});
            this.dgvExamManage.GridColor = System.Drawing.Color.DarkGray;
            this.dgvExamManage.Location = new System.Drawing.Point(9, 321);
            this.dgvExamManage.Name = "dgvExamManage";
            this.dgvExamManage.Size = new System.Drawing.Size(768, 403);
            this.dgvExamManage.TabIndex = 19;
            this.dgvExamManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamManage_CellContentClick);
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
            // ExamTitle
            // 
            this.ExamTitle.HeaderText = "Exam Title";
            this.ExamTitle.Name = "ExamTitle";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // PassingPercentage
            // 
            this.PassingPercentage.HeaderText = "Passing Percentage";
            this.PassingPercentage.Name = "PassingPercentage";
            // 
            // TestTime
            // 
            this.TestTime.HeaderText = "Test Time";
            this.TestTime.Name = "TestTime";
            // 
            // ValidDate
            // 
            this.ValidDate.HeaderText = "Valid Date";
            this.ValidDate.Name = "ValidDate";
            // 
            // TopCategory
            // 
            this.TopCategory.HeaderText = "Top Category";
            this.TopCategory.Name = "TopCategory";
            // 
            // SecondCategory
            // 
            this.SecondCategory.HeaderText = "Second Category";
            this.SecondCategory.Name = "SecondCategory";
            // 
            // TestOption
            // 
            this.TestOption.HeaderText = "Test Option";
            this.TestOption.Name = "TestOption";
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
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(334, 206);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(49, 13);
            this.lblQuestion.TabIndex = 18;
            this.lblQuestion.Text = "Question";
            // 
            // lblRandom
            // 
            this.lblRandom.AutoSize = true;
            this.lblRandom.Location = new System.Drawing.Point(125, 206);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(47, 13);
            this.lblRandom.TabIndex = 17;
            this.lblRandom.Text = "Random";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(128, 277);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(125, 243);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(28, 13);
            this.lbldate.TabIndex = 15;
            this.lbldate.Text = "date";
            // 
            // lblValiddate
            // 
            this.lblValiddate.AutoSize = true;
            this.lblValiddate.Location = new System.Drawing.Point(6, 243);
            this.lblValiddate.Name = "lblValiddate";
            this.lblValiddate.Size = new System.Drawing.Size(56, 13);
            this.lblValiddate.TabIndex = 14;
            this.lblValiddate.Text = "Valid Date";
            // 
            // txtTestoption
            // 
            this.txtTestoption.Location = new System.Drawing.Point(181, 203);
            this.txtTestoption.Name = "txtTestoption";
            this.txtTestoption.Size = new System.Drawing.Size(130, 20);
            this.txtTestoption.TabIndex = 13;
            this.txtTestoption.TextChanged += new System.EventHandler(this.txt_changed);
            // 
            // lblTestoption
            // 
            this.lblTestoption.AutoSize = true;
            this.lblTestoption.Location = new System.Drawing.Point(6, 206);
            this.lblTestoption.Name = "lblTestoption";
            this.lblTestoption.Size = new System.Drawing.Size(62, 13);
            this.lblTestoption.TabIndex = 12;
            this.lblTestoption.Text = "Test Option";
            // 
            // cmbSecondcat
            // 
            this.cmbSecondcat.FormattingEnabled = true;
            this.cmbSecondcat.Location = new System.Drawing.Point(283, 89);
            this.cmbSecondcat.Name = "cmbSecondcat";
            this.cmbSecondcat.Size = new System.Drawing.Size(100, 21);
            this.cmbSecondcat.TabIndex = 11;
            // 
            // cmbTopcate
            // 
            this.cmbTopcate.FormattingEnabled = true;
            this.cmbTopcate.Location = new System.Drawing.Point(128, 89);
            this.cmbTopcate.Name = "cmbTopcate";
            this.cmbTopcate.Size = new System.Drawing.Size(137, 21);
            this.cmbTopcate.TabIndex = 10;
            this.cmbTopcate.SelectedIndexChanged += new System.EventHandler(this.cmbTopcate_SelectedIndexChanged);
            // 
            // txtTesttimemin
            // 
            this.txtTesttimemin.Location = new System.Drawing.Point(128, 161);
            this.txtTesttimemin.Name = "txtTesttimemin";
            this.txtTesttimemin.Size = new System.Drawing.Size(137, 20);
            this.txtTesttimemin.TabIndex = 9;
            this.txtTesttimemin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_keypressNoDecimal);
            // 
            // lblTesttimeminute
            // 
            this.lblTesttimeminute.AutoSize = true;
            this.lblTesttimeminute.Location = new System.Drawing.Point(6, 168);
            this.lblTesttimeminute.Name = "lblTesttimeminute";
            this.lblTesttimeminute.Size = new System.Drawing.Size(80, 13);
            this.lblTesttimeminute.TabIndex = 8;
            this.lblTesttimeminute.Text = "Test Time (Min)";
            // 
            // txtPassingpercentage
            // 
            this.txtPassingpercentage.Location = new System.Drawing.Point(128, 127);
            this.txtPassingpercentage.Name = "txtPassingpercentage";
            this.txtPassingpercentage.Size = new System.Drawing.Size(137, 20);
            this.txtPassingpercentage.TabIndex = 7;
            this.txtPassingpercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblPassingpercent
            // 
            this.lblPassingpercent.AutoSize = true;
            this.lblPassingpercent.Location = new System.Drawing.Point(6, 130);
            this.lblPassingpercent.Name = "lblPassingpercent";
            this.lblPassingpercent.Size = new System.Drawing.Size(102, 13);
            this.lblPassingpercent.TabIndex = 6;
            this.lblPassingpercent.Text = "Passing Percentage";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(6, 92);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category";
            // 
            // txtExamtitle
            // 
            this.txtExamtitle.Location = new System.Drawing.Point(128, 51);
            this.txtExamtitle.Name = "txtExamtitle";
            this.txtExamtitle.Size = new System.Drawing.Size(137, 20);
            this.txtExamtitle.TabIndex = 3;
            this.txtExamtitle.TextChanged += new System.EventHandler(this.txt_changed);
            // 
            // lblExamTitle
            // 
            this.lblExamTitle.AutoSize = true;
            this.lblExamTitle.Location = new System.Drawing.Point(6, 54);
            this.lblExamTitle.Name = "lblExamTitle";
            this.lblExamTitle.Size = new System.Drawing.Size(56, 13);
            this.lblExamTitle.TabIndex = 2;
            this.lblExamTitle.Text = "Exam Title";
            // 
            // txtExamcode
            // 
            this.txtExamcode.Location = new System.Drawing.Point(128, 13);
            this.txtExamcode.Name = "txtExamcode";
            this.txtExamcode.Size = new System.Drawing.Size(137, 20);
            this.txtExamcode.TabIndex = 1;
            this.txtExamcode.TextChanged += new System.EventHandler(this.txt_changed);
            // 
            // lblExamcode
            // 
            this.lblExamcode.AutoSize = true;
            this.lblExamcode.Location = new System.Drawing.Point(6, 16);
            this.lblExamcode.Name = "lblExamcode";
            this.lblExamcode.Size = new System.Drawing.Size(61, 13);
            this.lblExamcode.TabIndex = 0;
            this.lblExamcode.Text = "Exam Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblExamcode);
            this.groupBox1.Controls.Add(this.txtExamcode);
            this.groupBox1.Controls.Add(this.lblQuestion);
            this.groupBox1.Controls.Add(this.lblExamTitle);
            this.groupBox1.Controls.Add(this.lblRandom);
            this.groupBox1.Controls.Add(this.txtExamtitle);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.lbldate);
            this.groupBox1.Controls.Add(this.lblPassingpercent);
            this.groupBox1.Controls.Add(this.lblValiddate);
            this.groupBox1.Controls.Add(this.txtPassingpercentage);
            this.groupBox1.Controls.Add(this.txtTestoption);
            this.groupBox1.Controls.Add(this.lblTesttimeminute);
            this.groupBox1.Controls.Add(this.lblTestoption);
            this.groupBox1.Controls.Add(this.txtTesttimemin);
            this.groupBox1.Controls.Add(this.cmbSecondcat);
            this.groupBox1.Controls.Add(this.cmbTopcate);
            this.groupBox1.Location = new System.Drawing.Point(9, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 313);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // frmExamConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 741);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExamConfig";
            this.Text = "Exam Config";
            this.Load += new System.EventHandler(this.frmExamConfig_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamManage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblValiddate;
        private System.Windows.Forms.TextBox txtTestoption;
        private System.Windows.Forms.Label lblTestoption;
        private System.Windows.Forms.ComboBox cmbSecondcat;
        private System.Windows.Forms.ComboBox cmbTopcate;
        private System.Windows.Forms.TextBox txtTesttimemin;
        private System.Windows.Forms.Label lblTesttimeminute;
        private System.Windows.Forms.TextBox txtPassingpercentage;
        private System.Windows.Forms.Label lblPassingpercent;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtExamtitle;
        private System.Windows.Forms.Label lblExamTitle;
        private System.Windows.Forms.TextBox txtExamcode;
        private System.Windows.Forms.Label lblExamcode;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblRandom;
        private System.Windows.Forms.DataGridView dgvExamManage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamManageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassingPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestOption;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}