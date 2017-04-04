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
using BOLayer;
using BALayer;

namespace DesktopAdmin
{
    public partial class frmWithdrawOption : Form
    {
        private BOPaymentOption _bopymopt = new BOPaymentOption();
        private BAPaymentOption _bapymopt = new BAPaymentOption();
        private List<BOPaymentOption> _bopymoptlist = new List<BOPaymentOption>();
        private int pytoptId = default(int);
        private int LoginID = default(int);
        private bool headval = default(bool);

        public frmWithdrawOption(int loginID)
        {
            InitializeComponent();
            txtPaymentOption.Focus();
            dgvPaymentOption.Columns[0].Visible = false;
            LoginID = loginID;
        }

        private void frmWithdrawOption_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _bopymopt.Event = "GETALL";
            _bopymoptlist = new List<BOPaymentOption>();
            _bopymoptlist = _bapymopt.SelectPaymentOptionList(_bopymopt);
            int tmp = default(int);
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_bopymoptlist);
            dgvPaymentOption.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvPaymentOption.Rows.Add();
                dgvPaymentOption.Rows[tmp].Cells[0].Value = Convert.ToString(row["PaymentOptionId"]);
                dgvPaymentOption.Rows[tmp].Cells[1].Value = Convert.ToString(row["PaymentOption"]);
                tmp++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPaymentOption.Text))
                {
                    if (pytoptId > 0)
                    {
                        _bopymopt.PaymentOptionId = pytoptId;
                        _bopymopt.PaymentOption = txtPaymentOption.Text;
                        _bopymopt.IsActive = true;
                        _bopymopt.IsDelete = false;
                        _bopymopt.CreatedBy = LoginID;
                        _bopymopt.CreatedDate = DateTime.UtcNow;
                        _bopymopt.UpdateBy = LoginID;
                        _bopymopt.UpdateDate = DateTime.UtcNow;
                        _bopymopt.Event = "Update";
                        MessageBox.Show(Common.Message("Payment option", _bapymopt.Update(_bopymopt)));
                    }
                    else
                    {
                        _bopymopt.PaymentOption = txtPaymentOption.Text;
                        _bopymopt.IsActive = true;
                        _bopymopt.IsDelete = false;
                        _bopymopt.CreatedBy = LoginID;
                        _bopymopt.CreatedDate = DateTime.UtcNow;
                        _bopymopt.UpdateBy = LoginID;
                        _bopymopt.UpdateDate = DateTime.UtcNow;
                        _bopymopt.Event = "Insert";
                        MessageBox.Show(Common.Message("Payment option", _bapymopt.Insert(_bopymopt)));
                    }
                    ClearControl();
                }
                else
                {
                    MessageBox.Show("Please enter payment option");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPaymentOption_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvPaymentOption.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        pytoptId = Convert.ToInt32(dgvPaymentOption.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtPaymentOption.Text = dgvPaymentOption.Rows[e.RowIndex].Cells[1].Value.ToString();
                        btnAdd.Text = "Update";
                    }
                    else if (dgvPaymentOption.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult dgresult = MessageBox.Show("Are you sure you want to delete\nrecord " + dgvPaymentOption.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Warning", MessageBoxButtons.YesNo);
                        if (dgresult == DialogResult.Yes)
                        {
                            pytoptId = Convert.ToInt32(dgvPaymentOption.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _bopymopt.PaymentOptionId = pytoptId;
                            _bopymopt.PaymentOption = "";
                            _bopymopt.IsActive = true;
                            _bopymopt.IsDelete = true;
                            _bopymopt.CreatedBy = LoginID;
                            _bopymopt.CreatedDate = DateTime.UtcNow;
                            _bopymopt.UpdateBy = LoginID;
                            _bopymopt.UpdateDate = DateTime.UtcNow;
                            _bopymopt.Event = "Delete";
                            MessageBox.Show(Common.Message(dgvPaymentOption.Rows[e.RowIndex].Cells[1].Value.ToString(), _bapymopt.Delete(_bopymopt)));
                            ClearControl();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearControl()
        {
            FillDataGridView();
            pytoptId = default(int);
            btnAdd.Text = "Add";
            txtPaymentOption.Text = "";
        }

        private void txtPaymentOption_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtPaymentOption_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void dgvPaymentOption_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && (e.ColumnIndex == 2 || e.ColumnIndex == 3))
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
