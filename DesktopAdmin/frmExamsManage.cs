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
    public partial class frmExamsManage : Form
    {
        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private List<BOExamManage> _boexmmnglist = new List<BOExamManage>();
        private int loginID = default(int);
        private bool headval = default(bool);

        public frmExamsManage(int loginid)
        {
            InitializeComponent();
            loginID = loginid;
        }

        private void frmExamsManage_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            try
            {
                dgvExamManage.ReadOnly = true;
                FillDataGridView();
                dgvExamManage.Columns[0].Visible = false;
                dgvExamManage.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGridView()
        {
            _boexmmng.Event = "GETALL";
            _boexmmnglist = _baexmmng.SelectExamManageList(_boexmmng);
            int tmp = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_boexmmnglist);
            dgvExamManage.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvExamManage.Rows.Add();
                dgvExamManage.Rows[tmp].Cells[0].Value = Convert.ToString(row["ExamCodeId"]);
                dgvExamManage.Rows[tmp].Cells[1].Value = Convert.ToString(row["ExamCode"]);
                dgvExamManage.Rows[tmp].Cells[2].Value = Convert.ToString(row["SecondCategory"]);
                dgvExamManage.Rows[tmp].Cells[3].Value = Convert.ToString(row["MerchantName"]);
                dgvExamManage.Rows[tmp].Cells[4].Value = Convert.ToString(row["Level"]);
                if (Convert.ToBoolean(row["IsActive"]))
                {
                    dgvExamManage.Rows[tmp].Cells[6].Value = "Activated";
                }
                else
                {
                    dgvExamManage.Rows[tmp].Cells[6].Value = "Inactivated";
                }
                dgvExamManage.Rows[tmp].Cells[5].Value = Convert.ToString(row["IsActive"]);
                tmp++;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _boexmmng.Event = "GETALL";
                List<BOExamManage> predict = _baexmmng.SelectExamManageList(_boexmmng);

                if (!string.IsNullOrEmpty(txtExamCode.Text))
                {
                    predict = predict.Where(exmmng => exmmng.ExamCode.ToUpper().Contains(txtExamCode.Text.ToUpper())).ToList();
                }
                if (!string.IsNullOrEmpty(txtSecondCategory.Text))
                    predict = predict.Where(exmmng => exmmng.SecondCategory.ToUpper().Contains(txtSecondCategory.Text.ToUpper())).ToList();
                if (!string.IsNullOrEmpty(txtMerchantName.Text))
                    predict = predict.Where(exmmng => exmmng.MerchantName.ToUpper().Contains(txtMerchantName.Text.ToUpper())).ToList();
                if (!string.IsNullOrEmpty(txtLevel.Text))
                    predict = predict.Where(exmmng => exmmng.Level.ToUpper().Contains(txtLevel.Text.ToUpper())).ToList();

                int tmp = 0;
                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(predict);
                dgvExamManage.Rows.Clear();
                foreach (DataRow row in _table.Rows)
                {
                    dgvExamManage.Rows.Add();
                    dgvExamManage.Rows[tmp].Cells[0].Value = Convert.ToString(row["ExamCodeId"]);
                    dgvExamManage.Rows[tmp].Cells[1].Value = Convert.ToString(row["ExamCode"]);
                    dgvExamManage.Rows[tmp].Cells[2].Value = Convert.ToString(row["SecondCategory"]);
                    dgvExamManage.Rows[tmp].Cells[3].Value = Convert.ToString(row["MerchantName"]);
                    dgvExamManage.Rows[tmp].Cells[4].Value = Convert.ToString(row["Level"]);
                    if (Convert.ToBoolean(row["IsActive"]))
                    {
                        dgvExamManage.Rows[tmp].Cells[6].Value = "Activated";
                    }
                    else
                    {
                        dgvExamManage.Rows[tmp].Cells[6].Value = "Inactivated";
                    }
                    dgvExamManage.Rows[tmp].Cells[5].Value = Convert.ToString(row["IsActive"]);
                    tmp++;
                }
                dgvExamManage.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvExamManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (headval)
                {
                    if (dgvExamManage.Columns[e.ColumnIndex].Name == "Active")
                    {
                        bool isactive = Convert.ToBoolean(dgvExamManage.Rows[e.RowIndex].Cells[5].Value.ToString());
                        if (isactive == true)
                        {
                            _boexmmng.IsActive = false;
                        }
                        else
                        {
                            _boexmmng.IsActive = true;
                        }
                        _boexmmng.ExamCodeId = Convert.ToInt32(dgvExamManage.Rows[e.RowIndex].Cells[0].Value.ToString());

                        _boexmmng.UpdatedBy = loginID;
                        _boexmmng.UpdatedDate = DateTime.UtcNow;
                        _boexmmng.Event = "UpdateActive";
                        MessageBox.Show(Common.Message("Exam code " + dgvExamManage.Rows[e.RowIndex].Cells[1].Value.ToString() + " is", _baexmmng.Update(_boexmmng)));
                        FillDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtExamCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtSecondCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtMerchantName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || (char.IsNumber(e.KeyChar)));
        }

        private void txtExamCode_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void txtSecondCategory_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void txtMerchantName_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void txtLevel_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text.StartsWith(" "))
            {
                textBox.Text = "";
            }
        }

        private void dgvExamManage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 6)
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
