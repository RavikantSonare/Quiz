namespace DesktopAdmin
{
    partial class frmQuestionTypeManage
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
            this.dgvQuestionType = new System.Windows.Forms.DataGridView();
            this.QuestionTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQuestionType = new System.Windows.Forms.TextBox();
            this.lblQuestionType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionType)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuestionType
            // 
            this.dgvQuestionType.AllowUserToAddRows = false;
            this.dgvQuestionType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestionType.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestionType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestionType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuestionTypeId,
            this.QuestionType,
            this.Edit,
            this.Delete});
            this.dgvQuestionType.Location = new System.Drawing.Point(2, 45);
            this.dgvQuestionType.Name = "dgvQuestionType";
            this.dgvQuestionType.Size = new System.Drawing.Size(780, 680);
            this.dgvQuestionType.TabIndex = 3;
            this.dgvQuestionType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestionType_CellClick);
            this.dgvQuestionType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestionType_CellContentClick);
            // 
            // QuestionTypeId
            // 
            this.QuestionTypeId.HeaderText = "ID";
            this.QuestionTypeId.Name = "QuestionTypeId";
            // 
            // QuestionType
            // 
            this.QuestionType.HeaderText = "QuestionType";
            this.QuestionType.Name = "QuestionType";
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
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(310, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQuestionType
            // 
            this.txtQuestionType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuestionType.Location = new System.Drawing.Point(126, 14);
            this.txtQuestionType.Name = "txtQuestionType";
            this.txtQuestionType.Size = new System.Drawing.Size(158, 20);
            this.txtQuestionType.TabIndex = 1;
            this.txtQuestionType.TextChanged += new System.EventHandler(this.txtQuestionType_TextChanged);
            this.txtQuestionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuestionType_KeyPress);
            // 
            // lblQuestionType
            // 
            this.lblQuestionType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuestionType.AutoSize = true;
            this.lblQuestionType.Location = new System.Drawing.Point(5, 17);
            this.lblQuestionType.Name = "lblQuestionType";
            this.lblQuestionType.Size = new System.Drawing.Size(76, 13);
            this.lblQuestionType.TabIndex = 6;
            this.lblQuestionType.Text = "Question Type";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 728);
            this.panel1.TabIndex = 10;
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncancel.Location = new System.Drawing.Point(411, 12);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Reset";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvQuestionType);
            this.panel2.Location = new System.Drawing.Point(227, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 728);
            this.panel2.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.txtQuestionType);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblQuestionType);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 40);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // frmQuestionTypeManage
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
            this.Name = "frmQuestionTypeManage";
            this.Text = "Question Type";
            this.Load += new System.EventHandler(this.frmQuestionTypeManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionType)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestionType;
        private System.Windows.Forms.DataGridView dgvQuestionType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblQuestionType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionType;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}