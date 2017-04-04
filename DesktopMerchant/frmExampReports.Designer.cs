namespace DesktopMerchant
{
    partial class frmExampReports
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
            this.dgvTemplate = new System.Windows.Forms.DataGridView();
            this.TemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CertificateTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplatePicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.TemplatePic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblsamplemsg = new System.Windows.Forms.Label();
            this.lblSample = new System.Windows.Forms.Label();
            this.btnphoto = new System.Windows.Forms.Button();
            this.txtTemplatePicture = new System.Windows.Forms.TextBox();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.txtCertificateTitle = new System.Windows.Forms.TextBox();
            this.lblCertificateTitle = new System.Windows.Forms.Label();
            this.lblTemplatePicture = new System.Windows.Forms.Label();
            this.dgvExamReports = new System.Windows.Forms.DataGridView();
            this.ExamReportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassFail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowPrint = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DegitalCertificate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Generate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamReports)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 740);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTemplate);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvExamReports);
            this.panel2.Location = new System.Drawing.Point(231, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 740);
            this.panel2.TabIndex = 1;
            // 
            // dgvTemplate
            // 
            this.dgvTemplate.AllowUserToAddRows = false;
            this.dgvTemplate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTemplate.BackgroundColor = System.Drawing.Color.White;
            this.dgvTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TemplateId,
            this.CertificateTitle,
            this.TemplatePicture,
            this.TemplatePic,
            this.Edit,
            this.Delete});
            this.dgvTemplate.Location = new System.Drawing.Point(3, 526);
            this.dgvTemplate.Name = "dgvTemplate";
            this.dgvTemplate.ReadOnly = true;
            this.dgvTemplate.Size = new System.Drawing.Size(772, 150);
            this.dgvTemplate.TabIndex = 2;
            this.dgvTemplate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTemplate_CellContentClick);
            // 
            // TemplateId
            // 
            this.TemplateId.HeaderText = "Template Id";
            this.TemplateId.Name = "TemplateId";
            this.TemplateId.ReadOnly = true;
            // 
            // CertificateTitle
            // 
            this.CertificateTitle.HeaderText = "Certificate Title";
            this.CertificateTitle.Name = "CertificateTitle";
            this.CertificateTitle.ReadOnly = true;
            // 
            // TemplatePicture
            // 
            this.TemplatePicture.HeaderText = "Template Picture";
            this.TemplatePicture.Name = "TemplatePicture";
            this.TemplatePicture.ReadOnly = true;
            // 
            // TemplatePic
            // 
            this.TemplatePic.HeaderText = "Template Picture";
            this.TemplatePic.Name = "TemplatePic";
            this.TemplatePic.ReadOnly = true;
            // 
            // Edit
            // 
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblsamplemsg);
            this.groupBox1.Controls.Add(this.lblSample);
            this.groupBox1.Controls.Add(this.btnphoto);
            this.groupBox1.Controls.Add(this.txtTemplatePicture);
            this.groupBox1.Controls.Add(this.btnSaveTemplate);
            this.groupBox1.Controls.Add(this.txtCertificateTitle);
            this.groupBox1.Controls.Add(this.lblCertificateTitle);
            this.groupBox1.Controls.Add(this.lblTemplatePicture);
            this.groupBox1.Location = new System.Drawing.Point(3, 362);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 158);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblsamplemsg
            // 
            this.lblsamplemsg.AutoSize = true;
            this.lblsamplemsg.Location = new System.Drawing.Point(108, 95);
            this.lblsamplemsg.Name = "lblsamplemsg";
            this.lblsamplemsg.Size = new System.Drawing.Size(65, 13);
            this.lblsamplemsg.TabIndex = 7;
            this.lblsamplemsg.Text = "Review msg";
            // 
            // lblSample
            // 
            this.lblSample.AutoSize = true;
            this.lblSample.Location = new System.Drawing.Point(7, 95);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(42, 13);
            this.lblSample.TabIndex = 6;
            this.lblSample.Text = "Sample";
            // 
            // btnphoto
            // 
            this.btnphoto.Location = new System.Drawing.Point(210, 16);
            this.btnphoto.Name = "btnphoto";
            this.btnphoto.Size = new System.Drawing.Size(75, 22);
            this.btnphoto.TabIndex = 5;
            this.btnphoto.Text = "Browse";
            this.btnphoto.UseVisualStyleBackColor = true;
            this.btnphoto.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtTemplatePicture
            // 
            this.txtTemplatePicture.Location = new System.Drawing.Point(111, 17);
            this.txtTemplatePicture.Name = "txtTemplatePicture";
            this.txtTemplatePicture.Size = new System.Drawing.Size(100, 20);
            this.txtTemplatePicture.TabIndex = 4;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Location = new System.Drawing.Point(111, 125);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(100, 23);
            this.btnSaveTemplate.TabIndex = 3;
            this.btnSaveTemplate.Text = "Save to Template";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // txtCertificateTitle
            // 
            this.txtCertificateTitle.Location = new System.Drawing.Point(111, 57);
            this.txtCertificateTitle.Name = "txtCertificateTitle";
            this.txtCertificateTitle.Size = new System.Drawing.Size(174, 20);
            this.txtCertificateTitle.TabIndex = 2;
            // 
            // lblCertificateTitle
            // 
            this.lblCertificateTitle.AutoSize = true;
            this.lblCertificateTitle.Location = new System.Drawing.Point(7, 57);
            this.lblCertificateTitle.Name = "lblCertificateTitle";
            this.lblCertificateTitle.Size = new System.Drawing.Size(77, 13);
            this.lblCertificateTitle.TabIndex = 1;
            this.lblCertificateTitle.Text = "Certificate Title";
            // 
            // lblTemplatePicture
            // 
            this.lblTemplatePicture.AutoSize = true;
            this.lblTemplatePicture.Location = new System.Drawing.Point(7, 20);
            this.lblTemplatePicture.Name = "lblTemplatePicture";
            this.lblTemplatePicture.Size = new System.Drawing.Size(87, 13);
            this.lblTemplatePicture.TabIndex = 0;
            this.lblTemplatePicture.Text = "Template Picture";
            // 
            // dgvExamReports
            // 
            this.dgvExamReports.AllowUserToAddRows = false;
            this.dgvExamReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvExamReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExamReportId,
            this.UserName,
            this.Category,
            this.ExamCode,
            this.PassFail,
            this.Score,
            this.AllowPrint,
            this.DegitalCertificate,
            this.Generate,
            this.No});
            this.dgvExamReports.Location = new System.Drawing.Point(3, 3);
            this.dgvExamReports.Name = "dgvExamReports";
            this.dgvExamReports.Size = new System.Drawing.Size(772, 344);
            this.dgvExamReports.TabIndex = 0;
            // 
            // ExamReportId
            // 
            this.ExamReportId.HeaderText = "Exam Report Id";
            this.ExamReportId.Name = "ExamReportId";
            // 
            // UserName
            // 
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // ExamCode
            // 
            this.ExamCode.HeaderText = "Exam Code";
            this.ExamCode.Name = "ExamCode";
            // 
            // PassFail
            // 
            this.PassFail.HeaderText = "Pass/Fail";
            this.PassFail.Name = "PassFail";
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            // 
            // AllowPrint
            // 
            this.AllowPrint.HeaderText = "Allow Print";
            this.AllowPrint.Name = "AllowPrint";
            this.AllowPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DegitalCertificate
            // 
            this.DegitalCertificate.HeaderText = "Degital Certificate";
            this.DegitalCertificate.Name = "DegitalCertificate";
            // 
            // Generate
            // 
            this.Generate.HeaderText = "Generate";
            this.Generate.Name = "Generate";
            this.Generate.Text = "Generate";
            this.Generate.UseColumnTextForButtonValue = true;
            // 
            // No
            // 
            this.No.HeaderText = "No.#";
            this.No.Name = "No";
            // 
            // frmExampReports
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
            this.Name = "frmExampReports";
            this.Text = "Examp Reports";
            this.Load += new System.EventHandler(this.frmExampReports_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvExamReports;
        private System.Windows.Forms.DataGridView dgvTemplate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnphoto;
        private System.Windows.Forms.TextBox txtTemplatePicture;
        private System.Windows.Forms.Button btnSaveTemplate;
        private System.Windows.Forms.TextBox txtCertificateTitle;
        private System.Windows.Forms.Label lblCertificateTitle;
        private System.Windows.Forms.Label lblTemplatePicture;
        private System.Windows.Forms.Label lblsamplemsg;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CertificateTitle;
        private System.Windows.Forms.DataGridViewImageColumn TemplatePicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplatePic;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamReportId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewLinkColumn AllowPrint;
        private System.Windows.Forms.DataGridViewComboBoxColumn DegitalCertificate;
        private System.Windows.Forms.DataGridViewButtonColumn Generate;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
    }
}