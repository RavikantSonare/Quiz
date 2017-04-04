namespace DesktopMerchant
{
    partial class frmFinanceWithDraw
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
            this.dgvWithDrawreport = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WithDrawAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWithdrawReport = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.txtWithDraw = new System.Windows.Forms.TextBox();
            this.lblWithDraw = new System.Windows.Forms.Label();
            this.lblcurrbal = new System.Windows.Forms.Label();
            this.lblYourCurrentlyBalance = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWithDrawreport)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 740);
            this.panel1.TabIndex = 0;
            // 
            // dgvWithDrawreport
            // 
            this.dgvWithDrawreport.AllowUserToAddRows = false;
            this.dgvWithDrawreport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWithDrawreport.BackgroundColor = System.Drawing.Color.White;
            this.dgvWithDrawreport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWithDrawreport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.OrderId,
            this.OrderNo,
            this.WithDrawAmount,
            this.Status});
            this.dgvWithDrawreport.GridColor = System.Drawing.Color.DarkGray;
            this.dgvWithDrawreport.Location = new System.Drawing.Point(12, 206);
            this.dgvWithDrawreport.Name = "dgvWithDrawreport";
            this.dgvWithDrawreport.Size = new System.Drawing.Size(768, 523);
            this.dgvWithDrawreport.TabIndex = 20;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.Name = "OrderId";
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "OrderNo";
            this.OrderNo.Name = "OrderNo";
            // 
            // WithDrawAmount
            // 
            this.WithDrawAmount.HeaderText = "WithDraw Amount";
            this.WithDrawAmount.Name = "WithDrawAmount";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // lblWithdrawReport
            // 
            this.lblWithdrawReport.AutoSize = true;
            this.lblWithdrawReport.Location = new System.Drawing.Point(33, 177);
            this.lblWithdrawReport.Name = "lblWithdrawReport";
            this.lblWithdrawReport.Size = new System.Drawing.Size(89, 13);
            this.lblWithdrawReport.TabIndex = 5;
            this.lblWithdrawReport.Text = "WithDraw Report";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(165, 91);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(75, 23);
            this.btnRequest.TabIndex = 4;
            this.btnRequest.Text = "Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // txtWithDraw
            // 
            this.txtWithDraw.Location = new System.Drawing.Point(165, 50);
            this.txtWithDraw.Name = "txtWithDraw";
            this.txtWithDraw.Size = new System.Drawing.Size(120, 20);
            this.txtWithDraw.TabIndex = 3;
            this.txtWithDraw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // lblWithDraw
            // 
            this.lblWithDraw.AutoSize = true;
            this.lblWithDraw.Location = new System.Drawing.Point(21, 53);
            this.lblWithDraw.Name = "lblWithDraw";
            this.lblWithDraw.Size = new System.Drawing.Size(54, 13);
            this.lblWithDraw.TabIndex = 2;
            this.lblWithDraw.Text = "WithDraw";
            // 
            // lblcurrbal
            // 
            this.lblcurrbal.AutoSize = true;
            this.lblcurrbal.Location = new System.Drawing.Point(162, 16);
            this.lblcurrbal.Name = "lblcurrbal";
            this.lblcurrbal.Size = new System.Drawing.Size(28, 13);
            this.lblcurrbal.TabIndex = 1;
            this.lblcurrbal.Text = "$xxx";
            // 
            // lblYourCurrentlyBalance
            // 
            this.lblYourCurrentlyBalance.AutoSize = true;
            this.lblYourCurrentlyBalance.Location = new System.Drawing.Point(21, 16);
            this.lblYourCurrentlyBalance.Name = "lblYourCurrentlyBalance";
            this.lblYourCurrentlyBalance.Size = new System.Drawing.Size(115, 13);
            this.lblYourCurrentlyBalance.TabIndex = 0;
            this.lblYourCurrentlyBalance.Text = "Your Currently Balance";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvWithDrawreport);
            this.panel3.Controls.Add(this.lblWithdrawReport);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(224, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 741);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblYourCurrentlyBalance);
            this.groupBox1.Controls.Add(this.lblcurrbal);
            this.groupBox1.Controls.Add(this.btnRequest);
            this.groupBox1.Controls.Add(this.lblWithDraw);
            this.groupBox1.Controls.Add(this.txtWithDraw);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // frmFinanceWithDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 741);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFinanceWithDraw";
            this.Text = "Finance WithDraw";
            this.Load += new System.EventHandler(this.frmFinanceWithDraw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWithDrawreport)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtWithDraw;
        private System.Windows.Forms.Label lblWithDraw;
        private System.Windows.Forms.Label lblcurrbal;
        private System.Windows.Forms.Label lblYourCurrentlyBalance;
        private System.Windows.Forms.Label lblWithdrawReport;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.DataGridView dgvWithDrawreport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WithDrawAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}