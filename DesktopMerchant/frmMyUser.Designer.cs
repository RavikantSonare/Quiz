namespace DesktopMerchant
{
    partial class frmMyUser
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvExamMerchant = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblusername = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblAddUser = new System.Windows.Forms.Label();
            this.lblAccesspassword = new System.Windows.Forms.Label();
            this.txtAccesspassword = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblExam = new System.Windows.Forms.Label();
            this.dgvChklist = new System.Windows.Forms.DataGridView();
            this.lblValidtime = new System.Windows.Forms.Label();
            this.txtValidTime = new System.Windows.Forms.TextBox();
            this.lblAccessoption = new System.Windows.Forms.Label();
            this.chkOnline = new System.Windows.Forms.CheckBox();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamMerchant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 737);
            this.panel1.TabIndex = 0;
            // 
            // dgvExamMerchant
            // 
            this.dgvExamMerchant.AllowUserToAddRows = false;
            this.dgvExamMerchant.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExamMerchant.BackgroundColor = System.Drawing.Color.White;
            this.dgvExamMerchant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamMerchant.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.UserName,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.ItemPrice,
            this.Edit,
            this.Delete});
            this.dgvExamMerchant.Location = new System.Drawing.Point(13, 376);
            this.dgvExamMerchant.Name = "dgvExamMerchant";
            this.dgvExamMerchant.Size = new System.Drawing.Size(777, 352);
            this.dgvExamMerchant.TabIndex = 9;
            this.dgvExamMerchant.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamMerchant_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "UserId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccessPassword";
            this.dataGridViewTextBoxColumn2.HeaderText = "Access Password";
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
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ExamCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "Exam Code";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ValidTime";
            this.dataGridViewTextBoxColumn5.HeaderText = "Valid Time";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "AccessOoption";
            this.ItemPrice.HeaderText = "Access Option";
            this.ItemPrice.Name = "ItemPrice";
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
            // lblusername
            // 
            this.lblusername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(6, 42);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(112, 13);
            this.lblusername.TabIndex = 1;
            this.lblusername.Text = "UserName/RealName";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(136, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // lblAddUser
            // 
            this.lblAddUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddUser.AutoSize = true;
            this.lblAddUser.Location = new System.Drawing.Point(133, 18);
            this.lblAddUser.Name = "lblAddUser";
            this.lblAddUser.Size = new System.Drawing.Size(51, 13);
            this.lblAddUser.TabIndex = 0;
            this.lblAddUser.Text = "Add User";
            // 
            // lblAccesspassword
            // 
            this.lblAccesspassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccesspassword.AutoSize = true;
            this.lblAccesspassword.Location = new System.Drawing.Point(6, 74);
            this.lblAccesspassword.Name = "lblAccesspassword";
            this.lblAccesspassword.Size = new System.Drawing.Size(91, 13);
            this.lblAccesspassword.TabIndex = 1;
            this.lblAccesspassword.Text = "Access Password";
            // 
            // txtAccesspassword
            // 
            this.txtAccesspassword.Location = new System.Drawing.Point(136, 70);
            this.txtAccesspassword.Name = "txtAccesspassword";
            this.txtAccesspassword.Size = new System.Drawing.Size(100, 20);
            this.txtAccesspassword.TabIndex = 2;
            this.txtAccesspassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtAccesspassword_Validating);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(6, 109);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(136, 105);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCategory_Validating);
            // 
            // lblExam
            // 
            this.lblExam.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExam.AutoSize = true;
            this.lblExam.Location = new System.Drawing.Point(6, 163);
            this.lblExam.Name = "lblExam";
            this.lblExam.Size = new System.Drawing.Size(33, 13);
            this.lblExam.TabIndex = 0;
            this.lblExam.Text = "Exam";
            // 
            // dgvChklist
            // 
            this.dgvChklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChklist.Location = new System.Drawing.Point(136, 132);
            this.dgvChklist.Name = "dgvChklist";
            this.dgvChklist.Size = new System.Drawing.Size(173, 108);
            this.dgvChklist.TabIndex = 1;
            // 
            // lblValidtime
            // 
            this.lblValidtime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValidtime.AutoSize = true;
            this.lblValidtime.Location = new System.Drawing.Point(6, 250);
            this.lblValidtime.Name = "lblValidtime";
            this.lblValidtime.Size = new System.Drawing.Size(56, 13);
            this.lblValidtime.TabIndex = 1;
            this.lblValidtime.Text = "Valid Time";
            // 
            // txtValidTime
            // 
            this.txtValidTime.Location = new System.Drawing.Point(136, 246);
            this.txtValidTime.Name = "txtValidTime";
            this.txtValidTime.Size = new System.Drawing.Size(100, 20);
            this.txtValidTime.TabIndex = 2;
            this.txtValidTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValidTime_KeyPress);
            // 
            // lblAccessoption
            // 
            this.lblAccessoption.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccessoption.AutoSize = true;
            this.lblAccessoption.Location = new System.Drawing.Point(6, 280);
            this.lblAccessoption.Name = "lblAccessoption";
            this.lblAccessoption.Size = new System.Drawing.Size(76, 13);
            this.lblAccessoption.TabIndex = 1;
            this.lblAccessoption.Text = "Access Option";
            // 
            // chkOnline
            // 
            this.chkOnline.AutoSize = true;
            this.chkOnline.Checked = true;
            this.chkOnline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnline.Location = new System.Drawing.Point(136, 278);
            this.chkOnline.Name = "chkOnline";
            this.chkOnline.Size = new System.Drawing.Size(56, 17);
            this.chkOnline.TabIndex = 0;
            this.chkOnline.Text = "Online";
            this.chkOnline.UseVisualStyleBackColor = true;
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(201, 278);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(56, 17);
            this.chkOffline.TabIndex = 1;
            this.chkOffline.Text = "Offline";
            this.chkOffline.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(136, 310);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvExamMerchant);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(226, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 736);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.chkOffline);
            this.groupBox1.Controls.Add(this.chkOnline);
            this.groupBox1.Controls.Add(this.lblAccessoption);
            this.groupBox1.Controls.Add(this.txtValidTime);
            this.groupBox1.Controls.Add(this.lblValidtime);
            this.groupBox1.Controls.Add(this.dgvChklist);
            this.groupBox1.Controls.Add(this.lblExam);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.txtAccesspassword);
            this.groupBox1.Controls.Add(this.lblAccesspassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.lblusername);
            this.groupBox1.Controls.Add(this.lblAddUser);
            this.groupBox1.Location = new System.Drawing.Point(13, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 359);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // frmMyUser
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
            this.Name = "frmMyUser";
            this.Text = "My User";
            this.Load += new System.EventHandler(this.frmMyUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamMerchant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAddUser;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblAccesspassword;
        private System.Windows.Forms.TextBox txtAccesspassword;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblExam;
        private System.Windows.Forms.Label lblValidtime;
        private System.Windows.Forms.Label lblAccessoption;
        private System.Windows.Forms.CheckBox chkOnline;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvExamMerchant;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgvChklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.TextBox txtValidTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}