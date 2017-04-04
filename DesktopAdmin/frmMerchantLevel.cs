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
    public partial class frmMerchantLevel : Form
    {
        private BOMerchantLevel _bomerlvl = new BOMerchantLevel();
        private BAMerchantLevel _bamerlvl = new BAMerchantLevel();
        private List<BOMerchantLevel> _bomerlvllist = new List<BOMerchantLevel>();
        private int merlvlId = default(int);
        private int loginID = default(int);
        private bool headval = default(bool);

        public frmMerchantLevel(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
            dgvMerchantLevel.Columns[0].Visible = false;
            dgvMerchantLevel.Columns["Edit"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMerchantLevel.Columns["Delete"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void frmMerchantLevel_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                dgvMerchantLevel.ReadOnly = true;
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _bomerlvl.Event = "GETALL";
            _bomerlvllist = _bamerlvl.GetMerchantLevelList(_bomerlvl);
            int sn = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_bomerlvllist);
            dgvMerchantLevel.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvMerchantLevel.Rows.Add();
                dgvMerchantLevel.Rows[sn].Cells[0].Value = Convert.ToString(row["MerchantLevelId"]);
                dgvMerchantLevel.Rows[sn].Cells[1].Value = Convert.ToString(row["MerchantLevel"]);
                dgvMerchantLevel.Rows[sn].Cells[2].Value = Convert.ToString(row["AnnualFee"]);
                sn++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTextBoxes())
                {
                    if (merlvlId > 0)
                    {
                        _bomerlvl.MerchantLevelId = merlvlId;
                        _bomerlvl.MerchantLevel = txtMerchantLevel.Text;
                        _bomerlvl.AnnualFee = Convert.ToDecimal(txtAnnualFee.Text);
                        _bomerlvl.IsActive = true;
                        _bomerlvl.IsDelete = false;
                        _bomerlvl.CreatedBy = loginID;
                        _bomerlvl.CreatedDate = DateTime.UtcNow;
                        _bomerlvl.UpdateBy = loginID;
                        _bomerlvl.UpdateDate = DateTime.UtcNow;
                        _bomerlvl.Event = "Update";
                        MessageBox.Show(Common.Message("Merchant level", _bamerlvl.Update(_bomerlvl)));
                    }
                    else
                    {
                        _bomerlvl.MerchantLevel = txtMerchantLevel.Text;
                        _bomerlvl.AnnualFee = Convert.ToDecimal(txtAnnualFee.Text);
                        _bomerlvl.IsActive = true;
                        _bomerlvl.IsDelete = false;
                        _bomerlvl.CreatedBy = loginID;
                        _bomerlvl.CreatedDate = DateTime.UtcNow;
                        _bomerlvl.UpdateBy = loginID;
                        _bomerlvl.UpdateDate = DateTime.UtcNow;
                        _bomerlvl.Event = "Insert";
                        MessageBox.Show(Common.Message("Merchant level", _bamerlvl.Insert(_bomerlvl)));
                    }
                    Clearcontrol();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAnnualFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMerchantLevel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvMerchantLevel.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        merlvlId = Convert.ToInt32(dgvMerchantLevel.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtMerchantLevel.Text = dgvMerchantLevel.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtAnnualFee.Text = dgvMerchantLevel.Rows[e.RowIndex].Cells[2].Value.ToString();
                        btnAdd.Text = "Update";
                    }
                    else if (dgvMerchantLevel.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord " + dgvMerchantLevel.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Warning", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            merlvlId = Convert.ToInt32(dgvMerchantLevel.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _bomerlvl.MerchantLevelId = merlvlId;
                            _bomerlvl.MerchantLevel = txtMerchantLevel.Text;
                            _bomerlvl.AnnualFee = !string.IsNullOrEmpty(txtAnnualFee.Text) ? Convert.ToDecimal(txtAnnualFee.Text) : 0;
                            _bomerlvl.IsActive = true;
                            _bomerlvl.IsDelete = true;
                            _bomerlvl.CreatedBy = loginID;
                            _bomerlvl.CreatedDate = DateTime.UtcNow;
                            _bomerlvl.UpdateBy = loginID;
                            _bomerlvl.UpdateDate = DateTime.UtcNow;
                            _bomerlvl.Event = "Delete";
                            MessageBox.Show(Common.Message(dgvMerchantLevel.Rows[e.RowIndex].Cells[1].Value.ToString(), _bamerlvl.Delete(_bomerlvl)));
                            Clearcontrol();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clearcontrol()
        {
            txtAnnualFee.Text = txtMerchantLevel.Text = "";
            FillDataGridView();
            merlvlId = default(int);
            btnAdd.Text = "Add";
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                Clearcontrol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMerchantLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtMerchantLevel_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void dgvMerchantLevel_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (txtMerchantLevel.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter merchant level");
                return false;
            }
            if (txtAnnualFee.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter annual fee");
                return false;
            }
            return true;
        }
    }
}
