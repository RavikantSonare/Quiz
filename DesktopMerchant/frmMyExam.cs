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
    public partial class frmMyExam : Form
    {
        private BOExamManage _boexmmng = new BOExamManage();
        private BAExamManage _baexmmng = new BAExamManage();
        private List<BOExamManage> _boexmmnglist = new List<BOExamManage>();

        private int merchantId = default(int);

        public frmMyExam(int id)
        {
            InitializeComponent();
            merchantId = id;
        }

        private void frmMyExam_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                FillMerchantExamGridview(merchantId);
                dgvExamMerchant.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    }
}
