namespace DesktopMerchant
{
    partial class frmMyExam
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
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamMerchant)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 738);
            this.panel1.TabIndex = 0;
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
            this.AllowSales});
            this.dgvExamMerchant.Location = new System.Drawing.Point(0, 3);
            this.dgvExamMerchant.Name = "dgvExamMerchant";
            this.dgvExamMerchant.Size = new System.Drawing.Size(790, 350);
            this.dgvExamMerchant.TabIndex = 3;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvExamMerchant);
            this.panel2.Location = new System.Drawing.Point(225, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 737);
            this.panel2.TabIndex = 1;
            // 
            // frmMyExam
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
            this.Name = "frmMyExam";
            this.Text = "My Exam";
            this.Load += new System.EventHandler(this.frmMyExam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamMerchant)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvExamMerchant;
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
        private System.Windows.Forms.Panel panel2;
    }
}