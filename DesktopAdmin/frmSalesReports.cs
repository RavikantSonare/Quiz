using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using BOLayer;
using BALayer;

namespace DesktopAdmin
{
    public partial class frmSalesReports : Form
    {
        private BOSalesReports _boslsrpt = new BOSalesReports();
        private List<BOSalesReports> _boslsrptlist = new List<BOSalesReports>();
        private BASalesReports _baslsrpt = new BASalesReports();
        int loginID = default(int);
        private bool headval = default(bool);

        public frmSalesReports(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
        }

        private void frmSalesReports_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillDataGridView();
                dgvSalesReports.ReadOnly = true;
                dgvSalesReports.Columns[0].Visible = false;
                dgvSalesReports.Columns[8].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _boslsrpt.Event = "GETALL";
            _boslsrptlist = _baslsrpt.SelectSalesReportsList(_boslsrpt);

            int tmp = 0;

            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_boslsrptlist);
            dgvSalesReports.Rows.Clear();

            foreach (DataRow row in _table.Rows)
            {
                dgvSalesReports.Rows.Add();
                dgvSalesReports.Rows[tmp].Cells[0].Value = Convert.ToString(row["OrderId"]);
                dgvSalesReports.Rows[tmp].Cells[1].Value = Convert.ToString(row["OrderNo"]);
                dgvSalesReports.Rows[tmp].Cells[2].Value = Convert.ToString(row["ExamCode"]);
                dgvSalesReports.Rows[tmp].Cells[3].Value = Convert.ToString(row["SecondCategory"]);
                dgvSalesReports.Rows[tmp].Cells[4].Value = Convert.ToString(row["MerchantName"]);
                dgvSalesReports.Rows[tmp].Cells[5].Value = Convert.ToString(row["Price"]);
                dgvSalesReports.Rows[tmp].Cells[6].Value = Convert.ToString(row["FeeRate"]);
                dgvSalesReports.Rows[tmp].Cells[7].Value = Convert.ToString(row["NetAmount"]);
                if (Convert.ToBoolean(row["OrderStatus"]))
                {
                    dgvSalesReports.Rows[tmp].Cells[9].Value = "Confirmed";
                    dgvSalesReports.Rows[tmp].Cells[8].Value = Convert.ToString(row["OrderStatus"]);
                }
                else
                {
                    dgvSalesReports.Rows[tmp].Cells[9].Value = "Processing";
                    dgvSalesReports.Rows[tmp].Cells[8].Value = Convert.ToString(row["OrderStatus"]);
                }
                tmp++;
            }
        }

        private void dgvSalesReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvSalesReports.Columns[e.ColumnIndex].Name == "OrderConfirm")
                    {
                        bool isactive = Convert.ToBoolean(dgvSalesReports.Rows[e.RowIndex].Cells[8].Value.ToString());
                        if (isactive == true)
                        {
                            _boslsrpt.OrderStatus = false;
                            MessageBox.Show("Order already confirmed");
                        }
                        else
                        {
                            _boslsrpt.OrderStatus = true;
                            _boslsrpt.OrderId = Convert.ToInt32(dgvSalesReports.Rows[e.RowIndex].Cells[0].Value.ToString());

                            _boslsrpt.UpdatedBy = loginID;
                            _boslsrpt.UpdatedDate = DateTime.UtcNow;
                            _boslsrpt.Event = "UpdateStatus";
                            MessageBox.Show(Common.Message("order", _baslsrpt.Update(_boslsrpt)));
                            FillDataGridView();
                        }
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        MailMessage message = new MailMessage();
                        SmtpClient smtp = new SmtpClient();

                        message.From = new MailAddress("shailendra@mobiwebtech.com");
                        message.To.Add(new MailAddress("test@gmail.com"));
                        message.Subject = "Test";
                        message.Body = "Content";

                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("test@gmail.com", "test123");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please configure mail setting");
            }
        }

        private void txtMerchantName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtMerchantName_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            _boslsrpt.Event = "GETALL";
            _boslsrptlist = _baslsrpt.SelectSalesReportsList(_boslsrpt);
            if (!string.IsNullOrEmpty(txtMerchantName.Text))
            {
                _boslsrptlist = _boslsrptlist.Where(mername => mername.MerchantName.ToUpper().Contains(txtMerchantName.Text.ToUpper())).ToList();
            }
            int tmp = 0;

            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_boslsrptlist);
            dgvSalesReports.Rows.Clear();

            foreach (DataRow row in _table.Rows)
            {
                dgvSalesReports.Rows.Add();
                dgvSalesReports.Rows[tmp].Cells[0].Value = Convert.ToString(row["OrderId"]);
                dgvSalesReports.Rows[tmp].Cells[1].Value = Convert.ToString(row["OrderNo"]);
                dgvSalesReports.Rows[tmp].Cells[2].Value = Convert.ToString(row["ExamCode"]);
                dgvSalesReports.Rows[tmp].Cells[3].Value = Convert.ToString(row["SecondCategory"]);
                dgvSalesReports.Rows[tmp].Cells[4].Value = Convert.ToString(row["MerchantName"]);
                dgvSalesReports.Rows[tmp].Cells[5].Value = Convert.ToString(row["Price"]);
                dgvSalesReports.Rows[tmp].Cells[6].Value = Convert.ToString(row["FeeRate"]);
                dgvSalesReports.Rows[tmp].Cells[7].Value = Convert.ToString(row["NetAmount"]);
                if (Convert.ToBoolean(row["OrderStatus"]))
                {
                    dgvSalesReports.Rows[tmp].Cells[9].Value = "Confirmed";
                    dgvSalesReports.Rows[tmp].Cells[8].Value = Convert.ToString(row["OrderStatus"]);
                }
                else
                {
                    dgvSalesReports.Rows[tmp].Cells[9].Value = "Processing";
                    dgvSalesReports.Rows[tmp].Cells[8].Value = Convert.ToString(row["OrderStatus"]);
                }
                tmp++;
            }
        }

        private void dgvSalesReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && (e.ColumnIndex == 9 || e.ColumnIndex == 10))
            {
                headval = false;
            }
            else
            {
                headval = true;
            }
        }
    }
}
