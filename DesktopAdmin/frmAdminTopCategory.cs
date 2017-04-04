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
    public partial class frmAdminTopCategory : Form
    {
        private BOTopCategory _botcat = new BOTopCategory();
        private BATopCategory _batcat = new BATopCategory();
        private List<BOTopCategory> TopCateList = new List<BOTopCategory>();
        private int TopCatId = default(int);
        private int loginID = default(int);
        private bool headval = default(bool);

        #region Constructor
        public frmAdminTopCategory(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
            dgvTopCategory.Columns[0].Visible = false;
        }
        #endregion

        private void frmAdminTopCategory_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                FillGridView();
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
                if (!string.IsNullOrEmpty(txtTopCategory.Text))
                {
                    if (TopCatId > 0)
                    {
                        _botcat.TopCategoryId = TopCatId;
                        _botcat.TopCategoryName = txtTopCategory.Text;
                        _botcat.IsActive = true;
                        _botcat.IsDelete = false;
                        _botcat.CreatedBy = loginID;
                        _botcat.CreatedDate = DateTime.UtcNow;
                        _botcat.UpdatedBy = loginID;
                        _botcat.UpdatedDate = DateTime.UtcNow;
                        _botcat.Event = "Update";
                        MessageBox.Show(Common.Message("Top category", _batcat.Update(_botcat)));
                    }
                    else
                    {
                        _botcat.TopCategoryName = txtTopCategory.Text;
                        _botcat.IsActive = true;
                        _botcat.IsDelete = false;
                        _botcat.CreatedBy = loginID;
                        _botcat.CreatedDate = DateTime.UtcNow;
                        _botcat.UpdatedBy = loginID;
                        _botcat.UpdatedDate = DateTime.UtcNow;
                        _botcat.Event = "Insert";
                        MessageBox.Show(Common.Message("Top category", _batcat.Insert(_botcat)));
                    }
                    ClearControl();
                }
                else
                {
                    MessageBox.Show("Please enter top category");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillGridView()
        {
            int Snu = 0;
            DataTable dt = new DataTable();
            _botcat.Event = "GETALL";
            dt = _batcat.SelectTopCategory(_botcat);
            dgvTopCategory.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgvTopCategory.Rows.Add();
                dgvTopCategory.Rows[Snu].Cells[0].Value = Convert.ToString(row["TopCategoryId"]);
                dgvTopCategory.Rows[Snu].Cells[1].Value = Convert.ToString(row["TopCategoryName"]);
                ++Snu;
            }
            dgvTopCategory.ReadOnly = true;
        }

        private void dgvTopCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvTopCategory.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        TopCatId = Convert.ToInt32(dgvTopCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtTopCategory.Text = dgvTopCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                        txtTopCategory.Focus();
                        btnAdd.Text = "Update";
                    }
                    else if (dgvTopCategory.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord " + dgvTopCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + " ?", "Warning", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            TopCatId = Convert.ToInt32(dgvTopCategory.Rows[e.RowIndex].Cells[0].Value.ToString());
                            BOTopCategory _botcat = new BOTopCategory();
                            _botcat.TopCategoryId = TopCatId;
                            _botcat.TopCategoryName = txtTopCategory.Text;
                            _botcat.IsActive = true;
                            _botcat.IsDelete = true;
                            _botcat.CreatedBy = loginID;
                            _botcat.CreatedDate = DateTime.UtcNow;
                            _botcat.UpdatedBy = loginID;
                            _botcat.UpdatedDate = DateTime.UtcNow;
                            _botcat.Event = "Delete";
                            MessageBox.Show(Common.Message(dgvTopCategory.Rows[e.RowIndex].Cells[1].Value.ToString(), _batcat.Delete(_botcat)));
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
                _botcat.Event = "GETALL";
                List<BOTopCategory> predict = _batcat.SelectTopCategoryList(_botcat);

                if (!string.IsNullOrEmpty(txtCateSearch.Text))
                {
                    predict = predict.Where(topcate => topcate.TopCategoryName.ToUpper().Contains(txtCateSearch.Text.ToUpper())).ToList();
                }
                int Snu = 0;
                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(predict);
                dgvTopCategory.Rows.Clear();
                foreach (DataRow row in _table.Rows)
                {
                    dgvTopCategory.Rows.Add();
                    dgvTopCategory.Rows[Snu].Cells[0].Value = Convert.ToString(row["TopCategoryId"]);
                    dgvTopCategory.Rows[Snu].Cells[1].Value = Convert.ToString(row["TopCategoryName"]);
                    ++Snu;
                }
                dgvTopCategory.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
            FillGridView();
            btnAdd.Text = "Add";
            txtTopCategory.Text = "";
            TopCatId = default(int);
        }

        private void txtTopCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtCateSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtTopCategory_TextChanged(object sender, EventArgs e)
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

        private void dgvTopCategory_CellClick(object sender, DataGridViewCellEventArgs e)
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
