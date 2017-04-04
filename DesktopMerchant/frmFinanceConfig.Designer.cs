namespace DesktopMerchant
{
    partial class frmFinanceConfig
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
            this.dgvFinanceConfig = new System.Windows.Forms.DataGridView();
            this.FinanceConfigId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentOptionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankOfName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SwiftCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblmessage = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlWiretransfer = new System.Windows.Forms.Panel();
            this.txtSwiftCode = new System.Windows.Forms.TextBox();
            this.lblSwiftCode = new System.Windows.Forms.Label();
            this.txtBankOfName = new System.Windows.Forms.TextBox();
            this.lblBankOfName = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.pnlPaypal = new System.Windows.Forms.Panel();
            this.txtAccountEmail = new System.Windows.Forms.TextBox();
            this.lblAccountEmail = new System.Windows.Forms.Label();
            this.cmbPaymentOption = new System.Windows.Forms.ComboBox();
            this.lblPaymentReceive = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanceConfig)).BeginInit();
            this.pnlWiretransfer.SuspendLayout();
            this.pnlPaypal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 740);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvFinanceConfig);
            this.panel2.Controls.Add(this.lblmessage);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.pnlWiretransfer);
            this.panel2.Controls.Add(this.pnlPaypal);
            this.panel2.Controls.Add(this.cmbPaymentOption);
            this.panel2.Controls.Add(this.lblPaymentReceive);
            this.panel2.Location = new System.Drawing.Point(225, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 738);
            this.panel2.TabIndex = 0;
            // 
            // dgvFinanceConfig
            // 
            this.dgvFinanceConfig.AllowUserToAddRows = false;
            this.dgvFinanceConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFinanceConfig.BackgroundColor = System.Drawing.Color.White;
            this.dgvFinanceConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinanceConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FinanceConfigId,
            this.PaymentOptionId,
            this.PaymentOption,
            this.AccountEmail,
            this.FirstName,
            this.LastName,
            this.Country,
            this.City,
            this.BankOfName,
            this.SwiftCode,
            this.Edit});
            this.dgvFinanceConfig.GridColor = System.Drawing.Color.DarkGray;
            this.dgvFinanceConfig.Location = new System.Drawing.Point(9, 237);
            this.dgvFinanceConfig.Name = "dgvFinanceConfig";
            this.dgvFinanceConfig.Size = new System.Drawing.Size(257, 131);
            this.dgvFinanceConfig.TabIndex = 21;
            this.dgvFinanceConfig.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFinanceConfig_CellContentClick);
            // 
            // FinanceConfigId
            // 
            this.FinanceConfigId.HeaderText = "Id";
            this.FinanceConfigId.Name = "FinanceConfigId";
            // 
            // PaymentOptionId
            // 
            this.PaymentOptionId.HeaderText = "POId";
            this.PaymentOptionId.Name = "PaymentOptionId";
            // 
            // PaymentOption
            // 
            this.PaymentOption.HeaderText = "Payment Option";
            this.PaymentOption.Name = "PaymentOption";
            // 
            // AccountEmail
            // 
            this.AccountEmail.HeaderText = "Account Email";
            this.AccountEmail.Name = "AccountEmail";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // BankOfName
            // 
            this.BankOfName.HeaderText = "Bank Name";
            this.BankOfName.Name = "BankOfName";
            // 
            // SwiftCode
            // 
            this.SwiftCode.HeaderText = "Swift Code";
            this.SwiftCode.Name = "SwiftCode";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // lblmessage
            // 
            this.lblmessage.AutoSize = true;
            this.lblmessage.Location = new System.Drawing.Point(6, 209);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(191, 13);
            this.lblmessage.TabIndex = 5;
            this.lblmessage.Text = "You Currently Payment Receive Option";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(127, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlWiretransfer
            // 
            this.pnlWiretransfer.Controls.Add(this.txtSwiftCode);
            this.pnlWiretransfer.Controls.Add(this.lblSwiftCode);
            this.pnlWiretransfer.Controls.Add(this.txtBankOfName);
            this.pnlWiretransfer.Controls.Add(this.lblBankOfName);
            this.pnlWiretransfer.Controls.Add(this.txtCity);
            this.pnlWiretransfer.Controls.Add(this.lblCity);
            this.pnlWiretransfer.Controls.Add(this.txtCountry);
            this.pnlWiretransfer.Controls.Add(this.lblCountry);
            this.pnlWiretransfer.Controls.Add(this.txtLastName);
            this.pnlWiretransfer.Controls.Add(this.lblLastName);
            this.pnlWiretransfer.Controls.Add(this.txtFirstName);
            this.pnlWiretransfer.Controls.Add(this.lblFirstName);
            this.pnlWiretransfer.Location = new System.Drawing.Point(3, 83);
            this.pnlWiretransfer.Name = "pnlWiretransfer";
            this.pnlWiretransfer.Size = new System.Drawing.Size(777, 79);
            this.pnlWiretransfer.TabIndex = 3;
            this.pnlWiretransfer.Visible = false;
            // 
            // txtSwiftCode
            // 
            this.txtSwiftCode.Location = new System.Drawing.Point(318, 41);
            this.txtSwiftCode.Name = "txtSwiftCode";
            this.txtSwiftCode.Size = new System.Drawing.Size(121, 20);
            this.txtSwiftCode.TabIndex = 13;
            this.txtSwiftCode.TextChanged += new System.EventHandler(this.txt_textChanged);
            // 
            // lblSwiftCode
            // 
            this.lblSwiftCode.AutoSize = true;
            this.lblSwiftCode.Location = new System.Drawing.Point(255, 44);
            this.lblSwiftCode.Name = "lblSwiftCode";
            this.lblSwiftCode.Size = new System.Drawing.Size(58, 13);
            this.lblSwiftCode.TabIndex = 12;
            this.lblSwiftCode.Text = "Swift Code";
            // 
            // txtBankOfName
            // 
            this.txtBankOfName.Location = new System.Drawing.Point(124, 41);
            this.txtBankOfName.Name = "txtBankOfName";
            this.txtBankOfName.Size = new System.Drawing.Size(121, 20);
            this.txtBankOfName.TabIndex = 11;
            this.txtBankOfName.TextChanged += new System.EventHandler(this.txt_textChanged);
            // 
            // lblBankOfName
            // 
            this.lblBankOfName.AutoSize = true;
            this.lblBankOfName.Location = new System.Drawing.Point(3, 44);
            this.lblBankOfName.Name = "lblBankOfName";
            this.lblBankOfName.Size = new System.Drawing.Size(77, 13);
            this.lblBankOfName.TabIndex = 10;
            this.lblBankOfName.Text = "Bank Of Name";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(653, 7);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(121, 20);
            this.txtCity.TabIndex = 9;
            this.txtCity.TextChanged += new System.EventHandler(this.txt_textChanged);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(624, 10);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 8;
            this.lblCity.Text = "City";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(497, 7);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(121, 20);
            this.txtCountry.TabIndex = 7;
            this.txtCountry.TextChanged += new System.EventHandler(this.txt_textChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(447, 10);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 6;
            this.lblCountry.Text = "Country";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(318, 7);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 20);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.TextChanged += new System.EventHandler(this.txt_textChanged);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(255, 10);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(124, 7);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 20);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txt_textChanged);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(3, 10);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name";
            // 
            // pnlPaypal
            // 
            this.pnlPaypal.Controls.Add(this.txtAccountEmail);
            this.pnlPaypal.Controls.Add(this.lblAccountEmail);
            this.pnlPaypal.Location = new System.Drawing.Point(3, 43);
            this.pnlPaypal.Name = "pnlPaypal";
            this.pnlPaypal.Size = new System.Drawing.Size(777, 36);
            this.pnlPaypal.TabIndex = 2;
            this.pnlPaypal.Visible = false;
            // 
            // txtAccountEmail
            // 
            this.txtAccountEmail.Location = new System.Drawing.Point(124, 9);
            this.txtAccountEmail.Name = "txtAccountEmail";
            this.txtAccountEmail.Size = new System.Drawing.Size(121, 20);
            this.txtAccountEmail.TabIndex = 1;
            this.txtAccountEmail.TextChanged += new System.EventHandler(this.txt_textChanged);
            // 
            // lblAccountEmail
            // 
            this.lblAccountEmail.AutoSize = true;
            this.lblAccountEmail.Location = new System.Drawing.Point(3, 12);
            this.lblAccountEmail.Name = "lblAccountEmail";
            this.lblAccountEmail.Size = new System.Drawing.Size(75, 13);
            this.lblAccountEmail.TabIndex = 0;
            this.lblAccountEmail.Text = "Account Email";
            // 
            // cmbPaymentOption
            // 
            this.cmbPaymentOption.FormattingEnabled = true;
            this.cmbPaymentOption.Location = new System.Drawing.Point(127, 16);
            this.cmbPaymentOption.Name = "cmbPaymentOption";
            this.cmbPaymentOption.Size = new System.Drawing.Size(121, 21);
            this.cmbPaymentOption.TabIndex = 1;
            this.cmbPaymentOption.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentOption_SelectedIndexChanged);
            // 
            // lblPaymentReceive
            // 
            this.lblPaymentReceive.AutoSize = true;
            this.lblPaymentReceive.Location = new System.Drawing.Point(6, 19);
            this.lblPaymentReceive.Name = "lblPaymentReceive";
            this.lblPaymentReceive.Size = new System.Drawing.Size(119, 13);
            this.lblPaymentReceive.TabIndex = 0;
            this.lblPaymentReceive.Text = "Paymet Receive Option";
            // 
            // frmFinanceConfig
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
            this.Name = "frmFinanceConfig";
            this.Text = "Finance Config";
            this.Load += new System.EventHandler(this.frmFinanceConfig_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanceConfig)).EndInit();
            this.pnlWiretransfer.ResumeLayout(false);
            this.pnlWiretransfer.PerformLayout();
            this.pnlPaypal.ResumeLayout(false);
            this.pnlPaypal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblmessage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlWiretransfer;
        private System.Windows.Forms.TextBox txtSwiftCode;
        private System.Windows.Forms.Label lblSwiftCode;
        private System.Windows.Forms.TextBox txtBankOfName;
        private System.Windows.Forms.Label lblBankOfName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Panel pnlPaypal;
        private System.Windows.Forms.TextBox txtAccountEmail;
        private System.Windows.Forms.Label lblAccountEmail;
        private System.Windows.Forms.ComboBox cmbPaymentOption;
        private System.Windows.Forms.Label lblPaymentReceive;
        private System.Windows.Forms.DataGridView dgvFinanceConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinanceConfigId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentOptionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankOfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SwiftCode;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
    }
}