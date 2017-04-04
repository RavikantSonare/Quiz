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
    public partial class MDIfrmAdminDashboard : Form
    {
        private BAExamManage _baexmmng = new BAExamManage();
        private BOExamManage _boexmmng = new BOExamManage();
        private List<BOExamManage> _boexmmnglist = new List<BOExamManage>();
        private int loginID = default(int);
        private bool headval = default(bool);

        public MDIfrmAdminDashboard(int loginid)
        {
            try
            {
                InitializeComponent();
                loginID = loginid;
                foreach (Control c in this.Controls)
                {
                    if (c is MdiClient)
                        c.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MDIfrmAdminDashboard_Load(object sender, EventArgs e)
        {
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
        private void MDIfrmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private bool IsAlreadyOpen(Type formType)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == formType)
                {
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;
                    isOpen = true;
                }
            }
            return isOpen;
        }
        public void Closeallfrm(Type formType)
        {
            Form[] childarray = this.MdiChildren;
            foreach (Form child in childarray)
            {
                if (child != null)
                    if (child.GetType() == formType)
                    {
                    }
                    else
                    {
                        child.Close();
                    }
            }
        }
        public void ButtonHover(Button btn, string btntext)
        {
            Common.BtnHideHover(tableLayoutPanel1);
            foreach (Form frm in this.MdiChildren)
            {
                if (btn.Text == btntext)
                {
                    btn.BackColor = Color.Blue;
                }
            }
        }

        private void btnTopCat_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmAdminTopCategory));
            bool isFormOpen = IsAlreadyOpen(typeof(frmAdminTopCategory));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmAdminTopCategory frm = new frmAdminTopCategory(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnTopCat, "Top Category");
        }

        private void btnSecondCat_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmAdminSecondCategory));
            bool isFormOpen = IsAlreadyOpen(typeof(frmAdminSecondCategory));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmAdminSecondCategory frm = new frmAdminSecondCategory(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnSecondCat, "Second Category");
        }

        private void btnThirdCat_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmAdminThirdCategory));
            bool isFormOpen = IsAlreadyOpen(typeof(frmAdminThirdCategory));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmAdminThirdCategory frm = new frmAdminThirdCategory(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnThirdCat, "Third Category");
        }

        private void btnQuestionType_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmQuestionTypeManage));
            bool isFormOpen = IsAlreadyOpen(typeof(frmQuestionTypeManage));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmQuestionTypeManage frm = new frmQuestionTypeManage(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnQuestionType, "Question Type Manage");
        }

        private void btnMerchantLevel_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmMerchantLevel));
            bool isFormOpen = IsAlreadyOpen(typeof(frmMerchantLevel));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmMerchantLevel frm = new frmMerchantLevel(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnMerchantLevel, "Merchant Level");
        }

        private void btnMerchantFeeRate_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmMerchantFeeRate));
            bool isFormOpen = IsAlreadyOpen(typeof(frmMerchantFeeRate));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmMerchantFeeRate frm = new frmMerchantFeeRate(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnMerchantFeeRate, "Merchant Fee Rate");
        }

        private void btnMerchantManage_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmMerchantManage));
            bool isFormOpen = IsAlreadyOpen(typeof(frmMerchantManage));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmMerchantManage frm = new frmMerchantManage(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnMerchantManage, "Merchant Manage");
        }

        private void btnWithdrawoption_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmWithdrawOption));
            bool isFormOpen = IsAlreadyOpen(typeof(frmWithdrawOption));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmWithdrawOption frm = new frmWithdrawOption(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnWithdrawoption, "Add WithDraw Option");
        }

        private void btnExamManage_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmExamsManage));
            bool isFormOpen = IsAlreadyOpen(typeof(frmExamsManage));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmExamsManage frm = new frmExamsManage(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnExamManage, "Exam Manage");
        }

        private void btnSalesReports_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmSalesReports));
            bool isFormOpen = IsAlreadyOpen(typeof(frmSalesReports));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmSalesReports frm = new frmSalesReports(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnSalesReports, "Sales Reports");
        }

        private void btnWithDrawManage_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmWithDrawManage));
            bool isFormOpen = IsAlreadyOpen(typeof(frmWithDrawManage));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmWithDrawManage frm = new frmWithDrawManage(loginID);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnWithDrawManage, "WithDraw Manage");
        }

    }
}
