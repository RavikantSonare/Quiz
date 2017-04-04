using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DesktopMerchant.BOLayer;
using DesktopMerchant.BALayer;

namespace DesktopMerchant
{
    public partial class frmExampReports : Form
    {
        private int MerchantID = default(int);
        private int tmpltID = default(int);

        private BOTemplate _botmplt = new BOTemplate();
        private BATemplate _batmple = new BATemplate();
        private List<BOTemplate> _botmpltlist = new List<BOTemplate>();

        private BOExamReport _boexmrpt = new BOExamReport();
        private BAExamReport _baexmrpt = new BAExamReport();
        private List<BOExamReport> _boexmrptlist = new List<BOExamReport>();

        public frmExampReports(int mid)
        {
            InitializeComponent();
            MerchantID = mid;
        }

        private void frmExampReports_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;

                FillTemplateGridview(MerchantID);
                dgvTemplate.Columns[0].Visible = false;
                dgvTemplate.Columns[3].Visible = false;

                FillExamReportGridview(MerchantID);
                dgvExamReports.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select a Image";
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";

            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Images\"; // <---
            if (Directory.Exists(appPath) == false)                                              // <---
            {                                                                                    // <---
                Directory.CreateDirectory(appPath);                                              // <---
            }                                                                                    // <---

            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = opFile.SafeFileName;   // <---
                    string filepath = opFile.FileName;    // <---
                    File.Copy(filepath, appPath + iName); // <---
                    txtTemplatePicture.Text = appPath + iName;        // picProduct.Image = new Bitmap(opFile.OpenFile());
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
                opFile.Dispose();
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmpltID > 0)
                {
                    _botmplt.TemplateId = tmpltID;
                    _botmplt.CertificateTitle = txtCertificateTitle.Text;
                    _botmplt.SampleUserName = lblsamplemsg.Text;
                    _botmplt.TemplatePicture = txtTemplatePicture.Text;
                    _botmplt.MerchantId = MerchantID;
                    _botmplt.IsActive = true;
                    _botmplt.IsDelete = false;
                    _botmplt.CreatedBy = MerchantID;
                    _botmplt.CreatedDate = DateTime.UtcNow;
                    _botmplt.UpdatedBy = MerchantID;
                    _botmplt.UpdatedDate = DateTime.UtcNow;
                    _botmplt.Event = "Update";
                    MessageBox.Show(Common.Message(_batmple.Update(_botmplt)));
                }
                else
                {
                    _botmplt.CertificateTitle = txtCertificateTitle.Text;
                    _botmplt.SampleUserName = lblsamplemsg.Text;
                    _botmplt.TemplatePicture = txtTemplatePicture.Text;
                    _botmplt.MerchantId = MerchantID;
                    _botmplt.IsActive = true;
                    _botmplt.IsDelete = false;
                    _botmplt.CreatedBy = MerchantID;
                    _botmplt.CreatedDate = DateTime.UtcNow;
                    _botmplt.UpdatedBy = MerchantID;
                    _botmplt.UpdatedDate = DateTime.UtcNow;
                    _botmplt.Event = "Insert";
                    MessageBox.Show(Common.Message("Template", _batmple.Insert(_botmplt)));
                }
                Clearcontrol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTemplateGridview(int Mid)
        {
            _botmpltlist = _batmple.SelecttemplateList("GetTemplateMID", Mid);
            if (_botmpltlist.Count > 0)
            {
                int tmp = 0;
                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(_botmpltlist);
                dgvTemplate.Rows.Clear();
                foreach (DataRow row in _table.Rows)
                {
                    dgvTemplate.Rows.Add();
                    dgvTemplate.Rows[tmp].Cells[0].Value = Convert.ToString(row["TemplateId"]);
                    dgvTemplate.Rows[tmp].Cells[1].Value = Convert.ToString(row["CertificateTitle"]);
                    Bitmap bitmp = new Bitmap(row["TemplatePicture"].ToString());
                    dgvTemplate.Rows[tmp].Cells[2].Value = bitmp;
                    dgvTemplate.Rows[tmp].Cells[2].Style.Padding = new Padding(10, 10, 10, 10);
                    dgvTemplate.Rows[tmp].Cells[3].Value = Convert.ToString(row["TemplatePicture"]);
                    dgvTemplate.Rows[tmp].Height = 100;
                    tmp++;
                }
            }
        }

