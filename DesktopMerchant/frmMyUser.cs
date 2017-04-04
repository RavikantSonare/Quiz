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
    public partial class frmMyUser : Form
    {
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;

        private int merchantId = default(int);
        private int userId = default(int);

        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private List<BOExamManage> _boexmmnglist = new List<BOExamManage>();

        private BOMyUser _bomyuser = new BOMyUser();
        private BAMyUser _bamyuser = new BAMyUser();
        private List<BOMyUser> _bomyuserlist = new List<BOMyUser>();

        public frmMyUser(int mrid)
        {
            InitializeComponent();
            merchantId = mrid;
        }

        private void frmMyUser_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                BindChecboxList(merchantId);
                BindCmbSecondCategory();
                dgvExamMerchant.Columns[0].Visible = false;
                BindGrdiview(merchantId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BindGrdiview(int merchantId)
        {
            _bomyuser.Event = "GetUserWithMId";
            _bomyuser.MerchantId = merchantId;
            _bomyuserlist = _bamyuser.SelectUserDetail(_bomyuser);
            int sn = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_bomyuserlist);
            dgvExamMerchant.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvExamMerchant.Rows.Add();
                dgvExamMerchant.Rows[sn].Cells[0].Value = Convert.ToString(row["UserId"]);
                dgvExamMerchant.Rows[sn].Cells[1].Value = Convert.ToString(row["UserName"]);
                dgvExamMerchant.Rows[sn].Cells[2].Value = Decryptdata(row["AccessPassword"].ToString());
                dgvExamMerchant.Rows[sn].Cells[3].Value = Convert.ToString(row["SecondCategory"]);
                dgvExamMerchant.Rows[sn].Cells[4].Value = Convert.ToString(row["ExamCode"]);
                dgvExamMerchant.Rows[sn].Cells[5].Value = Convert.ToString(row["ValidTime"]);
                dgvExamMerchant.Rows[sn].Cells[6].Value = Convert.ToString(row["AccessOption"]);
                sn++;
            }
        }

        private void BindCmbSecondCategory()
        {
            BOSecondCategory _boseccat = new BOSecondCategory();
            BASecondCategory bascat = new BALayer.BASecondCategory();
            _boseccat.Event = "GETALL";
            List<BOSecondCategory> _secCatlist = bascat.SelectSecondCategoryList(_boseccat);
            cmbCategory.DataSource = _secCatlist;
            cmbCategory.DisplayMember = "SecondCategoryName";
            cmbCategory.ValueMember = "SecondCategoryId";
        }

        private void BindChecboxList(int merchantId)
        {
            AddHeaderCheckBox();

            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dgvChklist.CellValueChanged += new DataGridViewCellEventHandler(dgvSelectAll_CellValueChanged);
            dgvChklist.CurrentCellDirtyStateChanged += new EventHandler(dgvSelectAll_CurrentCellDirtyStateChanged);
            dgvChklist.CellPainting += new DataGridViewCellPaintingEventHandler(dgvSelectAll_CellPainting);

            _boexmmng.Event = "GetExamWithMId";
            _boexmmng.MerchantId = merchantId;
            _boexmmnglist = _baexmmng.SelectMerchantExamDetail(_boexmmng);

            dgvChklist.DataSource = _boexmmnglist;
            for (int i = 0; i < dgvChklist.Columns.Count; i++)
            {
                dgvChklist.Columns[i].Visible = false;
            }
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dgvChklist.Columns.Insert(0, checkBoxColumn);
            dgvChklist.Columns[2].Visible = true;

            TotalCheckBoxes = dgvChklist.RowCount;
            TotalCheckedCheckBoxes = 0;
        }

        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool bValidName = ValidateName();
                bool bValidAccessPwd = ValidatePassword();
                bool bValidCmbCat = ValidateCmbCategory();
                if (bValidName && bValidAccessPwd && bValidCmbCat)
                {
                    if (userId > 0)
                    {
                        _bomyuser.UserId = userId;
                        _bomyuser.UserName = txtUserName.Text;
                        _bomyuser.AccessPassword = Encryptdata(txtAccesspassword.Text);
                        _bomyuser.MerchantId = merchantId;
                        _bomyuser.SecondCategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                        _bomyuser.ExamId = chklist().Item2;
                        _bomyuser.ExamCode = chklist().Item1;
                        _bomyuser.ValidTime = Convert.ToInt32(txtValidTime.Text);
                        _bomyuser.AccessOption = accessoption();
                        _bomyuser.IsActive = true;
                        _bomyuser.IsDelete = false;
                        _bomyuser.CreatedBy = merchantId;
                        _bomyuser.CreatedDate = DateTime.UtcNow;
                        _bomyuser.UpdatedBy = merchantId;
                        _bomyuser.UpdatedDate = DateTime.UtcNow;
                        _bomyuser.Event = "Update";
                        MessageBox.Show(Common.Message(_bamyuser.Update(_bomyuser)));

                    }
                    else
                    {
                        _bomyuser.UserName = txtUserName.Text;
                        _bomyuser.AccessPassword = Encryptdata(txtAccesspassword.Text);
                        _bomyuser.MerchantId = merchantId;
                        _bomyuser.SecondCategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                        _bomyuser.ExamId = chklist().Item2;
                        _bomyuser.ExamCode = chklist().Item1;
                        _bomyuser.ValidTime = Convert.ToInt32(txtValidTime.Text);
                        _bomyuser.AccessOption = accessoption();
                        _bomyuser.IsActive = true;
                        _bomyuser.IsDelete = false;
                        _bomyuser.CreatedBy = merchantId;
                        _bomyuser.CreatedDate = DateTime.UtcNow;
                        _bomyuser.UpdatedBy = merchantId;
                        _bomyuser.UpdatedDate = DateTime.UtcNow;
                        _bomyuser.Event = "Insert";
                        MessageBox.Show(Common.Message(_bamyuser.Insert(_bomyuser)));
                    }
                    ClearControl();
                }
                else
                {
                    MessageBox.Show("Please Enter Or Select Value");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearControl()
        {
            foreach (DataGridViewRow row1 in dgvChklist.Rows)
            {
                row1.Cells["checkBoxColumn"].Value = false;
            }
            BindGrdiview(merchantId);
            chkOnline.Checked = false;
            chkOffline.Checked = false;
            userId = default(int);
            btnAdd.Text = "Add";
            txtUserName.Text = txtAccesspassword.Text = "";
            cmbCategory.SelectedIndex = 0;
        }

        private bool ValidateName()
        {
            bool bStatus = true;
            if (txtUserName.Text == "")
            {
                errorProvider1.SetError(txtUserName, "Please enter User Name");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtUserName, "");
            return bStatus;
        }
        private bool ValidatePassword()
        {
            bool bStatus = true;
            if (txtAccesspassword.Text == "")
            {
                errorProvider1.SetError(txtAccesspassword, "Please enter Access Password");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtAccesspassword, "");
            return bStatus;
        }
        private bool ValidateCmbCategory()
        {
            bool bStatus = true;
            if (cmbCategory.Text == "")
            {
                errorProvider1.SetError(cmbCategory, "Please Select Category");
                bStatus = false;
            }
            else
                errorProvider1.SetError(cmbCategory, "");
            return bStatus;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            ValidateName();
        }

        private void txtAccesspassword_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword();
        }

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            ValidateCmbCategory();
        }

        private string accessoption()
        {
            string str = default(string);
            if (chkOnline.Checked)
            {
                str += chkOnline.Text;
            }
            if (chkOffline.Checked)
            {
                if (str != "" && str != null)
                    str += "&" + chkOffline.Text;
                else
                    str += chkOffline.Text;
            }

            return str;
        }

        private Tuple<string, string> chklist()
        {
            string exmcode = string.Empty;
            string exmcodeid = string.Empty;
            foreach (DataGridViewRow row in dgvChklist.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    //message += Environment.NewLine;
                    if (exmcode != "" && exmcode != null)
                    {
                        exmcode += "," + row.Cells["ExamCode"].Value.ToString();
                        exmcodeid += "," + row.Cells["ExamCodeId"].Value.ToString();
                    }
                    else
                    {
                        exmcode += row.Cells["ExamCode"].Value.ToString();
                        exmcodeid += row.Cells["ExamCodeId"].Value.ToString();
                    }
                }
            }

            // MessageBox.Show("Selected Values" + exmcode);
            return Tuple.Create(exmcode, exmcodeid);
        }

        private void dgvExamMerchant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvExamMerchant.Columns[e.ColumnIndex].Name == "Edit")
                {
                    ClearControl();
                    userId = Convert.ToInt32(dgvExamMerchant.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtUserName.Text = dgvExamMerchant.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtAccesspassword.Text = dgvExamMerchant.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbCategory.Text = dgvExamMerchant.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string[] excode = dgvExamMerchant.Rows[e.RowIndex].Cells[4].Value.ToString().Split(',');
                    txtValidTime.Text = dgvExamMerchant.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string[] accessoption = dgvExamMerchant.Rows[e.RowIndex].Cells[6].Value.ToString().Split('&');
                    foreach (DataGridViewRow row1 in dgvChklist.Rows)
                    {
                        foreach (string s in excode)
                        {
                            if (s == row1.Cells["ExamCode"].Value.ToString())
                            {
                                // bool isSelected = Convert.ToBoolean(row1.Cells["checkBoxColumn"].Value);
                                row1.Cells["checkBoxColumn"].Value = true;
                            }
                        }
                    }
                    foreach (string s in accessoption)
                    {
                        if (s == chkOnline.Text)
                        {
                            chkOnline.Checked = true;
                        }
                        if (s == chkOffline.Text)
                        {
                            chkOffline.Checked = true;
                        }
                    }
                    btnAdd.Text = "Update";
                }
                else if (dgvExamMerchant.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord of " + dgvExamMerchant.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Warning", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        userId = Convert.ToInt32(dgvExamMerchant.Rows[e.RowIndex].Cells[0].Value.ToString());
                        _bomyuser.UserId = userId;

                        _bomyuser.ValidTime = 0;
                        _bomyuser.IsActive = true;
                        _bomyuser.IsDelete = true;
                        _bomyuser.CreatedBy = merchantId;
                        _bomyuser.CreatedDate = DateTime.UtcNow;
                        _bomyuser.UpdatedBy = merchantId;
                        _bomyuser.UpdatedDate = DateTime.UtcNow;
                        _bomyuser.Event = "Delete";
                        MessageBox.Show(Common.Message(_bamyuser.Delete(_bomyuser)));
                        ClearControl();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtValidTime_KeyPress(object sender, KeyPressEventArgs e)
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



        private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsHeaderCheckBoxClicked)
                RowCheckBoxClick((DataGridViewCheckBoxCell)dgvChklist[e.ColumnIndex, e.RowIndex]);
        }

        private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvChklist.CurrentCell is DataGridViewCheckBoxCell)
                dgvChklist.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void dgvSelectAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvChklist.Controls.Add(HeaderCheckBox);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvChklist.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvChklist.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["checkBoxColumn"]).Value = HCheckBox.Checked;

            dgvChklist.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modifiy Counter;            
                if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                //Change state of the header CheckBox.
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }
    }
}
