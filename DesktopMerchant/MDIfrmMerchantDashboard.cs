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
    public partial class MDIfrmMerchantDashboard : Form
    {
        private BOMerchantManage _bomermng = new BOMerchantManage();
        private BAMerchantManage _bamermng = new BAMerchantManage();
        private List<BOMerchantManage> _bomermnglist = new List<BOMerchantManage>();

        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private List<BOExamManage> _boexmmnglist = new List<BOExamManage>();

        private int merchantId = default(int);

        public MDIfrmMerchantDashboard(int loginid)
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = Color.White;
            }
            merchantId = loginid;

            Bind_TopCategoryCombo();

            FillMarchantInfoGridView(loginid);
            dgvMerchantProfile.Columns[0].Visible = false;

            FillMerchantExamGridview(loginid);
            dgvExamMerchant.Columns[1].Visible = false;
        }

        private void FillMarchantInfoGridView(int Loginid)
        {
            _bomermng.Event = "GETWITHID";
            _bomermnglist = _bamermng.SelectMerchantDetail(Loginid, _bomermng);
            int tmp = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_bomermnglist);
            dgvMerchantProfile.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvMerchantProfile.Rows.Add();
                dgvMerchantProfile.Rows[tmp].Cells[0].Value = Convert.ToString(row["MerchantId"]);
                dgvMerchantProfile.Rows[tmp].Cells[1].Value = Convert.ToString(row["EndDate"]);
                dgvMerchantProfile.Rows[tmp].Cells[2].Value = Convert.ToString(row["MerchantName"]);
                dgvMerchantProfile.Rows[tmp].Cells[3].Value = Convert.ToString(row["UserName"]);
                dgvMerchantProfile.Rows[tmp].Cells[4].Value = Convert.ToString(row["MerchantLevel"]);
                tmp++;
            }
        }

        private void FillMerchantExamGridview(int loginid)
        {
            _boexmmng.Event = "GetExamWithMId";
            _boexmmng.MerchantId = loginid;
            _boexmmnglist = _baexmmng.SelectMerchantExamDetail(_boexmmng);
            int tmp = 0;
            DataTable _table = new DataTable();
            _table = Common.LINQToDataTable(_boexmmnglist);
            dgvExamMerchant.Rows.Clear();
            foreach (DataRow row in _table.Rows)
            {
                dgvExamMerchant.Rows.Add();
                dgvExamMerchant.Rows[tmp].Cells[1].Value = Convert.ToString(row["ExamCodeId"]);
                dgvExamMerchant.Rows[tmp].Cells[2].Value = Convert.ToString(row["ExamCode"]);
                dgvExamMerchant.Rows[tmp].Cells[3].Value = Convert.ToString(row["SecondCategory"]);
                dgvExamMerchant.Rows[tmp].Cells[4].Value = Convert.ToString(row["TestTime"]);
                dgvExamMerchant.Rows[tmp].Cells[5].Value = Convert.ToString(row["ValidDate"]);
                tmp++;
            }
        }

        private void Bind_TopCategoryCombo()
        {
            BOTopCategory _botopcat = new BOTopCategory();
            BATopCategory _batopcat = new BATopCategory();
            _botopcat.Event = "GETALL";
            List<BOTopCategory> TCateList = _batopcat.SelectTopCategoryList(_botopcat);
            if (TCateList.Count > 0)
            {
                cmbTopcat.DataSource = TCateList;
                cmbTopcat.DisplayMember = "TopCategoryName";
                cmbTopcat.ValueMember = "TopCategoryID";
            }
        }

        public void ButtonHover(Button btn, string btntext)
        {
            Common.BtnHideHover(tableLayoutPanel2);
            foreach (Form frm in this.MdiChildren)
            {
                if (btn.Text == btntext)
                {
                    btn.BackColor = Color.Blue;
                }
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

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            //Closeallfrm();
            //frmAdminTopCategory frm = new frmAdminTopCategory(loginID);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.MdiParent = this;
            //frm.Show();
            //DisposeAllButThis(frm);
            //ButtonHover(btnAddExam, "Add Exam");
        }

        private void btnMyExam_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmMyExam));
            bool isFormOpen = IsAlreadyOpen(typeof(frmMyExam));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmMyExam frm = new frmMyExam(merchantId);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnMyExam, "My Exam");
        }

        private void btnMyUser_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmMyUser));
            bool isFormOpen = IsAlreadyOpen(typeof(frmMyUser));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmMyUser frm = new frmMyUser(merchantId);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnMyUser, "My User");
        }

        private void btnConfigexam_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmExamConfig));
            bool isFormOpen = IsAlreadyOpen(typeof(frmExamConfig));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmExamConfig frm = new frmExamConfig(merchantId);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnConfigexam, "Config Exam");
        }

        private void btnSalesReports_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmSalesReports));
            bool isFormOpen = IsAlreadyOpen(typeof(frmSalesReports));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmSalesReports frm = new frmSalesReports(merchantId);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnSalesReports, "Sales Reports");
        }

        private void btnFinanceConfig_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmFinanceConfig));
            bool isFormOpen = IsAlreadyOpen(typeof(frmFinanceConfig));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmFinanceConfig frm = new frmFinanceConfig(merchantId);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnFinanceConfig, "Finance Config");
        }

        private void btnFinanceWithDraw_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmFinanceWithDraw));
            bool isFormOpen = IsAlreadyOpen(typeof(frmFinanceWithDraw));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmFinanceWithDraw frm = new frmFinanceWithDraw(merchantId);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnFinanceWithDraw, "Finance WithDraw");
        }

        private void btnExamReport_Click(object sender, EventArgs e)
        {
            Closeallfrm(typeof(frmExampReports));
            bool isFormOpen = IsAlreadyOpen(typeof(frmExampReports));
            if (isFormOpen == false)
            {
                panel1.Visible = false;
                frmExampReports frm = new frmExampReports(merchantId);
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
            ButtonHover(btnExamReport, "Exam Report");
        }
    }
}