        private void FillExamReportGridview(int Mid)
        {
            _boexmrptlist = _baexmrpt.SelectExamreportList("GetExamRptMID", Mid);
            if (_boexmrptlist.Count > 0)
            {
                int tmp = 0;
                DataTable _table = new DataTable();
                _table = Common.LINQToDataTable(_boexmrptlist);
                dgvExamReports.Rows.Clear();
                _botmpltlist = _batmple.SelecttemplateList("GetTemplateMID", Mid);
                foreach (DataRow row in _table.Rows)
                {
                    dgvExamReports.Rows.Add();
                    dgvExamReports.Rows[tmp].Cells[0].Value = Convert.ToString(row["ExamReportId"]);
                    dgvExamReports.Rows[tmp].Cells[1].Value = Convert.ToString(row["UserName"]);
                    dgvExamReports.Rows[tmp].Cells[2].Value = Convert.ToString(row["CategoryName"]);
                    dgvExamReports.Rows[tmp].Cells[3].Value = Convert.ToString(row["ExamCode"]);
                    if (Convert.ToBoolean(row["Result"]))
                    {
                        dgvExamReports.Rows[tmp].Cells[4].Value = "Pass";
                    }
                    else
                    {
                        dgvExamReports.Rows[tmp].Cells[4].Value = "Fail";
                    }
                    dgvExamReports.Rows[tmp].Cells[5].Value = Convert.ToString(row["Score"]);
                    if (Convert.ToBoolean(row["AllowPrint"]))
                    {
                        dgvExamReports.Rows[tmp].Cells[6].Value = "Yes";
                    }
                    else
                    {
                        dgvExamReports.Rows[tmp].Cells[6].Value = "No";
                    }
                    DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)(dgvExamReports.Rows[tmp].Cells[7]);
                    ComboColumn.ValueMember = "TemplateId";
                    ComboColumn.DisplayMember = "CertificateTitle";
                    ComboColumn.DataSource = _botmpltlist;
                    dgvExamReports.Rows[tmp].Cells[8].Style.Padding = new Padding(10, 1, 10, 1);
                    tmp++;
                }
            }
        }

        private void Clearcontrol()
        {
            txtCertificateTitle.Text = txtTemplatePicture.Text = "";
            FillTemplateGridview(MerchantID);
        }

        private void dgvTemplate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTemplate.Columns[e.ColumnIndex].Name == "Edit")
            {
                tmpltID = Convert.ToInt32(dgvTemplate.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCertificateTitle.Text = dgvTemplate.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTemplatePicture.Text = dgvTemplate.Rows[e.RowIndex].Cells[3].Value.ToString();
                btnSaveTemplate.Text = "Update";
            }
            else if (dgvTemplate.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult result1 = MessageBox.Show("Are you sure you want to delete\nrecord " + dgvTemplate.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Warning", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    tmpltID = Convert.ToInt32(dgvTemplate.Rows[e.RowIndex].Cells[0].Value.ToString());
                    _botmplt.TemplateId = tmpltID;
                    _botmplt.CertificateTitle = txtCertificateTitle.Text;
                    _botmplt.SampleUserName = lblsamplemsg.Text;
                    _botmplt.TemplatePicture = txtTemplatePicture.Text;
                    _botmplt.MerchantId = MerchantID;
                    _botmplt.IsActive = true;
                    _botmplt.IsDelete = true;
                    _botmplt.CreatedBy = MerchantID;
                    _botmplt.CreatedDate = DateTime.UtcNow;
                    _botmplt.UpdatedBy = MerchantID;
                    _botmplt.UpdatedDate = DateTime.UtcNow;
                    _botmplt.Event = "Delete";
                    MessageBox.Show(Common.Message(dgvTemplate.Rows[e.RowIndex].Cells[1].Value.ToString(), _batmple.Delete(_botmplt)));
                    Clearcontrol();
                }
            }
        }
    }
}
