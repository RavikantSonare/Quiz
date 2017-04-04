using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOLayer;
using BALayer;

namespace DesktopAdmin
{
    public partial class frmMerchantFeeRate : Form
    {
        private BOMerchantFeeRate _bomerfrt = new BOMerchantFeeRate();
        private BAMerchantFeeRate _bamerfrt = new BAMerchantFeeRate();
        private BAMerchantLevel _bamerlvl = new BAMerchantLevel();
        private List<BOMerchantFeeRate> _bomerfrtlist = new List<BOMerchantFeeRate>();

        private int merfrtId = default(int);
        private int loginID = default(int);
        private bool headval = default(bool);

        public frmMerchantFeeRate(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
            txtMerchantFeeRate.Focus();
            dgvMerchantFeeRate.Columns[0].Visible = false;
        }

        private void frmMerchantFeeRate_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillMerchantLevelCombo();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _bomerfrt.Event = "GETALL";
            _bomerfrtlist = _bamerfrt.GetMerchantLevelList(_bomerfrt);
            int sn = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_bomerfrtlist);
            dgvMerchantFeeRate.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvMerchantFeeRate.Rows.Add();
                dgvMerchantFeeRate.Rows[sn].Cells[0].Value = Convert.ToString(row["MerchantFeeRateId"]);
                dgvMerchantFeeRate.Rows[sn].Cells[1].Value = Convert.ToString(row["MerchantFeeRate"]);
                dgvMerchantFeeRate.Rows[sn].Cells[2].Value = Convert.ToString(row["MerchantLevel"]);

                sn++;
            }
        }

        private void FillMerchantLevelCombo()
        {
            BOMerchantLevel _bomerlvl = new BOMerchantLevel();
            _bomerlvl.Event = "GETALL";
            List<BOMerchantLevel> _bomerlvllist = _bamerlvl.GetMerchantLevelList(_bomerlvl);
            cmbMerchantLevel.DataSource = _bomerlvllist;
            cmbMerchantLevel.DisplayMember = "MerchantLevel";
            cmbMerchantLevel.ValueMember = "MerchantLevelId";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTextBoxes())
                {
                    if (merfrtId > 0)
                    {
                        _bomerfrt.MerchantFeeRateId = merfrtId;
                        _bomerfrt.MerchantFeeRate = Convert.ToInt32(txtMerchantFeeRate.Text);
                        _bomerfrt.MerchantLevelId = Convert.ToInt32(cmbMerchantLevel.SelectedValue);
                        _bomerfrt.IsActive = true;
                        _bomerfrt.IsDelete = false;
                        _bomerfrt.CreatedBy = loginID;
                        _bomerfrt.CreatedDate = DateTime.UtcNow;
                        _bomerfrt.UpdatedBy = loginID;
                        _bomerfrt.UpdatedDate = DateTime.UtcNow;
                        _bomerfrt.Event = "Update";
                        MessageBox.Show(Common.Message("Fee rate", _bamerfrt.Update(_bomerfrt)));

                    }
                    else
                    {
                        _bomerfrt.MerchantFeeRate = Convert.ToInt32(txtMerchantFeeRate.Text);
                        _bomerfrt.MerchantLevelId = Convert.ToInt32(cmbMerchantLevel.SelectedValue);
                        _bomerfrt.IsActive = true;
                        _bomerfrt.IsDelete = false;
                        _bomerfrt.CreatedBy = loginID;
                        _bomerfrt.CreatedDate = DateTime.UtcNow;
                        _bomerfrt.UpdatedBy = loginID;
                        _bomerfrt.UpdatedDate = DateTime.UtcNow;
                        _bomerfrt.Event = "Insert";
                        MessageBox.Show(Common.Message("Fee rate", _bamerfrt.Insert(_bomerfrt)));
                    }
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMerchantFeeRate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvMerchantFeeRate.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        merfrtId = Convert.ToInt32(dgvMerchantFeeRate.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtMerchantFeeRate.Text = dgvMerchantFeeRate.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cmbMerchantLevel.Text = dgvMerchantFeeRate.Rows[e.RowIndex].Cells[2].Value.ToString();
                        btnAdd.Text = "Update";
                    }
                    else if (dgvMerchantFeeRate.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord " + dgvMerchantFeeRate.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Warning", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            merfrtId = Convert.ToInt32(dgvMerchantFeeRate.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _bomerfrt.MerchantFeeRateId = merfrtId;
                            _bomerfrt.MerchantFeeRate = 0;
                            _bomerfrt.MerchantLevelId = Convert.ToInt32(cmbMerchantLevel.SelectedValue);
                            _bomerfrt.IsActive = true;
                            _bomerfrt.IsDelete = true;
                            _bomerfrt.CreatedBy = loginID;
                            _bomerfrt.CreatedDate = DateTime.UtcNow;
                            _bomerfrt.UpdatedBy = loginID;
                            _bomerfrt.UpdatedDate = DateTime.UtcNow;
                            _bomerfrt.Event = "Delete";
                            MessageBox.Show(Common.Message(dgvMerchantFeeRate.Rows[e.RowIndex].Cells[1].Value.ToString(), _bamerfrt.Delete(_bomerfrt)));
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

        private void txtMerchantFeeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
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
            merfrtId = default(int);
            btnAdd.Text = "Add";
            txtMerchantFeeRate.Text = "";
            cmbMerchantLevel.SelectedIndex = 0;
        }

        private void txtMerchantFeeRate_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void dgvMerchantFeeRate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && (e.ColumnIndex == 3 || e.ColumnIndex == 4))
            {
                headval = false;
            }
            else
            {
                headval = true;
            }
        }

        private bool ValidateTextBoxes()
        {
            if (txtMerchantFeeRate.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter fee rate");
                return false;
            }
            if (cmbMerchantLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select merchant level");
                return false;
            }
            return true;
        }
    }
}
