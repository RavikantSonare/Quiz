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
    public partial class frmAdminThirdCategory : Form
    {
        BOThirdCategory _bothirdcate = new BOThirdCategory();
        private BASecondCategory bascat = new BASecondCategory();
        private BAThirdCategory batcat = new BAThirdCategory();
        private List<BOThirdCategory> _thirdcatlist = new List<BOThirdCategory>();
        private int ThirdCatId = default(int);
        private int loginID = default(int);
        private bool headval = default(bool);

        public frmAdminThirdCategory(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
            dgvThirdCategory.ReadOnly = true;
            dgvThirdCategory.Columns[0].Visible = false;
        }

        private void frmAdminThirdCategory_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillSecondCategory();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _bothirdcate.Event = "GETALL";
            _thirdcatlist = batcat.SelectThirdCategoryList(_bothirdcate);
            int sn = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_thirdcatlist);
            dgvThirdCategory.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvThirdCategory.Rows.Add();
                dgvThirdCategory.Rows[sn].Cells[0].Value = Convert.ToString(row["ThirdCategoryId"]);
                dgvThirdCategory.Rows[sn].Cells[1].Value = Convert.ToString(row["ThirdCategoryName"]);
                dgvThirdCategory.Rows[sn].Cells[2].Value = Convert.ToString(row["SecondCategoryName"]);
                sn++;
            }
        }

        private void FillSecondCategory()
        {
            BOSecondCategory _boseccat = new BOSecondCategory();
            _boseccat.Event = "GETALL";
            List<BOSecondCategory> _secCatlist = bascat.SelectSecondCategoryList(_boseccat);
            cmbSecondCategory.DataSource = _secCatlist;
            cmbSecondCategory.DisplayMember = "SecondCategoryName";
            cmbSecondCategory.ValueMember = "SecondCategoryId";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTextBoxes())
                {
                    if (ThirdCatId > 0)
                    {
                        _bothirdcate.ThirdCategoryId = ThirdCatId;
                        _bothirdcate.ThirdCategoryName = txtThirdCategory.Text;
                        _bothirdcate.SecondCategoryId = Convert.ToInt32(cmbSecondCategory.SelectedValue);
                        _bothirdcate.IsActive = true;
                        _bothirdcate.IsDelete = false;
                        _bothirdcate.CreatedBy = loginID;
                        _bothirdcate.CreatedDate = DateTime.UtcNow;
                        _bothirdcate.UpdatedBy = loginID;
                        _bothirdcate.UpdatedDate = DateTime.UtcNow;
                        _bothirdcate.Event = "Update";
                        MessageBox.Show(Common.Message("Third category", batcat.Update(_bothirdcate)));
                        ThirdCatId = default(int);
                        txtThirdCategory.Text = "";
                    }
                    else
                    {
                        _bothirdcate.ThirdCategoryName = txtThirdCategory.Text;
                        _bothirdcate.SecondCategoryId = Convert.ToInt32(cmbSecondCategory.SelectedValue);
                        _bothirdcate.IsActive = true;
                        _bothirdcate.IsDelete = false;
                        _bothirdcate.CreatedBy = loginID;
                        _bothirdcate.CreatedDate = DateTime.UtcNow;
                        _bothirdcate.UpdatedBy = loginID;
                        _bothirdcate.UpdatedDate = DateTime.UtcNow;
                        _bothirdcate.Event = "Insert";
                        MessageBox.Show(Common.Message("Third category", batcat.Insert(_bothirdcate)));
                        ThirdCatId = default(int);
                        txtThirdCategory.Text = "";
                    }
                    btnAdd.Text = "Add";
                    FillDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvThirdCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvThirdCategory.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        ThirdCatId = Convert.ToInt32(dgvThirdCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtThirdCategory.Text = dgvThirdCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cmbSecondCategory.Text = dgvThirdCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                        btnAdd.Text = "Update";
                    }
                    else if (dgvThirdCategory.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord " + dgvThirdCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Warning", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            ThirdCatId = Convert.ToInt32(dgvThirdCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                            _bothirdcate.ThirdCategoryId = ThirdCatId;
                            _bothirdcate.ThirdCategoryName = txtThirdCategory.Text;
                            _bothirdcate.SecondCategoryId = Convert.ToInt32(cmbSecondCategory.SelectedValue);
                            _bothirdcate.IsActive = true;
                            _bothirdcate.IsDelete = true;
                            _bothirdcate.CreatedBy = loginID;
                            _bothirdcate.CreatedDate = DateTime.UtcNow;
                            _bothirdcate.UpdatedBy = loginID;
                            _bothirdcate.UpdatedDate = DateTime.UtcNow;
                            _bothirdcate.Event = "Delete";
                            MessageBox.Show(Common.Message(dgvThirdCategory.Rows[e.RowIndex].Cells[1].Value.ToString(), batcat.Delete(_bothirdcate)));
                            FillDataGridView();
                            ThirdCatId = default(int);
                            btnAdd.Text = "Add";
                            txtThirdCategory.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCateSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<BOThirdCategory> predict = _thirdcatlist;
                if (!string.IsNullOrEmpty(txtCateSearch.Text))
                {
                    predict = predict.Where(thirdcat => thirdcat.ThirdCategoryName.ToUpper().Contains(txtCateSearch.Text.ToUpper()) || thirdcat.SecondCategoryName.ToUpper().Contains(txtCateSearch.Text.ToUpper())).ToList();
                }
                int sn = 0;
                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(predict);
                dgvThirdCategory.Rows.Clear();
                foreach (DataRow row in _table.Rows)
                {
                    dgvThirdCategory.Rows.Add();
                    dgvThirdCategory.Rows[sn].Cells[0].Value = Convert.ToString(row["ThirdCategoryId"]);
                    dgvThirdCategory.Rows[sn].Cells[1].Value = Convert.ToString(row["ThirdCategoryName"]);
                    dgvThirdCategory.Rows[sn].Cells[2].Value = Convert.ToString(row["SecondCategoryName"]);
                    sn++;
                }
                dgvThirdCategory.ReadOnly = true;
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
            cmbSecondCategory.SelectedIndex = 0;
            FillDataGridView();
            ThirdCatId = default(int);
            btnAdd.Text = "Add";
            txtThirdCategory.Text = "";
        }

        private void txtThirdCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtCateSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtThirdCategory_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void txtCateSearch_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void dgvThirdCategory_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (txtThirdCategory.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter category name");
                return false;
            }
            if (cmbSecondCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select category");
                return false;
            }
            return true;
        }
    }
}
