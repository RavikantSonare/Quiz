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
    public partial class frmAdminSecondCategory : Form
    {
        private BATopCategory btcat = new BATopCategory();
        private BASecondCategory bscat = new BASecondCategory();
        private BOSecondCategory _boscat = new BOSecondCategory();
        private List<BOSecondCategory> _secondCatList = new List<BOSecondCategory>();
        private int SecCatId = default(int);
        private int loginID = default(int);
        private bool headval = default(bool);

        public frmAdminSecondCategory(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
            dgvSecondCategory.ReadOnly = true;
            dgvSecondCategory.Columns[0].Visible = false;
        }

        private void frmAdminSecondCategory_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillTopCategory();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            int Snu = 0;
            DataTable dt = new DataTable();
            _boscat.Event = "GETALL";
            List<BOSecondCategory> _boseccatlist = bscat.SelectSecondCategoryList(_boscat);
            dt = Common.LINQToDataTable(_boseccatlist);
            dgvSecondCategory.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgvSecondCategory.Rows.Add();
                dgvSecondCategory.Rows[Snu].Cells[0].Value = Convert.ToString(row["SecondCategoryId"]);
                dgvSecondCategory.Rows[Snu].Cells[1].Value = Convert.ToString(row["SecondCategoryName"]);
                dgvSecondCategory.Rows[Snu].Cells[2].Value = Convert.ToString(row["TopCategoryName"]);
                ++Snu;
            }
        }

        private void FillTopCategory()
        {
            BOTopCategory _botopcat = new BOTopCategory();
            _botopcat.Event = "GETALL";
            List<BOTopCategory> TCateList = btcat.SelectTopCategoryList(_botopcat);
            cmbTopCategory.DataSource = TCateList;
            cmbTopCategory.DisplayMember = "TopCategoryName";
            cmbTopCategory.ValueMember = "TopCategoryID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTextBoxes())
                {
                    if (SecCatId > 0)
                    {
                        _boscat.SecondCategoryId = SecCatId;
                        _boscat.SecondCategoryName = txtSecondCategory.Text;
                        _boscat.TopCategoryId = Convert.ToInt32(cmbTopCategory.SelectedValue);
                        _boscat.IsActive = true;
                        _boscat.IsDelete = false;
                        _boscat.CreatedBy = loginID;
                        _boscat.CreatedDate = DateTime.UtcNow;
                        _boscat.UpdatedBy = loginID;
                        _boscat.UpdatedDate = DateTime.UtcNow;
                        _boscat.Event = "Update";
                        MessageBox.Show(Common.Message("Second category", bscat.Update(_boscat)));
                        SecCatId = default(int);
                        txtSecondCategory.Text = "";
                    }
                    else
                    {
                        _boscat.SecondCategoryName = txtSecondCategory.Text;
                        _boscat.TopCategoryId = Convert.ToInt32(cmbTopCategory.SelectedValue);
                        _boscat.IsActive = true;
                        _boscat.IsDelete = false;
                        _boscat.CreatedBy = loginID;
                        _boscat.CreatedDate = DateTime.UtcNow;
                        _boscat.UpdatedBy = loginID;
                        _boscat.UpdatedDate = DateTime.UtcNow;
                        _boscat.Event = "Insert";
                        MessageBox.Show(Common.Message("Second category", bscat.Insert(_boscat)));
                        SecCatId = default(int);
                        txtSecondCategory.Text = "";
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

        private void dgvSecondCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvSecondCategory.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        SecCatId = Convert.ToInt32(dgvSecondCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtSecondCategory.Text = dgvSecondCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cmbTopCategory.Text = dgvSecondCategory.Rows[e.RowIndex].Cells[2].Value.ToString();
                        btnAdd.Text = "Update";
                    }
                    else if (dgvSecondCategory.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord " + dgvSecondCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + " ?", "Warning", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            SecCatId = Convert.ToInt32(dgvSecondCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                            BOSecondCategory _boscat = new BOSecondCategory();
                            _boscat.SecondCategoryId = SecCatId;
                            _boscat.SecondCategoryName = txtSecondCategory.Text;
                            _boscat.TopCategoryId = Convert.ToInt32(cmbTopCategory.SelectedValue);
                            _boscat.IsActive = true;
                            _boscat.IsDelete = true;
                            _boscat.CreatedBy = loginID;
                            _boscat.CreatedDate = DateTime.UtcNow;
                            _boscat.UpdatedBy = loginID;
                            _boscat.UpdatedDate = DateTime.UtcNow;
                            _boscat.Event = "Delete";
                            MessageBox.Show(Common.Message(dgvSecondCategory.Rows[e.RowIndex].Cells[1].Value.ToString(), bscat.Delete(_boscat)));
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

        private void btnCateSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _boscat.Event = "GETALL";
                List<BOSecondCategory> predict = bscat.SelectSecondCategoryList(_boscat);

                if (!string.IsNullOrEmpty(txtCateSearch.Text))
                {
                    predict = predict.Where(seccate => seccate.SecondCategoryName.ToUpper().Contains(txtCateSearch.Text.ToUpper()) || seccate.TopCategoryName.ToUpper().Contains(txtCateSearch.Text.ToUpper())).ToList();
                }

                int Snu = 0;
                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(predict);
                dgvSecondCategory.Rows.Clear();
                foreach (DataRow row in _table.Rows)
                {
                    dgvSecondCategory.Rows.Add();
                    dgvSecondCategory.Rows[Snu].Cells[0].Value = Convert.ToString(row["SecondCategoryId"]);
                    dgvSecondCategory.Rows[Snu].Cells[1].Value = Convert.ToString(row["SecondCategoryName"]);
                    dgvSecondCategory.Rows[Snu].Cells[2].Value = Convert.ToString(row["TopCategoryName"]);
                    ++Snu;
                }
                dgvSecondCategory.ReadOnly = true;
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
            SecCatId = default(int);
            btnAdd.Text = "Add";
            txtSecondCategory.Text = "";
            cmbTopCategory.SelectedIndex = 0;
        }

        private void txtSecondCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtCateSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtSecondCategory_TextChanged(object sender, EventArgs e)
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

        private void dgvSecondCategory_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (txtSecondCategory.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter category name");
                return false;
            }
            if (cmbTopCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select top category");
                return false;
            }
            return true;
        }
    }
}
