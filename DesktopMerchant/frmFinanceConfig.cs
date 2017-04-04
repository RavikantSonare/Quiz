using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopMerchant.BOLayer;
using DesktopMerchant.BALayer;

namespace DesktopMerchant
{
    public partial class frmFinanceConfig : Form
    {
        private int merchantID = default(int);
        private int financnfgid = default(int);
        private BOFinanceConfig _bofcnfg = new BOFinanceConfig();
        private List<BOFinanceConfig> _bofcnfglist = new List<BOFinanceConfig>();
        private BAFinanceConfig _bafcnfg = new BAFinanceConfig();

        public frmFinanceConfig(int mrcntid)
        {
            InitializeComponent();
            merchantID = mrcntid;
        }

        private void frmFinanceConfig_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                BindPaymentOptionCmb();
                FillGridView(merchantID);
                dgvFinanceConfig.Columns[0].Visible = false;
                dgvFinanceConfig.Columns[1].Visible = false;
                dgvFinanceConfig.Columns[3].Visible = false;
                dgvFinanceConfig.Columns[4].Visible = false;
                dgvFinanceConfig.Columns[5].Visible = false;
                dgvFinanceConfig.Columns[6].Visible = false;
                dgvFinanceConfig.Columns[7].Visible = false;
                dgvFinanceConfig.Columns[8].Visible = false;
                dgvFinanceConfig.Columns[9].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillGridView(int merchantID)
        {
            _bofcnfg.Event = "GetAllWithMId";
            _bofcnfg.MerchantId = merchantID;
            _bofcnfglist = _bafcnfg.SelectFinanceConfigList(_bofcnfg);
            if (_bofcnfglist.Count > 0)
            {
                DataTable _datatable = new DataTable();
                _datatable = Common.LINQToDataTable(_bofcnfglist);
                dgvFinanceConfig.Rows.Clear();
                int tmp = 0;
                foreach (DataRow row in _datatable.Rows)
                {
                    dgvFinanceConfig.Rows.Add();
                    dgvFinanceConfig.Rows[tmp].Cells[0].Value = Convert.ToString(row["FinanceConfigId"]);
                    dgvFinanceConfig.Rows[tmp].Cells[1].Value = Convert.ToString(row["PaymentOptionId"]);
                    dgvFinanceConfig.Rows[tmp].Cells[2].Value = Convert.ToString(row["PaymentOption"]);
                    dgvFinanceConfig.Rows[tmp].Cells[3].Value = Convert.ToString(row["AccountEmail"]);
                    dgvFinanceConfig.Rows[tmp].Cells[4].Value = Convert.ToString(row["FirstName"]);
                    dgvFinanceConfig.Rows[tmp].Cells[5].Value = Convert.ToString(row["LastName"]);
                    dgvFinanceConfig.Rows[tmp].Cells[6].Value = Convert.ToString(row["Country"]);
                    dgvFinanceConfig.Rows[tmp].Cells[7].Value = Convert.ToString(row["City"]);
                    dgvFinanceConfig.Rows[tmp].Cells[8].Value = Convert.ToString(row["BankOfName"]);
                    dgvFinanceConfig.Rows[tmp].Cells[9].Value = Convert.ToString(row["SwiftCode"]);
                    tmp++;
                }
            }

        }

        private void BindPaymentOptionCmb()
        {
            BOPaymentOption _bopmntopt = new BOLayer.BOPaymentOption();
            List<BOPaymentOption> _bopmntoptlist = new List<BOPaymentOption>();
            BAPaymentOption _bapmntopt = new BALayer.BAPaymentOption();
            _bopmntopt.Event = "GETMerchantOption";
            _bopmntoptlist = _bapmntopt.SelectPaymentOptionList(_bopmntopt);
            if (_bopmntoptlist.Count > 0)
            {
                cmbPaymentOption.DataSource = _bopmntoptlist;
                cmbPaymentOption.DisplayMember = "PaymentOption";
                cmbPaymentOption.ValueMember = "PaymentOptionId";
                if (cmbPaymentOption.SelectedText.Equals("Paypal"))
                {
                    pnlPaypal.Visible = true;
                    pnlWiretransfer.Visible = false;
                }
                else if (cmbPaymentOption.SelectedText.Equals("Wire Transfer"))
                {
                    pnlWiretransfer.Visible = true;
                    pnlPaypal.Visible = false;
                }
            }

        }

