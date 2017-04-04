namespace DesktopAdmin
{
    partial class frmWithdrawOption
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
            this.lblPaymentOption = new System.Windows.Forms.Label();
            this.txtPaymentOption = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.dgvPaymentOption = new System.Windows.Forms.DataGridView();
            this.PaymentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOption)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 733);
            this.panel1.TabIndex = 0;
            // 
            // lblPaymentOption
            // 
            this.lblPaymentOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPaymentOption.AutoSize = true;
            this.lblPaymentOption.Location = new System.Drawing.Point(3, 15);
            this.lblPaymentOption.Name = "lblPaymentOption";
            this.lblPaymentOption.Size = new System.Drawing.Size(82, 13);
            this.lblPaymentOption.TabIndex = 0;
            this.lblPaymentOption.Text = "Payment Option";
            // 
            // txtPaymentOption
            // 
            this.txtPaymentOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPaymentOption.Location = new System.Drawing.Point(117, 12);
            this.txtPaymentOption.Name = "txtPaymentOption";
            this.txtPaymentOption.Size = new System.Drawing.Size(162, 20);
            this.txtPaymentOption.TabIndex = 1;
            this.txtPaymentOption.TextChanged += new System.EventHandler(this.txtPaymentOption_TextChanged);
            this.txtPaymentOption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentOption_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(303, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncancel.Location = new System.Drawing.Point(396, 11);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Reset";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // dgvPaymentOption
            // 
            this.dgvPaymentOption.AllowUserToAddRows = false;
            this.dgvPaymentOption.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentOption.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaymentOption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentOption.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentId,
            this.PaymentOption,
            this.Edit,
            this.Delete});
            this.dgvPaymentOption.Location = new System.Drawing.Point(3, 46);
            this.dgvPaymentOption.Name = "dgvPaymentOption";
            this.dgvPaymentOption.ReadOnly = true;
            this.dgvPaymentOption.Size = new System.Drawing.Size(780, 688);
            this.dgvPaymentOption.TabIndex = 4;
            this.dgvPaymentOption.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaymentOption_CellClick);
            this.dgvPaymentOption.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaymentOption_CellContentClick);
            // 
            // PaymentId
            // 
            this.PaymentId.HeaderText = "Payment Id";
            this.PaymentId.Name = "PaymentId";
            // 
            // PaymentOption
            // 
            this.PaymentOption.HeaderText = "Payment Option";
            this.PaymentOption.Name = "PaymentOption";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dgvPaymentOption);
            this.panel2.Location = new System.Drawing.Point(226, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 734);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncancel);
            this.groupBox1.Controls.Add(this.lblPaymentOption);
            this.groupBox1.Controls.Add(this.txtPaymentOption);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 40);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // frmWithdrawOption
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
            this.Name = "frmWithdrawOption";
            this.Text = "Withdraw Option";
            this.Load += new System.EventHandler(this.frmWithdrawOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentOption)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPaymentOption;
        private System.Windows.Forms.TextBox txtPaymentOption;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvPaymentOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentOption;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}