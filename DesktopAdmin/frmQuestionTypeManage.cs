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
    public partial class frmQuestionTypeManage : Form
    {
        private BAQuestionType _baqtype = new BAQuestionType();
        private BOQuestionType _boqtype = new BOQuestionType();
        private int QTypeId = default(int);
        private int loginID = default(int);
        private bool headval = default(bool);

        public frmQuestionTypeManage(int loginid)
        {
            InitializeComponent();
            txtQuestionType.Focus();
            loginID = loginid;
            dgvQuestionType.ReadOnly = true;
            dgvQuestionType.Columns[0].Visible = false;
        }

        private void frmQuestionTypeManage_Load(object sender, EventArgs e)
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
            _boqtype.Event = "GETALL";
            int rn = 0;
            DataTable _table = new DataTable();
            _table = _baqtype.SelectQuestionType(_boqtype);
            dgvQuestionType.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvQuestionType.Rows.Add();
                dgvQuestionType.Rows[rn].Cells[0].Value = Convert.ToString(row["QuestionTypeId"]);
                dgvQuestionType.Rows[rn].Cells[1].Value = Convert.ToString(row["QuestionType"]);
                ++rn;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtQuestionType.Text))
                {
                    if (QTypeId > 0)
                    {
                        _boqtype.QuestionTypeId = QTypeId;
                        _boqtype.QuestionType = txtQuestionType.Text;
                        _boqtype.IsActive = true;
                        _boqtype.IsDelete = false;
                        _boqtype.CreatedBy = loginID;
                        _boqtype.CreatedDate = DateTime.UtcNow;
                        _boqtype.UpdateBy = loginID;
                        _boqtype.UpdateDate = DateTime.UtcNow;
                        _boqtype.Event = "Update";
                        MessageBox.Show(Common.Message("Question type", _baqtype.Update(_boqtype)));
                    }
                    else
                    {
                        _boqtype.QuestionType = txtQuestionType.Text;
                        _boqtype.IsActive = true;
                        _boqtype.IsDelete = false;
                        _boqtype.CreatedBy = loginID;
                        _boqtype.CreatedDate = DateTime.UtcNow;
                        _boqtype.UpdateBy = loginID;
                        _boqtype.UpdateDate = DateTime.UtcNow;
                        _boqtype.Event = "Insert";
                        MessageBox.Show(Common.Message("Question type", _baqtype.Insert(_boqtype)));
                    }
                    ClearControl();
                }
                else
                {
                    MessageBox.Show("Please enter question type");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvQuestionType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvQuestionType.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        QTypeId = Convert.ToInt32(dgvQuestionType.Rows[e.RowIndex].Cells[0].Value.ToString());
                        txtQuestionType.Text = dgvQuestionType.Rows[e.RowIndex].Cells[1].Value.ToString();
                        btnAdd.Text = "Update";
                    }
                    else if (dgvQuestionType.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want delete\nrecord " + dgvQuestionType.Rows[e.RowIndex].Cells[1].Value.ToString() + " ?", "Warning", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            QTypeId = Convert.ToInt32(dgvQuestionType.Rows[e.RowIndex].Cells[0].Value.ToString());
                            BOQuestionType _boqtype = new BOQuestionType();
                            _boqtype.QuestionTypeId = QTypeId;
                            _boqtype.QuestionType = txtQuestionType.Text;
                            _boqtype.IsActive = true;
                            _boqtype.IsDelete = true;
                            _boqtype.CreatedBy = loginID;
                            _boqtype.CreatedDate = DateTime.UtcNow;
                            _boqtype.UpdateBy = loginID;
                            _boqtype.UpdateDate = DateTime.UtcNow;
                            _boqtype.Event = "Delete";
                            MessageBox.Show(Common.Message(dgvQuestionType.Rows[e.RowIndex].Cells[1].Value.ToString(), _baqtype.Delete(_boqtype)));
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
            QTypeId = default(int);
            btnAdd.Text = "Add";
            txtQuestionType.Text = "";
        }

        private void txtQuestionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == '&' || e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtQuestionType_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void dgvQuestionType_CellClick(object sender, DataGridViewCellEventArgs e)
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
