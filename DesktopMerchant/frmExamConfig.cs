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
    public partial class frmExamConfig : Form
    {
        private BOExamConfig _boexmcnfg = new BOExamConfig();
        private BAExamConfig _baexmcnfg = new BAExamConfig();
        private List<BOExamConfig> _boexmcnfglist = new List<BOExamConfig>();

        private int merchantId = default(int);
        private int examid = default(int);

        public frmExamConfig(int mrctid)
        {
            InitializeComponent();
            merchantId = mrctid;
            lbldate.Text = SelectMerchantValidDate(merchantId).ToString("yyyy/MM/dd");
        }

        private void frmExamConfig_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                FillTopCategoryCombo();
                FillDataGridView();
                dgvExamManage.Columns[0].Visible = false;
                dgvExamManage.Columns[7].Visible = false;
                dgvExamManage.Columns[8].Visible = false;
                dgvExamManage.Columns[9].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DateTime SelectMerchantValidDate(int merchantId)
        {
            BOMerchantManage _bomermng = new BOMerchantManage();
            BAMerchantManage _bamermng = new BAMerchantManage();
            DateTime validdate = _bamermng.SelectValiddate("GetValidDate", merchantId);
            return validdate;
        }

        private void FillTopCategoryCombo()
        {
            BOTopCategory _botopcat = new BOTopCategory();
            BATopCategory _batopcat = new BATopCategory();
            _botopcat.Event = "GETALL";
            List<BOTopCategory> TCateList = _batopcat.SelectTopCategoryList(_botopcat);
            if (TCateList.Count > 0)
            {
                cmbTopcate.DataSource = TCateList;
                cmbTopcate.DisplayMember = "TopCategoryName";
                cmbTopcate.ValueMember = "TopCategoryID";
                FillSecondCategoryCombo("GetWithTopCatId", Convert.ToInt32(cmbTopcate.SelectedValue));
            }
        }

        private void FillSecondCategoryCombo(string eventtxt, int topcatid)
        {
            BOSecondCategory _boseccat = new BOSecondCategory();
            BASecondCategory bascat = new BALayer.BASecondCategory();
            List<BOSecondCategory> _secCatlist = bascat.SelectSecondCatListWithTop(eventtxt, topcatid);
            cmbSecondcat.DataSource = null;
            if (_secCatlist.Count > 0)
            {
                cmbSecondcat.DataSource = _secCatlist;
                cmbSecondcat.DisplayMember = "SecondCategoryName";
                cmbSecondcat.ValueMember = "SecondCategoryId";
            }
        }

        private void FillDataGridView()
        {
            _boexmcnfg.Event = "GetExamWithMId";
            _boexmcnfg.MerchantId = merchantId;
            _boexmcnfglist = _baexmcnfg.SelectExamConfigByMerchant(_boexmcnfg);
            int tmp = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_boexmcnfglist);
            dgvExamManage.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvExamManage.Rows.Add();
                dgvExamManage.Rows[tmp].Cells[0].Value = Convert.ToString(row["ExamCodeId"]);
                dgvExamManage.Rows[tmp].Cells[1].Value = Convert.ToString(row["ExamCode"]);
                dgvExamManage.Rows[tmp].Cells[2].Value = Convert.ToString(row["ExamTitle"]);
                dgvExamManage.Rows[tmp].Cells[3].Value = Convert.ToString(row["Category"]);
                dgvExamManage.Rows[tmp].Cells[4].Value = Convert.ToString(row["PassingPercentage"]);
                dgvExamManage.Rows[tmp].Cells[5].Value = Convert.ToString(row["TestTime"]);
                dgvExamManage.Rows[tmp].Cells[6].Value = Convert.ToString(row["ValidDate"]);

                dgvExamManage.Rows[tmp].Cells[7].Value = Convert.ToString(row["TopCategory"]);
                dgvExamManage.Rows[tmp].Cells[8].Value = Convert.ToString(row["SecondCategory"]);
                dgvExamManage.Rows[tmp].Cells[9].Value = Convert.ToString(row["TestOption"]);
                tmp++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (examid > 0)
                {
                    _boexmcnfg.ExamCodeId = examid;
                    _boexmcnfg.ExamCode = txtExamcode.Text;
                    _boexmcnfg.ExamTitle = txtExamtitle.Text;
                    _boexmcnfg.TopCategoryId = Convert.ToInt32(cmbTopcate.SelectedValue);
                    _boexmcnfg.SecondCategoryId = Convert.ToInt32(cmbSecondcat.SelectedValue);
                    _boexmcnfg.PassingPercentage = Convert.ToDecimal(txtPassingpercentage.Text);
                    _boexmcnfg.TestTime = Convert.ToInt32(txtTesttimemin.Text);
                    _boexmcnfg.TestOption = txtTestoption.Text;
                    _boexmcnfg.ValidDate = Convert.ToDateTime(lbldate.Text);
                    _boexmcnfg.IsActive = true;
                    _boexmcnfg.IsDelete = false;
                    _boexmcnfg.CreatedBy = merchantId;
                    _boexmcnfg.CreatedDate = DateTime.UtcNow;
                    _boexmcnfg.UpdatedBy = merchantId;
                    _boexmcnfg.UpdatedDate = DateTime.UtcNow;
                    _boexmcnfg.Event = "Update";
                    MessageBox.Show(Common.Message(_baexmcnfg.Update(_boexmcnfg)));
                }
                else
                {
                    _boexmcnfg.ExamCode = txtExamcode.Text;
                    _boexmcnfg.ExamTitle = txtExamtitle.Text;
                    _boexmcnfg.TopCategoryId = Convert.ToInt32(cmbTopcate.SelectedValue);
                    _boexmcnfg.SecondCategoryId = Convert.ToInt32(cmbSecondcat.SelectedValue);
                    _boexmcnfg.PassingPercentage = Convert.ToDecimal(txtPassingpercentage.Text);
                    _boexmcnfg.TestTime = Convert.ToInt32(txtTesttimemin.Text);
                    _boexmcnfg.TestOption = txtTestoption.Text;
                    _boexmcnfg.ValidDate = Convert.ToDateTime(lbldate.Text);
                    _boexmcnfg.IsActive = true;
                    _boexmcnfg.IsDelete = false;
                    _boexmcnfg.CreatedBy = merchantId;
                    _boexmcnfg.CreatedDate = DateTime.UtcNow;
                    _boexmcnfg.UpdatedBy = merchantId;
                    _boexmcnfg.UpdatedDate = DateTime.UtcNow;
                    _boexmcnfg.Event = "Insert";
                    MessageBox.Show(Common.Message(_baexmcnfg.Insert(_boexmcnfg)));
                }
                Clearcontrol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTopcate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTopcate.SelectedValue is int)
                {
                    FillSecondCategoryCombo("GetWithTopCatId", Convert.ToInt32(cmbTopcate.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clearcontrol()
        {
            txtExamcode.Text = txtExamtitle.Text = txtPassingpercentage.Text = "";
            txtTestoption.Text = txtTesttimemin.Text = "";
            FillDataGridView();
            FillTopCategoryCombo();
            btnAdd.Text = "Add";
            lbldate.Text = "date";
        }

        private void dgvExamManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvExamManage.Columns[e.ColumnIndex].Name == "Edit")
                {
                    examid = Convert.ToInt32(dgvExamManage.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtExamcode.Text = dgvExamManage.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtExamtitle.Text = dgvExamManage.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtPassingpercentage.Text = dgvExamManage.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtTesttimemin.Text = dgvExamManage.Rows[e.RowIndex].Cells[5].Value.ToString();
                    lbldate.Text = dgvExamManage.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtTestoption.Text = dgvExamManage.Rows[e.RowIndex].Cells[9].Value.ToString();
                    cmbTopcate.Text = dgvExamManage.Rows[e.RowIndex].Cells[7].Value.ToString();
                    cmbSecondcat.Text = dgvExamManage.Rows[e.RowIndex].Cells[8].Value.ToString();
                    btnAdd.Text = "Update";
                }
                else if (dgvExamManage.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord of " + dgvExamManage.Rows[e.RowIndex].Cells[1].Value.ToString() + " ?", "Warning", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        examid = Convert.ToInt32(dgvExamManage.Rows[e.RowIndex].Cells[0].Value.ToString());

                        _boexmcnfg.ExamCodeId = examid;
                        _boexmcnfg.IsDelete = true;
                        _boexmcnfg.ValidDate = DateTime.UtcNow;
                        _boexmcnfg.CreatedBy = merchantId;
                        _boexmcnfg.CreatedDate = DateTime.UtcNow;
                        _boexmcnfg.UpdatedBy = merchantId;
                        _boexmcnfg.UpdatedDate = DateTime.UtcNow;
                        _boexmcnfg.Event = "Delete";
                        MessageBox.Show(Common.Message(_baexmcnfg.Delete(_boexmcnfg)));
                        Clearcontrol();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_changed(object sender, EventArgs e)
        {
            try
            {
                var textBox = (TextBox)sender;
                if (textBox.Text.StartsWith(" "))
                {
                    textBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txt_keypressNoDecimal(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !char.IsDigit(e.KeyChar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