        private void cmbPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaymentOption.Text.Equals("Paypal"))
                {
                    pnlPaypal.Visible = true;
                    pnlWiretransfer.Visible = false;
                }
                else if (cmbPaymentOption.Text.Equals("Wire Transfer"))
                {
                    pnlWiretransfer.Visible = true;
                    pnlPaypal.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (financnfgid > 0)
                {
                    _bofcnfg.FinanceConfigId = financnfgid;
                    _bofcnfg.PaymentOptionId = Convert.ToInt32(cmbPaymentOption.SelectedValue);
                    _bofcnfg.MerchantId = merchantID;
                    _bofcnfg.AccountEmail = txtAccountEmail.Text;
                    _bofcnfg.FirstName = txtFirstName.Text;
                    _bofcnfg.LastName = txtLastName.Text;
                    _bofcnfg.Country = txtCountry.Text;
                    _bofcnfg.City = txtCity.Text;
                    _bofcnfg.BankOfName = txtBankOfName.Text;
                    _bofcnfg.SwiftCode = txtSwiftCode.Text;
                    _bofcnfg.IsActive = true;
                    _bofcnfg.IsDelete = false;
                    _bofcnfg.CreatedBy = merchantID;
                    _bofcnfg.CreatedDate = DateTime.UtcNow;
                    _bofcnfg.UpdatedBy = merchantID;
                    _bofcnfg.UpdatedDate = DateTime.UtcNow;
                    _bofcnfg.Event = "Update";
                    MessageBox.Show(Common.Message(_bafcnfg.Update(_bofcnfg)));
                }
                else
                {

                    _bofcnfg.PaymentOptionId = Convert.ToInt32(cmbPaymentOption.SelectedValue);
                    _bofcnfg.MerchantId = merchantID;
                    _bofcnfg.AccountEmail = txtAccountEmail.Text;
                    _bofcnfg.FirstName = txtFirstName.Text;
                    _bofcnfg.LastName = txtLastName.Text;
                    _bofcnfg.Country = txtCountry.Text;
                    _bofcnfg.City = txtCity.Text;
                    _bofcnfg.BankOfName = txtBankOfName.Text;
                    _bofcnfg.SwiftCode = txtSwiftCode.Text;
                    _bofcnfg.IsActive = true;
                    _bofcnfg.IsDelete = false;
                    _bofcnfg.CreatedBy = merchantID;
                    _bofcnfg.CreatedDate = DateTime.UtcNow;
                    _bofcnfg.UpdatedBy = merchantID;
                    _bofcnfg.UpdatedDate = DateTime.UtcNow;
                    _bofcnfg.Event = "Insert";
                    MessageBox.Show(Common.Message(_bafcnfg.Insert(_bofcnfg)));
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvFinanceConfig_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFinanceConfig.Columns[e.ColumnIndex].Name.Equals("Edit"))
                {
                    financnfgid = Convert.ToInt32(dgvFinanceConfig.Rows[e.RowIndex].Cells[0].Value);
                    cmbPaymentOption.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[2].Value.ToString();
                    if (cmbPaymentOption.Text.Equals("Paypal"))
                    {
                        pnlPaypal.Visible = true;
                        pnlWiretransfer.Visible = false;
                    }
                    else if (cmbPaymentOption.Text.Equals("Wire Transfer"))
                    {
                        pnlWiretransfer.Visible = true;
                        pnlPaypal.Visible = false;
                    }
                    txtAccountEmail.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtFirstName.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtLastName.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtCountry.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtCity.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtBankOfName.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[8].Value.ToString();
                    txtSwiftCode.Text = dgvFinanceConfig.Rows[e.RowIndex].Cells[9].Value.ToString();
                    btnAdd.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearControl()
        {
            txtAccountEmail.Text =
                txtBankOfName.Text =
                txtCity.Text =
                txtCountry.Text =
                txtFirstName.Text =
                txtLastName.Text =
                txtSwiftCode.Text = "";
            cmbPaymentOption.SelectedIndex = 0;
            FillGridView(merchantID);
            btnAdd.Text = "Add";
        }

        private void txt_textChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }
    }
}
